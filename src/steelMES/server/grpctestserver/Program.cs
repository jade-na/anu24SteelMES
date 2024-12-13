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
            // 콘솔 창 활성화
            AllocConsole();
            Console.WriteLine("콘솔 창이 활성화되었습니다.");

            var config = LoadConfig();

            // gRPC 서버 실행
            var serverThread = new Thread(() => StartgRPCServer(config.GrpcSettings)) { IsBackground = true };
            var piServerThread = new Thread(() => StartPiConnection(config.PiConnections)) { IsBackground = true };

            serverThread.Start();
            piServerThread.Start();

            // Windows Forms 애플리케이션 실행
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        private static Server server; // 클래스 레벨 변수로 선언

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
                Console.WriteLine($"Client gRPC 서버가 {grpcSettings.Host}:{grpcSettings.Port}에서 실행 중입니다.");

                // 애플리케이션 종료 이벤트 처리
                AppDomain.CurrentDomain.ProcessExit += (s, e) =>
                {
                    Console.WriteLine("서버 종료 중...");
                    server.ShutdownAsync().Wait();
                    Console.WriteLine("서버가 정상적으로 종료되었습니다.");
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"gRPC 서버 실행 중 오류 발생: {ex.Message}");
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
                Console.WriteLine($"Pi gRPC 서버가 {PiConnections.Host}:{PiConnections.Port}에서 실행 중입니다.");

                AppDomain.CurrentDomain.ProcessExit += (s, e) =>
                {
                    Console.WriteLine("Pi Control 서버 종료 중...");
                    server.ShutdownAsync().Wait();
                    Console.WriteLine("Pi Control 서버가 정상적으로 종료되었습니다.");
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Pi Control 서버 실행 중 오류 발생: {ex.Message}");
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
                    throw new FileNotFoundException($"설정 파일을 찾을 수 없습니다: {configFilePath}");
                }

                string json = File.ReadAllText(configFilePath);
                var config = JsonConvert.DeserializeObject<Config>(json);
                Console.WriteLine($"로드된 JSON 내용: {json}"); // 디버깅용

                if (config.GrpcSettings == null)
                {
                    throw new InvalidOperationException("GrpcSettings가 설정되지 않았습니다.");
                }
                // null 체크 추가
                if (config.PiConnections == null)
                {
                    throw new InvalidOperationException("PiConnection Host 설정이 없습니다.");
                }

                return config;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"설정 파일 로드 실패: {ex.Message}");
                Console.WriteLine($"현재 디렉토리: {Directory.GetCurrentDirectory()}");
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
