namespace LogicForms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.andButton = new System.Windows.Forms.ToolStripButton();
            this.orButton = new System.Windows.Forms.ToolStripButton();
            this.notButton = new System.Windows.Forms.ToolStripButton();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.expressionText = new System.Windows.Forms.TextBox();
            this.mainToolStrip.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.andButton,
            this.orButton,
            this.notButton});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 24);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(581, 25);
            this.mainToolStrip.TabIndex = 0;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // andButton
            // 
            this.andButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.andButton.Image = ((System.Drawing.Image)(resources.GetObject("andButton.Image")));
            this.andButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.andButton.Name = "andButton";
            this.andButton.Size = new System.Drawing.Size(23, 22);
            this.andButton.Tag = "LogicalAnd";
            this.andButton.Text = "&&";
            this.andButton.ToolTipText = "Добавить логические И";
            this.andButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // orButton
            // 
            this.orButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.orButton.Image = ((System.Drawing.Image)(resources.GetObject("orButton.Image")));
            this.orButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.orButton.Name = "orButton";
            this.orButton.Size = new System.Drawing.Size(23, 22);
            this.orButton.Tag = "LogicalOr";
            this.orButton.Text = "1";
            this.orButton.ToolTipText = "Добавить логическое ИЛИ";
            this.orButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // notButton
            // 
            this.notButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.notButton.Image = ((System.Drawing.Image)(resources.GetObject("notButton.Image")));
            this.notButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.notButton.Name = "notButton";
            this.notButton.Size = new System.Drawing.Size(23, 22);
            this.notButton.Tag = "LogicalNot";
            this.notButton.Text = "o";
            this.notButton.ToolTipText = "Добавить логическое НЕ";
            this.notButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 386);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(581, 22);
            this.mainStatusStrip.TabIndex = 1;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(581, 24);
            this.mainMenuStrip.TabIndex = 2;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Location = new System.Drawing.Point(0, 78);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(581, 305);
            this.mainPanel.TabIndex = 3;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // expressionText
            // 
            this.expressionText.Location = new System.Drawing.Point(0, 52);
            this.expressionText.Name = "expressionText";
            this.expressionText.ReadOnly = true;
            this.expressionText.Size = new System.Drawing.Size(581, 20);
            this.expressionText.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 408);
            this.Controls.Add(this.expressionText);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainToolStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "Дизайнер логических выражений";
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton andButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ToolStripButton orButton;
        private System.Windows.Forms.ToolStripButton notButton;
        private System.Windows.Forms.TextBox expressionText;
    }
}

