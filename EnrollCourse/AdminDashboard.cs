using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnrollCourse
{
    public partial class AdminDashboard : Form
    {
        string connectionstring = "Data Source=LAPTOP-M8OIGI02\\SQLEXPRESS;Initial Catalog=CourseEnrollment;Integrated Security=True";
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void btnLoginSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionstring);

            if(textBoxCourse.Text !="" && textBoxCredits.Text != "")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_COURSE", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@coursename", textBoxCourse.Text);
                    cmd.Parameters.AddWithValue("@credits", textBoxCredits.Text);
                    con.Open();
                    int numrec = cmd.ExecuteNonQuery();
                    if(numrec > 0)
                    {
                        MessageBox.Show("Success !!!","Saved");
                        
                    }
                    else
                    {
                        MessageBox.Show("Try again !!!", "Failed");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminControls ac = new AdminControls();
            ac.ShowDialog();
        }
    }
}
