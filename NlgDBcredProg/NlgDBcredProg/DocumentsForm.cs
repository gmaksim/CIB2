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
            gdZaemwik.Size = new Size(650, 150);
            gdZaemwik.Location = new Point(5, 30);
            gdZaemwik.DataSource = bsZaemwik;
            gdDocsZalPor = new DataGridView(); //dg DocsZalPor
            gdDocsZalPor.Size = new Size(650, 150);
            gdDocsZalPor.Location = new Point(5, gdZaemwik.Bottom + 30);
            gdDocsZalPor.DataSource = bsDocsZalPor;

            this.Controls.AddRange(new Control[] { gdZaemwik, gdDocsZalPor });

            //dataSet.Tables["SpDopSog"].Columns["idSpDpSg"].ColumnMapping = MappingType.Hidden;
            //dataSet.Tables["SpDopSog"].Columns["id"].ColumnMapping = MappingType.Hidden;
            //dataSet.Tables["DopSog"].Columns["id"].ColumnMapping = MappingType.Hidden;
        }



        private void DocumentsForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Left += 100;
            Size = new Size(680, 430);
        }

        private void saveZaemwik_Click(object sender, EventArgs e) //save for Zaemwik
        {
               {
                   connection.Open();
                   adZaemwik = new SqlDataAdapter("SELECT * FROM Zaemwik;", connection);
                   SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adZaemwik);
                   adZaemwik.InsertCommand = new SqlCommand("sp_Zaemwik", connection);
                   adZaemwik.InsertCommand.CommandType = CommandType.StoredProcedure;
                   adZaemwik.InsertCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 10, "id"));
                   adZaemwik.InsertCommand.Parameters.Add(new SqlParameter("@Паспорт", SqlDbType.NVarChar, 300, "Паспорт"));
                   adZaemwik.InsertCommand.Parameters.Add(new SqlParameter("@ЕГРЮЛ", SqlDbType.NVarChar, 300, "ЕГРЮЛ"));
                   adZaemwik.InsertCommand.Parameters.Add(new SqlParameter("@Участники", SqlDbType.NVarChar, 300, "Участники"));
                   adZaemwik.InsertCommand.Parameters.Add(new SqlParameter("@Заявка", SqlDbType.NVarChar, 300, "Заявка"));
                   adZaemwik.InsertCommand.Parameters.Add(new SqlParameter("@Анкета", SqlDbType.NVarChar, 300, "Анкета"));
                   adZaemwik.Update(dataSet.Tables["Zaemwik"]);
                   connection.Close();
               }
           }

         private void saveDocsZalPor_Click(object sender, EventArgs e) //save for DocsZalPor
         {
               {
                   connection.Open();
                   adDocsZalPor = new SqlDataAdapter("SELECT * FROM DocsZalPor;", connection);
                   SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adDocsZalPor);
                   adDocsZalPor.InsertCommand = new SqlCommand("sp_DocsZalPor", connection);
                   adDocsZalPor.InsertCommand.CommandType = CommandType.StoredProcedure;
                   adDocsZalPor.InsertCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 10, "id"));
                   adDocsZalPor.InsertCommand.Parameters.Add(new SqlParameter("@Паспорт", SqlDbType.NVarChar, 300, "Паспорт"));
                   adDocsZalPor.InsertCommand.Parameters.Add(new SqlParameter("@ЕГРЮЛ", SqlDbType.NVarChar, 300, "ЕГРЮЛ"));
                   adDocsZalPor.InsertCommand.Parameters.Add(new SqlParameter("@Участники", SqlDbType.NVarChar, 300, "Участники"));
                   adDocsZalPor.InsertCommand.Parameters.Add(new SqlParameter("@Заявка", SqlDbType.NVarChar, 300, "Заявка"));
                   adDocsZalPor.InsertCommand.Parameters.Add(new SqlParameter("@Анкета", SqlDbType.NVarChar, 300, "Анкета"));
                   adDocsZalPor.Update(dataSet.Tables["DocsZalPor"]);
                   connection.Close();
               }
          }

    }
}
