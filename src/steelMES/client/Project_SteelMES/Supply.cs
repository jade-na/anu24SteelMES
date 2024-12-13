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
using Grpc.Net.Client;
using grpctestserver;
using Oracle.ManagedDataAccess.Client;
using ReaLTaiizor.Forms;
using SteelMES;

namespace Project_SteelMES
{
    public partial class Supply : LostForm
    {
        private int? seletedID; // 클릭된 FacID를 저장하는 변수

        private Config config; //추가

        //// Oracle 연결 문자열
        //private string connectionString = "User Id=scott;Password=tiger;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));";

        public Supply()
        {
            InitializeComponent();

            string configFilePath = Path.Combine(Directory.GetCurrentDirectory(), "appsetting.json");
            config = ConfigLoader.LoadConfig(configFilePath);

            if (config == null || config.GrpcSettings == null)
            {
                MessageBox.Show("gRPC 설정을 로드하는 데 실패했습니다.");
            }
        }

        private void Lost7_Load(object sender, EventArgs e)
        {
            // 폼 시작 위치를 사용자 정의로 설정
            this.StartPosition = FormStartPosition.Manual;
            // 폼의 위치를 고정된 좌표로 설정
            this.Location = new Point(320, 220);

            // DataGridView 설정 (최초 한 번만 호출)
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("SupplierID", "공급업체 ID");
                dataGridView1.Columns.Add("SupplierName", "공급업체");
                dataGridView1.Columns.Add("ContactInfo", "연락처");
                dataGridView1.Columns.Add("Country", "위치");
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

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
            Definition metro = new Definition();
            metro.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e) //추가 버튼
        {
            Supply2 material3 = new Supply2(this);
            material3.StartPosition = FormStartPosition.Manual; // 위치를 수동으로 지정
            material3.Location = new Point(1000, 220);
            material3.Show();
        }

        // Material3에서 호출할 행 추가 메서드
        public void AddRowToDataGridView(string text1, string text2, string text3)
        {
            dataGridView1.Rows.Add(text1, text2, text3);
        }

        private void button6_Click(object sender, EventArgs e) //설정 아이콘 버튼
        {
        }
        //sell을 클릭했을 때 정보를 받음
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            if (rowIndex >= 0) // 유효한 행 클릭
            {
                var cellValue = dataGridView1.Rows[rowIndex].Cells["SupplierID"].Value;

                if (cellValue != null)
                {
                    seletedID = Convert.ToInt32(cellValue); // FacID를 변수에 저장
                    MessageBox.Show($"클릭된 셀의 데이터: {seletedID}");
                }
                else
                {
                    seletedID = null; // 값이 없는 경우 초기화
                    MessageBox.Show("유효한 데이터를 클릭하세요.");
                }
            }
        }

        private async void Viewbtn_Click(object sender, EventArgs e) //수정
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

                // DataGridView 초기화
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                // DataGridView 열 정의
                dataGridView1.Columns.Add("SUPPLIERID", "Supplier ID");
                dataGridView1.Columns.Add("SUPPLIERNAME", "Supplier Name");
                dataGridView1.Columns.Add("CONTACTINFO", "Contact Info");
                dataGridView1.Columns.Add("COUNTRY", "Country");

                // 데이터 추가
                foreach (var supplier in response.Suppliers)
                {
                    dataGridView1.Rows.Add(
                        supplier.SupplierID,
                        supplier.SupplierName,
                        supplier.ContactInfo,
                        supplier.Country
                    );
                }

                MessageBox.Show("데이터 로드 완료", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private async void DeleteBtn_Click(object sender, EventArgs e) //수정
        {
            if (config == null || config.GrpcSettings == null)
            {
                MessageBox.Show("gRPC 설정을 불러올 수 없습니다.");
                return;
            }

            // 선택된 SupplierID 확인
            if (seletedID == null)
            {
                MessageBox.Show("삭제할 공급업체를 선택하세요.", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // gRPC 채널 생성
            var channel = new Channel($"{config.GrpcSettings.Host}:{config.GrpcSettings.Port}", ChannelCredentials.Insecure);
            var client = new DB_Service.DB_ServiceClient(channel);

            try
            {
                // 삭제 요청 생성
                var deleteRequest = new DeleteSupplyRequest { SupplierID = { seletedID.Value } };
                var response = await client.DeleteSupplyDataAsync(deleteRequest);


                if (response.ErrorCode == 0)
                {
                    MessageBox.Show($"SupplierID {seletedID} 공급업체가 삭제 처리되었습니다.", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // DataGridView에서 선택된 행 제거
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["SupplierID"].Value != null && (int)row.Cells["SupplierID"].Value == seletedID)
                        {
                            dataGridView1.Rows.Remove(row);
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"삭제 중 오류 발생: {response.ErrorMessage}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
