namespace SeaBattle
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tool = new System.Windows.Forms.ToolStrip();
            this.ship1 = new System.Windows.Forms.ToolStripButton();
            this.ship2 = new System.Windows.Forms.ToolStripButton();
            this.ship3 = new System.Windows.Forms.ToolStripButton();
            this.ship4 = new System.Windows.Forms.ToolStripButton();
            this.save = new System.Windows.Forms.SaveFileDialog();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.status = new System.Windows.Forms.StatusStrip();
            this.timerLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menu.SuspendLayout();
            this.tool.SuspendLayout();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menu.Size = new System.Drawing.Size(461, 28);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.FileToolStripMenuItem.Text = "&Файл";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.saveToolStripMenuItem.Text = "&Сохранить...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.ExitToolStripMenuItem.Text = "&Выход";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // tool
            // 
            this.tool.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ship1,
            this.ship2,
            this.ship3,
            this.ship4});
            this.tool.Location = new System.Drawing.Point(0, 28);
            this.tool.Name = "tool";
            this.tool.Size = new System.Drawing.Size(461, 31);
            this.tool.TabIndex = 1;
            this.tool.Text = "toolStrip1";
            // 
            // ship1
            // 
            this.ship1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ship1.Image = global::SeaBattle.Properties.Resources.Ship_01;
            this.ship1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ship1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ship1.Name = "ship1";
            this.ship1.Size = new System.Drawing.Size(28, 28);
            this.ship1.Text = "toolStripButton1";
            this.ship1.ToolTipText = "Добавление однопалубного корабля";
            this.ship1.Click += new System.EventHandler(this.ship1_Click);
            // 
            // ship2
            // 
            this.ship2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ship2.Image = global::SeaBattle.Properties.Resources.Ship_02;
            this.ship2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ship2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ship2.Name = "ship2";
            this.ship2.Size = new System.Drawing.Size(28, 28);
            this.ship2.Text = "toolStripButton1";
            this.ship2.ToolTipText = "Добавление двухпалубного корабля";
            this.ship2.Click += new System.EventHandler(this.ship2_Click);
            // 
            // ship3
            // 
            this.ship3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ship3.Image = global::SeaBattle.Properties.Resources.Ship_03;
            this.ship3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ship3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ship3.Name = "ship3";
            this.ship3.Size = new System.Drawing.Size(28, 28);
            this.ship3.Text = "toolStripButton2";
            this.ship3.ToolTipText = "Добавление трехпалубного корабля";
            // 
            // ship4
            // 
            this.ship4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ship4.Image = global::SeaBattle.Properties.Resources.Ship_04;
            this.ship4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ship4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ship4.Name = "ship4";
            this.ship4.Size = new System.Drawing.Size(28, 28);
            this.ship4.Text = "toolStripButton3";
            this.ship4.ToolTipText = "Добавление четырехпалубного корабля";
            // 
            // save
            // 
            this.save.Filter = "XML-файлы (*.xml)|*.xml|Все файлы (*.*)|*.*";
            this.save.Title = "Сохранение игры";
            // 
            // timer
            // 
            this.timer.Interval = 2000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // status
            // 
            this.status.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timerLabel});
            this.status.Location = new System.Drawing.Point(0, 324);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(461, 24);
            this.status.SizingGrip = false;
            this.status.TabIndex = 2;
            // 
            // timerLabel
            // 
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(0, 19);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(461, 348);
            this.Controls.Add(this.status);
            this.Controls.Add(this.tool);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Морской бой";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tool.ResumeLayout(false);
            this.tool.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip tool;
        private System.Windows.Forms.ToolStripButton ship1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog save;
        private System.Windows.Forms.ToolStripButton ship2;
        private System.Windows.Forms.ToolStripButton ship3;
        private System.Windows.Forms.ToolStripButton ship4;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel timerLabel;
    }
}

