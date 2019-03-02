namespace Acronym
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
            this.listResult = new System.Windows.Forms.ListBox();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonLoad = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonText = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
            this.tools.SuspendLayout();
            this.SuspendLayout();
            // 
            // listResult
            // 
            this.listResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listResult.FormattingEnabled = true;
            this.listResult.ItemHeight = 16;
            this.listResult.Location = new System.Drawing.Point(16, 96);
            this.listResult.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listResult.Name = "listResult";
            this.listResult.Size = new System.Drawing.Size(708, 388);
            this.listResult.Sorted = true;
            this.listResult.TabIndex = 2;
            // 
            // tools
            // 
            this.tools.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLoad,
            this.toolStripButtonText,
            this.toolStripButtonCopy});
            this.tools.Location = new System.Drawing.Point(0, 0);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(743, 71);
            this.tools.TabIndex = 3;
            this.tools.Text = "toolStrip1";
            // 
            // toolStripButtonLoad
            // 
            this.toolStripButtonLoad.Image = global::Acronym.Properties.Resources.download;
            this.toolStripButtonLoad.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLoad.Name = "toolStripButtonLoad";
            this.toolStripButtonLoad.Size = new System.Drawing.Size(198, 68);
            this.toolStripButtonLoad.Text = "Загрузка словаря";
            this.toolStripButtonLoad.Click += new System.EventHandler(this.toolStripButtonLoad_Click);
            // 
            // toolStripButtonText
            // 
            this.toolStripButtonText.Image = global::Acronym.Properties.Resources.open_folder_outline;
            this.toolStripButtonText.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonText.Name = "toolStripButtonText";
            this.toolStripButtonText.Size = new System.Drawing.Size(184, 68);
            this.toolStripButtonText.Text = "Загрузка файла";
            this.toolStripButtonText.Click += new System.EventHandler(this.toolStripButtonText_Click);
            // 
            // toolStripButtonCopy
            // 
            this.toolStripButtonCopy.Image = global::Acronym.Properties.Resources.copy;
            this.toolStripButtonCopy.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolStripButtonCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopy.Name = "toolStripButtonCopy";
            this.toolStripButtonCopy.Size = new System.Drawing.Size(220, 68);
            this.toolStripButtonCopy.Text = "Копировать в буфер";
            this.toolStripButtonCopy.Click += new System.EventHandler(this.toolStripButtonCopy_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 502);
            this.Controls.Add(this.tools);
            this.Controls.Add(this.listResult);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Список сокращений";
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listResult;
        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoad;
        private System.Windows.Forms.ToolStripButton toolStripButtonText;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopy;
    }
}

