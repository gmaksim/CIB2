using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NlgDBcredProg
{
    static class Program
    {
        // DE public static string connectionIdPass = @"Data Source=.\cibEXPRESS ;Initial Catalog=CredDogCIB;User Id={Id};Password={Password};";
        // DE public static string connection;

        public static string connection;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
       
            Application.Run(new AuthForm());
   
            
        }
    }

}