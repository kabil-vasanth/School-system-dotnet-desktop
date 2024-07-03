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

namespace Student
{
    public partial class Gradesubject : Form
    {
        DataTable dt=new DataTable();
        DataView  dv=new DataView();
        public Gradesubject()
        {
            InitializeComponent();
        }

        private void gsinsert_Click(object sender, EventArgs e)
        {

            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;
            connetionString = "Server=destok-11\\SQLEXPRESS;Database=KabilDB;Trusted_Connection=True;TrustServerCertificate=True";
            sql = "INSERT INTO gradesubject (grade_id,subject_id) VALUES ('" + gi.Text + "','" + si.Text + "');";
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                MessageBox.Show("Save Sucessfully");
                si.Text = "";
                gi.Text = "";
               


            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
        }

        private void gsdelete_Click(object sender, EventArgs e)
        {
            string id = dataGridView5.CurrentRow.Cells["id"].Value.ToString();
            DialogResult D = MessageBox.Show("Do You Want to Delete?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (D == DialogResult.No)
            {
                return;
            }
            string connetionString = null;
            connetionString = "Server=destok-11\\SQLEXPRESS;Database=KabilDB;Trusted_Connection=True;TrustServerCertificate=True";
            SqlConnection cnn;
            cnn = new SqlConnection(connetionString);
            SqlCommand command;
            string sql = "DELETE FROM gradesubject WHERE id = '" + id + "'";
            try
            {
                cnn.Open();
                command = new SqlCommand(sql, cnn);
                command.ExecuteNonQuery();
                MessageBox.Show("Data Deleted Successfully");
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
        }

        private void gsget_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            string connetionString = null;
            string sql = null;
            connetionString = "Server=destok-11\\SQLEXPRESS;Database=KabilDB;Trusted_Connection=True;TrustServerCertificate=True";
            SqlConnection cnn;
            cnn = new SqlConnection(connetionString);
            SqlCommand command;
            sql = "SELECT * FROM gradesubject";
            try
            {


                cnn.Open();
                command = new SqlCommand(sql, cnn);
                SqlDataReader sqlReader = command.ExecuteReader();

                dt.Load(sqlReader);

                dv = dt.DefaultView;
                dataGridView5.DataSource = dv;


                sqlReader.Close();
                command.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + ex.Message);
            }
        }

        private void gsupdate_Click(object sender, EventArgs e)
        {

        }
    }
}
