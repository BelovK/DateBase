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
    public partial class MainForm : Form
    {
        SqlConnection connection;
        Form ParentForm;
        string CurIdStud;
        public MainForm(Form Parent)
        {
            InitializeComponent();
            string path = @"Data Source = (LocalDB)\MSSQLLocalDB;" +
                @"AttachDbFilename = |DataDirectory|\Database.mdf; Integrated Security = True";
            connection = new SqlConnection(path);
            ParentForm = Parent;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //DataGridViewRow DR = (DataGridViewRow)dataGridViewStudent.Rows[0].Clone();
            //DR.Cells["Id"].Value = 1;
            //DR.Cells["Student"].Value = "Кирилл";
            connection.Open();
            List<Data> datas = new List<Data>();
            try
            {
                string c = "SELECT Id, Name FROM dbo.Student;";
                SqlCommand cmd = new SqlCommand(c, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                
                object ID = new object();
                object name = new object();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        ID = reader.GetValue(0);
                        name = reader.GetValue(1);
                        datas.Add(new Data((int)ID, (string)name));
                    }
                }
                reader.Close();
                //MessageBox.Show(ID.ToString());
                //MessageBox.Show(name.ToString());
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
            foreach(Data data in datas)
                dataGridViewStudent.Rows.Add(data.IntegerData,data.StringData);
            //// TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet.Student". При необходимости она может быть перемещена или удалена.
            //this.studentTableAdapter.Fill(this.databaseDataSet.Student);
            //// TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet.Subject". При необходимости она может быть перемещена или удалена.
            //this.subjectTableAdapter.Fill(this.databaseDataSet.Subject);
            //// TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet.View". При необходимости она может быть перемещена или удалена.
            //this.viewTableAdapter.Fill(this.databaseDataSet.View);
        }

        private void dataGridViewStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            List<Data> datas = new List<Data>();
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                connection.Open();
                
                try
                {
                    CurIdStud = dataGridViewStudent.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                    string c = "SELECT Id, Name FROM dbo.Subject;";
                    SqlCommand cmd = new SqlCommand(c, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    object ID = new object();
                    object name = new object();
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            ID = reader.GetValue(0);
                            name = reader.GetValue(1);
                            datas.Add(new Data((int)ID, (string)name));
                        }
                    }
                    reader.Close();
                    //MessageBox.Show(ID.ToString());
                    //MessageBox.Show(name.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                    MessageBox.Show(ex.StackTrace);
                }
                finally
                {
                    
                }
                
                try
                {
                    
                    string c = "SELECT Pass,IdSubject FROM dbo.Pass WHERE IdStudent LIKE " + dataGridViewStudent.Rows[e.RowIndex].Cells["Id"].Value.ToString() + ";";
                    SqlCommand cmd = new SqlCommand(c, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    object Pass = new object();
                    object IdSub = new object();
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            Pass = reader.GetValue(0);
                            IdSub = reader.GetValue(1);
                            if (Pass.Equals(true))
                            {
                                int i = Int32.Parse(IdSub.ToString());
                                datas.Find(x => i == x.IntegerData).SetInt2(1);
                            }
                            else
                            {
                                int i = Int32.Parse(IdSub.ToString());
                                datas.Find(x => i == x.IntegerData).SetInt2(0);
                            }

                        }
                    }
                    reader.Close();
                    //MessageBox.Show(ID.ToString());
                    //MessageBox.Show(name.ToString());
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
                dataGridViewSubjects.Rows.Clear();
                foreach (Data data in datas)
                    dataGridViewSubjects.Rows.Add(data.IntegerData, data.StringData, YesOrNo(data.IntegerData2));
            }
        }
        private Boolean YesOrNo(int i)
        {
            Boolean res = false;
            if (i == 0)
            {
                return res;
            }
            else
                return true;
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ParentForm.Close();
        }

        private void dataGridViewSubjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn &&
                e.RowIndex >= 0)
            {
                try
                {
                    connection.Open();
                    
                    List<Data> Datas = new List<Data>();
                    string c = "INSERT INTO dbo.Pass (Pass,IdStudent,IdSubject) VALUES( ";
                    c = "IF EXISTS(select * from dbo.Pass where IdStudent = @IdStudent AND IdSubject = @IdSubject)";
                    c += " Update dbo.Pass set Pass = @Pass where IdStudent = @IdStudent AND IdSubject = @IdSubject";
                    c += " insert into dbo.Pass(Pass,IdStudent,IdSubject) values(@Pass,@IdStudent,@IdSubject);";
                    SqlCommand cmd = new SqlCommand(c, connection);
                    SqlParameter Pass = cmd.Parameters.Add("@Pass", SqlDbType.Bit);
                    if (bool.Parse(dataGridViewSubjects.Rows[e.RowIndex].Cells["Pass"].Value.ToString()))
                        Pass.Value = true;
                    else
                        Pass.Value = false;
                    SqlParameter Stud = cmd.Parameters.Add("@IdStudent", SqlDbType.Int);
                    Stud.Value = CurIdStud;
                    SqlParameter Sub = cmd.Parameters.Add("@IdSubject", SqlDbType.Int);
                    Sub.Value = dataGridViewSubjects.Rows[e.RowIndex].Cells["PassId"].Value.ToString();
                    
                    int rowCount = cmd.ExecuteNonQuery();
                    //MessageBox.Show(ID.ToString());
                    //MessageBox.Show(name.ToString());
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error: " + ex);
                    //MessageBox.Show(ex.StackTrace);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
