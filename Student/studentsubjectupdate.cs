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
    public partial class studentsubjectupdate : Form
    {
        int id;
        int suid;
        int addn;
        public studentsubjectupdate(int id,int suid,int addn)
        {
            InitializeComponent();

            this.id = id;
            this.suid = suid;
            this.addn= addn;

            subjectid.Text = this.id.ToString();
            addno.Text=this.addn.ToString();

        }
      
        private void supdate_Click(object sender, EventArgs e)
        {

            string connetionString = null;

            string sql = null;
            SqlConnection connection;
            SqlCommand command;




            connetionString = "Server=destok-11\\SQLEXPRESS;Database=KabilDB;Trusted_Connection=True;TrustServerCertificate=True";
            sql = "UPDATE [studentsubjects] SET [subject_id]='" + subjectid.Text + "', [admission_no]='" + addno.Text + "' WHERE [id]='" + this.id + "'";

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
