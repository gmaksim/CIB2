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
        SqlDataAdapter adName, adKredDog, adZalogPoruch;
        BindingSource bsName, bsKredDog, bsZalogPoruch;

        DataGridView gdName, gdKredDog, gdZalogPoruch;

        public Search()
        {
            InitializeComponent();

            adZalogPoruch = new SqlDataAdapter("SELECT * FROM ZalogPoruch", Program.connection);
            adKredDog = new SqlDataAdapter("SELECT * FROM KredDog", Program.connection);
            adName = new SqlDataAdapter("SELECT * FROM Name", Program.connection);

            dataSet = new DataSet();
            adZalogPoruch.Fill(dataSet, "ZalogPoruch");
            adKredDog.Fill(dataSet, "KredDog");
            adName.Fill(dataSet, "Name");

            dataSet.Relations.Add("ZalogPoruch-KredDog", dataSet.Tables["ZalogPoruch"].Columns["id"], dataSet.Tables["KredDog"].Columns["idKredDog"], false); // oh! magic false
            dataSet.Relations.Add("KredDog-Name", dataSet.Tables["KredDog"].Columns["id"], dataSet.Tables["Name"].Columns["idName"], false);

            bsZalogPoruch = new BindingSource(dataSet, "ZalogPoruch");
            bsKredDog = new BindingSource(dataSet, "KredDog");
            bsName = new BindingSource(dataSet, "Name");

            bsKredDog = new BindingSource(bsZalogPoruch, "ZalogPoruch-KredDog");
            bsName = new BindingSource(bsKredDog, "KredDog-Name");

            gdZalogPoruch = new DataGridView(); //dg ZalogPoruch
            gdZalogPoruch.Size = new Size(330, 270);
            gdZalogPoruch.Location = new Point(5, 30);
            gdZalogPoruch.DataSource = bsZalogPoruch;

            gdKredDog = new DataGridView(); //dg gdKredDog
            gdKredDog.Size = new Size(245, 100);
            gdKredDog.Location = new Point(340, 30);
            gdKredDog.DataSource = bsKredDog;

            gdName = new DataGridView(); //dg OOO
            gdName.Size = new Size(245, 100);
            gdName.Location = new Point(340, gdKredDog.Bottom + 30);
            gdName.DataSource = bsName;

            this.Controls.AddRange(new Control[] { gdName, gdKredDog, gdZalogPoruch });

            gdName.ScrollBars = ScrollBars.Vertical;
            gdKredDog.ScrollBars = ScrollBars.Vertical;
            gdZalogPoruch.ScrollBars = ScrollBars.Vertical;
        }

        private void Search_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Left += 100;
            Size = new Size(650, 400);
        }

        private void textBox1_TextChanged(object sender, EventArgs e) //search by Name
        {
            bsZalogPoruch.Filter = "Наименование LIKE '%' + '" + textBox1.Text + "%'"; 
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           bsZalogPoruch.Filter = "Паспорт_ИНН LIKE '%' + '" + textBox2.Text + "%'";
        }
    }
}
