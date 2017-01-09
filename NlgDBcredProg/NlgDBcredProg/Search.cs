using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace NlgDBcredProg
{
    public partial class Search : Form
    {                                                                           
     

        public Search()
        {
            InitializeComponent(); 
           
        }

        private void Search_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen; //position like main form
            this.Left += 400;
            Size = new Size(1000, 800);
        }

        private void textBox1_TextChanged(object sender, EventArgs e) 
        {
            //bindingSourceUsers.Filter = "Name LIKE '%' + '" + textBox1.Text + "%'"; //search in tables
        }
    }
}
