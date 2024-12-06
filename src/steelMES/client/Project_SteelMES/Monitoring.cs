using System;
using System.Drawing;
using System.Windows.Forms;
using Grpc.Core;


//using System.Windows.Forms;
using ReaLTaiizor.Forms;
using SteelMES;

namespace Project_SteelMES
{
	public partial class Monitoring : LostForm
	{
		private Button optionButton1; //공장 등록 버튼
		private Button optionButton2; //공급업체 등록 버튼
		private Button optionButton3; //회원 관리 버튼
		private bool areOptionButtonsVisible = false; // 가시성 상태 저장

		private int userLevel;
		private string userName;

		public Monitoring(string userName, int userLevel)
		{
			InitializeComponent();

			this.userLevel = userLevel;
			this.userName = userName;
		}

		public Monitoring()
		{

		}

		private void Lost_Load(object sender, EventArgs e)
		{
			// 폼 시작 위치를 사용자 정의로 설정
			this.StartPosition = FormStartPosition.Manual;
			// 폼의 위치를 고정된 좌표로 설정
			this.Location = new Point(0, 0);

			// 하위 버튼 생성
			CreateOptionButtons();

			timer1.Start();

			LoginInfo1.Text = $"{userName} 님";
			LoginInfo2.Text = $"권한등급 : {userLevel}";


		}

		private void CreateOptionButtons()
		{

			//공장 등록 버튼
			optionButton1 = new Button();
			optionButton1.Text = "공장 등록";
			optionButton1.Location = new Point(this.Width - 120, 100);
			optionButton1.Size = new Size(200, 50);
			optionButton1.Font = new System.Drawing.Font("G마켓 산스 TTF Midium", 20F);
			optionButton1.BackColor = Color.LightGray;
			optionButton1.FlatStyle = FlatStyle.Flat;
			optionButton1.Visible = false; // 초기에는 숨김
			optionButton1.Click += OptionButton1_Click;

			//공급업체 등록 버튼
			optionButton2 = new Button();
			optionButton2.Text = "공급업체 등록";
			optionButton2.Location = new Point(this.Width - 120, 100);
			optionButton2.Font = new System.Drawing.Font("G마켓 산스 TTF Midium", 20F);
			optionButton2.Size = new Size(200, 50);
			optionButton2.BackColor = Color.LightGray;
			optionButton2.FlatStyle = FlatStyle.Flat;
			optionButton2.Visible = false; // 초기에는 숨김
			optionButton2.Click += OptionButton2_Click;

			//회원 관리 버튼
			optionButton3 = new Button();
			optionButton3.Text = "회원 관리";
			optionButton3.Location = new Point(this.Width - 120, 100);
			optionButton3.Font = new System.Drawing.Font("G마켓 산스 TTF Midium", 20F);
			optionButton3.Size = new Size(200, 50);
			optionButton3.BackColor = Color.LightGray;
			optionButton3.FlatStyle = FlatStyle.Flat;
			optionButton3.Visible = false; // 초기에는 숨김
			optionButton3.Click += OptionButton3_Click;

			// 동적으로 생성된 버튼을 폼에 추가
			//         this.Controls.Add(optionButton1);
			//this.Controls.Add(optionButton2);
			this.Controls.Add(optionButton1);
			this.Controls.Add(optionButton2);
			this.Controls.Add(optionButton3);

		}

