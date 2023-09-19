using Library_Management.Add;
using Library_Management.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("종료하시겠습니까?","Confirm",
                MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnBookAdd_Click(object sender, EventArgs e)
        {
            AddBooks ab = new AddBooks(); 
            ab.Show();
        }

        private void btnBookView_Click(object sender, EventArgs e)
        {
            ViewBooks vb = new ViewBooks();
            vb.Show();
        }

        private void btnStudentAdd_Click(object sender, EventArgs e)
        {
            AddStudent ast = new AddStudent();
            ast.Show();
        }

        private void btnStudentView_Click(object sender, EventArgs e)
        {
            ViewStudent vst = new ViewStudent();
            vst.Show();
        }
    }
}
