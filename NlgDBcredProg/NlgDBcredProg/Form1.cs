using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace NlgDBcredProg
{
    public partial class Form1 : Form

    {
        SqlConnection connection;
        DataSet dataSet;
        SqlDataAdapter adapterUsers, adapterFiles, adapterOOO, adapterLoan;
        BindingSource bindingSourceUsers, bindingSourceFiles, bindingSourceOOO, bindingSourceLoan;
        DataGridView gridUsers, gridFiles, gridOOO, gridLoan;

        public Form1()
        
        {
            InitializeComponent();
            Size = new Size(450, 450); 
            connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=usersdb;Integrated Security=True"); //connection to SQL
            adapterUsers = new SqlDataAdapter("SELECT * FROM Users;", connection); //select from tables
            adapterFiles = new SqlDataAdapter("SELECT * FROM Files", connection);
            adapterOOO = new SqlDataAdapter("SELECT * FROM OOO", connection);
            adapterLoan = new SqlDataAdapter("SELECT * FROM LoanAgr", connection);

            dataSet = new DataSet(); //create dataset with tables
            adapterUsers.Fill(dataSet, "Users");
            adapterFiles.Fill(dataSet, "Files");
            adapterOOO.Fill(dataSet, "OOO");
            adapterLoan.Fill(dataSet, "LoanAgr");

            dataSet.Relations.Add("ooo-loanagr", //relations OOO and LoanAgr      
            dataSet.Tables["OOO"].Columns["IdOOO"],             
            dataSet.Tables["LoanAgr"].Columns["LoanId"]);
            dataSet.Relations.Add("loanagr-users", //relations LoanAgr and Users      
            dataSet.Tables["LoanAgr"].Columns["Id"],
            dataSet.Tables["Users"].Columns["IdUsers"]);
            dataSet.Relations.Add("users-files", //relations Users and Files
            dataSet.Tables["Users"].Columns["FILESid"],
            dataSet.Tables["Files"].Columns["UsersId"]);

            bindingSourceLoan = new BindingSource(dataSet, "LoanAgr"); //bs dataset
            bindingSourceOOO = new BindingSource(dataSet, "OOO"); 
            bindingSourceUsers = new BindingSource(dataSet, "Users");
            bindingSourceLoan = new BindingSource(bindingSourceOOO, "ooo-loanagr"); //bs with relations
            bindingSourceUsers = new BindingSource(bindingSourceLoan, "loanagr-users"); 
            bindingSourceFiles = new BindingSource(bindingSourceUsers, "users-files");

            gridOOO = new DataGridView(); //dg OOO
            gridOOO.Size = new Size(300, 610);
            gridOOO.Location = new Point(5, 5);
            gridOOO.DataSource = bindingSourceOOO;
            gridLoan = new DataGridView(); //dg LoanAgr
            gridLoan.Size = new Size(250, 200);
            gridLoan.Location = new Point(310, 5);
            gridLoan.DataSource = bindingSourceLoan;
            gridUsers = new DataGridView(); //dg Users
            gridUsers.Size = new Size(350, 200);
            gridUsers.Location = new Point(570, 5);
            gridUsers.DataSource = bindingSourceUsers;
            gridFiles = new DataGridView(); //dg Files
            gridFiles.Size = new Size(670, 200);
            gridFiles.Location = new Point(310, gridUsers.Bottom + 30); 
            gridFiles.DataSource = bindingSourceFiles;

            this.Controls.AddRange(new Control[] { gridUsers, gridFiles, gridOOO, gridLoan }); //control with 4 dg

            dataSet.Tables["OOO"].Columns["IdOOO"].ColumnMapping = MappingType.Hidden; // hidden ID's 
            dataSet.Tables["LoanAgr"].Columns["Id"].ColumnMapping = MappingType.Hidden;
            dataSet.Tables["LoanAgr"].Columns["LoanId"].ColumnMapping = MappingType.Hidden;
            dataSet.Tables["Users"].Columns["FILESId"].ColumnMapping = MappingType.Hidden;
            dataSet.Tables["Users"].Columns["IdUsers"].ColumnMapping = MappingType.Hidden;
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
        private void saveButtonLoan_Click(object sender, EventArgs e) //save for LoanAgr
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=usersdb;Integrated Security=True"))
            {
                connection.Open();
                adapterLoan = new SqlDataAdapter("SELECT * FROM LoanAgr;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapterLoan);
                adapterLoan.InsertCommand = new SqlCommand("sp_Loan", connection);
                adapterLoan.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapterLoan.InsertCommand.Parameters.Add(new SqlParameter("@договор", SqlDbType.NVarChar, 50, "Договор"));
                adapterLoan.InsertCommand.Parameters.Add(new SqlParameter("@принят", SqlDbType.Date, 30, "Принят"));
                adapterLoan.InsertCommand.Parameters.Add(new SqlParameter("@loanid", SqlDbType.Int, 10, "LoanId"));
                SqlParameter parameter = adapterLoan.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 10, "Id");

                parameter.Direction = ParameterDirection.Output;
                adapterLoan.Update(dataSet.Tables["LoanAgr"]);
            }
        }
        private void saveButtonUsers_Click(object sender, EventArgs e) //save for Users
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=usersdb;Integrated Security=True"))
            {
                connection.Open();
                adapterUsers = new SqlDataAdapter("SELECT * FROM Users;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapterUsers);
                adapterUsers.InsertCommand = new SqlCommand("sp_Users", connection);
                adapterUsers.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapterUsers.InsertCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.NText, 10, "Name"));
                adapterUsers.InsertCommand.Parameters.Add(new SqlParameter("@age", SqlDbType.NText, 10, "Age"));
                adapterUsers.InsertCommand.Parameters.Add(new SqlParameter("@idusers", SqlDbType.Int, 10, "IdUsers"));
                SqlParameter parameter = adapterUsers.InsertCommand.Parameters.Add("@FILESId", SqlDbType.Int, 10, "FILESId");
                parameter.Direction = ParameterDirection.Output;
                adapterUsers.Update(dataSet.Tables["Users"]);
            }
        }
        private void saveButtonFiles_Click(object sender, EventArgs e) //save for Files in DB - TO-DO
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=usersdb;Integrated Security=True"))
            {

            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen; //form position and size
            this.Left += 400;
            Size = new Size(1000, 800); 
        }

    }
 }
