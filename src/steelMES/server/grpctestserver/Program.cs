using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using grpcDummyMesServer;
using SteelMES;

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

			// gRPC 서버 실행
			var serverThread = new Thread(StartGrpcServer) { IsBackground = true };
			serverThread.Start();

			// Windows Forms 애플리케이션 실행
			ApplicationConfiguration.Initialize();
			Application.Run(new Form1());
		}

		private static void StartGrpcServer()
		{
			try
			{
				const string host = "127.0.0.1";
				const int port = 50051;

				var server = new Grpc.Core.Server
				{
					Services = { DB_Service.BindService(new DBServiceServer()) },
					Ports = { new Grpc.Core.ServerPort(host, port, Grpc.Core.ServerCredentials.Insecure) }
				};

				server.Start();
				Console.WriteLine($"gRPC 서버가 {host}:{port}에서 실행 중입니다.");

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
	}
}
