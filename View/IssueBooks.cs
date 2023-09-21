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


        private void IssueBooks_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = Main.sourceDB;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd = new MySqlCommand("SELECT bName FROM NewBook", con);
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
                }
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (txtStuName.Text != "")
            {
                if (cbBookName.SelectedIndex != -1 && count <= 2)
                {
                    String std_enroll = txtSearch.Text;
                    String std_name = txtStuName.Text;
                    String std_depart = txtDepart.Text;
                    String std_sem = txtSemester.Text;
                    Int64 std_contact = Int64.Parse(txtContact.Text);
                    String std_email = txtEmail.Text;
                    String book_name = cbBookName.Text;
                    String book_issue_date = txtIssueDate.Text;

                    MySqlConnection con = new MySqlConnection();
                    con.ConnectionString = Main.sourceDB;
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;

                    con.Open();
                    cmd.CommandText = "INSERT INTO IRBook (std_enroll,std_name,std_depart,std_sem,std_contact,std_email,book_name,book_issue_date) VALUES ('"
                        + std_enroll + "','" + std_name + "','" + std_depart + "','" + std_sem + "'," + std_contact + ",'" + std_email + "','"
                        + book_name + "','" + book_issue_date + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("책이 대여되었습니다.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("대여할 책을 선택하시거나,\n대여 가능한 개수를 초과중입니다.", "No Issue", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("회원정보를 선택해주세요.", "No Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
