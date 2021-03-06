﻿namespace AirBattle
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
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tool = new System.Windows.Forms.ToolStrip();
            this.button1 = new System.Windows.Forms.ToolStripButton();
            this.button2 = new System.Windows.Forms.ToolStripButton();
            this.button3 = new System.Windows.Forms.ToolStripButton();
            this.button4 = new System.Windows.Forms.ToolStripButton();
            this.save = new System.Windows.Forms.SaveFileDialog();
            this.open = new System.Windows.Forms.OpenFileDialog();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.status = new System.Windows.Forms.StatusStrip();
            this.timerLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.tool.SuspendLayout();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.gameToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menu.Size = new System.Drawing.Size(355, 28);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.FileToolStripMenuItem.Text = "&Файл";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.loadToolStripMenuItem.Text = "Загрузить...";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.saveToolStripMenuItem.Text = "Сохранить...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.ExitToolStripMenuItem.Text = "&Выход";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // tool
            // 
            this.tool.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.button1,
            this.button2,
            this.button3,
            this.button4});
            this.tool.Location = new System.Drawing.Point(0, 28);
            this.tool.Name = "tool";
            this.tool.Size = new System.Drawing.Size(355, 27);
            this.tool.TabIndex = 1;
            this.tool.Text = "toolStrip1";
            // 
            // button1
            // 
            this.button1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.button1.Image = global::AirBattle.Properties.Resources.ship01;
            this.button1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 24);
            this.button1.ToolTipText = "Расстановка однопалубного корабля";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.button2.Image = global::AirBattle.Properties.Resources.ship02;
            this.button2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 24);
            this.button2.Text = "toolStripButton1";
            this.button2.ToolTipText = "Расстановка двухпалубного корабля";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.button3.Image = global::AirBattle.Properties.Resources.ship03;
            this.button3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 24);
            this.button3.Text = "toolStripButton2";
            this.button3.ToolTipText = "Расстановка трехпалубного корабля";
            // 
            // button4
            // 
            this.button4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.button4.Image = global::AirBattle.Properties.Resources.ship04;
            this.button4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(24, 24);
            this.button4.Text = "toolStripButton3";
            this.button4.ToolTipText = "Расстановка четырехпалубного корабля";
            // 
            // save
            // 
            this.save.Filter = "XML-файлы(*.xml)|*.xml|Все файлы (*.*)|*.*";
            this.save.Title = "Сохранение состояния игры";
            // 
            // open
            // 
            this.open.Filter = "XML-файлы(*.xml)|*.xml|Все файлы (*.*)|*.*";
            this.open.Title = "Загрузка состояния игры";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // status
            // 
            this.status.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timerLabel});
            this.status.Location = new System.Drawing.Point(0, 277);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(355, 25);
            this.status.SizingGrip = false;
            this.status.TabIndex = 2;
            this.status.Text = "statusStrip1";
            // 
            // timerLabel
            // 
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(15, 20);
            this.timerLabel.Text = "*";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.gameToolStripMenuItem.Text = "&Игра";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.startToolStripMenuItem.Text = "&Начать...";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(355, 302);
            this.Controls.Add(this.status);
            this.Controls.Add(this.tool);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Воздушный бой";
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
        private System.Windows.Forms.ToolStripButton button1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog save;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog open;
        private System.Windows.Forms.ToolStripButton button2;
        private System.Windows.Forms.ToolStripButton button3;
        private System.Windows.Forms.ToolStripButton button4;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel timerLabel;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
    }
}

