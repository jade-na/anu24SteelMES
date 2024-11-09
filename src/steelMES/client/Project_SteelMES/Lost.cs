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
    }
}
