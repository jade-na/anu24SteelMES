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
    public partial class Definition : MetroForm
    {
		public Definition()
        {
            InitializeComponent();
        }

        private void Metro_Load(object sender, EventArgs e)
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

		private void button5_Click(object sender, EventArgs e)
		{
            Dispose();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			
		}
		
	}
}
