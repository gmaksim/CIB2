using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace NlgDBcredProg
{ 
    public partial class Spis_dop_sog : Form
    {
        DataSet dataSet;
        SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS; Initial Catalog=CredDogCIB; Integrated Security=True");
        SqlDataAdapter adSpDopSog, adDopSog, adKredDog, adDocsZalPor, adZaemwik;
        BindingSource bsSpDopSog, bsDopSog, bsKredDog;
        DataGridView gdSpDopSog, gdDopSog;

        public Spis_dop_sog()
        { }

        public Spis_dop_sog(int trans1)
        {
            InitializeComponent();

          adKredDog = new SqlDataAdapter("SELECT * FROM KredDog where idKredDog=" + trans1.ToString(), connection);
            adSpDopSog = new SqlDataAdapter("SELECT * FROM SpDopSog where id=" + trans1.ToString(), connection);
            adDopSog = new SqlDataAdapter("SELECT * FROM DopSog", connection);

            dataSet = new DataSet();
        adKredDog.Fill(dataSet, "KredDog");
            adSpDopSog.Fill(dataSet, "SpDopSog");
            adDopSog.Fill(dataSet, "DopSog");


       dataSet.Relations.Add("KredDog-SpDopSog", dataSet.Tables["KredDog"].Columns["idKredDog"], dataSet.Tables["SpDopSog"].Columns["id"]);
           dataSet.Relations.Add("SpDopSog-DopSog", dataSet.Tables["SpDopSog"].Columns["idSpDpSg"], dataSet.Tables["DopSog"].Columns["id"], false);


           bsKredDog = new BindingSource(dataSet, "KredDog");
            bsSpDopSog = new BindingSource(dataSet, "SpDopSog");
            bsDopSog = new BindingSource(dataSet, "DopSog");

          bsSpDopSog = new BindingSource(bsKredDog, "KredDog-SpDopSog");
           bsDopSog = new BindingSource(bsSpDopSog, "SpDopSog-DopSog");

        /*    gdSpDopSog = new DataGridView(); //dg SpDopSog
            gdSpDopSog.Size = new Size(315, 315);
            gdSpDopSog.Location = new Point(5, 5);
            gdSpDopSog.DataSource = bsSpDopSog;
            gdDopSog = new DataGridView(); //dg DopSog
            gdDopSog.Size = new Size(600, 315);
            gdDopSog.Location = new Point(325, 5);
            gdDopSog.DataSource = bsDopSog;*/

            this.Controls.AddRange(new Control[] { gdSpDopSog, gdDopSog });

            //dataSet.Tables["SpDopSog"].Columns["idSpDpSg"].ColumnMapping = MappingType.Hidden;
            //dataSet.Tables["SpDopSog"].Columns["id"].ColumnMapping = MappingType.Hidden;
            //dataSet.Tables["DopSog"].Columns["id"].ColumnMapping = MappingType.Hidden;
        }

        private void Spis_dop_sog_Load(object sender, EventArgs e)
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
