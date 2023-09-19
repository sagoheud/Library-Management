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
    public partial class ViewBooks : Form
    {
        public ViewBooks()
        {
            InitializeComponent();
        }

        private void ViewBooks_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Main.sourceDB;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select * from NewBook";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        int bid;
        Int64 rowid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                // 열의 인덱스가 메시지 박스로 표시
            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = Main.sourceDB;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select * from NewBook where bid= " + bid + "";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            txtBookName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtAuthor.Text = ds.Tables[0].Rows[0][2].ToString();
            txtPublic.Text = ds.Tables[0].Rows[0][3].ToString();
            txtPDate.Text = ds.Tables[0].Rows[0][4].ToString();
            txtPrice.Text = ds.Tables[0].Rows[0][5].ToString();
            txtQty.Text = ds.Tables[0].Rows[0][6].ToString();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            txtBookName.Clear();
            txtAuthor.Clear();
            txtPublic.Clear();
            txtPDate.Value = DateTime.Today;
            txtPrice.Clear();
            txtQty.Clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Main.sourceDB;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Select * from NewBook where bName LIKE '"+txtSearch.Text+ "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else 
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Main.sourceDB;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Select * from NewBook";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtBookName.Clear();
            txtAuthor.Clear();
            txtPublic.Clear();
            txtPDate.Value = DateTime.Today;
            txtPrice.Clear();
            txtQty.Clear();
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
                    Int64 bPrice = Int64.Parse(txtPrice.Text);
                    Int16 bQty = Int16.Parse(txtQty.Text);

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = Main.sourceDB;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "Update NewBook set bName = '" + bName + "',bAuthor = '" + bAuthor +
                        "',bPublic = '" + bPublic + "',bPDate = '" + bPDate + "',bPrice = " + bPrice +
                        ",bQty = " + bQty + "where bid = " + rowid;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
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
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = Main.sourceDB;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "Delete from NewBook where bid = " + rowid;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                }
            }
            else
            {
                MessageBox.Show("내용을 선택해주세요", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
