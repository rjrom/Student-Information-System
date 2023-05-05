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
namespace StudentInfo
{
    public partial class SectionForm : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        string connectionString = @"Data Source=DESKTOP-UG8SN2H\SQLEXPRESS; Initial Catalog = testsql2; Integrated Security = True;";
        SqlDataAdapter da;
        int indexRow;
        string sectioncode = "";
        string course = "";
        string year = "";
        string semester = "";
        string section = "";
        //string seccode = "";
        public SectionForm()
        {
            InitializeComponent();
            LoadCourse();
            PopulateSchoolYear();
            displayInfo();
        }

        private void LoadCourse()
        {
            //guide: https://www.youtube.com/watch?v=au-5buEKT_k
            string connectionString = @"Data Source=DESKTOP-UG8SN2H\SQLEXPRESS; Initial Catalog = testsql2; Integrated Security = True;";
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblCourse", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cboCourse.Items.Add(dt.Rows[i]["Course_Code"]);
            }
        }
        public void displayInfo()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM tableSection Order by Section_Code", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }
        void clearField()
        {
            txtSectionCode.Clear();
            cboCourse.SelectedIndex = -1;
            cboSchoolYear.SelectedIndex = -1;
            cboSemester.SelectedIndex = -1;
            cboYearLevel.SelectedIndex = -1;
            cboSection.SelectedIndex = -1;
            dataGridView1.ClearSelection();
            cboCourse.Focus();
            txtSectionCode.Clear();
            year = "";
            semester = "";
            section = "";
        }
        private void PopulateSchoolYear()
        {
            string connectionString = @"Data Source=DESKTOP-UG8SN2H\SQLEXPRESS; Initial Catalog = testsql2; Integrated Security = True;";
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tableCurriculum", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cboSchoolYear.Items.Add(dt.Rows[i]["curriculum_code"]);
            }
        }
        private void cboSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cboYearLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboYearLevel.Text == "First Year")
            {
                year = "1";
            }
            else if (cboYearLevel.Text == "Second Year")
            {
                year = "2";
            }
            else if (cboYearLevel.Text == "Third Year")
            {
                year = "3";
            }
            else if (cboYearLevel.Text == "Fourth Year")
            {
                year = "4";
            }
            txtSectionCode.Text = cboCourse.Text + year + "." + semester + section;
        }

        private void cboSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboSemester.Text == "First Sem")
            {
                semester = "1";
            }
            else if(cboSemester.Text == "Second Sem")
            {
                semester = "2";
            }
            txtSectionCode.Text = cboCourse.Text + year + "." + semester + section;
        }

        private void DeleteCourseButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this section?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete tableSection where section_code = @section_code", con);
                cmd.Parameters.Add("@section_code", txtSectionCode.Text);
                cmd.ExecuteNonQuery();
                displayInfo();
                clearField();
                con.Close();
                dataGridView1.ClearSelection();
                MessageBox.Show("Successfully deleted.");//do something
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ModifyCourseButton_Click(object sender, EventArgs e)
        {
            /*try
            {

                if (cboSchoolYear.SelectedIndex == -1 || cboCourse.SelectedIndex == -1 || cboSchoolYear.SelectedIndex == -1 || cboSemester.SelectedIndex == -1 || cboSection.SelectedIndex == -1)
                {
                    MessageBox.Show("Fill all the empty fields first.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update tableSection set Section_Code = @Section_Code, Curriculum_Code = @Curriculum_Code, Course_Code = @Course_code, Year_Level = @Year_Level, Semester = @Semester, Section = @Section where Section_Code = "+label3.Text +"", con);
                    cmd.Parameters.Add("@section_code", txtSectionCode.Text);
                    cmd.Parameters.Add("@curriculum_code", cboSchoolYear.Text);
                    cmd.Parameters.Add("@course_code", cboCourse.Text);
                    cmd.Parameters.Add("@year_level", cboYearLevel.Text);
                    cmd.Parameters.Add("@semester", cboSemester.Text);
                    cmd.Parameters.Add("@section", cboSection.Text);
                    cmd.ExecuteNonQuery();
                    displayInfo();
                    clearField();
                    //randomID();
                    con.Close();
                    dataGridView1.ClearSelection();
                    MessageBox.Show("Successfully Updated.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error during update " + ex.Message);
            }*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddCourseButton_Click(object sender, EventArgs e) //AddSection Button
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("Select section_code from tableSection where section_code='" + txtSectionCode.Text + "' ", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        MessageBox.Show("Section code already exist.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (txtSectionCode.TextLength == 0 || cboCourse.SelectedIndex == -1 || cboSchoolYear.SelectedIndex == -1 || cboSemester.SelectedIndex == -1 || cboYearLevel.SelectedIndex == -1 || cboSection.SelectedIndex == -1)
                    {
                        MessageBox.Show("Fill all the empty fields first.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        using (var cmd = new SqlCommand("INSERT INTO tableSection (Section_Code, Curriculum_Code, Course_Code, Year_Level, Semester, Section) VALUES (@Section_Code, @Curriculum_Code, @Course_Code, @Year_Level, @Semester, @Section)"))
                        {

                            cmd.Connection = con;
                            //@@LastName, @FirstName, @MiddleInitial, @ContactNumber, @EmailAddress, @Specializati
                            cmd.Parameters.Add("@Section_Code", txtSectionCode.Text);
                            cmd.Parameters.Add("@Course_Code", cboCourse.Text);
                            cmd.Parameters.Add("@Curriculum_Code", cboSchoolYear.Text);
                            cmd.Parameters.Add("@Year_Level", cboYearLevel.Text);
                            cmd.Parameters.Add("@Semester", cboSemester.Text);
                            cmd.Parameters.Add("@Section", cboSection.Text);
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
            dataGridView1.ClearSelection();
        }

        private void cboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSectionCode.Text = cboCourse.Text + year + "." + semester + section;
        }

        //comboboxSection
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSection.Text == "A")
            {
                section = "A";
            }
            else if (cboSection.Text == "B")
            {
                section = "B";
            }
            else if (cboSection.Text == "C")
            {
                section = "C";
            }
            else if (cboSection.Text == "D")
            {
                section = "D";
            }
            else if (cboSection.Text == "E")
            {
                section = "E";
            }
            txtSectionCode.Text = cboCourse.Text + year + "." + semester + section;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                indexRow = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[indexRow];
                txtSectionCode.Text = row.Cells[0].Value.ToString();
                cboSchoolYear.Text = row.Cells[1].Value.ToString();
                cboCourse.Text = row.Cells[2].Value.ToString();
                cboYearLevel.Text = row.Cells[3].Value.ToString();
                cboSemester.Text = row.Cells[4].Value.ToString();
                cboSection.Text = row.Cells[5].Value.ToString();
                label3.Text = row.Cells[0].Value.ToString();
            }
            catch
            {

            }
        }

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

        private void iconButton3_Click(object sender, EventArgs e)
        {
            TeacherForm newform = new TeacherForm();
            this.Hide();
            newform.ShowDialog();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            ScheduleForm newform = new ScheduleForm();
            this.Hide();
            newform.ShowDialog();
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            RoomForm newform = new RoomForm();
            this.Hide();
            newform.ShowDialog();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            SubjectForm newform = new SubjectForm();
            this.Hide();
            newform.ShowDialog();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            clearField();
        }

        private void SectionForm_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                //buttonUpdate.Enabled = true;
                btnAdd.Enabled = false; //add button
                btnDelete.Enabled = true; //delete button
            }
            else
            {
                //buttonUpdate.Enabled = false;
                btnAdd.Enabled = true; // add button
                btnDelete.Enabled = false; //delete button
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {

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

                    using (DataTable dt = new DataTable("tableSection"))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM tableSection where section_code like @section_code or course_code like @course_code", con))
                        {
                            if (textSearch.TextLength == 0)
                            {
                                displayInfo();
                            }
                            else
                            {
                                //guide: https://www.youtube.com/watch?v=FVaQdTpSbS0
                                cmd.Parameters.Add("@section_code", textSearch.Text);
                                cmd.Parameters.Add("@course_code",textSearch.Text);
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
