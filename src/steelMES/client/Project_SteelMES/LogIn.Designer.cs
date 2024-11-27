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
            this.panel1 = new System.Windows.Forms.Panel();
            this.parrotFormHandle2 = new ReaLTaiizor.Controls.ParrotFormHandle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.JoinBtn = new ReaLTaiizor.Controls.MaterialButton();
            this.hopeSwitch1 = new ReaLTaiizor.Controls.HopeSwitch();
            this.Password_TextBox = new ReaLTaiizor.Controls.HopeTextBox();
            this.LogInBtn = new ReaLTaiizor.Controls.MaterialButton();
            this.UserID_TextBox = new ReaLTaiizor.Controls.HopeTextBox();
            this.hopePictureBox1 = new ReaLTaiizor.Controls.HopePictureBox();
            this.dungeonLinkLabel1 = new ReaLTaiizor.Controls.DungeonLinkLabel();
            this.materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hopePictureBox1)).BeginInit();
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
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(-41, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 559);
            this.panel1.TabIndex = 0;
            // 
            // parrotFormHandle2
            // 
            this.parrotFormHandle2.DockAtTop = true;
            this.parrotFormHandle2.HandleControl = this.panel2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(34)))));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.JoinBtn);
            this.panel2.Controls.Add(this.hopeSwitch1);
            this.panel2.Controls.Add(this.Password_TextBox);
            this.panel2.Controls.Add(this.LogInBtn);
            this.panel2.Controls.Add(this.UserID_TextBox);
            this.panel2.Controls.Add(this.hopePictureBox1);
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(326, 539);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // JoinBtn
            // 
            this.JoinBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.JoinBtn.AutoSize = false;
            this.JoinBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.JoinBtn.CharacterCasing = ReaLTaiizor.Controls.MaterialButton.CharacterCasingEnum.Normal;
            this.JoinBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.JoinBtn.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.JoinBtn.Depth = 0;
            this.JoinBtn.HighEmphasis = true;
            this.JoinBtn.Icon = null;
            this.JoinBtn.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            this.JoinBtn.Location = new System.Drawing.Point(168, 474);
            this.JoinBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.JoinBtn.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.JoinBtn.Name = "JoinBtn";
            this.JoinBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.JoinBtn.Size = new System.Drawing.Size(108, 36);
            this.JoinBtn.TabIndex = 21;
            this.JoinBtn.Text = "회원가입";
            this.JoinBtn.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.JoinBtn.UseAccentColor = false;
            this.JoinBtn.UseVisualStyleBackColor = true;
            this.JoinBtn.Click += new System.EventHandler(this.materialButton2_Click);
            // 
            // hopeSwitch1
            // 
            this.hopeSwitch1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hopeSwitch1.AutoSize = true;
            this.hopeSwitch1.BaseColor = System.Drawing.Color.DimGray;
            this.hopeSwitch1.BaseOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hopeSwitch1.BaseOnColor = System.Drawing.Color.LightGray;
            this.hopeSwitch1.Checked = true;
            this.hopeSwitch1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hopeSwitch1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hopeSwitch1.Location = new System.Drawing.Point(47, 357);
            this.hopeSwitch1.Name = "hopeSwitch1";
            this.hopeSwitch1.Size = new System.Drawing.Size(40, 20);
            this.hopeSwitch1.TabIndex = 10;
            this.hopeSwitch1.Text = "hopeSwitch1";
            this.hopeSwitch1.UseVisualStyleBackColor = true;
            this.hopeSwitch1.CheckedChanged += new System.EventHandler(this.hopeSwitch1_CheckedChanged);
            // 
            // Password_TextBox
            // 
            this.Password_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Password_TextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(45)))));
            this.Password_TextBox.BaseColor = System.Drawing.Color.Transparent;
            this.Password_TextBox.BorderColorA = System.Drawing.Color.DodgerBlue;
            this.Password_TextBox.BorderColorB = System.Drawing.Color.DarkGray;
            this.Password_TextBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Password_TextBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.Password_TextBox.Hint = "";
            this.Password_TextBox.Location = new System.Drawing.Point(47, 292);
            this.Password_TextBox.MaxLength = 128;
            this.Password_TextBox.Multiline = false;
            this.Password_TextBox.Name = "Password_TextBox";
            this.Password_TextBox.PasswordChar = '*';
            this.Password_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Password_TextBox.SelectedText = "";
            this.Password_TextBox.SelectionLength = 0;
            this.Password_TextBox.SelectionStart = 0;
            this.Password_TextBox.Size = new System.Drawing.Size(219, 38);
            this.Password_TextBox.TabIndex = 8;
            this.Password_TextBox.TabStop = false;
            this.Password_TextBox.Text = "Password";
            this.Password_TextBox.UseSystemPasswordChar = false;
            this.Password_TextBox.Click += new System.EventHandler(this.hopeTextBox2_Click);
            // 
            // LogInBtn
            // 
            this.LogInBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LogInBtn.AutoEllipsis = true;
            this.LogInBtn.AutoSize = false;
            this.LogInBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LogInBtn.BackColor = System.Drawing.Color.Orange;
            this.LogInBtn.CharacterCasing = ReaLTaiizor.Controls.MaterialButton.CharacterCasingEnum.Normal;
            this.LogInBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogInBtn.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.LogInBtn.Depth = 0;
            this.LogInBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogInBtn.HighEmphasis = true;
            this.LogInBtn.Icon = null;
            this.LogInBtn.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            this.LogInBtn.Location = new System.Drawing.Point(33, 474);
            this.LogInBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.LogInBtn.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.LogInBtn.Name = "LogInBtn";
            this.LogInBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.LogInBtn.Size = new System.Drawing.Size(108, 36);
            this.LogInBtn.TabIndex = 20;
            this.LogInBtn.Text = "로그인";
            this.LogInBtn.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.LogInBtn.UseAccentColor = false;
            this.LogInBtn.UseVisualStyleBackColor = false;
            this.LogInBtn.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // UserID_TextBox
            // 
            this.UserID_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.UserID_TextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(45)))));
            this.UserID_TextBox.BaseColor = System.Drawing.Color.Transparent;
            this.UserID_TextBox.BorderColorA = System.Drawing.Color.DodgerBlue;
            this.UserID_TextBox.BorderColorB = System.Drawing.Color.DarkGray;
            this.UserID_TextBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.UserID_TextBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.UserID_TextBox.Hint = "";
            this.UserID_TextBox.Location = new System.Drawing.Point(47, 231);
            this.UserID_TextBox.MaxLength = 128;
            this.UserID_TextBox.Multiline = false;
            this.UserID_TextBox.Name = "UserID_TextBox";
            this.UserID_TextBox.PasswordChar = '\0';
            this.UserID_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.UserID_TextBox.SelectedText = "";
            this.UserID_TextBox.SelectionLength = 0;
            this.UserID_TextBox.SelectionStart = 0;
            this.UserID_TextBox.Size = new System.Drawing.Size(219, 38);
            this.UserID_TextBox.TabIndex = 7;
            this.UserID_TextBox.TabStop = false;
            this.UserID_TextBox.Text = "ID";
            this.UserID_TextBox.UseSystemPasswordChar = false;
            this.UserID_TextBox.Click += new System.EventHandler(this.hopeTextBox1_Click);
            // 
            // hopePictureBox1
            // 
            this.hopePictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.hopePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.hopePictureBox1.Enabled = false;
            this.hopePictureBox1.Image = global::Project_SteelMES.Properties.Resources.Logo;
            this.hopePictureBox1.Location = new System.Drawing.Point(83, 70);
            this.hopePictureBox1.Name = "hopePictureBox1";
            this.hopePictureBox1.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.hopePictureBox1.Size = new System.Drawing.Size(160, 98);
            this.hopePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.hopePictureBox1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.hopePictureBox1.TabIndex = 0;
            this.hopePictureBox1.TabStop = false;
            this.hopePictureBox1.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
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
            this.dungeonLinkLabel1.Location = new System.Drawing.Point(-207, 547);
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
            this.materialLabel1.Location = new System.Drawing.Point(58, 551);
            this.materialLabel1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(94, 17);
            this.materialLabel1.TabIndex = 12;
            this.materialLabel1.Text = "Remember me";
            this.materialLabel1.UseAccent = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 542);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.dungeonLinkLabel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.Text = "Crown";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hopePictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ReaLTaiizor.Controls.ParrotFormEllipse parrotFormEllipse1;
        private ReaLTaiizor.Controls.ParrotFormHandle parrotFormHandle1;
        private ReaLTaiizor.Controls.ParrotFormHandle parrotFormHandle2;
        private ReaLTaiizor.Controls.HopeTextBox Password_TextBox;
        private ReaLTaiizor.Controls.HopeTextBox UserID_TextBox;
        private ReaLTaiizor.Controls.HopeSwitch hopeSwitch1;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
        private ReaLTaiizor.Controls.DungeonLinkLabel dungeonLinkLabel1;
        private System.Windows.Forms.Panel panel2;
        private ReaLTaiizor.Controls.MaterialButton JoinBtn;
        private ReaLTaiizor.Controls.MaterialButton LogInBtn;
        private ReaLTaiizor.Controls.HopePictureBox hopePictureBox1;
    }
}

