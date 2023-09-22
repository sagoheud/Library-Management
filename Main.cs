using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management
{
    public class Main
    {
        public static string sourceDB =
                    "Server=localhost; " +
                    "Port=3306; " +
                    "Database=colabo; " +
                    "User=root; " +
                    "Password=1234;"; // MySQL 연결 문자열 수정

        public static string cardNum;

        public static string portName = "COM6";
    }
}
