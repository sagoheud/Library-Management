using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class Seat : Form
    {
        string portName = Main.portName;
        // Arduino와의 시리얼 통신에 사용할 포트 이름
        SerialPort serialPort;
        // 시리얼 포트 객체 선언
        private string receivedData;
        // 받는 데이터 객체 선언
        private System.Threading.Timer dataReceiveTimer;
        // 시간경과 체크

        Dictionary<UserControl, int> controlIndexMap = new Dictionary<UserControl, int>();

        public Seat()
        {
            InitializeComponent();
            // 시리얼 포트 초기화
            serialPort = new SerialPort(portName, 9600);
            Rest();
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

        private void Seat_Load(object sender, EventArgs e)
        {
            using (MySqlConnection con = GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM studyRoom";
                using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[1].Visible = false;

                    // DataTable의 행 수만큼 반복하여 userControl 설정
                    for (int i = 0; i < 20; i++)
                    {
                        string controlName = "userControl" + (i + 1);
                        UserControl userControl = this.Controls.Find(controlName, true).FirstOrDefault() as UserControl;

                        if (userControl != null)
                        {
                            if (dt.Rows[i][1].ToString() == "1")
                            {
                                userControl.BackColor = Color.Gray;
                                userControl.Enabled = false;
                            }
                            else
                            {
                                userControl.BackColor = Color.LightGreen;
                            }
                        }
                    }
                }
            }
        }


        private void userControl1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = GetConnection())
            {
                serialPort.Open();
                MessageBox.Show("카드 입력해주세요");
                dataReceiveTimer = new System.Threading.Timer(StopDataReceive, null, 5000, Timeout.Infinite);
                SerialPort_DataReceived();
                if (receivedData != null)
                {
                    con.Open();
                    string query = "SELECT * FROM studyRoom";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        for (int x = 0; x < dt.Rows.Count; x++)
                        {
                            if (dt.Rows[x][2].ToString() == receivedData)
                            {
                                serialPort.Close();
                                con.Close();
                                MessageBox.Show("이미 좌석 배정받은 카드입니다");
                                return;
                            }
                            else
                            {

                            }
                        }

                        UserControl clickedControl = sender as UserControl;

                        if (clickedControl != null)
                        {
                            string clickedControlName = clickedControl.Name;
                            string indexString = clickedControlName.Substring("userControl".Length);
                            {
                                string query1 = "UPDATE studyRoom SET able = 1, cardNum = @cardNum, date = NOW() WHERE seat = @seat";
                                using (MySqlCommand cmd = new MySqlCommand(query1, con))
                                {
                                    cmd.Parameters.AddWithValue("@cardNum", receivedData);
                                    // userControl에서 좌석 정보를 가져와서 @seat에 할당
                                    cmd.Parameters.AddWithValue("@seat", indexString); // 예시: 인덱스 + 1을 좌석 번호로 사용

                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("좌석배정을 완료했습니다.");

                                    clickedControl.BackColor = Color.Gray;
                                    clickedControl.Enabled = false;
                                    serialPort.Close();
                                    this.Close();
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Rest()
        {
            using (MySqlConnection con = GetConnection())
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM studyRoom WHERE able = 0"; // able이 0인 행의 개수를 셀 쿼리
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    int rowCount = Convert.ToInt32(cmd.ExecuteScalar()); // 결과의 첫 번째 열 값을 가져와서 행 수로 변환

                    lblRest.Text = rowCount.ToString();
                    lblPresent.Text = (20 - rowCount).ToString(); 
                }
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = GetConnection())
            {
                serialPort.Open();
                MessageBox.Show("카드 입력해주세요");
                dataReceiveTimer = new System.Threading.Timer(StopDataReceive, null, 5000, Timeout.Infinite);
                SerialPort_DataReceived();
                if (receivedData != null)
                {
                    con.Open();
                    string query = "SELECT * FROM studyRoom";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        for (int x = 0; x < dt.Rows.Count; x++)
                        {
                            if (dt.Rows[x][2].ToString() == receivedData)
                            {
                                string query1 = "UPDATE studyRoom SET able = 0, cardNum = @resetNum, date = NOW() WHERE cardNum = @cardNum";
                                using (MySqlCommand cmd = new MySqlCommand(query1, con))
                                {
                                    cmd.Parameters.AddWithValue("@resetNum", "");
                                    // userControl에서 좌석 정보를 가져와서 @seat에 할당
                                    cmd.Parameters.AddWithValue("@cardNum", receivedData); // 예시: 인덱스 + 1을 좌석 번호로 사용

                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("좌석 반납을 완료했습니다.");
                                    serialPort.Close();
                                    Rest();
                                    this.Close();
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
