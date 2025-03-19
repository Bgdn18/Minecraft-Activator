namespace Minecraft_Activator
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox System32Path;
        private System.Windows.Forms.TextBox SysWow64Path;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System32Path = new TextBox();
            SysWow64Path = new TextBox();
            menuStrip1 = new MenuStrip();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem = new ToolStripMenuItem();
            button1 = new Button();
            button2 = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // System32Path
            // 
            System32Path.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold);
            System32Path.Location = new Point(12, 37);
            System32Path.Name = "System32Path";
            System32Path.PlaceholderText = "System32Path";
            System32Path.Size = new Size(318, 24);
            System32Path.TabIndex = 0;
            System32Path.Text = "C:\\Windows\\System32\\Windows.ApplicationModel.Store.dll";
            // 
            // SysWow64Path
            // 
            SysWow64Path.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold);
            SysWow64Path.Location = new Point(12, 67);
            SysWow64Path.Name = "SysWow64Path";
            SysWow64Path.PlaceholderText = "SysWow64Path";
            SysWow64Path.Size = new Size(318, 24);
            SysWow64Path.TabIndex = 1;
            SysWow64Path.Text = "C:\\Windows\\SysWow64\\Windows.ApplicationModel.Store.dll";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { aboutToolStripMenuItem, quitToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(342, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(52, 20);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new Size(42, 20);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += quitToolStripMenuItem_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Comic Sans MS", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(12, 170);
            button1.Name = "button1";
            button1.Size = new Size(318, 30);
            button1.TabIndex = 7;
            button1.Text = "Скачать Minecraft";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button2.Location = new Point(12, 97);
            button2.Name = "button2";
            button2.Size = new Size(318, 67);
            button2.TabIndex = 8;
            button2.Text = "Активировать Лицензию";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(342, 212);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(SysWow64Path);
            Controls.Add(System32Path);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Minecraft Activator";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        private MenuStrip menuStrip1;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
        private Button button1;
        private Button button2;
    }
}