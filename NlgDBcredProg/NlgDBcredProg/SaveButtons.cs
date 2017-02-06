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

        private void gdOsnSdelkVdch_CellContentClick(object sender, DataGridViewCellEventArgs e) //make clickable cells gdOsnSdelkVdch
        {
            {
                Process.Start(gdOsnSdelkVdch.SelectedCells[0].Value.ToString());
            }
        }

        private void gdKredDocum_CellContentClick(object sender, DataGridViewCellEventArgs e) //make clickable cells gdKredDocum
        {
            {
                Process.Start(gdKredDocum.SelectedCells[0].Value.ToString());
            }
        }
        private void gdOsnovnSd_CellContentClick(object sender, DataGridViewCellEventArgs e) //make clickable cells gdOsnovnSd
        {
            {
                Process.Start(gdOsnovnSd.SelectedCells[0].Value.ToString());
            }
        }

    }


    public partial class Spid_ds_and_grob : Form
    {

        private void saveDopSogZalPor_Click(object sender, EventArgs e) //save for DopSogZalPor
        {
            {
                connection.Open();
                adDopSogZalPor = new SqlDataAdapter("SELECT * FROM DopSogZalPor;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adDopSogZalPor);
                adDopSogZalPor.InsertCommand = new SqlCommand("sp_DopSogZalPor", connection);
                adDopSogZalPor.InsertCommand.CommandType = CommandType.StoredProcedure;
                adDopSogZalPor.InsertCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 10, "id"));
                adDopSogZalPor.InsertCommand.Parameters.Add(new SqlParameter("@Дог_поруч_залога", SqlDbType.NVarChar, 300, "Дог_поруч_залога"));
                adDopSogZalPor.InsertCommand.Parameters.Add(new SqlParameter("@Одобрение_сделки", SqlDbType.NVarChar, 300, "Одобрение_сделки"));
                adDopSogZalPor.InsertCommand.Parameters.Add(new SqlParameter("@ЕГРЮЛ_на_дату_подп", SqlDbType.NVarChar, 300, "ЕГРЮЛ_на_дату_подп"));
                adDopSogZalPor.InsertCommand.Parameters.Add(new SqlParameter("@Список_участн_на_дату", SqlDbType.NVarChar, 300, "Список_участн_на_дату"));
                adDopSogZalPor.Update(dataSet.Tables["DopSogZalPor"]);
                connection.Close();
            }
        }

        private void saveGrpObject_Click(object sender, EventArgs e) //save for GrpObject
        {
            {
                connection.Open();
                adGrpObject = new SqlDataAdapter("SELECT * FROM GrpObject;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adGrpObject);
                adGrpObject.InsertCommand = new SqlCommand("sp_GrpObject", connection);
                adGrpObject.InsertCommand.CommandType = CommandType.StoredProcedure;
                adGrpObject.InsertCommand.Parameters.Add(new SqlParameter("@Группы_объектов", SqlDbType.NVarChar, 50, "Группы_объектов"));
                adGrpObject.InsertCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 30, "id"));
                SqlParameter parameter = adGrpObject.InsertCommand.Parameters.Add("@idGrObj", SqlDbType.Int, 10, "idGrObj");
                parameter.Direction = ParameterDirection.Output;
                adGrpObject.Update(dataSet.Tables["GrpObject"]);
                connection.Close();
            }
        }

        private void saveObjData_Click(object sender, EventArgs e) //save for ObjData
        {
            {
                connection.Open();
                adObjData = new SqlDataAdapter("SELECT * FROM ObjData;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adObjData);
                adObjData.InsertCommand = new SqlCommand("sp_ObjData", connection);
                adObjData.InsertCommand.CommandType = CommandType.StoredProcedure;
                adObjData.InsertCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 10, "id"));
                adObjData.InsertCommand.Parameters.Add(new SqlParameter("@Выписки_ЕГРП", SqlDbType.NVarChar, 300, "Выписки_ЕГРП"));
                adObjData.InsertCommand.Parameters.Add(new SqlParameter("@Свид_права_собст", SqlDbType.NVarChar, 300, "Свид_права_собст"));
                adObjData.InsertCommand.Parameters.Add(new SqlParameter("@Договоры_куп_прод_обрем", SqlDbType.NVarChar, 300, "Договоры_куп_прод_обрем"));
                adObjData.InsertCommand.Parameters.Add(new SqlParameter("@Кадастровый_пасп", SqlDbType.NVarChar, 300, "Кадастровый_пасп"));
                adObjData.InsertCommand.Parameters.Add(new SqlParameter("@Фотографии", SqlDbType.NVarChar, 300, "Фотографии"));
                adObjData.InsertCommand.Parameters.Add(new SqlParameter("@Согласие_на_обремен", SqlDbType.NVarChar, 300, "Согласие_на_обремен"));
                adObjData.Update(dataSet.Tables["ObjData"]);
                connection.Close();
            }
        }

        private void gdDopSogZalPor_CellContentClick(object sender, DataGridViewCellEventArgs e) //make clickable cells gdDopSogZalPor
        {
            {
                Process.Start(gdDopSogZalPor.SelectedCells[0].Value.ToString());
            }
        }
        private void gdObjData_CellContentClick(object sender, DataGridViewCellEventArgs e) //make clickable cells gdObjData
        {
            {
                Process.Start(gdObjData.SelectedCells[0].Value.ToString());
            }
        }

    }

    public partial class DocumentsForm : Form
    {

        private void saveZaemwik_Click(object sender, EventArgs e) //save for Zaemwik
        {
            {
                connection.Open();
                adZaemwik = new SqlDataAdapter("SELECT * FROM Zaemwik;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adZaemwik);
                adZaemwik.InsertCommand = new SqlCommand("sp_Zaemwik", connection);
                adZaemwik.InsertCommand.CommandType = CommandType.StoredProcedure;
                adZaemwik.InsertCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 10, "id"));
                adZaemwik.InsertCommand.Parameters.Add(new SqlParameter("@Паспорт", SqlDbType.NVarChar, 300, "Паспорт"));
                adZaemwik.InsertCommand.Parameters.Add(new SqlParameter("@ЕГРЮЛ", SqlDbType.NVarChar, 300, "ЕГРЮЛ"));
                adZaemwik.InsertCommand.Parameters.Add(new SqlParameter("@Участники", SqlDbType.NVarChar, 300, "Участники"));
                adZaemwik.InsertCommand.Parameters.Add(new SqlParameter("@Заявка", SqlDbType.NVarChar, 300, "Заявка"));
                adZaemwik.InsertCommand.Parameters.Add(new SqlParameter("@Анкета", SqlDbType.NVarChar, 300, "Анкета"));
                adZaemwik.Update(dataSet.Tables["Zaemwik"]);
                connection.Close();
            }
        }

        private void saveDocsZalPor_Click(object sender, EventArgs e) //save for DocsZalPor
        {
            {
                connection.Open();
                adDocsZalPor = new SqlDataAdapter("SELECT * FROM DocsZalPor;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adDocsZalPor);
                adDocsZalPor.InsertCommand = new SqlCommand("sp_DocsZalPor", connection);
                adDocsZalPor.InsertCommand.CommandType = CommandType.StoredProcedure;
                adDocsZalPor.InsertCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 10, "id"));
                adDocsZalPor.InsertCommand.Parameters.Add(new SqlParameter("@Паспорт", SqlDbType.NVarChar, 300, "Паспорт"));
                adDocsZalPor.InsertCommand.Parameters.Add(new SqlParameter("@ЕГРЮЛ", SqlDbType.NVarChar, 300, "ЕГРЮЛ"));
                adDocsZalPor.InsertCommand.Parameters.Add(new SqlParameter("@Участники", SqlDbType.NVarChar, 300, "Участники"));
                adDocsZalPor.InsertCommand.Parameters.Add(new SqlParameter("@Заявка", SqlDbType.NVarChar, 300, "Заявка"));
                adDocsZalPor.InsertCommand.Parameters.Add(new SqlParameter("@Анкета", SqlDbType.NVarChar, 300, "Анкета"));
                adDocsZalPor.Update(dataSet.Tables["DocsZalPor"]);
                connection.Close();
            }
        }

        private void gdZaemwik_CellContentClick(object sender, DataGridViewCellEventArgs e) //make clickable cells gdZaemwik
        {
            {
                Process.Start(gdZaemwik.SelectedCells[0].Value.ToString());
            }
        }
        private void gdDocsZalPor_CellContentClick(object sender, DataGridViewCellEventArgs e) //make clickable cells gdDocsZalPor
        {
            {
                Process.Start(gdDocsZalPor.SelectedCells[0].Value.ToString());
            }
        }
    }
}