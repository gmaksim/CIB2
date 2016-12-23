using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace NlgDBcredProg
{
    public partial class Search : Form
    {                                                                           //CredDogCIB CHANGE IT
        SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=usersdb;Integrated Security=True");
        DataSet dataSet;
        SqlDataAdapter adapterUsers;
        BindingSource bindingSourceUsers;
        DataGridView gridUsers;

        public Search()
        {
            InitializeComponent(); //connect and view of table "Users"  (all comments u can see in main form, it's copy-paste "Users" grid)
            adapterUsers = new SqlDataAdapter("SELECT * FROM Users;", connection);                             
            dataSet = new DataSet(); 
            adapterUsers.Fill(dataSet, "Users");
            bindingSourceUsers = new BindingSource(dataSet, "Users");
            gridUsers = new DataGridView(); 
            gridUsers.Size = new Size(500, 500);
            gridUsers.Location = new Point(5, 5);
            gridUsers.DataSource = bindingSourceUsers;
            this.Controls.AddRange(new Control[] {gridUsers});
        }

        private void Search_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen; //position like main form
            this.Left += 400;
            Size = new Size(1000, 800);
        }

        private void textBox1_TextChanged(object sender, EventArgs e) 
        {
            bindingSourceUsers.Filter = "Name LIKE '%' + '" + textBox1.Text + "%'"; //search in tables
        }
    }
}
