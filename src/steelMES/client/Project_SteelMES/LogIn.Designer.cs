using Project_SteelMES.Properties;

namespace Project_SteelMES
{
    partial class Login
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.parrotFormEllipse1 = new ReaLTaiizor.Controls.ParrotFormEllipse();
            this.parrotFormHandle1 = new ReaLTaiizor.Controls.ParrotFormHandle();
            this.parrotFormHandle2 = new ReaLTaiizor.Controls.ParrotFormHandle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.JoinBtn = new System.Windows.Forms.Button();
            this.hopeSwitch1 = new ReaLTaiizor.Controls.HopeSwitch();
            this.Password = new ReaLTaiizor.Controls.HopeTextBox();
            this.UserID = new ReaLTaiizor.Controls.HopeTextBox();
            this.dungeonLinkLabel1 = new ReaLTaiizor.Controls.DungeonLinkLabel();
            this.materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // parrotFormEllipse1
            // 
            this.parrotFormEllipse1.CornerRadius = 10;
            this.parrotFormEllipse1.EffectedForm = this;
            // 
            // parrotFormHandle1
            // 
            this.parrotFormHandle1.DockAtTop = true;
            this.parrotFormHandle1.HandleControl = this.panel1;
            // 
            // parrotFormHandle2
            // 
            this.parrotFormHandle2.DockAtTop = true;
            this.parrotFormHandle2.HandleControl = this.panel2;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(10)))), ((int)(((byte)(37)))));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(-3, -4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(293, 542);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Segoe UI Semibold", 8F);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(176, 428);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 41);
            this.button3.TabIndex = 31;
            this.button3.Text = "고객센터";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 8F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(72, 485);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 41);
            this.button2.TabIndex = 30;
            this.button2.Text = "이용약관";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.LoginBtn);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.JoinBtn);
            this.groupBox1.Controls.Add(this.hopeSwitch1);
            this.groupBox1.Controls.Add(this.Password);
            this.groupBox1.Controls.Add(this.UserID);
            this.groupBox1.Location = new System.Drawing.Point(-17, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 490);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(190, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 28;
            this.label2.Text = "IP보안";
            // 
            // LoginBtn
            // 
            this.LoginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.LoginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LoginBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.LoginBtn.ForeColor = System.Drawing.Color.Black;
            this.LoginBtn.Location = new System.Drawing.Point(47, 270);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(225, 38);
            this.LoginBtn.TabIndex = 27;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = false;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SUIT ExtraBold", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.label1.Location = new System.Drawing.Point(100, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 40);
            this.label1.TabIndex = 24;
            this.label1.Text = "LOGIN";
            // 
            // JoinBtn
            // 
            this.JoinBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.JoinBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.JoinBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.JoinBtn.ForeColor = System.Drawing.Color.White;
            this.JoinBtn.Location = new System.Drawing.Point(71, 347);
            this.JoinBtn.Name = "JoinBtn";
            this.JoinBtn.Size = new System.Drawing.Size(181, 41);
            this.JoinBtn.TabIndex = 26;
            this.JoinBtn.Text = "Create an Account";
            this.JoinBtn.UseVisualStyleBackColor = false;
            this.JoinBtn.Click += new System.EventHandler(this.JoinBtn_Click);
            // 
            // hopeSwitch1
            // 
            this.hopeSwitch1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hopeSwitch1.AutoSize = true;
            this.hopeSwitch1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.hopeSwitch1.BaseColor = System.Drawing.Color.MidnightBlue;
            this.hopeSwitch1.BaseOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hopeSwitch1.BaseOnColor = System.Drawing.Color.White;
            this.hopeSwitch1.Checked = true;
            this.hopeSwitch1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hopeSwitch1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hopeSwitch1.Location = new System.Drawing.Point(232, 227);
            this.hopeSwitch1.Name = "hopeSwitch1";
            this.hopeSwitch1.Size = new System.Drawing.Size(40, 20);
            this.hopeSwitch1.TabIndex = 10;
            this.hopeSwitch1.Text = "hopeSwitch1";
            this.hopeSwitch1.UseVisualStyleBackColor = false;
            this.hopeSwitch1.CheckedChanged += new System.EventHandler(this.hopeSwitch1_CheckedChanged);
            // 
            // Password
            // 
            this.Password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Password.BaseColor = System.Drawing.Color.Transparent;
            this.Password.BorderColorA = System.Drawing.Color.DodgerBlue;
            this.Password.BorderColorB = System.Drawing.Color.DodgerBlue;
            this.Password.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Password.ForeColor = System.Drawing.Color.SteelBlue;
            this.Password.Hint = "";
            this.Password.Location = new System.Drawing.Point(47, 180);
            this.Password.MaxLength = 128;
            this.Password.Multiline = false;
            this.Password.Name = "Password";
            this.Password.PasswordChar = '\0';
            this.Password.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Password.SelectedText = "";
            this.Password.SelectionLength = 0;
            this.Password.SelectionStart = 0;
            this.Password.Size = new System.Drawing.Size(225, 38);
            this.Password.TabIndex = 8;
            this.Password.TabStop = false;
            this.Password.Text = "Password";
            this.Password.UseSystemPasswordChar = false;
            this.Password.Click += new System.EventHandler(this.hopeTextBox2_Click);
            // 
            // UserID
            // 
            this.UserID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.UserID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.UserID.BaseColor = System.Drawing.Color.DarkGray;
            this.UserID.BorderColorA = System.Drawing.Color.DodgerBlue;
            this.UserID.BorderColorB = System.Drawing.Color.DodgerBlue;
            this.UserID.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.UserID.ForeColor = System.Drawing.Color.SteelBlue;
            this.UserID.Hint = "";
            this.UserID.Location = new System.Drawing.Point(47, 131);
            this.UserID.MaxLength = 128;
            this.UserID.Multiline = false;
            this.UserID.Name = "UserID";
            this.UserID.PasswordChar = '\0';
            this.UserID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.UserID.SelectedText = "";
            this.UserID.SelectionLength = 0;
            this.UserID.SelectionStart = 0;
            this.UserID.Size = new System.Drawing.Size(225, 38);
            this.UserID.TabIndex = 7;
            this.UserID.TabStop = false;
            this.UserID.Text = "ID";
            this.UserID.UseSystemPasswordChar = false;
            this.UserID.Click += new System.EventHandler(this.UseId_Click);
            // 
            // dungeonLinkLabel1
            // 
            this.dungeonLinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(72)))), ((int)(((byte)(20)))));
            this.dungeonLinkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dungeonLinkLabel1.AutoSize = true;
            this.dungeonLinkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.dungeonLinkLabel1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dungeonLinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.dungeonLinkLabel1.LinkColor = System.Drawing.Color.Silver;
            this.dungeonLinkLabel1.Location = new System.Drawing.Point(40, 545);
            this.dungeonLinkLabel1.Name = "dungeonLinkLabel1";
            this.dungeonLinkLabel1.Size = new System.Drawing.Size(118, 20);
            this.dungeonLinkLabel1.TabIndex = 18;
            this.dungeonLinkLabel1.TabStop = true;
            this.dungeonLinkLabel1.Text = "Forgot Password";
            this.dungeonLinkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(119)))), ((int)(((byte)(70)))));
            // 
            // materialLabel1
            // 
            this.materialLabel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = ReaLTaiizor.Manager.MaterialSkinManager.FontType.Subtitle2;
            this.materialLabel1.HighEmphasis = true;
            this.materialLabel1.Location = new System.Drawing.Point(58, 549);
            this.materialLabel1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(94, 17);
            this.materialLabel1.TabIndex = 12;
            this.materialLabel1.Text = "Remember me";
            this.materialLabel1.UseAccent = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Project_SteelMES.Properties.Resources.info;
            this.pictureBox2.Location = new System.Drawing.Point(156, 496);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(18, 18);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 32;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Project_SteelMES.Properties.Resources.logo2;
            this.pictureBox1.Location = new System.Drawing.Point(118, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Project_SteelMES.Properties.Resources.info;
            this.pictureBox3.Location = new System.Drawing.Point(72, 437);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(18, 18);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 33;
            this.pictureBox3.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(75)))), ((int)(((byte)(139)))));
            this.panel1.BackgroundImage = global::Project_SteelMES.Properties.Resources.background2;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(132, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 542);
            this.panel1.TabIndex = 0;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 539);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.dungeonLinkLabel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.Text = "Crown";
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ReaLTaiizor.Controls.ParrotFormEllipse parrotFormEllipse1;
        private ReaLTaiizor.Controls.ParrotFormHandle parrotFormHandle1;
        private ReaLTaiizor.Controls.ParrotFormHandle parrotFormHandle2;
        private ReaLTaiizor.Controls.HopeTextBox Password;
        private ReaLTaiizor.Controls.HopeTextBox UserID;
        private ReaLTaiizor.Controls.HopeSwitch hopeSwitch1;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
        private ReaLTaiizor.Controls.DungeonLinkLabel dungeonLinkLabel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button JoinBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

