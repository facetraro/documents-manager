namespace DocumentsManager.WinApp.Controls
{
    partial class CheckLog
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCheckLog = new System.Windows.Forms.Button();
            this.listBoxLogs = new System.Windows.Forms.ListBox();
            this.labelDateUntil = new System.Windows.Forms.Label();
            this.labelDateSince = new System.Windows.Forms.Label();
            this.dateTimePickerUntil = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerSince = new System.Windows.Forms.DateTimePicker();
            this.buttonBack = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.buttonCheckLog);
            this.panel1.Controls.Add(this.listBoxLogs);
            this.panel1.Controls.Add(this.labelDateUntil);
            this.panel1.Controls.Add(this.labelDateSince);
            this.panel1.Controls.Add(this.dateTimePickerUntil);
            this.panel1.Controls.Add(this.dateTimePickerSince);
            this.panel1.Controls.Add(this.buttonBack);
            this.panel1.Location = new System.Drawing.Point(5, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 457);
            this.panel1.TabIndex = 0;
            // 
            // buttonCheckLog
            // 
            this.buttonCheckLog.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonCheckLog.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonCheckLog.Location = new System.Drawing.Point(531, 33);
            this.buttonCheckLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonCheckLog.Name = "buttonCheckLog";
            this.buttonCheckLog.Size = new System.Drawing.Size(64, 32);
            this.buttonCheckLog.TabIndex = 8;
            this.buttonCheckLog.Text = "Consultar";
            this.buttonCheckLog.UseVisualStyleBackColor = false;
            this.buttonCheckLog.Click += new System.EventHandler(this.buttonCheckLog_Click);
            // 
            // listBoxLogs
            // 
            this.listBoxLogs.FormattingEnabled = true;
            this.listBoxLogs.Location = new System.Drawing.Point(28, 99);
            this.listBoxLogs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBoxLogs.Name = "listBoxLogs";
            this.listBoxLogs.Size = new System.Drawing.Size(567, 316);
            this.listBoxLogs.TabIndex = 7;
            // 
            // labelDateUntil
            // 
            this.labelDateUntil.AutoSize = true;
            this.labelDateUntil.Location = new System.Drawing.Point(35, 52);
            this.labelDateUntil.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDateUntil.Name = "labelDateUntil";
            this.labelDateUntil.Size = new System.Drawing.Size(69, 13);
            this.labelDateUntil.TabIndex = 6;
            this.labelDateUntil.Text = "Fecha hasta:";
            // 
            // labelDateSince
            // 
            this.labelDateSince.AutoSize = true;
            this.labelDateSince.Location = new System.Drawing.Point(35, 33);
            this.labelDateSince.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDateSince.Name = "labelDateSince";
            this.labelDateSince.Size = new System.Drawing.Size(72, 13);
            this.labelDateSince.TabIndex = 5;
            this.labelDateSince.Text = "Fecha desde:";
            // 
            // dateTimePickerUntil
            // 
            this.dateTimePickerUntil.Location = new System.Drawing.Point(122, 53);
            this.dateTimePickerUntil.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePickerUntil.Name = "dateTimePickerUntil";
            this.dateTimePickerUntil.Size = new System.Drawing.Size(209, 20);
            this.dateTimePickerUntil.TabIndex = 4;
            // 
            // dateTimePickerSince
            // 
            this.dateTimePickerSince.Location = new System.Drawing.Point(122, 30);
            this.dateTimePickerSince.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePickerSince.Name = "dateTimePickerSince";
            this.dateTimePickerSince.Size = new System.Drawing.Size(209, 20);
            this.dateTimePickerSince.TabIndex = 3;
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonBack.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonBack.Location = new System.Drawing.Point(2, 427);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(61, 28);
            this.buttonBack.TabIndex = 2;
            this.buttonBack.Text = "Volver";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // CheckLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CheckLog";
            this.Size = new System.Drawing.Size(627, 462);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonCheckLog;
        private System.Windows.Forms.ListBox listBoxLogs;
        private System.Windows.Forms.Label labelDateUntil;
        private System.Windows.Forms.Label labelDateSince;
        private System.Windows.Forms.DateTimePicker dateTimePickerUntil;
        private System.Windows.Forms.DateTimePicker dateTimePickerSince;
    }
}
