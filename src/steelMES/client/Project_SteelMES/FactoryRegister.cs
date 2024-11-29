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
using Oracle.ManagedDataAccess.Client;
using ReaLTaiizor.Forms;
using SteelMES;

namespace Project_SteelMES
{
    public partial class FactoryRegister : LostForm
    {
        private int? selectedFacID; // 클릭된 FacID를 저장하는 변수
        public FactoryRegister()
        {
            InitializeComponent();
            
        }
        
       
        private void Lost6_Load(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e) //추가 버튼
        {
            FactoryRegister2 material2 = new FactoryRegister2(this);
            material2.StartPosition = FormStartPosition.Manual; // 위치를 수동으로 지정
            material2.Location = new Point(1000, 220);
            material2.Show();
        }

        private void button6_Click(object sender, EventArgs e) //설정 아이콘 버튼
        {
            
        }

        

        // Material2에서 호출할 행 추가 메서드
        public void AddRowToDataGridView(string text1, string text2)
        {
            dataGridView1.Rows.Add(text1, text2);
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

        private void button6_Click_1(object sender, EventArgs e)
        {
            
        }

        private async void viewbtn_Click(object sender, EventArgs e)
        {
            // gRPC 채널 생성
            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
            var client = new DB_Service.DB_ServiceClient(channel);

            try
            {
                // gRPC 서버에서 Supplier 데이터를 가져옴
                var response = await client.GetFactoryDataAsync(new Empty());

                if (response.ErrorCode != 0)
                {
                    MessageBox.Show($"서버 오류 코드: {response.ErrorCode}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // DataTable 생성
                var dataTable = new DataTable();
                dataTable.Columns.Add("FacID", typeof(int));
                dataTable.Columns.Add("FacName", typeof(string));
                dataTable.Columns.Add("Location", typeof(string));

                dataTable.Clear();


                foreach (var factory in response.Factories)
                {
                    dataTable.Rows.Add(
                         factory.FacID,
                         factory.FacName,
                         factory.Location
                    );
                }

                // DataGridView에 DataTable 바인딩
                dataGridView1.DataSource = dataTable;

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int rowIndex = e.RowIndex;

            if (rowIndex >= 0) // 유효한 행 클릭
            {
                var cellValue = dataGridView1.Rows[rowIndex].Cells["FacID"].Value;

                if (cellValue != null)
                {
                    selectedFacID = Convert.ToInt32(cellValue); // FacID를 변수에 저장
                    MessageBox.Show($"클릭된 셀의 데이터: {selectedFacID}");
                }
                else
                {
                    selectedFacID = null; // 값이 없는 경우 초기화
                    MessageBox.Show("유효한 데이터를 클릭하세요.");
                }
            }
        }

        private async void DeleteBtn_Click(object sender, EventArgs e)
        {
            // 선택된 FacID 확인
            if (selectedFacID == null)
            {
                MessageBox.Show("삭제할 공장을 선택하세요.", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // gRPC 채널 생성
            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
            var client = new DB_Service.DB_ServiceClient(channel);

            try
            {
                // 삭제 요청 생성
                var deleteRequest = new DeleteFactoryRequest { FacID = { selectedFacID.Value } };
                var response = await client.DeleteFactoryDataAsync(deleteRequest);

                if (response.ErrorCode == 0)
                {
                    MessageBox.Show($"FacID {selectedFacID} 공장이 삭제 처리되었습니다.", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // DataGridView에서 선택된 행 제거
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["FacID"].Value != null && (int)row.Cells["FacID"].Value == selectedFacID)
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
