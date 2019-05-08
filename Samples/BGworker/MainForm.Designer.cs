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
            this.textResult1 = new System.Windows.Forms.TextBox();
            this.buttonGo = new System.Windows.Forms.Button();
            this.worker1 = new System.ComponentModel.BackgroundWorker();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.buttonStop = new System.Windows.Forms.Button();
            this.worker2 = new System.ComponentModel.BackgroundWorker();
            this.textResult2 = new System.Windows.Forms.TextBox();
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
            this.textN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            // textResult1
            // 
            this.textResult1.Location = new System.Drawing.Point(143, 48);
            this.textResult1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textResult1.Name = "textResult1";
            this.textResult1.Size = new System.Drawing.Size(469, 22);
            this.textResult1.TabIndex = 1;
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(16, 143);
            this.buttonGo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(308, 28);
            this.buttonGo.TabIndex = 2;
            this.buttonGo.Text = "Запустить";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // worker1
            // 
            this.worker1.WorkerReportsProgress = true;
            this.worker1.WorkerSupportsCancellation = true;
            this.worker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.worker_ProgressChanged);
            this.worker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(16, 178);
            this.progress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(597, 41);
            this.progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progress.TabIndex = 3;
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(332, 143);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(280, 28);
            this.buttonStop.TabIndex = 4;
            this.buttonStop.Text = "Остановить";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // worker2
            // 
            this.worker2.WorkerReportsProgress = true;
            this.worker2.WorkerSupportsCancellation = true;
            this.worker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.worker_ProgressChanged);
            this.worker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // textResult2
            // 
            this.textResult2.Location = new System.Drawing.Point(143, 80);
            this.textResult2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textResult2.Name = "textResult2";
            this.textResult2.Size = new System.Drawing.Size(469, 22);
            this.textResult2.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 234);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.textResult2);
            this.Controls.Add(this.textResult1);
            this.Controls.Add(this.textN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Интегратор";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textResult1;
        private System.Windows.Forms.Button buttonGo;
        private System.ComponentModel.BackgroundWorker worker1;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Button buttonStop;
        private System.ComponentModel.BackgroundWorker worker2;
        private System.Windows.Forms.TextBox textResult2;
    }
}

