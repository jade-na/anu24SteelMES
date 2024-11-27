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
    public partial class MaterialOrder2 : PoisonForm
    {
        public MaterialOrder2()
        {
            InitializeComponent();

            // 위치 고정 설정
            this.StartPosition = FormStartPosition.Manual; // 위치를 수동으로 설정
            this.Location = new Point(1200, 250); // (300, 200) 위치에 폼 배치

            
            
        }

        private void OrderBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void MaterialOrder2_Load(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
