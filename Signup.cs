using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Library_Management
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        public int id = 0;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string conString = Main.sourceDB;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                if (txtAccess.Text == "147258") // 인증번호 일치할 시
                {
                    if (txtUsername.Text.Length >= 3 && txtUsername.Text.Length <= 8)
                    {
                        if (txtPassword.Text.Length >= 3 && txtPassword.Text.Length <= 8)
                        {
                            string qry = "Insert into Login (username, pass) Values(@username, @pass)";
                            using (SqlCommand cmd = new SqlCommand(qry, connection))
                            {
                                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                                cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("가입 성공", "RMS", MessageBoxButtons.OK, MessageBoxIcon.None);
                            txtUsername.Text = "";
                            txtPassword.Text = "";
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("비밀번호를 3~8글자로 입력해 주세요", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("아이디를 3~8글자로 입력해 주세요", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("인증번호가 틀립니다.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
