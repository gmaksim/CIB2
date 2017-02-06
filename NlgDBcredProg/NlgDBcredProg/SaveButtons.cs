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
        SqlConnection connection = new SqlConnection(Program.connection);

        private void saveName_Click(object sender, EventArgs e) //save for Name
        {
            {
                connection.Open();
                adName = new SqlDataAdapter("SELECT * FROM Name;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adName);
                adName.InsertCommand = new SqlCommand("sp_Name", connection);
                adName.InsertCommand.CommandType = CommandType.StoredProcedure;
                adName.InsertCommand.Parameters.Add(new SqlParameter("@Наименование", SqlDbType.NVarChar, 50, "Наименование"));
                adName.InsertCommand.Parameters.Add(new SqlParameter("@Принят", SqlDbType.Date, 30, "Принят"));
                SqlParameter parameter = adName.InsertCommand.Parameters.Add("@idName", SqlDbType.Int, 10, "idName");
                parameter.Direction = ParameterDirection.Output;
                adName.Update(dataSet.Tables["Name"]);
                connection.Close();
            }
        }

        private void saveKredDog_Click(object sender, EventArgs e) //save for KredDog
        {
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
                connection.Close();
            }
        }



        private void saveKredDocum_Click(object sender, EventArgs e) //save for KredDocum
        {
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
                connection.Close();
            }
        }

        private void saveOsnSdelkVdch_Click(object sender, EventArgs e) //save for OsnSdelkVdch
        {
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
                connection.Close();
            }
        }

        private void saveZalogPoruch_Click(object sender, EventArgs e) //save for ZalogPoruch
        {
            {
                connection.Open();
                adZalogPoruch = new SqlDataAdapter("SELECT * FROM ZalogPoruch;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adZalogPoruch);
                adZalogPoruch.InsertCommand = new SqlCommand("sp_ZalogPoruch", connection);
                adZalogPoruch.InsertCommand.CommandType = CommandType.StoredProcedure;
                adZalogPoruch.InsertCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 10, "id"));
                adZalogPoruch.InsertCommand.Parameters.Add(new SqlParameter("@Наименование", SqlDbType.NVarChar, 50, "Наименование"));
                adZalogPoruch.InsertCommand.Parameters.Add(new SqlParameter("@Тип_З_П", SqlDbType.NVarChar, 50, "Тип_З_П"));
                adZalogPoruch.InsertCommand.Parameters.Add(new SqlParameter("@Принят", SqlDbType.Date, 30, "Принят"));
                SqlParameter parameter = adZalogPoruch.InsertCommand.Parameters.Add("@idZalPor", SqlDbType.Int, 10, "idZalPor");
                parameter.Direction = ParameterDirection.Output;
                adZalogPoruch.Update(dataSet.Tables["ZalogPoruch"]);
                connection.Close();
            }
        }

        private void saveOsnovnSd_Click(object sender, EventArgs e) //save for OsnovnSd
        {
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
                connection.Close();
            }
        }

    }
}