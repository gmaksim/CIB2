using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace NlgDBcredProg
{
    public partial class Search : Form
    {
        DataSet dataSet;
        SqlDataAdapter adOOO, adKredDog, adZalogPoruch;
        BindingSource bsOOO, bsKredDog, bsZalogPoruch;
        DataGridView gdOOO, gdKredDog, gdZalogPoruch;

        public Search()
        {
            InitializeComponent();

            //SELECT FROM TABLES AREA 
            adZalogPoruch = new SqlDataAdapter("SELECT * FROM ZalogPoruch", Program.connection);
            adKredDog = new SqlDataAdapter("SELECT * FROM KredDog", Program.connection);
            adOOO = new SqlDataAdapter("SELECT * FROM OOO", Program.connection);

            //CREATE DATASET WITH TABLES AREA 
            dataSet = new DataSet();
            adZalogPoruch.Fill(dataSet, "ZalogPoruch");
            adKredDog.Fill(dataSet, "KredDog");
            adOOO.Fill(dataSet, "OOO");

            //RELATIONS IN DB AREA 
            dataSet.Relations.Add("ZalogPoruch-KredDog", dataSet.Tables["ZalogPoruch"].Columns["id"], dataSet.Tables["KredDog"].Columns["idKredDog"], false); // oh! magic false
            dataSet.Relations.Add("KredDog-OOO", dataSet.Tables["KredDog"].Columns["id"], dataSet.Tables["OOO"].Columns["idOOO"], false);

            //BIND.SOURCE AREA 
            bsZalogPoruch = new BindingSource(dataSet, "ZalogPoruch");
            bsKredDog = new BindingSource(dataSet, "KredDog");
            bsOOO = new BindingSource(dataSet, "OOO");

            //BIND.SOURCE WITH RELATIONS AREA 
            bsKredDog = new BindingSource(bsZalogPoruch, "ZalogPoruch-KredDog");
            bsOOO = new BindingSource(bsKredDog, "KredDog-OOO");

            //DATA GRID LOCATION AND SIZE AREA
            gdZalogPoruch = new DataGridView(); //dg ZalogPoruch
            gdZalogPoruch.Size = new Size(270, 400);
            gdZalogPoruch.Location = new Point(5, 5);
            gdZalogPoruch.DataSource = bsZalogPoruch;

            gdKredDog = new DataGridView(); //dg gdKredDog
            gdKredDog.Size = new Size(270, 400);
            gdKredDog.Location = new Point(280, 5);
            gdKredDog.DataSource = bsKredDog;

            gdOOO = new DataGridView(); //dg OOO
            gdOOO.Size = new Size(270, 400);
            gdOOO.Location = new Point(580, 5);
            gdOOO.DataSource = bsOOO;


            this.Controls.AddRange(new Control[] { gdOOO, gdKredDog, gdZalogPoruch }); 
        }

        private void Search_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Left += 100;
            Size = new Size(1000, 800);
        }

        private void textBox1_TextChanged(object sender, EventArgs e) 
        {
            bsZalogPoruch.Filter = "ФИО LIKE '%' + '" + textBox1.Text + "%'"; //search in tables
        }
    }
}
