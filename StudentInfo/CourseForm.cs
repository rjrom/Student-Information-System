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
    public partial class CourseForm : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        string connectionString = @"Data Source=DESKTOP-UG8SN2H\SQLEXPRESS; Initial Catalog = testsql2; Integrated Security = True;";
        SqlDataAdapter da;
        int indexRow;
        public CourseForm()
        {
            InitializeComponent();
            displayInfo();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public void displayInfo()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM tblCourse", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }

        void clearField()
        {
            txtCourseCode.Clear();
            txtCourseDescription.Clear();
            textSearch.Clear();
            dataGridView1.ClearSelection();
            txtCourseCode.Focus();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("Select Course_Code from tblCourse where Course_Code='" + txtCourseCode.Text + "' ", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        MessageBox.Show("Course already exist.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (txtCourseCode.TextLength == 0 || txtCourseDescription.TextLength == 0)
                    {
                        MessageBox.Show("Fill all the empty fields first.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else
                    {
                        using (var cmd = new SqlCommand("INSERT INTO tblCourse (Course_Code, Course_Description) VALUES (@Course_Code, @Course_Description)"))
                        {

                            cmd.Connection = con;
                            //@Student_ID, @LastName, @FirstName, @MiddleInitial, @Contact_Number, @Address, @BirthDate, @Course, @Year_Level, @School_Year, @Term
                            cmd.Parameters.Add("@Course_Code", txtCourseCode.Text);
                            cmd.Parameters.Add("@Course_Description", txtCourseDescription.Text);

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
                    MessageBox.Show("Error during insert: " + ex.Message);
                }
            }
            dataGridView1.ClearSelection();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete tblCourse where Course_Code = @Course_Code", con);
                cmd.Parameters.Add("@Course_Code", txtCourseCode.Text);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                indexRow = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[indexRow];
                txtCourseCode.Text = row.Cells[0].Value.ToString();
                txtCourseDescription.Text = row.Cells[1].Value.ToString();
            }
            catch
            {

            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            clearField();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtCourseCode.TextLength == 0 || txtCourseDescription.TextLength == 0)
                {
                    MessageBox.Show("Fill all the empty fields first.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update tblCourse set Course_Code = @Course_Code, Course_Description = @Course_Description where Course_Code = @Course_Code", con);
                    cmd.Parameters.Add("@Course_Code", txtCourseCode.Text);
                    cmd.Parameters.Add("@Course_Description", txtCourseDescription.Text);
                    cmd.ExecuteNonQuery();
                    displayInfo();
                    clearField();
                    con.Close();
                    dataGridView1.ClearSelection();
                    MessageBox.Show("Successfully Changed.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error during update " + ex.Message);
            }
        }

        private void txtCourseDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            TeacherForm newform = new TeacherForm();
            this.Hide();
            newform.ShowDialog();
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            SubjectForm newform = new SubjectForm();
            this.Hide();
            newform.ShowDialog();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Form2 newform = new Form2();
            this.Hide();
            newform.ShowDialog();
        }

        private void iconButton3_Click_1(object sender, EventArgs e)
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

        private void iconButton7_Click_1(object sender, EventArgs e)
        {
            SubjectForm newform = new SubjectForm();
            this.Hide();
            newform.ShowDialog();
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {
            //dataGridView1.Columns[0].Width = 100;
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                buttonUpdate.Enabled = true;
                buttonAdd.Enabled = false; //add button
                buttonDelete.Enabled = true; //delete button
            }
            else
            {
                buttonUpdate.Enabled = false;
                buttonAdd.Enabled = true; // add button
                buttonDelete.Enabled = false; //delete button
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

                    using (DataTable dt = new DataTable("tblCourse"))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblCourse where Course_Code like @Course_Code or Course_Description like @Course_Description", con))
                        {
                            if (textSearch.TextLength == 0)
                            {
                                displayInfo();
                            }
                            else
                            {
                                //guide: https://www.youtube.com/watch?v=FVaQdTpSbS0
                                cmd.Parameters.Add("Course_Code", string.Format("%{0}%", textSearch.Text));
                                cmd.Parameters.Add("Course_Description", string.Format("%{0}%", textSearch.Text));
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

                    using (DataTable dt = new DataTable("tblCourse"))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblCourse where Course_Code like @Course_Code or Course_Description like @Course_Description", con))
                        {
                            if (textSearch.TextLength == 0)
                            {
                                displayInfo();
                            }
                            else
                            {
                                //guide: https://www.youtube.com/watch?v=FVaQdTpSbS0
                                cmd.Parameters.Add("Course_Code", string.Format("%{0}%", textSearch.Text));
                                cmd.Parameters.Add("Course_Description", string.Format("%{0}%", textSearch.Text));
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
            if (textSearch.TextLength == 0)
            {
                dataGridView1.ClearSelection();
            }
        }

        private void textSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Search.PerformClick();
            }
        }
    }
}
