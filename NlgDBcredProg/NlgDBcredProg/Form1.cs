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
        SqlDataAdapter adapterUsers;
        SqlDataAdapter adapterFiles;
        SqlDataAdapter adapterOOO;
        BindingSource bindingSourceUsers;
        BindingSource bindingSourceFiles;
        BindingSource bindingSourceOOO;
        DataGridView gridUsers;
        DataGridView gridFiles;
        DataGridView gridOOO;
        
        public Form1()
        
        {
            InitializeComponent();
            Size = new Size(450, 450); 
            connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=usersdb;Integrated Security=True"); //connection to SQL
            adapterUsers = new SqlDataAdapter("SELECT * FROM Users;", connection); //select from tables
            adapterFiles = new SqlDataAdapter("SELECT * FROM Files", connection);
            adapterOOO = new SqlDataAdapter("SELECT * FROM OOO", connection);

            dataSet = new DataSet(); //create dataset with tables
            adapterUsers.Fill(dataSet, "Users");
            adapterFiles.Fill(dataSet, "Files");
            adapterOOO.Fill(dataSet, "OOO");

            dataSet.Relations.Add("ooo-users", //relations OOO and Users      
            dataSet.Tables["OOO"].Columns["IdOOO"],             
            dataSet.Tables["Users"].Columns["OOOid"]);         

            dataSet.Relations.Add("users-files", //relations Users and Files
            dataSet.Tables["Users"].Columns["FILESid"],
            dataSet.Tables["Files"].Columns["UsersId"]);


            bindingSourceOOO = new BindingSource(dataSet, "OOO"); //bs dataset
            bindingSourceUsers = new BindingSource(dataSet, "Users");

            bindingSourceUsers = new BindingSource(bindingSourceOOO, "ooo-users"); //bs with relations
            bindingSourceFiles = new BindingSource(bindingSourceUsers, "users-files");

            gridUsers = new DataGridView(); //dg Users
            gridUsers.Size = new Size(670, 380);
            gridUsers.Location = new Point(310, 5); 
            gridUsers.DataSource = bindingSourceUsers;

            gridFiles = new DataGridView(); //dg Files
            gridFiles.Size = new Size(670, 200);
            gridFiles.Location = new Point(310, gridUsers.Bottom + 30); 
            gridFiles.DataSource = bindingSourceFiles;

            gridOOO = new DataGridView(); //dg OOO
            gridOOO.Size = new Size (300, 610);
            gridOOO.Location = new Point(5, 5);
            gridOOO.DataSource = bindingSourceOOO;

            this.Controls.AddRange(new Control[] { gridUsers, gridFiles, gridOOO }); //control with 3 dg
            dataSet.Tables["Users"].Columns["Id"].ReadOnly = true; // R/O for 3 id in tables (temporary security)
            dataSet.Tables["OOO"].Columns["IdOOO"].ReadOnly = true;
            dataSet.Tables["Files"].Columns["UsersId"].ReadOnly = true;
        }

        private void saveButtonOOO_Click(object sender, EventArgs e) //save for OOO in DB 
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
                SqlParameter parameter = adapterUsers.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 10, "Id");
                parameter.Direction = ParameterDirection.Output;
                adapterUsers.Update(dataSet.Tables["Users"]);
            }
        }
        private void saveButtonUsers_Click(object sender, EventArgs e) //save for Users in DB 
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=usersdb;Integrated Security=True"))
            {
                connection.Open(); 
                adapterUsers = new SqlDataAdapter("SELECT * FROM Users;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapterUsers);
                adapterUsers.InsertCommand = new SqlCommand("sp_Users", connection);
                adapterUsers.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapterUsers.InsertCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.NText, 10, "Name"));
                adapterUsers.InsertCommand.Parameters.Add(new SqlParameter("@age", SqlDbType.NText, 10,"Age"));
                SqlParameter parameter = adapterUsers.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 10,"Id");
                parameter.Direction = ParameterDirection.Output;
                adapterUsers.Update(dataSet.Tables["Users"]);
            }
        }
        private void saveButtonFiles_Click(object sender, EventArgs e) //save for OOO in DB 
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
                SqlParameter parameter = adapterUsers.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 10, "Id");
                parameter.Direction = ParameterDirection.Output;
                adapterUsers.Update(dataSet.Tables["Users"]);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen; //form position and size
            this.Left += 400;
            Size = new Size(1000, 700); 
        }

    }
 }

