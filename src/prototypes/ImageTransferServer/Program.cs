using Grpc.Core;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Image; // Proto에서 생성된 네임스페이스

namespace ImageTransferServer
{
	class Program
	{
		const int Port = 50051;

		static async Task Main(string[] args)
		{
			Server server = new Server
			{
				Services = { ImageService.BindService(new ImageServiceImpl()) },
				Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
			};

			server.Start();
			Console.WriteLine($"Server is listening on port {Port}");

			Console.WriteLine("Press any key to stop the server...");
			Console.ReadKey();

			await server.ShutdownAsync();
			Console.WriteLine("Server has been stopped.");
		}
	}

	public class ImageServiceImpl : ImageService.ImageServiceBase
	{
		public override Task<ImageReply> SendImage(ImageRequest request, ServerCallContext context)
		{
			try
			{
				string directoryPath = "UploadedImages";
				string savePath = Path.Combine(directoryPath, request.ImageName);

				// 디렉터리 생성
				if (!Directory.Exists(directoryPath))
				{
					Directory.CreateDirectory(directoryPath);
					Console.WriteLine($"Directory created at: {directoryPath}");
				}

				// 이미지 데이터 저장
				File.WriteAllBytes(savePath, request.ImageData.ToByteArray());
				Console.WriteLine($"Image received and saved to: {savePath}");

				// 저장된 폴더 열기
				Process.Start(new ProcessStartInfo
				{
					FileName = directoryPath,
					UseShellExecute = true,
					Verb = "open"
				});

				return Task.FromResult(new ImageReply
				{
					Status = "Image received and saved successfully"
				});
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error while saving image: {ex.Message}");
				return Task.FromResult(new ImageReply
				{
					Status = $"Failed to save image: {ex.Message}"
				});
			}
		}
	}
}
