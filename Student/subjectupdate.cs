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
    public partial class subjectupdate : Form
    {

        int id;
        string subname;
        int subindex;
        int subnumber;
        string suborder;
        
        public subjectupdate(int id,string subname,int subindex,int subnumber,string suborder)
        {
            InitializeComponent();
            this.id = id;
            this.subname = subname;
            this.subindex = subindex;
            this.subnumber = subnumber;
            this.suborder = suborder;


            sun.Text = this.subname;
            sui.Text = this.subindex.ToString();
            sunu.Text = this.subnumber.ToString();
            suo.Text = this.suborder;
        }

        private void subupdate_Click(object sender, EventArgs e)
        {
            string connetionString = null;

            string sql = null;
            SqlConnection connection;
            SqlCommand command;




            connetionString = "Server=destok-11\\SQLEXPRESS;Database=SchoolSystem;Trusted_Connection=True;TrustServerCertificate=True";
            sql = "UPDATE [subjectss] SET [subject_name]='" + sun.Text + "', [subject_index]='" + sui.Text + "', [subject_number]='" + sunu.Text + "', [subject_order]='" + suo.Text + "' WHERE [id]='" + this.id + "'";

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
