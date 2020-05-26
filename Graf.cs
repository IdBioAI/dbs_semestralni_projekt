using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbs_semestralka
{
    public partial class Graf : Form
    {

        String DatumOd = "";
        String DatumDo = "";

        RidiciFormular ridiciFormular;
        public Graf(RidiciFormular ridiciFormular)
        {
            this.ridiciFormular = ridiciFormular;

            InitializeComponent();
        }

        private void Graf_Load(object sender, EventArgs e)
        {

            NahratStroje();
            NahratStav();
            NahratBaterie();
            ZprcovatDatum();
        }

        private void ZprcovatDatum()
        {
            DatumOd = Convert.ToDateTime(dateTimePicker1.Text).ToString("yyyy/MM/dd HH:mm:ss");
            DatumOd = Convert.ToString(DatumOd).Replace(".", "/");

            DatumDo = Convert.ToDateTime(dateTimePicker3.Text).ToString("yyyy/MM/dd");
            DatumDo += " 23:59:59";
            DatumDo = Convert.ToString(DatumDo).Replace(".", "/");
        }

        private void NahratStav()
        {
            MySqlConnection connection = null;
            int[] stav = new int[6];

            try
            {
                chartStav.Series.Clear();
                connection = ridiciFormular.GetConnection();
                List<String> VIN = new List<string>();

                MySqlCommand mySqlCommand = new MySqlCommand("SELECT VIN FROM mydb.stroj;", connection);

                using (var reader = mySqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VIN.Add(reader.GetString(reader.GetOrdinal("VIN")));
                    }
                }

                foreach(string v in VIN)
                {
                    mySqlCommand = new MySqlCommand("SELECT MAX(Datum) as Maximum FROM mydb.udajestroj WHERE stroj_VIN = '" + v + "';", connection);
                    string datum = "";
                    using (var reader = mySqlCommand.ExecuteReader())
                    {
                        if (reader.Read()) {
                            datum = reader.GetString("Maximum");

                        }
                    }
                    mySqlCommand = new MySqlCommand("SELECT Stav FROM mydb.udajeStroj WHERE stroj_VIN = '" + v + "' AND '" + Convert.ToDateTime(datum).ToString("yyyy/MM/dd HH:mm:ss") + "' = Datum;", connection);
                    using (var reader = mySqlCommand.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            if (reader.GetInt32("Stav") == 0) stav[0]++;
                            else if (reader.GetInt32("Stav") == 1) stav[1]++;
                            else if (reader.GetInt32("Stav") == 2) stav[2]++;
                            else if (reader.GetInt32("Stav") == 3) stav[3]++;
                            else if (reader.GetInt32("Stav") == 4) stav[4]++;
                            else if (reader.GetInt32("Stav") == 5) stav[5]++;
                        }
                    }
                }


            }
            catch (Exception ex){}
            chartStav.Series.Add("Stav");
            chartStav.Series["Stav"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            chartStav.Series["Stav"].IsValueShownAsLabel = true;
            chartStav.Series["Stav"].Label = "";
            chartStav.Series["Stav"].Points.AddXY("v klidu", stav[0]);
            chartStav.Series["Stav"].Points.AddXY("v pohybu", stav[1]);
            chartStav.Series["Stav"].Points.AddXY("orá", stav[2]);
            chartStav.Series["Stav"].Points.AddXY("seje", stav[3]);
            chartStav.Series["Stav"].Points.AddXY("práškuje", stav[4]);
            chartStav.Series["Stav"].Points.AddXY("hnojí", stav[5]);
        }

        private void NahratStroje()
        {
            MySqlConnection connection = null;
            try
            {
                comboBox1.Items.Clear();
                connection = ridiciFormular.GetConnection();

                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Nazev FROM mydb.stroj;", connection);

                using (var reader = mySqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader.GetString("Nazev"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při načítání", "UPOZORNĚNÍ");

            }
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            NahratStav();
            NahratBaterie();
        }

        private void Chart2_Click(object sender, EventArgs e)
        {
            NahratBaterie();
        }

        private void NahratBaterie()
        {
            chartBaterie.Series.Clear();
            MySqlConnection connection = null;
            Dictionary<String, Int16> dict = new Dictionary<string, short>();

            try
            {
                connection = ridiciFormular.GetConnection();
                Dictionary<String, String> VIN = new Dictionary<String, String>();

                MySqlCommand mySqlCommand = new MySqlCommand("SELECT VIN, Nazev FROM mydb.stroj;", connection);

                using (var reader = mySqlCommand.ExecuteReader())
                {
                    while (reader.Read()) VIN.Add(reader.GetString("VIN"), reader.GetString("Nazev"));
                }

                foreach (KeyValuePair<String,String> pom in VIN)
                {
                    string v = pom.Key;
                    mySqlCommand = new MySqlCommand("SELECT MAX(Datum) as Maximum FROM mydb.udajestroj WHERE stroj_VIN = '" + v + "';", connection);
                    string datum = "";
                    using (var reader = mySqlCommand.ExecuteReader())
                    {
                        if (reader.Read()) datum = reader.GetString("Maximum");
                    }
                    mySqlCommand = new MySqlCommand("SELECT StavBaterie FROM mydb.udajeStroj WHERE stroj_VIN = '" + v + "' AND '" + Convert.ToDateTime(datum).ToString("yyyy/MM/dd HH:mm:ss") + "' = Datum;", connection);
                    using (var reader = mySqlCommand.ExecuteReader())
                    {
                        if (reader.Read()) dict.Add(pom.Value, reader.GetInt16("StavBaterie"));
                    }
                }
                dict = findSmallest(dict);
                chartBaterie.Series.Add("10 nejnižších baterií");
                chartBaterie.Legends.Clear();
                chartBaterie.Series["10 nejnižších baterií"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

                foreach (KeyValuePair<String,short> key in dict)
                {
                    chartBaterie.Series["10 nejnižších baterií"].Points.AddXY(key.Key, key.Value);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Chyba při načítání", "UPOZORNĚNÍ");
            }
        }

        private Dictionary<String, short> findSmallest(Dictionary<String, short> dict)
        {
            Dictionary<String, short> returnDict = new Dictionary<string, short>();
            for(int i = 0; i < 7; i++)
            {
                short smallestvalue = 100;
                string key;
                foreach (KeyValuePair<String, short> pom in dict)
                {
                    if (pom.Value < smallestvalue) smallestvalue = pom.Value;

                }
                key = dict.FirstOrDefault(x => x.Value == smallestvalue).Key;
                returnDict.Add(key,smallestvalue);
                dict.Remove(key);
            }          
        return returnDict;
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DatumOd = Convert.ToDateTime(dateTimePicker1.Text).ToString("yyyy/MM/dd HH:mm:ss");
            DatumOd = Convert.ToString(DatumOd).Replace(".", "/");
        }

        private void DateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            DatumDo = Convert.ToDateTime(dateTimePicker3.Text).ToString("yyyy/MM/dd");
            DatumDo += " 23:59:59";
            DatumDo = Convert.ToString(DatumDo).Replace(".", "/");
        }

        private void ButtonShow_Click(object sender, EventArgs e)
        {
            try
            {
                chartTenzo.Series.Clear();
                String nazev = comboBox1.SelectedItem.ToString();

                String VIN = "";
                MySqlConnection connection = ridiciFormular.GetConnection();
                ZprcovatDatum();




                MySqlCommand mySqlCommand = new MySqlCommand("SELECT VIN FROM mydb.stroj WHERE Nazev = '" + nazev + "';", connection);

                using (var reader = mySqlCommand.ExecuteReader())
                {
                    if (reader.Read()) VIN = reader.GetString("VIN");
                }

                List<String> oznaceniTenzo = new List<String>();

                mySqlCommand = new MySqlCommand("SELECT DISTINCT oznaceniTenzo FROM mydb.udajeTenzometr WHERE udajeStroj_stroj_VIN = '" + VIN +
                   "' AND udajeStroj_Datum BETWEEN '" + DatumOd + "' AND '" + DatumDo + "' ;", connection);
                using (var reader = mySqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string pom = reader.GetString("oznaceniTenzo");
                        if (!oznaceniTenzo.Contains(pom)) oznaceniTenzo.Add(pom);
                    }
                }

                foreach (string ozn in oznaceniTenzo)
                {
                    chartTenzo.Series.Add(ozn);
                    chartTenzo.Series[ozn].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    chartTenzo.Series[ozn].BorderWidth = 3;

                    mySqlCommand = new MySqlCommand("SELECT hodnota, udajeStroj_Datum FROM mydb.udajeTenzometr WHERE oznaceniTenzo = '" + ozn +
                    "' AND udajeStroj_Datum BETWEEN '" + DatumOd + "' AND '" + DatumDo + "' ;", connection);
                    using (var reader = mySqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            decimal pom = reader.GetDecimal("hodnota");
                            DateTime dt = reader.GetDateTime("udajeStroj_Datum");
                            chartTenzo.Series[ozn].Points.AddXY(dt, pom);
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Něco se nepovedlo :/");
            }
            

            
        }

        private void ChartStav_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonShow.Enabled = true;
        }

        private void ChartTenzo_Click(object sender, EventArgs e)
        {

        }
    }
}
