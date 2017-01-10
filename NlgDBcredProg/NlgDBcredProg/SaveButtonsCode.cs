using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
using System.Diagnostics;

namespace NlgDBcredProg
{
    public partial class Form1 : Form
    {


        private void saveOOO_Click(object sender, EventArgs e) //save for OOO
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=CredDogCIB;Integrated Security=True"))
            {
                connection.Open();
                adOOO = new SqlDataAdapter("SELECT * FROM OOO;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adOOO);
                adOOO.InsertCommand = new SqlCommand("sp_OOO", connection);
                adOOO.InsertCommand.CommandType = CommandType.StoredProcedure;
                adOOO.InsertCommand.Parameters.Add(new SqlParameter("@Наименование", SqlDbType.NVarChar, 50, "Наименование"));
                adOOO.InsertCommand.Parameters.Add(new SqlParameter("@Принят", SqlDbType.Date, 30, "Принят"));
                SqlParameter parameter = adOOO.InsertCommand.Parameters.Add("@IdOOO", SqlDbType.Int, 10, "IdOOO");
                parameter.Direction = ParameterDirection.Output;
                adOOO.Update(dataSet.Tables["OOO"]);
            }
        }

        private void saveKredDog_Click(object sender, EventArgs e) //save for KredDog
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=CredDogCIB;Integrated Security=True"))
            {
                connection.Open();
                adKredDog = new SqlDataAdapter("SELECT * FROM KredDog;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adKredDog);
                adKredDog.InsertCommand = new SqlCommand("sp_KredDog", connection);
                adKredDog.InsertCommand.CommandType = CommandType.StoredProcedure;
                adKredDog.InsertCommand.Parameters.Add(new SqlParameter("@Договор", SqlDbType.NVarChar, 50, "Договор"));
                adKredDog.InsertCommand.Parameters.Add(new SqlParameter("@Принят", SqlDbType.Date, 30, "Принят"));
                adKredDog.InsertCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 10, "id"));
                SqlParameter parameter = adKredDog.InsertCommand.Parameters.Add("@idKredDog", SqlDbType.Int, 10, "idKredDog");
                parameter.Direction = ParameterDirection.Output;
                adKredDog.Update(dataSet.Tables["KredDog"]);
            }
        }

        private void saveZaemwik_Click(object sender, EventArgs e) //save for Zaemwik
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=CredDogCIB;Integrated Security=True"))
            {
                connection.Open();
                adZaemwik = new SqlDataAdapter("SELECT * FROM Zaemwik;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adZaemwik);
                adZaemwik.InsertCommand = new SqlCommand("sp_Zaemwik", connection);
                adZaemwik.InsertCommand.CommandType = CommandType.StoredProcedure;
                adZaemwik.InsertCommand.Parameters.Add(new SqlParameter("@Договор", SqlDbType.NVarChar, 50, "Договор"));
                adZaemwik.InsertCommand.Parameters.Add(new SqlParameter("@Принят", SqlDbType.Date, 30, "Принят"));
                adZaemwik.InsertCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 10, "id"));
                SqlParameter parameter = adZaemwik.InsertCommand.Parameters.Add("@idKredDog", SqlDbType.Int, 10, "idKredDog");
                parameter.Direction = ParameterDirection.Output;
                adZaemwik.Update(dataSet.Tables["Zaemwik"]);
            }
        }





    }
}