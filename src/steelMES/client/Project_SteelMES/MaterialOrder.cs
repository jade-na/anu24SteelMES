using Grpc.Core;
using OpenTK.Graphics.OpenGL;
using SteelMES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_SteelMES
{
    public partial class MaterialOrder : Form
    {
        public MaterialOrder()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OrderBtn_Click(object sender, EventArgs e)
        {
            MaterialOrder2 matOrder = new MaterialOrder2();
            matOrder.Show();
            
        }

        private async void SelectBtn_Click(object sender, EventArgs e)
        {

            // gRPC 채널 생성
            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
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
                         material.SupplierID,
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

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

        private async void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // gRPC 채널 생성
            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
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

        //private void ViewSupBtn_Click(object sender, EventArgs e)
        //{

        //}
    }
}
