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
    public partial class SubjectForm : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        string connectionString = @"Data Source=DESKTOP-UG8SN2H\SQLEXPRESS; Initial Catalog = testsql2; Integrated Security = True;";
        SqlDataAdapter da;
        int indexRow;
        public SubjectForm()
        {
            InitializeComponent();
            displayInfo();
            PopulateComboBox();
            
        }

        private void PopulateComboBox()
        {
            //guide: https://www.youtube.com/watch?v=au-5buEKT_k
            string connectionString = @"Data Source=DESKTOP-UG8SN2H\SQLEXPRESS; Initial Catalog = testsql2; Integrated Security = True;";
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblCourse", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1_Course.Items.Add(dt.Rows[i]["Course_Code"]);
            }
        }
        public void displayInfo()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM tblSubject", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Form2 newform = new Form2();
            this.Hide();
            newform.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("Select Subject_Code from tblSubject where Subject_Code='" + textBox2_SubjectCode.Text + "' ", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        MessageBox.Show("Subject with the same Subject Code already exist.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox2_SubjectCode.Focus();
                    }
                    else if (comboBox1_Course.SelectedIndex == -1 || textBox2_SubjectCode.TextLength == 0 || textBox3_SubjectTitle.TextLength == 0 || textBox4_Units.TextLength == 0 || comboBox1_Year.SelectedIndex == -1 || comboBox2_Semester.SelectedIndex == -1)
                    {
                        MessageBox.Show("Fill all the empty fields first.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        using (var cmd = new SqlCommand("INSERT INTO tblSubject (Course_Code, Subject_Code, Subject_Name, Units, Year, Semester) VALUES (@Course_Code, @Subject_Code, @Subject_Name, @Units, @Year, @Semester)"))
                        {

                            cmd.Connection = con;
                            //@Student_ID, @LastName, @FirstName, @MiddleInitial, @Contact_Number, @Address, @BirthDate, @Course, @Year_Level, @School_Year, @Term
                            cmd.Parameters.Add("@Course_Code", comboBox1_Course.Text);
                            cmd.Parameters.Add("@Subject_Code", textBox2_SubjectCode.Text);
                            cmd.Parameters.Add("@Subject_Name", textBox3_SubjectTitle.Text);
                            cmd.Parameters.Add("@Units", textBox4_Units.Text);
                            cmd.Parameters.Add("@Year", comboBox1_Year.GetItemText(comboBox1_Year.SelectedItem));
                            cmd.Parameters.Add("@Semester", comboBox2_Semester.GetItemText(comboBox2_Semester.SelectedItem));

                            con.Open();
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("Record inserted");
                                displayInfo();
                                clearField();
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
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_Course_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ModifyCourseButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(comboBox1_Course.SelectedIndex == -1 || textBox2_SubjectCode.TextLength == 0 || textBox3_SubjectTitle.TextLength == 0 || textBox4_Units.TextLength == 0 || comboBox1_Year.SelectedIndex == -1)
                {
                    MessageBox.Show("You must fill all the textbox first before you can modify a course.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update tblSubject set course_code = @course_code, subject_code = @subject_code, subject_name = @subject_name, units = @units, year = @year, semester = @semester  where subject_code = @subject_code", con);
                    cmd.Parameters.Add("@course_code", comboBox1_Course.Text);
                    cmd.Parameters.Add("@subject_code", textBox2_SubjectCode.Text);
                    cmd.Parameters.Add("@subject_name", textBox3_SubjectTitle.Text);
                    cmd.Parameters.Add("@units", textBox4_Units.Text);
                    cmd.Parameters.Add("@year", comboBox1_Year.Text);
                    cmd.Parameters.Add("@semester", comboBox2_Semester.Text);
                    cmd.ExecuteNonQuery();
                    displayInfo();
                    clearField();
                    con.Close();
                    MessageBox.Show("Successfully Changed.");



                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox2_CourseCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                indexRow = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[indexRow];
                comboBox1_Course.Text = row.Cells[0].Value.ToString();
                textBox2_SubjectCode.Text = row.Cells[1].Value.ToString();
                textBox3_SubjectTitle.Text = row.Cells[2].Value.ToString();
                textBox4_Units.Text = row.Cells[3].Value.ToString();
                comboBox1_Year.Text = row.Cells[4].Value.ToString();
                comboBox2_Semester.Text = row.Cells[5].Value.ToString();
                
            }
            catch
            {

            }
        }
        void clearField()
        {
            comboBox1_Course.SelectedIndex = -1;
            textBox2_SubjectCode.Clear();
            textBox3_SubjectTitle.Clear();
            textBox4_Units.Clear();
            comboBox1_Year.SelectedIndex = -1;
            dataGridView1.ClearSelection();
            textBox2_SubjectCode.Focus();
            comboBox2_Semester.SelectedIndex = -1;
        }

        private void DeleteCourseButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete tblSubject where subject_code = @subject_code", con);
                cmd.Parameters.Add("@subject_code", textBox2_SubjectCode.Text);
                cmd.ExecuteNonQuery();
                displayInfo();
                clearField();
                con.Close();
                MessageBox.Show("Successfully deleted.");//do something
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    using (DataTable dt = new DataTable("tableCourse"))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM tableCourse where Program like @Program or Course_ID like @Course_ID or Course_Title like @Course_Title or Year_Semester like @Year_Semester", con))
                        {
                            if (textSearch.TextLength == 0)
                            {
                                displayInfo();
                            }
                            else
                            {
                                //guide: https://www.youtube.com/watch?v=FVaQdTpSbS0
                                cmd.Parameters.Add("Program", string.Format("%{0}%", textSearch.Text));
                                cmd.Parameters.Add("Course_ID", string.Format("%{0}%", textSearch.Text));
                                cmd.Parameters.Add("Course_Title", string.Format("%{0}%", textSearch.Text));
                                cmd.Parameters.Add("Year_Semester", textSearch.Text);
                                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                                adapter.Fill(dt);
                                dataGridView1.DataSource = dt;
                                con.Close();
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void textSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Search.PerformClick();
            }
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            ScheduleForm newform = new ScheduleForm();
            this.Hide();
            newform.ShowDialog();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                buttonModifyCourse.Enabled = true;
                buttonAddCourse.Enabled = false; //add button
                buttonDeleteCourse.Enabled = true; //delete button
                textBox2_SubjectCode.Enabled = false;
            }
            else
            {
                textBox2_SubjectCode.Enabled = true;
                buttonModifyCourse.Enabled = false;
                buttonAddCourse.Enabled = true;
                buttonDeleteCourse.Enabled = false;
            }
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            textBox2_SubjectCode.Focus();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            clearField();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            TeacherForm newform = new TeacherForm();
            this.Hide();
            newform.ShowDialog();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            SectionForm newform = new SectionForm();
            this.Hide();
            newform.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            RoomForm newform = new RoomForm();
            this.Hide();
            newform.ShowDialog();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            CourseForm newform = new CourseForm();
            this.Hide();
            newform.ShowDialog();
        }

        private void textBox4_Units_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_Units_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox4_Units_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    using (DataTable dt = new DataTable("tblSubject"))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblSubject where course_code like @course_code or subject_code like @subject_code or subject_name like @subject_name", con))
                        {
                            if (textSearch.TextLength == 0)
                            {
                                displayInfo();
                            }
                            else
                            {
                                //guide: https://www.youtube.com/watch?v=FVaQdTpSbS0
                                cmd.Parameters.Add("course_code", string.Format("%{0}%", textSearch.Text));
                                cmd.Parameters.Add("subject_code", string.Format("%{0}%", textSearch.Text));
                                cmd.Parameters.Add("subject_name", string.Format("%{0}%", textSearch.Text));
                                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                                adapter.Fill(dt);
                                dataGridView1.DataSource = dt;
                                //clearField();
                                //dataGridView1.ClearSelection();
                                con.Close();
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            if (textSearch.TextLength == 0)
            {
                dataGridView1.ClearSelection();
            }
        }
    }
}
