using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private MySqlConnection GetConnection()
        {
            string connectionString = Main.sourceDB;
            return new MySqlConnection(connectionString);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();

                if (txtAccess.Text == "1234") // 인증번호 일치할 시
                {
                    if (txtUsername.Text.Length >= 3 && txtUsername.Text.Length <= 8)
                    {
                        if (txtPassword.Text.Length >= 3 && txtPassword.Text.Length <= 8)
                        {
                            string query = "INSERT INTO Login (username, pass) VALUES (@username, @pass)";
                            using (MySqlCommand cmd = new MySqlCommand(query, connection))
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
