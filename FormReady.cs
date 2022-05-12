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
    public partial class FormReady : Form
    {
        public FormReady()
        {
            InitializeComponent();
        }
        private List<(string text, Color color)> itemInfo = new();
        private List<(string text, Color color)> modeInfo = new();
        private List<(string text, Color color)> diffInfo = new();
        private WeightedRandom wr = new();
        private Dictionary<string,int>itemList = new();
        private int rollChance = 3;//剩余可抽取次数
        private int abilityVacancy = 3;//可用藏品空间
        private bool isAbilityLockable = false;//藏品选择是否合法

        private void InfoUpdate()
        {
            richTextBox1.Clear();
            foreach(var (text, color) in diffInfo)
            {
                RichTextBoxExtension.Add(richTextBox1, text, color);
            }
            foreach (var (text, color) in modeInfo)
            {
                RichTextBoxExtension.Add(richTextBox1, text, color);
            }
            foreach (var (text, color) in itemInfo)
            {
                RichTextBoxExtension.Add(richTextBox1, text, color);
            }
            if(diffInfo.Count > 0 && modeInfo.Count > 0 && itemInfo.Count > 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //选择藏品
            modeInfo.Clear();
            modeInfo.Add(("您的出身选择:", Color.RoyalBlue));
            modeInfo.Add((comboBox2.Items[comboBox2.SelectedIndex].ToString()??"",Color.Black));
            Globle.player.Family = comboBox2.SelectedIndex;
            InfoUpdate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //选择难度
            diffInfo.Clear();
            diffInfo.Add(("本次您人生的难度:", Color.RoyalBlue));
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    diffInfo.Add(("【惬意云游】", Color.LightGreen));
                    diffInfo.Add(("\t“这将是一次愉快的旅程...”", Color.LightGreen));
                    diffInfo.Add(("\t+初始获得增益藏品【眷顾薄膜】", Color.LimeGreen));
                    diffInfo.Add(("\t-得分结算减少25%", Color.Red));
                    break;
                case 1:
                    diffInfo.Add(("【人生一遭】", Color.DarkKhaki));
                    diffInfo.Add(("\t“好好体验一次充实的人生也很不错呢...”", Color.DarkKhaki));
                    break;
                case 2:
                    diffInfo.Add(("【苦难之路】", Color.Orange));
                    diffInfo.Add(("\t“看来你喜欢一些挑战...”", Color.Orange));
                    diffInfo.Add(("\t-初始随机获得一件减益藏品", Color.Red));
                    diffInfo.Add(("\t+初始随机获得一件增益藏品", Color.LimeGreen));
                    diffInfo.Add(("\t+得分结算增加25%", Color.LimeGreen));
                    break;
                case 3:
                    diffInfo.Add(("【炼狱求生】", Color.Crimson));
                    diffInfo.Add(("\t“尽力...活下去...”", Color.Crimson));
                    break;
            }
            Globle.player.Difficulty = comboBox1.SelectedIndex;
            InfoUpdate();
        }

        private void FormReady_Load(object sender, EventArgs e)
        {
            wr.RandomInitiallize(Globle.weightList);
            label7.Text = rollChance.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rollChance--;
            label7.Text = rollChance.ToString();
            if(rollChance == 0)
            {
                button2.Enabled = false;
            }
            checkedListBox1.Items.Clear();
            itemList.Clear();
            richTextBox2.Clear();
            for(int i=0;i<10;i++)
            {
                int index = wr.GetRandomIndex();
                while(checkedListBox1.Items.Contains(Globle.items[index].Name))
                {
                    index = wr.GetRandomIndex();
                }
                itemList.Add(Globle.items[index].Name,index);
                checkedListBox1.Items.Add(Globle.items[index].Name);
            }
        }
        private void LockAbility()//锁定藏品
        {
            int itemCount = itemInfo.Count - 1;
            if (itemCount == 0)
            {
                itemInfo.Clear();
                itemInfo.Add(("本次您未携带任何藏品", Color.Crimson));
                itemInfo.Add(("\t+得分结算增加15%", Color.LimeGreen));
            }
            else if (itemCount < abilityVacancy)
            {
                itemInfo.Add(("本次您携带的藏品少于可携带数量", Color.Crimson));
                int coef = (abilityVacancy - itemCount) * 2;
                itemInfo.Add(("\t+得分结算增加" + coef.ToString() + "%", Color.LimeGreen));
            }
            InfoUpdate();
            button2.Enabled = false;
            button3.Enabled = false;
            button3.Text = "已锁定藏品";
            checkedListBox1.Enabled = false;
            label5.Text = "已锁定藏品";
            Debug.Print("藏品选择完毕");
            RichTextBoxExtension.Add(richTextBox2, "藏品已选择完毕!", Color.Green);
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    Globle.player.AttainItem(itemList[checkedListBox1.Items[i].ToString() ?? ""]);
                }
            }
            label5.BackColor = Color.Red;
            label7.Visible = false;
        }
        private void button3_Click(object sender, EventArgs e)//点击确认藏品按钮
        {
            richTextBox2.Clear();
            itemInfo.Clear();
            itemInfo.Add(("本次您携带的藏品:", Color.RoyalBlue));
            //选择藏品
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    Items item = Globle.items[itemList[checkedListBox1.Items[i].ToString() ?? ""]];
                    string selectedItem = item.Name + " (" + item.Eff + ")";
                    itemInfo.Add((selectedItem, Color.Black));
                }
            }
            int itemCount = itemInfo.Count - 1;
            if(itemCount > abilityVacancy)
            {
                Debug.Print("藏品选择过多(" + itemCount.ToString() + "/" + abilityVacancy.ToString() + ")",1);
                RichTextBoxExtension.Add(richTextBox2, "您已选择(", Color.Orange,false);
                RichTextBoxExtension.Add(richTextBox2, itemCount.ToString(), Color.Red,false);
                RichTextBoxExtension.Add(richTextBox2,  "/" + abilityVacancy.ToString() + ")个藏品，您本次携带的藏品过多\n请放弃不必要的藏品!", Color.Orange);
                isAbilityLockable = false;
                button3.Text = "确认藏品选择";
                return;
            }
            else if(isAbilityLockable)
            {
                LockAbility();
                return;
            }
            else if(itemCount < abilityVacancy)
            {
                Debug.Print("藏品选择不足(" + itemCount.ToString() + "/" + abilityVacancy.ToString() + ")", 1);
                RichTextBoxExtension.Add(richTextBox2, "您已选择(", Color.Gray, false);
                RichTextBoxExtension.Add(richTextBox2, itemCount.ToString(), Color.LightSeaGreen, false);
                RichTextBoxExtension.Add(richTextBox2, "/" + abilityVacancy.ToString() + ")个藏品，您还有剩余的可携带数量\n再按一次确认按钮以锁定藏品", Color.Gray);
                isAbilityLockable = true;
                button3.Text = "锁定藏品";
                return;
            }
            else
            {
                RichTextBoxExtension.Add(richTextBox2, "再按一次确认按钮以锁定藏品", Color.Gray);
                isAbilityLockable = true;
                button3.Text = "锁定藏品";
                return;
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //显示当前选中的藏品信息
            richTextBox2.Clear();
            int index = itemList[checkedListBox1.Items[checkedListBox1.SelectedIndex].ToString() ?? ""];
            Items item = Globle.items[index];
            RichTextBoxExtension.Add(richTextBox2, item.Name + " id:" + item.Index,Color.Black);
            RichTextBoxExtension.Add(richTextBox2, item.Eff, Color.BlueViolet);
            RichTextBoxExtension.Add(richTextBox2, item.Des, Color.Gray);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Globle.formMain = new();
            Globle.formMain.Show();
            Close();
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //若选择藏品改变则需要重新确认藏品
            isAbilityLockable = false;
            button3.Text = "确认藏品选择";
        }
    }
}
