using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private MySqlConnection GetConnection()
        {
            string connectionString = Main.sourceDB;
            return new MySqlConnection(connectionString);
        }

        private void txtUsername_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtUsername.Text == "사용자명")
            {
                txtUsername.Clear();
            }
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPassword.Text == "비밀번호")
            {
                txtPassword.Clear();
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picInstagram_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/");
        }

        private void picFacebook_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/");
        }

        private void picYoutube_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM Login WHERE username = @username AND pass = @password";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count != 0) // 로그인 성공 시
                        {
                            this.Hide();
                            Dashboard das = new Dashboard();
                            das.Show();
                        }
                        else // 아이디 또는 비밀번호가 틀릴 때
                        {
                            MessageBox.Show("아이디 또는 비밀번호가 틀립니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            Signup si = new Signup();
            si.Show();
        }
    }
}
