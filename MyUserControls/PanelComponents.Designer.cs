namespace generateContentForInstructionSimonov.MyUserControls
{
    partial class PanelComponents
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelComponents));
            this.imgContextComponent1 = new generateContentForInstructionSimonov.MyUserControls.ImgContextComponent();
            this.textElement1 = new generateContentForInstructionSimonov.MyUserControls.TextElement();
            this.SuspendLayout();
            // 
            // imgContextComponent1
            // 
            this.imgContextComponent1.AllowDrop = true;
            this.imgContextComponent1.AutoSize = true;
            this.imgContextComponent1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.imgContextComponent1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imgContextComponent1.BackgroundImage")));
            this.imgContextComponent1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imgContextComponent1.form = null;
            this.imgContextComponent1.Location = new System.Drawing.Point(14, 15);
            this.imgContextComponent1.MaximumSize = new System.Drawing.Size(50, 50);
            this.imgContextComponent1.MinimumSize = new System.Drawing.Size(50, 50);
            this.imgContextComponent1.Name = "imgContextComponent1";
            this.imgContextComponent1.Size = new System.Drawing.Size(50, 50);
            this.imgContextComponent1.TabIndex = 0;
            // 
            // textElement1
            // 
            this.textElement1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textElement1.form = null;
            this.textElement1.Location = new System.Drawing.Point(14, 94);
            this.textElement1.Name = "textElement1";
            this.textElement1.Size = new System.Drawing.Size(150, 50);
            this.textElement1.TabIndex = 1;
            // 
            // PanelComponents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.textElement1);
            this.Controls.Add(this.imgContextComponent1);
            this.Name = "PanelComponents";
            this.Size = new System.Drawing.Size(246, 204);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ImgContextComponent imgContextComponent1;
        private TextElement textElement1;
    }
}
