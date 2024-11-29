using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using System.Windows.Forms;
using ReaLTaiizor.Forms;

namespace Project_SteelMES
{
    public partial class DefectRecord2 : MaterialForm
    {
		public string DefectID { get; set; }
		public string ProductID { get; set; }
		public string MaterialID { get; set; }
		public string DefectType { get; set; }
		public string DetectionDate { get; set; }
		public DefectRecord2()
        {
            InitializeComponent();
        }

        private void Material_Load(object sender, EventArgs e)
        {
			// 전달받은 데이터를 Label에 표시
			label2.Text = DefectType;
			label3.Text = DefectID;
			label4.Text = ProductID;
			label5.Text = MaterialID;
			label6.Text = DetectionDate;
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

		private void button5_Click(object sender, EventArgs e)
		{
			// Lost2 폼으로 돌아가기
			DefectRecord lost2Form = new DefectRecord();
			lost2Form.Show();
			this.Close();
		}
		private void OptionButton1_Click(object sender, EventArgs e)
		{
			
		}

		private void OptionButton2_Click(object sender, EventArgs e)
		{
			MessageBox.Show("기능 미구현");
		}
	}
}
