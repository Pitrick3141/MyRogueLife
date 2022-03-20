using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyRogueLife
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            
            InitializeComponent();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(label1.Top < 12)
            {
                label1.Top += 1;
            }
            if(button1.Left > 631)
            {
                button1.Left -= 10;
            }
            if (button2.Left > 593&&button1.Left<700)
            {
                button2.Left -= 10;
            }
            if (button4.Left > 557&&button2.Left<700)
            {
                button4.Left -= 10;
            }
            if(button3.Left>521&&button4.Left<700)
            {
                button3.Left -= 10;
            }
        }

        private void FormStart_Load(object sender, EventArgs e)
        {
            label1.Top = -20;
            button1.Left = 800;
            button2.Left = 800;
            button3.Left = 800;
            button4.Left = 800;
            Debug.Print("主窗口加载完成");
            JsonData.LoadCollections();
            Globle.player = JsonData.LoadPlayer();
            Globle.record = JsonData.LoadRecord();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("您确定要退出吗？", "退出游戏",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                System.Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Globle.formReady = new();
            Globle.formReady.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Globle.formSetting = new();
            Globle.formSetting.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Globle.formRecord = new();
            Globle.formRecord.Show();
        }
    }
}
