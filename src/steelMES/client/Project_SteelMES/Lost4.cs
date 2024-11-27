using System;
using System.Drawing;
using System.Windows.Forms;
using Grpc.Core;
using ReaLTaiizor.Forms;
using SteelMES;

namespace Project_SteelMES
{
	public partial class Lost4 : LostForm
	{
		private bool materialDataLoaded = false; // MATERIAL 데이터 로드 상태
		private bool supplierDataLoaded = false; // SUPPLIER 데이터 로드 상태

		public Lost4()
		{
			InitializeComponent();
		}

		private void Lost4_Load(object sender, EventArgs e)
		{
			// 초기 상태에서 열만 정의
			InitializeMaterialColumns();
		}

		private void InitializeMaterialColumns()
		{
			if (dataGridView1.Columns["MATERIALID"] == null)
			{
				dataGridView1.Columns.Clear();
				dataGridView1.Columns.Add("MATERIALID", "자재ID");
				dataGridView1.Columns.Add("MATERIALNAME", "자재명");
				dataGridView1.Columns.Add("SUPPLIERID", "공급ID");
				dataGridView1.Columns.Add("QUANTITY", "수량");
				dataGridView1.Columns.Add("IMPORTDATE", "수입날짜");
			}
		}

		private async void button6_Click(object sender, EventArgs e)
		{
            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
            var client = new DB_Service.DB_ServiceClient(channel);

            // MATERIAL 데이터를 처음 한 번만 로드
            if (materialDataLoaded)
			{
				MessageBox.Show("MATERIAL 데이터는 이미 로드되었습니다.");
				return;
			}

			try
			{
				// MATERIAL 데이터를 가져오는 요청
				var response = await client.GetMaterialDataAsync(new SteelMES.Empty());

				foreach (var material in response.Materials)
				{
					dataGridView1.Rows.Add(
						material.MaterialID,
						material.MaterialName,
						material.SupplierID,
						material.Quantity,
						material.ImportDate
					);
				}

				materialDataLoaded = true; // 데이터 로드 상태 업데이트
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
		private async void button8_Click(object sender, EventArgs e)
		{
			// SUPPLIER 데이터를 처음 한 번만 로드
			if (supplierDataLoaded)
			{
				MessageBox.Show("SUPPLIER 데이터는 이미 로드되었습니다.");
				return;
			}

			var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
			var client = new DB_Service.DB_ServiceClient(channel);

			try
			{
				// SUPPLIER 데이터를 가져오는 요청
				var response = await client.GetSupplierDataAsync(new SteelMES.Empty());

				foreach (var supplier in response.Suppliers)
				{
					dataGridView2.Rows.Add(
						supplier.SupplierID,
						supplier.SupplierName,
						supplier.ContactInfo,
						supplier.Country
					);
				}

				supplierDataLoaded = true; // 데이터 로드 상태 업데이트
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


		private async void button7_Click(object sender, EventArgs e)
		{
			// 텍스트박스에서 입력 값 가져오기
			int[] quantities = new int[6];
			try
			{
				quantities[0] = string.IsNullOrEmpty(textBox1.Text) ? 0 : int.Parse(textBox1.Text);
				quantities[1] = string.IsNullOrEmpty(textBox2.Text) ? 0 : int.Parse(textBox2.Text);
				quantities[2] = string.IsNullOrEmpty(textBox3.Text) ? 0 : int.Parse(textBox3.Text);
				quantities[3] = string.IsNullOrEmpty(textBox4.Text) ? 0 : int.Parse(textBox4.Text);
				quantities[4] = string.IsNullOrEmpty(textBox5.Text) ? 0 : int.Parse(textBox5.Text);
				quantities[5] = string.IsNullOrEmpty(textBox6.Text) ? 0 : int.Parse(textBox6.Text);
			}
			catch
			{
				MessageBox.Show("숫자만 입력해주세요.");
				return;
			}

			// gRPC 서버와 통신하여 데이터 업데이트
			var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
			var client = new DB_Service.DB_ServiceClient(channel);

			try
			{
				for (int i = 0; i < quantities.Length; i++)
				{
					if (quantities[i] > 0) // 값이 0보다 큰 경우만 업데이트
					{
						var request = new UpdateMaterialQuantityRequest
						{
							MaterialID = 101 + i, // MATERIALID는 101부터 시작
							AdditionalQuantity = quantities[i]
						};

						var response = await client.UpdateMaterialQuantityAsync(request);

						if (response.ErrorCode == 0)
						{
							// DataGridView 업데이트
							foreach (DataGridViewRow row in dataGridView1.Rows)
							{
								if (row.Cells["MATERIALID"].Value != null &&
									row.Cells["MATERIALID"].Value.ToString() == request.MaterialID.ToString())
								{
									int currentQuantity = int.Parse(row.Cells["QUANTITY"].Value.ToString());
									row.Cells["QUANTITY"].Value = currentQuantity + request.AdditionalQuantity;
								}
							}
						}
						else
						{
							MessageBox.Show($"MATERIALID {request.MaterialID} 업데이트 실패.");
						}
					}
				}

				MessageBox.Show("수량이 성공적으로 업데이트되었습니다.");
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

		private void button9_Click(object sender, EventArgs e)
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
			Lost3 lost3 = new Lost3();
			lost3.Show();
			this.Hide();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			Dispose();
		}
	}
}
