namespace GenericServiceApp
{
    partial class GenericService
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.watch = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.watch)).BeginInit();
            // 
            // GenericService
            // 
            this.AutoLog = false;
            this.CanPauseAndContinue = true;
            this.ServiceName = "GenericService";
            ((System.ComponentModel.ISupportInitialize)(this.watch)).EndInit();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.IO.FileSystemWatcher watch;
    }
}
