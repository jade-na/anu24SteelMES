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

        private void button6_Click(object sender, EventArgs e)
        {

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

        private void button5_Click(object sender, EventArgs e)
        {

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

        private void button4_Click(object sender, EventArgs e)
        {

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

        private void button3_Click(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {

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

        private void button2_Click(object sender, EventArgs e)
        {

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
