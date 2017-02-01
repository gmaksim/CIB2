using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NlgDBcredProg
{
    public partial class AuthForm : Form
    {
       public AuthForm()
        {
            InitializeComponent();
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen; // position and size
        }

        private void auth_proc(object sender, EventArgs e) //for main program
        {
            /*
            Program.connection = @"Data Source=.\cibEXPRESS ;Initial Catalog=CredDogCIB;User Id=" + textBox1.Text + ";Password=" + textBox2.Text + ";"; // connection to SQL
            int j = 1;
            try
            {
                SqlConnection connection = new SqlConnection(Program.connection);
                connection.Open();
                j++;
                connection.Close();
            }
            catch
            {
                MessageBox.Show("Логин или пароль некорректны");
            }
            if (j != 1)
            {
                Form1 fm2 = new Form1(); // run Form1 form
                fm2.Show();
                this.Hide(); // hide AuthForm after Form1
            }*/
        }

    }
} 