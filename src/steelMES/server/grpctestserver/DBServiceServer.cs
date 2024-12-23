﻿using Grpc.Core;
using Oracle.ManagedDataAccess.Client;
using SteelMES;
using GrpcPiControl;
using TorchSharp;
using OpenCvSharp;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using MongoDB.Driver.Core.Configuration;
using Microsoft.VisualBasic;

namespace grpctestserver
{
    public class DBServiceServer : DB_Service.DB_ServiceBase
    {
        //private readonly string _connectionString = 
        // "User Id=scott;Password=tiger;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST= 127.0.0.1)(PORT=1521))(CONNECT_DATA=(SID=XE)))";

        private readonly string _connectionString;
        private readonly UserSessionManager m_UserSessionManager;
        private static torch.jit.ScriptModule? model;
        private System.Timers.Timer m_Timer;

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //Console.WriteLine("Timer");
            m_UserSessionManager.ForceLogoutTimeOutUser();
        }

        public DBServiceServer()
        {
            m_UserSessionManager = new UserSessionManager();

            string configFilePath = Path.Combine(Directory.GetCurrentDirectory(), "appsetting.json");
            //string configFilePath = @"C:\Temp\anu24SteelMES\src\steelMES\server\grpctestserver\appsetting.json"; // JSON 파일 경로 설정
            var config = ConfigLoader.LoadConfig(configFilePath);

            if (config != null)
            {
                // 연결 문자열을 JSON 설정을 사용해 동적으로 생성
                _connectionString = ConfigLoader.BuildConnectionString(config.OracleConnection);

                m_Timer = new System.Timers.Timer(1000); // 1초에 한번씩 Timer_Elapsed 함수 들어옴
                m_Timer.Elapsed += Timer_Elapsed; // 
                m_Timer.AutoReset = true; // 자동 리셋
                m_Timer.Enabled = true; // 타이머 시작
            }
            else
            {
                throw new Exception("설정 파일을 읽을 수 없습니다.");
            }
        }


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

                    Console.WriteLine($"불량 식별 ID : {reader.GetInt32(0)}"); // 로그 추가
                    Console.WriteLine($"제품 ID: {reader.GetInt32(1)}"); // 로그 추가
                    Console.WriteLine($"불량 종류 : {reader.GetString(2)}"); // 로그 추가
                    Console.WriteLine();

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

                    Console.WriteLine($"불량 식별 ID : {reader.GetInt32(0)}"); // 로그 추가
                    Console.WriteLine($"제품 ID: {reader.GetInt32(1)}"); // 로그 추가
                    Console.WriteLine($"불량 종류 : {reader.GetString(2)}"); // 로그 추가
                    Console.WriteLine();

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

                const string query = "SELECT FACID, FACNAME, LOCATION, DELETED FROM FACTORY WHERE DELETED = 0";

                await using var command = new OracleCommand(query, connection);
                await using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    var deleted = reader.GetInt32(3); // DELETED 값 디버깅
                    Console.WriteLine($"FacID: {reader.GetInt32(0)}, Deleted: {deleted}"); // 로그 추가
                    result.Factories.Add(new FactoryInfo
                    {
                        FacID = reader.GetInt32(0),
                        FacName = reader.GetString(1),
                        Location = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        Deleted = deleted
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching factory data: {ex.Message}");
            }

            return result;

        }

        /// <summary>
        /// 공장 ID를 기준으로 생산 라인 데이터를 가져오는 메서드
        /// </summary>
        //   public override async Task<ProductionLineReply> GetProductionLineData(ProductionLineRequest request, ServerCallContext context)
        //   {
        //       var result = new ProductionLineReply();

        //       try
        //       {
        //           await using var connection = new OracleConnection(_connectionString);
        //           await connection.OpenAsync();

        //           const string query = @"
        //SELECT LINEID, FACID, LINENAME, OPERATINGDATE
        //FROM PRODUCTIONLINE
        //WHERE FACID = :facid";

        //           await using var command = new OracleCommand(query, connection);
        //           command.Parameters.Add(new OracleParameter("facid", request.FacID));

        //           await using var reader = await command.ExecuteReaderAsync();
        //           while (await reader.ReadAsync())
        //           {

        //               result.Lines.Add(new ProductionLineInfo
        //               {
        //                   LineID = reader.GetInt32(0),
        //                   FacID = reader.GetInt32(1),
        //                   LineName = reader.GetString(2),
        //                   OperateDate = reader.GetDateTime(3).ToString("yyyy-MM-dd")
        //               });
        //           }

        //           result.ErrorCode = result.Lines.Count > 0 ? 0 : -1;
        //       }
        //       catch (Exception ex)
        //       {
        //           Console.WriteLine($"Error: {ex.Message}");
        //           result.ErrorCode = -1;
        //       }

        //       return result;
        //   }
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
                    SELECT MATERIALID, MATERIALNAME, SUPPLIERNAME, QUANTITY, IMPORTDATE 
                    FROM MATERIAL";

