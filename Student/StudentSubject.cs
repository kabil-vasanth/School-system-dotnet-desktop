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
    public partial class StudentSubject : Form
    {
        DataTable dt = new DataTable();
        DataView dv = new DataView();
        public StudentSubject()
        {
            InitializeComponent();
        }

        private void ssinsert_Click(object sender, EventArgs e)
        {
            {
                string connetionString = null;
                SqlConnection connection;
                SqlCommand command;
                string sql = null;
                connetionString = "Server=destok-11\\SQLEXPRESS;Database=KabilDB;Trusted_Connection=True;TrustServerCertificate=True";
                sql = "INSERT INTO studentsubjects (subject_id,admission_no) VALUES ('" + subjectid.Text + "','" + addno.Text + "');";
                connection = new SqlConnection(connetionString);
                try
                {
                    connection.Open();
                    command = new SqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();
                    MessageBox.Show("Save Sucessfully");
                    subjectid.Text = "";
                    addno.Text = "";



                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can not open connection ! ");
                }
            }
        }

        private void ssdelete_Click(object sender, EventArgs e)
        {
            {
                string id = dataGridView4.CurrentRow.Cells["id"].Value.ToString();
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
                string sql = "DELETE FROM studentsubjects WHERE id = '" + id + "'";
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
        }

        private void ssget_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            string connetionString = null;
            string sql = null;
            connetionString = "Server=destok-11\\SQLEXPRESS;Database=KabilDB;Trusted_Connection=True;TrustServerCertificate=True";
            SqlConnection cnn;
            cnn = new SqlConnection(connetionString);
            SqlCommand command;
            sql = "SELECT * FROM studentsubjects";
            try
            {


                cnn.Open();
                command = new SqlCommand(sql, cnn);
                SqlDataReader sqlReader = command.ExecuteReader();

                dt.Load(sqlReader);

                dv = dt.DefaultView;
                dataGridView4.DataSource = dv;


                sqlReader.Close();
                command.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + ex.Message);
            }
        }

        private void ssupdate_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(dataGridView4.CurrentRow.Cells["id"].Value.ToString());
            int suid = Convert.ToInt32(dataGridView4.CurrentRow.Cells["subject_id"].Value);
            int addn = Convert.ToInt32(dataGridView4.CurrentRow.Cells["admission_no"].Value);





            studentsubjectupdate frm = new studentsubjectupdate(id, suid, addn);
            frm.ShowDialog();

        }
    }   
}
