using Grpc.Core;
using grpcDummyMesServer;
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
            // gRPC ������ ���� ���̶�� ������ ǥ��
            textBox1.Text = "Host Port ���ӿϷ�";  // �������� ǥ��

            // Form�� �ε�Ǹ� �ڵ����� ���� ����
            var config = Program.LoadConfig(); // JSON ���Ͽ��� ���� �б�
            string host = config.GrpcSettings.Host;
            int port = config.GrpcSettings.Port;

            try
            {
                // gRPC ������ ����
                var server = new Server
                {
                    Services = { DB_Service.BindService(new DBServiceServer(connectionString)) },
                    Ports = { new ServerPort(host, port, ServerCredentials.Insecure) }
                };

                server.Start();
                Console.WriteLine($"gRPC ������ {host}:{port}���� ���� ���Դϴ�.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"gRPC ���� ���� �� ���� �߻�: {ex.Message}");
            }
        }
    }
}
