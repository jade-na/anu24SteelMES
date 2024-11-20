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
			// �ܼ� â Ȱ��ȭ
			AllocConsole();
			Console.WriteLine("�ܼ� â�� Ȱ��ȭ�Ǿ����ϴ�.");

			// gRPC ���� ����
			var serverThread = new Thread(StartGrpcServer) { IsBackground = true };
			serverThread.Start();

			// Windows Forms ���ø����̼� ����
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
				Console.WriteLine($"gRPC ������ {host}:{port}���� ���� ���Դϴ�.");

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
	}
}
