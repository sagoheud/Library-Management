using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management.Add
{
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBookName.Text != "" && txtAuthor.Text != "" && txtPublic.Text != "" 
                && txtPrice.Text != "" && txtQty.Text != "")
            {
                String bName = txtBookName.Text;
                String bAuthor = txtAuthor.Text;
                String bPublic = txtPublic.Text;
                String bPDate = dateTimePicker1.Text;
                Int64 bPrice = Int64.Parse(txtPrice.Text);
                Int16 bQty = Int16.Parse(txtQty.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = Main.sourceDB;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "Insert into NewBook (bName,bAuthor,bPublic,bPDate,bPrice,bQty) values ('"
                    + bName + "','" + bAuthor + "','" + bPublic + "','" + bPDate + "'," + bPrice + "," + bQty + ")";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("저장 완료", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBookName.Clear();
                txtAuthor.Clear();
                txtPublic.Clear();
                txtPrice.Clear();
                txtQty.Clear();
            }
            else
            {
                MessageBox.Show("빈 칸을 채워주세요", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("저장되지 않은 데이터가 삭제됩니다.", "확실합니까?", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            } 
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            Int64 res = 0;
            if (Int64.TryParse(txtPrice.Text, out res))
            {
                if (txtPrice.Text.Length > 5)
                {
                    txtPrice.Text = txtPrice.Text.Substring(0, 5);
                    txtPrice.SelectionStart = txtPrice.Text.Length;
                }
            }
            else
            {
                txtPrice.Text = null;
            }
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            Int16 res = 0;
            if(Int16.TryParse(txtQty.Text, out res))
            {
                if (txtQty.Text.Length > 3)
                {
                    txtQty.Text = txtQty.Text.Substring(0, 3);
                    txtQty.SelectionStart = txtQty.Text.Length;
                }
            }
            else
            {
                txtQty.Text = null;
            }
        }
    }
}
