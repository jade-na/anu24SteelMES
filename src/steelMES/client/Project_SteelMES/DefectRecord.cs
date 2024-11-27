using System;
using System.Windows.Forms;
using Grpc.Core;
using SteelMES;
using ReaLTaiizor.Forms;
using System.Drawing;

namespace Project_SteelMES
{
	public partial class DefectRecord : Form
	{
		public DefectRecord()
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
				dataGridView1.Columns.Add("DefectType", "검출 타입");
				dataGridView1.Columns.Add("DefectionDate", "검출 날짜");
			}

			
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
						dataGridView1.Rows.Add(info.DefectID, info.ProductID, info.DefectType, info.DefectionDate);
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
			Monitoring lost = new Monitoring();
			lost.Show();
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

		private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex >= 0) // 유효한 행인지 확인
			{
				// 클릭한 행의 데이터를 가져오기
				var defectID = dataGridView1.Rows[e.RowIndex].Cells["DefectID"].Value.ToString();
				var productID = dataGridView1.Rows[e.RowIndex].Cells["ProductID"].Value.ToString();
				var defectType = dataGridView1.Rows[e.RowIndex].Cells["DefectType"].Value.ToString();
				var detectionDate = dataGridView1.Rows[e.RowIndex].Cells["DefectionDate"].Value.ToString();

				// Material 폼 열기
				DefectRecord2 materialForm = new DefectRecord2
				{
					DefectID = defectID,
					ProductID = productID,
					DefectType = defectType,
					DetectionDate = detectionDate
				};

				materialForm.Show();
				this.Hide();
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			
		}

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dungeonLabel2_Click(object sender, EventArgs e)
        {

        }

        private void dungeonLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}
