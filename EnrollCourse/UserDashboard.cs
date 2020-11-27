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
    public partial class UserDashboard : Form
    {
		string connectionstring = "Data Source=LAPTOP-M8OIGI02\\SQLEXPRESS;Initial Catalog=CourseEnrollment;Integrated Security=True";
		public UserDashboard()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
			

			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = dataGridViewcourses.Rows[e.RowIndex];
				textBoxUsername.Text = row.Cells[0].Value.ToString();
				textBoxPassword.Text = row.Cells[1].Value.ToString();
				textBoxcredits.Text = row.Cells[2].Value.ToString();
			}


		}

        private void UserDashboard_Load(object sender, EventArgs e)
        {
			label5.Text = username;
			label5.Visible = true;
			

			SqlCommand cmd = new SqlCommand();
			SqlDataAdapter da = new SqlDataAdapter();
			DataSet ds = new DataSet();

			SqlConnection con = new SqlConnection(connectionstring);
			con.Open();
			cmd.Connection = con;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "SP_SHOWCOURSES";
			da = new SqlDataAdapter(cmd);
			da.Fill(ds);
			con.Close();
			dataGridViewcourses.DataSource = ds.Tables[0];
		}

		int userid;
		string username;
		public void GetUserInfo(int id,string name)
        {
			userid = id;
			username = name;
        }

        private void label5_Click(object sender, EventArgs e)
        {
			
        }

        

        private void btnLoginSubmit_Click(object sender, EventArgs e)
        {
			
        }

        private void btnLoginSubmit_Click_1(object sender, EventArgs e)
        {
			SqlConnection con = new SqlConnection(connectionstring);
			try
			{
				DataTable dt = new DataTable();
				SqlCommand cmd = new SqlCommand("sp_enroll", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@courseid", textBoxUsername.Text.Trim().ToString());
				cmd.Parameters.AddWithValue("@userid", userid);
				con.Open();
				int cid = Convert.ToInt32(textBoxUsername.Text);
				string query = "select count(*) from enrollments where usrid = " + userid + " and crsid = " + cid + "";
				SqlCommand cmdd = new SqlCommand(query, con);
				SqlDataReader dr = cmdd.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						string val = dr.GetValue(0).ToString();
						if ( val == "0")
						{
							dr.Close();
							int numrec = cmd.ExecuteNonQuery();

							if (numrec > 0)
							{

								MessageBox.Show("Success !!!");
								break;

							}
							else
							{
								MessageBox.Show("Failed !!!");
								break;
							}
						}
						else
						{
							throw new Exception("Trying to enroll again !!! Failed");
						}
					}
				}

				

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

        private void button1_Click(object sender, EventArgs e)
        {
			SqlCommand cmd = new SqlCommand();
			SqlDataAdapter da = new SqlDataAdapter();
			DataSet ds = new DataSet();

			SqlConnection con = new SqlConnection(connectionstring);
			con.Open();
			cmd.Connection = con;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "SP_ENROLLEDCOURSES";
			cmd.Parameters.AddWithValue("@userid",userid);
			da = new SqlDataAdapter(cmd);
			da.Fill(ds);
			con.Close();
			dataGridViewcourses.DataSource = ds.Tables[0];
		}

        private void btnavailablecourses_Click(object sender, EventArgs e)
        {
			SqlCommand cmd = new SqlCommand();
			SqlDataAdapter da = new SqlDataAdapter();
			DataSet ds = new DataSet();

			SqlConnection con = new SqlConnection(connectionstring);
			con.Open();
			cmd.Connection = con;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "SP_SHOWCOURSES";
			da = new SqlDataAdapter(cmd);
			da.Fill(ds);
			con.Close();
			dataGridViewcourses.DataSource = ds.Tables[0];
		}

        private void button2_Click(object sender, EventArgs e)
        {
			

			this.Hide();
			var LoginAndRegister = new LoginAndRegister();
			LoginAndRegister.Closed += (s, args) => this.Close();
			LoginAndRegister.Show();
		}

        private void button3_Click(object sender, EventArgs e)
        {
			SqlConnection con = new SqlConnection(connectionstring);

			try
            {
			
				SqlCommand cmd = new SqlCommand("SP_Remove", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@courseid", textBoxUsername.Text.Trim().ToString());
				cmd.Parameters.AddWithValue("@userid",userid);
				con.Open();
				int nrows=cmd.ExecuteNonQuery();
				if(nrows == 1)
                {
					MessageBox.Show("Deleted Successfully");

                }
				else
                {
					MessageBox.Show("Something Went Wrong");
				}


            }
			catch(Exception ex)
            {
				MessageBox.Show(ex.Message);
            }
        }
    }
}
