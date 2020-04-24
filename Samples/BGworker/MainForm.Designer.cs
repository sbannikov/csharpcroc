namespace BGworker
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
            this.label1 = new System.Windows.Forms.Label();
            this.textN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonGo = new System.Windows.Forms.Button();
            this.progress3 = new System.Windows.Forms.ProgressBar();
            this.buttonStop = new System.Windows.Forms.Button();
            this.list = new System.Windows.Forms.ListBox();
            this.progress2 = new System.Windows.Forms.ProgressBar();
            this.progress1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Число итерация";
            // 
            // textN
            // 
            this.textN.Location = new System.Drawing.Point(143, 15);
            this.textN.Margin = new System.Windows.Forms.Padding(4);
            this.textN.Name = "textN";
            this.textN.Size = new System.Drawing.Size(469, 22);
            this.textN.TabIndex = 1;
            this.textN.Text = "100000000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Результат";
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(19, 211);
            this.buttonGo.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(308, 28);
            this.buttonGo.TabIndex = 2;
            this.buttonGo.Text = "Запустить";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // progress3
            // 
            this.progress3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progress3.Location = new System.Drawing.Point(19, 354);
            this.progress3.Margin = new System.Windows.Forms.Padding(4);
            this.progress3.Name = "progress3";
            this.progress3.Size = new System.Drawing.Size(593, 41);
            this.progress3.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progress3.TabIndex = 3;
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStop.Location = new System.Drawing.Point(332, 211);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(280, 28);
            this.buttonStop.TabIndex = 4;
            this.buttonStop.Text = "Остановить";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // list
            // 
            this.list.FormattingEnabled = true;
            this.list.ItemHeight = 16;
            this.list.Location = new System.Drawing.Point(19, 73);
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(593, 116);
            this.list.TabIndex = 5;
            // 
            // progress2
            // 
            this.progress2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progress2.Location = new System.Drawing.Point(19, 305);
            this.progress2.Margin = new System.Windows.Forms.Padding(4);
            this.progress2.Name = "progress2";
            this.progress2.Size = new System.Drawing.Size(593, 41);
            this.progress2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progress2.TabIndex = 3;
            // 
            // progress1
            // 
            this.progress1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progress1.Location = new System.Drawing.Point(19, 256);
            this.progress1.Margin = new System.Windows.Forms.Padding(4);
            this.progress1.Name = "progress1";
            this.progress1.Size = new System.Drawing.Size(593, 41);
            this.progress1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progress1.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 410);
            this.Controls.Add(this.list);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.progress1);
            this.Controls.Add(this.progress2);
            this.Controls.Add(this.progress3);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.textN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Интегратор";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.ProgressBar progress3;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.ListBox list;
        private System.Windows.Forms.ProgressBar progress2;
        private System.Windows.Forms.ProgressBar progress1;
    }
}

