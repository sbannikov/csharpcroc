namespace Sinusoid
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textMininum = new System.Windows.Forms.TextBox();
            this.textMaximum = new System.Windows.Forms.TextBox();
            this.button = new System.Windows.Forms.Button();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.errors = new System.Windows.Forms.ErrorProvider(this.components);
            this.tool = new System.Windows.Forms.ToolStrip();
            this.startButton = new System.Windows.Forms.ToolStripButton();
            this.stopButton = new System.Windows.Forms.ToolStripButton();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.status = new System.Windows.Forms.StatusStrip();
            this.progress = new System.Windows.Forms.ToolStripProgressBar();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errors)).BeginInit();
            this.tool.SuspendLayout();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Минимальное значение";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Максимальное значение";
            // 
            // textMininum
            // 
            this.textMininum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textMininum.Location = new System.Drawing.Point(161, 58);
            this.textMininum.Name = "textMininum";
            this.textMininum.Size = new System.Drawing.Size(161, 20);
            this.textMininum.TabIndex = 0;
            this.textMininum.Text = "1";
            this.textMininum.Leave += new System.EventHandler(this.textMininum_Leave);
            // 
            // textMaximum
            // 
            this.textMaximum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textMaximum.Location = new System.Drawing.Point(161, 84);
            this.textMaximum.Name = "textMaximum";
            this.textMaximum.Size = new System.Drawing.Size(161, 20);
            this.textMaximum.TabIndex = 1;
            this.textMaximum.Text = "1000";
            // 
            // button
            // 
            this.button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button.Location = new System.Drawing.Point(161, 110);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(161, 23);
            this.button.TabIndex = 2;
            this.button.Text = "Построить график";
            this.tip.SetToolTip(this.button, "Запустить процесс построения графика");
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            this.button.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button.MouseHover += new System.EventHandler(this.button_MouseHover);
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(12, 153);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(310, 95);
            this.chart.TabIndex = 5;
            this.chart.Text = "chart1";
            // 
            // errors
            // 
            this.errors.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errors.ContainerControl = this;
            // 
            // tool
            // 
            this.tool.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startButton,
            this.stopButton});
            this.tool.Location = new System.Drawing.Point(0, 0);
            this.tool.Name = "tool";
            this.tool.Size = new System.Drawing.Size(334, 39);
            this.tool.TabIndex = 6;
            this.tool.Text = "toolStrip1";
            // 
            // startButton
            // 
            this.startButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startButton.Image = global::Sinusoid.Properties.Resources.Play;
            this.startButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.startButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(36, 36);
            this.startButton.Text = "toolStripButton1";
            this.startButton.ToolTipText = "Запуск вычислений в отдельном потоке";
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopButton.Image = global::Sinusoid.Properties.Resources.Stop;
            this.stopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(36, 36);
            this.stopButton.Text = "toolStripButton2";
            this.stopButton.ToolTipText = "Досрочное завершение вычислений";
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // worker
            // 
            this.worker.WorkerReportsProgress = true;
            this.worker.WorkerSupportsCancellation = true;
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.worker_ProgressChanged);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progress});
            this.status.Location = new System.Drawing.Point(0, 251);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(334, 22);
            this.status.TabIndex = 7;
            this.status.Text = "statusStrip1";
            // 
            // progress
            // 
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(310, 16);
            this.progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // tip
            // 
            this.tip.IsBalloon = true;
            this.tip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 273);
            this.Controls.Add(this.status);
            this.Controls.Add(this.tool);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.button);
            this.Controls.Add(this.textMaximum);
            this.Controls.Add(this.textMininum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(350, 275);
            this.Name = "MainForm";
            this.Text = "Первое приложение";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errors)).EndInit();
            this.tool.ResumeLayout(false);
            this.tool.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textMininum;
        private System.Windows.Forms.TextBox textMaximum;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.ErrorProvider errors;
        private System.Windows.Forms.ToolStrip tool;
        private System.Windows.Forms.ToolStripButton startButton;
        private System.Windows.Forms.ToolStripButton stopButton;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripProgressBar progress;
        private System.ComponentModel.BackgroundWorker worker;
        private System.Windows.Forms.ToolTip tip;
    }
}

