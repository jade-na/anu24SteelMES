using System;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Grpc.Core;
using grpcDummyMesServer;
using MongoDB.Driver.Core.Configuration;
using Newtonsoft.Json;
using SteelMES;
using static grpctestserver.Program;

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
            var connectionString = CreateConnectionString(config.OracleConnection);

            // gRPC ���� ����
            var serverThread = new Thread(() => StartgRPCServer(connectionString, config.GrpcSettings)) { IsBackground = true };
            serverThread.Start();

            // Windows Forms ���ø����̼� ����
            ApplicationConfiguration.Initialize();
			Application.Run(new Form1());
		}

        private static void StartgRPCServer(string connectionString, GrpcSettings grpcSettings)
        {
            try
            {
                string host = grpcSettings.Host;  // JSON���� ���� ȣ��Ʈ
                int port = grpcSettings.Port;    // JSON���� ���� ��Ʈ

                var server = new Grpc.Core.Server
                {
                    Services = { DB_Service.BindService(new DBServiceServer(connectionString)) },
                    Ports = { new Grpc.Core.ServerPort(host, port, Grpc.Core.ServerCredentials.Insecure) }
                };

                try
                {
                    server.Start();
                    Console.WriteLine($"gRPC ������ {host}:{port}���� ���� ���Դϴ�.");
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
            string json = File.ReadAllText(configFilePath);
            return JsonConvert.DeserializeObject<Config>(json);
        }
        public static string CreateConnectionString(OracleConnectionConfig oracleConfig)
        {
            return $"User Id={oracleConfig.UserId};Password={oracleConfig.Password};Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={oracleConfig.Host})(PORT={oracleConfig.Port}))(CONNECT_DATA=(SID=XE)))";
        }

        public class Config
        {
            public OracleConnectionConfig OracleConnection { get; set; }
            public GrpcSettings GrpcSettings { get; set; }
        }
        public class OracleConnectionConfig
        {
           public string UserId {  get; set; }
           public string Password { get; set; }
           public int Port { get; set; }
           public int Host {  get; set; } 
         
        }
        public class GrpcSettings
        {
            public  string Host { get; set; }
            public  int Port { get; set; }
        }
    }
}
