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
    public partial class Register : Form
    {
        string connectionstring = "Data Source=LAPTOP-M8OIGI02\\SQLEXPRESS;Initial Catalog=CourseEnrollment;Integrated Security=True";
        public Register()
        {
            InitializeComponent();
        }

        private void btnLoginSubmit_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(connectionstring);
            try
            {


                con.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("SP_REG", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@actiontype", "REGISTER");

                cmd.Parameters.AddWithValue("@username", textBoxUsername.Text.Trim().ToString());
                cmd.Parameters.AddWithValue("@password", textBoxPassword.Text.Trim().ToString());
                cmd.Parameters.AddWithValue("@email", textBoxEmail.Text.Trim().ToString());

                if (textBoxPassword.Text == "" || textBoxConfPassword.Text == "")
                {
                    MessageBox.Show("Enter correct Password !!!", "Password Error");
                    textBoxPassword.Focus();
                    return;
                }
                else if (textBoxPassword.Text != textBoxConfPassword.Text)
                {
                    MessageBox.Show("Enter correct Password !!!", "Password Error");
                    textBoxConfPassword.Focus();
                    return;
                }
                int numrec = cmd.ExecuteNonQuery();
                if (numrec > 0)
                {
                    MessageBox.Show("Success !!!");
                }
                else
                {
                    MessageBox.Show("Failure !!!");
                }
                con.Close();
                clear();

                LoginAndRegister log = new LoginAndRegister();
                log.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            


        }


        void clear()
        {
            textBoxUsername.Text = textBoxPassword.Text = textBoxConfPassword.Text = textBoxEmail.Text = "";
        }

        private void Register_Load(object sender, EventArgs e)
        {
            textBoxPassword.Text = "";
            textBoxPassword.PasswordChar = '*';

            textBoxConfPassword.Text = "";
            textBoxConfPassword.PasswordChar = '*';

        }
    }

    
}
