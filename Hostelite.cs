using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hms
{
    public partial class Hostelite : Form
    {
        public Hostelite()
        {
            InitializeComponent();
            Loads();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=hms;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader read;
        SqlDataAdapter drr;
        string id;
        bool Mode = true;
        string sql;




        private void label31_Click(object sender, EventArgs e)
        {
            this.Close();
            Home f1 = new Home();
            f1.Show();
        }

        private void label24_Click(object sender, EventArgs e)
        {
            this.Close();
            Hostel f1 = new Hostel();
            f1.Show();
        }

        private void Hostelite_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hmsDataSet1.StudentTbl' table. You can move, or remove it, as needed.
            this.studentTblTableAdapter.Fill(this.hmsDataSet1.StudentTbl);
            // TODO: This line of code loads data into the 'hmsDataSet.Table' table. You can move, or remove it, as needed.
            

        }
        private void Loads()
        {
            try
            {
                sql = "select * from StudentTbl order by stId";
                cmd = new SqlCommand(sql, conn);
                conn.Open();

                read = cmd.ExecuteReader();
                dataGridView1.Rows.Clear();

                while (read.Read())
                {
                    dataGridView1.Rows.Add(read[0], read[1], read[2], read[3], read[4], read[5]);
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clearbox()
        {
            stName.Clear();
            stGender.Items.Clear();
            stCourse.Clear();
            stRoomNo.Items.Clear();
            stAddress.Clear();
            stDOB.ResetText();
            stPhone.Clear();
            stGName.Clear();
            stGphone.Clear();
            stStayDate.ResetText();
            stFees.Clear();
            stUsername.Clear();
            stPassword.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string name = stName.Text;
            string gender = stGender.Text;
            string course = stCourse.Text;
            string room = stRoomNo.Text;
            string address = stAddress.Text;
            string dob = stDOB.Text;
            string phone = stPhone.Text;
            string guardian = stGName.Text;
            string guardianPhone = stGphone.Text;
            string stayDate = stStayDate.Text;
            string fees = stFees.Text;
            string username = stUsername.Text;
            string password = stPassword.Text;

            if (Mode == true)
            {
                sql = "insert into StudentTbl (stName,stGender,stCourse,stRoom,stAddress,stDOB,stPhone,stGuardianName,stGuardianPhone,stStayDate,stFees,stuName,stPassword) values(@stName,@stGender,@stCourse,@stRoom,@stAddress,@stDOB,@stPhone,@stGuardianName,@stGuardianPhone,@stStayDate,@stFees,@stuName,@stPassword) ";
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@stName", name);
                cmd.Parameters.AddWithValue("@stGender", gender);
                cmd.Parameters.AddWithValue("@stCourse", course);
                cmd.Parameters.AddWithValue("@stRoom", room);
                cmd.Parameters.AddWithValue("@stAddress", address);
                cmd.Parameters.AddWithValue("@stDOB", dob);
                cmd.Parameters.AddWithValue("@stPhone", phone);
                cmd.Parameters.AddWithValue("@stGuardianName", guardian);
                cmd.Parameters.AddWithValue("@stGuardianPhone", guardianPhone);
                cmd.Parameters.AddWithValue("@stStayDate", stayDate);
                cmd.Parameters.AddWithValue("@stFees", fees);
                cmd.Parameters.AddWithValue("@stuName", username);
                cmd.Parameters.AddWithValue("@stPassword", password );

                MessageBox.Show("Data has been recorded");
                cmd.ExecuteNonQuery();

                clearbox();


            }
            else
            {
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                sql = "update StudentTbl set  stName=@stName,stGender=@stGender,stCourse=@stCourse,stRoomNo=@stRoomNo,stAddress=@stAddress, stDOB=@ stDOB, stPhone=@ stPhone, stGName=@ stGName, stGphone=@ stGphone, stStayDate=@ stStayDate, stFees=@ stFees, stUsername=@ stUsername, stPassword=@ stPassword where stId = @stId";
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@stName", name);
                cmd.Parameters.AddWithValue("@stGender", gender);
                cmd.Parameters.AddWithValue("@stCourse", course);
                cmd.Parameters.AddWithValue("@stRoom", room);
                cmd.Parameters.AddWithValue("@stAddress", address);
                cmd.Parameters.AddWithValue("@stDOB", dob);
                cmd.Parameters.AddWithValue("@stPhone", phone);
                cmd.Parameters.AddWithValue("@stGuardianName", guardian);
                cmd.Parameters.AddWithValue("@stGuardianPhone", guardianPhone);
                cmd.Parameters.AddWithValue("@stStayDate", stayDate);
                cmd.Parameters.AddWithValue("@stFees", fees);
                cmd.Parameters.AddWithValue("@stuName", username);
                cmd.Parameters.AddWithValue("@stPassword", password);
                cmd.Parameters.AddWithValue("@stId", id);

                MessageBox.Show("Data has been recorded");
                cmd.ExecuteNonQuery();

                clearbox();
                Mode = true;
            }
            conn.Close();
            
        }
    }
}
