using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DataBaseStudents
{
    public partial class LoginForm : Form
    {
        SqlConnection connection;
        public LoginForm()
        {
            InitializeComponent();
            //Data Source=(LocalDB)\MSSQLLocalDB;
            //AttachDbFilename = C:\Users\Кирилл\source\repos\DataBaseStudents\DataBaseStudents\Database.mdf;
            //Integrated Security=True
            string path = @"Data Source = (LocalDB)\MSSQLLocalDB;" +
                @"AttachDbFilename = |DataDirectory|\Database.mdf; Integrated Security = True";
            connection = new SqlConnection(path);
            
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            connection.Open();
            try
            {
                String Name = LoginBox.Text;
                // Команда Insert.
                string c = "SELECT Password,Admin,IdStudent FROM dbo.LoginTable WHERE Login LIKE @Name;";
                SqlCommand cmd = new SqlCommand(c, connection);
                SqlParameter name = cmd.Parameters.Add("@Name", SqlDbType.Text);
                name.Value = Name;
                SqlDataReader reader = cmd.ExecuteReader();
                object tmp = new object();
                object admin = new object();
                object id = new object();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        tmp = reader.GetValue(0);
                        admin = reader.GetValue(1);
                        id = reader.GetValue(2);
                    }
                }
                reader.Close();
                if(bool.Parse(admin.ToString()) && tmp.ToString() == PassBox.Text)
                {
                    connection.Close();
                    connection.Dispose();
                    MainForm main = new MainForm(this);
                    main.Visible = true;
                    main.Show();
                    this.Visible = false;
                }
                else if(!bool.Parse(admin.ToString()) && tmp.ToString() == PassBox.Text)
                {
                    connection.Close();
                    connection.Dispose();
                    StudentForm main = new StudentForm(this,id.ToString());
                    main.Visible = true;
                    main.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
                //MessageBox.Show(tmp.ToString());
                //MessageBox.Show(admin.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                connection.Close();
            }
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            String order = "";
            String Name = LoginBox.Text;
            String Pass = PassBox.Text;
            
            try
            {
                if (textBoxId.Text != "Введите ID")
                {
                    connection.Open();
                    // Команда Insert.
                    string sql = "Insert into dbo.LoginTable (Id, Login, Password, Admin, IdStudent) "
                                                     + " values (@Id, @Login, @Password, 0, @IdStudent);";
                    string c = "SELECT COUNT(*) FROM dbo.LoginTable;";
                    object count = new object();
                    SqlCommand cmd = new SqlCommand(c, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            count = reader.GetValue(0);
                        }
                    }
                    reader.Close();

                    cmd.CommandText = sql;
                    SqlParameter IdParameter = cmd.Parameters.Add("@Id", SqlDbType.Int);
                    IdParameter.Value = Int32.Parse(count.ToString()) + 1;
                    // Создать объект Parameter.
                    SqlParameter LoginParameter = new SqlParameter("@Login", SqlDbType.Text);
                    LoginParameter.Value = Name;
                    cmd.Parameters.Add(LoginParameter);

                    // Добавить параметр @highSalary (Написать короче).
                    SqlParameter PassParameter = cmd.Parameters.Add("@Password", SqlDbType.Text);
                    PassParameter.Value = Pass;
                    SqlParameter IdStudParameter = cmd.Parameters.Add("@IdStudent", SqlDbType.Int);

                    //cmd.CommandText = cmd.CommandText.Replace("@Id", IdParameter.Value.ToString());
                    //cmd.CommandText = cmd.CommandText.Replace("@Login", Name);
                    //cmd.CommandText = cmd.CommandText.Replace("@Password", Pass);

                    //MessageBox.Show(cmd.CommandText);
                    //SqlCommand command = new SqlCommand(cmd.CommandText, connection);
                    // Выполнить Command (Используется для delete, insert, update).
                    int rowCount = cmd.ExecuteNonQuery();
                    //MessageBox.Show("Row Count affected = " + rowCount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                connection.Close();
                //connection.Dispose();
                //connection = null;
            }
        }

        private void loginTableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {


        }

        private void LoginForm_Load(object sender, EventArgs e)
        {


        }

        private void loginTableBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void loginTableBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {

        }
    }
}
