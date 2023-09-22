using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Library_Management.View
{
    public partial class CompleteBooksDetails : Form
    {
        public CompleteBooksDetails()
        {
            InitializeComponent();
        }

        private void CompleteBooksDetails_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = Main.sourceDB;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT std_enroll,std_name,std_contact,std_email,book_name,book_issue_date, book_return_date FROM IRBook WHERE book_return_date IS NULL";
            MySqlDataAdapter da1 = new MySqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];

            cmd.CommandText = "SELECT std_enroll,std_name,std_contact,std_email,book_name,book_issue_date, book_return_date FROM IRBook WHERE book_return_date IS NOT NULL";
            MySqlDataAdapter da2 = new MySqlDataAdapter(cmd);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];
        }
    }
}
