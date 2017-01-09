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
        SqlDataAdapter adSpDSZalPor, adGrpObject, adDopSogZalPor, adObjData;
        BindingSource bsOOO, bsKredDog, bsZaemwik, bsKredDocum, bsOsnSdelkVdch, bsSpDopSog, bsZalogPoruch, bsDopSog,
                       bsOsnovnSd, bsSpDSZalPor, bsGrpObject, bsDocsZalPor, bsDopSogZalPor, bsObjData;
        DataGridView gdOOO, gdKredDog, gdZaemwik, gdKredDocum, gdOsnSdelkVdch, gdSpDopSog, gdZalogPoruch, gdDopSog,
                       gdOsnovnSd, gdSpDSZalPor, gdGrpObject, gdDocsZalPor, gdDopSogZalPor, gdObjData;


        public Spid_ds_and_grob()
        {
            InitializeComponent();

            adSpDSZalPor = new SqlDataAdapter("SELECT * FROM SpDSZalPor", connection);
            adGrpObject = new SqlDataAdapter("SELECT * FROM GrpObject", connection);
            adDopSogZalPor = new SqlDataAdapter("SELECT * FROM DopSogZalPor", connection);
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

            //DATA GRID LOCATION AND SIZE AREA
            gdSpDSZalPor = new DataGridView(); //dg OOO
            gdSpDSZalPor.Size = new Size(315, 610);
            gdSpDSZalPor.Location = new Point(5, 5);
            gdSpDSZalPor.DataSource = bsSpDSZalPor;


            this.Controls.AddRange(new Control[] {  gdSpDSZalPor, gdGrpObject, gdDopSogZalPor, gdObjData });

        }

        private void Spid_ds_and_grob_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.WindowsDefaultBounds; //main form position and size
            this.Left += 400;
            Size = new Size(1300, 900);
        }
    }
}
