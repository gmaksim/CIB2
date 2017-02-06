using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace NlgDBcredProg
{
    public partial class DocumentsForm : Form
    {
        DataSet dataSet;
        SqlDataAdapter adName, adZaemwik, adZalogPoruch, adDocsZalPor;
        BindingSource bsName, bsZaemwik, bsZalogPoruch, bsDocsZalPor;
        DataGridView gdZaemwik, gdDocsZalPor;
        SqlConnection connection = new SqlConnection(Program.connection);
        private int trans1, trans2;

        public DocumentsForm()
        { }

        public DocumentsForm(int trans1, int trans2) 
        {
            InitializeComponent();

            this.trans1 = trans1;
            this.trans2 = trans2;

            adName = new SqlDataAdapter("SELECT * FROM Name where idName=" + trans1.ToString(), Program.connection);
            adZaemwik = new SqlDataAdapter("SELECT * FROM Zaemwik", Program.connection);
            adZalogPoruch = new SqlDataAdapter("SELECT * FROM ZalogPoruch where idZalPor=" + trans2.ToString(), Program.connection);
            adDocsZalPor = new SqlDataAdapter("SELECT * FROM DocsZalPor", Program.connection);

            dataSet = new DataSet();
            adName.Fill(dataSet, "Name");
            adZaemwik.Fill(dataSet, "Zaemwik");
            adZalogPoruch.Fill(dataSet, "ZalogPoruch");
            adDocsZalPor.Fill(dataSet, "DocsZalPor");

            dataSet.Relations.Add("Name-Zaemwik", dataSet.Tables["Name"].Columns["idName"], dataSet.Tables["Zaemwik"].Columns["id"], false);
            dataSet.Relations.Add("ZalogPoruch-DocsZalPor", dataSet.Tables["ZalogPoruch"].Columns["idZalPor"], dataSet.Tables["DocsZalPor"].Columns["id"], false);  

            bsName = new BindingSource(dataSet, "Name");
            bsZaemwik = new BindingSource(dataSet, "Zaemwik");
            bsZalogPoruch = new BindingSource(dataSet, "ZalogPoruch");
            bsDocsZalPor = new BindingSource(dataSet, "DocsZalPor");
       
            bsZaemwik = new BindingSource(bsName, "Name-Zaemwik");
            bsDocsZalPor = new BindingSource(bsZalogPoruch, "ZalogPoruch-DocsZalPor");

            gdZaemwik = new DataGridView(); //dg Zaemwik
            gdZaemwik.Size = new Size(545, 150);
            gdZaemwik.Location = new Point(5, 30);
            gdZaemwik.DataSource = bsZaemwik;
            gdDocsZalPor = new DataGridView(); //dg DocsZalPor
            gdDocsZalPor.Size = new Size(545, 150);
            gdDocsZalPor.Location = new Point(5, gdZaemwik.Bottom + 30);
            gdDocsZalPor.DataSource = bsDocsZalPor;

            this.Controls.AddRange(new Control[] { gdZaemwik, gdDocsZalPor });

            this.gdZaemwik.CellContentClick += new DataGridViewCellEventHandler(this.gdZaemwik_CellContentClick);
            this.gdDocsZalPor.CellContentClick += new DataGridViewCellEventHandler(this.gdDocsZalPor_CellContentClick);

            gdDocsZalPor.ScrollBars = ScrollBars.Vertical;
            gdZaemwik.ScrollBars = ScrollBars.Vertical;
        }

        public DocumentsForm(int trans1)
        {
            InitializeComponent();

            this.trans1 = trans1;

            adName = new SqlDataAdapter("SELECT * FROM Name where idName=" + trans1.ToString(), Program.connection);
            adZaemwik = new SqlDataAdapter("SELECT * FROM Zaemwik", Program.connection);

            dataSet = new DataSet();
            adName.Fill(dataSet, "Name");
            adZaemwik.Fill(dataSet, "Zaemwik");

            dataSet.Relations.Add("Name-Zaemwik", dataSet.Tables["Name"].Columns["idName"], dataSet.Tables["Zaemwik"].Columns["id"], false);

            bsName = new BindingSource(dataSet, "Name");
            bsZaemwik = new BindingSource(dataSet, "Zaemwik");

            bsZaemwik = new BindingSource(bsName, "Name-Zaemwik");

            gdZaemwik = new DataGridView(); //dg Zaemwik
            gdZaemwik.Size = new Size(545, 150);
            gdZaemwik.Location = new Point(5, 30);
            gdZaemwik.DataSource = bsZaemwik;

            this.label4.Text = "Нет добавленных залогодателей / поручителей";

            this.Controls.AddRange(new Control[] { gdZaemwik });

            this.gdZaemwik.CellContentClick += new DataGridViewCellEventHandler(this.gdZaemwik_CellContentClick);
            this.gdDocsZalPor.CellContentClick += new DataGridViewCellEventHandler(this.gdDocsZalPor_CellContentClick);

            gdZaemwik.ScrollBars = ScrollBars.Vertical;
        }

        private void DocumentsForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Left += 100;
            Size = new Size(575, 445);
        }

    }
}
