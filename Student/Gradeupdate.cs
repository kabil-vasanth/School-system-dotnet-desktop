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
    public partial class Gradeupdate : Form
    {

        int id;
        string graname;
        string gragroup;
        int graorder;

        public Gradeupdate(int id,string graname, string gragroup, int graorder)
        {
            InitializeComponent();

            this.id = id;
            this.graname = graname;
            this.gragroup = gragroup;
            this.graorder = graorder;



            gn.Text = graname;
            gg.Text = gragroup;
            go.Text=Convert.ToString(graorder);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connetionString = null;

            string sql = null;
            SqlConnection connection;
            SqlCommand command;




            connetionString = "Server=destok-11\\SQLEXPRESS;Database=SchoolSystem;Trusted_Connection=True;TrustServerCertificate=True";
            sql = "UPDATE [grades] SET [grade_name]='" + gn.Text + "', [grade_group]='" + gg.Text + "', [grade_order]='" + go.Text + "' WHERE [id]='" + this.id + "'";

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