		private void button4_Click(object sender, EventArgs e)
		{
			Menu_WorkBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(44)))), ((int)(((byte)(77)))));
			Menu_WorkBtn.ForeColor = Color.SkyBlue;

			Menu_MonitoringBtn.BackColor = Color.Transparent;
			Menu_MonitoringBtn.ForeColor = Color.SkyBlue;
			Menu_DefectRecordBtn.BackColor = Color.Transparent;
			Menu_DefectRecordBtn.ForeColor = Color.SkyBlue;
			Menu_DefinitonBtn.BackColor = Color.Transparent;
			Menu_DefinitonBtn.ForeColor = Color.SkyBlue;

			Work lost8 = new Work();

			// Form2를 panel1에 표시
			lost8.TopLevel = false; // 폼을 자식 컨트롤로 설정
			lost8.FormBorderStyle = FormBorderStyle.None; // 테두리 제거
			lost8.Dock = DockStyle.Fill; // Panel에 맞게 크기 조정

			panel5.Controls.Clear(); // 기존 컨트롤 제거
			panel5.Controls.Add(lost8); // Form2 추가
			lost8.Show(); // Form2 표시
		}


		private void OptionButton1_Click(object sender, EventArgs e) //공장 등록 버튼
		{

			if (userLevel == 0)
			{
				FactoryRegister facRegister = new FactoryRegister();
				facRegister.Show();
			}
			else
			{
				MessageBox.Show("admin 권한 이상만 접속이 가능합니다.");
			}
		}

		private void OptionButton2_Click(object sender, EventArgs e) //공급업체 등록 버튼
		{
			if (userLevel == 0)
			{
				Supply supply = new Supply();
				supply.Show();
			}
			else
			{
				MessageBox.Show("admin 권한 이상만 접속이 가능합니다.");
			}
		}

		private void OptionButton3_Click(object sender, EventArgs e) //회원 관리 버튼
		{
			if (userLevel == 0)
			{
				Membership membership = new Membership();
				membership.Show();
			}
			else
			{
				MessageBox.Show("admin 권한 이상만 접속이 가능합니다.");
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Menu_DefinitonBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(44)))), ((int)(((byte)(77)))));
			Menu_DefinitonBtn.ForeColor = Color.SkyBlue;

			Menu_DefectRecordBtn.BackColor = Color.Transparent;
			Menu_DefectRecordBtn.ForeColor = Color.SkyBlue;
			Menu_MonitoringBtn.BackColor = Color.Transparent;
			Menu_MonitoringBtn.ForeColor = Color.SkyBlue;
			Menu_WorkBtn.BackColor = Color.Transparent;
			Menu_WorkBtn.ForeColor = Color.SkyBlue;

			// Form2 인스턴스 생성
			Definition metro = new Definition();

			// Form2를 panel1에 표시
			metro.TopLevel = false; // 폼을 자식 컨트롤로 설정
			metro.FormBorderStyle = FormBorderStyle.None; // 테두리 제거
			metro.Dock = DockStyle.Fill; // Panel에 맞게 크기 조정

			panel5.Controls.Clear(); // 기존 컨트롤 제거
			panel5.Controls.Add(metro); // Form2 추가
			metro.Show(); // Form2 표시

		}

		private void button5_Click(object sender, EventArgs e)
		{
			Menu_CloseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(44)))), ((int)(((byte)(77)))));
			Menu_CloseBtn.ForeColor = Color.SkyBlue;

			Menu_DefinitonBtn.BackColor = Color.Transparent;
			Menu_DefinitonBtn.ForeColor = Color.SkyBlue;
			Menu_DefectRecordBtn.BackColor = Color.Transparent;
			Menu_DefectRecordBtn.ForeColor = Color.SkyBlue;
			Menu_MonitoringBtn.BackColor = Color.Transparent;
			Menu_MonitoringBtn.ForeColor = Color.SkyBlue;
			Menu_WorkBtn.BackColor = Color.Transparent;
			Menu_WorkBtn.ForeColor = Color.SkyBlue;


			Dispose();
		}

		private void button6_Click(object sender, EventArgs e) //설정 아이콘 버튼
		{
			// 버튼 가시성 토글
			areOptionButtonsVisible = !areOptionButtonsVisible;

			Point baseLocation = button6.Location;
			optionButton1.Location = new Point(baseLocation.X + button6.Width + 5, baseLocation.Y);
			optionButton2.Location = new Point(baseLocation.X + button6.Width + 5, baseLocation.Y + optionButton1.Height + 1);
			optionButton3.Location = new Point(baseLocation.X + button6.Width + 5, baseLocation.Y + optionButton1.Height + 52);

			// 버튼 가시성 업데이트
			optionButton1.Visible = areOptionButtonsVisible;
			optionButton2.Visible = areOptionButtonsVisible;
			optionButton3.Visible = areOptionButtonsVisible;

			// 버튼 앞으로 가져오기
			optionButton1.BringToFront();
			optionButton2.BringToFront();
			optionButton3.BringToFront();

		}

		private void button1_Click(object sender, EventArgs e)
		{
			Menu_DefectRecordBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(44)))), ((int)(((byte)(77)))));
			Menu_DefectRecordBtn.ForeColor = Color.SkyBlue;

			Monitoring lost = new Monitoring();
			lost.Show();
			this.Hide();
		}

		private void button8_Click(object sender, EventArgs e) //자재 주문 버튼
		{
			Menu_DefinitonBtn.BackColor = Color.Transparent;
			Menu_DefinitonBtn.ForeColor = Color.SkyBlue;
			Menu_DefectRecordBtn.BackColor = Color.Transparent;
			Menu_DefectRecordBtn.ForeColor = Color.SkyBlue;
			Menu_MonitoringBtn.BackColor = Color.Transparent;
			Menu_MonitoringBtn.ForeColor = Color.SkyBlue;
			Menu_WorkBtn.BackColor = Color.Transparent;
			Menu_WorkBtn.ForeColor = Color.SkyBlue;

			if (userLevel <= 1)
			{
				FactoryRegister facRegister = new FactoryRegister();
				facRegister.Show();
			}
			else
			{
				MessageBox.Show("manager 권한 이상만 접속이 가능합니다.");
			}

			MaterialOrder matOrder = new MaterialOrder();

			matOrder.TopLevel = false;
			matOrder.FormBorderStyle = FormBorderStyle.None; // 테두리 제거
			matOrder.Dock = DockStyle.Fill; // Panel에 맞게 크기 조정

			panel5.Controls.Clear(); // 기존 컨트롤 제거
			panel5.Controls.Add(matOrder); // Form2 추가
			matOrder.Show(); // Form2 표시


		}

		private void button7_Click(object sender, EventArgs e)
		{
			Menu_DefinitonBtn.BackColor = Color.Transparent;
			Menu_DefinitonBtn.ForeColor = Color.SkyBlue;
			Menu_DefectRecordBtn.BackColor = Color.Transparent;
			Menu_DefectRecordBtn.ForeColor = Color.SkyBlue;
			Menu_MonitoringBtn.BackColor = Color.Transparent;
			Menu_MonitoringBtn.ForeColor = Color.SkyBlue;
			Menu_WorkBtn.BackColor = Color.Transparent;
			Menu_WorkBtn.ForeColor = Color.SkyBlue;

			ProcessManagement lost5 = new ProcessManagement();

			lost5.TopLevel = false;
			lost5.FormBorderStyle = FormBorderStyle.None; // 테두리 제거
			lost5.Dock = DockStyle.Fill; // Panel에 맞게 크기 조정

			panel5.Controls.Clear(); // 기존 컨트롤 제거
			panel5.Controls.Add(lost5); // Form2 추가
			lost5.Show(); // Form2 표시
		}

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{

		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void Menu_DefectRecordBtn_Click(object sender, EventArgs e)
		{
			Menu_DefectRecordBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(44)))), ((int)(((byte)(77)))));
			Menu_DefectRecordBtn.ForeColor = Color.SkyBlue;

			Menu_MonitoringBtn.BackColor = Color.Transparent;
			Menu_MonitoringBtn.ForeColor = Color.SkyBlue;

			Menu_DefinitonBtn.BackColor = Color.Transparent;
			Menu_DefinitonBtn.ForeColor = Color.SkyBlue;
			Menu_WorkBtn.BackColor = Color.Transparent;
			Menu_WorkBtn.ForeColor = Color.SkyBlue;

			// Form2 인스턴스 생성
			DefectRecord lost2 = new DefectRecord();

			// Form2를 panel1에 표시
			lost2.TopLevel = false; // 폼을 자식 컨트롤로 설정
			lost2.FormBorderStyle = FormBorderStyle.None; // 테두리 제거
			lost2.Dock = DockStyle.Fill; // Panel에 맞게 크기 조정

			panel5.Controls.Clear(); // 기존 컨트롤 제거
			panel5.Controls.Add(lost2); // Form2 추가
			lost2.Show(); // Form2 표시
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			label1.Text = DateTime.Now.ToString();
		}

		private async void LogoutBtn_Click(object sender, EventArgs e)
		{
			// gRPC 채널 생성
			var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
			var client = new DB_Service.DB_ServiceClient(channel);

			try
			{
				// 로그아웃 요청
				var logoutResponse = await client.GetLogoutAsync(new LogoutRequest
				{
					UserId = userName  // 로그아웃할 사용자 ID
				});

				if (logoutResponse.Success)
				{
					MessageBox.Show("로그아웃 성공!");
					this.Close();
				}
				else
				{
					MessageBox.Show("로그아웃 실패: " + logoutResponse.Message);
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

		private void LoginInfo2_Click(object sender, EventArgs e)
		{

		}
	}
}
