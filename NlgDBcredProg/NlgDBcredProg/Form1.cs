using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace NlgDBcredProg
{
    public partial class Form1 : Form

    {
        SqlConnection connection;
        SqlDataAdapter adapterUsers;
        SqlDataAdapter adapterFiles;
        DataSet dataSet;
        BindingSource bindingSourceUsers;
        BindingSource bindingSourceFiles;
        DataGridView gridUsers;
        DataGridView gridFiles;

        public Form1()
        
        {
            InitializeComponent();
            Size = new Size(450, 450); //РАЗМЕР ДАТАГРИДОВ
            connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=usersdb;Integrated Security=True"); //измени дома инстанс для синхронизации БД
            adapterUsers = new SqlDataAdapter("SELECT * FROM Users;", connection);                                       //инстансы - home-sqlexpress, work - cibexpress
            adapterFiles = new SqlDataAdapter("SELECT * FROM Files", connection);
            dataSet = new DataSet(); 
            adapterUsers.Fill(dataSet, "Users");
            adapterFiles.Fill(dataSet, "Files");
            dataSet.Relations.Add("users-files", //название связи
            dataSet.Tables["Users"].Columns["Id"],//первичный ключ главной таблицы
            dataSet.Tables["Files"].Columns["UsersId"]);//внешний ключ подчиненной таблицы
            bindingSourceUsers = new BindingSource(dataSet, "Users");
            bindingSourceFiles = new BindingSource(bindingSourceUsers, "users-files"); 
            gridUsers = new DataGridView();
            gridUsers.Size = new Size(this.ClientRectangle.Width - 20, (this.ClientRectangle.Height >> 1) - 15);
            gridUsers.Location = new Point(170, 10); // ТУТ МЕНЯЕТСЯ ПОЗИЦИЯ ОТ ФОРМЫ!!!
            gridUsers.DataSource = bindingSourceUsers;
            gridFiles = new DataGridView();
            gridFiles.Size = gridUsers.Size;
            gridFiles.Location = new Point(170, gridUsers.Bottom + 10); // И ТУТ
            gridFiles.DataSource = bindingSourceFiles;
            this.Controls.AddRange(new Control[] { gridUsers, gridFiles });
            dataSet.Tables["Users"].Columns["Id"].ReadOnly = true; // R/O на ид в юзер таблице 
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            DataRow row = dataSet.Tables[0].NewRow(); // добавляем новую строку в DataTable
            dataSet.Tables[0].Rows.Add(row);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=usersdb;Integrated Security=True"))
            {
                connection.Open();
                adapterUsers = new SqlDataAdapter("SELECT * FROM Users;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapterUsers);
                adapterUsers.InsertCommand = new SqlCommand("sp_Users", connection);
                adapterUsers.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapterUsers.InsertCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.NText, 10, "Name"));
                adapterUsers.InsertCommand.Parameters.Add(new SqlParameter("@age", SqlDbType.NText, 10,"Age"));
                SqlParameter parameter = adapterUsers.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 10,"Id");
                parameter.Direction = ParameterDirection.Output;
                adapterUsers.Update(dataSet.Tables["Users"]);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen;
            this.Left += 400;
            Size = new Size(1000, 700); //размер основной формы и позиция
            
        }

    }
 }

