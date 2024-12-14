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

            if (label2.Text == "Crazing")
            {
                pictureBox1.Image = Properties.Resources.crazing;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // 이미지 크기를 PictureBox에 맞게 조정
            }
			else if(label2.Text == "Inclusions")
			{
                pictureBox1.Image = Properties.Resources.inclusions;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pictureBox1.Image = null; // 조건이 맞지 않으면 이미지를 제거
            }
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
			this.Dispose();
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
