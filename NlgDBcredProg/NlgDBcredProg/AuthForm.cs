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

        }


 
        private void auth_proc(object sender, EventArgs e)
        {
            //DE Program.connection = Program.connectionIdPass.Replace("{Id}", textBox1.Text).Replace("{Password}", textBox2.Text);
            Program.connection = @"Data Source=.\cibEXPRESS ;Initial Catalog=CredDogCIB;User Id=" + textBox1.Text + ";Password=" + textBox2.Text + ";";

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
                MessageBox.Show("Неверные параметры подключения");
            }
            if (j != 1)
            {
                Form1 fm2 = new Form1();
                fm2.Show();
                this.Hide();
            }
        }

    }
} 