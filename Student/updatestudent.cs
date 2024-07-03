using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student
{
    public partial class updatestudent : Form
    {

        int id;
        string admission;
        string firstname;
        string lastname;
        string fullname;
        string gender;
        string dop;
        string nic;
        string tp;
        string gid;
        string medium;
        string dateaddmision;
        string readdress;




        public updatestudent(int id,string admission, string firstname, string lastname, string fullname, string gender, string dop, string nic, string tp, string gid, string medium, string dateaddmision, string readdress)
        {
            InitializeComponent();
            this.id = id;
            this.admission = admission;
            this.firstname = firstname;
            this.lastname = lastname;
            this.fullname = fullname;
            this.gender = gender;
            this.dop = dop;
            this.nic = nic;
            this.tp = tp;
            this.gid = gid;
            this.medium = medium;
            this.dateaddmision = dateaddmision;
            this.readdress = readdress;



            san.Text = this.admission;
            sfn.Text = this.firstname;
            sln.Text = this.lastname;
            sfun.Text = this.fullname;
            sg.Text = this.gender;
            sdob.Text = this.dop;
            snic.Text = this.nic;
            stn.Text = this.tp;
            sgid.Text = this.gid;
            sm.Text = this.medium;
            sdoa.Text = this.dateaddmision;
            sra.Text = this.readdress;



        }

        
        private void update_Click(object sender, EventArgs e)
        {
            {
                string connetionString = null;
              
                string sql = null;
                SqlConnection connection;
                SqlCommand command;




                connetionString = "Server=destok-11\\SQLEXPRESS;Database=SchoolSystem;Trusted_Connection=True;TrustServerCertificate=True";
                sql = "UPDATE [students] SET [admission_no]='" + san.Text + "', [first_name]='" + sfn.Text + "', [last_name]='" + sln.Text + "', [full_name]='" + sfun.Text + "', [gender]='" + sg.Text + "' ,[date_of_birth]='" + DateTime.Parse(sdob.Text).ToString("yyyy-MM-dd") + "',[stu_nic_no]='" + snic.Text + "',[tp_no]='" + stn.Text + "',[grade_id]='" + sgid.Text + "',[medium]='" + sm.Text + "' ,[date_of_addmission]='" + DateTime.Parse(sdoa.Text).ToString("yyyy-MM-dd") + "' ,[resident_address]='" + sra.Text + "' WHERE [id]='" + this.id + "'";

                connection = new SqlConnection(connetionString);
                try
                {
                    connection.Open();
                    command = new SqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();
                    MessageBox.Show("Update Sucessfully");



                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can not open connection ! ");
                }
            }

        }
    }
}
   

