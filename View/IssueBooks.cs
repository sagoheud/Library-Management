using System;
using System.Data;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Library_Management.View
{
    public partial class IssueBooks : Form
    {

        public IssueBooks()
        {
            InitializeComponent();
            txtSearch.Text = Main.cardNum;
            txtSearch.Enabled = false;
            EventHandler e = new EventHandler(btnSearch_Click);

            // btnSearch_Click 이벤트 핸들러를 호출
            e.Invoke(this, EventArgs.Empty);
        }

        private MySqlConnection GetConnection()
        {
            string connectionString = Main.sourceDB;
            return new MySqlConnection(connectionString);
        }


        private void IssueBooks_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = Main.sourceDB;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd = new MySqlCommand("SELECT bName FROM NewBook Where bQty>0", con);
            MySqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    cbBookName.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
            con.Close();
        }

        int count;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                String eid = txtSearch.Text;

                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = Main.sourceDB;
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT * FROM NewStudent WHERE stuEnroll = '" + eid + "'";
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                //------------------------------------------------------------------------------------
                // 얼마나 많은 책을 대여할 수 있는지 계산하는 코드
                // 새로이 대여,반납에 대한 테이블 생성
                cmd.CommandText = "SELECT count(std_enroll) FROM IRBook WHERE std_enroll = '"
                    + eid + "' AND book_return_date IS NULL";
                MySqlDataAdapter da2 = new MySqlDataAdapter(cmd);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);

                count = int.Parse(ds2.Tables[0].Rows[0][0].ToString());
                //------------------------------------------------------------------------------------

                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtStuName.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtDepart.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtSemester.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtContact.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0][6].ToString();
                }
                else
                {
                    txtStuName.Clear();
                    txtDepart.Clear();
                    txtSemester.Clear();
                    txtContact.Clear();
                    txtEmail.Clear();
                    MessageBox.Show("정보가 없습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStuName.Text))
            {
                MessageBox.Show("회원정보를 선택해주세요.", "No Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbBookName.SelectedIndex == -1 || count > 2)
            {
                MessageBox.Show("대여할 책을 선택하시거나,\n대여 가능한 개수를 초과중입니다.", "No Issue", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string std_enroll = txtSearch.Text;
                string std_name = txtStuName.Text;
                string std_depart = txtDepart.Text;
                string std_sem = txtSemester.Text;
                long std_contact = long.Parse(txtContact.Text);
                string std_email = txtEmail.Text;
                string book_name = cbBookName.Text;
                string book_issue_date = txtIssueDate.Text;

                using (MySqlConnection con = new MySqlConnection(Main.sourceDB))
                {
                    con.Open();

                    string insertQuery = "INSERT INTO IRBook (std_enroll, std_name, std_depart, std_sem, std_contact, std_email, book_name, book_issue_date) " +
                        "VALUES (@std_enroll, @std_name, @std_depart, @std_sem, @std_contact, @std_email, @book_name, @book_issue_date)";

                    using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, con))
                    {
                        insertCommand.Parameters.AddWithValue("@std_enroll", std_enroll);
                        insertCommand.Parameters.AddWithValue("@std_name", std_name);
                        insertCommand.Parameters.AddWithValue("@std_depart", std_depart);
                        insertCommand.Parameters.AddWithValue("@std_sem", std_sem);
                        insertCommand.Parameters.AddWithValue("@std_contact", std_contact);
                        insertCommand.Parameters.AddWithValue("@std_email", std_email);
                        insertCommand.Parameters.AddWithValue("@book_name", book_name);
                        insertCommand.Parameters.AddWithValue("@book_issue_date", book_issue_date);

                        insertCommand.ExecuteNonQuery();
                    }

                    string updateQuery = "UPDATE NewBook SET bQty = (bQty - 1) WHERE bName = @book_name";

                    using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, con))
                    {
                        updateCommand.Parameters.AddWithValue("@book_name", book_name);
                        updateCommand.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("책이 대여되었습니다.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reset();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류가 발생했습니다: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "") // btnRefresh_Click 동작과 연동됨
            {
                txtStuName.Clear();
                txtDepart.Clear();
                txtSemester.Clear();
                txtContact.Clear();
                txtEmail.Clear();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reset()
        {
            using (MySqlConnection con = GetConnection())
            {
                con.Open();
                string query = "SELECT bName FROM NewBook Where bQty>0";
                using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    
                }
                con.Close();
            }
        }
    }
}
