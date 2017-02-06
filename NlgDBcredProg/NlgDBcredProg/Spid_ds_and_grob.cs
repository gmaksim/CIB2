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

            this.gdDopSogZalPor.CellContentClick += new DataGridViewCellEventHandler(this.gdDopSogZalPor_CellContentClick);
            this.gdObjData.CellContentClick += new DataGridViewCellEventHandler(this.gdObjData_CellContentClick);

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
 
    }
}
