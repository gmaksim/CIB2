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
        SqlDataAdapter adSpDopSog, adDopSog;
        BindingSource bsSpDopSog, bsDopSog;
        DataGridView gdSpDopSog, gdDopSog;

        public Spis_dop_sog()
        {
            InitializeComponent();

            adSpDopSog = new SqlDataAdapter("SELECT * FROM SpDopSog", connection);
            adDopSog = new SqlDataAdapter("SELECT * FROM DopSog", connection);

            dataSet = new DataSet();
            adSpDopSog.Fill(dataSet, "SpDopSog");
            adDopSog.Fill(dataSet, "DopSog");

            dataSet.Relations.Add("SpDopSog-DopSog", dataSet.Tables["SpDopSog"].Columns["idSpDpSg"], dataSet.Tables["DopSog"].Columns["id"]);

            bsSpDopSog = new BindingSource(dataSet, "SpDopSog");
            bsDopSog = new BindingSource(dataSet, "DopSog");

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
    }
}
