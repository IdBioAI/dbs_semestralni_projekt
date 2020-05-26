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
    public partial class IoTjednotka : Form
    {
        RidiciFormular ridiciFormular;
        int vyber = 0; // 0 = přidat 1 = upravit
        String staryNazev;

        public IoTjednotka(RidiciFormular ridiciFormular)
        {
            this.ridiciFormular = ridiciFormular;
            InitializeComponent();
        }

        private void ButtHledat_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = ridiciFormular.GetConnection();

            try
            {
                connection = ridiciFormular.GetConnection();

                MySqlCommand mySqlCommand = new MySqlCommand("DELETE FROM mydb.udajestroj " +
                                                             "WHERE IoTPrvek_SerioveCislo = N'" + dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[1].Value.ToString() + "';", connection);
                mySqlCommand.ExecuteNonQuery();
                mySqlCommand = new MySqlCommand("DELETE FROM mydb.iotprvek " +
                                                             "WHERE SerioveCislo = N'" + dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[1].Value.ToString() + "';", connection);

                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Chyba při načítání", "UPOZORNĚNÍ");
            }

            Odstranit();
            Nahrat();
        }

        private void IoTjednotka_Load(object sender, EventArgs e)
        {
            Nahrat();
        }

        private void ButtonClick_Click(object sender, EventArgs e)
        {
            // přidat 
            if (vyber == 0)
            {
                MySqlConnection connection = null;

                try
                {
                    connection = ridiciFormular.GetConnection();

                    MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO mydb.iotprvek (SerioveCislo, Popis, Nazev, DatumPridani) VALUES (" +
                                                                   "N'" + textSerCislo.Text + "', " +
                                                                   "N'" + textPopis.Text + "', " +
                                                                   "N'" + textNazev.Text + "', " +
                                                                   "N'" + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "' )", connection);

                    mySqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Chyba při načítání", "UPOZORNĚNÍ");
                }
            }
            // upravit
            else
            {
                MySqlConnection connection = null;

                try
                {
                    connection = ridiciFormular.GetConnection();

                    MySqlCommand mySqlCommand = new MySqlCommand("UPDATE mydb.iotprvek SET " +
                                                                    "SerioveCislo = N'" + textSerCislo.Text + "', " +
                                                                    "Popis = N'" + textPopis.Text + "', " +
                                                                    "Nazev = N'" + textNazev.Text + "' " +
                                                                    "WHERE Nazev = N'" + staryNazev + "';", connection);

                    mySqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Chyba při načítání", "UPOZORNĚNÍ");
                }
            }

            Odstranit();
            Nahrat();
        }

        private void Nahrat()
        {
            try
            {
                dataGridView2.Columns.Clear();
            }
            catch
            {

            }

            MySqlConnection connection = ridiciFormular.GetConnection();

            String sqlQuery = "SELECT Nazev, SerioveCislo, Popis, DatumPridani as 'Datum přidání'" +
                              " FROM mydb.iotprvek ";

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sqlQuery, connection);
            DataSet DS = new DataSet();
            mySqlDataAdapter.Fill(DS);
            dataGridView2.DataSource = DS.Tables[0];
        }

        private void Odstranit()
        {
            textNazev.Text = "";
            textSerCislo.Text = "";
            textPopis.Text = "";
            buttonClick.Enabled = false;
        }

        private void DataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Odstranit();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            textNazev.Text = "";
            textSerCislo.Text = "";
            textPopis.Text = "";
            buttonClick.Enabled = true;
            buttonClick.Text = "Přidat";
            vyber = 0;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textNazev.Text = dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[0].Value.ToString();
            textSerCislo.Text = dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[1].Value.ToString();
            textPopis.Text = dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[2].Value.ToString();
            buttonClick.Enabled = true;
            buttonClick.Text = "Upravit";
            vyber = 1;
            staryNazev = dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[0].Value.ToString();
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            textNazev.Text = dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[0].Value.ToString();
            textSerCislo.Text = dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[1].Value.ToString();
            textPopis.Text = dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[2].Value.ToString();
            buttonClick.Enabled = true;
            buttonClick.Text = "Upravit";
            vyber = 1;
            staryNazev = dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[0].Value.ToString();
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            textNazev.Text = "";
            textSerCislo.Text = "";
            textPopis.Text = "";
            buttonClick.Enabled = true;
            buttonClick.Text = "Přidat";
            vyber = 0;
        }
    }
}
