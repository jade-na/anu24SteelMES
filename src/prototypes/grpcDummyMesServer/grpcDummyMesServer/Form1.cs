using Grpc.Core;
using SteelMES;
using System.Threading;
using System.Threading.Tasks;

namespace grpcDummyMesServer
{
    public partial class Form1 : Form
    {
        Server grpcServer = null;

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (grpcServer != null)
            {
                MessageBox.Show("gRPC Server is already running.");
                return;
            }
            
            int port = int.Parse(textBox1.Text);            
            
            grpcServer = new Server
            {
                Services = { DB_Service.BindService(new DBServiceServer()) },
                Ports = { new ServerPort("localhost", port, ServerCredentials.Insecure) }
            };

            grpcServer.Start();
            MessageBox.Show($"gRPC Server started at localhost:{port}");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (grpcServer == null)
            {
                MessageBox.Show("gRPC Server is not running.");
                return;
            }

            await grpcServer.ShutdownAsync();
            grpcServer = null;
            MessageBox.Show("gRPC Server stopped.");
        }
    }
}
