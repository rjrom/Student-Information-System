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
    public partial class StudentInfo : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        string connectionString = @"Data Source=DESKTOP-UG8SN2H\SQLEXPRESS; Initial Catalog = testsql2; Integrated Security = True;";
        SqlDataAdapter da;
        int indexRow;
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

        public StudentInfo()
        {
            InitializeComponent();
            displayInfo();
            randomID();
            
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
        }

        private void StudentInfo_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("Select Student_ID from tableStudent where Student_ID='" + textBox1_StudentNumber.Text + "' ", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if(dt.Rows.Count >= 1)
                    {
                        MessageBox.Show("Student data already exist.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (textBox2_LastName.TextLength == 0 || textBox3_FirstName.TextLength == 0 || textBox4_MiddleInitial.TextLength == 0
                        || textBox5_ContactNumber.TextLength == 0 || textBox6_Address.TextLength == 0 || comboBox1_Course.SelectedIndex == -1 
                        || comboBox2_YearLevel.SelectedIndex == -1 || comboBox3_SchoolYear.SelectedIndex == -1 || comboBox4_Term.SelectedIndex == -1)
                    {
                        MessageBox.Show("Fill all the empty fields first.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else
                    {
                        using (var cmd = new SqlCommand("INSERT INTO tableStudent (Student_ID, LastName, FirstName, MiddleInitial, Contact_Number, Address, BirthDate, Course, Year_Level, School_Year, Term) VALUES (@Student_ID, @LastName, @FirstName, @MiddleInitial, @Contact_Number, @Address, @BirthDate, @Course, @Year_Level, @School_Year, @Term)"))
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
        }

        private void textBox_StudentNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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
                comboBox3_SchoolYear.Text = row.Cells[9].Value.ToString();
                comboBox4_Term.Text = row.Cells[10].Value.ToString();
            }
            catch
            {

            }
            
        }

        bool totoo = true;
        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox2_LastName.TextLength == 0 || textBox3_FirstName.TextLength == 0 || textBox4_MiddleInitial.TextLength == 0
                        || textBox5_ContactNumber.TextLength == 0 || textBox6_Address.TextLength == 0 || comboBox1_Course.SelectedIndex == -1
                        || comboBox2_YearLevel.SelectedIndex == -1 || comboBox3_SchoolYear.SelectedIndex == -1 || comboBox4_Term.SelectedIndex == -1)
                {
                    MessageBox.Show("Fill all the empty fields first.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update tableStudent set Student_ID = @Student_ID, LastName = @LastName, FirstName = @FirstName, MiddleInitial = @MiddleInitial, Contact_Number = @Contact_Number, Address = @Address, Birthdate = @BirthDate, Course = @Course, Year_Level = @Year_Level, School_Year = @School_Year, Term = @Term where Student_ID = @Student_ID", con);
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
                    cmd.ExecuteNonQuery();
                    displayInfo();
                    clearField();
                    randomID();
                    con.Close();
                    MessageBox.Show("Successfully Changed.");
                }
            }
            catch(Exception ex)
            {

                MessageBox.Show("Error during update " + ex.Message);
            }
            
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {

        }

        private void iconButton5_Click(object sender, EventArgs e)
        {

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {

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

        private void button1_Click_1(object sender, EventArgs e)
        {
           
            try
            {
                using(SqlConnection con = new SqlConnection(connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                        
                    using(DataTable dt = new DataTable("tableStudent"))
                    {
                        using(SqlCommand cmd = new SqlCommand("SELECT * FROM tableStudent where Student_ID like @Student_ID or LastName like @LastName or FirstName like @FirstName or Course like @Course", con))
                        {
                            if(textSearch.TextLength == 0)
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
                                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                                adapter.Fill(dt);
                                dataGridView1.DataSource = dt;
                                con.Close();
                            }
                            

                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void textSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)13)
            {
                Search.PerformClick();
            }
        }

        private void textBox3_FirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_2(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_YearLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_Term_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_Address_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_MiddleInitial_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void iconButton6_Click(object sender, EventArgs e)
        {

        }
    }
}
