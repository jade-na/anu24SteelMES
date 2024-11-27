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
    public partial class FactoryRegister2 : MaterialForm
    {
        private FactoryRegister lost6;

        public FactoryRegister2(FactoryRegister lost6)
        {
            InitializeComponent();
            this.lost6 = lost6; // lost6 참조 저장
        }

        private void Material2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //추가 버튼
        {
            string facName = textBox1.Text;
            string location = textBox2.Text;

            // 입력값 검증
            if (string.IsNullOrWhiteSpace(facName) || string.IsNullOrWhiteSpace(location))
            {
                MessageBox.Show("모든 필드를 입력하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 메시지 박스 표시
            DialogResult result = MessageBox.Show("등록하시겠습니까?", "확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                // DB에 데이터 저장
                if (InsertFactoryToDatabase(facName, location))
                {
                    MessageBox.Show("등록 성공!", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // TextBox 초기화
                    textBox1.Clear();
                    textBox2.Clear();
                }
                else
                {
                    MessageBox.Show("등록 실패. 다시 시도하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        // 공장이름과 위치를 DB에 저장하는 메서드
        private bool InsertFactoryToDatabase(string facName, string location)
        {
            try
            {
                // Oracle 연결 문자열
                string connectionString = "User Id=scott;Password=tiger;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));";

                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();

                    // INSERT 쿼리
                    string query = "INSERT INTO FACTORY (FacName, Location) VALUES (:FacName, :Location)";

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        // 파라미터 추가
                        command.Parameters.Add(new OracleParameter(":FacName", facName));
                        command.Parameters.Add(new OracleParameter(":Location", location));

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
