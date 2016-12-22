using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NlgDBcredProg
{
    public partial class Group : Form
    {
        public Group()
        {
            InitializeComponent();



        }

        private void Group_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen; //position like main form
            this.Left += 400;
            Size = new Size(1000, 800);
        }
    }
}
