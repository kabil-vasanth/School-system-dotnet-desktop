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
    public partial class GradeDetails : Form
    {
        DataTable dt=new DataTable();
        DataView dv = new DataView();
        public GradeDetails()
        {
            InitializeComponent();
        }

        private void gradeinsert_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;
            connetionString = "Server=destok-11\\SQLEXPRESS;Database=SchoolSystem;Trusted_Connection=True;TrustServerCertificate=True";
            sql = "INSERT INTO grades (grade_name,grade_group,grade_order) VALUES ('" + gn.Text + "','" + gg.Text + "','" + go.Text + "');";
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                MessageBox.Show("Save Sucessfully");
                gn.Text = "";
                gg.Text = "";
                go.Text = "";
                


            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
        }

        private void gradedelete_Click(object sender, EventArgs e)
        {
            string id = dataGridView3.CurrentRow.Cells["id"].Value.ToString();
            DialogResult D = MessageBox.Show("Do You Want to Delete?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (D == DialogResult.No)
            {
                return;
            }
            string connetionString = null;
            connetionString = "Server=destok-11\\SQLEXPRESS;Database=SchoolSystem;Trusted_Connection=True;TrustServerCertificate=True";
            SqlConnection cnn;
            cnn = new SqlConnection(connetionString);
            SqlCommand command;
            string sql = "DELETE FROM grades WHERE id = '" + id + "'";
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

        private void gradeget_Click(object sender, EventArgs e)
        {

            dt = new DataTable();
            string connetionString = null;
            string sql = null;
            connetionString = "Server=destok-11\\SQLEXPRESS;Database=SchoolSystem;Trusted_Connection=True;TrustServerCertificate=True";
            SqlConnection cnn;
            cnn = new SqlConnection(connetionString);
            SqlCommand command;
            sql = "SELECT * FROM grades";
            try
            {


                cnn.Open();
                command = new SqlCommand(sql, cnn);
                SqlDataReader sqlReader = command.ExecuteReader();

                dt.Load(sqlReader);

                dv = dt.DefaultView;
                dataGridView3.DataSource = dv;


                sqlReader.Close();
                command.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + ex.Message);
            }
        }

        private void gradeupdate_Click(object sender, EventArgs e)
        {
            {
                int id = Int32.Parse(dataGridView3.CurrentRow.Cells["id"].Value.ToString());
                string graname = dataGridView3.CurrentRow.Cells["grade_name"].Value.ToString();
                string gragroup = dataGridView3.CurrentRow.Cells["grade_group"].Value.ToString();
                int graorder = Convert.ToInt32(dataGridView3.CurrentRow.Cells["grade_order"].Value);
                





                Gradeupdate frm = new Gradeupdate(id, graname,gragroup,graorder);
                frm.ShowDialog();

            }
        }
    }
    }

