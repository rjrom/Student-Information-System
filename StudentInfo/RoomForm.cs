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
    public partial class RoomForm : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        string connectionString = @"Data Source=DESKTOP-UG8SN2H\SQLEXPRESS; Initial Catalog = testsql2; Integrated Security = True;";
        SqlDataAdapter da;
        SqlDataReader dr;
        int indexRow;
        public RoomForm()
        {
            InitializeComponent();
            displayInfo();
        }

        public void displayInfo()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Room FROM tableRooms oRDER BY ROOM ASC", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }

        void clearField()
        {
            textBox_Room.Clear();
            dataGridView1.ClearSelection();
        }

        private void RoomForm_Load(object sender, EventArgs e)
        {
            displayInfo();
            dataGridView1.ClearSelection();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                indexRow = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[indexRow];
                textBox_Room.Text = row.Cells[1].Value.ToString();
            }
            catch
            {

            }

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("Select room from tablerooms where room='" + textBox_Room.Text + "' ", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        MessageBox.Show("Room is already existing.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (textBox_Room.TextLength == 0)
                    {
                        MessageBox.Show("You didn't input anything.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        using (var cmd = new SqlCommand("INSERT INTO tableRooms (Room) VALUES (@Room)"))
                        {

                            cmd.Connection = con;
                            cmd.Parameters.Add("@Room", textBox_Room.Text);

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

        private void textBox_Room_TextChanged(object sender, EventArgs e)
        {

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

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Room.TextLength == -1)
                {
                    MessageBox.Show("You must fill all the textbox first before you can modify a course.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update tableRooms set room = @room where room = @room", con);
                    cmd.Parameters.Add("@room", textBox_Room.Text);
                    cmd.ExecuteNonQuery();
                    displayInfo();
                    clearField();
                    con.Close();
                    MessageBox.Show("Successfully Changed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this room?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete tableRooms where room = @room", con);
                cmd.Parameters.Add("@room", textBox_Room.Text);
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

        private void dataGridView1_CellBorderStyleChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                indexRow = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[indexRow];
                textBox_Room.Text = row.Cells[0].Value.ToString();
            }
            catch
            {

            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            clearField();
        }
    }
}
