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
    public partial class StudentForm : Form
    {
        SqlConnection connection;
        Form ParentForm;
        string CurIdStud;
        public StudentForm(Form Parent, string id)
        {
            InitializeComponent();
            string path = @"Data Source = (LocalDB)\MSSQLLocalDB;" +
               @"AttachDbFilename = |DataDirectory|\Database.mdf; Integrated Security = True";
            connection = new SqlConnection(path);
            ParentForm = Parent;
            CurIdStud = id;
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            List<Data> datas = new List<Data>();
            connection.Open();

            try
            {
                
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

                string c = "SELECT Pass,IdSubject FROM dbo.Pass WHERE IdStudent LIKE " + CurIdStud + ";";
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

        private void StudentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ParentForm.Close();
        }

        private void dataGridViewSubjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
