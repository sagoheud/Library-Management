using MySql.Data.MySqlClient;
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

        private MySqlConnection GetConnection()
        {
            string connectionString = Main.sourceDB;
            return new MySqlConnection(connectionString);
        }

        private void ViewStudent_Load(object sender, EventArgs e)
        {
            using (MySqlConnection con = GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM NewStudent";
                using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        int stuid;
        Int64 rowid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                stuid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }

            using (MySqlConnection con = GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM NewStudent WHERE stuid= " + stuid;
                using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        rowid = Int64.Parse(dt.Rows[0][0].ToString());
                        txtStuName.Text = dt.Rows[0][1].ToString();
                        txtEnrollNo.Text = dt.Rows[0][2].ToString();
                        txtDepart.Text = dt.Rows[0][3].ToString();
                        txtSemester.Text = dt.Rows[0][4].ToString();
                        txtContact.Text = dt.Rows[0][5].ToString();
                        txtEmail.Text = dt.Rows[0][6].ToString();
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtStuName.Text != "" && txtEnrollNo.Text != "" && txtDepart.Text != ""
                && txtSemester.Text != "" && txtContact.Text != "")
            {
                if (MessageBox.Show("내용을 변경하시겠습니까?", "Question",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string stuName = txtStuName.Text;
                    string stuEnroll = txtEnrollNo.Text;
                    string stuDepart = txtDepart.Text;
                    string stuSemester = txtSemester.Text;
                    Int64 stuContact = Int64.Parse(txtContact.Text);
                    string stuEmail = txtEmail.Text;

                    using (MySqlConnection con = GetConnection())
                    {
                        con.Open();
                        string query = "UPDATE NewStudent SET stuName = @stuName, stuEnroll = @stuEnroll, " +
                            "studepart = @studepart, stuSem = @stuSem, stuContact = @stuContact, stuEmail = @stuEmail " +
                            "WHERE stuid = @stuid";
                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@stuName", stuName);
                            cmd.Parameters.AddWithValue("@stuEnroll", stuEnroll);
                            cmd.Parameters.AddWithValue("@studepart", stuDepart);
                            cmd.Parameters.AddWithValue("@stuSem", stuSemester);
                            cmd.Parameters.AddWithValue("@stuContact", stuContact);
                            cmd.Parameters.AddWithValue("@stuEmail", stuEmail);
                            cmd.Parameters.AddWithValue("@stuid", stuid);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("변경 완료");
                    reset();
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
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtStuName.Text != "" && txtEnrollNo.Text != "" && txtDepart.Text != ""
                && txtSemester.Text != "" && txtContact.Text != "")
            {
                if (MessageBox.Show("내용을 제거하시겠습니까?", "Are you sure?",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    using (MySqlConnection con = GetConnection())
                    {
                        con.Open();
                        string query = "DELETE FROM NewStudent WHERE stuid = @rowid";
                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@rowid", rowid);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                using (MySqlConnection con = GetConnection())
                {
                    con.Open();
                    string query = "SELECT * FROM NewStudent WHERE stuName LIKE '" + txtSearch.Text + "%'";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            else
            {
                using (MySqlConnection con = GetConnection())
                {
                    con.Open();
                    string query = "SELECT * FROM NewStudent";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }

        private void reset()
        {
            using (MySqlConnection con = GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM NewStudent";
                using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }
    }
}
