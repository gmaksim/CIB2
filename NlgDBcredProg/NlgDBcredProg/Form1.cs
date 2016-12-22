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
        DataSet dataSet;
        SqlDataAdapter adapterUsers, adapterFiles, adapterOOO, adapterLoan, adapterZalogodat, adapterPoruchit, adapterGroupObj, adapterFilesGrOb;
        BindingSource bindingSourceUsers, bindingSourceFiles, bindingSourceOOO, bindingSourceLoan, bindingSourceZalogodat, bindingSourcePoruchit, bindingSourceGroupObj, bindingSourceFilesGrOb;


        DataGridView gridUsers, gridFiles, gridOOO, gridLoan, gridZalogodat, gridPoruchit, gridGroupObj, gridFilesGrOb;

        public Form1()
        
        {
            InitializeComponent();
            Size = new Size(450, 450); 
            connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=usersdb;Integrated Security=True"); //connection to SQL

            adapterUsers = new SqlDataAdapter("SELECT * FROM Users;", connection); adapterOOO = new SqlDataAdapter("SELECT * FROM OOO", connection); //select from tables
            adapterLoan = new SqlDataAdapter("SELECT * FROM LoanAgr", connection); adapterZalogodat = new SqlDataAdapter("SELECT * FROM Zalogodat", connection);
            adapterPoruchit = new SqlDataAdapter("SELECT * FROM Poruchit", connection); adapterFiles = new SqlDataAdapter("SELECT * FROM Files", connection);
            //adapterGroupObj = new SqlDataAdapter("SELECT * FROM GroupObj", connection); adapterFilesGrOb = new SqlDataAdapter("SELECT * FROM FilesGrOb", connection);

            dataSet = new DataSet(); //create dataset with tables
            adapterUsers.Fill(dataSet, "Users"); adapterOOO.Fill(dataSet, "OOO"); adapterLoan.Fill(dataSet, "LoanAgr");
            adapterZalogodat.Fill(dataSet, "Zalogodat"); adapterPoruchit.Fill(dataSet, "Poruchit"); adapterFiles.Fill(dataSet, "Files");
            //adapterGroupObj.Fill(dataSet, "GroupObj"); adapterFilesGrOb.Fill(dataSet, "FilesGrOb");

            dataSet.Relations.Add("ooo-loanagr",dataSet.Tables["OOO"].Columns["IdOOO"],dataSet.Tables["LoanAgr"].Columns["LoanId"]); //relations OOO and LoanAgr      
            dataSet.Relations.Add("loanagr-users",dataSet.Tables["LoanAgr"].Columns["Id"],dataSet.Tables["Users"].Columns["IdUsers"]); //relations LoanAgr and Users (main data)  
            dataSet.Relations.Add("loanagr-zalogodat",dataSet.Tables["LoanAgr"].Columns["Id"],dataSet.Tables["Zalogodat"].Columns["ZalId"]); //relations LoanAgr and Zalogodat
            dataSet.Relations.Add("loanagr-poruchit", dataSet.Tables["LoanAgr"].Columns["Id"], dataSet.Tables["Poruchit"].Columns["PorId"]); //relations LoanAgr and Poruchit
            dataSet.Relations.Add("zalogodat-files", dataSet.Tables["Zalogodat"].Columns["FilesZalId"], dataSet.Tables["Files"].Columns["ZalFileId"]); //relations Zalogod and Files   
            dataSet.Relations.Add("poruchit-files", dataSet.Tables["Poruchit"].Columns["FilesPorId"],dataSet.Tables["Files"].Columns["PorFileId"]); //relations Poruchit and Files      

            bindingSourceOOO = new BindingSource(dataSet, "OOO"); bindingSourceLoan = new BindingSource(dataSet, "LoanAgr"); //bs dataset+
            bindingSourceUsers = new BindingSource(dataSet, "Users"); bindingSourceZalogodat = new BindingSource(dataSet, "Zalogodat");
            bindingSourcePoruchit = new BindingSource(dataSet, "Poruchit"); bindingSourceFiles = new BindingSource(dataSet, "Files");
            //bindingSourceGroupObj = new BindingSource(dataSet, "GroupObj"); bindingSourceFilesGrOb = new BindingSource(dataSet, "FilesGrOb");

            bindingSourceLoan = new BindingSource(bindingSourceOOO, "ooo-loanagr"); bindingSourceZalogodat = new BindingSource(bindingSourceLoan, "loanagr-zalogodat"); //bs with relations
            bindingSourcePoruchit = new BindingSource(bindingSourceLoan, "loanagr-poruchit"); bindingSourceUsers = new BindingSource(bindingSourceLoan, "loanagr-users");
            bindingSourceFiles = new BindingSource(bindingSourceZalogodat, "zalogodat-files"); 
            bindingSourceFiles = new BindingSource(bindingSourcePoruchit, "poruchit-files");

            gridOOO = new DataGridView(); gridOOO.Size = new Size(300, 610); gridOOO.Location = new Point(5, 5); gridOOO.DataSource = bindingSourceOOO; //dg OOO
            gridLoan = new DataGridView(); gridLoan.Size = new Size(250, 200); gridLoan.Location = new Point(310, 5); gridLoan.DataSource = bindingSourceLoan; //dg LoanAgr
            gridUsers = new DataGridView(); gridUsers.Size = new Size(650, 200); gridUsers.Location = new Point(570, 5); gridUsers.DataSource = bindingSourceUsers; //dg Users
            gridZalogodat = new DataGridView(); gridZalogodat.Size = new Size(300, 200); gridZalogodat.Location = new Point(310, 240); gridZalogodat.DataSource = bindingSourceZalogodat; //dg Zalogodat
            gridPoruchit = new DataGridView(); gridPoruchit.Size = new Size(300, 200); gridPoruchit.Location = new Point(620, 240); gridPoruchit.DataSource = bindingSourcePoruchit; //dg Poruchit
            gridFiles = new DataGridView(); gridFiles.Size = new Size(670, 200); gridFiles.Location = new Point(310, gridUsers.Bottom + 300); gridFiles.DataSource = bindingSourceFiles; //dg Files

            this.Controls.AddRange(new Control[] { gridUsers, gridFiles, gridOOO, gridLoan, gridZalogodat, gridPoruchit, gridGroupObj, gridFilesGrOb }); //control with 4 dg

            dataSet.Tables["OOO"].Columns["IdOOO"].ColumnMapping = MappingType.Hidden; // hidden ID's 
            dataSet.Tables["LoanAgr"].Columns["Id"].ColumnMapping = MappingType.Hidden; 
            dataSet.Tables["LoanAgr"].Columns["LoanId"].ColumnMapping = MappingType.Hidden; 
            dataSet.Tables["Users"].Columns["IdUsers"].ColumnMapping = MappingType.Hidden;
            dataSet.Tables["Users"].Columns["Id"].ColumnMapping = MappingType.Hidden;
            dataSet.Tables["Zalogodat"].Columns["ZalId"].ColumnMapping = MappingType.Hidden;
            dataSet.Tables["Zalogodat"].Columns["FilesZalId"].ColumnMapping = MappingType.Hidden;
            dataSet.Tables["Poruchit"].Columns["PorId"].ColumnMapping = MappingType.Hidden;
            dataSet.Tables["Poruchit"].Columns["FilesPorId"].ColumnMapping = MappingType.Hidden;
            dataSet.Tables["Files"].Columns["ZalFileId"].ColumnMapping = MappingType.Hidden;
            dataSet.Tables["Files"].Columns["PorFileId"].ColumnMapping = MappingType.Hidden;
            dataSet.Tables["Files"].Columns["Id"].ColumnMapping = MappingType.Hidden;
        }

        private void saveButtonOOO_Click(object sender, EventArgs e) //save for OOO
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=usersdb;Integrated Security=True"))
            {
                connection.Open();
                adapterOOO = new SqlDataAdapter("SELECT * FROM OOO;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapterOOO);
                adapterOOO.InsertCommand = new SqlCommand("sp_OOO", connection);
                adapterOOO.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapterOOO.InsertCommand.Parameters.Add(new SqlParameter("@наименование", SqlDbType.NVarChar, 50, "Наименование"));
                adapterOOO.InsertCommand.Parameters.Add(new SqlParameter("@принят", SqlDbType.Date, 30, "Принят"));
                SqlParameter parameter = adapterOOO.InsertCommand.Parameters.Add("@IdOOO", SqlDbType.Int, 10, "IdOOO");
                parameter.Direction = ParameterDirection.Output;
                adapterOOO.Update(dataSet.Tables["OOO"]);
            }
        }
        private void saveButtonLoan_Click(object sender, EventArgs e) //save for LoanAgr
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=usersdb;Integrated Security=True"))
            {
                connection.Open();
                adapterLoan = new SqlDataAdapter("SELECT * FROM LoanAgr;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapterLoan);
                adapterLoan.InsertCommand = new SqlCommand("sp_Loan", connection);
                adapterLoan.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapterLoan.InsertCommand.Parameters.Add(new SqlParameter("@договор", SqlDbType.NVarChar, 50, "Договор"));
                adapterLoan.InsertCommand.Parameters.Add(new SqlParameter("@принят", SqlDbType.Date, 30, "Принят"));
                adapterLoan.InsertCommand.Parameters.Add(new SqlParameter("@loanid", SqlDbType.Int, 10, "LoanId"));
                SqlParameter parameter = adapterLoan.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 10, "Id");
                parameter.Direction = ParameterDirection.Output;
                adapterLoan.Update(dataSet.Tables["LoanAgr"]);
            }
        }
        private void saveButtonUsers_Click(object sender, EventArgs e) //save for Users
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=usersdb;Integrated Security=True"))
            {
                connection.Open();
                adapterUsers = new SqlDataAdapter("SELECT * FROM Users;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapterUsers);
                adapterUsers.InsertCommand = new SqlCommand("sp_Users", connection);
                adapterUsers.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapterUsers.InsertCommand.Parameters.Add(new SqlParameter("@idusers", SqlDbType.Int, 10, "IdUsers"));
                adapterUsers.InsertCommand.Parameters.Add(new SqlParameter("@доп_соглашение", SqlDbType.NVarChar, 50, "Доп_соглашение"));
                adapterUsers.InsertCommand.Parameters.Add(new SqlParameter("@оф_переписка", SqlDbType.NVarChar, 50, "Оф_переписка"));
                adapterUsers.InsertCommand.Parameters.Add(new SqlParameter("@кредитный_договор", SqlDbType.NVarChar, 50, "Кредитный_договор"));
                adapterUsers.InsertCommand.Parameters.Add(new SqlParameter("@одобрение_сделки", SqlDbType.NVarChar, 50, "Одобрение_сделки"));
                adapterUsers.InsertCommand.Parameters.Add(new SqlParameter("@егрюл", SqlDbType.NVarChar, 50, "ЕГРЮЛ"));
                adapterUsers.InsertCommand.Parameters.Add(new SqlParameter("@список_участниковков", SqlDbType.NVarChar, 50, "Список_участниковков"));
                SqlParameter parameter = adapterUsers.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 10, "Id");
                parameter.Direction = ParameterDirection.Output;
                adapterUsers.Update(dataSet.Tables["Users"]);
            }
        }

        private void saveButtonZalog_Click(object sender, EventArgs e) //save for Zalogodatel 
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=usersdb;Integrated Security=True"))
            {
                connection.Open();
                adapterZalogodat = new SqlDataAdapter("SELECT * FROM Zalogodat;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapterZalogodat);
                adapterZalogodat.InsertCommand = new SqlCommand("sp_Zalogodat", connection);
                adapterZalogodat.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapterZalogodat.InsertCommand.Parameters.Add(new SqlParameter("@ФИО", SqlDbType.NVarChar, 50, "ФИО"));
                adapterZalogodat.InsertCommand.Parameters.Add(new SqlParameter("@Основная_сделка", SqlDbType.NVarChar, 50, "Основная_сделка"));
                adapterZalogodat.InsertCommand.Parameters.Add(new SqlParameter("@Доп_соглашение", SqlDbType.NVarChar, 50, "Доп_соглашение"));
                adapterZalogodat.InsertCommand.Parameters.Add(new SqlParameter("@Дата_рождения", SqlDbType.Date, 30, "Дата_рождения"));
                adapterZalogodat.InsertCommand.Parameters.Add(new SqlParameter("@ZalId", SqlDbType.Int, 10, "ZalId"));
                SqlParameter parameter = adapterZalogodat.InsertCommand.Parameters.Add("@FilesZalId", SqlDbType.Int, 10, "FilesZalId");
                parameter.Direction = ParameterDirection.Output;
                adapterZalogodat.Update(dataSet.Tables["Zalogodat"]);
            }
        }

        private void saveButtonPoruchit_Click(object sender, EventArgs e) //save for Poruchitel 
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=usersdb;Integrated Security=True"))
            {
                connection.Open();
                adapterPoruchit = new SqlDataAdapter("SELECT * FROM Poruchit;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapterPoruchit);
                adapterPoruchit.InsertCommand = new SqlCommand("sp_Poruchit", connection);
                adapterPoruchit.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapterPoruchit.InsertCommand.Parameters.Add(new SqlParameter("@ФИО", SqlDbType.NVarChar, 50, "ФИО"));
                adapterPoruchit.InsertCommand.Parameters.Add(new SqlParameter("@Основная_сделка", SqlDbType.NVarChar, 50, "Основная_сделка"));
                adapterPoruchit.InsertCommand.Parameters.Add(new SqlParameter("@Доп_соглашение", SqlDbType.NVarChar, 50, "Доп_соглашение"));
                adapterPoruchit.InsertCommand.Parameters.Add(new SqlParameter("@Дата_рождения", SqlDbType.Date, 30, "Дата_рождения"));
                adapterPoruchit.InsertCommand.Parameters.Add(new SqlParameter("@PorId", SqlDbType.Int, 10, "PorId"));
                SqlParameter parameter = adapterPoruchit.InsertCommand.Parameters.Add("@FilesPorId", SqlDbType.Int, 10, "FilesPorId");
                parameter.Direction = ParameterDirection.Output;
                adapterPoruchit.Update(dataSet.Tables["Poruchit"]);
            }
        }

        private void saveButtonFiles_Click(object sender, EventArgs e) //save for Files 
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\cibEXPRESS;Initial Catalog=usersdb;Integrated Security=True"))
            {
                connection.Open();
                adapterFiles = new SqlDataAdapter("SELECT * FROM Files;", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapterFiles);
                adapterFiles.InsertCommand = new SqlCommand("sp_Files", connection);
                adapterFiles.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapterFiles.InsertCommand.Parameters.Add(new SqlParameter("@ZalFileId", SqlDbType.Int, 10, "ZalFileId"));
                adapterFiles.InsertCommand.Parameters.Add(new SqlParameter("@PorFileId", SqlDbType.Int, 10, "PorFileId"));
                adapterFiles.InsertCommand.Parameters.Add(new SqlParameter("@Паспорт", SqlDbType.NVarChar, 50, "Паспорт"));
                adapterFiles.InsertCommand.Parameters.Add(new SqlParameter("@Заявка ", SqlDbType.NVarChar, 50, "Заявка"));
                adapterFiles.InsertCommand.Parameters.Add(new SqlParameter("@Анкета", SqlDbType.NVarChar, 50, "Анкета"));
                SqlParameter parameter = adapterFiles.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 10, "Id");
                parameter.Direction = ParameterDirection.Output;
                adapterFiles.Update(dataSet.Tables["Files"]);
            }
        }



        private void Form1_Load(object sender, EventArgs e) 
        {
            StartPosition = FormStartPosition.WindowsDefaultBounds; //main form position and size
            this.Left += 400;
            Size = new Size(1300, 800); 
        }

        private void searchForm_Click(object sender, EventArgs e) //button to open Search form
        {
            Search src = new Search();
            src.Show();
        }

        private void groupObjForm_Click(object sender, EventArgs e) //button to open GroupObject form
        {
            Group src = new Group();
            src.Show();
        }
    }
}
