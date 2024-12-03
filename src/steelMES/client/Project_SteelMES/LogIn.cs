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
using SteelMES;
using Grpc.Core;

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
            CreateID createForm = new CreateID();
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

        private async void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = UserID.Text;
            string password = Password.Text;
            //Password.PasswordChar = '*';

            // gRPC 채널 생성
            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
            var client = new DB_Service.DB_ServiceClient(channel);

            try
            {
                // gRPC 서버로 로그인 요청
                var response = await client.GetLoginAsync(new LoginRequest
                {
                    Username = username,
                    Password = password
                });

                if (response.ErrorCode == 0)
                {
                    MessageBox.Show(response.Message);

                    Monitoring MonitoringForm = new Monitoring(username, response.UserLevel);
                    MonitoringForm.Show();

                    // 현재 로그인 창 숨기기
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(response.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("gRPC 오류 발생: " + ex.Message);
            }
            finally
            {
                await channel.ShutdownAsync();
            }


        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
