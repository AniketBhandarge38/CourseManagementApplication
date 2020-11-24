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
    public partial class LoginAndRegister : Form
    {
        string connectionstring = "Data Source=LAPTOP-M8OIGI02\\SQLEXPRESS;Initial Catalog=CourseEnrollment;Integrated Security=True";
        public LoginAndRegister()
        {
            InitializeComponent();
        }

        private void linkLabelRegistering_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register reg = new Register();
            reg.ShowDialog();
        }

        private void btnLoginSubmit_Click(object sender, EventArgs e)
        {

            string u = textBoxUsername.Text;
            string p = textBoxPassword.Text;
            if (u.Equals("Admin") && p.Equals("admin123"))
            {
                AdminDashboard ad = new AdminDashboard();
                ad.ShowDialog();
            }
            else
            {

                SqlConnection con = new SqlConnection(connectionstring);
                if (textBoxUsername.Text != "" && textBoxPassword.Text != "")
                    try
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }

                        using (SqlCommand cmd = new SqlCommand("sp_login", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@username", textBoxUsername.Text.Trim().ToString());
                            cmd.Parameters.AddWithValue("@password", textBoxPassword.Text.Trim().ToString());
                            cmd.Parameters.AddWithValue("@ActionType", "CHECK");


                           
                            using (SqlDataReader da = cmd.ExecuteReader())
                            {
                                if (da.HasRows)
                                {
                                    while (da.Read())
                                    {
                                        string eq = da.GetValue(0).ToString();
                                        if (eq == "1")
                                        {
                                            da.Close();
                                           
                                            string username = textBoxUsername.Text.Trim().ToString();
                                            string password = textBoxPassword.Text.Trim().ToString();
                                            string query = "SELECT userid FROM registry where username = '" +username +"' AND password = '"+@password+"'";
                                            SqlCommand cmdd = new SqlCommand(query, con);
                                            SqlDataAdapter daa = new SqlDataAdapter(cmdd);
                                            DataTable dt = new DataTable();
                                            daa.Fill(dt);
                                            if (dt.Rows.Count == 1)
                                            {
                                                
                                                int id = Convert.ToInt32(dt.Rows[0]["userid"].ToString());
                                                UserDashboard ud = new UserDashboard();
                                                ud.GetUserInfo(id, username);
                                                ud.ShowDialog();
                                                break;
                                            }


                                        }

                                        else
                                        {
                                            MessageBox.Show("Try again !!!", "Check Credentials");
                                        }
                                    }
                                }



                            }
                        }

                        con.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
            }
        }
    }
}
