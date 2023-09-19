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

namespace Library_Management.Add
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtStuName.Clear();
            txtEnrollNo.Clear();
            txtDepart.Clear();
            txtSemester.Clear();
            txtContact.Clear();
            txtEmail.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtStuName.Text != "" && txtEnrollNo.Text != "" && txtDepart.Text != "" 
                && txtSemester.Text != "" && txtContact.Text != "")
            {
                String stuName = txtStuName.Text;
                String stuEnroll = txtEnrollNo.Text;
                String studepart = txtDepart.Text;
                String stuSem = txtSemester.Text;
                Int64 stuContact = Int64.Parse(txtContact.Text);
                String stuEmail = txtEmail.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = Main.sourceDB;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "Insert into NewStudent (stuName,stuEnroll,studepart,stuSem,stuContact,stuEmail) values ('"
                    + stuName + "','" + stuEnroll + "','" + studepart + "','" + stuSem + "'," + stuContact + ",'" + stuEmail +"')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("저장 완료", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStuName.Clear();
                txtEnrollNo.Clear();
                txtDepart.Clear();
                txtSemester.Clear();
                txtContact.Clear();
                txtEmail.Text = "";
            }
            else
            {
                MessageBox.Show("빈 칸을 채워주세요", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("저장되지 않은 데이터가 삭제됩니다.", "확실합니까?", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            Int64 res = 0;
            if (Int64.TryParse(txtContact.Text, out res))
            {
                if (txtContact.Text.Length > 10)
                {
                    txtContact.Text = txtContact.Text.Substring(0, 10);
                    txtContact.SelectionStart = txtContact.Text.Length;
                }
            }
            else
            {
                txtContact.Text = null;
            }
        }
    }
}
