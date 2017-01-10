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
        SqlDataAdapter adSpDopSog, adDopSog, adKredDog;
        BindingSource bsSpDopSog, bsDopSog, bsKredDog;
        DataGridView gdSpDopSog, gdDopSog;



        public Spis_dop_sog()
        {
            InitializeComponent();

            adKredDog = new SqlDataAdapter("SELECT * FROM KredDog", connection);
            adSpDopSog = new SqlDataAdapter("SELECT * FROM SpDopSog", connection);
            adDopSog = new SqlDataAdapter("SELECT * FROM DopSog", connection);

            dataSet = new DataSet();
            adKredDog.Fill(dataSet, "KredDog");
            adSpDopSog.Fill(dataSet, "SpDopSog");
            adDopSog.Fill(dataSet, "DopSog");

            dataSet.Relations.Add("KredDog-SpDopSog", dataSet.Tables["KredDog"].Columns["idKredDog"], dataSet.Tables["SpDopSog"].Columns["id"]);
            dataSet.Relations.Add("SpDopSog-DopSog", dataSet.Tables["SpDopSog"].Columns["idSpDpSg"], dataSet.Tables["DopSog"].Columns["id"]);

            bsKredDog = new BindingSource(dataSet, "KredDog");
            bsSpDopSog = new BindingSource(dataSet, "SpDopSog");
            bsDopSog = new BindingSource(dataSet, "DopSog");

            bsSpDopSog = new BindingSource(bsKredDog, "KredDog-SpDopSog");
            bsDopSog = new BindingSource(bsSpDopSog, "SpDopSog-DopSog");

            gdSpDopSog = new DataGridView(); //dg SpDopSog
            gdSpDopSog.Size = new Size(315, 315);
            gdSpDopSog.Location = new Point(5, 5);
            gdSpDopSog.DataSource = bsSpDopSog;
            gdDopSog = new DataGridView(); //dg DopSog
            gdDopSog.Size = new Size(600, 315);
            gdDopSog.Location = new Point(325, 5);
            gdDopSog.DataSource = bsDopSog;

            this.Controls.AddRange(new Control[] { gdSpDopSog, gdDopSog });

            dataSet.Tables["SpDopSog"].Columns["idSpDpSg"].ColumnMapping = MappingType.Hidden;
            dataSet.Tables["SpDopSog"].Columns["id"].ColumnMapping = MappingType.Hidden;
            dataSet.Tables["DopSog"].Columns["id"].ColumnMapping = MappingType.Hidden;

        }

        private void Spis_dop_sog_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.WindowsDefaultBounds; //main form position and size
            this.Left += 400;
            Size = new Size(1000, 400);
        }


        private void saveSpDopSog_Click(object sender, EventArgs e) //save for SpDopSog
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=CredDogCIB;Integrated Security=True"))
            {
                  connection.Open();
                  adSpDopSog = new SqlDataAdapter("SELECT * FROM SpDopSog;", connection);
                  SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adSpDopSog);
                  adSpDopSog.InsertCommand = new SqlCommand("sp_SpDopSog", connection);
                  adSpDopSog.InsertCommand.CommandType = CommandType.StoredProcedure;
                  adSpDopSog.InsertCommand.Parameters.Add(new SqlParameter("@Договор", SqlDbType.NVarChar, 50, "Договор"));
                  adSpDopSog.InsertCommand.Parameters.Add(new SqlParameter("@Принят", SqlDbType.Date, 30, "Принят"));
                  adSpDopSog.InsertCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 30, "id"));
                  SqlParameter parameter = adSpDopSog.InsertCommand.Parameters.Add("@idSpDpSg", SqlDbType.Int, 10, "idSpDpSg");
                  parameter.Direction = ParameterDirection.Output;
                  adSpDopSog.Update(dataSet.Tables["SpDopSog"]);
            }
        }

        private void saveDopSog_Click(object sender, EventArgs e) //save for DopSog
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=CredDogCIB;Integrated Security=True"))
            {
                connection.Open();
                adSpDopSog = new SqlDataAdapter("SELECT * FROM DopSog;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adSpDopSog);
                adSpDopSog.InsertCommand = new SqlCommand("sp_DopSog", connection);
                adSpDopSog.InsertCommand.CommandType = CommandType.StoredProcedure;
                adSpDopSog.InsertCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 10, "id"));
                adSpDopSog.InsertCommand.Parameters.Add(new SqlParameter("@Кредитный_дог", SqlDbType.NVarChar, 300, "Кредитный_дог"));
                adSpDopSog.InsertCommand.Parameters.Add(new SqlParameter("@Одобрение_сделки", SqlDbType.NVarChar, 300, "Одобрение_сделки"));
                adSpDopSog.InsertCommand.Parameters.Add(new SqlParameter("@ЕГРЮЛ_на_дату_подп", SqlDbType.NVarChar, 300, "ЕГРЮЛ_на_дату_подп"));
                adSpDopSog.InsertCommand.Parameters.Add(new SqlParameter("@Список_участн_на_дату", SqlDbType.NVarChar, 300, "Список_участн_на_дату"));
                adSpDopSog.Update(dataSet.Tables["DopSog"]);
            }
        }

    }
}
