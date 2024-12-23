﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.Collections;
using Grpc.Core;
using Grpc.Net.Client;
using grpctestserver;
using Oracle.ManagedDataAccess.Client;
using ReaLTaiizor.Forms;
using SteelMES;

namespace Project_SteelMES
{
    public partial class Supply2 : MaterialForm
    {
        private Supply lost7;

        private Config config; //추가

        public Supply2(Supply lost7)
        {
            InitializeComponent();
            this.lost7 = lost7; // lost7 참조 저장

            string configFilePath = Path.Combine(Directory.GetCurrentDirectory(), "appsetting.json");
            config = ConfigLoader.LoadConfig(configFilePath);

            if (config == null || config.GrpcSettings == null)
            {
                MessageBox.Show("gRPC 설정을 로드하는 데 실패했습니다.");
            }
        }

        private void Material3_Load(object sender, EventArgs e)
        {
            // 폼 시작 위치를 사용자 정의로 설정
            this.StartPosition = FormStartPosition.Manual;
            // 폼의 위치를 고정된 좌표로 설정
            this.Location = new Point(1255, 350);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e) //등록 버튼 //수정
        {
            if (config == null || config.GrpcSettings == null)
            {
                MessageBox.Show("gRPC 설정을 불러올 수 없습니다.");
                return;
            }

            string supplierName = textBox1.Text;
            string contactInfo = textBox2.Text;
            string country = textBox3.Text;

            if (string.IsNullOrWhiteSpace(supplierName) || string.IsNullOrWhiteSpace(contactInfo) || string.IsNullOrWhiteSpace(country))
            {
                MessageBox.Show("모든 필드를 입력하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // gRPC 채널 생성
            var channel = new Channel($"{config.GrpcSettings.Host}:{config.GrpcSettings.Port}", ChannelCredentials.Insecure);
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
