using Grpc.Core;
using grpctestserver;
using SteelMES;
using System;
using System.IO;
using System.Windows.Forms;

namespace Project_SteelMES
{
    public partial class MaterialOrder : Form
    {
        private Config config; //추가

        public MaterialOrder() //추가
        {
            InitializeComponent();

            string configFilePath = Path.Combine(Directory.GetCurrentDirectory(), "appsetting.json");
            config = ConfigLoader.LoadConfig(configFilePath);

            if (config == null || config.GrpcSettings == null)
            {
                MessageBox.Show("gRPC 설정을 로드하는 데 실패했습니다.");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OrderBtn_Click(object sender, EventArgs e)
        {
            MaterialOrder2 matOrder = new MaterialOrder2();
            matOrder.Show();
            
        }

        private async void SelectBtn_Click(object sender, EventArgs e) //수정
        {
            if (config == null || config.GrpcSettings == null)
            {
                MessageBox.Show("gRPC 설정을 불러올 수 없습니다.");
                return;
            }

            var channel = new Channel($"{config.GrpcSettings.Host}:{config.GrpcSettings.Port}", ChannelCredentials.Insecure);
            var client = new DB_Service.DB_ServiceClient(channel);

            try
            {
                // gRPC 서버에서 Supplier 데이터를 가져옴
                var responseMat = await client.GetMaterialDataAsync(new Empty());
                var responseSup = await client.GetSupplierDataAsync(new Empty());

                if (responseMat.ErrorCode != 0)
                {
                    MessageBox.Show($"서버 오류 코드: {responseMat.ErrorCode}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // DataGridView 초기화
                dataGridView1.Rows.Clear();

                foreach (var material in responseMat.Materials)
                {
                    dataGridView1.Rows.Add(
                         material.MaterialID,
                         material.MaterialName,
                         material.SupplierName,
                         material.Quantity,
                         material.ImportDate
                    );
                }
                dataGridView2.Rows.Clear();
                foreach (var supplier in responseSup.Suppliers)
                {
                    dataGridView2.Rows.Add(
                         supplier.SupplierID,
                         supplier.SupplierName,
                         supplier.ContactInfo,
                         supplier.Country
                    );
                }
            }
            catch (RpcException ex)
            {
                MessageBox.Show($"gRPC 호출 실패: {ex.Status.Detail}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                await channel.ShutdownAsync();
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            

        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //수정
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
                // gRPC 서버에서 Supplier 데이터를 가져옴
                var response = await client.GetSupplierDataAsync(new Empty());
                

                if (response.ErrorCode != 0)
                {
                    MessageBox.Show($"서버 오류 코드: {response.ErrorCode}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                comboBox1.Items.Clear();

                foreach (var supplier in response.Suppliers)
                {
                    comboBox1.Items.Add(supplier.SupplierName.ToString());
                }
            }
            catch (RpcException ex)
            {
                MessageBox.Show($"gRPC 호출 실패: {ex.Status.Detail}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                await channel.ShutdownAsync();
            }
        }

        private async void comboBox2_SelectedIndexChanged(object sender, EventArgs e) //수정
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
                // gRPC 서버에서 Supplier 데이터를 가져옴
                var response = await client.GetMaterialDataAsync(new Empty());


                if (response.ErrorCode != 0)
                {
                    MessageBox.Show($"서버 오류 코드: {response.ErrorCode}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                comboBox2.Items.Clear();

                foreach (var material in response.Materials)
                {
                    comboBox2.Items.Add(material.MaterialName.ToString());
                }
            }
            catch (RpcException ex)
            {
                MessageBox.Show($"gRPC 호출 실패: {ex.Status.Detail}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                await channel.ShutdownAsync();
            }
        }

        private void MaterialOrder_Load(object sender, EventArgs e)
        {

        }

        //private void ViewSupBtn_Click(object sender, EventArgs e)
        //{

        //}
    }
}
