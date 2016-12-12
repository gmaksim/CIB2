using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NlgDBcredProg
{
    public partial class Form1 : Form

    {
        private int nc;
        private int nr;

        public Form1()
        { //need usersdb DB and Users TABLES
            InitializeComponent();
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=usersdb;Integrated Security=True";
            string sql = "SELECT * FROM Users";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                // Создаем объект Dataset
                DataSet ds = new DataSet();
                // Заполняем Dataset
                adapter.Fill(ds);
                // Отображаем данные
                dataGridView1.DataSource = ds.Tables[0];
            

            }

            string sql2 = "SELECT * FROM Files";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sql2, connection);
                // Создаем объект Dataset
                DataSet ds = new DataSet();
                // Заполняем Dataset
                adapter.Fill(ds);
                // Отображаем данные
          
                dataGridView2.DataSource = ds.Tables[0];

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



 

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            nc = e.ColumnIndex;
            nr = e.RowIndex;
            dataGridView2.Rows[nr].Cells[nc].Selected = true;
        }




        /*  private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
          {
              label1.Text = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
          }


          private void label1_Changed(object sender, EventArgs e)
          {
              this.ИМЯBindingSource.Filter = string.Format("CONVERT(СТОЛБЕЦ, 'System.String') LIKE '{0}'", this.label1.Text);
          }*/


    }
}

