using System;
using System.Threading.Tasks;
using Grpc.Core;
using Oracle.ManagedDataAccess.Client;
using SteelMES;
using Google.Protobuf.WellKnownTypes; // Google의 Empty 사용

namespace grpcDummyMesServer
{
	public class DBServiceServer : DB_Service.DB_ServiceBase
	{
		private readonly string _connectionString =
			"User Id=scott;Password=tiger;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.0.9)(PORT=1521))(CONNECT_DATA=(SID=XE)))";

		/// <summary>
		/// 요청 기간 내 불량 이력을 가져오는 메서드
		/// </summary>
		public override async Task<prodHistoryInfoReply> reqProdHistory(prodHistoryInfoRequest request, ServerCallContext context)
		{
			var result = new prodHistoryInfoReply();

			try
			{
				Console.WriteLine($"Request received: From {request.FromTime} To {request.ToTime}");

				await using var connection = new OracleConnection(_connectionString);
				await connection.OpenAsync();
				 
				const string query = @"
					SELECT DefectID, ProductID, DefectType, DetectionDate
					FROM SCOTT.DEFECT
					WHERE DetectionDate BETWEEN TO_DATE(:fromTime, 'YYYY-MM-DD') AND TO_DATE(:toTime, 'YYYY-MM-DD')";

				await using var command = new OracleCommand(query, connection);
				command.Parameters.Add(new OracleParameter("fromTime", request.FromTime));
				command.Parameters.Add(new OracleParameter("toTime", request.ToTime));

				await using var reader = await command.ExecuteReaderAsync();
				while (await reader.ReadAsync())
				{
					result.Infos.Add(new prodHistoryInfo
					{
						DefectID = reader.GetInt32(0),
						ProductID = reader.GetInt32(1),
						DefectType = reader.GetString(2),
						DetectionDate = reader.GetDateTime(3).ToString("yyyy-MM-dd"),
					});
				}

				result.ErrorCode = result.Infos.Count > 0 ? 0 : -1; // 데이터 여부 체크
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				result.ErrorCode = -1;
			}

			return result;
		}

		/// <summary>
		/// 모든 불량 데이터를 가져오는 메서드
		/// </summary>
		public override async Task<prodHistoryInfoReply> GetAllDefects(SteelMES.Empty request, ServerCallContext context)
		{
			var result = new prodHistoryInfoReply();

            try
            {
                await using var connection = new OracleConnection(_connectionString);
                await connection.OpenAsync();

				// SQL 쿼리 수정: 잘못된 쉼표와 오타 제거
				const string query = @"SELECT DefectID, ProductID,DefectType,DetectionDate FROM SCOTT.DEFECT";

                await using var command = new OracleCommand(query, connection);
                await using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    result.Infos.Add(new prodHistoryInfo
                    {
                        DefectID = reader.GetInt32(0), // 첫 번째 열은 0번 인덱스
                        ProductID = reader.GetInt32(1), // 두 번째 열은 1번 인덱스
                        DefectType = reader.GetString(2), // 세 번째 열은 2번 인덱스
                        DetectionDate = reader.GetDateTime(3).ToString("yyyy-MM-dd"), // 네 번째 열은 3번 인덱스
                    });
                }

                result.ErrorCode = result.Infos.Count > 0 ? 0 : -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                result.ErrorCode = -1;
            }
			return result;
		}

