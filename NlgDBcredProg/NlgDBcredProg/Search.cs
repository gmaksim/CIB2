using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace NlgDBcredProg
{
    public partial class Search : Form
    {
        SqlConnection connection;
        DataSet dataSet;
        SqlDataAdapter adapterUsers;
        BindingSource bindingSourceUsers;
        DataGridView gridUsers;

        public Search()
        {
            InitializeComponent();
            connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=usersdb;Integrated Security=True"); //connection to SQL
            adapterUsers = new SqlDataAdapter("SELECT * FROM Users;", connection); //select from tables
            dataSet = new DataSet(); //create dataset with tables
            adapterUsers.Fill(dataSet, "Users");
            bindingSourceUsers = new BindingSource(dataSet, "Users");
            gridUsers = new DataGridView(); //dg Users
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
    }
}
