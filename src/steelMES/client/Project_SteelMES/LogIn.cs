using System;
using System.Windows.Forms;
using System.Windows.Forms;
using ReaLTaiizor.Forms;
using SteelMES;
using Grpc.Core;
using grpctestserver;
using System.IO;

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

		private async void LoginBtn_Click(object sender, EventArgs e) //수정
        {
			string username = UserID.Text;
			string password = Password.Text;

            string configFilePath = Path.Combine(Directory.GetCurrentDirectory(), "appsetting.json");
            var config = ConfigLoader.LoadConfig(configFilePath);

            if (config == null || config.GrpcSettings == null)
            {
                MessageBox.Show("gRPC 설정을 로드하는 데 실패했습니다.");
                return;
            }

            // gRPC 채널 생성
            var channel = new Channel($"{config.GrpcSettings.Host}:{config.GrpcSettings.Port}", ChannelCredentials.Insecure);
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
					if (response.ForceExit) // 중복 로그인 세션이 감지된 경우
					{
						// 서버에서 자동으로 강제 로그아웃 처리
						var forceLogoutResponse = await client.ForceLogoutAsync(new ForceLogoutRequest { UserId = username });

						if (forceLogoutResponse.Success)
						{
							// 기존 세션이 강제 종료된 후 새로 로그인
							MessageBox.Show("기존 세션이 강제로 종료되었습니다. 새로운 세션으로 로그인합니다.");

							// 강제 로그아웃 후 다시 로그인
							var newResponse = await client.GetLoginAsync(new LoginRequest
							{
								Username = username,
								Password = password
							});

							if (newResponse.ErrorCode == 0)
							{
								// 로그인 성공
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
						// 이미 로그인된 세션이 없으면 바로 로그인
						Monitoring MonitoringForm = new Monitoring(username, response.UserLevel);
						MessageBox.Show($"{username} 님 반갑습니다.");
						MonitoringForm.Show();
						this.Hide();
					}
				}
				else
				{
					// 로그인 실패
					MessageBox.Show("로그인 실패: " + response.Message);
				}
			}
			catch (RpcException rpcEx)
			{
				// gRPC 호출 오류 처리
				MessageBox.Show("gRPC 오류 발생: " + rpcEx.Status.Detail);
			}
			catch (Exception ex)
			{
				// 일반적인 오류 처리
				MessageBox.Show("오류 발생: " + ex.Message);
			}
			finally
			{
				await channel.ShutdownAsync();
			}
		}

	}
}
