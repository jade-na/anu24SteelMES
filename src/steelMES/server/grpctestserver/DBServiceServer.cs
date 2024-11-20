using System;
using System.Threading.Tasks;
using Grpc.Core;
using Oracle.ManagedDataAccess.Client;
using SteelMES;

namespace grpcDummyMesServer
{
	public class DBServiceServer : DB_Service.DB_ServiceBase
	{
		private readonly string _connectionString =
			"User Id=scott;Password=tiger;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.0.9)(PORT=1521))(CONNECT_DATA=(SID=XE)))";

		public override async Task<prodHistoryInfoReply> reqProdHistory(prodHistoryInfoRequest request, ServerCallContext context)
		{
			var result = new prodHistoryInfoReply();

			try
			{
				Console.WriteLine($"Received request: FromTime={request.FromTime}, ToTime={request.ToTime}");

				await using var connection = new OracleConnection(_connectionString);
				await connection.OpenAsync();
				Console.WriteLine("Database connection established.");

				const string query = @"
					SELECT DefectID, ProductID, MaterialID, DefectType, DetectionDate, Location
					FROM SCOTT.DEFECT
					WHERE DetectionDate BETWEEN TO_DATE(:fromTime, 'YYYY-MM-DD') AND TO_DATE(:toTime, 'YYYY-MM-DD')";

				await using var command = new OracleCommand(query, connection);
				command.Parameters.Add(new OracleParameter("fromTime", request.FromTime));
				command.Parameters.Add(new OracleParameter("toTime", request.ToTime));

				Console.WriteLine($"Executing SQL query with parameters: FromTime={request.FromTime}, ToTime={request.ToTime}");
				await using var reader = await command.ExecuteReaderAsync();

				while (await reader.ReadAsync())
				{
					Console.WriteLine($"Data fetched: DefectID={reader.GetInt32(0)}");
					result.Infos.Add(new prodHistoryInfo
					{
						DefectID = reader.GetInt32(0),
						ProductID = reader.GetInt32(1),
						MaterialID = reader.GetInt32(2),
						DefectType = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
						DefectionDate = reader.IsDBNull(4) ? string.Empty : reader.GetDateTime(4).ToString("yyyy-MM-dd"),
						Location = reader.IsDBNull(5) ? string.Empty : reader.GetString(5)
					});
				}

				if (result.Infos.Count == 0)
				{
					Console.WriteLine("No data found for the given range.");
					result.ErrorCode = -1; // 데이터 없음
				}
				else
				{
					result.ErrorCode = 0; // 성공
				}

				Console.WriteLine("Data fetched successfully.");
			}
			catch (OracleException ex)
			{
				Console.WriteLine($"OracleException 발생: {ex.Message}");
				Console.WriteLine($"오류 코드: {ex.Number}");
				Console.WriteLine($"StackTrace: {ex.StackTrace}");
				result.ErrorCode = -1;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception 발생: {ex.Message}");
				Console.WriteLine($"StackTrace: {ex.StackTrace}");
				result.ErrorCode = -1;
			}
			return result;
		}

	}
}
