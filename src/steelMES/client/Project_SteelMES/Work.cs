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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project_SteelMES
{
    public partial class Work : Form
    {
        public Work()
        {
            InitializeComponent();
        }

        private void Lost8_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dungeonLabel3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            // ComboBox1, NumericUpDown1, ComboBox2 값 가져오기
            string comboBox1Value = comboBox1.Text; // 선택된 텍스트
            string numericUpDown7Value = numericUpDown7.Value.ToString(); // 숫자 값
            string comboBox3Value = comboBox3.Text; // 선택된 텍스트

            // 입력값 확인
            if (string.IsNullOrWhiteSpace(comboBox1Value) ||
                numericUpDown7.Value == 0 ||
                string.IsNullOrWhiteSpace(comboBox3Value))
            {
                // 경고 메시지 표시
                MessageBox.Show("모든 필드를 입력해주세요.", "입력 확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // DataGridView에 새 행 추가
            dataGridView1.Rows.Add(comboBox1Value, numericUpDown7Value, comboBox3Value);
        }

        private void button9_Click(object sender, EventArgs e) //작업 지시 버튼
        {
            
        }
    }
}
