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
        //CHANGE CONNECTION!!!

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



        private void saveKredDocum_Click(object sender, EventArgs e) //save for KredDocum
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=CredDogCIB;Integrated Security=True"))
            {
                connection.Open();
                adKredDocum = new SqlDataAdapter("SELECT * FROM KredDocum;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adKredDocum);
                adKredDocum.InsertCommand = new SqlCommand("sp_KredDocum", connection);
                adKredDocum.InsertCommand.CommandType = CommandType.StoredProcedure;
                adKredDocum.InsertCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 10, "id"));
                adKredDocum.InsertCommand.Parameters.Add(new SqlParameter("@Оф_переписка", SqlDbType.NVarChar, 300, "Оф_переписка"));
                adKredDocum.InsertCommand.Parameters.Add(new SqlParameter("@Судебные_решения", SqlDbType.NVarChar, 300, "Судебные_решения"));
                adKredDocum.Update(dataSet.Tables["KredDocum"]);
            }
        }

        private void saveOsnSdelkVdch_Click(object sender, EventArgs e) //save for OsnSdelkVdch
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=CredDogCIB;Integrated Security=True"))
            {
                connection.Open();
                adOsnSdelkVdch = new SqlDataAdapter("SELECT * FROM OsnSdelkVdch;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adOsnSdelkVdch);
                adOsnSdelkVdch.InsertCommand = new SqlCommand("sp_OsnSdelkVdch", connection);
                adOsnSdelkVdch.InsertCommand.CommandType = CommandType.StoredProcedure;
                adOsnSdelkVdch.InsertCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 10, "id"));
                adOsnSdelkVdch.InsertCommand.Parameters.Add(new SqlParameter("@Кредитный_дог", SqlDbType.NVarChar, 300, "Кредитный_дог"));
                adOsnSdelkVdch.InsertCommand.Parameters.Add(new SqlParameter("@Одобрение_сделки", SqlDbType.NVarChar, 300, "Одобрение_сделки"));
                adOsnSdelkVdch.InsertCommand.Parameters.Add(new SqlParameter("@ЕГРЮЛ_на_дату_подп", SqlDbType.NVarChar, 300, "ЕГРЮЛ_на_дату_подп"));
                adOsnSdelkVdch.InsertCommand.Parameters.Add(new SqlParameter("@Список_участн_на_дату", SqlDbType.NVarChar, 300, "Список_участн_на_дату"));
                adOsnSdelkVdch.Update(dataSet.Tables["OsnSdelkVdch"]);
            }
        }

        private void saveZalogPoruch_Click(object sender, EventArgs e) //save for ZalogPoruch
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=CredDogCIB;Integrated Security=True"))
            {
                connection.Open();
                adZalogPoruch = new SqlDataAdapter("SELECT * FROM ZalogPoruch;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adZalogPoruch);
                adZalogPoruch.InsertCommand = new SqlCommand("sp_ZalogPoruch", connection);
                adZalogPoruch.InsertCommand.CommandType = CommandType.StoredProcedure;
                adZalogPoruch.InsertCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 10, "id"));
                adZalogPoruch.InsertCommand.Parameters.Add(new SqlParameter("@ФИО", SqlDbType.NVarChar, 50, "ФИО"));
                adZalogPoruch.InsertCommand.Parameters.Add(new SqlParameter("@Тип_З_П", SqlDbType.NVarChar, 50, "Тип_З_П"));
                adZalogPoruch.InsertCommand.Parameters.Add(new SqlParameter("@Принят", SqlDbType.Date, 30, "Принят"));
                SqlParameter parameter = adZalogPoruch.InsertCommand.Parameters.Add("@idZalPor", SqlDbType.Int, 10, "idZalPor");
                parameter.Direction = ParameterDirection.Output;
                adZalogPoruch.Update(dataSet.Tables["ZalogPoruch"]);
            }
        }

        private void saveOsnovnSd_Click(object sender, EventArgs e) //save for OsnovnSd
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=CredDogCIB;Integrated Security=True"))
            {
                connection.Open();
                adOsnovnSd = new SqlDataAdapter("SELECT * FROM OsnovnSd;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adOsnovnSd);
                adOsnovnSd.InsertCommand = new SqlCommand("sp_OsnovnSd", connection);
                adOsnovnSd.InsertCommand.CommandType = CommandType.StoredProcedure;
                adOsnovnSd.InsertCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 10, "id"));
                adOsnovnSd.InsertCommand.Parameters.Add(new SqlParameter("@Дог_поруч_залога", SqlDbType.NVarChar, 300, "Дог_поруч_залога"));
                adOsnovnSd.InsertCommand.Parameters.Add(new SqlParameter("@Одобрение_сделки", SqlDbType.NVarChar, 300, "Одобрение_сделки"));
                adOsnovnSd.InsertCommand.Parameters.Add(new SqlParameter("@ЕГРЮЛ_на_дату_подп", SqlDbType.NVarChar, 300, "ЕГРЮЛ_на_дату_подп"));
                adOsnovnSd.InsertCommand.Parameters.Add(new SqlParameter("@Список_участн_на_дату", SqlDbType.NVarChar, 300, "Список_участн_на_дату"));
                adOsnovnSd.InsertCommand.Parameters.Add(new SqlParameter("@Согласие_на_обремен", SqlDbType.NVarChar, 300, "Согласие_на_обремен"));
                adOsnovnSd.Update(dataSet.Tables["OsnovnSd"]);
            }
        }







        private void saveSpDopSog_Click(object sender, EventArgs e) //save for SpDopSog
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=CredDogCIB;Integrated Security=True"))
            {
                connection.Open();
                adSpDopSog = new SqlDataAdapter("SELECT * FROM SpDopSog;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adSpDopSog);
                adSpDopSog.InsertCommand = new SqlCommand("sp_SpDopSog", connection);
                adSpDopSog.InsertCommand.CommandType = CommandType.StoredProcedure;
                adSpDopSog.InsertCommand.Parameters.Add(new SqlParameter("@Договор", SqlDbType.NVarChar, 50, "Договор"));
                adSpDopSog.InsertCommand.Parameters.Add(new SqlParameter("@Принят", SqlDbType.Date, 30, "Принят"));
                adSpDopSog.InsertCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 30, "id"));
                SqlParameter parameter = adSpDopSog.InsertCommand.Parameters.Add("@idSpDpSg", SqlDbType.Int, 10, "idSpDpSg");
                parameter.Direction = ParameterDirection.Output;
                adSpDopSog.Update(dataSet.Tables["SpDopSog"]);
            }
        }

        private void saveDopSog_Click(object sender, EventArgs e) //save for DopSog
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=CredDogCIB;Integrated Security=True"))
            {
                connection.Open();
                adDopSog = new SqlDataAdapter("SELECT * FROM DopSog;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adDopSog);
                adDopSog.InsertCommand = new SqlCommand("sp_DopSog", connection);
                adDopSog.InsertCommand.CommandType = CommandType.StoredProcedure;
                adDopSog.InsertCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 10, "id"));
                adDopSog.InsertCommand.Parameters.Add(new SqlParameter("@Кредитный_дог", SqlDbType.NVarChar, 300, "Кредитный_дог"));
                adDopSog.InsertCommand.Parameters.Add(new SqlParameter("@Одобрение_сделки", SqlDbType.NVarChar, 300, "Одобрение_сделки"));
                adDopSog.InsertCommand.Parameters.Add(new SqlParameter("@ЕГРЮЛ_на_дату_подп", SqlDbType.NVarChar, 300, "ЕГРЮЛ_на_дату_подп"));
                adDopSog.InsertCommand.Parameters.Add(new SqlParameter("@Список_участн_на_дату", SqlDbType.NVarChar, 300, "Список_участн_на_дату"));
                adDopSog.Update(dataSet.Tables["DopSog"]);
            }
        }

    }
}