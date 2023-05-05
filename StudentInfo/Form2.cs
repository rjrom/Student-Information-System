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
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        string connectionString = @"Data Source=DESKTOP-UG8SN2H\SQLEXPRESS; Initial Catalog = testsql2; Integrated Security = True;";
        SqlDataAdapter da;
        SqlDataReader dr;
        int indexRow;
        public Form2()
        {
            InitializeComponent();
            displayInfo();
            randomID();
            PopulateComboBox();
            PopulateSchoolYear();
            
            //dataGridView1.ClearSelection();
            //hideButton();
        }
        public void displayInfo()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM tableStudent", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }
        void randomID()
        {
            Random random = new Random();
            int randomFirstID = random.Next(9);
            int randomSecondID = random.Next(9);
            int randomThirdID = random.Next(9);
            int randomFourthID = random.Next(9);
            int randomFifthID = random.Next(9);
            int randomSixthID = random.Next(9);
            String convertFirst = randomFirstID.ToString();
            String convertSecond = randomSecondID.ToString();
            String convertThird = randomThirdID.ToString();
            String convertFourth = randomFourthID.ToString();
            String convertFifth = randomFifthID.ToString();
            String convertSixth = randomSixthID.ToString();
            String randomizeID = "02000" + convertFirst + convertSecond + convertThird + convertFourth + convertFifth + convertSixth;
            textBox1_StudentNumber.Text = randomizeID;

        }
        void clearField()
        {
            textBox1_StudentNumber.Clear();
            textBox2_LastName.Clear();
            textBox3_FirstName.Clear();
            textBox4_MiddleInitial.Clear();
            textBox5_ContactNumber.Clear();
            textBox6_Address.Clear();
            comboBox1_Course.SelectedIndex = -1;
            comboBox2_YearLevel.SelectedIndex = -1;
            comboBox3_SchoolYear.SelectedIndex = -1;
            comboBox4_Term.SelectedIndex = -1;
            dataGridView1.ClearSelection();
            textBox2_LastName.Focus();
            textSearch.Clear();
        }

        public void LoadSection()
        {
            SqlConnection con = new SqlConnection(connectionString);
            comboBox5_Section.Items.Clear();
            con.Open();
            cmd = new SqlCommand("SELECT * FROM tableSection where course_code = @course_code and year_level = @year_level and semester = @semester", con);
            cmd.Parameters.AddWithValue("@course_code", comboBox1_Course.Text);
            cmd.Parameters.AddWithValue("@year_level", comboBox2_YearLevel.Text);
            cmd.Parameters.AddWithValue("@semester", comboBox4_Term.Text);
            //cmd.Parameters.AddWithValue("@semester", comboBox4_Term.Text);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox5_Section.Items.Add(dr["section_code"].ToString());
            }
            dr.Close();
            con.Close();
        }
        private void textBox5_ContactNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_Address_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_Course_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5_Section.Text = "";
            LoadSection();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            textBox2_LastName.Focus();
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

                    using (DataTable dt = new DataTable("tableStudent"))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM tableStudent where Student_ID like @Student_ID or LastName like @LastName or FirstName like @FirstName or Course like @Course or section like @section or school_year like @school_year", con))
                        {
                            if (textSearch.TextLength == 0)
                            {
                                displayInfo();
                            }
                            else
                            {
                                //guide: https://www.youtube.com/watch?v=FVaQdTpSbS0
                                cmd.Parameters.Add("Student_ID", string.Format("%{0}%", textSearch.Text));
                                cmd.Parameters.Add("LastName", string.Format("%{0}%", textSearch.Text));
                                cmd.Parameters.Add("FirstName", string.Format("%{0}%", textSearch.Text));
                                cmd.Parameters.Add("Course", textSearch.Text);
                                cmd.Parameters.Add("section", textSearch.Text);
                                cmd.Parameters.Add("school_year", textSearch.Text);
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

        private void PopulateSchoolYear()
        {
            string connectionString = @"Data Source=DESKTOP-UG8SN2H\SQLEXPRESS; Initial Catalog = testsql2; Integrated Security = True;";
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tableCurriculum", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox3_SchoolYear.Items.Add(dt.Rows[i]["curriculum_code"]);
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

                    using (DataTable dt = new DataTable("tableStudent"))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM tableStudent where Student_ID like @Student_ID or LastName like @LastName or FirstName like @FirstName or Course like @Course or section like @section or school_year like @school_year", con))
                        {
                            if (textSearch.TextLength == 0)
                            {
                                displayInfo();
                            }
                            else
                            {
                                //guide: https://www.youtube.com/watch?v=FVaQdTpSbS0
                                cmd.Parameters.Add("Student_ID", string.Format("%{0}%", textSearch.Text));
                                cmd.Parameters.Add("LastName", string.Format("%{0}%", textSearch.Text));
                                cmd.Parameters.Add("FirstName", string.Format("%{0}%", textSearch.Text));
                                cmd.Parameters.Add("Course", textSearch.Text);
                                cmd.Parameters.Add("section", textSearch.Text);
                                cmd.Parameters.Add("school_year", textSearch.Text);
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
            
        }
        private void textSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Search.PerformClick();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //hideAddButton();
        }

        private void textBox2_LastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("Select Student_ID from tableStudent where Student_ID='" + textBox1_StudentNumber.Text + "' ", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        MessageBox.Show("Student data already exist.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (textBox2_LastName.TextLength == 0 || textBox3_FirstName.TextLength == 0 || textBox4_MiddleInitial.TextLength == 0
                        || textBox5_ContactNumber.TextLength == 0 || textBox6_Address.TextLength == 0 || comboBox1_Course.SelectedIndex == -1
                        || comboBox2_YearLevel.SelectedIndex == -1 || comboBox4_Term.SelectedIndex == -1)
                    {
                        MessageBox.Show("Fill all the empty fields first.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (comboBox3_SchoolYear.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please select school year.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else
                    {
                        using (var cmd = new SqlCommand("INSERT INTO tableStudent (Student_ID, LastName, FirstName, MiddleInitial, Contact_Number, Address, BirthDate, Course, Year_Level, School_Year, Term, Section) VALUES (@Student_ID, @LastName, @FirstName, @MiddleInitial, @Contact_Number, @Address, @BirthDate, @Course, @Year_Level, @School_Year, @Term, @Section)"))
                        {

                            cmd.Connection = con;
                            //@Student_ID, @LastName, @FirstName, @MiddleInitial, @Contact_Number, @Address, @BirthDate, @Course, @Year_Level, @School_Year, @Term
                            cmd.Parameters.Add("@Student_ID", textBox1_StudentNumber.Text);
                            cmd.Parameters.Add("@LastName", textBox2_LastName.Text);
                            cmd.Parameters.Add("@FirstName", textBox3_FirstName.Text);
                            cmd.Parameters.Add("@MiddleInitial", textBox4_MiddleInitial.Text);
                            cmd.Parameters.Add("@Contact_Number", textBox5_ContactNumber.Text);
                            cmd.Parameters.Add("@Address", textBox6_Address.Text);
                            cmd.Parameters.Add("@BirthDate", dateTimePicker1.Text);
                            cmd.Parameters.Add("@Course", comboBox1_Course.GetItemText(comboBox1_Course.SelectedItem));
                            cmd.Parameters.Add("@Year_Level", comboBox2_YearLevel.GetItemText(comboBox2_YearLevel.SelectedItem));
                            cmd.Parameters.Add("@School_Year", comboBox3_SchoolYear.GetItemText(comboBox3_SchoolYear.SelectedItem));
                            cmd.Parameters.Add("@Term", comboBox4_Term.GetItemText(comboBox4_Term.SelectedItem));
                            cmd.Parameters.Add("@Section", comboBox5_Section.GetItemText(comboBox5_Section.SelectedItem));



                            con.Open();
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("Record inserted");
                                displayInfo();
                                clearField();
                                randomID();
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

        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (textBox2_LastName.TextLength == 0 || textBox3_FirstName.TextLength == 0 || textBox4_MiddleInitial.TextLength == 0
                        || textBox5_ContactNumber.TextLength == 0 || textBox6_Address.TextLength == 0 || comboBox1_Course.SelectedIndex == -1
                        || comboBox2_YearLevel.SelectedIndex == -1 || comboBox3_SchoolYear.SelectedIndex == -1 || comboBox4_Term.SelectedIndex == -1 || comboBox5_Section.SelectedIndex == -1)
                {
                    MessageBox.Show("Fill all the empty fields first.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update tableStudent set Student_ID = @Student_ID, LastName = @LastName, FirstName = @FirstName, MiddleInitial = @MiddleInitial, Contact_Number = @Contact_Number, Address = @Address, Birthdate = @BirthDate, Course = @Course, Year_Level = @Year_Level, School_Year = @School_Year, Term = @Term, Section = @Section where Student_ID = @Student_ID", con);
                    cmd.Parameters.Add("@Student_ID", textBox1_StudentNumber.Text);
                    cmd.Parameters.Add("@LastName", textBox2_LastName.Text);
                    cmd.Parameters.Add("@FirstName", textBox3_FirstName.Text);
                    cmd.Parameters.Add("@MiddleInitial", textBox4_MiddleInitial.Text);
                    cmd.Parameters.Add("@Contact_Number", textBox5_ContactNumber.Text);
                    cmd.Parameters.Add("@Address", textBox6_Address.Text);
                    cmd.Parameters.Add("@BirthDate", dateTimePicker1.Text);
                    cmd.Parameters.Add("@Course", comboBox1_Course.GetItemText(comboBox1_Course.SelectedItem));
                    cmd.Parameters.Add("@Year_Level", comboBox2_YearLevel.GetItemText(comboBox2_YearLevel.SelectedItem));
                    cmd.Parameters.Add("@School_Year", comboBox3_SchoolYear.GetItemText(comboBox3_SchoolYear.SelectedItem));
                    cmd.Parameters.Add("@Term", comboBox4_Term.GetItemText(comboBox4_Term.SelectedItem));
                    cmd.Parameters.Add("@Section", comboBox5_Section.GetItemText(comboBox5_Section.SelectedItem));
                    cmd.ExecuteNonQuery();
                    displayInfo();
                    clearField();
                    randomID();
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

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete tableStudent where Student_ID = @Student_ID", con);
                cmd.Parameters.Add("@Student_ID", int.Parse(textBox1_StudentNumber.Text));
                cmd.ExecuteNonQuery();
                displayInfo();
                clearField();
                randomID();
                con.Close();
                dataGridView1.ClearSelection();
                MessageBox.Show("Successfully deleted.");//do something
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            clearField();
            randomID();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //hideAddButton();
            try
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

            }
            
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            CourseForm newform = new CourseForm();
            this.Hide();
            newform.ShowDialog();
        }

        

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Update.Enabled = true;
                button2.Visible = false; //add button
                button3.Enabled = true; //delete button
            }
            else
            {
                Update.Enabled = false;
                button2.Visible = true;
                button2.Enabled = true;
                button3.Enabled = false;
            }
            //hideButton();
            /*if (dataGridView1.SelectedRows != null)
            {
                Update.Enabled = false;
            }
            else if(dataGridView1.SelectedRows.Count > 0)
            {
                Update.Enabled = true;
            }
            /*if (this.dataGridView1.SelectedRows.Count > 0)
            {
                //Update.Enabled = true;
                button2.Enabled = false;
            }
            else
            {
                //Update.Enabled = false;
                button2.Enabled = true;
            }*/


        }

        void hideButton()
        {
            bool totoo = true;
            if(dataGridView1.SelectedCells.Count > 0)
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hideButton();
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

        private void comboBox2_YearLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5_Section.Text = "";
            LoadSection();
        }

        private void comboBox4_Term_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5_Section.Text = "";
            LoadSection();
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            RoomForm newform = new RoomForm();
            this.Hide();
            newform.ShowDialog();
        }

        private void textBox5_ContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void comboBox1_Course_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}
