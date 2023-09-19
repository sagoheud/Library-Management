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
    public partial class ViewStudent : Form
    {
        public ViewStudent()
        {
            InitializeComponent();
        }

        private void ViewStudent_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Main.sourceDB;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select * from NewStudent";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        int stuid;
        Int64 rowid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                stuid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = Main.sourceDB;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select * from NewStudent where stuid= " + stuid + "";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            txtStuName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtEnrollNo.Text = ds.Tables[0].Rows[0][2].ToString();
            txtDepart.Text = ds.Tables[0].Rows[0][3].ToString();
            txtSemester.Text = ds.Tables[0].Rows[0][4].ToString();
            txtContact.Text = ds.Tables[0].Rows[0][5].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0][6].ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Main.sourceDB;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Select * from NewStudent where stuName LIKE '" + txtSearch.Text + "%'";
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

                cmd.CommandText = "Select * from NewStudent";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtStuName.Clear();
            txtEnrollNo.Clear();
            txtDepart.Clear();
            txtSemester.Clear();
            txtContact.Clear();
            txtEmail.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtStuName.Text != "" && txtEnrollNo.Text != "" && txtDepart.Text != ""
                && txtSemester.Text != "" && txtContact.Text != "")
            {
                if (MessageBox.Show("내용을 변경하시겠습니까?", "Question",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    String stuName = txtStuName.Text;
                    String stuEnroll = txtEnrollNo.Text;
                    String studepart = txtDepart.Text;
                    String stuSem = txtSemester.Text;
                    Int64 stuContact = Int64.Parse(txtContact.Text);
                    String stuEmail = txtEmail.Text;

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = Main.sourceDB;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "Update NewStudent set stuName = '" + stuName + "',stuEnroll = '" + stuEnroll +
                        "',studepart = '" + studepart + "',stuSem = '" + stuSem + "',stuContact = " + stuContact +
                        ",stuEmail = '" + stuEmail + "' where stuid = " + rowid;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    MessageBox.Show("저장 완료", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("내용을 선택해주세요", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtStuName.Text != "" && txtEnrollNo.Text != "" && txtDepart.Text != ""
                && txtSemester.Text != "" && txtContact.Text != "")
            {
                if (MessageBox.Show("내용을 제거하시겠습니까?", "Are you sure?",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = Main.sourceDB;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "Delete from NewStudent where stuid = " + rowid;
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

        private void btnCancle_Click(object sender, EventArgs e)
        {
            txtStuName.Clear();
            txtEnrollNo.Clear();
            txtDepart.Clear();
            txtSemester.Clear();
            txtContact.Clear();
            txtEmail.Clear();
        }
    }
}
