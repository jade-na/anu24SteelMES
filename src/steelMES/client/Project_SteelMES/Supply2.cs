using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.Collections;
using Grpc.Core;
using Grpc.Net.Client;
using Oracle.ManagedDataAccess.Client;
using ReaLTaiizor.Forms;
using SteelMES;

namespace Project_SteelMES
{
    public partial class Supply2 : MaterialForm
    {
        private Supply lost7;

        public Supply2(Supply lost7)
        {
            InitializeComponent();
            this.lost7 = lost7; // lost7 참조 저장
        }

        private void Material3_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e) //등록 버튼
        {
            string supplierName = textBox1.Text;
            string contactInfo = textBox2.Text;
            string country = textBox3.Text;

            if (string.IsNullOrWhiteSpace(supplierName) || string.IsNullOrWhiteSpace(contactInfo) || string.IsNullOrWhiteSpace(country))
            {
                MessageBox.Show("모든 필드를 입력하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
            var client = new DB_Service.DB_ServiceClient(channel);

            try
            {
                var request = new AddSupplierRequest
                {
                    SupplierName = supplierName,
                    ContactInfo = contactInfo,
                    Country = country
                };

                var response = await client.AddSupplierAsync(request);
                
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
