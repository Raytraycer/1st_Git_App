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
            this.dg_OrderData = new System.Windows.Forms.DataGridView();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dg_OrderData)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_CurrentCursorPosition
            // 
            this.lb_CurrentCursorPosition.AutoSize = true;
            this.lb_CurrentCursorPosition.Location = new System.Drawing.Point(-1, 515);
            this.lb_CurrentCursorPosition.Name = "lb_CurrentCursorPosition";
            this.lb_CurrentCursorPosition.Size = new System.Drawing.Size(111, 13);
            this.lb_CurrentCursorPosition.TabIndex = 0;
            this.lb_CurrentCursorPosition.Text = "Waiting market coord.";
            // 
            // dg_OrderData
            // 
            this.dg_OrderData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dg_OrderData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_OrderData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Data,
            this.Value});
            this.dg_OrderData.Location = new System.Drawing.Point(2, 12);
            this.dg_OrderData.Name = "dg_OrderData";
            this.dg_OrderData.ReadOnly = true;
            this.dg_OrderData.RowHeadersVisible = false;
            this.dg_OrderData.Size = new System.Drawing.Size(166, 150);
            this.dg_OrderData.TabIndex = 1;
            // 
            // Data
            // 
            this.Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            this.Data.Width = 50;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(170, 537);
            this.Controls.Add(this.dg_OrderData);
            this.Controls.Add(this.lb_CurrentCursorPosition);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_OrderData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_CurrentCursorPosition;
        private System.Windows.Forms.DataGridView dg_OrderData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
    }
}

