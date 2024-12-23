﻿using Project_SteelMES.Properties;

namespace Project_SteelMES
{
    partial class DefectRecord
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.dungeonLabel1 = new ReaLTaiizor.Controls.DungeonLabel();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.dungeonLabel2 = new ReaLTaiizor.Controls.DungeonLabel();
			this.SelectBtn = new System.Windows.Forms.Button();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.dungeonLabel3 = new ReaLTaiizor.Controls.DungeonLabel();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(15)))), ((int)(((byte)(37)))));
			this.panel2.Controls.Add(this.dataGridView1);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.dungeonLabel1);
			this.panel2.Controls.Add(this.dateTimePicker2);
			this.panel2.Controls.Add(this.dungeonLabel2);
			this.panel2.Controls.Add(this.SelectBtn);
			this.panel2.Controls.Add(this.dateTimePicker1);
			this.panel2.Controls.Add(this.dungeonLabel3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Margin = new System.Windows.Forms.Padding(2);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1066, 693);
			this.panel2.TabIndex = 1;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 18F);
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(70)))));
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 18F);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridView1.Location = new System.Drawing.Point(20, 147);
			this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersVisible = false;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(44)))));
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 16F);
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
			this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(1024, 513);
			this.dataGridView1.TabIndex = 14;
			this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label1.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(487, 85);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 50);
			this.label1.TabIndex = 16;
			this.label1.Text = "-";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// dungeonLabel1
			// 
			this.dungeonLabel1.BackColor = System.Drawing.Color.Transparent;
			this.dungeonLabel1.Font = new System.Drawing.Font("G마켓 산스 TTF Bold", 26.25F, System.Drawing.FontStyle.Bold);
			this.dungeonLabel1.ForeColor = System.Drawing.Color.White;
			this.dungeonLabel1.Location = new System.Drawing.Point(13, 15);
			this.dungeonLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.dungeonLabel1.Name = "dungeonLabel1";
			this.dungeonLabel1.Size = new System.Drawing.Size(188, 38);
			this.dungeonLabel1.TabIndex = 9;
			this.dungeonLabel1.Text = "불량 이력";
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.Font = new System.Drawing.Font("Segoe UI", 18F);
			this.dateTimePicker2.Location = new System.Drawing.Point(533, 91);
			this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new System.Drawing.Size(303, 39);
			this.dateTimePicker2.TabIndex = 13;
			this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
			// 
			// dungeonLabel2
			// 
			this.dungeonLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.dungeonLabel2.Font = new System.Drawing.Font("G마켓 산스 TTF Medium", 18F, System.Drawing.FontStyle.Bold);
			this.dungeonLabel2.ForeColor = System.Drawing.Color.DeepSkyBlue;
			this.dungeonLabel2.Location = new System.Drawing.Point(166, 68);
			this.dungeonLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.dungeonLabel2.Name = "dungeonLabel2";
			this.dungeonLabel2.Size = new System.Drawing.Size(122, 22);
			this.dungeonLabel2.TabIndex = 10;
			this.dungeonLabel2.Text = "시작일";
			this.dungeonLabel2.Click += new System.EventHandler(this.dungeonLabel2_Click);
			// 
			// SelectBtn
			// 
			this.SelectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(215)))), ((int)(((byte)(235)))));
			this.SelectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SelectBtn.Font = new System.Drawing.Font("Segoe UI", 18F);
			this.SelectBtn.ForeColor = System.Drawing.Color.Black;
			this.SelectBtn.Location = new System.Drawing.Point(837, 90);
			this.SelectBtn.Margin = new System.Windows.Forms.Padding(2);
			this.SelectBtn.Name = "SelectBtn";
			this.SelectBtn.Size = new System.Drawing.Size(85, 23);
			this.SelectBtn.TabIndex = 15;
			this.SelectBtn.Text = "조회";
			this.SelectBtn.UseVisualStyleBackColor = false;
			this.SelectBtn.Click += new System.EventHandler(this.SelectBtn_Click);
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.CalendarMonthBackground = System.Drawing.SystemColors.HotTrack;
			this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateTimePicker1.Location = new System.Drawing.Point(171, 92);
			this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(303, 39);
			this.dateTimePicker1.TabIndex = 12;
			this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
			// 
			// dungeonLabel3
			// 
			this.dungeonLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.dungeonLabel3.Font = new System.Drawing.Font("G마켓 산스 TTF Medium", 18F, System.Drawing.FontStyle.Bold);
			this.dungeonLabel3.ForeColor = System.Drawing.Color.DeepSkyBlue;
			this.dungeonLabel3.Location = new System.Drawing.Point(526, 67);
			this.dungeonLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.dungeonLabel3.Name = "dungeonLabel3";
			this.dungeonLabel3.Size = new System.Drawing.Size(122, 22);
			this.dungeonLabel3.TabIndex = 11;
			this.dungeonLabel3.Text = "종료일";
			this.dungeonLabel3.Click += new System.EventHandler(this.dungeonLabel3_Click);
			// 
			// DefectRecord
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1066, 693);
			this.Controls.Add(this.panel2);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "DefectRecord";
			this.Text = "강철주야";
			this.Load += new System.EventHandler(this.Lost2_Load);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2; //Main
        private System.Windows.Forms.Button SelectBtn; //날짜 조회 버튼
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel1; //불량 이력 제목
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel2; //시작일 라벨
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel3; //종료일 라벨
        private System.Windows.Forms.DateTimePicker dateTimePicker1; //시작일
        private System.Windows.Forms.DateTimePicker dateTimePicker2; //종료일
        private System.Windows.Forms.DataGridView dataGridView1; //표
        private System.Windows.Forms.Label label1;
    }
}