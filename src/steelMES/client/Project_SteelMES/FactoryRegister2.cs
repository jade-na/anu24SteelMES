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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using SteelMES;

namespace Project_SteelMES
{
    public partial class FactoryRegister2 : MaterialForm
    {
        private FactoryRegister lost6;

        public FactoryRegister2(FactoryRegister lost6)
        {
            InitializeComponent();
            this.lost6 = lost6; // lost6 참조 저장
        }

        private void Material2_Load(object sender, EventArgs e)
        {
            // 폼 시작 위치를 사용자 정의로 설정
            this.StartPosition = FormStartPosition.Manual;
            // 폼의 위치를 고정된 좌표로 설정
            this.Location = new Point(1255, 350);
        }

        private async void button1_Click(object sender, EventArgs e) //추가 버튼
        {
            string FacName = textBox1.Text;
            string Loaction = textBox2.Text;

            if (string.IsNullOrWhiteSpace(FacName) || string.IsNullOrWhiteSpace(Loaction))
            {
                MessageBox.Show("모든 필드를 입력하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
            var client = new DB_Service.DB_ServiceClient(channel);

            try
            {
                var request = new AddFactoryRequest
                {
                    FacName = FacName,
                    Location = Loaction
                };

                var response = await client.AddFactoryAsync(request);

                if (response.ErrorCode == 0)
                {
                    MessageBox.Show("공급업체 등록 성공!", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"공급업체 등록 실패: {response.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (RpcException ex)
            {
                MessageBox.Show($"gRPC 호출 실패: {ex.Status.Detail}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

       

        private void button2_Click(object sender, EventArgs e) //돌아가기 버튼
        {
            this.Dispose();
        }
    }
}
