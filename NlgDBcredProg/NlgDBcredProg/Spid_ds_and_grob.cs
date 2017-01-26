using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace NlgDBcredProg

{
    public partial class Spid_ds_and_grob : Form
    {

        DataSet dataSet;
        SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS; Initial Catalog=CredDogCIB; Integrated Security=True");
        SqlDataAdapter adZalogPoruch,adSpDSZalPor, adGrpObject, adDopSogZalPor, adObjData;
        BindingSource bsZalogPoruch, bsSpDSZalPor, bsGrpObject, bsDopSogZalPor, bsObjData;
        DataGridView gdSpDSZalPor, gdGrpObject, gdDopSogZalPor, gdObjData;

        public Spid_ds_and_grob()
        { }

        public Spid_ds_and_grob(int trans2)
        {
            InitializeComponent();

            adZalogPoruch = new SqlDataAdapter("SELECT * FROM ZalogPoruch where idZalPor=" + trans2.ToString(), connection);
            adSpDSZalPor = new SqlDataAdapter("SELECT * FROM SpDSZalPor where id=" + trans2.ToString(), connection);
            adDopSogZalPor = new SqlDataAdapter("SELECT * FROM DopSogZalPor", connection);

            adZalogPoruch = new SqlDataAdapter("SELECT * FROM ZalogPoruch where idZalPor=" + trans2.ToString(), connection);
            adGrpObject = new SqlDataAdapter("SELECT * FROM GrpObject where id=" + trans2.ToString(), connection);
            adObjData = new SqlDataAdapter("SELECT * FROM ObjData", connection);




            dataSet = new DataSet();
            adZalogPoruch.Fill(dataSet, "ZalogPoruch");
            adSpDSZalPor.Fill(dataSet, "SpDSZalPor");
            adGrpObject.Fill(dataSet, "GrpObject");
            adDopSogZalPor.Fill(dataSet, "DopSogZalPor");
            adObjData.Fill(dataSet, "ObjData");


            dataSet.Relations.Add("ZalogPoruch-SpDSZalPor", dataSet.Tables["ZalogPoruch"].Columns["idZalPor"], dataSet.Tables["SpDSZalPor"].Columns["id"]);
            dataSet.Relations.Add("ZalogPoruch-GrpObject", dataSet.Tables["ZalogPoruch"].Columns["idZalPor"], dataSet.Tables["GrpObject"].Columns["id"]);
            dataSet.Relations.Add("SpDSZalPor-DopSogZalPor", dataSet.Tables["SpDSZalPor"].Columns["idSpDSZP"], dataSet.Tables["DopSogZalPor"].Columns["id"], false);
            dataSet.Relations.Add("GrpObject-ObjData", dataSet.Tables["GrpObject"].Columns["idGrObj"], dataSet.Tables["ObjData"].Columns["id"]);

            bsZalogPoruch = new BindingSource(dataSet, "ZalogPoruch");
            bsSpDSZalPor = new BindingSource(dataSet, "SpDSZalPor");
            bsGrpObject = new BindingSource(dataSet, "GrpObject");
            bsDopSogZalPor = new BindingSource(dataSet, "DopSogZalPor");
            bsObjData = new BindingSource(dataSet, "ObjData");

            bsSpDSZalPor = new BindingSource(bsZalogPoruch, "ZalogPoruch-SpDSZalPor");
            bsGrpObject = new BindingSource(bsZalogPoruch, "ZalogPoruch-GrpObject");
            bsDopSogZalPor = new BindingSource(bsSpDSZalPor, "SpDSZalPor-DopSogZalPor");
            bsObjData = new BindingSource(bsGrpObject, "GrpObject-ObjData");

            gdSpDSZalPor = new DataGridView(); //dg SpDSZalPor
            gdSpDSZalPor.Size = new Size(250, 250);
            gdSpDSZalPor.Location = new Point(5, 5);
            gdSpDSZalPor.DataSource = bsSpDSZalPor;
            gdDopSogZalPor = new DataGridView(); //dg DopSogZalPor
            gdDopSogZalPor.Size = new Size(600, 250);
            gdDopSogZalPor.Location = new Point(275, 5);
            gdDopSogZalPor.DataSource = bsDopSogZalPor;
            gdGrpObject = new DataGridView(); //dg GrpObject
            gdGrpObject.Size = new Size(250, 250);
            gdGrpObject.Location = new Point(5, gdSpDSZalPor.Bottom + 50);
            gdGrpObject.DataSource = bsGrpObject;
            gdObjData = new DataGridView(); //dg ObjData
            gdObjData.Size = new Size(600, 250);
            gdObjData.Location = new Point(275, gdDopSogZalPor.Bottom + 50);
            gdObjData.DataSource = bsObjData;

            this.Controls.AddRange(new Control[] {  gdSpDSZalPor, gdGrpObject, gdDopSogZalPor, gdObjData });

           // dataSet.Tables["SpDSZalPor"].Columns["id"].ColumnMapping = MappingType.Hidden;
         //   dataSet.Tables["SpDSZalPor"].Columns["idSpDSZP"].ColumnMapping = MappingType.Hidden;
         //   dataSet.Tables["DopSogZalPor"].Columns["id"].ColumnMapping = MappingType.Hidden;
         //   dataSet.Tables["GrpObject"].Columns["id"].ColumnMapping = MappingType.Hidden;
          //  dataSet.Tables["ObjData"].Columns["id"].ColumnMapping = MappingType.Hidden;
         //   dataSet.Tables["GrpObject"].Columns["idGrObj"].ColumnMapping = MappingType.Hidden;

        }

        private void Spid_ds_and_grob_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.WindowsDefaultBounds; //main form position and size
            this.Left += 400;
            Size = new Size(900, 700);
        }



        private void saveSpDSZalPor_Click(object sender, EventArgs e) //save for SpDSZalPor
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=CredDogCIB;Integrated Security=True"))
            {
                connection.Open();
                adSpDSZalPor = new SqlDataAdapter("SELECT * FROM SpDSZalPor;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adSpDSZalPor);
                adSpDSZalPor.InsertCommand = new SqlCommand("sp_SpDSZalPor", connection);
                adSpDSZalPor.InsertCommand.CommandType = CommandType.StoredProcedure;
                adSpDSZalPor.InsertCommand.Parameters.Add(new SqlParameter("@Доп_соглашение", SqlDbType.NVarChar, 50, "Доп_соглашение"));
                adSpDSZalPor.InsertCommand.Parameters.Add(new SqlParameter("@Принято", SqlDbType.Date, 30, "Принято"));
                adSpDSZalPor.InsertCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 30, "id"));
                SqlParameter parameter = adSpDSZalPor.InsertCommand.Parameters.Add("@idSpDSZP", SqlDbType.Int, 10, "idSpDSZP");
                parameter.Direction = ParameterDirection.Output;
                adSpDSZalPor.Update(dataSet.Tables["SpDSZalPor"]);
            }
        }

        private void saveDopSogZalPor_Click(object sender, EventArgs e) //save for DopSogZalPor
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=CredDogCIB;Integrated Security=True"))
            {
                connection.Open();
                adDopSogZalPor = new SqlDataAdapter("SELECT * FROM DopSogZalPor;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adDopSogZalPor);
                adDopSogZalPor.InsertCommand = new SqlCommand("sp_DopSogZalPor", connection);
                adDopSogZalPor.InsertCommand.CommandType = CommandType.StoredProcedure;
                adDopSogZalPor.InsertCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 10, "id"));
                adDopSogZalPor.InsertCommand.Parameters.Add(new SqlParameter("@Дог_поруч_залога", SqlDbType.NVarChar, 300, "Дог_поруч_залога"));
                adDopSogZalPor.InsertCommand.Parameters.Add(new SqlParameter("@Одобрение_сделки", SqlDbType.NVarChar, 300, "Одобрение_сделки"));
                adDopSogZalPor.InsertCommand.Parameters.Add(new SqlParameter("@ЕГРЮЛ_на_дату_подп", SqlDbType.NVarChar, 300, "ЕГРЮЛ_на_дату_подп"));
                adDopSogZalPor.InsertCommand.Parameters.Add(new SqlParameter("@Список_участн_на_дату", SqlDbType.NVarChar, 300, "Список_участн_на_дату"));
                adDopSogZalPor.InsertCommand.Parameters.Add(new SqlParameter("@Согласие_на_обремен", SqlDbType.NVarChar, 300, "Согласие_на_обремен"));
                adDopSogZalPor.Update(dataSet.Tables["DopSogZalPor"]);
            }
        }

    }
}
