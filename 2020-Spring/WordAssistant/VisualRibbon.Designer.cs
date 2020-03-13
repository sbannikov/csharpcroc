namespace WordAssistant
{
    partial class VisualRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public VisualRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.tabCROC = this.Factory.CreateRibbonTab();
            this.groupAssistant = this.Factory.CreateRibbonGroup();
            this.buttonFields = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.tabCROC.SuspendLayout();
            this.groupAssistant.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // tabCROC
            // 
            this.tabCROC.Groups.Add(this.groupAssistant);
            this.tabCROC.Label = "КРОК";
            this.tabCROC.Name = "tabCROC";
            // 
            // groupAssistant
            // 
            this.groupAssistant.Items.Add(this.buttonFields);
            this.groupAssistant.Label = "Помощник";
            this.groupAssistant.Name = "groupAssistant";
            // 
            // buttonFields
            // 
            this.buttonFields.Label = "Поля";
            this.buttonFields.Name = "buttonFields";
            this.buttonFields.ScreenTip = "Управление свойствами документов";
            this.buttonFields.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonFields_Click);
            // 
            // VisualRibbon
            // 
            this.Name = "VisualRibbon";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tab1);
            this.Tabs.Add(this.tabCROC);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.VisualRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.tabCROC.ResumeLayout(false);
            this.tabCROC.PerformLayout();
            this.groupAssistant.ResumeLayout(false);
            this.groupAssistant.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabCROC;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupAssistant;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonFields;
    }

    partial class ThisRibbonCollection
    {
        internal VisualRibbon VisualRibbon
        {
            get { return this.GetRibbon<VisualRibbon>(); }
        }
    }
}
