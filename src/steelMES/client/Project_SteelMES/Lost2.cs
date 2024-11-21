using System;
using System.Windows.Forms;
using Grpc.Core;
using SteelMES;
using ReaLTaiizor.Forms;
using System.Drawing;

namespace Project_SteelMES
{
	public partial class Lost2 : LostForm
	{
		private Button optionButton1;
		private Button optionButton2;
		private bool areOptionButtonsVisible = false; // 가시성 상태 저장

		public Lost2()
		{
			InitializeComponent();
		}

		private void Lost2_Load(object sender, EventArgs e)
		{
			// DataGridView 설정 (최초 한 번만 호출)
			if (dataGridView1.Columns.Count == 0)
			{
				dataGridView1.Columns.Add("DefectID", "검출 ID");
				dataGridView1.Columns.Add("ProductID", "제품 ID");
				dataGridView1.Columns.Add("MaterialID", "자재 ID");
				dataGridView1.Columns.Add("DefectType", "검출 타입");
				dataGridView1.Columns.Add("DefectionDate", "검출 날짜");
				dataGridView1.Columns.Add("Location", "위치");
			}

			// 하위 버튼 생성
			CreateOptionButtons();
		}

		private async void button6_Click(object sender, EventArgs e)
		{
			var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
			var client = new DB_Service.DB_ServiceClient(channel);

			try
			{
				var fromTime = dateTimePicker1.Value.ToString("yyyy-MM-dd");
				var toTime = dateTimePicker2.Value.ToString("yyyy-MM-dd");

				var request = new prodHistoryInfoRequest
				{
					FromTime = fromTime,
					ToTime = toTime
				};

				Console.WriteLine($"Sending request: FromTime={fromTime}, ToTime={toTime}");

				var response = await client.reqProdHistoryAsync(request);

				if (response.ErrorCode == 0)
				{
					Console.WriteLine("Data received successfully.");
					dataGridView1.Rows.Clear();
					foreach (var info in response.Infos)
					{
						dataGridView1.Rows.Add(info.DefectID, info.ProductID, info.MaterialID, info.DefectType, info.DefectionDate, info.Location);
					}
				}
				else
				{
					MessageBox.Show($"서버에서 데이터를 가져오지 못했습니다. ErrorCode: {response.ErrorCode}");
					Console.WriteLine($"ErrorCode: {response.ErrorCode}");
				}
			}
			catch (RpcException ex)
			{
				MessageBox.Show($"gRPC 호출 실패: {ex.StatusCode} - {ex.Message}");
				Console.WriteLine($"RpcException: {ex.Status.Detail}");
			}
			catch (Exception ex)
			{
				MessageBox.Show($"클라이언트에서 예외 발생: {ex.Message}");
				Console.WriteLine($"Exception: {ex.Message}\nStackTrace: {ex.StackTrace}");
			}
			finally
			{
				await channel.ShutdownAsync();
				Console.WriteLine("Channel shutdown.");
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Lost lost = new Lost();
			lost.Show();
			this.Hide();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Metro metro = new Metro();
			metro.Show();
			this.Hide();
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


		private void button5_Click(object sender, EventArgs e)
		{
			Dispose();
		}
		private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex >= 0) // 유효한 행인지 확인
			{
				// 클릭한 행의 데이터를 가져오기
				var defectID = dataGridView1.Rows[e.RowIndex].Cells["DefectID"].Value.ToString();
				var productID = dataGridView1.Rows[e.RowIndex].Cells["ProductID"].Value.ToString();
				var materialID = dataGridView1.Rows[e.RowIndex].Cells["MaterialID"].Value.ToString();
				var defectType = dataGridView1.Rows[e.RowIndex].Cells["DefectType"].Value.ToString();
				var detectionDate = dataGridView1.Rows[e.RowIndex].Cells["DefectionDate"].Value.ToString();

				// Material 폼 열기
				Material materialForm = new Material
				{
					DefectID = defectID,
					ProductID = productID,
					MaterialID = materialID,
					DefectType = defectType,
					DetectionDate = detectionDate
				};

				materialForm.Show();
				this.Hide();
			}
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
			Lost3 lost3 = new Lost3();
			lost3.Show();
			this.Hide();
		}

		private void OptionButton2_Click(object sender, EventArgs e)
		{
			MessageBox.Show("기능 미구현");
		}
	}
}
