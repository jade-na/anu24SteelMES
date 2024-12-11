using Grpc.Core;
using grpctestserver;
using ReaLTaiizor.Child.Material;
using SteelMES;
using System;
using System.IO;
using System.Runtime.Remoting.Channels;
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

        private async void SelectBtn_Click(object sender, EventArgs e) //조회 버튼 //수정
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
                // gRPC 서버에서 Material 데이터를 가져옴
                var responseMat = await client.GetMaterialDataAsync(new Empty());

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

                // gRPC 서버에서 Supplier 데이터를 가져옴
                var responseSup = await client.GetSupplierDataAsync(new Empty());

                if (responseSup.ErrorCode != 0)
                {
                    MessageBox.Show($"서버 오류 코드: {responseSup.ErrorCode}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dataGridView2.Rows.Clear();
                foreach (var supplier in responseSup.Suppliers)
                {
                    dataGridView2.Rows.Add(
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

        private async void SearchButton_Click(object sender, EventArgs e) //검색 버튼
        {
            // 공급업체명
            // 공급업체명
            string supplierName = comboBox1.SelectedItem?.ToString() ?? comboBox1.Text.Trim();
            string materialName = comboBox2.SelectedItem?.ToString() ?? comboBox2.Text.Trim();
            string importDate = dateTimePicker1.Value.ToString("yyyy-MM-dd"); // DateTimePicker에서 선택된 날짜

            if (config == null || config.GrpcSettings == null)
            {
                MessageBox.Show("gRPC 설정을 불러올 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Debug: 입력값 확인
            Console.WriteLine($"SupplierName: {supplierName}, MaterialName: {materialName}, ImportDate: {importDate}");

            var channel = new Channel($"{config.GrpcSettings.Host}:{config.GrpcSettings.Port}", ChannelCredentials.Insecure);
            var client = new DB_Service.DB_ServiceClient(channel);

            try
            {
                // gRPC 요청 객체 생성
                var request = new MaterialSearchRequest
                {
                    SupplierName = supplierName,
                    MaterialName = materialName,
                    ImportDate = importDate
                };

                // gRPC 서버에 요청
                var response = await client.GetMaterialSearchDataAsync(request);

                // 응답 확인
                if (response == null)
                {
                    MessageBox.Show("서버 응답이 null입니다. 서버를 확인하세요.", "서버 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (response.ErrorCode != 0)
                {
                    MessageBox.Show($"서버 오류 발생.\n오류 코드: {response.ErrorCode}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (response.Materials == null || response.Materials.Count == 0)
                {
                    MessageBox.Show("검색 결과가 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // DataGridView 초기화
                dataGridView1.Rows.Clear();

                // 검색 결과 표시
                foreach (var material in response.Materials)
                {
                    Console.WriteLine($"MaterialID: {material.MaterialID}, MaterialName: {material.MaterialName}");
                    dataGridView1.Rows.Add(
                        material.MaterialID,
                        material.MaterialName,
                        material.SupplierName,
                        material.Quantity,
                        material.ImportDate
                    );
                }

                MessageBox.Show("검색이 완료되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (RpcException ex)
            {
                MessageBox.Show($"gRPC 호출 실패:\n상세 정보: {ex.Status.Detail}\n상태 코드: {ex.StatusCode}", "통신 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"예기치 않은 오류가 발생했습니다: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                await channel.ShutdownAsync();
            }
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
