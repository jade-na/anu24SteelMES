using System;
using System.Drawing;
using System.Windows.Forms;
using Grpc.Core;
using ReaLTaiizor.Forms;
using SteelMES;

namespace Project_SteelMES
{
	public partial class Lost3 : LostForm
	{
		private Button optionButton1;
		private Button optionButton2;
		private bool areOptionButtonsVisible = false; // 가시성 상태 저장

		public Lost3()
		{
			InitializeComponent();
		}

		private async void button6_Click(object sender, EventArgs e)
		{
			var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
			var client = new DB_Service.DB_ServiceClient(channel);

			try
			{
				var response = await client.GetFactoryDataAsync(new SteelMES.Empty());

				// 열 확인 후 데이터 추가
				if (dataGridView1.Columns.Count == 0)
				{
					dataGridView1.Columns.Add("FACID", "FACID");
					dataGridView1.Columns.Add("LOCATION", "Location");
				}

				dataGridView1.Rows.Clear();

				foreach (var factory in response.Factories)
				{
					dataGridView1.Rows.Add(factory.FacID, factory.Location);
				}
			}
			catch (RpcException ex)
			{
				MessageBox.Show($"gRPC 호출 실패: {ex.Status.Detail}");
			}
			finally
			{
				await channel.ShutdownAsync();
			}
		}

		private async void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				var selectedFacID = dataGridView1.Rows[e.RowIndex].Cells[0].Value?.ToString();

				if (!string.IsNullOrEmpty(selectedFacID))
				{
					var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
					var client = new DB_Service.DB_ServiceClient(channel);

					try
					{
						var lineResponse = await client.GetProductionLineDataAsync(new ProductionLineRequest
						{
							FacID = int.Parse(selectedFacID)
						});

						dataGridView2.Rows.Clear();

						foreach (var line in lineResponse.Lines)
						{
							dataGridView2.Rows.Add(line.FacID, line.LineID, line.LineName, line.OperateDate);
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show($"Error: {ex.Message}");
					}
					finally
					{
						await channel.ShutdownAsync();
					}
				}
			}
		}

		private void Lost3_Load(object sender, EventArgs e)
		{
			// DataGridView1 설정 (Factory 데이터)
			if (dataGridView1.Columns.Count == 0) // 중복 추가 방지
			{
				dataGridView1.Columns.Add("FACID", "FACID");
				dataGridView1.Columns.Add("LOCATION", "Location");
			}

			// DataGridView2 설정 (Production Line 데이터)
			if (dataGridView2.Columns.Count == 0) // 중복 추가 방지
			{
				dataGridView2.Columns.Add("FACID", "FACID");
				dataGridView2.Columns.Add("LINEID", "LineID");
				dataGridView2.Columns.Add("LINENAME", "Line Name");
				dataGridView2.Columns.Add("OPERATEDATE", "Operation Date");
			}

			// 하위 버튼 생성
			CreateOptionButtons();
		}

		private void CreateOptionButtons()
		{
			// "자재 관리" 버튼
			optionButton1 = new Button();
			optionButton1.Text = "자재 관리";
			optionButton1.Location = new Point(this.Width - 120, 190); // 오른쪽 위치
			optionButton1.Size = new Size(120, 40);
			optionButton1.BackColor = Color.LightGray;
			optionButton1.FlatStyle = FlatStyle.Flat;
			optionButton1.Visible = false; // 초기에는 숨김
			optionButton1.Click += OptionButton1_Click;

			// "공정 관리" 버튼
			optionButton2 = new Button();
			optionButton2.Text = "공정 관리";
			optionButton2.Location = new Point(this.Width - 120, 240);
			optionButton2.Size = new Size(120, 40);
			optionButton2.BackColor = Color.LightGray;
			optionButton2.FlatStyle = FlatStyle.Flat;
			optionButton2.Visible = false; // 초기에는 숨김
			optionButton2.Click += OptionButton2_Click;

			// 동적으로 생성된 버튼을 폼에 추가
			this.Controls.Add(optionButton1);
			this.Controls.Add(optionButton2);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			// 버튼 가시성 토글
			areOptionButtonsVisible = !areOptionButtonsVisible;

			// "생산 정보" 버튼의 위치 기준으로 새 버튼 위치 계산
			Point baseLocation = button4.Location;
			optionButton1.Location = new Point(baseLocation.X + button4.Width + 5, baseLocation.Y);
			optionButton2.Location = new Point(baseLocation.X + button4.Width + 5, baseLocation.Y + optionButton1.Height + 5);

			// 버튼 가시성 업데이트
			optionButton1.Visible = areOptionButtonsVisible;
			optionButton2.Visible = areOptionButtonsVisible;

			// 버튼 앞으로 가져오기
			optionButton1.BringToFront();
			optionButton2.BringToFront();
		}

		private void OptionButton1_Click(object sender, EventArgs e)
		{

		}

		private void OptionButton2_Click(object sender, EventArgs e)
		{
			MessageBox.Show("기능 미구현");
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Monitoring lost = new Monitoring();
			lost.Show();
			this.Hide();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DefectRecord lost2 = new DefectRecord();
			lost2.Show();
			this.Hide();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Definition metro = new Definition();
			metro.Show();
			this.Hide();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			Dispose();
		}

		private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			Lost4 lost4 = new Lost4();
			lost4.Show();
			this.Hide();
		}

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
