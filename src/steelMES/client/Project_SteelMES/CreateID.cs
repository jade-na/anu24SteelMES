using Oracle.ManagedDataAccess.Client;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_SteelMES
{
    public partial class CreateID : Form
    {
        public CreateID()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = UserName.Text;
            string password = Password.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("아이디와 비밀번호를 입력하세요.");
                return;
            }

            // 오라클 연결 문자열
            string connectionString = "User Id=scott;Password=tiger;Data Source=//localhost:1521/XE";


            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Users (Username, Password) VALUES (:username, :password)";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        // 매개변수 추가
                        cmd.Parameters.Add(new OracleParameter("username", username));
                        cmd.Parameters.Add(new OracleParameter("password", password));

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("회원가입 성공!");
                            this.Close(); // 회원가입 창 닫기
                        }
                        catch (OracleException ex)
                        {
                            // UNIQUE 제약 조건 위반 예외 처리
                            if (ex.Number == 1) // ORA-00001: Unique Constraint 위반
                            {
                                MessageBox.Show("이미 존재하는 아이디입니다.");
                            }
                            else
                            {
                                MessageBox.Show("오류 발생: " + ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("데이터베이스 연결 오류: " + ex.Message);
                }
            }

        }
    }
}
