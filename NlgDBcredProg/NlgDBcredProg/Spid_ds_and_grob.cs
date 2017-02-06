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
        SqlDataAdapter adZalogPoruch, adGrpObject, adDopSogZalPor, adObjData;
        BindingSource bsZalogPoruch, bsGrpObject, bsDopSogZalPor, bsObjData;
        DataGridView gdGrpObject, gdDopSogZalPor, gdObjData;
        SqlConnection connection = new SqlConnection(Program.connection);

        public Spid_ds_and_grob()
        { }

        public Spid_ds_and_grob(int trans2)
        {
            InitializeComponent();

            adZalogPoruch = new SqlDataAdapter("SELECT * FROM ZalogPoruch where idZalPor=" + trans2.ToString(), Program.connection);
            adDopSogZalPor = new SqlDataAdapter("SELECT * FROM DopSogZalPor where id=" + trans2.ToString(), Program.connection);

            adZalogPoruch = new SqlDataAdapter("SELECT * FROM ZalogPoruch where idZalPor=" + trans2.ToString(), Program.connection);
            adGrpObject = new SqlDataAdapter("SELECT * FROM GrpObject where id=" + trans2.ToString(), Program.connection);
            adObjData = new SqlDataAdapter("SELECT * FROM ObjData", Program.connection);

            dataSet = new DataSet();
            adZalogPoruch.Fill(dataSet, "ZalogPoruch");
            adGrpObject.Fill(dataSet, "GrpObject");
            adDopSogZalPor.Fill(dataSet, "DopSogZalPor");
            adObjData.Fill(dataSet, "ObjData");

            dataSet.Relations.Add("ZalogPoruch-DopSogZalPor", dataSet.Tables["ZalogPoruch"].Columns["idZalPor"], dataSet.Tables["DopSogZalPor"].Columns["id"]);
            dataSet.Relations.Add("ZalogPoruch-GrpObject", dataSet.Tables["ZalogPoruch"].Columns["idZalPor"], dataSet.Tables["GrpObject"].Columns["id"]);
            dataSet.Relations.Add("GrpObject-ObjData", dataSet.Tables["GrpObject"].Columns["idGrObj"], dataSet.Tables["ObjData"].Columns["id"], false);

            bsZalogPoruch = new BindingSource(dataSet, "ZalogPoruch");
            bsGrpObject = new BindingSource(dataSet, "GrpObject");
            bsDopSogZalPor = new BindingSource(dataSet, "DopSogZalPor");
            bsObjData = new BindingSource(dataSet, "ObjData");

            bsDopSogZalPor = new BindingSource(bsZalogPoruch, "ZalogPoruch-DopSogZalPor");
            bsGrpObject = new BindingSource(bsZalogPoruch, "ZalogPoruch-GrpObject");
            bsObjData = new BindingSource(bsGrpObject, "GrpObject-ObjData");

            gdDopSogZalPor = new DataGridView(); //dg DopSogZalPor
            gdDopSogZalPor.Size = new Size(445, 150);
            gdDopSogZalPor.Location = new Point(5, 35);
            gdDopSogZalPor.DataSource = bsDopSogZalPor;
            gdGrpObject = new DataGridView(); //dg GrpObject
            gdGrpObject.Size = new Size(145, 200);
            gdGrpObject.Location = new Point(5, gdDopSogZalPor.Bottom + 50);
            gdGrpObject.DataSource = bsGrpObject;
            gdObjData = new DataGridView(); //dg ObjData
            gdObjData.Size = new Size(645, 200);
            gdObjData.Location = new Point(155, gdDopSogZalPor.Bottom + 50);
            gdObjData.DataSource = bsObjData;

            this.Controls.AddRange(new Control[] { gdGrpObject, gdDopSogZalPor, gdObjData });

            gdGrpObject.ScrollBars = ScrollBars.Vertical;
            gdObjData.ScrollBars = ScrollBars.Vertical;
            gdDopSogZalPor.ScrollBars = ScrollBars.Vertical;
        }

        private void Spid_ds_and_grob_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Left += 100;
            Size = new Size(825, 490);
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
                adObjData.InsertCommand.Parameters.Add(new SqlParameter("@Согласие_на_обремен", SqlDbType.NVarChar, 300, "Согласие_на_обремен"));
                adObjData.Update(dataSet.Tables["ObjData"]);
                connection.Close();
            }
        }

    }
}
