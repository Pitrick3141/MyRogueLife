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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void MenuOpenRecord_Click(object sender, EventArgs e)
        {
            Globle.formRecord = new();
            Globle.formRecord.Show();
        }

        private void MenuShowProperty_Click(object sender, EventArgs e)
        {
            Globle.formProperty = new();
            Globle.formProperty.Show();
        }

        private void 游戏设定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globle.formSetting = new();
            Globle.formSetting.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }
}
