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
using ReaLTaiizor.Forms;

namespace Project_SteelMES
{
    public partial class Material3 : MaterialForm
    {
        private Lost7 lost7;

        public Material3(Lost7 lost7)
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
            string text1 = textBox1.Text;
            string text2 = textBox2.Text;
            string text3 = textBox3.Text;

            // 입력값 검증
            if (string.IsNullOrWhiteSpace(text1) || string.IsNullOrWhiteSpace(text2) || string.IsNullOrWhiteSpace(text3))
            {
                MessageBox.Show("모든 필드를 입력하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 메시지 박스 표시
            DialogResult result = MessageBox.Show("등록하시겠습니까?", "확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                // 확인을 누르면 Lost7에 데이터 전달
                lost7.AddRowToDataGridView(text1, text2, text3);

                // TextBox 초기화
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();

            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e) //돌아가기 버튼
        {
            this.Dispose();
        }
    }
}
