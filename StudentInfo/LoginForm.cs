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
    public partial class LoginForm : Form
    {
        string connectionString = @"Data Source=DESKTOP-UG8SN2H\SQLEXPRESS; Initial Catalog = testsql2; Integrated Security = True;";
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            cn = new SqlConnection(connectionString);
            string query = "Select * from tblLogin where username = '" + txtUser.Text.Trim() + "'and password = '" + txtPW.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, cn);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                Form2 f = new Form2();
                this.Hide();
                f.Show();
            }
            else
            {
                MessageBox.Show("Wrong username or password.");
            }
        }
    }
}
