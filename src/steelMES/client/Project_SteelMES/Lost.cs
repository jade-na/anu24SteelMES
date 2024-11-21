using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using System.Windows.Forms;
using ReaLTaiizor.Forms;

namespace Project_SteelMES
{
    public partial class Lost : LostForm
    {
		private Button optionButton1;
		private Button optionButton2;
		private bool areOptionButtonsVisible = false; // 가시성 상태 저장

		public Lost()
        {
            InitializeComponent();
		}

        private void Lost_Load(object sender, EventArgs e)
        {
			// 하위 버튼 생성
			CreateOptionButtons();
		}

        private void button2_Click(object sender, EventArgs e)
        {
            Lost2 lost2 = new Lost2();
            lost2.Show();
            this.Hide();
        }
		private void CreateOptionButtons()
		{
			// "자재 관리" 버튼
			optionButton1 = new Button();
			optionButton1.Text = "자재 관리";
			optionButton1.Location = new Point(this.Width - 120, 190); // 오른쪽 위치
			optionButton1.Size = new Size(120, 40);
			optionButton1.BackColor = Color.LightGray;
			optionButton1.FlatStyle = FlatStyle.Flat;
			optionButton1.Visible = false; // 초기에는 숨김
			optionButton1.Click += OptionButton1_Click;

			// "공정 관리" 버튼
			optionButton2 = new Button();
			optionButton2.Text = "공정 관리";
			optionButton2.Location = new Point(this.Width - 120, 240);
			optionButton2.Size = new Size(120, 40);
			optionButton2.BackColor = Color.LightGray;
			optionButton2.FlatStyle = FlatStyle.Flat;
			optionButton2.Visible = false; // 초기에는 숨김
			optionButton2.Click += OptionButton2_Click;

			// 동적으로 생성된 버튼을 폼에 추가
			this.Controls.Add(optionButton1);
			this.Controls.Add(optionButton2);
		}

		private void button4_Click(object sender, EventArgs e)
        {
			// 버튼 가시성 토글
			areOptionButtonsVisible = !areOptionButtonsVisible;

			// "생산 정보" 버튼의 위치 기준으로 새 버튼 위치 계산
			Point baseLocation = button4.Location;
			optionButton1.Location = new Point(baseLocation.X + button4.Width + 5, baseLocation.Y);
			optionButton2.Location = new Point(baseLocation.X + button4.Width + 5, baseLocation.Y + optionButton1.Height + 5);

			// 버튼 가시성 업데이트
			optionButton1.Visible = areOptionButtonsVisible;
			optionButton2.Visible = areOptionButtonsVisible;

			// 버튼 앞으로 가져오기
			optionButton1.BringToFront();
			optionButton2.BringToFront();
		}
		private void OptionButton1_Click(object sender, EventArgs e)
		{
			Lost3 lost3 = new Lost3();
			lost3.Show();
			this.Hide();
		}

		private void OptionButton2_Click(object sender, EventArgs e)
		{
			MessageBox.Show("기능 미구현");
		}

		private void button3_Click(object sender, EventArgs e)
		{
            Metro metro = new Metro();
            metro.Show();
            this.Hide();
		}

		private void button5_Click(object sender, EventArgs e)
		{
            Dispose();
		}
	}
}
