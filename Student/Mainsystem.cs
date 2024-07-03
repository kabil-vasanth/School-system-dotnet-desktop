using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student
{
    public partial class Mainsystem : Form
    {
        public Mainsystem()
        {
            InitializeComponent();
        }

        private void Studentdetails_Click(object sender, EventArgs e)
        {
            StudentDetails frm= new StudentDetails();
            frm.ShowDialog();
        }

        private void subdetails_Click(object sender, EventArgs e)
        {
            SubjectsDetails frm= new SubjectsDetails();
            frm.ShowDialog();
        }

        private void graderdetails_Click(object sender, EventArgs e)
        {
            GradeDetails frm= new GradeDetails();
            frm.ShowDialog();
        }

        private void styudentsubject_Click(object sender, EventArgs e)
        {
            StudentSubject frm= new StudentSubject();
            frm.ShowDialog();
        }

        private void gs_Click(object sender, EventArgs e)
        {
            Gradesubject frm= new Gradesubject();
            frm.ShowDialog();
        }
    }
}
