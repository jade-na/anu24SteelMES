using System;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows.Forms;
using Grpc.Core;
using MongoDB.Driver.Core.Configuration;
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
            //json  ���� ���� �б�

            var config = LoadConfig();

            // gRPC ���� ����
            var serverThread = new Thread(() => StartgRPCServer(config.GrpcSettings)) { IsBackground = true };
            serverThread.Start();

            // Windows Forms ���ø����̼� ����
            ApplicationConfiguration.Initialize();
			Application.Run(new Form1());
		}

        private static void StartgRPCServer(GrpcSettings grpcSettings)
        {
            try
            {
                string host = grpcSettings.Host;  // JSON���� ���� ȣ��Ʈ
                int port = grpcSettings.Port;    // JSON���� ���� ��Ʈ

                Console.WriteLine($"Attempting to bind to {host}:{port}...");

                var server = new Grpc.Core.Server
                {
                    Services = { DB_Service.BindService(new DBServiceServer()) },
                    Ports = { new ServerPort(host, port, ServerCredentials.Insecure) }
                };

                try
                {
                    server.Start();
                    Console.WriteLine($"gRPC ������ {grpcSettings.Host}:{grpcSettings.Port}���� ���� ���Դϴ�.");
                }
                catch (Exception serverEx)
                {
                    Console.WriteLine($"gRPC ���� ���� ����: {serverEx.Message}");
                    Console.WriteLine($"StackTrace: {serverEx.StackTrace}");
                    return;
                }

                // ���� ���� ���
                Console.WriteLine("�����Ϸ��� �ֿܼ��� Ctrl+C�� ��������...");
                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"gRPC ���� ���� �� ���� �߻�: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
            }
        }
        public static Config LoadConfig()
        {
            string configFilePath = @"C:\Temp\anu24SteelMES\src\steelMES\server\grpctestserver\appsetting.json"; // ���� ��η� ��Ȯ�� ����
            try
            {
                string json = File.ReadAllText(configFilePath);
                return JsonConvert.DeserializeObject<Config>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"���� ������ �д� �� ���� �߻�: {ex.Message}");
                return null;
            }
        }
        // gRPC ���� ������ JSON���� �д� �Լ�
        public static GrpcSettings LoadGrpcServerSettings(string filePath)
        {
            try
            {
                var jsonString = File.ReadAllText(filePath);
                var settings = JsonConvert.DeserializeObject<JsonElement>(jsonString);
                var grpcServerSettings = settings.GetProperty("GrpcServer");

                return new GrpcSettings
                {
                    Host = grpcServerSettings.GetProperty("Host").GetString(),
                    Port = grpcServerSettings.GetProperty("Port").GetInt32()
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"���� ������ �д� �� ���� �߻�: {ex.Message}");
                return null;
            }
        }
        public class Config
        {
            public GrpcSettings GrpcSettings { get; set; }
        }
       
        public class GrpcSettings
        {
            public  string Host { get; set; }
            public  int Port { get; set; }
        }
    }
}
