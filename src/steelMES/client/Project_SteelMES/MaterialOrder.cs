using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_SteelMES
{
    public partial class MaterialOrder : Form
    {
        public MaterialOrder()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OrderBtn_Click(object sender, EventArgs e)
        {
            MaterialOrder2 matOrder = new MaterialOrder2();
            matOrder.Show();
            
        }
    }
}
