using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.Collections;
using Oracle.ManagedDataAccess.Client;
using ReaLTaiizor.Forms;

namespace Project_SteelMES
{
    public partial class Supply2 : MaterialForm
    {
        private Lost7 lost7;

        public Supply2(Lost7 lost7)
        {
            InitializeComponent();
            this.lost7 = lost7; // lost7 참조 저장
        }

        private void Material3_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //등록 버튼
        {
            string supplierName = textBox1.Text; // 공급업체명 입력 필드
            string contactInfo = textBox2.Text;   // 연락처 입력 필드
            string country = textBox3.Text;           // 업체국가 입력 필드

            // 입력값 검증
            if (string.IsNullOrWhiteSpace(supplierName) || string.IsNullOrWhiteSpace(contactInfo) || string.IsNullOrWhiteSpace(country))
            {
                MessageBox.Show("모든 필드를 입력하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 메시지 박스 표시
            DialogResult result = MessageBox.Show("등록하시겠습니까?", "확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                // DB에 데이터 저장
                if (InsertSupplierToDatabase(supplierName, contactInfo, country))
                {
                    MessageBox.Show("등록 성공!", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // TextBox 초기화
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
                else
                {
                    MessageBox.Show("등록 실패. 다시 시도하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // 공급업체 정보를 DB에 저장하는 메서드
        private bool InsertSupplierToDatabase(string supplierName, string contactInfo, string country)
        {
            try
            {
                // Oracle 연결 문자열
                string connectionString = "User Id=scott;Password=tiger;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));";

                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();

                    // INSERT 쿼리
                    string query = "INSERT INTO SUPPLIER (SupplierName, ContactInfo, Country) VALUES (:SupplierName, :ContactInfo, :Country)";

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        // 파라미터 추가
                        command.Parameters.Add(new OracleParameter(":SupplierName", supplierName));
                        command.Parameters.Add(new OracleParameter(":ContactInfo", contactInfo));
                        command.Parameters.Add(new OracleParameter(":Country", country));

                        // 쿼리 실행
                        int rowsAffected = command.ExecuteNonQuery();

                        // 쿼리 성공 여부 반환
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"데이터베이스 오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e) //돌아가기 버튼
        {
            this.Dispose();
        }
    }
}
