﻿using System;
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
    public partial class Lost9 : LostForm
    {
        public Lost9()
        {
            InitializeComponent();

            dataGridView1.Rows.Add("A", "0000");
            dataGridView1.Rows.Add("B", "1111");
            dataGridView1.Rows.Add("C", "2222");
        }

        private void Lost9_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Material4 material4 = new Material4(this);
            material4.Show();
        }
    }
}