		/// <summary>
		/// 공장 데이터를 가져오는 메서드
		/// </summary>
		public override async Task<FactoryReply> GetFactoryData(SteelMES.Empty request, ServerCallContext context)
		{
			var result = new FactoryReply();

			try
			{
				await using var connection = new OracleConnection(_connectionString);
				await connection.OpenAsync();

				const string query = "SELECT FACID, LOCATION FROM FACTORY";

				await using var command = new OracleCommand(query, connection);
				await using var reader = await command.ExecuteReaderAsync();

				while (await reader.ReadAsync())
				{
					result.Factories.Add(new FactoryInfo
					{
						FacID = reader.GetInt32(0),
						Location = reader.IsDBNull(1) ? string.Empty : reader.GetString(1)
					});
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}

			return result;
		}

		/// <summary>
		/// 공장 ID를 기준으로 생산 라인 데이터를 가져오는 메서드
		/// </summary>
		public override async Task<ProductionLineReply> GetProductionLineData(ProductionLineRequest request, ServerCallContext context)
		{
			var result = new ProductionLineReply();

			try
			{
				await using var connection = new OracleConnection(_connectionString);
				await connection.OpenAsync();

				const string query = @"
					SELECT LINEID, FACID, LINENAME, OPERATINGDATE
					FROM PRODUCTIONLINE
					WHERE FACID = :facid";

				await using var command = new OracleCommand(query, connection);
				command.Parameters.Add(new OracleParameter("facid", request.FacID));

				await using var reader = await command.ExecuteReaderAsync();
				while (await reader.ReadAsync())
				{
					result.Lines.Add(new ProductionLineInfo
					{
						LineID = reader.GetInt32(0),
						FacID = reader.GetInt32(1),
						LineName = reader.GetString(2),
						OperateDate = reader.GetDateTime(3).ToString("yyyy-MM-dd")
					});
				}

				result.ErrorCode = result.Lines.Count > 0 ? 0 : -1;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				result.ErrorCode = -1;
			}

			return result;
		}
		/// <summary>
		/// MATERIAL 테이블에서 데이터를 가져오는 메서드
		/// </summary>
		public override async Task<MaterialReply> GetMaterialData(SteelMES.Empty request, ServerCallContext context)
		{
			var result = new MaterialReply();

			try
			{
				Console.WriteLine("Received request for MATERIAL data.");

				await using var connection = new OracleConnection(_connectionString);
				await connection.OpenAsync();

				const string query = @"
                    SELECT MATERIALID, MATERIALNAME, SUPPLIERID, QUANTITY, IMPORTDATE 
                    FROM MATERIAL";

				await using var command = new OracleCommand(query, connection);
				await using var reader = await command.ExecuteReaderAsync();

				while (await reader.ReadAsync())
				{
					result.Materials.Add(new MaterialInfo
					{
						MaterialID = reader.GetInt32(0),
						MaterialName = reader.GetString(1),
						SupplierID = reader.GetInt32(2),
						Quantity = reader.GetInt32(3),
						ImportDate = reader.GetDateTime(4).ToString("yyyy-MM-dd")
					});
				}

				result.ErrorCode = result.Materials.Count > 0 ? 0 : -1;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error fetching MATERIAL data: {ex.Message}");
				result.ErrorCode = -1;
			}

			return result;
		}

		/// <summary>
		/// SUPPLIER 테이블에서 데이터를 가져오는 메서드
		/// </summary>
		public override async Task<SupplierReply> GetSupplierData(SteelMES.Empty request, ServerCallContext context)
		{
			var result = new SupplierReply();

			try
			{
				Console.WriteLine("Received request for SUPPLIER data.");

				await using var connection = new OracleConnection(_connectionString);
				await connection.OpenAsync();

				const string query = @"
                    SELECT SUPPLIERID, SUPPLIERNAME, CONTACTINFO, COUNTRY
                    FROM SUPPLIER";

				await using var command = new OracleCommand(query, connection);
				await using var reader = await command.ExecuteReaderAsync();

				while (await reader.ReadAsync())
				{
					result.Suppliers.Add(new SupplierInfo
					{
						SupplierID = reader.GetInt32(0),
						SupplierName = reader.GetString(1),
						ContactInfo = reader.GetString(2),
						Country = reader.GetString(3)
					});
				}

				result.ErrorCode = result.Suppliers.Count > 0 ? 0 : -1;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error fetching SUPPLIER data: {ex.Message}");
				result.ErrorCode = -1;
			}

			return result;
		}
		/// <summary>
		/// Material 테이블에 데이터를 추가하는 메서드
		/// </summary>
		public override async Task<UpdateMaterialQuantityReply> UpdateMaterialQuantity(UpdateMaterialQuantityRequest request, ServerCallContext context)
		{
			var result = new UpdateMaterialQuantityReply();

			try
			{
				await using var connection = new OracleConnection(_connectionString);
				await connection.OpenAsync();

				const string query = @"
			UPDATE MATERIAL
			SET QUANTITY = QUANTITY + :additionalQuantity
			WHERE MATERIALID = :materialID";

				await using var command = new OracleCommand(query, connection);
				command.Parameters.Add(new OracleParameter("additionalQuantity", request.AdditionalQuantity));
				command.Parameters.Add(new OracleParameter("materialID", request.MaterialID));

				int rowsAffected = await command.ExecuteNonQueryAsync();
				result.ErrorCode = rowsAffected > 0 ? 0 : -1; // 성공: 0, 실패: -1
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception 발생: {ex.Message}");
				result.ErrorCode = -1;
			}

			return result;
		}
		public override async Task<AddFactoryReply> AddFactory(AddFactoryRequest request, ServerCallContext context)
		{
			var result = new AddFactoryReply();
			try
			{
				// 요청받은 Location 값
				string location = request.Location;

				if (string.IsNullOrWhiteSpace(location))
				{
					result.ErrorCode = -1;
					result.Message = "공장 위치(Location)는 비워둘 수 없습니다.";
					return result;
				}

				await using var connection = new OracleConnection(_connectionString);
				await connection.OpenAsync();

				// 공장 삽입 쿼리 (FacID는 DB의 트리거와 시퀀스에서 자동 생성)
				const string insertQuery = "INSERT INTO FACTORY (LOCATION) VALUES (:location)";

				await using var command = new OracleCommand(insertQuery, connection);

				// 파라미터 설정
				command.Parameters.Add(new OracleParameter("location", OracleDbType.Varchar2) { Value = location });

				// 삽입 실행
				int rowsInserted = await command.ExecuteNonQueryAsync();

				// 결과 처리
				if (rowsInserted > 0)
				{
					result.ErrorCode = 0;
					result.Message = "공장이 성공적으로 추가되었습니다.";
				}
				else
				{
					result.ErrorCode = -1;
					result.Message = "공장을 추가할 수 없습니다.";
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding factory: {ex.Message}");
				result.ErrorCode = -1;
				result.Message = $"오류 발생: {ex.Message}";
			}
			return result;
		}
	}
}
