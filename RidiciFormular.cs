using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbs_semestralka
{
    public partial class RidiciFormular : Form
    {

        Zobrazeni zobrazeni;
        Graf graf;
        Stroj stoj;
        IoTjednotka ioTjednotka;

        MySqlConnection connection;

        string connectionString;

        public RidiciFormular()
        {
            this.IsMdiContainer = true;
            this.MaximizeBox = false;

            InitializeComponent();
        }

        public void ZobrazitMDI(int i)
        {
            zobrazeni = null;
            graf = null;
            stoj = null;
            ioTjednotka = null;

            if (i == 0)
            {
                if (zobrazeni == null)
                {
                    zobrazeni = new Zobrazeni(this);
                }

                zobrazeni.MdiParent = this;
                zobrazeni.Visible = true;
                zobrazeni.Location = new Point(252, 0);
                zobrazeni.Show();
            }

           else if (i == 1)
            {
                if (graf == null)
                {
                    graf = new Graf(this);
                }

                graf.MdiParent = this;
                graf.Visible = true;
                graf.Location = new Point(252, 0);
                graf.Show();
            }

            else if (i == 2)
            {
                if (stoj == null)
                {
                    stoj = new Stroj(this);
                }

                stoj.MdiParent = this;
                stoj.Visible = true;
                stoj.Location = new Point(252, 0);
                stoj.Show();
            }

            else if (i == 3)
            {
                if (ioTjednotka == null)
                {
                    ioTjednotka = new IoTjednotka(this);
                }

                ioTjednotka.MdiParent = this;
                ioTjednotka.Visible = true;
                ioTjednotka.Location = new Point(252, 0);
                ioTjednotka.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ZobrazitMDI(0);
        }

        private void InitDatabase()
        {
            try
            {
                String[] con = File.ReadAllLines("conf.txt");
                connectionString = "SERVER=" + con[0] + ";" + "DATABASE=" +
                    con[1] + ";" + "UID=" + con[2] + ";" + "PASSWORD=" + con[3] + ";";

               connection = new MySqlConnection(connectionString);

                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: nelze připojit k databázi - " + ex.Message);
            }
        }

        public MySqlConnection GetConnection()
        {
            if (connection == null || connection.State == ConnectionState.Closed)
            {
                InitDatabase();
            }

            return connection;
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            ZobrazitMDI(0);
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            ZobrazitMDI(0);
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {
            ZobrazitMDI(1);
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            ZobrazitMDI(1);
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            ZobrazitMDI(2);
        }

        private void PictureBox9_Click(object sender, EventArgs e)
        {
            ZobrazitMDI(2);
        }

        private void Label4_Click(object sender, EventArgs e)
        {
            ZobrazitMDI(3);
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PictureBox8_Click(object sender, EventArgs e)
        {
            ZobrazitMDI(3);
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
