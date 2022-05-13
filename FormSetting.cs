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
    public partial class FormSetting : Form
    {
        public FormSetting()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    Globle.currentLanguage = Globle.Lang.zh_CN;
                    Debug.Print("游戏语言已切换为zh_CN");
                    break;
                case 1:
                    Globle.currentLanguage = Globle.Lang.en_CA;
                    Debug.Print("游戏语言已切换为en_CA");
                    break;
            }
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JsonData.SavePlayer(Globle.player);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Globle.player = JsonData.LoadPlayer();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            JsonData.LoadCollections();
            JsonData.LoadEvents();
            JsonData.LoadResults();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Globle.player.PrintInfo();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==""||!textBox1.Text.All(char.IsDigit))
            {
                Debug.Print("输入的内容不合法", 1);
                return;
            }
            int key = Convert.ToInt32(textBox1.Text);
            Globle.player.AttainItem(key);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            JsonData.UnloadCollections();
            JsonData.UnloadEvents();
            JsonData.UnloadResults();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            JsonData.SaveRecord(Globle.record);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Globle.record = JsonData.LoadRecord();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Globle.formRecord.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Debug.Div();
            Conditions.TestParse(Conditions.ParseConditions(textBox2.Text).Item1,0);
            Debug.Div();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Debug.Div();
            if (Conditions.Check(Conditions.ParseConditions(textBox2.Text).Item1))
                Debug.Print("最终结果为真");
            else
                Debug.Print("最终结果为假");
            Debug.Div();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Globle.player = new();
            Debug.Print("人物信息已重置");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || !textBox3.Text.All(char.IsDigit))
            {
                Debug.Print("输入的内容不合法", 1);
                return;
            }
            int key = Convert.ToInt32(textBox3.Text);
            Globle.player.EventOccur(key);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || !textBox4.Text.All(char.IsDigit))
            {
                Debug.Print("输入的内容不合法", 1);
                return;
            }
            int key = Convert.ToInt32(textBox4.Text);
            if(Globle.results.ContainsKey(key))
            {
                Globle.results[key].Occur();
            }
            else
            {
                Debug.Print("不存在序号为" + key + "的结果", 1);
            }
        }
    }
}
