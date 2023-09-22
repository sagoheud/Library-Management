using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace Library_Management.Add
{
    public partial class AddStudent : Form
    {
        string portName = Main.portName;
        // Arduino와의 시리얼 통신에 사용할 포트 이름
        SerialPort serialPort;
        // 시리얼 포트 객체 선언
        private string receivedData;
        // 받는 데이터 객체 선언
        private System.Threading.Timer dataReceiveTimer;
        // 시간경과 체크

        public AddStudent()
        {
            InitializeComponent();
            // 시리얼 포트 초기화
            serialPort = new SerialPort(portName, 9600);
        }

        private void SerialPort_DataReceived()
        {
            try
            {
                receivedData = serialPort.ReadLine().ToString().Trim();
            }
            catch (Exception e)
            {
                Main.cardNum = null;
                receivedData = null;
                MessageBox.Show("시간 초과로 다시 진행 바랍니다.");
                return;
            }
        }

        private void StopDataReceive(object state)
        {
            serialPort.Close();
            dataReceiveTimer.Dispose();
            return;
        }


        private MySqlConnection GetConnection()
        {
            string connectionString = Main.sourceDB;
            return new MySqlConnection(connectionString);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtStuName.Clear();
            txtEnrollNo.Clear();
            txtDepart.Clear();
            txtSemester.Clear();
            txtContact.Clear();
            txtEmail.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtStuName.Text != "" && txtEnrollNo.Text != "" && txtDepart.Text != ""
                && txtSemester.Text != "" && txtContact.Text != "")
            {
                string stuName = txtStuName.Text;
                string stuEnroll = txtEnrollNo.Text;
                string studepart = txtDepart.Text;
                string stuSem = txtSemester.Text;
                Int64 stuContact = Int64.Parse(txtContact.Text);
                string stuEmail = txtEmail.Text;

                using (MySqlConnection con = GetConnection())
                {
                    con.Open();
                    string query = "INSERT INTO NewStudent (stuName, stuEnroll, studepart, stuSem, stuContact, stuEmail) " +
                        "VALUES (@stuName, @stuEnroll, @studepart, @stuSem, @stuContact, @stuEmail)";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@stuName", stuName);
                        cmd.Parameters.AddWithValue("@stuEnroll", stuEnroll);
                        cmd.Parameters.AddWithValue("@studepart", studepart);
                        cmd.Parameters.AddWithValue("@stuSem", stuSem);
                        cmd.Parameters.AddWithValue("@stuContact", stuContact);
                        cmd.Parameters.AddWithValue("@stuEmail", stuEmail);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("저장 완료", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStuName.Clear();
                txtEnrollNo.Clear();
                txtDepart.Clear();
                txtSemester.Clear();
                txtContact.Clear();
                txtEmail.Text = "";
            }
            else
            {
                MessageBox.Show("빈 칸을 채워주세요", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("저장되지 않은 데이터가 삭제됩니다.", "확실합니까?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            Int64 res = 0;
            if (Int64.TryParse(txtContact.Text, out res))
            {
                if (txtContact.Text.Length > 10)
                {
                    txtContact.Text = txtContact.Text.Substring(0, 10);
                    txtContact.SelectionStart = txtContact.Text.Length;
                }
            }
            else
            {
                txtContact.Text = null;
            }
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            serialPort.Open();
            MessageBox.Show("회원카드를 인식시켜 주세요");

            dataReceiveTimer = new System.Threading.Timer(StopDataReceive, null, 5000, Timeout.Infinite);
            SerialPort_DataReceived();
            if (receivedData != null)
            {
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = Main.sourceDB;
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM NewStudent WHERE stuEnroll = '" + receivedData + "'";
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    serialPort.Close();
                    MessageBox.Show("이미 등록된 카드입니다.");
                    return;
                }
                else
                {
                    txtEnrollNo.Text = receivedData;
                    serialPort.Close();
                }
            }
            else 
            {
                serialPort.Close();
                return; 
            }
        }
    }
}
