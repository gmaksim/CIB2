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
        BindingSource bsSpDSZalPor, bsGrpObject, bsDopSogZalPor, bsObjData;
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
            adSpDSZalPor.Fill(dataSet, "SpDSZalPor");
            adGrpObject.Fill(dataSet, "GrpObject");
            adDopSogZalPor.Fill(dataSet, "DopSogZalPor");
            adObjData.Fill(dataSet, "ObjData");

            dataSet.Relations.Add("SpDSZalPor-DopSogZalPor", dataSet.Tables["SpDSZalPor"].Columns["idSpDSZP"], dataSet.Tables["DopSogZalPor"].Columns["id"]);
            dataSet.Relations.Add("GrpObject-ObjData", dataSet.Tables["GrpObject"].Columns["idGrObj"], dataSet.Tables["ObjData"].Columns["id"]);

            bsSpDSZalPor = new BindingSource(dataSet, "SpDSZalPor");
            bsGrpObject = new BindingSource(dataSet, "GrpObject");
            bsDopSogZalPor = new BindingSource(dataSet, "DopSogZalPor");
            bsObjData = new BindingSource(dataSet, "ObjData");

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
            gdGrpObject.Location = new Point(5, gdSpDSZalPor.Bottom + 10);
            gdGrpObject.DataSource = bsGrpObject;
            gdObjData = new DataGridView(); //dg ObjData
            gdObjData.Size = new Size(600, 250);
            gdObjData.Location = new Point(275, gdDopSogZalPor.Bottom + 10);
            gdObjData.DataSource = bsObjData;

            this.Controls.AddRange(new Control[] {  gdSpDSZalPor, gdGrpObject, gdDopSogZalPor, gdObjData });

            dataSet.Tables["SpDSZalPor"].Columns["id"].ColumnMapping = MappingType.Hidden;
            dataSet.Tables["SpDSZalPor"].Columns["idSpDSZP"].ColumnMapping = MappingType.Hidden;
            dataSet.Tables["DopSogZalPor"].Columns["id"].ColumnMapping = MappingType.Hidden;
            dataSet.Tables["GrpObject"].Columns["id"].ColumnMapping = MappingType.Hidden;
            dataSet.Tables["ObjData"].Columns["id"].ColumnMapping = MappingType.Hidden;
            dataSet.Tables["GrpObject"].Columns["idGrObj"].ColumnMapping = MappingType.Hidden;

        }

        private void Spid_ds_and_grob_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.WindowsDefaultBounds; //main form position and size
            this.Left += 400;
            Size = new Size(900, 700);
        }
    }
}
