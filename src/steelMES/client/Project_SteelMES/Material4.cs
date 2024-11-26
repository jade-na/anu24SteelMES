using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReaLTaiizor.Forms;

namespace Project_SteelMES
{
    public partial class Material4 : MaterialForm
    {
        private Lost9 _lost9; // Lost9 참조

        public Material4(Lost9 lost9)
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
            // textBox1 값 가져오기
            string searchValue = textBox1.Text.Trim();

            // 입력값이 비어 있는 경우
            if (string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("검색결과 없음", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // DataGridView에서 검색
            bool found = false;
            foreach (DataGridViewRow row in _lost9.dataGridView1.Rows)
            {
                if (row.Cells["UserName"].Value != null &&
                    row.Cells["UserName"].Value.ToString() == searchValue)
                {
                    // 일치하는 데이터 발견
                    label4.Text = row.Cells["UserName"].Value.ToString();
                    label5.Text = row.Cells["Password"].Value.ToString();
                    found = true;
                    break;
                }
            }

            // 일치하는 데이터가 없는 경우
            if (!found)
            {
                MessageBox.Show("검색결과 없음", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            string userName = label4.Text;

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
