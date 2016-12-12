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
        SqlDataAdapter adapterUsers;
        SqlDataAdapter adapterFiles;
        // students = files, groups = users
        DataSet dataSet;
        BindingSource bindingSourceUsers;
        BindingSource bindingSourceFiles;
        DataGridView gridUsers;
        DataGridView gridFiles;

        public Form1()


        {

            InitializeComponent();
            this.Size = new Size(500, 500);
            connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=usersdb;Integrated Security=True");
            adapterUsers = new SqlDataAdapter("SELECT * FROM Users;", connection);
            adapterFiles = new SqlDataAdapter("SELECT * FROM Files", connection);
            dataSet = new DataSet();
            adapterUsers.Fill(dataSet, "Users");
            adapterFiles.Fill(dataSet, "Files");
            dataSet.Relations.Add("users-files", //название связи
                dataSet.Tables["Users"].Columns["Id"],//первичный ключ главной таблицы
                dataSet.Tables["Files"].Columns["UsersId"]);//внешний ключ подчиненной таблицы
            bindingSourceUsers = new BindingSource(dataSet, "Users");
            bindingSourceFiles = new BindingSource(bindingSourceUsers, "groups-students");
            gridUsers = new DataGridView();
            gridUsers.Size = new Size(this.ClientRectangle.Width - 20, (this.ClientRectangle.Height >> 1) - 15);
            gridUsers.Location = new Point(10, 10);
            gridUsers.DataSource = bindingSourceUsers;
            gridFiles = new DataGridView();
            gridFiles.Size = gridUsers.Size;
            gridFiles.Location = new Point(10, gridUsers.Bottom + 10);
            gridFiles.DataSource = bindingSourceFiles;
            this.Controls.AddRange(new Control[] { gridUsers, gridFiles });


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }

       



    }


