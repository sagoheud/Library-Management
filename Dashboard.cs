﻿using Library_Management.Add;
using Library_Management.View;
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
    public partial class Dashboard : Form
    {
        string portName = "COM6";
        // Arduino와의 시리얼 통신에 사용할 포트 이름
        SerialPort serialPort;
        // 시리얼 포트 객체 선언
        private string receivedData;
        // 받는 데이터 객체 선언
        private System.Threading.Timer dataReceiveTimer;
        // 시간경과 체크

        public Dashboard()
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("종료하시겠습니까?","Confirm",
                MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnBookAdd_Click(object sender, EventArgs e)
        {
            AddBooks ab = new AddBooks(); 
            ab.Show();
        }

        private void btnBookView_Click(object sender, EventArgs e)
        {
            ViewBooks vb = new ViewBooks();
            vb.Show();
        }

        private void btnStudentAdd_Click(object sender, EventArgs e)
        {
            AddStudent ast = new AddStudent();
            ast.Show();
        }

        private void btnStudentView_Click(object sender, EventArgs e)
        {
            ViewStudent vst = new ViewStudent();
            vst.Show();
        }

        private void btnBookIssue_Click(object sender, EventArgs e)
        {
            serialPort.Open();
            MessageBox.Show("회원카드를 인식시켜 주세요");

            dataReceiveTimer = new System.Threading.Timer(StopDataReceive, null, 5000, Timeout.Infinite);
            SerialPort_DataReceived();
            if (receivedData != null)
            {
                Main.cardNum = receivedData;
                MessageBox.Show(Main.cardNum);
                serialPort.Close();
                IssueBooks ib = new IssueBooks();
                ib.Show();
            }
            else { return; }
        }

        private void btnBookReturn_Click(object sender, EventArgs e)
        {
            serialPort.Open();
            MessageBox.Show("회원카드를 인식시켜 주세요");

            dataReceiveTimer = new System.Threading.Timer(StopDataReceive, null, 5000, Timeout.Infinite);
            SerialPort_DataReceived();
            if (receivedData != null)
            {
                Main.cardNum = receivedData;
                MessageBox.Show(Main.cardNum);
                serialPort.Close();
                ReturnBooks rb = new ReturnBooks();
                rb.Show();
            }
            else { return; }
        }

        private void btnBookDetail_Click(object sender, EventArgs e)
        {
            CompleteBooksDetails cbd = new CompleteBooksDetails();
            cbd.Show();
        }
    }
}
