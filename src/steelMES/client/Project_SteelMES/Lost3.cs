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
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Project_SteelMES
{
    public partial class Lost3 : LostForm
    {
        public Lost3()
        {
            InitializeComponent();

        }


        private void Lost3_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = null;
        }

        private void panel4_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
