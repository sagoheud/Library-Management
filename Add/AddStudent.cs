using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Library_Management.Add
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private MySqlConnection GetConnection()
        {
            string connectionString = Main.sourceDB;
            return new MySqlConnection(connectionString);
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
                string stuName = txtStuName.Text;
                string stuEnroll = txtEnrollNo.Text;
                string studepart = txtDepart.Text;
                string stuSem = txtSemester.Text;
                Int64 stuContact = Int64.Parse(txtContact.Text);
                string stuEmail = txtEmail.Text;

                using (MySqlConnection con = GetConnection())
                {
                    con.Open();
                    string query = "INSERT INTO NewStudent (stuName, stuEnroll, studepart, stuSem, stuContact, stuEmail) " +
                        "VALUES (@stuName, @stuEnroll, @studepart, @stuSem, @stuContact, @stuEmail)";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@stuName", stuName);
                        cmd.Parameters.AddWithValue("@stuEnroll", stuEnroll);
                        cmd.Parameters.AddWithValue("@studepart", studepart);
                        cmd.Parameters.AddWithValue("@stuSem", stuSem);
                        cmd.Parameters.AddWithValue("@stuContact", stuContact);
                        cmd.Parameters.AddWithValue("@stuEmail", stuEmail);

                        cmd.ExecuteNonQuery();
                    }
                }

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
