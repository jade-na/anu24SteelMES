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
using grpctestserver;
using SteelMES;
using System.IO;

namespace Project_SteelMES
{
    public partial class Membership : LostForm //수정
    {
        private Config config;

        //// Oracle 연결 문자열
        //private string connectionString = "User Id=scott;Password=tiger;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.0.9)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));";
        public Membership()
        {
            InitializeComponent();

            string configFilePath = Path.Combine(Directory.GetCurrentDirectory(), "appsetting.json");
            config = ConfigLoader.LoadConfig(configFilePath);

            if (config == null || config.GrpcSettings == null)
            {
                MessageBox.Show("gRPC 설정을 로드하는 데 실패했습니다.");
            }

            // Oracle 데이터를 바로 로드
            LogindataFromGrpc();
        }

		private async void LogindataFromGrpc() //수정
        {
            if (config == null || config.GrpcSettings == null)
            {
                MessageBox.Show("gRPC 설정을 불러올 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
			{
                // gRPC 채널 생성 (서버와 연결)
                var channel = new Channel($"{config.GrpcSettings.Host}:{config.GrpcSettings.Port}", ChannelCredentials.Insecure);
                var client = new DB_Service.DB_ServiceClient(channel);

                // 서버에서 사용자 데이터를 가져오는 gRPC 호출
                var reply = await client.GetAllUsersDataAsync(new SteelMES.Empty()); // 서버의 GetAllUsersData 호출

				// 데이터가 성공적으로 반환된 경우
				if (reply.ErrorCode == 0)
				{
					// 데이터를 DataTable로 변환
					DataTable dataTable = new DataTable();
					dataTable.Columns.Add("ID");
					dataTable.Columns.Add("유저ID");
					dataTable.Columns.Add("유저권한등급");

					// UsersReply에서 데이터를 받아 DataTable에 추가
					foreach (var user in reply.Users)
					{
						dataTable.Rows.Add(user.ID, user.Username, user.UserLevel); // Password 제외
					}

					// DataGridView에 데이터 바인딩
					dataGridView1.DataSource = dataTable;
				}
				else
				{
					// 오류 메시지 출력
					MessageBox.Show("유저 데이터를 가져오는 데 실패했습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				// 예외 처리
				MessageBox.Show($"데이터를 불러오는 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void Lost9_Load(object sender, EventArgs e)
        {
            // 폼 시작 위치를 사용자 정의로 설정
            this.StartPosition = FormStartPosition.Manual;
            // 폼의 위치를 고정된 좌표로 설정
            this.Location = new Point(320, 220);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Membership2 material4 = new Membership2(this);
            material4.Show();
        }

		private void refreshBtn_Click(object sender, EventArgs e)
		{
			LogindataFromGrpc();
		}

        private void dungeonLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
