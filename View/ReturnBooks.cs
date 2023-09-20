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
    public partial class ReturnBooks : Form
    {
        public ReturnBooks()
        {
            InitializeComponent();
        }

        private void ReturnBooks_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Main.sourceDB;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select * from IRBook where book_return_date IS NULL";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            for (int i = 3; i < 7; i++)
            {
                dataGridView1.Columns[i].Visible = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Main.sourceDB;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select * from IRBook where std_enroll = '" + txtSearch.Text + "' and book_return_date IS NULL";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
                // 열 내용 삭제 코드는 넣지 않아도 무방함
                dataGridView1.Columns[0].Visible = false; // 인덱스 열 제거
                for (int i = 3; i < 7; i++)
                {
                    dataGridView1.Columns[i].Visible = false; // 4번~7번 열 내용 제거
                }
            }
            else
            {
                MessageBox.Show("대여 내역이 없습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        Int64 rowid;
        String bname;
        String bdate;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                rowid = Int64.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                bname = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                bdate = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
            txtBookName.Text = bname;
            txtIssueDate.Text = bdate;
            txtSearch.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (txtBookName.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Main.sourceDB;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "Update IRBook set book_return_date = '" + txtReturnDate.Text +
                    "' where std_enroll = '" + txtSearch.Text + "' and id = " + rowid + "";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("책이 반납되었습니다.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReturnBooks_Load(sender, e);
                txtBookName.Clear();
                txtIssueDate.Clear();
                txtSearch.Clear();
            }
            else
            {
                MessageBox.Show("반납할 책을 선택해주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ReturnBooks_Load(sender, e);
            txtBookName.Clear();
            txtIssueDate.Clear();
            txtSearch.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtBookName.Clear();
            txtIssueDate.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
