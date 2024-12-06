using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using Newtonsoft.Json;
using System.Runtime;

namespace grpctestserver
{
    public class Config
    {
        public OracleConnectionConfig OracleConnection { get; set; }

        public GrpcSettings GrpcSettings { get; set; } //추가
    }

    public class GrpcSettings //추가
    {
        public string Host { get; set; }
        public int Port { get; set; }
    }

    public class OracleConnectionConfig
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Host {  get; set; }
        public int Port { get; set; }   
        public string Sid { get; set; }
    }
    public static class ConfigLoader
    {
        public static Config LoadConfig(string filePath)
        {
            try
            {
                var json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<Config>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"설정 파일을 읽는 중 오류 발생: {ex.Message}");
                return null;
            }
        }

        // 연결 문자열을 동적으로 생성
        public static string BuildConnectionString(OracleConnectionConfig config)
        {
            return $"User Id={config.UserId};Password={config.Password};Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={config.Host})(PORT={config.Port}))(CONNECT_DATA=(SID={config.Sid})))";
        }
    }
}
