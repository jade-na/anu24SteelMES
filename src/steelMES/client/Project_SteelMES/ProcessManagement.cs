using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grpc.Core;
using ReaLTaiizor.Forms;
using SteelMES;

namespace Project_SteelMES
{
    public partial class ProcessManagement : Form
    {
        public ProcessManagement()
        {
            InitializeComponent();
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

        private async void SelectBtn_Click(object sender, EventArgs e)
        {
			var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
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
						product.Weight,
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
    }
}
