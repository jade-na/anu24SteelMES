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
    public partial class Crown : CrownForm
    {
        public Crown()
        {
            InitializeComponent();
        }

        private void Crown_Load(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e) //Sign in
        {
            Lost lost = new Lost();
            lost.Show(); 
            this.Hide();
        }

        private void panel2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void hopeSwitch1_CheckedChanged(object sender, EventArgs e) //Password 암호화
        {
            this.hopeSwitch1.CheckedChanged += new System.EventHandler(this.hopeSwitch1_CheckedChanged);

            if (hopeSwitch1.Checked)
            {
                hopeTextBox2.UseSystemPasswordChar = true;
            }
            else
                hopeTextBox2.UseSystemPasswordChar = false;
        }

        private void hopeTextBox1_Click(object sender, EventArgs e) //ID 입력 시 초기화
        {

            this.hopeTextBox1.Enter += new System.EventHandler(this.hopeTextBox1_Enter);
            hopeTextBox1.Text = string.Empty;
        }
        private void hopeTextBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void hopeTextBox2_Click(object sender, EventArgs e) //Password 입력 시 초기화
        {
            this.hopeTextBox2.Enter += new System.EventHandler(this.hopeTextBox2_Enter);
            hopeTextBox2.Text = string.Empty;
        }
        private void hopeTextBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
