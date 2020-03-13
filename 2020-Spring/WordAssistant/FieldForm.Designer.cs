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
            this.label1 = new System.Windows.Forms.Label();
            this.comboDoc1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboDoc2 = new System.Windows.Forms.ComboBox();
            this.listFields2 = new System.Windows.Forms.ListBox();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.listFields1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Документ";
            // 
            // comboDoc1
            // 
            this.comboDoc1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDoc1.FormattingEnabled = true;
            this.comboDoc1.Location = new System.Drawing.Point(16, 30);
            this.comboDoc1.Name = "comboDoc1";
            this.comboDoc1.Size = new System.Drawing.Size(242, 21);
            this.comboDoc1.Sorted = true;
            this.comboDoc1.TabIndex = 1;
            this.comboDoc1.SelectedIndexChanged += new System.EventHandler(this.comboDoc_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Документ";
            // 
            // comboDoc2
            // 
            this.comboDoc2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDoc2.FormattingEnabled = true;
            this.comboDoc2.Location = new System.Drawing.Point(333, 30);
            this.comboDoc2.Name = "comboDoc2";
            this.comboDoc2.Size = new System.Drawing.Size(242, 21);
            this.comboDoc2.Sorted = true;
            this.comboDoc2.TabIndex = 1;
            this.comboDoc2.SelectedIndexChanged += new System.EventHandler(this.comboDoc_SelectedIndexChanged);
            // 
            // listFields2
            // 
            this.listFields2.FormattingEnabled = true;
            this.listFields2.Location = new System.Drawing.Point(333, 69);
            this.listFields2.Name = "listFields2";
            this.listFields2.Size = new System.Drawing.Size(242, 316);
            this.listFields2.Sorted = true;
            this.listFields2.TabIndex = 2;
            // 
            // buttonRight
            // 
            this.buttonRight.Location = new System.Drawing.Point(275, 69);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(48, 48);
            this.buttonRight.TabIndex = 3;
            this.buttonRight.Text = "button1";
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.buttonRight_Click);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Location = new System.Drawing.Point(275, 123);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(48, 48);
            this.buttonLeft.TabIndex = 3;
            this.buttonLeft.Text = "button1";
            this.buttonLeft.UseVisualStyleBackColor = true;
            // 
            // listFields1
            // 
            this.listFields1.FormattingEnabled = true;
            this.listFields1.Location = new System.Drawing.Point(16, 58);
            this.listFields1.Name = "listFields1";
            this.listFields1.Size = new System.Drawing.Size(242, 334);
            this.listFields1.Sorted = true;
            this.listFields1.TabIndex = 4;
            // 
            // FieldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 410);
            this.Controls.Add(this.listFields1);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.listFields2);
            this.Controls.Add(this.comboDoc2);
            this.Controls.Add(this.comboDoc1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FieldForm";
            this.Text = "FieldForm";
            this.Load += new System.EventHandler(this.FieldForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboDoc1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboDoc2;
        private System.Windows.Forms.ListBox listFields2;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.CheckedListBox listFields1;
    }
}