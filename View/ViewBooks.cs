using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Library_Management.View
{
    public partial class ViewBooks : Form
    {
        public ViewBooks()
        {
            InitializeComponent();
        }

        private MySqlConnection GetConnection()
        {
            string connectionString = Main.sourceDB;
            return new MySqlConnection(connectionString);
        }

        private void ViewBooks_Load(object sender, EventArgs e)
        {
            using (MySqlConnection con = GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM NewBook";
                using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        int bid;
        Int64 rowid;
        //int index;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }

            using (MySqlConnection con = GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM NewBook WHERE bid = " + bid;
                using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //index++;
                    if (dt.Rows.Count > 0)
                    {

                        rowid = Int64.Parse(dt.Rows[0][0].ToString());
                        //rowid = index;
                        txtBookName.Text = dt.Rows[0][1].ToString();
                        txtAuthor.Text = dt.Rows[0][2].ToString();
                        txtPublic.Text = dt.Rows[0][3].ToString();
                        txtPDate.Text = dt.Rows[0][4].ToString();
                        txtPrice.Text = dt.Rows[0][5].ToString();
                        txtQty.Text = dt.Rows[0][6].ToString();
                    }
                }
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            txtBookName.Clear();
            txtAuthor.Clear();
            txtPublic.Clear();
            txtPDate.Value = DateTime.Today;
            txtPrice.Clear();
            txtQty.Clear();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtBookName.Text != "" && txtAuthor.Text != "" && txtPublic.Text != ""
                && txtPrice.Text != "" && txtQty.Text != "")
            {
                if (MessageBox.Show("내용을 변경하시겠습니까?", "Question",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    String bName = txtBookName.Text;
                    String bAuthor = txtAuthor.Text;
                    String bPublic = txtPublic.Text;
                    String bPDate = txtPDate.Text;
                    decimal bPrice = decimal.Parse(txtPrice.Text);
                    int bQty = int.Parse(txtQty.Text);

                    using (MySqlConnection con = GetConnection())
                    {
                        con.Open();
                        string query = "UPDATE NewBook SET bName = @bName, bAuthor = @bAuthor, " +
                            "bPublic = @bPublic, bPDate = @bPDate, bPrice = @bPrice, bQty = @bQty WHERE bid = @bid";
                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@bName", bName);
                            cmd.Parameters.AddWithValue("@bAuthor", bAuthor);
                            cmd.Parameters.AddWithValue("@bPublic", bPublic);
                            cmd.Parameters.AddWithValue("@bPDate", bPDate);
                            cmd.Parameters.AddWithValue("@bPrice", bPrice);
                            cmd.Parameters.AddWithValue("@bQty", bQty);
                            cmd.Parameters.AddWithValue("@bid", rowid);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("변경완료");
                    reset();
                }
            }
            else
            {
                MessageBox.Show("내용을 선택해주세요", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtBookName.Text != "" && txtAuthor.Text != "" && txtPublic.Text != ""
                && txtPrice.Text != "" && txtQty.Text != "")
            {
                if (MessageBox.Show("내용을 제거하시겠습니까?", "Are you sure?",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    using (MySqlConnection con = GetConnection())
                    {
                        con.Open();
                        string query = "DELETE FROM NewBook WHERE bid = @bid";
                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@bid", rowid);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("삭제완료");
                    reset();
                }
            }
            else
            {
                MessageBox.Show("내용을 선택해주세요", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reset()
        {
            using (MySqlConnection con = GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM NewBook";
                using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM NewBook WHERE bName LIKE '%" + txtSearch.Text + "%'";
                using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                txtBookName.Clear();
                txtAuthor.Clear();
                txtPublic.Clear();
                txtPDate.Value = DateTime.Today;
                txtPrice.Clear();
                txtQty.Clear();
            }
        }
    }
}
