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
    public partial class AdminControls : Form
    {
        string connectionstring = "Data Source=LAPTOP-M8OIGI02\\SQLEXPRESS;Initial Catalog=CourseEnrollment;Integrated Security=True";
        public AdminControls()
        {
            InitializeComponent();
        }

        private void AdminControls_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionstring);

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = con;
            DataSet ds = new DataSet();
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "SP_SHOWENROLLMENTS";
            
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
            dataGridViewCD.DataSource = ds.Tables[0];

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
            dataGridViewCD.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionstring);

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = con;
            DataSet ds = new DataSet();
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "SP_SHOWENROLLMENTS";

            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
            dataGridViewCD.DataSource = ds.Tables[0];
        }
    }
}
