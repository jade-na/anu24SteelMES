using System;
using System.IO;
using System.Windows.Forms;
using Grpc.Core;
using grpctestserver;
using SteelMES;

namespace Project_SteelMES
{
	public partial class Work : Form
	{
		private readonly DB_Service.DB_ServiceClient _client;
		private readonly Channel _channel;

        private Config config; //추가

        public Work() //수정
		{
			InitializeComponent();

            string configFilePath = Path.Combine(Directory.GetCurrentDirectory(), "appsetting.json");
            config = ConfigLoader.LoadConfig(configFilePath);

            if (config == null || config.GrpcSettings == null)
            {
                MessageBox.Show("gRPC 설정을 로드하는 데 실패했습니다.");
                return;
            }

            var channel = new Channel($"{config.GrpcSettings.Host}:{config.GrpcSettings.Port}", ChannelCredentials.Insecure);
            _client = new DB_Service.DB_ServiceClient(channel);

            // 초기 데이터 로딩
            LoadFactoryList();
			InitializeProductComboBox();
			InitializeDataGridView();
		}

		// DataGridView 초기화 메서드
		private void InitializeDataGridView()
		{
			// DataGridView 컬럼 초기화
			dataGridView1.Columns.Clear();
			dataGridView1.Rows.Clear();

			// 컬럼 추가 (제품명, 수량, 공장명, 작업 시작 날짜)
			dataGridView1.Columns.Add("ProductName", "제품명");
			dataGridView1.Columns.Add("Quantity", "수량");
			dataGridView1.Columns.Add("FactoryName", "공장명");
			dataGridView1.Columns.Add("ProductionDate", "작업 시작 날짜");
		}

		// 제품 목록을 ComboBox1에 설정하는 메서드
		private void InitializeProductComboBox()
		{
			// 정해진 제품 리스트 추가 (수동으로 정해진 값들)
			var productList = new[] { "Steel Beam", "Heavy Plate", "Cold Rolled Coil", "Hot Rolled Coil" };
			comboBox1.Items.Clear();
			comboBox1.Items.AddRange(productList);
		}

		// 공장 목록을 ComboBox3에 로드하는 메서드
		private async void LoadFactoryList()
		{
			try
			{
				var factoryReply = await _client.GetFactoryDataAsync(new Empty());
				if (factoryReply.ErrorCode == 0)
				{
					comboBox3.Items.Clear();
					foreach (var factory in factoryReply.Factories)
					{
						comboBox3.Items.Add(new ComboBoxItem(factory.FacName, factory.FacID));
					}
				}
				else
				{
					MessageBox.Show("Failed to load factory list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (RpcException ex)
			{
				MessageBox.Show($"Failed to load factory list: {ex.Status.Detail}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// SelectBtn 클릭 이벤트 (DataGridView에 조회된 데이터를 추가)
		private void button8_Click(object sender, EventArgs e) // SelectBtn
		{
			string comboBox1Value = comboBox1.SelectedItem?.ToString();
			string numericUpDown7Value = numericUpDown7.Value.ToString();
			ComboBoxItem comboBox3Value = comboBox3.SelectedItem as ComboBoxItem;

			// 입력값 확인 및 유효성 검증
			if (string.IsNullOrWhiteSpace(comboBox1Value))
			{
				MessageBox.Show("제품을 선택해주세요.", "입력 확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (numericUpDown7.Value == 0)
			{
				MessageBox.Show("수량은 0보다 커야 합니다.", "입력 확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (comboBox3Value == null)
			{
				MessageBox.Show("공장을 선택해주세요.", "입력 확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// DataGridView에 새 행 추가 (제품명, 수량, 공장명, 작업 시작 날짜)
			dataGridView1.Rows.Add(comboBox1Value, numericUpDown7Value, comboBox3Value.Text);
		}

		// WorkBtn 클릭 이벤트 (작업지시 전송)
		private async void button9_Click(object sender, EventArgs e) // WorkBtn
		{
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				if (row.IsNewRow)
				{
					continue;
				}

				string productName = row.Cells[0].Value?.ToString();
				if (string.IsNullOrEmpty(productName))
				{
					continue; // 빈 행은 무시
				}

				int quantity;
				if (!int.TryParse(row.Cells[1].Value?.ToString(), out quantity) || quantity <= 0)
				{
					MessageBox.Show($"잘못된 수량 값입니다. 행 번호: {row.Index + 1}", "입력 확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					continue;
				}

				string factoryName = row.Cells[2].Value?.ToString();
				ComboBoxItem factory = FindFactoryByName(factoryName);

				if (factory == null)
				{
					MessageBox.Show($"유효하지 않은 공장명: {factoryName}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					continue;
				}

				var request = new ProductOrderRequest
				{
					ProductName = productName,
					Quantity = quantity,
					FactoryId = factory.Value,
				};

				try
				{
					var response = await _client.CreateProductOrderAsync(request);
					if (response.ErrorCode == 0)
					{
						MessageBox.Show($"작업지시 생성 성공. 제품: {productName}, 수량: {quantity}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						MessageBox.Show($"작업지시 생성 실패. 오류: {response.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				catch (RpcException ex)
				{
					MessageBox.Show($"RPC 오류 발생: {ex.Status.Detail}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		// Factory Name으로 ComboBoxItem 찾기
		private ComboBoxItem FindFactoryByName(string factoryName)
		{
			foreach (ComboBoxItem item in comboBox3.Items)
			{
				if (item.Text == factoryName)
				{
					return item;
				}
			}
			return null;
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			// gRPC Core 채널을 닫기
			_channel.ShutdownAsync().Wait();
			base.OnFormClosing(e);
		}

        private void Work_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Work_Load_1(object sender, EventArgs e)
        {

        }
    }

    // 공장 선택 시 사용되는 ComboBoxItem 클래스
    public class ComboBoxItem
	{
		public string Text { get; }
		public int Value { get; }

		public ComboBoxItem(string text, int value)
		{
			Text = text;
			Value = value;
		}

		public override string ToString()
		{
			return Text;
		}
	}
}
