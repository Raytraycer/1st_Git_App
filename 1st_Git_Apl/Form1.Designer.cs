namespace _1st_Git_Apl
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_CurrentCursorPosition = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_CurrentCursorPosition
            // 
            this.lb_CurrentCursorPosition.AutoSize = true;
            this.lb_CurrentCursorPosition.Location = new System.Drawing.Point(13, 8);
            this.lb_CurrentCursorPosition.Name = "lb_CurrentCursorPosition";
            this.lb_CurrentCursorPosition.Size = new System.Drawing.Size(111, 13);
            this.lb_CurrentCursorPosition.TabIndex = 0;
            this.lb_CurrentCursorPosition.Text = "Waiting market coord.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(170, 537);
            this.Controls.Add(this.lb_CurrentCursorPosition);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_CurrentCursorPosition;
    }
}

