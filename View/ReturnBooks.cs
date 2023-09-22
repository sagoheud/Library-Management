using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Library_Management.View
{
    public partial class ReturnBooks : Form
    {
        public ReturnBooks()
        {
            InitializeComponent();
            txtSearch.Text = Main.cardNum;
            txtSearch.Enabled = false;
            EventHandler e = new EventHandler(btnSearch_Click);

            // btnSearch_Click 이벤트 핸들러를 호출
            e.Invoke(this, EventArgs.Empty);
        }

        private void ReturnBooks_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = Main.sourceDB;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT * FROM IRBook WHERE std_enroll='"+txtSearch.Text+ "' AND book_return_date IS NULL";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
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
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = Main.sourceDB;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT * FROM IRBook WHERE std_enroll = '" + txtSearch.Text + "' AND book_return_date IS NULL";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                for (int i = 3; i < 7; i++)
                {
                    dataGridView1.Columns[i].Visible = false;
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
            if (string.IsNullOrWhiteSpace(txtBookName.Text))
            {
                MessageBox.Show("반납할 책을 선택해주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (MySqlConnection con = new MySqlConnection(Main.sourceDB))
                {
                    con.Open();

                    // IRBook 테이블 업데이트
                    string updateIRBookQuery = "UPDATE IRBook SET book_return_date = @return_date " +
                                               "WHERE std_enroll = @std_enroll AND id = @row_id";

                    using (MySqlCommand updateIRBookCommand = new MySqlCommand(updateIRBookQuery, con))
                    {
                        updateIRBookCommand.Parameters.AddWithValue("@return_date", txtReturnDate.Text);
                        updateIRBookCommand.Parameters.AddWithValue("@std_enroll", txtSearch.Text);
                        updateIRBookCommand.Parameters.AddWithValue("@row_id", rowid);
                        updateIRBookCommand.ExecuteNonQuery();
                    }

                    // NewBook 테이블 업데이트
                    string updateNewBookQuery = "UPDATE NewBook SET bQty = (bQty - 1) WHERE bName = @book_name";

                    using (MySqlCommand updateNewBookCommand = new MySqlCommand(updateNewBookQuery, con))
                    {
                        updateNewBookCommand.Parameters.AddWithValue("@book_name", bname);
                        updateNewBookCommand.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("책이 반납되었습니다.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReturnBooks_Load(sender, e);
                txtBookName.Clear();
                txtIssueDate.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류가 발생했습니다: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }
    }
}
