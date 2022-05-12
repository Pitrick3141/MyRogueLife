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
    public partial class FormProperty : Form
    {
        public FormProperty()
        {
            InitializeComponent();
        }
        List<int> itemsShown = new();
        Dictionary<int, int> itemsList = new();
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex == -1)
            {
                return;
            }
            int index = itemsShown[listBox1.SelectedIndex];
            int num = itemsList[index];
            Items item = Globle.items[index];
            richTextBox1.Clear();
            RichTextBoxExtension.Add(richTextBox1, "【" + item.Name + "】 拥有数量：" + num.ToString(), Color.Black);
            RichTextBoxExtension.Add(richTextBox1, "功能：", Color.Black);
            RichTextBoxExtension.Add(richTextBox1, item.Eff, Color.Black);
            RichTextBoxExtension.Add(richTextBox1, "描述：", Color.Black);
            RichTextBoxExtension.Add(richTextBox1, item.Des, Color.Black);
        }

        private void FormRecord_Load(object sender, EventArgs e)
        {
            RefreshRecord();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshRecord();
        }

        private void AddValue(string str,int value)
        {
            RichTextBoxExtension.Add(richTextBox2, str, Color.Black,false);
            if (value < 5)
            {
                RichTextBoxExtension.Add(richTextBox2, value.ToString(), Color.Gray);
                return;
            }
            else if(value < 10)
            {
                RichTextBoxExtension.Add(richTextBox2, value.ToString(), Color.DeepSkyBlue);
                return;
            }
            else if (value < 15)
            {
                RichTextBoxExtension.Add(richTextBox2, value.ToString(), Color.LimeGreen);
                return;
            }
            else if (value < 25)
            {
                RichTextBoxExtension.Add(richTextBox2, value.ToString(), Color.BlueViolet);
                return;
            }
            else if(value < 50)
            {
                RichTextBoxExtension.Add(richTextBox2, value.ToString(), Color.DarkOrange);
                return;
            }
            else
            {
                RichTextBoxExtension.Add(richTextBox2, value.ToString(), Color.OrangeRed);
                return;
            }
        }
        private void RefreshRecord()
        {
            itemsList.Clear();
            itemsShown.Clear();
            listBox1.Items.Clear();
            richTextBox1.Clear();
            richTextBox2.Clear();
            foreach (int index in Globle.player.tlt)
            {
                if (!itemsList.ContainsKey(index))
                {
                    itemsList.Add(index, 1);
                }
                else
                {
                    itemsList[index]++;
                }
            }
            itemsList = DictionarySort(itemsList);
            foreach (var item in itemsList)
            {
                listBox1.Items.Add(Globle.items[item.Key].Name);
                itemsShown.Add(item.Key);
            }
            AddValue("魅力:", Globle.player.CHM);
            AddValue("智力:", Globle.player.INT);
            AddValue("体质:", Globle.player.STR);
            AddValue("家境:", Globle.player.MNY);
            AddValue("精神:", Globle.player.SPR);
        }

        private Dictionary<int, int> DictionarySort(Dictionary<int, int> dic)
        {
            var dicSort = from objDic in dic orderby objDic.Key ascending select objDic;
            Dictionary<int, int> res = new();
            foreach (KeyValuePair<int, int> kvp in dicSort)
                res.Add(kvp.Key, kvp.Value);
            return res;
        }
    }
}
