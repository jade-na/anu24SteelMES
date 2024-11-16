using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using ReaLTaiizor.Forms;

namespace Project_SteelMES
{
    public class prodHistoryInfo : Object
    {
        public prodHistoryInfo(String prodName, String sn, String lotId, String defactCode, DateTime dt) 
        {
            _prodName = prodName;
            _serialNum = sn;
            _lotId = lotId;
            _defactCode = defactCode;
            _produceDay = dt;
        }

        public String _prodName;
        public String _serialNum;
        public String _lotId;
        public String _defactCode;
        public DateTime _produceDay;
    }

    public class prodHistoryInfoReply : Object
    {
        public prodHistoryInfoReply()
        {
            prodHistoryInfos = new Queue<prodHistoryInfo>();
        }
        public int errorCode=0; // 반환 결과
        public Queue<prodHistoryInfo> prodHistoryInfos;
    }

    public class prodHistoryInfoRequest : Object
    {
        public prodHistoryInfoRequest(String tStart, String tEnd)
        {
            startTime = tStart;
            endTime = tEnd;
        }
        public String startTime; // yyyy-mm-dd hh:mm:ss
        public String endTime;   // yyyy-mm-dd hh:mm:ss
    }

    public class DB_Service : Object
    {
        public DB_Service() 
        { 
        }

        // 함수명 : 제품의 생산 이력을 요청 한다.
        // 파라메터 : 조회를 위해 시작일과 종료일을 지정한다.
        // 반환 : prodHistoryInfo 타입을 Queue에 넣어서 여려개 반환한다. 반역 함수 호출 실패 시 에러값을 반환한다.
        public prodHistoryInfoReply reqProdHistory(prodHistoryInfoRequest req) 
        {
            // 테스트를 위해 가짜 데이터를 만들어서 넣어 주도록 하겠습니다.
            // req.startTime, req.endTime을 이용하여 DB 데이터를 조회한다.
            // 조회된 DB 정보를 prodHistoryInfoReply에 채워서 반환 한다.
            prodHistoryInfoReply reply = new prodHistoryInfoReply();
            reply.errorCode = 0; // no error, error가 있을 때는 error code를 정의해서 반환
            reply.prodHistoryInfos.Enqueue(new prodHistoryInfo("A", "0001", "lot A", "defact A", DateTime.Now));
            reply.prodHistoryInfos.Enqueue(new prodHistoryInfo("B", "0002", "lot A", "defact B", DateTime.Now));
            reply.prodHistoryInfos.Enqueue(new prodHistoryInfo("C", "0003", "lot A", "defact C", DateTime.Now));
            reply.prodHistoryInfos.Enqueue(new prodHistoryInfo("D", "0004", "lot A", "defact D", DateTime.Now));
            reply.prodHistoryInfos.Enqueue(new prodHistoryInfo("E", "0005", "lot A", "defact E", DateTime.Now));
            reply.prodHistoryInfos.Enqueue(new prodHistoryInfo("F", "0006", "lot A", "defact F", DateTime.Now));

            return reply;
        }
    }
    public partial class Lost2 : LostForm
    {
        public Lost2()
        {
            db_service = new DB_Service();
            InitializeComponent();
        }
        DB_Service db_service;

        private void Lost2_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // 제품명, S/N, LOTID, 불량명, 시간
            var reply = db_service.reqProdHistory(new prodHistoryInfoRequest("2024-11-16 00:00:00", "2024-11-16 23:59:59"));
            if(reply.errorCode == 0)
            {
                foreach (var h in reply.prodHistoryInfos)
                {
                    dataGridView1.Rows.Add(h._prodName, h._serialNum, h._lotId, h._defactCode, h._produceDay.ToString());
                }
            }
            else
            {
                // error message
            }
        }
    }
}
