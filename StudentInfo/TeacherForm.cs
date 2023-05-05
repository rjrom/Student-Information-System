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
    public partial class TeacherForm : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        string connectionString = @"Data Source=DESKTOP-UG8SN2H\SQLEXPRESS; Initial Catalog = testsql2; Integrated Security = True;";
        SqlDataAdapter da;
        int indexRow;
        public TeacherForm()
        {
            InitializeComponent();
        }

        public void displayInfo()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM tableTeacher", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }

        void clearField()
        {
            textBox2_LastName.Clear();
            textBox3_FirstName.Clear();
            textBox4_MiddleInitial.Clear();
            textBox5_ContactNumber.Clear();
            textBox6_EmailAddress.Clear();
            comboBox1_Specialization.SelectedIndex = -1;
            dataGridView1.ClearSelection();
            textBox2_LastName.Focus();
            textBox1_TeacherID.Clear();
            textSearch.Clear();
        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            displayInfo();
            dataGridView1.ClearSelection();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    if (textBox2_LastName.TextLength == 0 || textBox3_FirstName.TextLength == 0 || textBox4_MiddleInitial.TextLength == 0 || textBox5_ContactNumber.TextLength == 0 || textBox6_EmailAddress.TextLength == 0 || comboBox1_Specialization.SelectedIndex == -1)
                    {
                        MessageBox.Show("Fill all the empty fields first.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        using (var cmd = new SqlCommand("INSERT INTO tableTeacher (LastName, FirstName, MiddleInitial, ContactNumber, EmailAddress, Specialization) VALUES (@LastName, @FirstName, @MiddleInitial, @ContactNumber, @EmailAddress, @Specialization)"))
                        {

                            cmd.Connection = con;
                            //@@LastName, @FirstName, @MiddleInitial, @ContactNumber, @EmailAddress, @Specializati
                            cmd.Parameters.Add("@LastName", textBox2_LastName.Text);
                            cmd.Parameters.Add("@FirstName", textBox3_FirstName.Text);
                            cmd.Parameters.Add("@MiddleInitial", textBox4_MiddleInitial.Text);
                            cmd.Parameters.Add("@ContactNumber", textBox5_ContactNumber.Text);
                            cmd.Parameters.Add("@EmailAddress", textBox6_EmailAddress.Text);
                            cmd.Parameters.Add("@Specialization", comboBox1_Specialization.GetItemText(comboBox1_Specialization.SelectedItem));

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
                buttonUpdate.Enabled = true;
                buttonAdd.Enabled = false; //add button
                buttonDelete.Enabled = true; //delete button
            }
            else
            {
                buttonUpdate.Enabled = false;
                buttonAdd.Enabled = true;
                buttonDelete.Enabled = false;
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //hideAddButton();


        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                indexRow = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[indexRow];
                textBox1_TeacherID.Text = row.Cells[0].Value.ToString();
                textBox2_LastName.Text = row.Cells[2].Value.ToString();
                textBox3_FirstName.Text = row.Cells[3].Value.ToString();
                textBox4_MiddleInitial.Text = row.Cells[4].Value.ToString();
                textBox5_ContactNumber.Text = row.Cells[5].Value.ToString();
                textBox6_EmailAddress.Text = row.Cells[6].Value.ToString();
                comboBox1_Specialization.Text = row.Cells[7].Value.ToString();
            }
            catch
            {

            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox2_LastName.TextLength == -1 || textBox3_FirstName.TextLength == -1 || textBox4_MiddleInitial.TextLength == -1 || textBox5_ContactNumber.TextLength == -1 || textBox6_EmailAddress.TextLength == -1)
                {
                    MessageBox.Show("Fill all the empty fields first.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update tableTeacher set LastName = @LastName, FirstName = @FirstName, MiddleInitial = @MiddleInitial, ContactNumber = @ContactNumber, EmailAddress = @EmailAddress, Specialization = @Specialization where Teacher_ID = @Teacher_ID", con);
                    cmd.Parameters.Add("Teacher_ID", textBox1_TeacherID.Text);
                    cmd.Parameters.Add("@LastName", textBox2_LastName.Text);
                    cmd.Parameters.Add("@Firstname", textBox3_FirstName.Text);
                    cmd.Parameters.Add("@MiddleInitial", textBox4_MiddleInitial.Text);
                    cmd.Parameters.Add("@ContactNumber", textBox5_ContactNumber.Text);
                    cmd.Parameters.Add("@EmailAddress", textBox6_EmailAddress.Text);
                    cmd.Parameters.Add("@Specialization", comboBox1_Specialization.Text);
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this teacher record?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete tableTeacher where teacher_id = @teacher_id", con);
                cmd.Parameters.Add("@teacher_id", int.Parse(textBox1_TeacherID.Text));
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            clearField();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            SectionForm newform = new SectionForm();
            this.Hide();
            newform.ShowDialog();
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            SubjectForm newform = new SubjectForm();
            this.Hide();
            newform.ShowDialog();
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

                    using (DataTable dt = new DataTable("tableTeacher"))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM TableTeacher where Teacher_ID like @Teacher_ID or FullName like @FullName or Specialization like @Specialization", con))
                        {
                            if (textSearch.TextLength == 0)
                            {
                                displayInfo();
                            }
                            else
                            {
                                //guide: https://www.youtube.com/watch?v=FVaQdTpSbS0
                                cmd.Parameters.Add("teacher_id", string.Format("%{0}%", textSearch.Text));
                                cmd.Parameters.Add("fullname", string.Format("%{0}%", textSearch.Text));
                                cmd.Parameters.Add("specialization", string.Format("%{0}%", textSearch.Text));
                                //cmd.Parameters.Add("Course", textSearch.Text);
                                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                                adapter.Fill(dt);
                                dataGridView1.DataSource = dt;
                                dataGridView1.ClearSelection();
                                //clearField();
                                con.Close();
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            if(textSearch.TextLength == 0)
            {
                dataGridView1.ClearSelection();
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

                    using (DataTable dt = new DataTable("tableTeacher"))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM TableTeacher where Teacher_ID like @Teacher_ID or FullName like @FullName or Specialization like @Specialization", con))
                        {
                            if (textSearch.TextLength == 0)
                            {
                                displayInfo();
                            }
                            else
                            {
                                //guide: https://www.youtube.com/watch?v=FVaQdTpSbS0
                                cmd.Parameters.Add("teacher_id", string.Format("%{0}%", textSearch.Text));
                                cmd.Parameters.Add("fullname", string.Format("%{0}%", textSearch.Text));
                                cmd.Parameters.Add("specialization", string.Format("%{0}%", textSearch.Text));
                                //cmd.Parameters.Add("Course", textSearch.Text);
                                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                                adapter.Fill(dt);
                                dataGridView1.DataSource = dt;
                                dataGridView1.ClearSelection();
                                //clearField();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox5_ContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
