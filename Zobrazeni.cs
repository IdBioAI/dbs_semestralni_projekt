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
    public partial class Zobrazeni : Form
    {
        RidiciFormular ridiciFormular;

        String DatumOd = "";
        String DatumDo = "";

        int zvoleno = 0; // 0 - hledání udajestroj 1 - hledání tenzo
        bool nalezeno = false;

        int OffsetNP = 0; // Stránkování u historie nákup/prodej
        int AktualniStrankaNP = 1;
        int PocetStranekNP = 0;

        public Zobrazeni(RidiciFormular ridiciFormular)
        {
            this.ridiciFormular = ridiciFormular;
            InitializeComponent();
        }

        private void Zobrazeni_Load(object sender, EventArgs e)
        {
            DatumOd = Convert.ToDateTime(dateTimePicker1.Text).ToString("yyyy/MM/dd");
            DatumOd = Convert.ToString(DatumOd).Replace(".", "/");
            DatumOd = Convert.ToString(DatumOd).Replace(" ", "");

            DatumDo = Convert.ToDateTime(dateTimePicker2.Text).ToString("yyyy/MM/dd");
            DatumDo = Convert.ToString(DatumDo).Replace(".", "/");
            DatumDo = Convert.ToString(DatumOd).Replace(" ", "");

            dateTimePicker3.Text = "00:00:00";

            Nahrat();
            NahratData();
        }

        private void Nahrat()
        {

            MySqlConnection connection = null;

            try
            {
                comboStroje.Items.Clear();
                comboIoT.Items.Clear();

                comboStroje.Items.Add("Vše");
                comboIoT.Items.Add("Vše");

                connection = ridiciFormular.GetConnection();

                MySqlCommand mySqlCommand = new MySqlCommand("SELECT VIN FROM mydb.stroj;", connection);

                using (var reader = mySqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboStroje.Items.Add(reader.GetString(reader.GetOrdinal("VIN")));
                    }
                }

                mySqlCommand = new MySqlCommand("SELECT SerioveCislo FROM mydb.iotprvek;", connection);

                using (var reader = mySqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboIoT.Items.Add(reader.GetString(reader.GetOrdinal("SerioveCislo")));
                    }
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Chyba při načítání", "UPOZORNĚNÍ");

            }
        }

        private void NahratData()
        {

            try
            {
                dataGridView2.Columns.Clear();
            }
            catch
            {

            }

            MySqlConnection connection = ridiciFormular.GetConnection();
            String orderBy = "ASC";
            String sqlQuery = "SELECT stroj.Nazev, stroj_VIN as 'VIN', IoTPrvek_SerioveCislo as 'sériové číslo', Datum as 'datum', X, Y, Z, StavBaterie as 'stav baterie', Stav as 'stav', GPS" +
                              " FROM mydb.udajestroj ";
            String podminky = " JOIN mydb.stroj ON stroj.VIN =  udajestroj.stroj_VIN" +
                              " WHERE Datum BETWEEN '" + DatumOd + " " + dateTimePicker3.Text + "' AND '" + DatumDo + " " + dateTimePicker4.Text + "' ";

            if (checkBox1.Checked)
            {
                podminky += " AND X > '" + numericUpDown1.Value + "'";
                podminky += " AND Y > '" + numericUpDown1.Value + "'";
                podminky += " AND Z > '" + numericUpDown1.Value + "'";
            }
            else
            {
                podminky += " AND X < '" + numericUpDown1.Value + "'";
                podminky += " AND Y < '" + numericUpDown1.Value + "'";
                podminky += " AND Z < '" + numericUpDown1.Value + "'";
            }

            if (comboStav.SelectedIndex > 0)
            {
                podminky += " AND Stav = '" + comboStav.SelectedIndex + "'";
            }

            if (comboStroje.SelectedIndex > 0)
            {
                podminky += " AND stroj_VIN = '" + comboStroje.Text + "'";
            }

            if (comboIoT.SelectedIndex > 0)
            {
                podminky += " AND IoTPrvek_SerioveCislo = '" + comboIoT.Text + "'";
            }

            podminky += " ORDER BY ";

            if (checkASC.Checked)
            {
                podminky = "ASC";
            }
            if (checkdsc.Checked)
            {
                podminky = "DESC";
            }

            if (checkDatum.Checked)
            {
                podminky += " Datum " + orderBy + ", ";
            }
            if (checkStroj.Checked)
            {
                podminky += " stroj_VIN " + orderBy + ", ";
            }
            if (checkIoT.Checked)
            {
                podminky += " IoTPrvek_SerioveCislo " + orderBy + ", ";
            }
            if (checkStav.Checked)
            {
                podminky += " Stav " + orderBy + ", ";
            }
            if (checkX.Checked)
            {
                podminky += " X " + orderBy + ", ";
            }
            if (checkY.Checked)
            {
                podminky += " Y " + orderBy + ", ";
            }
            if (checkZ.Checked)
            {
                podminky += " Z " + orderBy + ", ";
            }
            if (checkBaterie.Checked)
            {
                podminky += " StavBaterie " + orderBy + ", ";
            }

            // odstranění čárky na konci příkazu
            podminky = podminky.Remove(podminky.Length - 2);

            podminky += " LIMIT " + OffsetNP + ",32";
            if (!nalezeno) NacteniStranekNP(podminky);
            try
            {
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sqlQuery + podminky, connection);
                DataSet DS = new DataSet();
                mySqlDataAdapter.Fill(DS);
                dataGridView2.DataSource = DS.Tables[0];
            }
            catch(Exception e)
            {
                MessageBox.Show("Nesprávné zvolení parametrů", "Chyba");
            }

        }

        private void ButtHledat_Click(object sender, EventArgs e)
        {
            nalezeno = false;
            zvoleno = 0;
            NahratData();
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DatumOd = Convert.ToDateTime(dateTimePicker1.Text).ToString("yyyy/MM/dd");
            DatumOd = Convert.ToString(DatumOd).Replace(".", "/");
            DatumOd = Convert.ToString(DatumOd).Replace(" ", "");
        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DatumDo = Convert.ToDateTime(dateTimePicker2.Text).ToString("yyyy/MM/dd");
            DatumDo = Convert.ToString(DatumDo).Replace(".", "/");
            DatumDo = Convert.ToString(DatumDo).Replace(" ", "");
        }

        private void ButtHledatTenzo_Click(object sender, EventArgs e)
        {
            zvoleno = 1;
            nalezeno = false;
            try
            {
                dataGridView2.Columns.Clear();
            }
            catch
            {

            }

            MySqlConnection connection = ridiciFormular.GetConnection();
            String orderBy = "ASC";
            String sqlQuery = "SELECT stroj.Nazev, udajeStroj_stroj_VIN as 'VIN', oznaceniTenzo as 'Tenzometr', hodnota as 'Hodnota', udajeStroj_Datum as 'Datum'" +
                              " FROM mydb.udajetenzometr ";
            String podminky = " JOIN mydb.stroj ON stroj.VIN =  udajetenzometr.udajeStroj_stroj_VIN" +
                              " WHERE udajeStroj_Datum BETWEEN '" + DatumOd + " " + dateTimePicker3.Text + "' AND '" + DatumDo + " " + dateTimePicker4.Text + "' ";

            if (checkBox4.Checked)
            {
                podminky += " AND hodnota > '" + numericUpDown4.Value + "'";
            }
            else
            {
                podminky += " AND hodnota < '" + numericUpDown4.Value + "'";
            }
            if (comboStroje.SelectedIndex > 0)
            {
                podminky += " AND udajeStroj_stroj_VIN = '" + comboStroje.Text + "'";
            }

            podminky += " ORDER BY ";

            if (checkASC.Checked)
            {
                orderBy = "ASC";
            }
            if (checkdsc.Checked)
            {
                orderBy = "DESC";
            }

            if (checkDatum.Checked)
            {
                podminky += " Datum " + orderBy + ", ";
            }
            if (checkHodnota.Checked)
            {
                podminky += " hodnota " + orderBy + ", ";
            }

            // odstranění čárky na konci příkazu
            podminky = podminky.Remove(podminky.Length - 2);

            podminky += " LIMIT " + OffsetNP + ",32";
            if (!nalezeno) NacteniStranekNP(podminky);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sqlQuery + podminky, connection);
            DataSet DS = new DataSet();
            mySqlDataAdapter.Fill(DS);
            dataGridView2.DataSource = DS.Tables[0];
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (AktualniStrankaNP != PocetStranekNP)
            {
                OffsetNP += 31;
                AktualniStrankaNP++;
                label1.Text = System.Convert.ToString(AktualniStrankaNP) + "/" + System.Convert.ToString(PocetStranekNP);
                if (zvoleno == 0)
                    NahratData();
                else if (zvoleno == 1)
                    ButtHledatTenzo_Click(null, null);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (AktualniStrankaNP != 1)
            {
                OffsetNP -= 31;
                AktualniStrankaNP--;
                label1.Text = System.Convert.ToString(AktualniStrankaNP) + "/" + System.Convert.ToString(PocetStranekNP);
                if (zvoleno == 0)
                    NahratData();
                else if (zvoleno == 1)
                    ButtHledatTenzo_Click(null, null);
            }
        }

        private void NacteniStranekNP(String podminky)
        {

            MySqlConnection conDataBase = ridiciFormular.GetConnection();

            try
            {
                string stmt = "SELECT COUNT(*) FROM mydb.udajestroj " + podminky;

                using (MySqlCommand cmdCount = new MySqlCommand(stmt, conDataBase))
                {

                    object result = cmdCount.ExecuteScalar();
                    decimal p = Convert.ToDecimal(result);
                    p = Math.Ceiling(p / 31);
                    PocetStranekNP = (int)p;
                    if (PocetStranekNP == 0)
                    {
                        PocetStranekNP = 1;
                    }
                    label1.Text = "1/" + System.Convert.ToString(PocetStranekNP);
                    nalezeno = true;
                }
            }
            catch (Exception ex)
            {
                //  MessageBox.Show("Historie nenačtena -> !!Nelze se připojit k databázi!!");

            }

        }

    }
}
