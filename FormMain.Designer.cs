namespace MyRogueLife
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuOpenRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuShowProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.游戏设定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 45);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(776, 338);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuOpenRecord,
            this.MenuShowProperty,
            this.游戏设定ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuOpenRecord
            // 
            this.MenuOpenRecord.Name = "MenuOpenRecord";
            this.MenuOpenRecord.Size = new System.Drawing.Size(92, 21);
            this.MenuOpenRecord.Text = "打开旅行日记";
            this.MenuOpenRecord.Click += new System.EventHandler(this.MenuOpenRecord_Click);
            // 
            // MenuShowProperty
            // 
            this.MenuShowProperty.Name = "MenuShowProperty";
            this.MenuShowProperty.Size = new System.Drawing.Size(116, 21);
            this.MenuShowProperty.Text = "查看当前人物状态";
            this.MenuShowProperty.Click += new System.EventHandler(this.MenuShowProperty_Click);
            // 
            // 游戏设定ToolStripMenuItem
            // 
            this.游戏设定ToolStripMenuItem.Name = "游戏设定ToolStripMenuItem";
            this.游戏设定ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.游戏设定ToolStripMenuItem.Text = "游戏设定";
            this.游戏设定ToolStripMenuItem.Click += new System.EventHandler(this.游戏设定ToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "MyRogueLife";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox richTextBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem MenuOpenRecord;
        private ToolStripMenuItem MenuShowProperty;
        private ToolStripMenuItem 游戏设定ToolStripMenuItem;
    }
}