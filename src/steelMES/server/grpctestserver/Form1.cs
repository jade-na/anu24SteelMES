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

            textBox1.Text = "Host Port ���ӿϷ�";  // �������� ǥ��

            //// gRPC ������ ���� ���̶�� ������ ǥ��
            //textBox1.Text = "Host Port ���ӿϷ�";  // �������� ǥ��

            //// Form�� �ε�Ǹ� �ڵ����� ���� ����
            //var config = Program.LoadConfig(); // JSON ���Ͽ��� ���� �б�
            //string host = config.GrpcSettings.Host;
            //int port = config. GrpcSettings.Port;

            //try
            //{
            //    // gRPC ������ ����
            //    grpcServer = new Server
            //    {
            //        Services = { DB_Service.BindService(new DBServiceServer()) },
            //        Ports = { new ServerPort(host, port, ServerCredentials.Insecure) }
            //    };

            //    // ���� ����
            //    grpcServer.Start();
            //    Console.WriteLine($"gRPC ������ {host}:{port}���� ���� ���Դϴ�.");

            //    textBox1.Text = $"gRPC ������ {host}:{port}���� ���� ���Դϴ�.";
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"gRPC ���� ���� �� ���� �߻�: {ex.Message}");
            //    Console.WriteLine($"gRPC ���� ���� �� ���� �߻�: {ex.Message}");
            //}

        }
    }
}
