using Grpc.Core;
using MongoDB.Driver.Core.Configuration;
using SteelMES;
using System.Threading;
using System.Threading.Tasks;

namespace grpctestserver
{
    public partial class Form1 : Form
    {
        Server grpcServer = null;
        private string connectionString;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            textBox1.Text = "Host Port 접속완료";  // 서버상태 표시

            //// gRPC 서버가 실행 중이라는 문구만 표시
            //textBox1.Text = "Host Port 접속완료";  // 서버상태 표시

            //// Form이 로드되면 자동으로 서버 시작
            //var config = Program.LoadConfig(); // JSON 파일에서 설정 읽기
            //string host = config.GrpcSettings.Host;
            //int port = config. GrpcSettings.Port;

            //try
            //{
            //    // gRPC 서버를 시작
            //    grpcServer = new Server
            //    {
            //        Services = { DB_Service.BindService(new DBServiceServer()) },
            //        Ports = { new ServerPort(host, port, ServerCredentials.Insecure) }
            //    };

            //    // 서버 시작
            //    grpcServer.Start();
            //    Console.WriteLine($"gRPC 서버가 {host}:{port}에서 실행 중입니다.");

            //    textBox1.Text = $"gRPC 서버가 {host}:{port}에서 실행 중입니다.";
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"gRPC 서버 실행 중 오류 발생: {ex.Message}");
            //    Console.WriteLine($"gRPC 서버 실행 중 오류 발생: {ex.Message}");
            //}

        }
    }
}
