using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NlgDBcredProg
{
    static class Program
    {
        public static string connection;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // direct connection to AuthForm
            //Application.Run(new AuthForm());

            // connection to SQL throw AutForm
            Program.connection = @"Data Source=.\cibEXPRESS; Initial Catalog=CredDogCIB; Integrated Security=True"; 
            SqlConnection connection = new SqlConnection(Program.connection);
            Application.Run(new Search());
            // connection to SQL throw AutForm
        }
    }
}