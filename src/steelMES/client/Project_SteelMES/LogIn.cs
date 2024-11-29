using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

using System.Windows.Forms;

//using System.Windows.Forms;
using ReaLTaiizor.Forms;

namespace Project_SteelMES
{
    public partial class Login : CrownForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Crown_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void hopeSwitch1_CheckedChanged(object sender, EventArgs e) //Password 암호화
        {
            this.hopeSwitch1.CheckedChanged += new System.EventHandler(this.hopeSwitch1_CheckedChanged);

            if (hopeSwitch1.Checked)
            {
                Password.UseSystemPasswordChar = true;
            }
            else
                Password.UseSystemPasswordChar = false;
        }

        private void UseId_Click(object sender, EventArgs e) //ID 입력 시 초기화
        {
            this.UserID.Enter += new System.EventHandler(this.UseId_Enter);
            UserID.Text = string.Empty;
        }
        private void UseId_Enter(object sender, EventArgs e)
        {
            
        }

        private void hopeTextBox2_Click(object sender, EventArgs e) //Password 입력 시 초기화
        {
            this.Password.Enter += new System.EventHandler(this.hopeTextBox2_Enter);
            Password.Text = string.Empty;
        }
        private void hopeTextBox2_Enter(object sender, EventArgs e)
        {

        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            // 회원가입 창 띄우기
            CreateID createForm= new CreateID();
            createForm.ShowDialog(); 
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        

        private void JoinBtn_Click(object sender, EventArgs e)
        {
            // 회원가입 창 띄우기
            CreateID createForm = new CreateID();
            //createForm.ShowDialog();
            createForm.Show();
            this.Hide();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = UserID.Text;
            string password = Password.Text;
            Password.PasswordChar = '*';
            // 오라클 연결 문자열
            string connectionString = "User Id=scott;Password=tiger;Data Source=//localhost:1521/XE";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE Username = :username AND Password = :password";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        // 매개변수 추가
                        cmd.Parameters.Add(new OracleParameter("username", username));
                        cmd.Parameters.Add(new OracleParameter("password", password));

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("로그인 성공!");

                            // Lost 폼 열기
                            Monitoring lostForm = new Monitoring();
                            lostForm.Show();

                            // 현재 로그인 창 숨기기
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("아이디 또는 비밀번호가 잘못되었습니다.");
                        }
                    }
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("데이터베이스 오류: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("오류 발생: " + ex.Message);
                }
            }
        }
    }
}
