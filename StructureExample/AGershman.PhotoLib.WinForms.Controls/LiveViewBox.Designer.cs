namespace AGershman.PhotoLib.WinForms.Controls
{
    partial class LiveViewBox
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
            this.pbView = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbView)).BeginInit();
            this.SuspendLayout();
            // 
            // pbView
            // 
            this.pbView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbView.Location = new System.Drawing.Point(0, 0);
            this.pbView.Name = "pbView";
            this.pbView.Size = new System.Drawing.Size(800, 450);
            this.pbView.TabIndex = 0;
            this.pbView.TabStop = false;
            // 
            // LiveViewBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbView);
            this.Name = "LiveViewBox";
            this.Size = new System.Drawing.Size(800, 450);
            ((System.ComponentModel.ISupportInitialize)(this.pbView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbView;
    }
}
