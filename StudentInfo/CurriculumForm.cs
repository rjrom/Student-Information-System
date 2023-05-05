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
    public partial class CurriculumForm : Form
    {
        string connectionString = @"Data Source=DESKTOP-UG8SN2H\SQLEXPRESS; Initial Catalog = testsql2; Integrated Security = True;";
        public CurriculumForm()
        {
            InitializeComponent();
            displayInfo();
        }

        public void displayInfo()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM tableCurriculum", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }
        void clearField()
        {
            cboCurriculum1.Text = "";
            txtCurriculum2.Clear();
            dataGridView1.ClearSelection();
            cboCurriculum1.Focus();
        }
        private void AddCourseButton_Click(object sender, EventArgs e)
        {
            string aycode = cboCurriculum1.Text + " - " + txtCurriculum2.Text;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    //SqlDataAdapter da = new SqlDataAdapter("Select curriculum_code from tableCurriculum where curriculum_code='" + cboCurriculum1.Text + "' ", con);
                    //DataTable dt = new DataTable();
                    //da.Fill(dt);
                    if (cboCurriculum1.SelectedIndex == -1)
                    {
                        MessageBox.Show("You didn't select a school year.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else
                    {
                        using (var cmd = new SqlCommand("INSERT INTO tableCurriculum (curriculum_code) VALUES (@curriculum_code)"))
                        {

                            cmd.Connection = con;
                            //@Student_ID, @LastName, @FirstName, @MiddleInitial, @Contact_Number, @Address, @BirthDate, @Course, @Year_Level, @School_Year, @Term
                            cmd.Parameters.Add("@curriculum_code", aycode);
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
                    //MessageBox.Show("Error during insert: " + ex.Message);
                    MessageBox.Show("Curriculum code already exists.");
                }
            }
            dataGridView1.ClearSelection();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboCurriculum1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                txtCurriculum2.Text = (long.Parse(cboCurriculum1.Text) + 1).ToString();
            }
            catch (Exception ex)
            {
                txtCurriculum2.Clear();
            }

            string aycode = cboCurriculum1.Text + " - " + txtCurriculum2.Text;
            //label4.Text = aycode;
        }

        private void cboCurriculum1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete tableStudent where Student_ID = @Student_ID", con);
                //cmd.Parameters.Add("@Student_ID", int.Parse(textBox1_StudentNumber.Text));
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
                //do something else
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*try 
            { 
                int indexRow;
                indexRow = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[indexRow];
                cboCurriculum1.Text = row.Cells[0].Value.ToString();
            }
            catch
            {

            }*/
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            CourseForm newform = new CourseForm();
            this.Hide();
            newform.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this curriculum?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete tablecurriculum where curriculum_code = @curriculum_code", con);
                cmd.Parameters.Add("@curriculum_code", txtCurriculum2.Text);
                cmd.ExecuteNonQuery();
                displayInfo();
                clearField();
                con.Close();
                dataGridView1.ClearSelection();
                MessageBox.Show("Successfully deleted.");//do something
            }
            else if (dialogResult == DialogResult.No)
            {
                //do somethi
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
