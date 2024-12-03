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
					// 세션이 존재하는 경우
					if (response.ForceExit) // 중복 로그인 세션이 감지된 경우
					{
						// 중복 로그인 경고 메시지 박스를 UI 스레드에서 띄운다.
						var result = ShowMessageBox(response.Message, "중복 로그인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

						// 사용자가 "Yes"를 눌렀을 경우
						if (result == DialogResult.Yes)
						{
							// 강제 로그아웃 요청
							var forceLogoutResponse = await client.ForceLogoutAsync(new LogoutRequest { UserId = username });

							// 로그아웃 성공하면 새로운 세션으로 로그인 처리
							if (forceLogoutResponse.Success)
							{
								// 로그아웃 후 다시 로그인
								var newResponse = await client.GetLoginAsync(new LoginRequest
								{
									Username = username,
									Password = password
								});

								if (newResponse.ErrorCode == 0)
								{
									MessageBox.Show("기존 세션이 강제로 종료되었습니다. 새로운 세션으로 로그인합니다.");

									// Monitoring 폼으로 이동
									Monitoring MonitoringForm = new Monitoring(username, newResponse.UserLevel);
									MonitoringForm.Show();
									this.Hide();
								}
								else
								{
									MessageBox.Show("로그인 실패: " + newResponse.Message);
								}
							}
							else
							{
								MessageBox.Show("세션 종료 실패: " + forceLogoutResponse.Message);
							}
						}
						else
						{
							// 사용자가 "No"를 눌렀을 경우, 로그인 취소
							MessageBox.Show("로그인이 취소되었습니다.");
						}
					}
					else
					{
						// 이미 로그인된 세션이 없으면 바로 로그인
						Monitoring MonitoringForm = new Monitoring(username, response.UserLevel);
						MonitoringForm.Show();
						this.Hide();
					}
				}
				else
				{
					// 로그인 실패
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

		private DialogResult ShowMessageBox(string message, string caption = "알림", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information)
		{
			// UI 스레드에서 메시지 박스를 띄운다.
			if (InvokeRequired)
			{
				// UI 스레드에서 호출되도록 Invoke를 사용
				return (DialogResult)Invoke(new Func<string, string, MessageBoxButtons, MessageBoxIcon, DialogResult>(ShowMessageBox), message, caption, buttons, icon);
			}
			else
			{
				return MessageBox.Show(message, caption, buttons, icon);
			}
		}
	}
}
