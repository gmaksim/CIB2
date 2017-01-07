using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace NlgDBcredProg
{
    public partial class Form1 : Form
        
    {
        DataSet dataSet;                                                        
        SqlConnection  connection = new SqlConnection(@"Data Source=.\cibEXPRESS; Initial Catalog=CredDogCIB; Integrated Security=True");
        SqlDataAdapter adOOO, adKredDog, adZaemwik, adKredDocum, adOsnSdelkVdch, adSpDopSog, adZalogPoruch, adDopSog, 
                       adOsnovnSd, adSpDSZalPor, adGrpObject, adDocsZalPor, adDopSogZalPor, adObjData;
        BindingSource  bsOOO, bsKredDog, bsZaemwik, bsKredDocum, bsOsnSdelkVdch, bsSpDopSog, bsZalogPoruch, bsDopSog,
                       bsOsnovnSd, bsSpDSZalPor, bsGrpObject, bsDocsZalPor, bsDopSogZalPor, bsObjData;
        DataGridView   gdOOO, gdKredDog, gdZaemwik, gdKredDocum, gdOsnSdelkVdch, gdSpDopSog, gdZalogPoruch, gdDopSog,
                       gdOsnovnSd, gdSpDSZalPor, gdGrpObject, gdDocsZalPor, gdDopSogZalPor, gdObjData;

        public Form1()
        
        {
            InitializeComponent();

            //SELECT FROM TABLES AREA (+)
            adOOO = new SqlDataAdapter("SELECT * FROM OOO", connection);
            adKredDog = new SqlDataAdapter("SELECT * FROM KredDog", connection);
            adZaemwik = new SqlDataAdapter("SELECT * FROM Zaemwik", connection);
            adKredDocum = new SqlDataAdapter("SELECT * FROM KredDocum", connection);
            adOsnSdelkVdch = new SqlDataAdapter("SELECT * FROM OsnSdelkVdch", connection);
            adSpDopSog = new SqlDataAdapter("SELECT * FROM SpDopSog", connection);
            adZalogPoruch = new SqlDataAdapter("SELECT * FROM ZalogPoruch", connection);
            adDopSog = new SqlDataAdapter("SELECT * FROM DopSog", connection);
            adOsnovnSd = new SqlDataAdapter("SELECT * FROM OsnovnSd", connection);
            adSpDSZalPor = new SqlDataAdapter("SELECT * FROM SpDSZalPor", connection);
            adGrpObject = new SqlDataAdapter("SELECT * FROM GrpObject", connection);
            adDocsZalPor = new SqlDataAdapter("SELECT * FROM DocsZalPor", connection);
            adDopSogZalPor = new SqlDataAdapter("SELECT * FROM DopSogZalPor", connection);
            adObjData = new SqlDataAdapter("SELECT * FROM ObjData", connection);

            //CREATE DATASET WITH TABLES AREA (+)
            dataSet = new DataSet();
            adOOO.Fill(dataSet, "OOO");
            adKredDog.Fill(dataSet, "KredDog");
            adZaemwik.Fill(dataSet, "Zaemwik");
            adKredDocum.Fill(dataSet, "KredDocum");
            adOsnSdelkVdch.Fill(dataSet, "OsnSdelkVdch");
            adSpDopSog.Fill(dataSet, "SpDopSog");
            adZalogPoruch.Fill(dataSet, "ZalogPoruch");
            adDopSog.Fill(dataSet, "DopSog");
            adOsnovnSd.Fill(dataSet, "OsnovnSd");
            adSpDSZalPor.Fill(dataSet, "SpDSZalPor");
            adGrpObject.Fill(dataSet, "GrpObject");
            adDocsZalPor.Fill(dataSet, "DocsZalPor");
            adDopSogZalPor.Fill(dataSet, "DopSogZalPor");
            adObjData.Fill(dataSet, "ObjData");

            //RELATIONS IN DB AREA (+)
            dataSet.Relations.Add("OOO-KredDog",dataSet.Tables["OOO"].Columns["idOOO"],dataSet.Tables["KredDog"].Columns["id"]);
            dataSet.Relations.Add("OOO-Zaemwik", dataSet.Tables["OOO"].Columns["idOOO"], dataSet.Tables["Zaemwik"].Columns["id"]);
            dataSet.Relations.Add("KredDog-KredDocum", dataSet.Tables["KredDog"].Columns["idKredDog"], dataSet.Tables["KredDocum"].Columns["id"]);
            dataSet.Relations.Add("KredDog-OsnSdelkVdch", dataSet.Tables["KredDog"].Columns["idKredDog"], dataSet.Tables["OsnSdelkVdch"].Columns["id"]);
            dataSet.Relations.Add("KredDog-SpDopSog", dataSet.Tables["KredDog"].Columns["idKredDog"], dataSet.Tables["SpDopSog"].Columns["id"]);
            dataSet.Relations.Add("KredDog-ZalogPoruch", dataSet.Tables["KredDog"].Columns["idKredDog"], dataSet.Tables["ZalogPoruch"].Columns["id"]);
            dataSet.Relations.Add("SpDopSog-DopSog", dataSet.Tables["SpDopSog"].Columns["idSpDpSg"], dataSet.Tables["DopSog"].Columns["id"]);
            dataSet.Relations.Add("ZalogPoruch-OsnovnSd", dataSet.Tables["ZalogPoruch"].Columns["idZalPor"], dataSet.Tables["OsnovnSd"].Columns["id"]);
            dataSet.Relations.Add("ZalogPoruch-SpDSZalPor", dataSet.Tables["ZalogPoruch"].Columns["idZalPor"], dataSet.Tables["SpDSZalPor"].Columns["id"]);
            dataSet.Relations.Add("ZalogPoruch-GrpObject", dataSet.Tables["ZalogPoruch"].Columns["idZalPor"], dataSet.Tables["GrpObject"].Columns["id"]);
            dataSet.Relations.Add("ZalogPoruch-DocsZalPor", dataSet.Tables["ZalogPoruch"].Columns["idZalPor"], dataSet.Tables["DocsZalPor"].Columns["id"]);
            dataSet.Relations.Add("SpDSZalPor-DopSogZalPor", dataSet.Tables["SpDSZalPor"].Columns["idSpDSZP"], dataSet.Tables["DopSogZalPor"].Columns["id"]);
            dataSet.Relations.Add("GrpObject-ObjData", dataSet.Tables["GrpObject"].Columns["idGrObj"], dataSet.Tables["ObjData"].Columns["id"]);

            //BIND.SOURCE AREA (+)
            bsOOO = new BindingSource(dataSet, "OOO");
            bsKredDog = new BindingSource(dataSet, "KredDog");
            bsZaemwik = new BindingSource(dataSet, "Zaemwik");
            bsKredDocum = new BindingSource(dataSet, "KredDocum");
            bsOsnSdelkVdch = new BindingSource(dataSet, "OsnSdelkVdch");
            bsSpDopSog = new BindingSource(dataSet, "SpDopSog");
            bsZalogPoruch = new BindingSource(dataSet, "ZalogPoruch");
            bsDopSog = new BindingSource(dataSet, "DopSog");
            bsOsnovnSd = new BindingSource(dataSet, "OsnovnSd");
            bsSpDSZalPor = new BindingSource(dataSet, "SpDSZalPor");
            bsGrpObject = new BindingSource(dataSet, "GrpObject");
            bsDocsZalPor = new BindingSource(dataSet, "DocsZalPor");
            bsDopSogZalPor = new BindingSource(dataSet, "DopSogZalPor");
            bsObjData = new BindingSource(dataSet, "ObjData");

            //BIND.SOURCE WITH RELATIONS AREA (+)
            bsKredDog = new BindingSource(bsOOO, "OOO-KredDog");
            bsZaemwik = new BindingSource(bsOOO, "OOO-Zaemwik");
            bsKredDocum = new BindingSource(bsKredDog, "KredDog-KredDocum");
            bsOsnSdelkVdch = new BindingSource(bsKredDog, "KredDog-OsnSdelkVdch");
            bsSpDopSog = new BindingSource(bsKredDog, "KredDog-SpDopSog");
            bsZalogPoruch = new BindingSource(bsKredDog, "KredDog-ZalogPoruch");
            bsDopSog = new BindingSource(bsSpDopSog, "SpDopSog-DopSog");
            bsOsnovnSd = new BindingSource(bsZalogPoruch, "ZalogPoruch-OsnovnSd");
            bsSpDSZalPor = new BindingSource(bsZalogPoruch, "ZalogPoruch-SpDSZalPor");
            bsGrpObject = new BindingSource(bsZalogPoruch, "ZalogPoruch-GrpObject");
            bsDocsZalPor = new BindingSource(bsZalogPoruch, "ZalogPoruch-DocsZalPor");
            bsDopSogZalPor = new BindingSource(bsSpDSZalPor, "SpDSZalPor-DopSogZalPor");
            bsObjData = new BindingSource(bsGrpObject, "GrpObject-ObjData");

            //DATA GRID LOCATION AND SIZE AREA

            gridOOO = new DataGridView(); //dg OOO
            gridOOO.Size = new Size(300, 610);
            gridOOO.Location = new Point(5, 5);
            gridOOO.DataSource = bindingSourceOOO; 
            //gridFiles.Location = new Point(310, gridUsers.Bottom + 300); 


            this.Controls.AddRange(new Control[] { gridOOO }); //control with dg

            //HIDDEN ID'S AREA
            dataSet.Tables["OOO"].Columns["IdOOO"].ColumnMapping = MappingType.Hidden; 

        }


private void saveButtonOOO_Click(object sender, EventArgs e) //save for OOO
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=usersdb;Integrated Security=True"))
            {
                connection.Open();
                adapterOOO = new SqlDataAdapter("SELECT * FROM OOO;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapterOOO);
                adapterOOO.InsertCommand = new SqlCommand("sp_OOO", connection);
                adapterOOO.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapterOOO.InsertCommand.Parameters.Add(new SqlParameter("@наименование", SqlDbType.NVarChar, 50, "Наименование"));
                adapterOOO.InsertCommand.Parameters.Add(new SqlParameter("@принят", SqlDbType.Date, 30, "Принят"));
                SqlParameter parameter = adapterOOO.InsertCommand.Parameters.Add("@IdOOO", SqlDbType.Int, 10, "IdOOO");
                parameter.Direction = ParameterDirection.Output;
                adapterOOO.Update(dataSet.Tables["OOO"]);
            }
        }
     
        private void Form1_Load(object sender, EventArgs e) 
        {
            StartPosition = FormStartPosition.WindowsDefaultBounds; //main form position and size
            this.Left += 400;
            Size = new Size(1300, 800); 
        }

        private void searchForm_Click(object sender, EventArgs e) //button to open Search form
        {
            Search src = new Search();
            src.Show();
        }

    }
}
