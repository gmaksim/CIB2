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
        //SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS; Initial Catalog=CredDogCIB; Integrated Security=True");
        SqlDataAdapter adOOO, adZaemwik, adZalogPoruch, adDocsZalPor;
          BindingSource bsOOO, bsZaemwik, bsZalogPoruch, bsDocsZalPor;
          DataGridView gdZaemwik, gdDocsZalPor;
        private int trans1, trans2;

        public DocumentsForm()
        { }

        public DocumentsForm(int trans1, int trans2) 
        {
            InitializeComponent();

            this.trans1 = trans1;
            this.trans2 = trans2;


            adOOO = new SqlDataAdapter("SELECT * FROM OOO where idOOO=" + trans1.ToString(), Program.connection);
            adZaemwik = new SqlDataAdapter("SELECT * FROM Zaemwik", Program.connection);
            adZalogPoruch = new SqlDataAdapter("SELECT * FROM ZalogPoruch where idZalPor=" + trans2.ToString(), Program.connection);
            adDocsZalPor = new SqlDataAdapter("SELECT * FROM DocsZalPor", Program.connection);



            dataSet = new DataSet();
            adOOO.Fill(dataSet, "OOO");
            adZaemwik.Fill(dataSet, "Zaemwik");
            adZalogPoruch.Fill(dataSet, "ZalogPoruch");
            adDocsZalPor.Fill(dataSet, "DocsZalPor");



            dataSet.Relations.Add("OOO-Zaemwik", dataSet.Tables["OOO"].Columns["idOOO"], dataSet.Tables["Zaemwik"].Columns["id"], false);
            dataSet.Relations.Add("ZalogPoruch-DocsZalPor", dataSet.Tables["ZalogPoruch"].Columns["idZalPor"], dataSet.Tables["DocsZalPor"].Columns["id"], false);  


            //BIND.SOURCE AREA 
            bsOOO = new BindingSource(dataSet, "OOO");
            bsZaemwik = new BindingSource(dataSet, "Zaemwik");
            bsZalogPoruch = new BindingSource(dataSet, "ZalogPoruch");
            bsDocsZalPor = new BindingSource(dataSet, "DocsZalPor");
       

            //BIND.SOURCE WITH RELATIONS AREA 

            bsZaemwik = new BindingSource(bsOOO, "OOO-Zaemwik");
            bsDocsZalPor = new BindingSource(bsZalogPoruch, "ZalogPoruch-DocsZalPor");



            gdZaemwik = new DataGridView(); //dg Zaemwik
            gdZaemwik.Size = new Size(245, 150);
            gdZaemwik.Location = new Point(255, 35);
            gdZaemwik.DataSource = bsZaemwik;

            gdDocsZalPor = new DataGridView(); //dg DocsZalPor
            gdDocsZalPor.Size = new Size(245, 150);
            gdDocsZalPor.Location = new Point(255, gdZaemwik.Bottom + 30);
            gdDocsZalPor.DataSource = bsDocsZalPor;

     
             this.Controls.AddRange(new Control[] { gdZaemwik, gdDocsZalPor });

            //dataSet.Tables["SpDopSog"].Columns["idSpDpSg"].ColumnMapping = MappingType.Hidden;
            //dataSet.Tables["SpDopSog"].Columns["id"].ColumnMapping = MappingType.Hidden;
            //dataSet.Tables["DopSog"].Columns["id"].ColumnMapping = MappingType.Hidden;
        }



        private void DocumentsForm_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.WindowsDefaultBounds; //main form position and size
            Size = new Size(950, 400);
        }

           private void saveZaemwik_Click(object sender, EventArgs e) //save for Zaemwik
           {
               using (SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=CredDogCIB;Integrated Security=True"))
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
               }
           }



           private void saveDocsZalPor_Click(object sender, EventArgs e) //save for DocsZalPor
           {
               using (SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=CredDogCIB;Integrated Security=True"))
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
               }
           }
    }
}
