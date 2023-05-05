using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace StudentInfo
{
    public partial class ScheduleForm : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        string connectionString = @"Data Source=DESKTOP-UG8SN2H\SQLEXPRESS; Initial Catalog = testsql2; Integrated Security = True;";
        public ScheduleForm()
        {
            InitializeComponent();
            //PopulateComboBox();
            //LoadSubject();
            displayInfo();
            dtStartTime.Format = DateTimePickerFormat.Custom;
            dtStartTime.CustomFormat = "hh:mm tt";
            dtEndTime.Format = DateTimePickerFormat.Custom;
            dtEndTime.CustomFormat = "hh:mm tt";
            LoadSection();
            LoadTeacher();
            LoadRoom();
            LoadSubject();
        }
        public void LoadRoom()
        {
            SqlConnection con = new SqlConnection(connectionString);
            cboSubjectCode.Items.Clear();
            con.Open();
            cmd = new SqlCommand("select * from tablerooms", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cboRoom.Items.Add(dr["room"].ToString());
            }
            dr.Close();
            con.Close();
        }
        public void LoadSection()
        {
            SqlConnection con = new SqlConnection(connectionString);
            cboSection.Items.Clear();
            con.Open();
            cmd = new SqlCommand("SELECT * FROM tableSection Order By Section_Code ASC", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cboSection.Items.Add(dr["section_code"].ToString());
            }
            dr.Close();
            con.Close();
        }
        public void displayInfo()
        {
            SqlConnection con = new SqlConnection(connectionString);
            dataGridView1.Rows.Clear();
            string day = "";
            int i = 0;
            con.Open();
            cmd = new SqlCommand("select id, subject_code, subject_title, section, start_time, end_time, mon, tue, wed, thu, fri, sat, teacher, room from tblSchedule where section = @section", con);
            cmd.Parameters.AddWithValue("@section", cboSection.Text);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                if (bool.Parse(dr["mon"].ToString()) == true)
                {
                    day = "M";
                }
                if (bool.Parse(dr["tue"].ToString()) == true)
                {
                    day += "T";
                }
                if (bool.Parse(dr["wed"].ToString()) == true)
                {
                    day += "W";
                }
                if (bool.Parse(dr["thu"].ToString()) == true)
                {
                    day += "TH";
                }
                if (bool.Parse(dr["fri"].ToString()) == true)
                {
                    day += "F";
                }
                if (bool.Parse(dr["sat"].ToString()) == true)
                {
                    day += "S";
                }
                dataGridView1.Rows.Add(dr["id"].ToString(), dr["section"].ToString(), dr["subject_code"].ToString(), dr["subject_title"].ToString(), dr["start_time"].ToString() + " - " + dr["end_time"].ToString(), day, dr["teacher"].ToString(), dr["room"].ToString());
                day = "";
            }
            con.Close();
            dr.Close();
        }
        /*public void displayInfo()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM tblSchedule", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }*/
        private void comboBox1_YearSem_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            cmd = new SqlCommand("SELECT * FROM tblSubject where subject_code like '" + cboSubjectCode.Text + "'", con);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                txtSubjetTitle.Text = dr["subject_name"].ToString();
            }
            con.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Program_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void LoadSubject()
        {
            SqlConnection con = new SqlConnection(connectionString);
            cboSubjectCode.Items.Clear();
            con.Open();
            cmd = new SqlCommand("select * from tblsubject", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cboSubjectCode.Items.Add(dr["subject_code"].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void LoadTeacher()
        {
            //guide: https://www.youtube.com/watch?v=au-5buEKT_k
            string connectionString = @"Data Source=DESKTOP-UG8SN2H\SQLEXPRESS; Initial Catalog = testsql2; Integrated Security = True;";
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tableTeacher", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cboTeacher.Items.Add(dt.Rows[i]["FullName"]);
            }
        }
        /*private void PopulateComboBox()
        {
            //guide: https://www.youtube.com/watch?v=au-5buEKT_k
            string connectionString = @"Data Source=DESKTOP-UG8SN2H\SQLEXPRESS; Initial Catalog = testsql2; Integrated Security = True;";
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblSubject", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1_CourseCode.Items.Add(dt.Rows[i]["Course_Title"]);
            }
        }*/

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Form2 newform = new Form2();
            this.Hide();
            newform.ShowDialog();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            CourseForm newform = new CourseForm();
            this.Hide();
            newform.ShowDialog();
        }

        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            //dataGridView1.Columns[0].Width = 100;
            //dataGridView1.Columns[1].Width = 100;
            //dataGridView1.Columns[2].Width = 250;
            //dataGridView1.Columns[4].Width = 80;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 250;
            txtSubjetTitle.BackColor = System.Drawing.SystemColors.Window;
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            TeacherForm newform = new TeacherForm();
            this.Hide();
            newform.ShowDialog();
        }
        private void clearField()
        {
            cboSubjectCode.SelectedIndex = -1;
            //cboSection.SelectedIndex = -1;
            cboTeacher.SelectedIndex = -1;
            cboRoom.SelectedIndex = -1;
            txtSubjetTitle.Clear();
            chkFriday.Checked = false;
            chkMonday.Checked = false;
            chkSaturday.Checked = false;
            chkThursday.Checked = false;
            chkTuesday.Checked = false;
            chkWednesday.Checked = false;
            //comboBox4_Term.SelectedIndex = -1;
            dataGridView1.ClearSelection();
            //textBox2_LastName.Focus();
        }
        private void AddCourseButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    if (cboSubjectCode.SelectedIndex == -1 || txtSubjetTitle.TextLength == 0 || cboSection.SelectedIndex == -1 || cboTeacher.SelectedIndex == -1 || cboRoom.SelectedIndex == -1)
                    {
                        MessageBox.Show("Fill all the empty fields first.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else if (chkMonday.Checked == false && chkTuesday.Checked == false && chkWednesday.Checked == false && chkThursday.Checked == false && chkFriday.Checked == false && chkSaturday.Checked == false)
                    {
                        MessageBox.Show("You didn't assign a day.");
                    }

                    else
                    {
                        using (var cmd = new SqlCommand("INSERT INTO tblSchedule (Subject_Code, Subject_Title, section, start_time, end_time, mon, tue, wed, thu, fri, sat, teacher,room) VALUES (@Subject_Code, @Subject_Title, @section, @start_time, @end_time, @mon, @tue, @wed, @thu, @fri, @sat, @teacher,@room)"))
                        {

                            cmd.Connection = con;
                            //@Student_ID, @LastName, @FirstName, @MiddleInitial, @Contact_Number, @Address, @BirthDate, @Course, @Year_Level, @School_Year, @Term
                            cmd.Parameters.Add("@Subject_Code", cboSubjectCode.Text);
                            cmd.Parameters.Add("@Subject_Title", txtSubjetTitle.Text);
                            cmd.Parameters.Add("@section", cboSection.Text);
                            cmd.Parameters.Add("@start_time", dtStartTime.Text);
                            cmd.Parameters.Add("@end_time", dtEndTime.Text);
                            cmd.Parameters.Add("@mon", chkMonday.Checked.ToString());
                            cmd.Parameters.Add("@tue", chkTuesday.Checked.ToString());
                            cmd.Parameters.Add("@wed", chkWednesday.Checked.ToString());
                            cmd.Parameters.Add("@thu", chkThursday.Checked.ToString());
                            cmd.Parameters.Add("@fri", chkFriday.Checked.ToString());
                            cmd.Parameters.Add("@sat", chkSaturday.Checked.ToString());
                            cmd.Parameters.Add("@teacher", cboTeacher.Text);
                            cmd.Parameters.Add("@room", cboRoom.Text);



                            con.Open();
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("Record saved.");
                                displayInfo();
                                clearField();
                                //randomID();
                                con.Close();

                            }
                            else
                            {
                                MessageBox.Show("Record failed");
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error during insert: " + ex.Message);
                }
            }
            dataGridView1.ClearSelection();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            SectionForm newform = new SectionForm();
            this.Hide();
            newform.ShowDialog();
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            RoomForm newform = new RoomForm();
            this.Hide();
            newform.ShowDialog();
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            SubjectForm newform = new SubjectForm();
            this.Hide();
            newform.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexRow];
            SqlConnection Conn = new SqlConnection(connectionString);
            SqlCommand Comm1 = new SqlCommand("SELECT * FROM tblSchedule where id = '" + row.Cells[0].Value.ToString() + "'", Conn);
            Conn.Open();
            SqlDataReader DR1 = Comm1.ExecuteReader();
            if (DR1.Read())
            {
                labelID.Text = DR1.GetValue(0).ToString();
                cboSubjectCode.Text = DR1.GetValue(1).ToString();
                cboSection.Text = DR1.GetValue(3).ToString();
                dtStartTime.Text = DR1.GetValue(4).ToString();
                dtEndTime.Text = DR1.GetValue(5).ToString();
                //chkMonday.Checked = DR1.GetValue(6).ToString();
                chkMonday.Checked = bool.Parse(DR1.GetValue(6).ToString());
                chkTuesday.Checked = bool.Parse(DR1.GetValue(7).ToString());
                chkWednesday.Checked = bool.Parse(DR1.GetValue(8).ToString());
                chkThursday.Checked = bool.Parse(DR1.GetValue(9).ToString());
                chkFriday.Checked = bool.Parse(DR1.GetValue(10).ToString());
                chkSaturday.Checked = bool.Parse(DR1.GetValue(11).ToString());
                cboTeacher.Text = DR1.GetValue(12).ToString();
                cboRoom.Text = DR1.GetValue(13).ToString();
            }
            Conn.Close();
            /*  try
              {
                  indexRow = e.RowIndex;
                  DataGridViewRow row = dataGridView1.Rows[indexRow];
                  textBox1_StudentNumber.Text = row.Cells[0].Value.ToString();
                  textBox2_LastName.Text = row.Cells[1].Value.ToString();
                  textBox3_FirstName.Text = row.Cells[2].Value.ToString();
                  textBox4_MiddleInitial.Text = row.Cells[3].Value.ToString();
                  textBox5_ContactNumber.Text = row.Cells[4].Value.ToString();
                  textBox6_Address.Text = row.Cells[5].Value.ToString();
                  dateTimePicker1.Text = row.Cells[6].Value.ToString();
                  comboBox1_Course.Text = row.Cells[7].Value.ToString();
                  comboBox2_YearLevel.Text = row.Cells[8].Value.ToString();
                  comboBox3_SchoolYear.Text = row.Cells[11].Value.ToString();
                  comboBox4_Term.Text = row.Cells[9].Value.ToString();
                  comboBox5_Section.Text = row.Cells[10].Value.ToString();
              }
              catch
              {

              }*/
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this schedule?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete tblSchedule where id = @id", con);
                cmd.Parameters.Add("@id", labelID.Text);
                cmd.ExecuteNonQuery();
                displayInfo();
                clearField();
                //randomID();
                con.Close();
                dataGridView1.ClearSelection();
                MessageBox.Show("Successfully deleted.");//do something
            }
            else if (dialogResult == DialogResult.No)
            {
                //do
            }
        }

        private void cboSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    if (cboSubjectCode.SelectedIndex == -1 || txtSubjetTitle.TextLength == 0 || cboSection.SelectedIndex == -1 || cboTeacher.SelectedIndex == -1 || cboRoom.SelectedIndex == -1)
                    {
                        MessageBox.Show("Fill all the empty fields first.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else if (chkMonday.Checked == false && chkTuesday.Checked == false && chkWednesday.Checked == false && chkThursday.Checked == false && chkFriday.Checked == false && chkSaturday.Checked == false)
                    {
                        MessageBox.Show("You didn't assign a day.");
                    }

                    else
                    {
                        using (var cmd = new SqlCommand("UPDATE tblSchedule set subject_code = @subject_code, subject_title = @subject_title, section = @section, start_time = @start_time, end_time = @end_time, mon = @mon, tue = @tue, wed = @wed, thu = @thu, fri = @fri, sat = @sat, teacher = @teacher, room = @room where id = @id",con))
                        {

                            cmd.Connection = con;
                            cmd.Parameters.Add("@id", labelID.Text);
                            //@Student_ID, @LastName, @FirstName, @MiddleInitial, @Contact_Number, @Address, @BirthDate, @Course, @Year_Level, @School_Year, @Term
                            cmd.Parameters.Add("@Subject_Code", cboSubjectCode.Text);
                            cmd.Parameters.Add("@Subject_Title", txtSubjetTitle.Text);
                            cmd.Parameters.Add("@section", cboSection.Text);
                            cmd.Parameters.Add("@start_time", dtStartTime.Text);
                            cmd.Parameters.Add("@end_time", dtEndTime.Text);
                            cmd.Parameters.Add("@mon", chkMonday.Checked.ToString());
                            cmd.Parameters.Add("@tue", chkTuesday.Checked.ToString());
                            cmd.Parameters.Add("@wed", chkWednesday.Checked.ToString());
                            cmd.Parameters.Add("@thu", chkThursday.Checked.ToString());
                            cmd.Parameters.Add("@fri", chkFriday.Checked.ToString());
                            cmd.Parameters.Add("@sat", chkSaturday.Checked.ToString());
                            cmd.Parameters.Add("@teacher", cboTeacher.Text);
                            cmd.Parameters.Add("@room", cboRoom.Text);



                            con.Open();
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("Schedule has been updated.");
                                displayInfo();
                                clearField();
                                //randomID();
                                con.Close();

                            }
                            else
                            {
                                MessageBox.Show("Update failed");
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error during Update: " + ex.Message);
                }
            }
            dataGridView1.ClearSelection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearField();
            cboSection.SelectedIndex = -1;
        }
    }
}
