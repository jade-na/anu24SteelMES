using grpctestserver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_SteelMES
{
    public partial class PanelForm : Form
    {
        private int userLevel;
        private string userName;

        private Config config; //추가

        public PanelForm(string userName, int userLevel)
        {
            InitializeComponent();

            this.userLevel = userLevel;
            this.userName = userName;

            string configFilePath = Path.Combine(Directory.GetCurrentDirectory(), "appsetting.json");
            config = ConfigLoader.LoadConfig(configFilePath);

            if (config == null || config.GrpcSettings == null)
            {
                MessageBox.Show("gRPC 설정을 로드하는 데 실패했습니다.");
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void MatOrderBtn_Click(object sender, EventArgs e) //자재 주문 버튼
        {
            if (userLevel <= 1)
            {
                MaterialOrder matOrder = new MaterialOrder();
                matOrder.Show();
            }
            else
            {
                MessageBox.Show("manager 권한 이상만 접속이 가능합니다.");
            }
        }
    }
}
