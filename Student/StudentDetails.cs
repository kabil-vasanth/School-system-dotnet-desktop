using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Student
{
    public partial class StudentDetails : Form



    {
        DataTable dt=new DataTable();
        DataView dv = new DataView();


       
      
        public StudentDetails()
        {
            InitializeComponent();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;
            connetionString = "Server=destok-11\\SQLEXPRESS;Database=SchoolSystem;Trusted_Connection=True;TrustServerCertificate=True";
            sql = "INSERT INTO students (admission_no,first_name, last_name,full_name,gender,date_of_birth,stu_nic_no,tp_no,grade_id,medium,date_of_addmission,resident_address) VALUES ('" + san.Text + "','" + sfn.Text + "','" + sln.Text + "','" + sfun.Text + "','" + sg.Text + "','" + DateTime.Parse(sdob.Text).ToString("yyyy-MM-dd") + "','" +snic.Text  + "','" + stn.Text + "','" + sgid.Text + "','" + sm.Text + "','" + DateTime.Parse(sdoa.Text).ToString("yyyy-MM-dd")  + "','" + sra.Text + "');";
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                MessageBox.Show("Save Sucessfully");
                san.Text = "";
                sfn.Text = "";
                sln.Text = "";
                sfun.Text = "";
                sg.Text ="";
                sdob.Text = "";
                snic.Text = "";
                stn.Text = "";
                sgid.Text = "";
                sm.Text = "";
                sdoa.Text = "";
                sra.Text = "";


            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
        }



        private void update_Click(object sender, EventArgs e)
        {

            int id = Int32.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
            string admission = dataGridView1.CurrentRow.Cells["admission_no"].Value.ToString();
            string firstname = dataGridView1.CurrentRow.Cells["first_name"].Value.ToString();
            string lastname = dataGridView1.CurrentRow.Cells["last_name"].Value.ToString(); ;
            string fullname = dataGridView1.CurrentRow.Cells["full_name"].Value.ToString(); ;
            string gender = dataGridView1.CurrentRow.Cells["gender"].Value.ToString(); ;
            string dop =dataGridView1.CurrentRow.Cells["date_of_birth"].Value.ToString(); ;
            string nic=dataGridView1.CurrentRow.Cells["stu_nic_no"].Value.ToString();
            string tp =dataGridView1.CurrentRow.Cells["tp_no"].Value.ToString();
            string gid = dataGridView1.CurrentRow.Cells["grade_id"].Value.ToString();
            string medium = dataGridView1.CurrentRow.Cells["medium"].Value.ToString(); ;
            string dateaddmision =dataGridView1.CurrentRow.Cells["date_of_addmission"].Value.ToString(); ;
            string readdress = dataGridView1.CurrentRow.Cells["resident_address"].Value.ToString(); ;


    




       




            updatestudent frm = new updatestudent(id,admission,firstname,lastname,fullname,gender,dop,nic,tp,gid,medium,dateaddmision,readdress);
            frm.ShowDialog();

        }

        private void Delete_Click(object sender, EventArgs e)
        {

            {
                string id = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                DialogResult D= MessageBox.Show("Do You Want to Delete?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (D == DialogResult.No)
                {
                    return;
                }
                string connetionString = null; 
                connetionString = "Server =destok-11\\SQLEXPRESS; Database=SchoolSystem; Trusted_Connection = True;";
                SqlConnection cnn;
                cnn = new SqlConnection(connetionString);
                SqlCommand command;
                string sql = "DELETE FROM students WHERE id = '" + id + "'";
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

        private void Get_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            string connetionString = null;
            string sql = null;
            connetionString = "Server =destok-11\\SQLEXPRESS; Database = SchoolSystem; Trusted_Connection = True;"; 
            SqlConnection cnn;
            cnn = new SqlConnection(connetionString);
            SqlCommand command;
            sql = "SELECT * FROM students";
            try
            {

             
                cnn.Open();
                command = new SqlCommand(sql, cnn);
                SqlDataReader sqlReader = command.ExecuteReader();

                dt.Load(sqlReader);

                dv = dt.DefaultView;
                dataGridView1.DataSource = dv;
            

                sqlReader.Close();
                command.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + ex.Message);
            }

        }
    }
}
