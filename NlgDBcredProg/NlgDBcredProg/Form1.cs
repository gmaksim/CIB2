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
            connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=usersdb;Integrated Security=True"); //инстансы - home-sqlexpress, work - cibexpress

            adapterUsers = new SqlDataAdapter("SELECT * FROM Users;", connection);
            adapterFiles = new SqlDataAdapter("SELECT * FROM Files", connection);
            adapterOOO = new SqlDataAdapter("SELECT * FROM OOO", connection);
       
            dataSet = new DataSet(); 
            adapterUsers.Fill(dataSet, "Users");
            adapterFiles.Fill(dataSet, "Files");
            adapterOOO.Fill(dataSet, "OOO");

            dataSet.Relations.Add("ooo-users",                  //название связи
            dataSet.Tables["OOO"].Columns["IdOOO"],             //первичный ключ главной таблицы
            dataSet.Tables["Users"].Columns["OOOid"]);          //внешний ключ подчиненной таблицы
            dataSet.Relations.Add("users-files", 
            dataSet.Tables["Users"].Columns["FILESid"],
            dataSet.Tables["Files"].Columns["UsersId"]);

            bindingSourceOOO = new BindingSource(dataSet, "OOO");
            bindingSourceUsers = new BindingSource(dataSet, "Users");
            bindingSourceUsers = new BindingSource(bindingSourceOOO, "ooo-users");
            bindingSourceFiles = new BindingSource(bindingSourceUsers, "users-files");

            gridUsers = new DataGridView(); //форма Users
            gridUsers.Size = new Size(this.ClientRectangle.Width - 20, (this.ClientRectangle.Height >> 1) - 15);
            gridUsers.Location = new Point(170, 10); 
            gridUsers.DataSource = bindingSourceUsers;

            gridFiles = new DataGridView(); //форма Files
            gridFiles.Size = gridUsers.Size;
            gridFiles.Location = new Point(170, gridUsers.Bottom + 10); 
            gridFiles.DataSource = bindingSourceFiles;

            gridOOO = new DataGridView(); //форма OOO
            gridOOO.Size = new Size(this.ClientRectangle.Width - 20, (this.ClientRectangle.Height >> 1) - 15);
            gridOOO.Location = new Point(20, gridFiles.Bottom + 10); 
            gridOOO.DataSource = bindingSourceOOO;

            this.Controls.AddRange(new Control[] { gridUsers, gridFiles, gridOOO });
            dataSet.Tables["Users"].Columns["Id"].ReadOnly = true; // R/O на ид в юзер таблице 

        }
//кнопки для грида ФИО
        private void addButton_Click(object sender, EventArgs e)
        {
            DataRow row = dataSet.Tables[0].NewRow(); // добавляем новую строку в DataTable
            dataSet.Tables[0].Rows.Add(row);
        }

        private void saveButton_Click(object sender, EventArgs e) 
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

        private void Form1_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen;
            this.Left += 400;
            Size = new Size(1000, 700); //размер основной формы и позиция
            
        }

    }
 }

