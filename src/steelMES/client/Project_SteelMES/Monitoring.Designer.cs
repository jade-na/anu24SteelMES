using Project_SteelMES.Properties;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project_SteelMES
{
    partial class Monitoring
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint27 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 20D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint28 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 40D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint29 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 60D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint30 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 80D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint31 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 100D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint32 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 40D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint33 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 60D);
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint34 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 20D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint35 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 25D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint36 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 30D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint37 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 15D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint38 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 10D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint39 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 9D);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button6 = new System.Windows.Forms.Button();
            this.hopePictureBox3 = new ReaLTaiizor.Controls.HopePictureBox();
            this.hopePictureBox1 = new ReaLTaiizor.Controls.HopePictureBox();
            this.Menu_DefectRecordBtn = new System.Windows.Forms.Button();
            this.Menu_CloseBtn = new System.Windows.Forms.Button();
            this.Menu_WorkBtn = new System.Windows.Forms.Button();
            this.Menu_DefinitonBtn = new System.Windows.Forms.Button();
            this.Menu_MonitoringBtn = new System.Windows.Forms.Button();
            this.dungeonLabel1 = new ReaLTaiizor.Controls.DungeonLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dungeonLabel2 = new ReaLTaiizor.Controls.DungeonLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dungeonLabel3 = new ReaLTaiizor.Controls.DungeonLabel();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel4 = new System.Windows.Forms.Panel();
            this.MatOrderBtn = new System.Windows.Forms.Button();
            this.ProcessBtn = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.LoginInfo1 = new System.Windows.Forms.Label();
            this.LoginInfo2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AccountImg = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hopePictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hopePictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountImg)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(14)))), ((int)(((byte)(33)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.hopePictureBox3);
            this.panel1.Controls.Add(this.hopePictureBox1);
            this.panel1.Controls.Add(this.Menu_DefectRecordBtn);
            this.panel1.Controls.Add(this.Menu_CloseBtn);
            this.panel1.Controls.Add(this.Menu_WorkBtn);
            this.panel1.Controls.Add(this.Menu_DefinitonBtn);
            this.panel1.Controls.Add(this.Menu_MonitoringBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(2, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 986);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Project_SteelMES.Properties.Resources.logo__2_;
            this.pictureBox2.Location = new System.Drawing.Point(22, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(230, 101);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Image = global::Project_SteelMES.Properties.Resources.icon2__3_;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button6.Location = new System.Drawing.Point(97, 163);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(82, 71);
            this.button6.TabIndex = 10;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // hopePictureBox3
            // 
            this.hopePictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(196)))), ((int)(((byte)(204)))));
            this.hopePictureBox3.Image = global::Project_SteelMES.Properties.Resources.icon3__2_;
            this.hopePictureBox3.Location = new System.Drawing.Point(182, 175);
            this.hopePictureBox3.Name = "hopePictureBox3";
            this.hopePictureBox3.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.hopePictureBox3.Size = new System.Drawing.Size(74, 58);
            this.hopePictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.hopePictureBox3.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.hopePictureBox3.TabIndex = 9;
            this.hopePictureBox3.TabStop = false;
            this.hopePictureBox3.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // hopePictureBox1
            // 
            this.hopePictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(196)))), ((int)(((byte)(204)))));
            this.hopePictureBox1.Image = global::Project_SteelMES.Properties.Resources.icon1__2_;
            this.hopePictureBox1.Location = new System.Drawing.Point(28, 169);
            this.hopePictureBox1.Name = "hopePictureBox1";
            this.hopePictureBox1.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.hopePictureBox1.Size = new System.Drawing.Size(55, 66);
            this.hopePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.hopePictureBox1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.hopePictureBox1.TabIndex = 7;
            this.hopePictureBox1.TabStop = false;
            this.hopePictureBox1.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // Menu_DefectRecordBtn
            // 
            this.Menu_DefectRecordBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Menu_DefectRecordBtn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu_DefectRecordBtn.ForeColor = System.Drawing.Color.SkyBlue;
            this.Menu_DefectRecordBtn.Location = new System.Drawing.Point(-11, 357);
            this.Menu_DefectRecordBtn.Name = "Menu_DefectRecordBtn";
            this.Menu_DefectRecordBtn.Size = new System.Drawing.Size(289, 103);
            this.Menu_DefectRecordBtn.TabIndex = 3;
            this.Menu_DefectRecordBtn.Text = "불 량 이 력";
            this.Menu_DefectRecordBtn.UseVisualStyleBackColor = true;
            this.Menu_DefectRecordBtn.Click += new System.EventHandler(this.Menu_DefectRecordBtn_Click);
            // 
            // Menu_CloseBtn
            // 
            this.Menu_CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Menu_CloseBtn.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.Menu_CloseBtn.ForeColor = System.Drawing.Color.SkyBlue;
            this.Menu_CloseBtn.Location = new System.Drawing.Point(-11, 663);
            this.Menu_CloseBtn.Name = "Menu_CloseBtn";
            this.Menu_CloseBtn.Size = new System.Drawing.Size(289, 103);
            this.Menu_CloseBtn.TabIndex = 6;
            this.Menu_CloseBtn.Text = "종 료";
            this.Menu_CloseBtn.UseVisualStyleBackColor = true;
            this.Menu_CloseBtn.Click += new System.EventHandler(this.button5_Click);
            // 
            // Menu_WorkBtn
            // 
            this.Menu_WorkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Menu_WorkBtn.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.Menu_WorkBtn.ForeColor = System.Drawing.Color.SkyBlue;
            this.Menu_WorkBtn.Location = new System.Drawing.Point(-11, 561);
            this.Menu_WorkBtn.Name = "Menu_WorkBtn";
            this.Menu_WorkBtn.Size = new System.Drawing.Size(289, 103);
            this.Menu_WorkBtn.TabIndex = 5;
            this.Menu_WorkBtn.Text = "작 업 지 시";
            this.Menu_WorkBtn.UseVisualStyleBackColor = true;
            this.Menu_WorkBtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // Menu_DefinitonBtn
            // 
            this.Menu_DefinitonBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Menu_DefinitonBtn.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.Menu_DefinitonBtn.ForeColor = System.Drawing.Color.SkyBlue;
            this.Menu_DefinitonBtn.Location = new System.Drawing.Point(-11, 459);
            this.Menu_DefinitonBtn.Name = "Menu_DefinitonBtn";
            this.Menu_DefinitonBtn.Size = new System.Drawing.Size(289, 103);
            this.Menu_DefinitonBtn.TabIndex = 4;
            this.Menu_DefinitonBtn.Text = "불 량 정 의";
            this.Menu_DefinitonBtn.UseVisualStyleBackColor = true;
            this.Menu_DefinitonBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // Menu_MonitoringBtn
            // 
            this.Menu_MonitoringBtn.BackColor = System.Drawing.Color.SkyBlue;
            this.Menu_MonitoringBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Menu_MonitoringBtn.Font = new System.Drawing.Font("프리젠테이션 5 Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Menu_MonitoringBtn.ForeColor = System.Drawing.Color.Black;
            this.Menu_MonitoringBtn.Location = new System.Drawing.Point(-11, 255);
            this.Menu_MonitoringBtn.Name = "Menu_MonitoringBtn";
            this.Menu_MonitoringBtn.Size = new System.Drawing.Size(289, 103);
            this.Menu_MonitoringBtn.TabIndex = 2;
            this.Menu_MonitoringBtn.Text = "Monitoring";
            this.Menu_MonitoringBtn.UseVisualStyleBackColor = false;
            this.Menu_MonitoringBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // dungeonLabel1
            // 
            this.dungeonLabel1.BackColor = System.Drawing.Color.Transparent;
            this.dungeonLabel1.Font = new System.Drawing.Font("G마켓 산스 TTF Bold", 24F, System.Drawing.FontStyle.Bold);
            this.dungeonLabel1.ForeColor = System.Drawing.Color.White;
            this.dungeonLabel1.Location = new System.Drawing.Point(14, 8);
            this.dungeonLabel1.Name = "dungeonLabel1";
            this.dungeonLabel1.Size = new System.Drawing.Size(226, 35);
            this.dungeonLabel1.TabIndex = 7;
            this.dungeonLabel1.Text = "Monitoring";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(70)))));
            this.panel2.Controls.Add(this.chart1);
            this.panel2.Controls.Add(this.dungeonLabel2);
            this.panel2.Location = new System.Drawing.Point(3, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(960, 366);
            this.panel2.TabIndex = 1;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(70)))));
            chartArea5.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea5.AxisX.MajorGrid.Enabled = false;
            chartArea5.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            chartArea5.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea5.AxisY.MajorGrid.Enabled = false;
            chartArea5.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(64)))));
            chartArea5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(70)))));
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            this.chart1.Location = new System.Drawing.Point(110, 43);
            this.chart1.Name = "chart1";
            series5.ChartArea = "ChartArea1";
            series5.Color = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(225)))), ((int)(((byte)(245)))));
            series5.IsValueShownAsLabel = true;
            series5.LabelForeColor = System.Drawing.Color.White;
            series5.Legend = "Legend1";
            series5.Name = "Coil Production";
            dataPoint27.AxisLabel = "Jan";
            dataPoint28.AxisLabel = "Feb";
            dataPoint29.AxisLabel = "Mar";
            dataPoint30.AxisLabel = "Apr";
            dataPoint31.AxisLabel = "May";
            dataPoint32.AxisLabel = "Jun";
            dataPoint33.AxisLabel = "Jul";
            series5.Points.Add(dataPoint27);
            series5.Points.Add(dataPoint28);
            series5.Points.Add(dataPoint29);
            series5.Points.Add(dataPoint30);
            series5.Points.Add(dataPoint31);
            series5.Points.Add(dataPoint32);
            series5.Points.Add(dataPoint33);
            series5.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(731, 320);
            this.chart1.TabIndex = 0;
            // 
            // dungeonLabel2
            // 
            this.dungeonLabel2.BackColor = System.Drawing.Color.Transparent;
            this.dungeonLabel2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.dungeonLabel2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.dungeonLabel2.Location = new System.Drawing.Point(10, 9);
            this.dungeonLabel2.Name = "dungeonLabel2";
            this.dungeonLabel2.Size = new System.Drawing.Size(209, 40);
            this.dungeonLabel2.TabIndex = 8;
            this.dungeonLabel2.Text = "코일 생산량";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(70)))));
            this.panel3.Controls.Add(this.dungeonLabel3);
            this.panel3.Controls.Add(this.chart2);
            this.panel3.Location = new System.Drawing.Point(3, 478);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(494, 306);
            this.panel3.TabIndex = 1;
            // 
            // dungeonLabel3
            // 
            this.dungeonLabel3.BackColor = System.Drawing.Color.Transparent;
            this.dungeonLabel3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.dungeonLabel3.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.dungeonLabel3.Location = new System.Drawing.Point(10, 10);
            this.dungeonLabel3.Name = "dungeonLabel3";
            this.dungeonLabel3.Size = new System.Drawing.Size(135, 42);
            this.dungeonLabel3.TabIndex = 9;
            this.dungeonLabel3.Text = "불량 현황";
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(70)))));
            chartArea6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(70)))));
            chartArea6.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea6);
            legend3.BackColor = System.Drawing.Color.Transparent;
            legend3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            legend3.ForeColor = System.Drawing.Color.White;
            legend3.IsTextAutoFit = false;
            legend3.Name = "Legend1";
            this.chart2.Legends.Add(legend3);
            this.chart2.Location = new System.Drawing.Point(80, 56);
            this.chart2.Name = "chart2";
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series6.Legend = "Legend1";
            series6.Name = "Defects";
            dataPoint34.AxisLabel = "";
            dataPoint34.BorderColor = System.Drawing.Color.ForestGreen;
            dataPoint34.Color = System.Drawing.Color.Yellow;
            dataPoint34.Label = "";
            dataPoint34.LabelForeColor = System.Drawing.Color.Black;
            dataPoint34.LegendText = "Crazing";
            dataPoint35.Color = System.Drawing.Color.Lime;
            dataPoint35.Label = "";
            dataPoint35.LegendText = "Inclusions";
            dataPoint36.Color = System.Drawing.Color.Cyan;
            dataPoint36.Label = "";
            dataPoint36.LegendText = "Patches";
            dataPoint37.Color = System.Drawing.Color.Magenta;
            dataPoint37.Label = "";
            dataPoint37.LegendText = "Pitted Surface";
            dataPoint38.Color = System.Drawing.Color.DarkViolet;
            dataPoint38.Label = "";
            dataPoint38.LegendText = "Roll-in Scale";
            dataPoint39.Color = System.Drawing.Color.OrangeRed;
            dataPoint39.LegendText = "Scratches";
            series6.Points.Add(dataPoint34);
            series6.Points.Add(dataPoint35);
            series6.Points.Add(dataPoint36);
            series6.Points.Add(dataPoint37);
            series6.Points.Add(dataPoint38);
            series6.Points.Add(dataPoint39);
            this.chart2.Series.Add(series6);
            this.chart2.Size = new System.Drawing.Size(357, 219);
            this.chart2.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(70)))));
            this.panel4.Controls.Add(this.MatOrderBtn);
            this.panel4.Controls.Add(this.ProcessBtn);
            this.panel4.Location = new System.Drawing.Point(533, 478);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(430, 306);
            this.panel4.TabIndex = 1;
            // 
            // MatOrderBtn
            // 
            this.MatOrderBtn.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.MatOrderBtn.Location = new System.Drawing.Point(101, 83);
            this.MatOrderBtn.Name = "MatOrderBtn";
            this.MatOrderBtn.Size = new System.Drawing.Size(268, 69);
            this.MatOrderBtn.TabIndex = 12;
            this.MatOrderBtn.Text = "자재 주문";
            this.MatOrderBtn.UseVisualStyleBackColor = true;
            this.MatOrderBtn.Click += new System.EventHandler(this.button8_Click);
            // 
            // ProcessBtn
            // 
            this.ProcessBtn.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.ProcessBtn.Location = new System.Drawing.Point(101, 168);
            this.ProcessBtn.Name = "ProcessBtn";
            this.ProcessBtn.Size = new System.Drawing.Size(268, 69);
            this.ProcessBtn.TabIndex = 11;
            this.ProcessBtn.Text = "공정 관리";
            this.ProcessBtn.UseVisualStyleBackColor = true;
            this.ProcessBtn.Click += new System.EventHandler(this.button7_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dungeonLabel1);
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Location = new System.Drawing.Point(298, 147);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(966, 839);
            this.panel5.TabIndex = 8;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Black;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.LoginInfo1);
            this.panel6.Controls.Add(this.LoginInfo2);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.pictureBox1);
            this.panel6.Controls.Add(this.AccountImg);
            this.panel6.Location = new System.Drawing.Point(298, 61);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(966, 67);
            this.panel6.TabIndex = 9;
            // 
            // LoginInfo1
            // 
            this.LoginInfo1.AutoSize = true;
            this.LoginInfo1.ForeColor = System.Drawing.Color.White;
            this.LoginInfo1.Location = new System.Drawing.Point(853, 10);
            this.LoginInfo1.Name = "LoginInfo1";
            this.LoginInfo1.Size = new System.Drawing.Size(94, 21);
            this.LoginInfo1.TabIndex = 10;
            this.LoginInfo1.Text = "사용자 이름";
            // 
            // LoginInfo2
            // 
            this.LoginInfo2.AutoSize = true;
            this.LoginInfo2.ForeColor = System.Drawing.Color.White;
            this.LoginInfo2.Location = new System.Drawing.Point(854, 36);
            this.LoginInfo2.Name = "LoginInfo2";
            this.LoginInfo2.Size = new System.Drawing.Size(94, 21);
            this.LoginInfo2.TabIndex = 11;
            this.LoginInfo2.Text = "사용자 권한";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(546, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "날짜 및 시간";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Project_SteelMES.Properties.Resources.clock__2_;
            this.pictureBox1.Location = new System.Drawing.Point(488, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // AccountImg
            // 
            this.AccountImg.Image = global::Project_SteelMES.Properties.Resources.user;
            this.AccountImg.Location = new System.Drawing.Point(805, 15);
            this.AccountImg.Name = "AccountImg";
            this.AccountImg.Size = new System.Drawing.Size(37, 34);
            this.AccountImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AccountImg.TabIndex = 10;
            this.AccountImg.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Monitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(14)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(1280, 1024);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Image = null;
            this.Name = "Monitoring";
            this.Load += new System.EventHandler(this.Lost_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hopePictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hopePictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1; //Left
        private System.Windows.Forms.Panel panel2; //Top
        private System.Windows.Forms.Panel panel3; //BottomLft
        private System.Windows.Forms.Panel panel4; //BottomRigiht
        private System.Windows.Forms.Button Menu_MonitoringBtn; //대시보드 버튼
        private System.Windows.Forms.Button Menu_DefectRecordBtn; //불량 이력 버튼
        private System.Windows.Forms.Button Menu_DefinitonBtn; //불량 정의 버튼
        private System.Windows.Forms.Button Menu_WorkBtn; //생산 정보 버튼
        private System.Windows.Forms.Button Menu_CloseBtn; //종료 버튼
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel1; //대시보드 제목
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel2; //코일 생산량 제목
        private ReaLTaiizor.Controls.DungeonLabel dungeonLabel3; //불량 현황 제목
        private ReaLTaiizor.Controls.HopePictureBox hopePictureBox1; //아이콘1
        private ReaLTaiizor.Controls.HopePictureBox hopePictureBox3; //아이콘2
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1; //코일 생산량 차트
        private Chart chart2;
        private Button button6;
        private Panel panel5;
        private Panel panel6;
        private Button MatOrderBtn;
        private Button ProcessBtn;
        private PictureBox AccountImg;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Timer timer1;
        private Label label1;
        private Label LoginInfo1;
        private Label LoginInfo2;
    }
}