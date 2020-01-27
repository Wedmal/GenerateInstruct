namespace generateContentForInstructionSimonov
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelDiagnostic1 = new System.Windows.Forms.Label();
            this.textElement1 = new generateContentForInstructionSimonov.MyUserControls.TextElement();
            this.imgContextComponent2 = new generateContentForInstructionSimonov.MyUserControls.ImgContextComponent();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(463, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 542);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(460, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Схема расположения компонентов:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Компоненты:";
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(12, 277);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(445, 286);
            this.panel3.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Настройки компонента и его содержимое:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(752, 622);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Предпросмотр";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelDiagnostic1);
            this.panel2.Location = new System.Drawing.Point(15, 569);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(731, 76);
            this.panel2.TabIndex = 8;
            // 
            // labelDiagnostic1
            // 
            this.labelDiagnostic1.AutoSize = true;
            this.labelDiagnostic1.Location = new System.Drawing.Point(3, 0);
            this.labelDiagnostic1.Name = "labelDiagnostic1";
            this.labelDiagnostic1.Size = new System.Drawing.Size(28, 13);
            this.labelDiagnostic1.TabIndex = 0;
            this.labelDiagnostic1.Text = "Info:";
            // 
            // textElement1
            // 
            this.textElement1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textElement1.form = this;
            this.textElement1.item_for_copy = true;
            this.textElement1.Location = new System.Drawing.Point(15, 77);
            this.textElement1.Name = "textElement1";
            this.textElement1.Size = new System.Drawing.Size(150, 50);
            this.textElement1.TabIndex = 11;
            // 
            // imgContextComponent2
            // 
            this.imgContextComponent2.AutoSize = true;
            this.imgContextComponent2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.imgContextComponent2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imgContextComponent2.BackgroundImage")));
            this.imgContextComponent2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imgContextComponent2.form = this;
            this.imgContextComponent2.item_for_copy = true;
            this.imgContextComponent2.Location = new System.Drawing.Point(15, 21);
            this.imgContextComponent2.MaximumSize = new System.Drawing.Size(50, 50);
            this.imgContextComponent2.MinimumSize = new System.Drawing.Size(50, 50);
            this.imgContextComponent2.Name = "imgContextComponent2";
            this.imgContextComponent2.Size = new System.Drawing.Size(50, 50);
            this.imgContextComponent2.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(868, 651);
            this.Controls.Add(this.textElement1);
            this.Controls.Add(this.imgContextComponent2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelDiagnostic1;
        private MyUserControls.ImgContextComponent imgContextComponent2;
        private MyUserControls.TextElement textElement1;
    }
}