                await using var command = new OracleCommand(query, connection);
                await using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {

                    Console.WriteLine($"원자재ID: {reader.GetInt32(0)}"); // 로그 추가
                    Console.WriteLine($"원자재 종류: {reader.GetString(1)}"); // 로그 추가
                    Console.WriteLine($"공급업체: {reader.GetString(2)}"); // 로그 추가
                    Console.WriteLine($"수량 : {reader.GetInt32(3)}"); // 
                    Console.WriteLine();

                    result.Materials.Add(new MaterialInfo
                    {
                        MaterialID = reader.GetInt32(0),
                        MaterialName = reader.GetString(1),
                        SupplierName = reader.GetString(2),
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

        public override async Task<MaterialReply> GetMaterialSearchData(MaterialSearchRequest request, ServerCallContext context)
        {
            var result = new MaterialReply();

            try
            {
                Console.WriteLine("Received request for MATERIAL data with search criteria.");
                Console.WriteLine($"SupplierName in request: '{request.SupplierName}'");
                Console.WriteLine($"MaterialName in request: '{request.MaterialName}'");
                Console.WriteLine($"ImportDate in request: '{request.ImportDate}'");

                // DB 연결
                await using var connection = new OracleConnection(_connectionString);
                await connection.OpenAsync();

                // 기본 쿼리
                var query = "SELECT MATERIALID, MATERIALNAME, SUPPLIERNAME, QUANTITY, IMPORTDATE FROM MATERIAL WHERE 1=1";
                var parameters = new List<OracleParameter>();

                // 검색 조건에 맞춰 WHERE 절 추가
                if (!string.IsNullOrEmpty(request.SupplierName))
                {
                    query += " AND UPPER(COALESCE(SUPPLIERNAME, '')) LIKE :SUPPLIERNAME";
                    parameters.Add(new OracleParameter(":SUPPLIERNAME", OracleDbType.Varchar2)
                    {
                        Value = $"%{request.SupplierName.Trim().ToUpper()}%"
                    });
                }
                if (!string.IsNullOrEmpty(request.MaterialName))
                {
                    query += " AND UPPER(COALESCE(MATERIALNAME, '')) LIKE :MaterialName";
                    parameters.Add(new OracleParameter(":MaterialName", OracleDbType.Varchar2)
                    {
                        Value = $"%{request.MaterialName.Trim().ToUpper()}%"
                    });
                }
                if (!string.IsNullOrEmpty(request.ImportDate))
                {
                    query += " AND TRUNC(IMPORTDATE) = TO_DATE(:ImportDate, 'YYYY-MM-DD')";
                    parameters.Add(new OracleParameter(":ImportDate", OracleDbType.Varchar2)
                    {
                        Value = DateTime.Parse(request.ImportDate).ToString("yyyy-MM-dd") // 날짜만 문자열로 전달
                    });
                }

                // 최종 쿼리와 파라미터 출력
                Console.WriteLine($"Generated Query: {query}");
                foreach (var param in parameters)
                {
                    Console.WriteLine($"Parameter Name: {param.ParameterName}, Value: {param.Value}");
                }

                // 쿼리 실행
                await using var command = new OracleCommand(query, connection);
                command.Parameters.AddRange(parameters.ToArray());

                await using var reader = await command.ExecuteReaderAsync();

                // 데이터 읽기
                while (await reader.ReadAsync())
                {
                    var material = new MaterialInfo
                    {
                        MaterialID = reader.GetInt32(0),
                        MaterialName = reader.GetString(1),
                        SupplierName = reader.GetString(2),
                        Quantity = reader.GetInt32(3),
                        ImportDate = reader.GetDateTime(4).ToString("yyyy-MM-dd")
                    };
                    Console.WriteLine($"Material Found - ID: {material.MaterialID}, Name: {material.MaterialName}, Supplier: {material.SupplierName}");
                    result.Materials.Add(material);
                }

                result.ErrorCode = result.Materials.Count > 0 ? 0 : -1;

                if (result.ErrorCode == -1)
                {
                    Console.WriteLine("No matching records found.");
                }
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

                const string query = "SELECT SUPPLIERID, SUPPLIERNAME, CONTACTINFO, COUNTRY FROM supplier WHERE DELETED = 0";

                await using var command = new OracleCommand(query, connection);
                await using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {

                    Console.WriteLine($"공급업체 ID: {reader.GetInt32(0)}"); // 로그 추가
                    Console.WriteLine($"공급업체 : {reader.GetString(1)}"); // 로그 추가
                    Console.WriteLine();
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
                string facName = request.FacName;
                string location = request.Location;

                // 필수값 체크
                if (string.IsNullOrWhiteSpace(facName))
                {
                    result.ErrorCode = -1;
                    result.Message = "공장 이름(FacName)은 비워둘 수 없습니다.";
                    return result;
                }
                if (string.IsNullOrWhiteSpace(location))
                {
                    result.ErrorCode = -1;
                    result.Message = "공장 위치(Location)는 비워둘 수 없습니다.";
                    return result;
                }

                await using var connection = new OracleConnection(_connectionString);
                await connection.OpenAsync();

                // 공장 삽입 쿼리 (FacID는 DB의 트리거와 시퀀스에서 자동 생성)
                string query = "INSERT INTO FACTORY (FacName, Location) VALUES (:FacName, :Location)";

                await using var command = new OracleCommand(query, connection);

                // 파라미터 설정
                command.Parameters.Add(new OracleParameter("FacName", OracleDbType.Varchar2) { Value = facName });
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
        //공장 제거 서비스
        public override async Task<DeleteFactoryReply> DeleteFactoryData(DeleteFactoryRequest request, ServerCallContext context)
        {
            var response = new DeleteFactoryReply();

            try
            {
                // FacIDs를 쉼표로 구분된 문자열로 변환
                var facIds = string.Join(",", request.FacID);

                await using var connection = new OracleConnection(_connectionString);
                await connection.OpenAsync();

                // DELETED 값을 1로 업데이트하는 SQL
                var query = $"UPDATE FACTORY SET DELETED = 1 WHERE FACID IN ({facIds})";

                await using var command = new OracleCommand(query, connection);
                var rowsAffected = await command.ExecuteNonQueryAsync();

                // 업데이트 성공 처리
                response.ErrorCode = 0;
                response.ErrorMessage = $"{rowsAffected}개의 공장이 삭제 처리되었습니다.";
            }
            catch (Exception ex)
            {
                // 예외 처리
                response.ErrorCode = 1;
                response.ErrorMessage = $"서버 오류: {ex.Message}";
            }
            return response;
        }
        //공급업체 제거 서비스
        public override async Task<DeleteSupplyReply> DeleteSupplyData(DeleteSupplyRequest request, ServerCallContext context)
        {
            var response = new DeleteSupplyReply();

            try
            {
                // FacIDs를 쉼표로 구분된 문자열로 변환
                var supplyids = string.Join(",", request.SupplierID);


                await using var connection = new OracleConnection(_connectionString);
                await connection.OpenAsync();

                var query = $"UPDATE SUPPLIER SET DELETED = 1 WHERE SUPPLIERID IN ({string.Join(",", request.SupplierID.Select((_, i) => $":id{i}"))})";

                await using var command = new OracleCommand(query, connection);

                for (int i = 0; i < request.SupplierID.Count; i++)
                {
                    command.Parameters.Add(new OracleParameter($":id{i}", request.SupplierID[i]));
                }

                var rowsAffected = await command.ExecuteNonQueryAsync();

                // 업데이트 성공 처리
                response.ErrorCode = 0;
                response.ErrorMessage = $"{rowsAffected}개의 공급업체가 삭제 처리되었습니다.";
            }
            catch (Exception ex)
            {
                // 예외 처리
                response.ErrorCode = 1;
                response.ErrorMessage = $"서버 오류: {ex.Message}";
            }
            return response;
        }
        public override async Task<AddSupplieReply> AddSupplier(AddSupplierRequest request, ServerCallContext context)
        {
            var result = new AddSupplieReply();

            try
            {
                await using var connection = new OracleConnection(_connectionString);
                await connection.OpenAsync();

                const string query = "INSERT INTO Supplier (SupplierName, ContactInfo, Country) VALUES (:SupplierName, :ContactInfo, :Country)";
                await using var command = new OracleCommand(query, connection);
                command.Parameters.Add(new OracleParameter(":SupplierName", request.SupplierName));
                command.Parameters.Add(new OracleParameter(":ContactInfo", request.ContactInfo));
                command.Parameters.Add(new OracleParameter(":Country", request.Country));

                int rowsAffected = await command.ExecuteNonQueryAsync();
                result.ErrorCode = rowsAffected > 0 ? 0 : -1; // 성공 여부 확인
                result.Message = rowsAffected > 0 ? "Success" : "Failed to insert supplier.";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting supplier: {ex.Message}");
                result.ErrorCode = 1;
                result.Message = $"Error: {ex.Message}";
            }

            return result;
        }
        public override async Task<AddMaterialReply> AddMaterial(AddMaterialRequest request, ServerCallContext context)
        {
            var result = new AddMaterialReply();

            try
            {
                // 요청받은 데이터
                string materialName = request.MaterialName;
                string supplierName = request.SupplierName;
                int quantity = request.Quantity;

                // 입력 데이터 검증
                if (string.IsNullOrWhiteSpace(materialName))
                {
                    result.ErrorCode = -1;
                    result.Message = "원자재 이름(Name)은 비워둘 수 없습니다.";
                    return result;
                }

                if (string.IsNullOrEmpty(supplierName) || quantity <= 0)
                {
                    result.ErrorCode = -1;
                    result.Message = "공급업체를 선택하세요.";
                    return result;
                }

                await using var connection = new OracleConnection(_connectionString);
                await connection.OpenAsync();

                // 원자재 삽입 쿼리 (MaterialID는 DB의 트리거와 시퀀스에서 자동 생성)
                const string insertQuery = @"
									INSERT INTO MATERIAL (MATERIALNAME, SUPPLIERNAME, QUANTITY, IMPORTDATE)
									VALUES (:materialName, :supplierName, :quantity, SYSDATE)";

                await using var command = new OracleCommand(insertQuery, connection);

                // 파라미터 설정
                command.Parameters.Add(new OracleParameter("materialName", OracleDbType.Varchar2) { Value = materialName });
                command.Parameters.Add(new OracleParameter("supplierName", OracleDbType.Varchar2) { Value = supplierName });
                command.Parameters.Add(new OracleParameter("quantity", OracleDbType.Int32) { Value = quantity });

                // 삽입 실행
                int rowsInserted = await command.ExecuteNonQueryAsync();

                // 결과 처리
                if (rowsInserted > 0)
                {
                    result.ErrorCode = 0;
                    result.Message = "원자재가 성공적으로 추가되었습니다.";
                }
                else
                {
                    result.ErrorCode = -1;
                    result.Message = "원자재를 추가할 수 없습니다.";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding material: {ex.Message}");
                result.ErrorCode = -1;
                result.Message = $"오류 발생: {ex.Message}";
            }
            return result;
        }
        /// <summary>
        /// Product 테이블에서 데이터를 가져오는 메서드
        /// </summary>
        public override async Task<ProductReply> GetAllProductData(SteelMES.Empty request, ServerCallContext context)
        {
            var result = new ProductReply();

            try
            {
                await using var connection = new OracleConnection(_connectionString);
                await connection.OpenAsync();

                const string query = @"
        SELECT P.PRODUCTID, P.PRODUCTNAME, P.QUANTITY, P.PRODUCTIONDATE, P.QUALITYGRADE, D.DEFECTID, P.FACID
        FROM SCOTT.PRODUCT P
        LEFT JOIN SCOTT.DEFECT D ON P.PRODUCTID = D.PRODUCTID";

                await using var command = new OracleCommand(query, connection);
                await using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {

                    result.Products.Add(new ProductInfo
                    {
                        ProductID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        ProductName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Quantity = reader.IsDBNull(2) ? 0 : reader.GetDouble(2),
                        ProductionDate = reader.IsDBNull(3) ? string.Empty : reader.GetDateTime(3).ToString("yyyy-MM-dd"),
                        QualityGrade = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                        DefectID = reader.IsDBNull(5) ? 0 : reader.GetInt32(5),
                        FacID = reader.IsDBNull(6) ? 0 : reader.GetInt32(6)
                    });
                }

                result.ErrorCode = result.Products.Count > 0 ? 0 : -1; // 데이터가 있는지 여부에 따라 에러코드 설정
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception 발생: {ex.Message}");
                result.ErrorCode = -1;
            }

            return result;
        }

        // 로그인 메서드
        public override async Task<LoginReply> GetLogin(LoginRequest request, ServerCallContext context)
        {
            var result = new LoginReply();
            bool forceExit = false;  // 중복 로그인 여부를 저장할 변수 선언
            string clientInfo = context.Peer;

            try
            {
                // 세션 관리: 이미 로그인된 사용자가 있으면 로그인 거부하고 기존 세션을 로그아웃 후 새로 로그인 처리
                if (!m_UserSessionManager.AddUserSession(request.Username, out forceExit, clientInfo))
                {
                    // 중복 로그인 세션이 있을 경우, forceExit는 true
                    result.ForceExit = forceExit;
                    result.Message = "중복 로그인 세션이 감지되었습니다."; // 중복 로그인 감지
                    result.ErrorCode = -1;
                    return result;
                }

                // 데이터베이스 연결 및 인증 처리
                await using var connection = new OracleConnection(_connectionString);
                await connection.OpenAsync();

                const string query = @"
            SELECT USERNAME, USER_LEVEL
            FROM SCOTT.USERS
            WHERE USERNAME = :username AND PASSWORD = :password";

                await using var command = new OracleCommand(query, connection);
                command.Parameters.Add(new OracleParameter("username", request.Username));
                command.Parameters.Add(new OracleParameter("password", request.Password));

                await using var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    result.ErrorCode = 0;
                    result.Username = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                    result.UserLevel = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                    result.Message = "로그인 성공!";
                    result.ForceExit = forceExit; // 세션 종료 여부 전달
                    Console.WriteLine($"[로그인 성공] 사용자: {request.Username}, 레벨: {result.UserLevel}, 세션 상태: {forceExit}");
                }
                else
                {
                    result.ErrorCode = -1;
                    result.Message = "아이디 또는 비밀번호가 잘못되었습니다.";
                    result.ForceExit = forceExit; // 세션 종료 여부 전달
                    Console.WriteLine($"[로그인 실패] 사용자: {request.Username}, 이유: 잘못된 아이디 또는 비밀번호.");
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = -1;
                result.Message = $"서버 오류: {ex.Message}";
                Console.WriteLine($"Exception: {ex.Message}");
            }

            return result;
        }

        // 로그아웃 처리
        public override async Task<LogoutReply> GetLogout(LogoutRequest request, ServerCallContext context)
        {
            var result = new LogoutReply();

            try
            {
                // 사용자가 로그인되어 있는지 확인
                bool isLoggedIn = m_UserSessionManager.IsUserLoggedIn(request.UserId);

                if (isLoggedIn)
                {
                    // 로그인된 세션이 있다면 로그아웃 처리
                    bool logoutSuccess = m_UserSessionManager.ForceLogout(request.UserId);

                    if (logoutSuccess)
                    {
                        result.Success = true;
                        result.Message = "로그아웃 성공!";
                        Console.WriteLine($"[로그아웃 성공] 사용자 ID: {request.UserId}");
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "로그아웃 실패. 세션을 찾을 수 없습니다.";
                    }
                }
                else
                {
                    // 로그인되지 않은 사용자가 로그아웃 요청 시
                    result.Success = false;
                    result.Message = "로그인되지 않은 사용자입니다.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"서버 오류: {ex.Message}";
                Console.WriteLine($"Exception: {ex.Message}");
            }

            return result;
        }

        // 강제 로그아웃 처리
        public override async Task<ForceLogoutReply> ForceLogout(ForceLogoutRequest request, ServerCallContext context)
        {
            var result = new ForceLogoutReply();
            bool isUserLoggedOut = false;
            string clientInfo = context.Peer;
            try
            {
                // 강제 로그아웃 처리 
                bool logoutSuccess = m_UserSessionManager.ForceLogoutAndReturnState(request.UserId, out isUserLoggedOut);

                if (logoutSuccess)
                {
                    result.Success = true;
                    result.Message = "기존 세션이 종료되었습니다.";
                    result.PromptUser = true;  // 클라이언트에게 로그아웃 메시지를 띄우도록 알림

                    bool sessionAdded = m_UserSessionManager.AddUserSession(request.UserId, out bool forceExit, clientInfo);
                    if (!sessionAdded)
                    {
                        result.Success = false;
                        result.Message = "새로운 세션을 추가하는 데 실패했습니다.";
                        result.PromptUser = true;
                    }
                }
                else
                {
                    result.Success = false;
                    result.Message = "해당 사용자가 로그인되지 않았습니다.";
                    result.PromptUser = false;  // 클라이언트에게 메시지를 띄우지 않음
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"서버 오류: {ex.Message}";
                Console.WriteLine($"Exception: {ex.Message}");
            }

            return result;
        }


        // 회원 추가 메서드
        public override async Task<AddUserReply> AddUser(AddUserRequest request, ServerCallContext context)
        {
            var result = new AddUserReply();
            try
            {
                // 요청받은 데이터
                string userName = request.Username;
                string password = request.Password;
                // 입력 데이터 검증
                if (string.IsNullOrWhiteSpace(userName))
                {
                    result.ErrorCode = -1;
                    result.Message = "UserName은 비워둘 수 없습니다.";
                    return result;
                }
                if (string.IsNullOrEmpty(password))
                {
                    result.ErrorCode = -1;
                    result.Message = "비밀번호를 입력하세요";
                    return result;
                }
                await using var connection = new OracleConnection(_connectionString);
                await connection.OpenAsync();
                const string insertQuery = @"
										 INSERT INTO USERS (USERNAME, PASSWORD)
										 VALUES (:username, :password)";
                await using var command = new OracleCommand(insertQuery, connection);
                // 파라미터 설정
                command.Parameters.Add(new OracleParameter("username", OracleDbType.Varchar2) { Value = userName });
                command.Parameters.Add(new OracleParameter("password", OracleDbType.Varchar2) { Value = password });
                // 삽입 실행
                int rowsInserted = await command.ExecuteNonQueryAsync();
                // 결과 처리
                if (rowsInserted > 0)
                {
                    result.ErrorCode = 0;
                    result.Message = "회원가입 성공!";
                }
                else
                {
                    result.ErrorCode = -1;
                    result.Message = "회원가입 실패!";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding Users: {ex.Message}");
                result.ErrorCode = -1;
                result.Message = $"오류 발생: {ex.Message}";
            }
            return result;
        }

        /// <summary>
        /// Users 테이블에서 데이터를 가져오는 메서드
        /// </summary>
        public override async Task<UsersReply> GetAllUsersData(SteelMES.Empty request, ServerCallContext context)
        {
            var result = new UsersReply();

            try
            {
                // Oracle DB 연결
                await using var connection = new OracleConnection(_connectionString);
                await connection.OpenAsync();

                // Password를 제외하고 ID, USERNAME, USER_LEVEL만 가져오기
                const string query = @"
SELECT ID, USERNAME, USER_LEVEL
FROM SCOTT.USERS"; // Password 제외

                await using var command = new OracleCommand(query, connection);
                await using var reader = await command.ExecuteReaderAsync();

                // 데이터 읽기
                while (await reader.ReadAsync())
                {
                    result.Users.Add(new UsersInfo
                    {
                        ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),        // ID 컬럼 (0번 인덱스)
                        Username = reader.IsDBNull(1) ? string.Empty : reader.GetString(1), // USERNAME 컬럼 (1번 인덱스)
                        UserLevel = reader.IsDBNull(2) ? 0 : reader.GetInt32(2)  // USER_LEVEL 컬럼 (2번 인덱스)
                    });
                }

                // 데이터가 있으면 성공 코드 설정
                result.ErrorCode = result.Users.Count > 0 ? 0 : -1;
            }
            catch (Exception ex)
            {
                result.ErrorCode = -1;
                Console.WriteLine($"Exception: {ex.Message}");
            }

            return result;
        }
        /// <summary>
        // 사용자 정보를 가져오는 메서드
        /// </summary>
        public override async Task<SearchUserReply> SearchUser(SearchUserRequest request, ServerCallContext context)
        {
            var result = new SearchUserReply();

            try
            {
                // Oracle DB 연결
                await using var connection = new OracleConnection(_connectionString);
                await connection.OpenAsync();

                // 사용자 정보 조회 쿼리
                const string query = "SELECT USERNAME, PASSWORD, USER_LEVEL FROM USERS WHERE USERNAME = :username";
                await using var command = new OracleCommand(query, connection);
                command.Parameters.Add(new OracleParameter(":username", request.Username));

                await using var reader = await command.ExecuteReaderAsync();

                // 데이터 읽기
                if (await reader.ReadAsync())
                {
                    result.Users.Add(new UsersInfo
                    {
                        Username = reader.IsDBNull(0) ? string.Empty : reader.GetString(0),
                        Password = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        UserLevel = reader.IsDBNull(2) ? 0 : reader.GetInt32(2)
                    });

                    result.ErrorCode = 0;  // 성공
                }
                else
                {
                    result.ErrorCode = -1;  // 사용자 없음
                    result.Message = "User not found.";  // 사용자 없음 메시지
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = -1;  // 예외 발생
                result.Message = $"Error: {ex.Message}";
                Console.WriteLine($"Exception: {ex.Message}");
            }

            return result;
        }

        // 사용자 레벨 변경 메서드
        public override async Task<UpdateUserLevelReply> UpdateUserLevel(UpdateUserLevelRequest request, ServerCallContext context)
        {
            var reply = new UpdateUserLevelReply();

            try
            {
                // Oracle DB 연결
                await using var connection = new OracleConnection(_connectionString);
                await connection.OpenAsync();

                // 트랜잭션 시작
                using var transaction = await connection.BeginTransactionAsync();

                const string updateQuery = "UPDATE USERS SET USER_LEVEL = :userLevel WHERE USERNAME = :username";
                await using var command = new OracleCommand(updateQuery, connection);
                command.Parameters.Add(new OracleParameter(":userLevel", request.UserLevel));
                command.Parameters.Add(new OracleParameter(":username", request.Username));

                // 비동기적으로 쿼리 실행
                int rowsAffected = await command.ExecuteNonQueryAsync();

                // 트랜잭션 커밋 또는 롤백 처리
                if (rowsAffected > 0)
                {
                    await transaction.CommitAsync();
                    reply.ErrorCode = 0;  // 성공
                    reply.Message = "유저권한등급 변경 완료.";
                }
                else
                {
                    await transaction.RollbackAsync();
                    reply.ErrorCode = -1;  // 실패
                    reply.Message = "유저를 찾지 못했거나 권한등급을 변경하지 못했습니다.";
                }
            }
            catch (Exception ex)
            {
                // 예외 발생 시 트랜잭션 롤백
                reply.ErrorCode = -1;
                reply.Message = $"Error: {ex.Message}";
            }

            return reply;
        }
        public override async Task<ProductListReply> GetProductList(SteelMES.Empty request, ServerCallContext context)
        {
            var result = new ProductListReply();
            try
            {
                // 제품 목록을 하드코딩으로 제공
                result.ProductNames.AddRange(new[] { "Steel Beam", "Heavy Plate", "Cold Rolled Coil", "Hot Rolled Coil" });
                result.ErrorCode = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching product list: {ex.Message}");
                result.ErrorCode = -1;
            }
            return await Task.FromResult(result);
        }

        public override async Task<ProductOrderResponse> CreateProductOrder(ProductOrderRequest request, ServerCallContext context)
        {
            var response = new ProductOrderResponse();
            try
            {
                await using var connection = new OracleConnection(_connectionString);
                await connection.OpenAsync();

                // 제품 주문 삽입 쿼리 (ProductionDate는 SYSDATE가 기본값으로 자동 설정)
                const string query = @"
                INSERT INTO PRODUCT (PRODUCTNAME, QUANTITY, FACID, DELETED)
                VALUES (:productName, :quantity, :facId, 0)";

                await using var command = new OracleCommand(query, connection);
                command.Parameters.Add(new OracleParameter(":productName", request.ProductName));
                command.Parameters.Add(new OracleParameter(":quantity", request.Quantity));
                command.Parameters.Add(new OracleParameter(":facId", request.FactoryId));

                int rowsAffected = await command.ExecuteNonQueryAsync();
                response.ErrorCode = rowsAffected > 0 ? 0 : -1; // 성공 여부 확인
                response.Message = rowsAffected > 0 ? "Product order created successfully." : "Failed to create product order.";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating product order: {ex.Message}");
                response.ErrorCode = -1;
                response.Message = $"Error: {ex.Message}";
            }
            return response;
        }


        // 이미지 검출
        //public override async Task<ImageAnalysisReply> AnalyzeImage(SteelMES.ImageRequest request, ServerCallContext context)
        //{
        //    var result = new ImageAnalysisReply();

        //    try
        //    {
        //        Console.WriteLine($"[INFO] Received AnalyzeImage request for ProductID={request.ProductID}");

        //        byte[] imageData = request.ImageData.ToByteArray();
        //        if (imageData == null || imageData.Length == 0)
        //            throw new Exception("No image data received.");

        //        using var mat = Cv2.ImDecode(imageData, ImreadModes.Color);
        //        if (mat.Empty())
        //            throw new Exception("Failed to decode image data.");

        //        var resizedMat = new Mat();
        //        Cv2.Resize(mat, resizedMat, new OpenCvSharp.Size(640, 640));

        //        var session = LoadOnnxModel();
        //        var tensor = ConvertToTensor(resizedMat);
        //        var inputTensor = new NamedOnnxValue[] { NamedOnnxValue.CreateFromTensor("images", tensor) };

        //        using var results = session.Run(inputTensor);
        //        var outputTensor = results.First(x => x.Name == "output0").AsTensor<float>();
        //        string detectedClass = AnalyzeOutput(outputTensor);

        //        await SaveDefectToDB(request.ProductID, detectedClass);

        //        result.ErrorCode = 0;
        //        result.DefectType = detectedClass;
        //        result.Message = "Defect detected and saved successfully.";
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"[ERROR] {ex.Message}");
        //        result.ErrorCode = -1;
        //        result.Message = ex.Message;
        //    }

        //    return result;
        //}

        //private InferenceSession LoadOnnxModel()
        //{
        //    string modelPath = Path.Combine(Directory.GetCurrentDirectory(), "241211best.onnx");
        //    if (!File.Exists(modelPath))
        //        throw new FileNotFoundException($"ONNX 모델이 없습니다: {modelPath}");

        //    return new InferenceSession(modelPath);
        //}

        //private DenseTensor<float> ConvertToTensor(Mat mat)
        //{
        //    var tensor = new DenseTensor<float>(new[] { 1, 3, mat.Rows, mat.Cols });
        //    for (int i = 0; i < mat.Rows; i++)
        //        for (int j = 0; j < mat.Cols; j++)
        //        {
        //            var pixel = mat.At<Vec3b>(i, j);
        //            tensor[0, 0, i, j] = pixel.Item2 / 255.0f;
        //            tensor[0, 1, i, j] = pixel.Item1 / 255.0f;
        //            tensor[0, 2, i, j] = pixel.Item0 / 255.0f;
        //        }
        //    return tensor;
        //} //onnx모델

        //private string AnalyzeOutput(Tensor<float> outputTensor)
        //{
        //    if (outputTensor.Length == 0)
        //        return "none";

        //    var dimensions = outputTensor.Dimensions;
        //    if (dimensions.Length != 3)
        //        throw new Exception("Unexpected output dimensions.");

        //    int anchors = dimensions[1];
        //    int numFeatures = dimensions[2];
        //    float maxConfidence = float.MinValue;
        //    int maxClassIndex = -1;

        //    for (int i = 0; i < anchors; i++)
        //    {
        //        int numClasses = numFeatures - 5;
        //        float objectness = outputTensor[0, i, 4];
        //        for (int c = 0; c < numClasses; c++)
        //        {
        //            float confidence = outputTensor[0, i, 5 + c] * objectness;
        //            if (confidence > maxConfidence)
        //            {
        //                maxConfidence = confidence;
        //                maxClassIndex = c;
        //            }
        //        }
        //    }

        //    return maxClassIndex switch
        //    {
        //        0 => "crazing",
        //        1 => "inclusion",
        //        2 => "patches",
        //        3 => "pitted_surface",
        //        4 => "rolled-in_scale",
        //        5 => "scratches",
        //        _ => "none",
        //    };
        //}

        //private async Task SaveDefectToDB(int productId, string defectType)
        //{
        //    using var connection = new OracleConnection(_connectionString);
        //    await connection.OpenAsync();

        //    try
        //    {
        //        using var transaction = connection.BeginTransaction();
        //        try
        //        {
        //            // 품질 등급 결정
        //            string qualityGrade = null;

        //            if (defectType.ToLower() == "none")
        //            {
        //                qualityGrade = "A";
        //            }
        //            else
        //            {
        //                qualityGrade = "F";
        //            }

        //            // 불량일 경우 DEFECT 테이블에 저장
        //            if (qualityGrade == "F")
        //            {
        //                var defectQuery = @"
        //             INSERT INTO DEFECT (PRODUCTID, DEFECTTYPE, DETECTIONDATE)
        //             VALUES ( :productId, :defectType, SYSDATE)";

        //                using var defectCommand = new OracleCommand(defectQuery, connection);
        //                defectCommand.Transaction = transaction;
        //                defectCommand.Parameters.Add(new OracleParameter(":productId", productId));
        //                defectCommand.Parameters.Add(new OracleParameter(":defectType", defectType));

        //                var insertResult = await defectCommand.ExecuteNonQueryAsync();
        //                Console.WriteLine($"[INFO] Defect record inserted: {insertResult} rows");
        //            }

        //            // QUALITYGRADE 업데이트
        //            if (qualityGrade != null)
        //            {
        //                //var updateQuery = @"
        //                //                UPDATE SCOTT.PRODUCT 
        //                //                SET QUALITYGRADE = :qualityGrade
        //                //                WHERE PRODUCTID = :productId";

        //                //using var updateCommand = new OracleCommand(updateQuery, connection);
        //                //updateCommand.Transaction = transaction;
        //                //updateCommand.Parameters.Add(new OracleParameter(":qualityGrade", qualityGrade));
        //                //updateCommand.Parameters.Add(new OracleParameter(":productId", productId));

        //                //var rowsAffected = await updateCommand.ExecuteNonQueryAsync();
        //                //Console.WriteLine($"[INFO] Product {productId} quality grade updated to {qualityGrade}, Rows affected: {rowsAffected}");
        //            }
        //            else
        //            {
        //                Console.WriteLine($"[INFO] No quality grade update needed for ProductID: {productId}");
        //            }

        //            // 트랜잭션 커밋
        //            transaction.Commit();
        //            Console.WriteLine($"[INFO] Transaction committed successfully for ProductID: {productId}");
        //        }
        //        catch (Exception ex)
        //        {
        //            transaction.Rollback();
        //            Console.WriteLine($"[ERROR] Transaction rolled back: {ex.Message}");
        //            throw;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"[ERROR] Database operation failed: {ex.Message}");
        //        throw;
        //    }
        //}


        public override async Task<Empty> DiagnosticReqeust(Empty request, ServerCallContext context)
        {
            var result = new Empty();
            string clientInfo = context.Peer;

            return result;
        }
    }

    //public class PiControlServiceImpl : PiControlService.PiControlServiceBase
    //{
    //    private readonly DBServiceServer _dbServiceServer;
    //    private readonly InferenceSession _session;

    //    public override async Task<ImageReply> SendImage(GrpcPiControl.ImageRequest request, ServerCallContext context)
    //    {
    //        var response = new ImageReply();

    //        try
    //        {
    //            Console.WriteLine($"[INFO] Received SendImage request for ProductID={request.ProductId}");

    //            // Validate and save the image data
    //            byte[] imageData = request.ImageData.ToByteArray();
    //            if (imageData == null || imageData.Length == 0)
    //            {
    //                throw new Exception("No image data received.");
    //            }

    //            // Define the output directory based on ProductID
    //            string outputDir = Path.Combine("C:\\captured_images", $"product_{request.ProductId}");
    //            if (!Directory.Exists(outputDir))
    //            {
    //                Directory.CreateDirectory(outputDir); // Create directory if it doesn't exist
    //                Console.WriteLine($"[INFO] Directory created: {outputDir}");
    //            }

    //            // Define the image file path
    //            //string filePath = Path.Combine(outputDir, request.ImageName);
    //            //await File.WriteAllBytesAsync(filePath, imageData); // Save the image
    //            //Console.WriteLine($"[INFO] Image saved at {filePath}");

    //            // Sanitize and generate unique file name
    //            string sanitizedFileName = Path.GetFileName(request.ImageName);
    //            string uniqueFileName = $"{Path.GetFileNameWithoutExtension(sanitizedFileName)}_{Guid.NewGuid()}{Path.GetExtension(sanitizedFileName)}";
    //            string filePath = Path.Combine(outputDir, uniqueFileName);

    //            // Save the image
    //            await File.WriteAllBytesAsync(filePath, imageData);
    //            Console.WriteLine($"[INFO] Image saved at {filePath}");

    //            // Respond to Pi with success message
    //            response.Status = "Success";
    //            response.DefectType = "None"; // Replace with real defect analysis if implemented
    //            response.Message = "Image received and saved successfully.";

    //            // Call AnalyzeImage to process the image
    //            var analyzeRequest = new SteelMES.ImageRequest
    //            {
    //                ProductID = request.ProductId,
    //                ImageData = Google.Protobuf.ByteString.CopyFrom(imageData)
    //            };

    //            var analysisResult = await _dbServiceServer.AnalyzeImage(analyzeRequest, context);

    //            // Respond to Pi with success message
    //            response.Status = "Success";
    //            response.DefectType = analysisResult.DefectType; // Include defect type in response
    //            response.Message = analysisResult.Message;
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"[ERROR] {ex.Message}");
    //            response.Status = "Failure";
    //            response.DefectType = "None";
    //            response.Message = $"Error saving image: {ex.Message}";
    //        }

    //        return response;
    //    }
    //}
    public class PiControlServiceImpl : PiControlService.PiControlServiceBase
    {
        private readonly InferenceSession _session;
        private readonly string _connectionString;

        public PiControlServiceImpl()
        {
            string configFilePath = Path.Combine(Directory.GetCurrentDirectory(), "appsetting.json");
            var config = ConfigLoader.LoadConfig(configFilePath);
            _connectionString = ConfigLoader.BuildConnectionString(config.OracleConnection);

            try
            {
                string modelPath = Path.Combine(Directory.GetCurrentDirectory(), "models", "241211best.onnx");
                if (!File.Exists(modelPath))
                {
                    throw new FileNotFoundException($"ONNX 모델이 없습니다: {modelPath}");
                }
                _session = new InferenceSession(modelPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] ONNX 모델 로드 실패: {ex.Message}");
                throw;
            }
        }

        public override async Task<ImageReply> SendImage(GrpcPiControl.ImageRequest request, ServerCallContext context)
        {
            var response = new ImageReply();

            try
            {
                Console.WriteLine($"[INFO] 수신한  ProductID={request.ProductId}");
                byte[] imageData = request.ImageData.ToByteArray();
                if (imageData == null || imageData.Length == 0)
                {
                    throw new Exception("No image data received.");
                }

                // 이미지 저장
                string outputDir = Path.Combine("C:\\captured_images", $"product_{request.ProductId}");
                Directory.CreateDirectory(outputDir);
                string sanitizedFileName = Path.GetFileName(request.ImageName);
                string uniqueFileName = $"{Path.GetFileNameWithoutExtension(sanitizedFileName)}_{Guid.NewGuid()}{Path.GetExtension(sanitizedFileName)}";
                string filePath = Path.Combine(outputDir, uniqueFileName);
                await File.WriteAllBytesAsync(filePath, imageData);
                Console.WriteLine($"[INFO] Image saved at {filePath}");

                // 이미지 분석
                using var mat = Cv2.ImDecode(imageData, ImreadModes.Color);
                if (mat.Empty())
                {
                    throw new Exception("Failed to decode image data.");
                }

                var resizedMat = new Mat();
                Cv2.Resize(mat, resizedMat, new OpenCvSharp.Size(640, 640));

                // 텐서 변환
                var tensor = new DenseTensor<float>(new[] { 1, 3, 640, 640 });
                for (int y = 0; y < resizedMat.Height; y++)
                {
                    for (int x = 0; x < resizedMat.Width; x++)
                    {
                        var pixel = resizedMat.At<Vec3b>(y, x);
                        tensor[0, 0, y, x] = pixel[2] / 255.0f; // R
                        tensor[0, 1, y, x] = pixel[1] / 255.0f; // G
                        tensor[0, 2, y, x] = pixel[0] / 255.0f; // B
                    }
                }

                // 추론 실행
                var inputs = new List<NamedOnnxValue> { NamedOnnxValue.CreateFromTensor("images", tensor) };
                using var results = _session.Run(inputs);
                var outputTensor = results.First().AsTensor<float>();
                string defectType = AnalyzeOutput(outputTensor);

                await SaveDefectToDB(request.ProductId, defectType);

                // 응답 설정
                response.Status = "Success";
                response.DefectType = defectType;
                response.Message = "분석 완료";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex.Message}");
                response.Status = "Failure";
                response.DefectType = "None";
                response.Message = $"Error: {ex.Message}";
            }

            return response;
        }

        private string AnalyzeOutput(Tensor<float> outputTensor)
        {
            if (outputTensor.Length == 0)
                return "none";

            var dimensions = outputTensor.Dimensions;
            if (dimensions.Length != 3)
                throw new Exception("Unexpected output dimensions.");

            int anchors = dimensions[1];
            int numFeatures = dimensions[2];
            float maxConfidence = float.MinValue;
            int maxClassIndex = -1;

            for (int i = 0; i < anchors; i++)
            {
                int numClasses = numFeatures - 5;
                float objectness = outputTensor[0, i, 4];

                for (int c = 0; c < numClasses; c++)
                {
                    float confidence = outputTensor[0, i, 5 + c] * objectness;
                    if (confidence > maxConfidence)
                    {
                        maxConfidence = confidence;
                        maxClassIndex = c;
                    }
                }
            }

			// 신뢰도가 50% 미만이면 "정상" 처리
			if (maxConfidence < 0.5f)
			{
                Console.WriteLine($"[분석 결과] 불량 유형: 정상, 신뢰도: {maxConfidence:F2}");
                return "none";

            }


            string defectType = maxClassIndex switch
			{
				0 => "crazing",
				1 => "inclusion",
				2 => "patches",
				3 => "pitted_surface",
				4 => "rolled-in_scale",
				5 => "scratches",
				_ => "none",
			};

            Console.WriteLine($"[분석 결과] 불량 유형: {defectType}, 신뢰도: {maxConfidence:F2}");
            return defectType;
        }
        private async Task SaveDefectToDB(int productId, string defectType)
        {
            using var _connection = new OracleConnection(_connectionString);
            await _connection.OpenAsync();

            try
            {
                using var transaction = _connection.BeginTransaction();
                try
                {
                    // 품질 등급 결정
                    string qualityGrade = null;

                    if (defectType.ToLower() == "none")
                    {
                        qualityGrade = "A";
                        var updateQuery = @"
                                    UPDATE product
                                    SET QUALITYGRADE = :qualityGrade
                                    WHERE PRODUCTID = :productId";

                        using var updateCommand = new OracleCommand(updateQuery, _connection);
                        updateCommand.Parameters.Add(new OracleParameter(":qualityGrade", qualityGrade));
                        updateCommand.Parameters.Add(new OracleParameter(":productId", productId)); // ProductID 값이 필요합니다.
                        var updateResult = await updateCommand.ExecuteNonQueryAsync();
                        Console.WriteLine($"[INFO] QUALITYGRADE updated to A for ProductID: {productId}, Rows affected: {updateResult}");
                    }
                    else
                    {
                        qualityGrade = "F";
                        var FQuery =@"UPDATE product
                                    SET QUALITYGRADE = :qualityGrade
                                    WHERE PRODUCTID = :productId";
                        using var FqueryCommand = new OracleCommand(FQuery, _connection);
                        FqueryCommand.Parameters.Add(new OracleParameter(":qualityGrade", qualityGrade));
                        FqueryCommand.Parameters.Add(new OracleParameter(":productId", productId)); // ProductID 값이 필요합니다.
                        var FqueryResult = await FqueryCommand.ExecuteNonQueryAsync();
                        Console.WriteLine($"[INFO] QUALITYGRADE updated to F for ProductID: {productId}, Rows affected: {FqueryResult}");
                    }


                    // 불량일 경우 DEFECT 테이블에 저장
                    if (qualityGrade == "F")
                    {
                        var defectQuery = @"
                            INSERT INTO DEFECT (PRODUCTID, DEFECTTYPE, DETECTIONDATE)
                            VALUES ( :productId, :defectType, SYSDATE)";

                        using var defectCommand = new OracleCommand(defectQuery, _connection);
                        defectCommand.Transaction = transaction;
                        defectCommand.Parameters.Add(new OracleParameter(":productId", productId));
                        defectCommand.Parameters.Add(new OracleParameter(":defectType", defectType));

                        var insertResult = await defectCommand.ExecuteNonQueryAsync();
                        Console.WriteLine($"[INFO] Defect record inserted: {insertResult} rows");
                    }

                    // QUALITYGRADE 업데이트
                    if (qualityGrade != null)
                    {
                        //var updateQuery = @"
                        //                UPDATE SCOTT.PRODUCT 
                        //                SET QUALITYGRADE = :qualityGrade
                        //                WHERE PRODUCTID = :productId";

                        //using var updateCommand = new OracleCommand(updateQuery, connection);
                        //updateCommand.Transaction = transaction;
                        //updateCommand.Parameters.Add(new OracleParameter(":qualityGrade", qualityGrade));
                        //updateCommand.Parameters.Add(new OracleParameter(":productId", productId));

                        //var rowsAffected = await updateCommand.ExecuteNonQueryAsync();
                        //Console.WriteLine($"[INFO] Product {productId} quality grade updated to {qualityGrade}, Rows affected: {rowsAffected}");
                    }
                    else
                    {
                        Console.WriteLine($"[INFO] No quality grade update needed for ProductID: {productId}");
                    }

                    // 트랜잭션 커밋
                    transaction.Commit();
                    Console.WriteLine($"[INFO] Transaction committed successfully for ProductID: {productId}");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine($"[ERROR] Transaction rolled back: {ex.Message}");
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Database operation failed: {ex.Message}");
                throw;
            }
        }
    }
}
