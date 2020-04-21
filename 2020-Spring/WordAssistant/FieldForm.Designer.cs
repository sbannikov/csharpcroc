namespace WordAssistant
{
    partial class FieldForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FieldForm));
            this.label1 = new System.Windows.Forms.Label();
            this.comboDoc1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboDoc2 = new System.Windows.Forms.ComboBox();
            this.listFields1 = new System.Windows.Forms.CheckedListBox();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.listFields2 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Документ";
            // 
            // comboDoc1
            // 
            this.comboDoc1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDoc1.FormattingEnabled = true;
            this.comboDoc1.Location = new System.Drawing.Point(13, 30);
            this.comboDoc1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboDoc1.Name = "comboDoc1";
            this.comboDoc1.Size = new System.Drawing.Size(321, 24);
            this.comboDoc1.Sorted = true;
            this.comboDoc1.TabIndex = 0;
            this.comboDoc1.SelectedIndexChanged += new System.EventHandler(this.comboDoc_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(411, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Документ";
            // 
            // comboDoc2
            // 
            this.comboDoc2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboDoc2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDoc2.FormattingEnabled = true;
            this.comboDoc2.Location = new System.Drawing.Point(414, 30);
            this.comboDoc2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboDoc2.Name = "comboDoc2";
            this.comboDoc2.Size = new System.Drawing.Size(321, 24);
            this.comboDoc2.Sorted = true;
            this.comboDoc2.TabIndex = 2;
            this.comboDoc2.SelectedIndexChanged += new System.EventHandler(this.comboDoc_SelectedIndexChanged);
            // 
            // listFields1
            // 
            this.listFields1.FormattingEnabled = true;
            this.listFields1.Location = new System.Drawing.Point(13, 62);
            this.listFields1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listFields1.Name = "listFields1";
            this.listFields1.Size = new System.Drawing.Size(321, 429);
            this.listFields1.Sorted = true;
            this.listFields1.TabIndex = 1;
            // 
            // buttonLeft
            // 
            this.buttonLeft.Image = global::WordAssistant.Properties.Resources._126569_32_l;
            this.buttonLeft.Location = new System.Drawing.Point(342, 134);
            this.buttonLeft.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(64, 64);
            this.buttonLeft.TabIndex = 5;
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.buttonLeft_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.Image = global::WordAssistant.Properties.Resources._126569_32_r;
            this.buttonRight.Location = new System.Drawing.Point(342, 62);
            this.buttonRight.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(64, 64);
            this.buttonRight.TabIndex = 4;
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.buttonRight_Click);
            // 
            // listFields2
            // 
            this.listFields2.FormattingEnabled = true;
            this.listFields2.Location = new System.Drawing.Point(414, 63);
            this.listFields2.Margin = new System.Windows.Forms.Padding(4);
            this.listFields2.Name = "listFields2";
            this.listFields2.Size = new System.Drawing.Size(321, 429);
            this.listFields2.Sorted = true;
            this.listFields2.TabIndex = 1;
            // 
            // FieldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 505);
            this.Controls.Add(this.listFields2);
            this.Controls.Add(this.listFields1);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.comboDoc2);
            this.Controls.Add(this.comboDoc1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FieldForm";
            this.Text = "Свойства документов";
            this.Load += new System.EventHandler(this.FieldForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboDoc1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboDoc2;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.CheckedListBox listFields1;
        private System.Windows.Forms.CheckedListBox listFields2;
    }
}