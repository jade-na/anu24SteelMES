using System;
using System.Threading.Tasks;
using Grpc.Core;
using SteelMES;

namespace grpcDummyMesServer
{
    public class DBServiceServer : DB_Service.DB_ServiceBase
    {
        public override Task<prodHistoryInfoReply> reqProdHistory(prodHistoryInfoRequest request, ServerCallContext context)
        {
            // request.FromTime;
            // request.ToTime;
            var result = new prodHistoryInfoReply();

            result.ErrorCode = 0;

            var info1 = new prodHistoryInfo();
            info1.ProdName = "A";
            info1.SerialNum = "0001";
            info1.LotId = "LOT A";
            info1.DefactCode = "DEFACT A";
            info1.ProduceDay = "2024-11-17 00:00:00";
            result.Infos.Add(info1);

            var info2 = new prodHistoryInfo();
            info2.ProdName = "B";
            info2.SerialNum = "0002";
            info2.LotId = "LOT A";
            info2.DefactCode = "DEFACT B";
            info2.ProduceDay = "2024-11-17 00:00:10";
            result.Infos.Add(info2);

            return Task.FromResult(result);
        }
    }
}
