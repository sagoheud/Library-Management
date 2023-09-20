using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management.View
{
    public partial class IssueBooks : Form
    {
        public IssueBooks()
        {
            InitializeComponent();
        }

        private void IssueBooks_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Main.sourceDB;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd = new SqlCommand("Select bName from NewBook", con);
            SqlDataReader sdr = cmd.ExecuteReader();

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

                SqlConnection con = new SqlConnection();
                con.ConnectionString = Main.sourceDB;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Select * from NewStudent where stuEnroll = '" + eid+"'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                //------------------------------------------------------------------------------------
                // 얼마나 많은 책을 대여랄 수 있는지 계산하는 코드
                // 새로이 대여,반납에 대한 테이블 생성
                cmd.CommandText = "Select count(std_enroll) from IRBook where std_enroll = '"
                    + eid + "' and book_return_date is null";
                SqlDataAdapter da2 = new SqlDataAdapter(cmd);
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
                    MessageBox.Show("정보가 없습니다.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = Main.sourceDB;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    con.Open();
                    cmd.CommandText = "Insert into IRBook (std_enroll,std_name,std_depart,std_sem,std_contact,std_email,book_name,book_issue_date) values ('"
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
                MessageBox.Show("회원정보를 선택해주세요.", "No Infomation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
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
