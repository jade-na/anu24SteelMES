﻿namespace Project_SteelMES
{
    partial class Lost5
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PruductDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QualityGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DefectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.monitoringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.불량이력ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.불량정의ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.생산관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.자재관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.공정관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dungeonLabel1 = new ReaLTaiizor.Controls.DungeonLabel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(93, 316);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(189, 20);
            this.progressBar1.TabIndex = 2;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(336, 316);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(189, 20);
            this.progressBar2.TabIndex = 5;
            // 
            // progressBar3
            // 
            this.progressBar3.Location = new System.Drawing.Point(577, 316);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(189, 20);
            this.progressBar3.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(14)))), ((int)(((byte)(34)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductID,
            this.ProductName,
            this.PruductDate,
            this.LineID,
            this.Weight,
            this.QualityGrade,
            this.DefectID});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(61, 370);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(726, 225);
            this.dataGridView1.TabIndex = 8;
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "ProductID";
            this.ProductID.Name = "ProductID";
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "ProductName";
            this.ProductName.Name = "ProductName";
            // 
            // PruductDate
            // 
            this.PruductDate.HeaderText = "ProductDate";
            this.PruductDate.Name = "PruductDate";
            // 
            // LineID
            // 
            this.LineID.HeaderText = "LineID";
            this.LineID.Name = "LineID";
            // 
            // Weight
            // 
            this.Weight.HeaderText = "Weight";
            this.Weight.Name = "Weight";
            // 
            // QualityGrade
            // 
            this.QualityGrade.HeaderText = "QualityGrade";
            this.QualityGrade.Name = "QualityGrade";
            // 
            // DefectID
            // 
            this.DefectID.HeaderText = "DefectID";
            this.DefectID.Name = "DefectID";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(130)))), ((int)(((byte)(255)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(789, 550);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 45);
            this.button1.TabIndex = 9;
            this.button1.Text = "조회";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(55)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monitoringToolStripMenuItem,
            this.불량이력ToolStripMenuItem,
            this.불량정의ToolStripMenuItem,
            this.생산관리ToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(2, 36);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(846, 27);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // monitoringToolStripMenuItem
            // 
            this.monitoringToolStripMenuItem.ForeColor = System.Drawing.Color.SkyBlue;
            this.monitoringToolStripMenuItem.Name = "monitoringToolStripMenuItem";
            this.monitoringToolStripMenuItem.Size = new System.Drawing.Size(90, 23);
            this.monitoringToolStripMenuItem.Text = "Monitoring";
            // 
            // 불량이력ToolStripMenuItem
            // 
            this.불량이력ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(55)))));
            this.불량이력ToolStripMenuItem.ForeColor = System.Drawing.Color.SkyBlue;
            this.불량이력ToolStripMenuItem.Name = "불량이력ToolStripMenuItem";
            this.불량이력ToolStripMenuItem.Size = new System.Drawing.Size(81, 23);
            this.불량이력ToolStripMenuItem.Text = "불량 이력";
            // 
            // 불량정의ToolStripMenuItem
            // 
            this.불량정의ToolStripMenuItem.ForeColor = System.Drawing.Color.SkyBlue;
            this.불량정의ToolStripMenuItem.Name = "불량정의ToolStripMenuItem";
            this.불량정의ToolStripMenuItem.Size = new System.Drawing.Size(81, 23);
            this.불량정의ToolStripMenuItem.Text = "불량 정의";
            // 
            // 생산관리ToolStripMenuItem
            // 
            this.생산관리ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.자재관리ToolStripMenuItem,
            this.공정관리ToolStripMenuItem});
            this.생산관리ToolStripMenuItem.ForeColor = System.Drawing.Color.SkyBlue;
            this.생산관리ToolStripMenuItem.Name = "생산관리ToolStripMenuItem";
            this.생산관리ToolStripMenuItem.Size = new System.Drawing.Size(81, 23);
            this.생산관리ToolStripMenuItem.Text = "생산 관리";
            // 
            // 자재관리ToolStripMenuItem
            // 
            this.자재관리ToolStripMenuItem.BackColor = System.Drawing.Color.LightGray;
            this.자재관리ToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.자재관리ToolStripMenuItem.Name = "자재관리ToolStripMenuItem";
            this.자재관리ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.자재관리ToolStripMenuItem.Text = "자재 관리";
            // 
            // 공정관리ToolStripMenuItem
            // 
            this.공정관리ToolStripMenuItem.BackColor = System.Drawing.Color.LightGray;
            this.공정관리ToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.공정관리ToolStripMenuItem.Name = "공정관리ToolStripMenuItem";
            this.공정관리ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.공정관리ToolStripMenuItem.Text = "공정 관리";
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.ForeColor = System.Drawing.Color.SkyBlue;
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(49, 23);
            this.종료ToolStripMenuItem.Text = "종료";
            // 
            // dungeonLabel1
            // 
            this.dungeonLabel1.BackColor = System.Drawing.Color.Transparent;
            this.dungeonLabel1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.dungeonLabel1.ForeColor = System.Drawing.Color.White;
            this.dungeonLabel1.Location = new System.Drawing.Point(15, 74);
            this.dungeonLabel1.Name = "dungeonLabel1";
            this.dungeonLabel1.Size = new System.Drawing.Size(111, 39);
            this.dungeonLabel1.TabIndex = 7;
            this.dungeonLabel1.Text = "공정 관리";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Project_SteelMES.Properties.Resources.prosess3;
            this.pictureBox3.Location = new System.Drawing.Point(567, 126);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(210, 173);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Project_SteelMES.Properties.Resources.progress2;
            this.pictureBox2.Location = new System.Drawing.Point(323, 99);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(218, 200);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Project_SteelMES.Properties.Resources.progress1;
            this.pictureBox1.Location = new System.Drawing.Point(80, 123);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(218, 173);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Lost5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(14)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(850, 600);
            this.Controls.Add(this.dungeonLabel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.progressBar3);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Image = global::Project_SteelMES.Properties.Resources.logo1;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Lost5";
            this.Text = " 강철주야";
            this.Load += new System.EventHandler(this.Lost5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PruductDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn QualityGrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn DefectID;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem monitoringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 불량이력ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 불량정의ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 생산관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 자재관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 공정관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel1;
    }
}