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
        SqlDataAdapter adZalogPoruch,adSpDSZalPor, adGrpObject, adDopSogZalPor, adObjData;
        BindingSource bsZalogPoruch, bsSpDSZalPor, bsGrpObject, bsDopSogZalPor, bsObjData;
        DataGridView gdSpDSZalPor, gdGrpObject, gdDopSogZalPor, gdObjData;
        SqlConnection connection = new SqlConnection(Program.connection);

        public Spid_ds_and_grob()
        { }

        public Spid_ds_and_grob(int trans2)
        {
            InitializeComponent();

            adZalogPoruch = new SqlDataAdapter("SELECT * FROM ZalogPoruch where idZalPor=" + trans2.ToString(), Program.connection);
            adSpDSZalPor = new SqlDataAdapter("SELECT * FROM SpDSZalPor where id=" + trans2.ToString(), Program.connection);
            adDopSogZalPor = new SqlDataAdapter("SELECT * FROM DopSogZalPor", Program.connection);

            adZalogPoruch = new SqlDataAdapter("SELECT * FROM ZalogPoruch where idZalPor=" + trans2.ToString(), Program.connection);
            adGrpObject = new SqlDataAdapter("SELECT * FROM GrpObject where id=" + trans2.ToString(), Program.connection);
            adObjData = new SqlDataAdapter("SELECT * FROM ObjData", Program.connection);




            dataSet = new DataSet();
            adZalogPoruch.Fill(dataSet, "ZalogPoruch");
            adSpDSZalPor.Fill(dataSet, "SpDSZalPor");
            adGrpObject.Fill(dataSet, "GrpObject");
            adDopSogZalPor.Fill(dataSet, "DopSogZalPor");
            adObjData.Fill(dataSet, "ObjData");


            dataSet.Relations.Add("ZalogPoruch-SpDSZalPor", dataSet.Tables["ZalogPoruch"].Columns["idZalPor"], dataSet.Tables["SpDSZalPor"].Columns["id"]);
            dataSet.Relations.Add("ZalogPoruch-GrpObject", dataSet.Tables["ZalogPoruch"].Columns["idZalPor"], dataSet.Tables["GrpObject"].Columns["id"]);
            dataSet.Relations.Add("SpDSZalPor-DopSogZalPor", dataSet.Tables["SpDSZalPor"].Columns["idSpDSZP"], dataSet.Tables["DopSogZalPor"].Columns["id"], false);
            dataSet.Relations.Add("GrpObject-ObjData", dataSet.Tables["GrpObject"].Columns["idGrObj"], dataSet.Tables["ObjData"].Columns["id"], false);

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
            gdSpDSZalPor.Location = new Point(5, 50);
            gdSpDSZalPor.DataSource = bsSpDSZalPor;
            gdDopSogZalPor = new DataGridView(); //dg DopSogZalPor
            gdDopSogZalPor.Size = new Size(600, 250);
            gdDopSogZalPor.Location = new Point(275, 50);
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
            this.Location = new Point(0, 0);
            this.Left += 100;
            Size = new Size(900, 650);
        }

        private void saveSpDSZalPor_Click(object sender, EventArgs e) //save for SpDSZalPor
        {
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
                connection.Close();
            }
        }

        private void saveDopSogZalPor_Click(object sender, EventArgs e) //save for DopSogZalPor
        {
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
                connection.Close();
            }
        }

        private void saveGrpObject_Click(object sender, EventArgs e) //save for GrpObject
        {
            {
                connection.Open();
                adGrpObject = new SqlDataAdapter("SELECT * FROM GrpObject;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adGrpObject);
                adGrpObject.InsertCommand = new SqlCommand("sp_GrpObject", connection);
                adGrpObject.InsertCommand.CommandType = CommandType.StoredProcedure;
                adGrpObject.InsertCommand.Parameters.Add(new SqlParameter("@Группы_объектов", SqlDbType.NVarChar, 50, "Группы_объектов"));
                adGrpObject.InsertCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 30, "id"));
                SqlParameter parameter = adGrpObject.InsertCommand.Parameters.Add("@idGrObj", SqlDbType.Int, 10, "idGrObj");
                parameter.Direction = ParameterDirection.Output;
                adGrpObject.Update(dataSet.Tables["GrpObject"]);
                connection.Close();
            }
        }


        private void saveObjData_Click(object sender, EventArgs e) //save for ObjData
        {
            {
                connection.Open();
                adObjData = new SqlDataAdapter("SELECT * FROM ObjData;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adObjData);
                adObjData.InsertCommand = new SqlCommand("sp_ObjData", connection);
                adObjData.InsertCommand.CommandType = CommandType.StoredProcedure;
                adObjData.InsertCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 10, "id"));
                adObjData.InsertCommand.Parameters.Add(new SqlParameter("@Выписки_ЕГРП", SqlDbType.NVarChar, 300, "Выписки_ЕГРП"));
                adObjData.InsertCommand.Parameters.Add(new SqlParameter("@Свид_права_собст", SqlDbType.NVarChar, 300, "Свид_права_собст"));
                adObjData.InsertCommand.Parameters.Add(new SqlParameter("@Договоры_куп_прод_обрем", SqlDbType.NVarChar, 300, "Договоры_куп_прод_обрем"));
                adObjData.InsertCommand.Parameters.Add(new SqlParameter("@Кадастровый_пасп", SqlDbType.NVarChar, 300, "Кадастровый_пасп"));
                adObjData.InsertCommand.Parameters.Add(new SqlParameter("@Фотографии", SqlDbType.NVarChar, 300, "Фотографии"));
                adObjData.Update(dataSet.Tables["ObjData"]);
                connection.Close();
            }
        }

    }
}
