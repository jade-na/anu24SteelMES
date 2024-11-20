using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using ReaLTaiizor.Forms;

namespace Project_SteelMES
{
    public partial class Lost : LostForm
    {
        public Lost()
        {
            InitializeComponent();
        }

        private void Lost_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lost2 lost2 = new Lost2();
            lost2.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // heiio
        }

		private void button3_Click(object sender, EventArgs e)
		{
            Metro metro = new Metro();
            metro.Show();
            this.Hide();
		}

		private void button5_Click(object sender, EventArgs e)
		{
            Dispose();
		}
	}
}
