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
using Grpc.Net.Client;
using Oracle.ManagedDataAccess.Client;
using ReaLTaiizor.Forms;
using SteelMES;

namespace Project_SteelMES
{
    public partial class Lost7 : LostForm
    {
        // Oracle 연결 문자열
        private string connectionString = "User Id=scott;Password=tiger;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));";

        public Lost7()
        {
            InitializeComponent();
            
        }

        private void Lost7_Load(object sender, EventArgs e)
        {
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void Viewbtn_Click(object sender, EventArgs e)
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

                // DataGridView 초기화
                dataGridView1.Rows.Clear();

                foreach (var supplier in response.Suppliers)
                {
                    dataGridView1.Rows.Add(
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
    }
}
