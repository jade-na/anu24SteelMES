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
    public partial class FactoryRegister : LostForm
    {

        
        public FactoryRegister()
        {
            InitializeComponent();

            dataGridView1.Rows.Add("포항공장", "경상북도 포항시 남구 동해안로 6261 (괴동동)");
            dataGridView1.Rows.Add("광양공장", "전남 광양시 폭포사랑길 20-26 (금호동)");
            dataGridView1.Rows.Add("당진공장", "충청남도 당진시 송악읍 북부산업로 1480");

        }

        private void Lost6_Load(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e) //추가 버튼
        {
            FactoryRegister2 material2 = new FactoryRegister2(this);
            material2.StartPosition = FormStartPosition.Manual; // 위치를 수동으로 지정
            material2.Location = new Point(1000, 220);
            material2.Show();
        }

        private void button6_Click(object sender, EventArgs e) //설정 아이콘 버튼
        {
            
        }

        

        // Material2에서 호출할 행 추가 메서드
        public void AddRowToDataGridView(string text1, string text2)
        {
            dataGridView1.Rows.Add(text1, text2);
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

        private void button6_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
