namespace Project_SteelMES
{
    partial class Membership
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.dungeonLabel2 = new ReaLTaiizor.Controls.DungeonLabel();
            this.SettingBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dungeonLabel1 = new ReaLTaiizor.Controls.DungeonLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.panel1.Controls.Add(this.refreshBtn);
            this.panel1.Controls.Add(this.dungeonLabel2);
            this.panel1.Controls.Add(this.SettingBtn);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(39, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(823, 495);
            this.panel1.TabIndex = 10;
            // 
            // refreshBtn
            // 
            this.refreshBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.refreshBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(215)))), ((int)(((byte)(235)))));
            this.refreshBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.refreshBtn.FlatAppearance.BorderSize = 0;
            this.refreshBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshBtn.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.refreshBtn.ForeColor = System.Drawing.Color.Black;
            this.refreshBtn.Location = new System.Drawing.Point(730, 454);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(90, 38);
            this.refreshBtn.TabIndex = 13;
            this.refreshBtn.Text = "조회";
            this.refreshBtn.UseVisualStyleBackColor = false;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // dungeonLabel2
            // 
            this.dungeonLabel2.AutoSize = true;
            this.dungeonLabel2.BackColor = System.Drawing.Color.Transparent;
            this.dungeonLabel2.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.dungeonLabel2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.dungeonLabel2.Location = new System.Drawing.Point(10, 12);
            this.dungeonLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dungeonLabel2.Name = "dungeonLabel2";
            this.dungeonLabel2.Size = new System.Drawing.Size(141, 32);
            this.dungeonLabel2.TabIndex = 12;
            this.dungeonLabel2.Text = "등록된 회원";
            this.dungeonLabel2.Click += new System.EventHandler(this.dungeonLabel2_Click);
            // 
            // SettingBtn
            // 
            this.SettingBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SettingBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.SettingBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SettingBtn.FlatAppearance.BorderSize = 0;
            this.SettingBtn.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.SettingBtn.ForeColor = System.Drawing.Color.IndianRed;
            this.SettingBtn.Image = global::Project_SteelMES.Properties.Resources.setting__2_;
            this.SettingBtn.Location = new System.Drawing.Point(755, 0);
            this.SettingBtn.Name = "SettingBtn";
            this.SettingBtn.Size = new System.Drawing.Size(68, 66);
            this.SettingBtn.TabIndex = 11;
            this.SettingBtn.UseVisualStyleBackColor = false;
            this.SettingBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(53)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(64, 84);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(690, 337);
            this.dataGridView1.TabIndex = 9;
            // 
            // dungeonLabel1
            // 
            this.dungeonLabel1.BackColor = System.Drawing.Color.Transparent;
            this.dungeonLabel1.Font = new System.Drawing.Font("G마켓 산스 TTF Bold", 26F, System.Drawing.FontStyle.Bold);
            this.dungeonLabel1.ForeColor = System.Drawing.Color.White;
            this.dungeonLabel1.Location = new System.Drawing.Point(32, 50);
            this.dungeonLabel1.Name = "dungeonLabel1";
            this.dungeonLabel1.Size = new System.Drawing.Size(231, 35);
            this.dungeonLabel1.TabIndex = 11;
            this.dungeonLabel1.Text = "회원 관리";
            // 
            // Membership
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(15)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(900, 630);
            this.Controls.Add(this.dungeonLabel1);
            this.Controls.Add(this.panel1);
            this.Image = global::Project_SteelMES.Properties.Resources.logo2;
            this.Name = "Membership";
            this.Text = "강 철 주 야";
            this.Load += new System.EventHandler(this.Lost9_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel1;
        private System.Windows.Forms.Button SettingBtn;
        public System.Windows.Forms.DataGridView dataGridView1;
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel2;
		private System.Windows.Forms.Button refreshBtn;
	}
}