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
    public partial class Membership2 : MaterialForm
    {
        // Oracle 연결 문자열
        private string connectionString = "User Id=scott;Password=tiger;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));";
        private Membership _lost9; // Lost9 참조

        public Membership2(Membership lost9)
        {
            InitializeComponent();
            _lost9 = lost9; // Lost9 참조 저장

            // 기본값 선택 (옵션)
            comboBox1.SelectedIndex = 0; // 첫 번째 항목 선택
        }

        private void Material4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //검색 버튼
        {
            string searchValue = InputTextBox.Text.Trim();

            // 입력값이 비어 있는 경우
            if (string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("검색할 값을 입력하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // DB에서 사용자 검색
            SearchUserInDatabase(searchValue);
            
        }
        private void SearchUserInDatabase(string username)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();

                    // SQL 쿼리
                    string query = "SELECT UserName, Password FROM Users WHERE UserName = :username";

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        // 파라미터 추가
                        command.Parameters.Add(new OracleParameter(":username", username));

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // 검색 결과 출력
                                UserNameLabel.Text = reader["UserName"].ToString();
                                PasswordLabel.Text = reader["Password"].ToString();
                            }
                            else
                            {
                                // 검색 결과 없음
                                MessageBox.Show("검색 결과 없음", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 오류 처리
                MessageBox.Show($"데이터베이스 오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e) //변경 버튼
        {
            // comboBox1에서 선택한 값 가져오기
            string selectedLevel = comboBox1.SelectedItem?.ToString();

            // 선택된 값이 없는 경우
            if (string.IsNullOrEmpty(selectedLevel))
            {
                MessageBox.Show("레벨을 선택하세요", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // label4의 텍스트 가져오기 (검색된 UserName 값)
            string userName = UserNameLabel.Text;

            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("먼저 사용자를 검색하세요", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 변경 확인 메시지 표시
            var result = MessageBox.Show("변경하시겠습니까?", "확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                // UserName이 일치하는 Row를 찾아 UserLevel 업데이트
                foreach (DataGridViewRow row in _lost9.dataGridView1.Rows)
                {
                    if (row.Cells["UserName"].Value != null &&
                        row.Cells["UserName"].Value.ToString() == userName)
                    {
                        // UserLevel 컬럼에 선택된 레벨 설정
                        row.Cells["UserLevel"].Value = selectedLevel;
                        MessageBox.Show("레벨이 변경되었습니다.", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                // 일치하는 데이터가 없는 경우
                MessageBox.Show("사용자를 찾을 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
