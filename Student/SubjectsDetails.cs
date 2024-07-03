using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student
{
    public partial class SubjectsDetails : Form


    {
        DataTable dt=new DataTable();
        DataView dv=new DataView();
        public SubjectsDetails()
        {
            InitializeComponent();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            {
                string connetionString = null;
                SqlConnection connection;
                SqlCommand command;
                string sql = null;
                connetionString = "Server=destok-11\\SQLEXPRESS;Database=SchoolSystem;Trusted_Connection=True;TrustServerCertificate=True";
                sql = "INSERT INTO subjectss (subject_name,subject_index,subject_number,subject_order) VALUES ('" + sun.Text + "','" + sui.Text + "','" + sunu.Text + "','" + suo.Text + "');";
                connection = new SqlConnection(connetionString);
                try
                {
                    connection.Open();
                    command = new SqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();
                    MessageBox.Show("Save Sucessfully");
                    sun.Text = "";
                    sui.Text = "";
                    sunu.Text = "";
                    suo.Text = "";


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can not open connection ! ");
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            {
                string id = dataGridView2.CurrentRow.Cells["id"].Value.ToString();
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
                string sql = "DELETE FROM subjectss WHERE id = '" + id + "'";
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

        private void get_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            string connetionString = null;
            string sql = null;
            connetionString = "Server=destok-11\\SQLEXPRESS;Database=SchoolSystem;Trusted_Connection=True;TrustServerCertificate=True";
            SqlConnection cnn;
            cnn = new SqlConnection(connetionString);
            SqlCommand command;
            sql = "SELECT * FROM subjectss";
            try
            {


                cnn.Open();
                command = new SqlCommand(sql, cnn);
                SqlDataReader sqlReader = command.ExecuteReader();

                dt.Load(sqlReader);

                dv = dt.DefaultView;
                dataGridView2.DataSource = dv;


                sqlReader.Close();
                command.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + ex.Message);
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            
            {
                int id = Int32.Parse(dataGridView2.CurrentRow.Cells["id"].Value.ToString());
                string subname = dataGridView2.CurrentRow.Cells["subject_name"].Value.ToString();
                int subindex = Convert.ToInt32(dataGridView2.CurrentRow.Cells["subject_index"].Value);
                int subnumber = Convert.ToInt32(dataGridView2.CurrentRow.Cells["subject_number"].Value);
                string suborder = dataGridView2.CurrentRow.Cells["subject_order"].Value.ToString();





                subjectupdate frm = new subjectupdate(id, subname, subindex, subnumber, suborder);
                frm.ShowDialog();

            }
        }
    }
}