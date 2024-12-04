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
			// 콘솔 창 활성화
			AllocConsole();
			Console.WriteLine("콘솔 창이 활성화되었습니다.");
            //json  파일 설정 읽기

            var config = LoadConfig();
            var connectionString = CreateConnectionString(config.OracleConnection);

            // gRPC 서버 실행
            var serverThread = new Thread(() => StartgRPCServer(connectionString, config.GrpcSettings)) { IsBackground = true };
            serverThread.Start();

            // Windows Forms 애플리케이션 실행
            ApplicationConfiguration.Initialize();
			Application.Run(new Form1());
		}

        private static void StartgRPCServer(string connectionString, GrpcSettings grpcSettings)
        {
            try
            {
                string host = grpcSettings.Host;  // JSON에서 읽은 호스트
                int port = grpcSettings.Port;    // JSON에서 읽은 포트

                var server = new Grpc.Core.Server
                {
                    Services = { DB_Service.BindService(new DBServiceServer(connectionString)) },
                    Ports = { new Grpc.Core.ServerPort(host, port, Grpc.Core.ServerCredentials.Insecure) }
                };

                try
                {
                    server.Start();
                    Console.WriteLine($"gRPC 서버가 {host}:{port}에서 실행 중입니다.");
                }
                catch (Exception serverEx)
                {
                    Console.WriteLine($"gRPC 서버 시작 오류: {serverEx.Message}");
                    Console.WriteLine($"StackTrace: {serverEx.StackTrace}");
                    return;
                }

                // 서버 종료 대기
                Console.WriteLine("종료하려면 콘솔에서 Ctrl+C를 누르세요...");
                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"gRPC 서버 실행 중 오류 발생: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
            }
        }
        public static Config LoadConfig()
        {
            string configFilePath = @"C:\Temp\anu24SteelMES\src\steelMES\server\grpctestserver\appsetting.json"; // 절대 경로로 정확히 설정
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
