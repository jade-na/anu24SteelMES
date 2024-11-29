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
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace Project_SteelMES
{
    public partial class MaterialOrder2 : PoisonForm
    {
        public MaterialOrder2()
        {
            InitializeComponent();

            // 위치 고정 설정
            this.StartPosition = FormStartPosition.Manual; // 위치를 수동으로 설정
            this.Location = new Point(1200, 250); // (300, 200) 위치에 폼 배치

            
            
        }

        private void OrderBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void MaterialOrder2_Load(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dungeonLabel1_Click(object sender, EventArgs e)
        {

        }

        private async void button6_Click(object sender, EventArgs e)
        {
            // 콤보박스에서 선택한 공급업체명
            string selectedSupplier = comboBox5.SelectedItem?.ToString();  // Null 체크
                                                                           // 라벨에서 원자재 이름 가져오기
            string materialName = label6.Text;  // 라벨에서 원자재 이름 가져오기
                                                // NumericUpDown에서 선택한 원자재 갯수
            int rawMaterialQuantity = (int)numericUpDown5.Value;  // 갯수 선택

            // 유효성 검사: 선택된 공급업체가 없거나 갯수가 0 이하인 경우
            if (string.IsNullOrEmpty(selectedSupplier) || rawMaterialQuantity <= 0)
            {
                MessageBox.Show("올바른 값을 입력해주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // gRPC 서버에 연결
            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);  // 서버 주소와 포트
            var client = new DB_Service.DB_ServiceClient(channel);

            try
            {
                // AddMaterialRequest 객체 생성
                var request = new AddMaterialRequest
                {
                    MaterialName = materialName,  // 라벨에서 원자재 이름
                    SupplierName = selectedSupplier,  // 콤보박스에서 선택한 공급업체
                    Quantity = rawMaterialQuantity  // NumericUpDown에서 선택한 원자재 갯수
                };

                // gRPC 서버에 요청 전송
                var response = await client.AddMaterialAsync(request);

                // 서버 응답 처리
                if (response.ErrorCode == 0)  // 서버에서 정상적으로 처리된 경우
                {
                    MessageBox.Show("원자재 등록 성공!\n" +
                                    $"Material ID: {response.MaterialID}", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else  // 서버에서 오류가 발생한 경우
                {
                    MessageBox.Show($"원자재 등록 실패: {response.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (RpcException ex)  // gRPC 호출 실패 시 예외 처리
            {
                MessageBox.Show($"gRPC 호출 실패: {ex.Status.Detail}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // gRPC 채널 종료
                await channel.ShutdownAsync();
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void button5_Click(object sender, EventArgs e)
        {
            // 콤보박스에서 선택한 공급업체명
            string selectedSupplier = comboBox4.SelectedItem?.ToString();  // Null 체크
                                                                           // 라벨에서 원자재 이름 가져오기
            string materialName = label5.Text;  // 라벨에서 원자재 이름 가져오기
                                                // NumericUpDown에서 선택한 원자재 갯수
            int rawMaterialQuantity = (int)numericUpDown4.Value;  // 갯수 선택

            // 유효성 검사: 선택된 공급업체가 없거나 갯수가 0 이하인 경우
            if (string.IsNullOrEmpty(selectedSupplier) || rawMaterialQuantity <= 0)
            {
                MessageBox.Show("올바른 값을 입력해주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // gRPC 서버에 연결
            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);  // 서버 주소와 포트
            var client = new DB_Service.DB_ServiceClient(channel);

            try
            {
                // AddMaterialRequest 객체 생성
                var request = new AddMaterialRequest
                {
                    MaterialName = materialName,  // 라벨에서 원자재 이름
                    SupplierName = selectedSupplier,  // 콤보박스에서 선택한 공급업체
                    Quantity = rawMaterialQuantity  // NumericUpDown에서 선택한 원자재 갯수
                };

                // gRPC 서버에 요청 전송
                var response = await client.AddMaterialAsync(request);

                // 서버 응답 처리
                if (response.ErrorCode == 0)  // 서버에서 정상적으로 처리된 경우
                {
                    MessageBox.Show("원자재 등록 성공!\n" +
                                    $"Material ID: {response.MaterialID}", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else  // 서버에서 오류가 발생한 경우
                {
                    MessageBox.Show($"원자재 등록 실패: {response.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (RpcException ex)  // gRPC 호출 실패 시 예외 처리
            {
                MessageBox.Show($"gRPC 호출 실패: {ex.Status.Detail}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // gRPC 채널 종료
                await channel.ShutdownAsync();
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            // 콤보박스에서 선택한 공급업체명
            string selectedSupplier = comboBox3.SelectedItem?.ToString();  // Null 체크
                                                                           // 라벨에서 원자재 이름 가져오기
            string materialName = label3.Text;  // 라벨에서 원자재 이름 가져오기
                                                // NumericUpDown에서 선택한 원자재 갯수
            int rawMaterialQuantity = (int)numericUpDown3.Value;  // 갯수 선택

            // 유효성 검사: 선택된 공급업체가 없거나 갯수가 0 이하인 경우
            if (string.IsNullOrEmpty(selectedSupplier) || rawMaterialQuantity <= 0)
            {
                MessageBox.Show("올바른 값을 입력해주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // gRPC 서버에 연결
            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);  // 서버 주소와 포트
            var client = new DB_Service.DB_ServiceClient(channel);

            try
            {
                // AddMaterialRequest 객체 생성
                var request = new AddMaterialRequest
                {
                    MaterialName = materialName,  // 라벨에서 원자재 이름
                    SupplierName = selectedSupplier,  // 콤보박스에서 선택한 공급업체
                    Quantity = rawMaterialQuantity  // NumericUpDown에서 선택한 원자재 갯수
                };

                // gRPC 서버에 요청 전송
                var response = await client.AddMaterialAsync(request);

                // 서버 응답 처리
                if (response.ErrorCode == 0)  // 서버에서 정상적으로 처리된 경우
                {
                    MessageBox.Show("원자재 등록 성공!\n" +
                                    $"Material ID: {response.MaterialID}", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else  // 서버에서 오류가 발생한 경우
                {
                    MessageBox.Show($"원자재 등록 실패: {response.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (RpcException ex)  // gRPC 호출 실패 시 예외 처리
            {
                MessageBox.Show($"gRPC 호출 실패: {ex.Status.Detail}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // gRPC 채널 종료
                await channel.ShutdownAsync();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            // 콤보박스에서 선택한 공급업체명
            string selectedSupplier = comboBox2.SelectedItem?.ToString();  // Null 체크
                                                                           // 라벨에서 원자재 이름 가져오기
            string materialName = label3.Text;  // 라벨에서 원자재 이름 가져오기
                                                // NumericUpDown에서 선택한 원자재 갯수
            int rawMaterialQuantity = (int)numericUpDown3.Value;  // 갯수 선택

            // 유효성 검사: 선택된 공급업체가 없거나 갯수가 0 이하인 경우
            if (string.IsNullOrEmpty(selectedSupplier) || rawMaterialQuantity <= 0)
            {
                MessageBox.Show("올바른 값을 입력해주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // gRPC 서버에 연결
            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);  // 서버 주소와 포트
            var client = new DB_Service.DB_ServiceClient(channel);

            try
            {
                // AddMaterialRequest 객체 생성
                var request = new AddMaterialRequest
                {
                    MaterialName = materialName,  // 라벨에서 원자재 이름
                    SupplierName = selectedSupplier,  // 콤보박스에서 선택한 공급업체
                    Quantity = rawMaterialQuantity  // NumericUpDown에서 선택한 원자재 갯수
                };

                // gRPC 서버에 요청 전송
                var response = await client.AddMaterialAsync(request);

                // 서버 응답 처리
                if (response.ErrorCode == 0)  // 서버에서 정상적으로 처리된 경우
                {
                    MessageBox.Show("원자재 등록 성공!\n" +
                                    $"Material ID: {response.MaterialID}", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else  // 서버에서 오류가 발생한 경우
                {
                    MessageBox.Show($"원자재 등록 실패: {response.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (RpcException ex)  // gRPC 호출 실패 시 예외 처리
            {
                MessageBox.Show($"gRPC 호출 실패: {ex.Status.Detail}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // gRPC 채널 종료
                await channel.ShutdownAsync();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // 콤보박스에서 선택한 공급업체명
            string selectedSupplier = SupplyOption1.SelectedItem?.ToString();  // Null 체크
                                                                             
            string materialName = label1.Text;  // 라벨에서 원자재 이름 가져오기
                                                // NumericUpDown에서 선택한 원자재 갯수
            int rawMaterialQuantity = (int)numericUpDown1.Value;  // 갯수 선택

            // 유효성 검사: 선택된 공급업체가 없거나 갯수가 0 이하인 경우
            if (string.IsNullOrEmpty(selectedSupplier) || rawMaterialQuantity <= 0)
            {
                MessageBox.Show("올바른 값을 입력해주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // gRPC 서버에 연결
            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);  // 서버 주소와 포트
            var client = new DB_Service.DB_ServiceClient(channel);

            try
            {
                // AddMaterialRequest 객체 생성
                var request = new AddMaterialRequest
                {
                    MaterialName = materialName,  // 라벨에서 원자재 이름
                    SupplierName = selectedSupplier,  // 콤보박스에서 선택한 공급업체
                    Quantity = rawMaterialQuantity  // NumericUpDown에서 선택한 원자재 갯수
                };

                // gRPC 서버에 요청 전송
                var response = await client.AddMaterialAsync(request);

                // 서버 응답 처리
                if (response.ErrorCode == 0)  // 서버에서 정상적으로 처리된 경우
                {
                    MessageBox.Show("원자재 등록 성공!\n" +
                                    $"Material ID: {response.MaterialID}", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else  // 서버에서 오류가 발생한 경우
                {
                    MessageBox.Show($"원자재 등록 실패: {response.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (RpcException ex)  // gRPC 호출 실패 시 예외 처리
            {
                MessageBox.Show($"gRPC 호출 실패: {ex.Status.Detail}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // gRPC 채널 종료
                await channel.ShutdownAsync();
            }
        }

        private void SupplyOption1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // 콤보박스에서 선택한 공급업체명
            string selectedSupplier = comboBox1.SelectedItem?.ToString();  // Null 체크
                                                                               // 라벨에서 원자재 이름 가져오기
            string materialName = label2.Text;  // 라벨에서 원자재 이름 가져오기
                                                // NumericUpDown에서 선택한 원자재 갯수
            int rawMaterialQuantity = (int)numericUpDown2.Value;  // 갯수 선택

            // 유효성 검사: 선택된 공급업체가 없거나 갯수가 0 이하인 경우
            if (string.IsNullOrEmpty(selectedSupplier) || rawMaterialQuantity <= 0)
            {
                MessageBox.Show("올바른 값을 입력해주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // gRPC 서버에 연결
            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);  // 서버 주소와 포트
            var client = new DB_Service.DB_ServiceClient(channel);

            try
            {
                // AddMaterialRequest 객체 생성
                var request = new AddMaterialRequest
                {
                    MaterialName = materialName,  // 라벨에서 원자재 이름
                    SupplierName = selectedSupplier,  // 콤보박스에서 선택한 공급업체
                    Quantity = rawMaterialQuantity  // NumericUpDown에서 선택한 원자재 갯수
                };

                // gRPC 서버에 요청 전송
                var response = await client.AddMaterialAsync(request);

                // 서버 응답 처리
                if (response.ErrorCode == 0)  // 서버에서 정상적으로 처리된 경우
                {
                    MessageBox.Show("원자재 등록 성공!\n" +
                                    $"Material ID: {response.MaterialID}", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else  // 서버에서 오류가 발생한 경우
                {
                    MessageBox.Show($"원자재 등록 실패: {response.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (RpcException ex)  // gRPC 호출 실패 시 예외 처리
            {
                MessageBox.Show($"gRPC 호출 실패: {ex.Status.Detail}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // gRPC 채널 종료
                await channel.ShutdownAsync();
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void SupplyOption1_DropDown(object sender, EventArgs e) //콤보박스 옆에 화살표 눌렀을 때
        {
            // gRPC 채널 생성
            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
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

                SupplyOption1.Items.Clear();

                foreach (var material in response.Suppliers)
                {
                    SupplyOption1.Items.Add(material.SupplierName.ToString());
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

        private async void comboBox1_DropDown(object sender, EventArgs e)
        {
            // gRPC 채널 생성
            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
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

                foreach (var material in response.Suppliers)
                {
                    comboBox1.Items.Add(material.SupplierName.ToString());
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

        private async void comboBox2_DropDown(object sender, EventArgs e)
        {
            // gRPC 채널 생성
            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
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

                comboBox2.Items.Clear();

                foreach (var material in response.Suppliers)
                {
                    comboBox2.Items.Add(material.SupplierName.ToString());
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

        private async void comboBox3_DropDown(object sender, EventArgs e)
        {
            // gRPC 채널 생성
            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
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

                comboBox3.Items.Clear();

                foreach (var material in response.Suppliers)
                {
                    comboBox3.Items.Add(material.SupplierName.ToString());
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

        private async void comboBox4_DropDown(object sender, EventArgs e)
        {
            // gRPC 채널 생성
            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
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

                comboBox4.Items.Clear();

                foreach (var material in response.Suppliers)
                {
                    comboBox4.Items.Add(material.SupplierName.ToString());
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

        private async void comboBox5_DropDown(object sender, EventArgs e)
        {
            // gRPC 채널 생성
            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
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

                comboBox5.Items.Clear();

                foreach (var material in response.Suppliers)
                {
                    comboBox5.Items.Add(material.SupplierName.ToString());
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
    }
}
