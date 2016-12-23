using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace NlgDBcredProg
{
    public partial class Form1 : Form
        
    {
        DataSet dataSet;                                                        //CredDogCIB CHANGE IT
        SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=usersdb;Integrated Security=True");
        SqlDataAdapter adapterOOO;
        BindingSource bindingSourceOOO;
        DataGridView gridOOO;

        public Form1()
        
        {
            InitializeComponent();

            //SELECT FROM TABLES AREA
            adapterOOO = new SqlDataAdapter("SELECT * FROM OOO", connection); 

            //CREATE DATASET WITH TABLES AREA
            dataSet = new DataSet(); 
            adapterOOO.Fill(dataSet, "OOO");

            //RELATIONS IN DB AREA
            //dataSet.Relations.Add("ooo-loanagr",dataSet.Tables["OOO"].Columns["IdOOO"],dataSet.Tables["LoanAgr"].Columns["LoanId"]);   
            
            //BIND.SOURCE AREA
            bindingSourceOOO = new BindingSource(dataSet, "OOO");  //bs dataset

            //BIND.SOURCE WITH RELATIONS AREA
            //bindingSourceLoan = new BindingSource(bindingSourceOOO, "ooo-loanagr"); 


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
