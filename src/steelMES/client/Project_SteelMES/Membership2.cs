using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grpc.Core;  // Grpc.Core 사용
using SteelMES;
using ReaLTaiizor.Forms;
using System.Drawing;

namespace Project_SteelMES
{
	public partial class Membership2 : MaterialForm
	{
		private DB_Service.DB_ServiceClient _client;
		private readonly Membership _lost9;
		private Channel _channel;

		public Membership2(Membership lost9)
		{
			InitializeComponent();
			_lost9 = lost9;
			comboBox1.SelectedIndex = 0; // 첫 번째 항목 선택
			this.Load += new EventHandler(Membership2_Load);  // Form Load 이벤트 처리
		}

		// Form Load 시 gRPC 클라이언트 초기화
		private void Membership2_Load(object sender, EventArgs e)
		{
			InitializeGrpcClient();  // 비동기적으로 gRPC 클라이언트 초기화
                                     // 폼 시작 위치를 사용자 정의로 설정
            this.StartPosition = FormStartPosition.Manual;
            // 폼의 위치를 고정된 좌표로 설정
            this.Location = new Point(1255, 350);
        }

		// gRPC 클라이언트 초기화
		private void InitializeGrpcClient()
		{
			try
			{
				// Grpc.Core 채널 초기화
				_channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
				_client = new DB_Service.DB_ServiceClient(_channel);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"gRPC 채널 초기화 오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// 검색 버튼 클릭 시
		private async void button1_Click(object sender, EventArgs e)
		{
			string searchValue = InputTextBox.Text.Trim();

			if (string.IsNullOrEmpty(searchValue))
			{
				MessageBox.Show("검색할 값을 입력하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			try
			{
				var request = new SearchUserRequest { Username = searchValue };
				var response = await _client.SearchUserAsync(request);

				if (response.ErrorCode == 0)
				{
					UserNameLabel.Text = response.Users[0].Username;
					PasswordLabel.Text = response.Users[0].Password;
					comboBox1.SelectedItem = response.Users[0].UserLevel.ToString();
				}
				else
				{
					MessageBox.Show(response.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"gRPC 호출 오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// 변경 버튼 클릭 시
		// 변경 버튼 클릭 시
		private async void button2_Click(object sender, EventArgs e)
		{
			string selectedLevel = comboBox1.SelectedItem?.ToString();
			string userName = UserNameLabel.Text;

			if (string.IsNullOrEmpty(selectedLevel))
			{
				MessageBox.Show("레벨을 선택하세요", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (string.IsNullOrEmpty(userName))
			{
				MessageBox.Show("먼저 사용자를 검색하세요", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			int userLevelInt = -1; // 기본값으로 유효하지 않은 값 설정

			if (selectedLevel == "admin")
			{
				userLevelInt = 0;
			}
			else if (selectedLevel == "manager")
			{
				userLevelInt = 1;
			}
			else if (selectedLevel == "operator")
			{
				userLevelInt = 2;
			}

			if (userLevelInt == -1)
			{
				MessageBox.Show("유효하지 않은 사용자 레벨입니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var result = MessageBox.Show("변경하시겠습니까?", "확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
			if (result == DialogResult.OK)
			{
				try
				{
					var request = new UpdateUserLevelRequest
					{
						Username = userName,
						UserLevel = userLevelInt.ToString() // gRPC 서버에 전송 시 string으로 변환
					};

					// gRPC 서버 요청
					var response = await _client.UpdateUserLevelAsync(request);

					if (response.ErrorCode == 0)
					{
						MessageBox.Show(response.Message, "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);

						// 변경 완료 후 창 닫기
						this.Close(); // Membership2 창 닫기
					}
					else
					{
						MessageBox.Show(response.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				catch (RpcException rpcEx)
				{
					// gRPC 관련 예외 처리
					MessageBox.Show($"gRPC 오류: {rpcEx.StatusCode} - {rpcEx.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}


		private void button3_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		// Form 종료 시 채널 종료
		private void Membership2_FormClosing(object sender, FormClosingEventArgs e)
		{
			_channel?.ShutdownAsync().Wait();  // 채널 닫기
		}

        
    }
}
