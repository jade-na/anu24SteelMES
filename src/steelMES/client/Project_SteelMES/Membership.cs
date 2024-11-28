using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using ReaLTaiizor.Forms;

namespace Project_SteelMES
{
    public partial class Membership : LostForm
    {
        // Oracle 연결 문자열
        private string connectionString = "User Id=scott;Password=tiger;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));";
        public Membership()
        {
            InitializeComponent();

            // Oracle 데이터를 바로 로드
            LogindataFromOracle();
        }
        private void LogindataFromOracle()
        {
            try
            {
                // Oracle 연결
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();

                    // SQL 쿼리
                    string query = "SELECT USERNAME AS ID,PASSWORD AS 비밀번호, USER_LEVEL AS 유저권한등급 FROM USERS";

                    // 데이터 어댑터와 데이터 테이블 생성
                    using (OracleDataAdapter adapter = new OracleDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // DataGridView에 데이터 바인딩
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                // 오류 메시지 표시
                MessageBox.Show($"데이터를 불러오는 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Lost9_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Membership2 material4 = new Membership2(this);
            material4.Show();
        }
    }
}
