using System;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows.Forms;
using Grpc.Core;
using GrpcPiControl;
using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver.Core.Connections;
using Newtonsoft.Json;
using SteelMES;
using static grpctestserver.Program;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace grpctestserver
{
	internal static class Program
	{
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool AllocConsole();

		[STAThread]
        static void Main()
        {
            // �ܼ� â Ȱ��ȭ
            AllocConsole();
            Console.WriteLine("�ܼ� â�� Ȱ��ȭ�Ǿ����ϴ�.");

            var config = LoadConfig();

            // gRPC ���� ����
            var serverThread = new Thread(() => StartgRPCServer(config.GrpcSettings)) { IsBackground = true };
            var piServerThread = new Thread(() => StartPiConnection(config.PiConnections)) { IsBackground = true };

            serverThread.Start();
            piServerThread.Start();

            // Windows Forms ���ø����̼� ����
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        private static Server server; // Ŭ���� ���� ������ ����

        private static void StartgRPCServer(GrpcSettings grpcSettings)
        {
            try
            {
                server = new Server
                {
                    Services = { DB_Service.BindService(new DBServiceServer()) },
                    Ports = { new ServerPort(grpcSettings.Host, grpcSettings.Port, ServerCredentials.Insecure) }
                };

                server.Start();
                Console.WriteLine($"Client gRPC ������ {grpcSettings.Host}:{grpcSettings.Port}���� ���� ���Դϴ�.");

                // ���ø����̼� ���� �̺�Ʈ ó��
                AppDomain.CurrentDomain.ProcessExit += (s, e) =>
                {
                    Console.WriteLine("���� ���� ��...");
                    server.ShutdownAsync().Wait();
                    Console.WriteLine("������ ���������� ����Ǿ����ϴ�.");
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"gRPC ���� ���� �� ���� �߻�: {ex.Message}");
            }
        }
        private static void StartPiConnection(PiConnections PiConnections)
        {
            try
            {

                server = new Server
                {
                    Services = { PiControlService.BindService(new PiControlServiceImpl()) },
                    Ports = { new ServerPort(PiConnections.Host, PiConnections.Port, ServerCredentials.Insecure) }
                };

                server.Start();
                Console.WriteLine($"Pi gRPC ������ {PiConnections.Host}:{PiConnections.Port}���� ���� ���Դϴ�.");

                AppDomain.CurrentDomain.ProcessExit += (s, e) =>
                {
                    Console.WriteLine("Pi Control ���� ���� ��...");
                    server.ShutdownAsync().Wait();
                    Console.WriteLine("Pi Control ������ ���������� ����Ǿ����ϴ�.");
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Pi Control ���� ���� �� ���� �߻�: {ex.Message}");
                throw;
            }
        }

        public static Config LoadConfig()
        {
            string configFilePath = Path.Combine(Directory.GetCurrentDirectory(), "appsetting.json");
            try
            {
                if (!File.Exists(configFilePath))
                {
                    throw new FileNotFoundException($"���� ������ ã�� �� �����ϴ�: {configFilePath}");
                }

                string json = File.ReadAllText(configFilePath);
                var config = JsonConvert.DeserializeObject<Config>(json);
                Console.WriteLine($"�ε�� JSON ����: {json}"); // ������

                if (config.GrpcSettings == null)
                {
                    throw new InvalidOperationException("GrpcSettings�� �������� �ʾҽ��ϴ�.");
                }
                // null üũ �߰�
                if (config.PiConnections == null)
                {
                    throw new InvalidOperationException("PiConnection Host ������ �����ϴ�.");
                }

                return config;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"���� ���� �ε� ����: {ex.Message}");
                Console.WriteLine($"���� ���丮: {Directory.GetCurrentDirectory()}");
                throw;
            }
        }

        public class Config
        {
            [JsonProperty("OracleConnection")]
            public OracleConnectionConfig OracleConnection { get; set; }

            [JsonProperty("GrpcSettings")]
            public GrpcSettings GrpcSettings { get; set; }

            [JsonProperty("PiConnection")]
            public PiConnections PiConnections { get; set; }
        }


        public class GrpcSettings
        {
            public  string Host { get; set; }
            public  int Port { get; set; }
        }
        public class PiConnections
        {
            public string Host { get; set; }
            public int Port { get; set; }
        }
    }
}
