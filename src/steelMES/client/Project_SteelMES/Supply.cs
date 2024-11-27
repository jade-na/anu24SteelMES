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
    public partial class Lost7 : LostForm
    {

        

        public Lost7()
        {
            InitializeComponent();

            
        }

        

        private void Lost7_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Monitoring lost = new Monitoring();
            lost.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DefectRecord lost2 = new DefectRecord();
            lost2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Definition metro = new Definition();
            metro.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e) //추가 버튼
        {
            Supply2 material3 = new Supply2(this);
            material3.StartPosition = FormStartPosition.Manual; // 위치를 수동으로 지정
            material3.Location = new Point(1000, 220);
            material3.Show();
        }

        // Material3에서 호출할 행 추가 메서드
        public void AddRowToDataGridView(string text1, string text2, string text3)
        {
            dataGridView1.Rows.Add(text1, text2, text3);
        }

        private void button6_Click(object sender, EventArgs e) //설정 아이콘 버튼
        {
        }

        
    }
}
