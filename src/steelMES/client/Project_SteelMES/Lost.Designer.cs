using Project_SteelMES.Properties;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project_SteelMES
{
    partial class Lost
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint14 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 20D);
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint15 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 40D);
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint16 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 60D);
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint17 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 80D);
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint18 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 100D);
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint19 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 40D);
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint20 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 60D);
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint21 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 20D);
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint22 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 25D);
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint23 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 30D);
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint24 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 15D);
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint25 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 10D);
			System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint26 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 9D);
			this.panel1 = new System.Windows.Forms.Panel();
			this.hopePictureBox3 = new ReaLTaiizor.Controls.HopePictureBox();
			this.hopePictureBox2 = new ReaLTaiizor.Controls.HopePictureBox();
			this.hopePictureBox1 = new ReaLTaiizor.Controls.HopePictureBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.dungeonLabel1 = new ReaLTaiizor.Controls.DungeonLabel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.dungeonLabel2 = new ReaLTaiizor.Controls.DungeonLabel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.dungeonLabel3 = new ReaLTaiizor.Controls.DungeonLabel();
			this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.panel4 = new System.Windows.Forms.Panel();
			this.dungeonLabel4 = new ReaLTaiizor.Controls.DungeonLabel();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.hopePictureBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.hopePictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.hopePictureBox1)).BeginInit();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(14)))), ((int)(((byte)(33)))));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.hopePictureBox3);
			this.panel1.Controls.Add(this.hopePictureBox2);
			this.panel1.Controls.Add(this.hopePictureBox1);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button5);
			this.panel1.Controls.Add(this.button4);
			this.panel1.Controls.Add(this.button3);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(2, 36);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(158, 562);
			this.panel1.TabIndex = 0;
			// 
			// hopePictureBox3
			// 
			this.hopePictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(196)))), ((int)(((byte)(204)))));
			this.hopePictureBox3.Image = global::Project_SteelMES.Properties.Resources.icon3;
			this.hopePictureBox3.Location = new System.Drawing.Point(98, 85);
			this.hopePictureBox3.Name = "hopePictureBox3";
			this.hopePictureBox3.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
			this.hopePictureBox3.Size = new System.Drawing.Size(24, 25);
			this.hopePictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.hopePictureBox3.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.hopePictureBox3.TabIndex = 9;
			this.hopePictureBox3.TabStop = false;
			this.hopePictureBox3.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			// 
			// hopePictureBox2
			// 
			this.hopePictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.hopePictureBox2.BackColor = System.Drawing.Color.Transparent;
			this.hopePictureBox2.Enabled = false;
			this.hopePictureBox2.Image = global::Project_SteelMES.Properties.Resources.icon2;
			this.hopePictureBox2.Location = new System.Drawing.Point(65, 85);
			this.hopePictureBox2.Name = "hopePictureBox2";
			this.hopePictureBox2.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
			this.hopePictureBox2.Size = new System.Drawing.Size(27, 25);
			this.hopePictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.hopePictureBox2.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.hopePictureBox2.TabIndex = 8;
			this.hopePictureBox2.TabStop = false;
			this.hopePictureBox2.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			// 
			// hopePictureBox1
			// 
			this.hopePictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(196)))), ((int)(((byte)(204)))));
			this.hopePictureBox1.Image = global::Project_SteelMES.Properties.Resources.icon1;
			this.hopePictureBox1.Location = new System.Drawing.Point(33, 85);
			this.hopePictureBox1.Name = "hopePictureBox1";
			this.hopePictureBox1.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
			this.hopePictureBox1.Size = new System.Drawing.Size(26, 25);
			this.hopePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.hopePictureBox1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.hopePictureBox1.TabIndex = 7;
			this.hopePictureBox1.TabStop = false;
			this.hopePictureBox1.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.ForeColor = System.Drawing.Color.SkyBlue;
			this.button2.Location = new System.Drawing.Point(-11, 192);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(179, 70);
			this.button2.TabIndex = 3;
			this.button2.Text = "불량 이력";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button5
			// 
			this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button5.ForeColor = System.Drawing.Color.SkyBlue;
			this.button5.Location = new System.Drawing.Point(-11, 402);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(179, 70);
			this.button5.TabIndex = 6;
			this.button5.Text = "종료";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button4
			// 
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button4.ForeColor = System.Drawing.Color.SkyBlue;
			this.button4.Location = new System.Drawing.Point(-11, 332);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(179, 70);
			this.button4.TabIndex = 5;
			this.button4.Text = "생산 정보";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.ForeColor = System.Drawing.Color.SkyBlue;
			this.button3.Location = new System.Drawing.Point(-11, 262);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(179, 70);
			this.button3.TabIndex = 4;
			this.button3.Text = "불량 정의";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.SkyBlue;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.ForeColor = System.Drawing.Color.Black;
			this.button1.Location = new System.Drawing.Point(-11, 122);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(179, 70);
			this.button1.TabIndex = 2;
			this.button1.Text = "Monitoring";
			this.button1.UseVisualStyleBackColor = false;
			// 
			// dungeonLabel1
			// 
			this.dungeonLabel1.BackColor = System.Drawing.Color.Transparent;
			this.dungeonLabel1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
			this.dungeonLabel1.ForeColor = System.Drawing.Color.White;
			this.dungeonLabel1.Location = new System.Drawing.Point(172, 39);
			this.dungeonLabel1.Name = "dungeonLabel1";
			this.dungeonLabel1.Size = new System.Drawing.Size(200, 35);
			this.dungeonLabel1.TabIndex = 7;
			this.dungeonLabel1.Text = "Monitoring";
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(48)))));
			this.panel2.Controls.Add(this.chart1);
			this.panel2.Controls.Add(this.dungeonLabel2);
			this.panel2.Location = new System.Drawing.Point(177, 91);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(653, 237);
			this.panel2.TabIndex = 1;
			// 
			// chart1
			// 
			this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(48)))));
			chartArea3.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
			chartArea3.AxisX.MajorGrid.Enabled = false;
			chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
			chartArea3.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
			chartArea3.AxisY.MajorGrid.Enabled = false;
			chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
			chartArea3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(44)))));
			chartArea3.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea3);
			this.chart1.Location = new System.Drawing.Point(55, 41);
			this.chart1.Name = "chart1";
			series3.ChartArea = "ChartArea1";
			series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(225)))), ((int)(((byte)(245)))));
			series3.IsValueShownAsLabel = true;
			series3.LabelForeColor = System.Drawing.Color.White;
			series3.Legend = "Legend1";
			series3.Name = "Coil Production";
			dataPoint14.AxisLabel = "Jan";
			dataPoint15.AxisLabel = "Feb";
			dataPoint16.AxisLabel = "Mar";
			dataPoint17.AxisLabel = "Apr";
			dataPoint18.AxisLabel = "May";
			dataPoint19.AxisLabel = "Jun";
			dataPoint20.AxisLabel = "Jul";
			series3.Points.Add(dataPoint14);
			series3.Points.Add(dataPoint15);
			series3.Points.Add(dataPoint16);
			series3.Points.Add(dataPoint17);
			series3.Points.Add(dataPoint18);
			series3.Points.Add(dataPoint19);
			series3.Points.Add(dataPoint20);
			series3.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
			this.chart1.Series.Add(series3);
			this.chart1.Size = new System.Drawing.Size(525, 196);
			this.chart1.TabIndex = 0;
			// 
			// dungeonLabel2
			// 
			this.dungeonLabel2.BackColor = System.Drawing.Color.Transparent;
			this.dungeonLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.dungeonLabel2.ForeColor = System.Drawing.Color.DeepSkyBlue;
			this.dungeonLabel2.Location = new System.Drawing.Point(11, 11);
			this.dungeonLabel2.Name = "dungeonLabel2";
			this.dungeonLabel2.Size = new System.Drawing.Size(98, 24);
			this.dungeonLabel2.TabIndex = 8;
			this.dungeonLabel2.Text = "코일 생산량";
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(48)))));
			this.panel3.Controls.Add(this.dungeonLabel3);
			this.panel3.Controls.Add(this.chart2);
			this.panel3.Location = new System.Drawing.Point(177, 347);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(343, 228);
			this.panel3.TabIndex = 1;
			// 
			// dungeonLabel3
			// 
			this.dungeonLabel3.BackColor = System.Drawing.Color.Transparent;
			this.dungeonLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.dungeonLabel3.ForeColor = System.Drawing.Color.DeepSkyBlue;
			this.dungeonLabel3.Location = new System.Drawing.Point(11, 11);
			this.dungeonLabel3.Name = "dungeonLabel3";
			this.dungeonLabel3.Size = new System.Drawing.Size(98, 24);
			this.dungeonLabel3.TabIndex = 9;
			this.dungeonLabel3.Text = "불량 현황";
			// 
			// chart2
			// 
			this.chart2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(44)))));
			chartArea4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(44)))));
			chartArea4.Name = "ChartArea1";
			this.chart2.ChartAreas.Add(chartArea4);
			legend2.BackColor = System.Drawing.Color.Transparent;
			legend2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
			legend2.ForeColor = System.Drawing.Color.White;
			legend2.IsTextAutoFit = false;
			legend2.Name = "Legend1";
			this.chart2.Legends.Add(legend2);
			this.chart2.Location = new System.Drawing.Point(15, 44);
			this.chart2.Name = "chart2";
			this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
			series4.ChartArea = "ChartArea1";
			series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
			series4.Legend = "Legend1";
			series4.Name = "Defects";
			dataPoint21.AxisLabel = "";
			dataPoint21.BorderColor = System.Drawing.Color.ForestGreen;
			dataPoint21.Color = System.Drawing.Color.Yellow;
			dataPoint21.Label = "";
			dataPoint21.LabelForeColor = System.Drawing.Color.Black;
			dataPoint21.LegendText = "Crazing";
			dataPoint22.Color = System.Drawing.Color.Lime;
			dataPoint22.Label = "";
			dataPoint22.LegendText = "Inclusions";
			dataPoint23.Color = System.Drawing.Color.Cyan;
			dataPoint23.Label = "";
			dataPoint23.LegendText = "Patches";
			dataPoint24.Color = System.Drawing.Color.Magenta;
			dataPoint24.Label = "";
			dataPoint24.LegendText = "Pitted Surface";
			dataPoint25.Color = System.Drawing.Color.DarkViolet;
			dataPoint25.Label = "";
			dataPoint25.LegendText = "Roll-in Scale";
			dataPoint26.Color = System.Drawing.Color.OrangeRed;
			dataPoint26.LegendText = "Scratches";
			series4.Points.Add(dataPoint21);
			series4.Points.Add(dataPoint22);
			series4.Points.Add(dataPoint23);
			series4.Points.Add(dataPoint24);
			series4.Points.Add(dataPoint25);
			series4.Points.Add(dataPoint26);
			this.chart2.Series.Add(series4);
			this.chart2.Size = new System.Drawing.Size(312, 170);
			this.chart2.TabIndex = 0;
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(48)))));
			this.panel4.Controls.Add(this.dungeonLabel4);
			this.panel4.Location = new System.Drawing.Point(540, 347);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(290, 228);
			this.panel4.TabIndex = 1;
			// 
			// dungeonLabel4
			// 
			this.dungeonLabel4.BackColor = System.Drawing.Color.Transparent;
			this.dungeonLabel4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.dungeonLabel4.ForeColor = System.Drawing.Color.DeepSkyBlue;
			this.dungeonLabel4.Location = new System.Drawing.Point(11, 11);
			this.dungeonLabel4.Name = "dungeonLabel4";
			this.dungeonLabel4.Size = new System.Drawing.Size(113, 24);
			this.dungeonLabel4.TabIndex = 10;
			this.dungeonLabel4.Text = "총불량 검출률";
			// 
			// Lost
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(14)))), ((int)(((byte)(34)))));
			this.ClientSize = new System.Drawing.Size(850, 600);
			this.Controls.Add(this.dungeonLabel1);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "Lost";
			this.Text = "강철주야";
			this.Load += new System.EventHandler(this.Lost_Load);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.hopePictureBox3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.hopePictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.hopePictureBox1)).EndInit();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
			this.panel4.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1; //Left
        private System.Windows.Forms.Panel panel2; //Top
        private System.Windows.Forms.Panel panel3; //BottomLft
        private System.Windows.Forms.Panel panel4; //BottomRigiht
        private System.Windows.Forms.Button button1; //대시보드 버튼
        private System.Windows.Forms.Button button2; //불량 이력 버튼
        private System.Windows.Forms.Button button3; //불량 정의 버튼
        private System.Windows.Forms.Button button4; //생산 정보 버튼
        private System.Windows.Forms.Button button5; //종료 버튼
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel1; //대시보드 제목
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel2; //코일 생산량 제목
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel3; //불량 현황 제목
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel4; //총불량 검출률 제목
        private ReaLTaiizor.Controls.HopePictureBox hopePictureBox1; //아이콘1
        private ReaLTaiizor.Controls.HopePictureBox hopePictureBox3; //아이콘2
        private ReaLTaiizor.Controls.HopePictureBox hopePictureBox2; //아이콘3
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1; //코일 생산량 차트
        private Chart chart2;
    }
}