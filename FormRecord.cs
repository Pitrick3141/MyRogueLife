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
    public partial class FormRecord : Form
    {
        public FormRecord()
        {
            InitializeComponent();
        }
        List<(Items, int)> itemsList = new();

        private void FormProperty_Load(object sender, EventArgs e)
        {
            RefreshRecord();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshRecord();
        }
        private void RefreshRecord()
        {
            itemsList.Clear();
            listBox1.Items.Clear();
            richTextBox1.Clear();
            richTextBox2.Clear();
            foreach (var item in Globle.record.itemAttainCount)
            {
                Dictionary<int, Items> items = Globle.items;
                int index = item.Key;
                int num = item.Value;
                listBox1.Items.Add(index.ToString() + " " + items[index].Name);
                itemsList.Add((items[index], num));
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var (item, num) = itemsList[listBox1.SelectedIndex];
            richTextBox1.Clear();
            RichTextBoxExtension.Add(richTextBox1, "【" + item.Name + "】 已获得次数：" + num.ToString(), Color.Black);
            RichTextBoxExtension.Add(richTextBox1, "功能：", Color.Black);
            RichTextBoxExtension.Add(richTextBox1, item.Eff, Color.Black);
            RichTextBoxExtension.Add(richTextBox1, "描述：", Color.Black);
            RichTextBoxExtension.Add(richTextBox1, item.Des, Color.Black);
        }
    }
}
