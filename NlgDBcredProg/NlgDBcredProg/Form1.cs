using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
using System.Diagnostics; 

namespace NlgDBcredProg
{
    public partial class Form1 : Form

    {
        DataSet dataSet;
        SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS; Initial Catalog=CredDogCIB; Integrated Security=True");
        SqlDataAdapter adOOO, adKredDog, adZaemwik, adKredDocum, adOsnSdelkVdch, adSpDopSog, adZalogPoruch,
                       adOsnovnSd, adSpDSZalPor, adGrpObject, adDocsZalPor, adDopSogZalPor, adObjData;
        BindingSource bsOOO, bsKredDog, bsZaemwik, bsKredDocum, bsOsnSdelkVdch, bsSpDopSog, bsZalogPoruch,
                      bsOsnovnSd, bsSpDSZalPor, bsGrpObject, bsDocsZalPor, bsDopSogZalPor, bsObjData;
        DataGridView gdOOO, gdKredDog, gdZaemwik, gdKredDocum, gdOsnSdelkVdch, gdZalogPoruch,
                     gdOsnovnSd, gdDocsZalPor;

        public Form1()

        {
            InitializeComponent();

            //SELECT FROM TABLES AREA 
            adOOO = new SqlDataAdapter("SELECT * FROM OOO", connection);
            adKredDog = new SqlDataAdapter("SELECT * FROM KredDog", connection);
            adZaemwik = new SqlDataAdapter("SELECT * FROM Zaemwik", connection);
            adKredDocum = new SqlDataAdapter("SELECT * FROM KredDocum", connection);
            adOsnSdelkVdch = new SqlDataAdapter("SELECT * FROM OsnSdelkVdch", connection);
            adSpDopSog = new SqlDataAdapter("SELECT * FROM SpDopSog", connection);
            adZalogPoruch = new SqlDataAdapter("SELECT * FROM ZalogPoruch", connection);
            adOsnovnSd = new SqlDataAdapter("SELECT * FROM OsnovnSd", connection);
            adSpDSZalPor = new SqlDataAdapter("SELECT * FROM SpDSZalPor", connection);
            adGrpObject = new SqlDataAdapter("SELECT * FROM GrpObject", connection);
            adDocsZalPor = new SqlDataAdapter("SELECT * FROM DocsZalPor", connection);
            adDopSogZalPor = new SqlDataAdapter("SELECT * FROM DopSogZalPor", connection);
            adObjData = new SqlDataAdapter("SELECT * FROM ObjData", connection);

            //CREATE DATASET WITH TABLES AREA 
            dataSet = new DataSet();
            adOOO.Fill(dataSet, "OOO");
            adKredDog.Fill(dataSet, "KredDog");
            adZaemwik.Fill(dataSet, "Zaemwik");
            adKredDocum.Fill(dataSet, "KredDocum");
            adOsnSdelkVdch.Fill(dataSet, "OsnSdelkVdch");
            adSpDopSog.Fill(dataSet, "SpDopSog");
            adZalogPoruch.Fill(dataSet, "ZalogPoruch");
            adOsnovnSd.Fill(dataSet, "OsnovnSd");
            adSpDSZalPor.Fill(dataSet, "SpDSZalPor");
            adGrpObject.Fill(dataSet, "GrpObject");
            adDocsZalPor.Fill(dataSet, "DocsZalPor");
            adDopSogZalPor.Fill(dataSet, "DopSogZalPor");
            adObjData.Fill(dataSet, "ObjData");

            //RELATIONS IN DB AREA 
            dataSet.Relations.Add("OOO-KredDog", dataSet.Tables["OOO"].Columns["idOOO"], dataSet.Tables["KredDog"].Columns["id"]);
            dataSet.Relations.Add("OOO-Zaemwik", dataSet.Tables["OOO"].Columns["idOOO"], dataSet.Tables["Zaemwik"].Columns["id"]);
            dataSet.Relations.Add("KredDog-KredDocum", dataSet.Tables["KredDog"].Columns["idKredDog"], dataSet.Tables["KredDocum"].Columns["id"]);
            dataSet.Relations.Add("KredDog-OsnSdelkVdch", dataSet.Tables["KredDog"].Columns["idKredDog"], dataSet.Tables["OsnSdelkVdch"].Columns["id"]);
            dataSet.Relations.Add("KredDog-SpDopSog", dataSet.Tables["KredDog"].Columns["idKredDog"], dataSet.Tables["SpDopSog"].Columns["id"]);
            dataSet.Relations.Add("KredDog-ZalogPoruch", dataSet.Tables["KredDog"].Columns["idKredDog"], dataSet.Tables["ZalogPoruch"].Columns["id"]);
            dataSet.Relations.Add("ZalogPoruch-OsnovnSd", dataSet.Tables["ZalogPoruch"].Columns["idZalPor"], dataSet.Tables["OsnovnSd"].Columns["id"]);
            dataSet.Relations.Add("ZalogPoruch-SpDSZalPor", dataSet.Tables["ZalogPoruch"].Columns["idZalPor"], dataSet.Tables["SpDSZalPor"].Columns["id"]);
            dataSet.Relations.Add("ZalogPoruch-GrpObject", dataSet.Tables["ZalogPoruch"].Columns["idZalPor"], dataSet.Tables["GrpObject"].Columns["id"]);
            dataSet.Relations.Add("ZalogPoruch-DocsZalPor", dataSet.Tables["ZalogPoruch"].Columns["idZalPor"], dataSet.Tables["DocsZalPor"].Columns["id"]);
            dataSet.Relations.Add("SpDSZalPor-DopSogZalPor", dataSet.Tables["SpDSZalPor"].Columns["idSpDSZP"], dataSet.Tables["DopSogZalPor"].Columns["id"]);
            dataSet.Relations.Add("GrpObject-ObjData", dataSet.Tables["GrpObject"].Columns["idGrObj"], dataSet.Tables["ObjData"].Columns["id"]);

            //BIND.SOURCE AREA 
            bsOOO = new BindingSource(dataSet, "OOO");
            bsKredDog = new BindingSource(dataSet, "KredDog");
            bsZaemwik = new BindingSource(dataSet, "Zaemwik");
            bsKredDocum = new BindingSource(dataSet, "KredDocum");
            bsOsnSdelkVdch = new BindingSource(dataSet, "OsnSdelkVdch");
            bsSpDopSog = new BindingSource(dataSet, "SpDopSog");
            bsZalogPoruch = new BindingSource(dataSet, "ZalogPoruch");
            bsOsnovnSd = new BindingSource(dataSet, "OsnovnSd");
            bsSpDSZalPor = new BindingSource(dataSet, "SpDSZalPor");
            bsGrpObject = new BindingSource(dataSet, "GrpObject");
            bsDocsZalPor = new BindingSource(dataSet, "DocsZalPor");
            bsDopSogZalPor = new BindingSource(dataSet, "DopSogZalPor");
            bsObjData = new BindingSource(dataSet, "ObjData");

            //BIND.SOURCE WITH RELATIONS AREA 
            bsKredDog = new BindingSource(bsOOO, "OOO-KredDog");
            bsZaemwik = new BindingSource(bsOOO, "OOO-Zaemwik");
            bsKredDocum = new BindingSource(bsKredDog, "KredDog-KredDocum");
            bsOsnSdelkVdch = new BindingSource(bsKredDog, "KredDog-OsnSdelkVdch");
            bsSpDopSog = new BindingSource(bsKredDog, "KredDog-SpDopSog");
            bsZalogPoruch = new BindingSource(bsKredDog, "KredDog-ZalogPoruch");
            bsOsnovnSd = new BindingSource(bsZalogPoruch, "ZalogPoruch-OsnovnSd");
            bsSpDSZalPor = new BindingSource(bsZalogPoruch, "ZalogPoruch-SpDSZalPor");
            bsGrpObject = new BindingSource(bsZalogPoruch, "ZalogPoruch-GrpObject");
            bsDocsZalPor = new BindingSource(bsZalogPoruch, "ZalogPoruch-DocsZalPor");
            bsDopSogZalPor = new BindingSource(bsSpDSZalPor, "SpDSZalPor-DopSogZalPor");
            bsObjData = new BindingSource(bsGrpObject, "GrpObject-ObjData");

            //DATA GRID LOCATION AND SIZE AREA
            gdOOO = new DataGridView(); //dg OOO
            gdOOO.Size = new Size(315, 610);
            gdOOO.Location = new Point(5, 5);
            gdOOO.DataSource = bsOOO;
            gdKredDog = new DataGridView(); //dg KredDog
            gdKredDog.Size = new Size(300, 150);
            gdKredDog.Location = new Point(325, 5);
            gdKredDog.DataSource = bsKredDog;
            gdZaemwik = new DataGridView(); //dg Zaemwik
            gdZaemwik.Size = new Size(630, 150);
            gdZaemwik.Location = new Point(630, 5);
            gdZaemwik.DataSource = bsZaemwik;
            gdKredDocum = new DataGridView(); //dg KredDocum
            gdKredDocum.Size = new Size(330, 150);
            gdKredDocum.Location = new Point(325, gdKredDog.Bottom + 50);
            gdKredDocum.DataSource = bsKredDocum;
            gdOsnSdelkVdch = new DataGridView(); //dg OsnSdelkVdch
            gdOsnSdelkVdch.Size = new Size(530, 150);
            gdOsnSdelkVdch.Location = new Point(680, gdZaemwik.Bottom + 50);
            gdOsnSdelkVdch.DataSource = bsOsnSdelkVdch;
            gdZalogPoruch = new DataGridView(); //dg ZalogPoruch
            gdZalogPoruch.Size = new Size(345, 150);
            gdZalogPoruch.Location = new Point(325, gdKredDocum.Bottom + 50);
            gdZalogPoruch.DataSource = bsZalogPoruch;
            gdOsnovnSd = new DataGridView(); //dg OsnovnSd
            gdOsnovnSd.Size = new Size(545, 150);
            gdOsnovnSd.Location = new Point(700, gdOsnSdelkVdch.Bottom + 50);
            gdOsnovnSd.DataSource = bsOsnovnSd;
            gdDocsZalPor = new DataGridView(); //dg DocsZalPor
            gdDocsZalPor.Size = new Size(845, 150);
            gdDocsZalPor.Location = new Point(325, gdZalogPoruch.Bottom + 50);
            gdDocsZalPor.DataSource = bsDocsZalPor;

            this.Controls.AddRange(new Control[] { gdOOO, gdKredDog, gdZaemwik, gdKredDocum, gdOsnSdelkVdch, gdZalogPoruch, gdOsnovnSd, gdDocsZalPor }); //control with dg
            this.gdZaemwik.CellContentClick += new DataGridViewCellEventHandler(this.gdZaemwik_CellContentClick); //clickable cells in Zaemwik

            //HIDDEN ID'S AREA
          dataSet.Tables["OOO"].Columns["IdOOO"].ColumnMapping = MappingType.Hidden;
           // dataSet.Tables["KredDog"].Columns["id"].ColumnMapping = MappingType.Hidden;
           // dataSet.Tables["KredDog"].Columns["idKredDog"].ColumnMapping = MappingType.Hidden;
            dataSet.Tables["Zaemwik"].Columns["id"].ColumnMapping = MappingType.Hidden;
            dataSet.Tables["KredDocum"].Columns["id"].ColumnMapping = MappingType.Hidden;
           dataSet.Tables["OsnSdelkVdch"].Columns["id"].ColumnMapping = MappingType.Hidden;
        //   dataSet.Tables["ZalogPoruch"].Columns["idZalPor"].ColumnMapping = MappingType.Hidden;
       //   dataSet.Tables["ZalogPoruch"].Columns["id"].ColumnMapping = MappingType.Hidden;
            dataSet.Tables["OsnovnSd"].Columns["id"].ColumnMapping = MappingType.Hidden;
            dataSet.Tables["DocsZalPor"].Columns["id"].ColumnMapping = MappingType.Hidden;
        }

        private void spis_dop_sog_Click(object sender, EventArgs e)
        {
            int trans1 = (int)gdKredDog.CurrentRow.Cells[0].Value;
           
            Spis_dop_sog SDS = new Spis_dop_sog(trans1);
            SDS.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.WindowsDefaultBounds; //main form position and size
            Size = new Size(1300, 900);
        }

        private void searchForm_Click(object sender, EventArgs e) //button to open Search form
        {
            Search src = new Search();
            src.Show();
        }

        private void spis_dop_sog_and__gr_obj_Click(object sender, EventArgs e) //button to open Spisok dop.sogl i grup.obj form
        {
            int trans2 = (int)gdZalogPoruch.CurrentRow.Cells[0].Value;

            Spid_ds_and_grob SDSG = new Spid_ds_and_grob(trans2);
            SDSG.Show();
        }

        private void gdZaemwik_CellContentClick(object sender, DataGridViewCellEventArgs e) //make clickable Zaemwik cells
        {

            {
                Process.Start(gdZaemwik.SelectedCells[0].Value.ToString());
            }
        }

    }
}
