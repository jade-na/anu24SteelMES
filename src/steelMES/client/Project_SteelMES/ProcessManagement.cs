using System;
using System.IO;
using System.Windows.Forms;
using Grpc.Core;
using grpctestserver;
using PiControlService;
using SteelMES;

namespace Project_SteelMES
{
	public partial class ProcessManagement : Form
	{
		private Config config; // gRPC 설정 로드용
		private int selectedProductId; // 선택된 제품 ID
		private string selectedProductName; // 선택된 제품 이름
		private int quantity; // 선택된 수량

		public ProcessManagement()
		{
			InitializeComponent();

			// JSON 설정 파일 경로
			string configFilePath = Path.Combine(Directory.GetCurrentDirectory(), "appsetting.json");
			config = ConfigLoader.LoadConfig(configFilePath);

			if (config == null || config.GrpcSettings == null)
			{
				MessageBox.Show("gRPC 설정을 로드하는 데 실패했습니다.");
			}
		}

		private void Lost5_Load(object sender, EventArgs e)
		{
			// DataGridView 설정 (최초 한 번만 호출)
			if (dataGridView1.Columns.Count == 0)
			{
				dataGridView1.Columns.Add("ProductID", "제품 ID");
				dataGridView1.Columns.Add("ProductName", "제품명");
				dataGridView1.Columns.Add("Quantity", "수량");
				dataGridView1.Columns.Add("ProductionDate", "생산 날짜");
				dataGridView1.Columns.Add("QualityGrade", "품질 등급");
				dataGridView1.Columns.Add("DefectID", "불량 ID");
				dataGridView1.Columns.Add("FacID", "공장 ID");
			}
		}

		private async void SelectBtn_Click(object sender, EventArgs e)
		{
			if (config == null || config.GrpcSettings == null)
			{
				MessageBox.Show("gRPC 설정을 불러올 수 없습니다.");
				return;
			}

			// gRPC 채널 생성
			var channel = new Channel($"{config.GrpcSettings.Host}:{config.GrpcSettings.Port}", ChannelCredentials.Insecure);
			var client = new DB_Service.DB_ServiceClient(channel);

			try
			{
				var response = await client.GetAllProductDataAsync(new Empty());

				if (response.ErrorCode != 0)
				{
					MessageBox.Show($"서버 오류 코드: {response.ErrorCode}");
					return;
				}

				dataGridView1.Rows.Clear();

				foreach (var product in response.Products)
				{
					dataGridView1.Rows.Add(
						product.ProductID,
						product.ProductName,
						product.Quantity,
						product.ProductionDate,
						product.QualityGrade,
						product.DefectID,
						product.FacID
					);
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

		private async void DefectBtn_Click(object sender, EventArgs e)
		{
			if (selectedProductId <= 0 || quantity <= 0)
			{
				MessageBox.Show("제품 ID와 수량을 입력하세요.");
				return;
			}

			var channel = new Channel("192.168.0.118:50052", ChannelCredentials.Insecure); // Python 서버 주소
			var client = new PiControlService.PiControlServiceClient(channel);

			try
			{
				var response = await client.StartInspectionAsync(new PiRequest
				{
					ProductId = selectedProductId.ToString(),
					Quantity = quantity
				});

				MessageBox.Show(response.ErrorCode == 0
					? $"작업 성공: {response.Message}"
					: $"작업 실패: {response.Message}");
			}
			catch (RpcException ex)
			{
				MessageBox.Show($"Pi 호출 실패: {ex.Status.Detail}");
			}
			finally
			{
				await channel.ShutdownAsync();
			}
		}

		private void UpdateProgressBar(int step)
		{
			switch (step)
			{
				case 1:
					progressBar1.Value = 100;
					break;
				case 2:
					progressBar2.Value = 100;
					break;
				case 3:
					progressBar3.Value = 100;
					break;
				case 4:
					progressBar4.Value = 100;
					break;
			}
		}

		private void ResetProgressBars()
		{
			progressBar1.Value = 0;
			progressBar2.Value = 0;
			progressBar3.Value = 0;
			progressBar4.Value = 0;
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

				try
				{
					selectedProductId = Convert.ToInt32(selectedRow.Cells["ProductID"].Value);
					selectedProductName = selectedRow.Cells["ProductName"].Value.ToString();
					quantity = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);

					Console.WriteLine($"Selected ProductID={selectedProductId}, ProductName={selectedProductName}, Quantity={quantity}");
				}
				catch (Exception ex)
				{
					MessageBox.Show($"선택된 데이터가 올바르지 않습니다: {ex.Message}");
				}
			}
		}
	}
}
