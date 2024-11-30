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
using ReaLTaiizor.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using Grpc.Core;
using SteelMES;

namespace Project_SteelMES
{
    public partial class CreateID : PoisonForm
    {
        public CreateID()
        {
            InitializeComponent();
        }

        private void CreateID_Load(object sender, EventArgs e)
        {

        }

        private async void JoinBtn_Click(object sender, EventArgs e)
        {
            string username = UserName.Text;
            string password = Password.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("아이디와 비밀번호를 입력하세요.");
                return;
            }

            // gRPC 채널 생성
            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
            var client = new DB_Service.DB_ServiceClient(channel);

            try
            {
                // 서버에 회원가입 요청
                var response = await client.AddUserAsync(new AddUserRequest
                {
                    Username = username,
                    Password = password
                });

                if (response.ErrorCode == 0)
                {
                    MessageBox.Show(response.Message);
                    this.Close(); // 회원가입 창 닫기
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

        private void CancelBtn_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void CancleBtn_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private void UserName_Click(object sender, EventArgs e)
        {
            
        }

        private void UserName_Enter(object sender, EventArgs e)
        {

        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void Password_Enter(object sender, EventArgs e)
        {

        }

    }
}
