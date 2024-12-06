using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grpc.Core;
using grpctestserver;
using ReaLTaiizor.Forms;
using SteelMES;

namespace Project_SteelMES
{
    public partial class ProcessManagement : Form
    {
        private Config config; //추가

        public ProcessManagement() //추가
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
				dataGridView1.Columns.Add("Weight", "무게");
				dataGridView1.Columns.Add("ProductionDate", "생산 날짜");
				dataGridView1.Columns.Add("QualityGrade", "품질 등급");
				dataGridView1.Columns.Add("DefectID", "불량 ID");
				dataGridView1.Columns.Add("FacID", "공장 ID");
			}
		}

        private async void SelectBtn_Click(object sender, EventArgs e) //수정
        {
            if (config == null || config.GrpcSettings == null)
            {
                MessageBox.Show("gRPC 설정을 불러올 수 없습니다.");
                return;
            }

            //gRPC 채널 생성
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
