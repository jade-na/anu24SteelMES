using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using System.Windows.Forms;
using ReaLTaiizor.Forms;
using Grpc.Core;
using SteelMES;

namespace Project_SteelMES
{
    public partial class Lost2 : LostForm
    {
        public Lost2()
        {
            InitializeComponent();
        }

        private void Lost2_Load(object sender, EventArgs e)
        {

        }

        // 조회
        private void button6_Click(object sender, EventArgs e)
        {
            // gRPC 채널 생성
            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);

            // gRPC 클라이언트 생성
            var client = new DB_Service.DB_ServiceClient(channel);

            try
            {
                // RPC 호출
                var request = new prodHistoryInfoRequest();
                var response = client.reqProdHistory(request);

                // 결과 출력
                // 제품명, S/N, LOTID, 불량명, 시간
                if (response.ErrorCode == 0)
                {
                    foreach (var i in response.Infos)
                    {
                        dataGridView1.Rows.Add(i.ProdName, i.SerialNum, i.LotId, i.DefactCode, i.ProduceDay);
                    }
                }
                else
                {
                    // error message
                    MessageBox.Show($"gRPC 호출 실패: ErrorCode = {response.ErrorCode}");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"gRPC 호출 실패: {ex.Message}");
            }
        }
    }
}
