namespace DocumentsManager.WinApp.Controls
{
    partial class ManageFormat
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
            this.labelTItle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonImportFormats = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonCreateStyle = new System.Windows.Forms.Button();
            this.buttonADdFormat = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTItle
            // 
            this.labelTItle.AutoSize = true;
            this.labelTItle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelTItle.Location = new System.Drawing.Point(13, 16);
            this.labelTItle.Name = "labelTItle";
            this.labelTItle.Size = new System.Drawing.Size(249, 29);
            this.labelTItle.TabIndex = 0;
            this.labelTItle.Text = "Gestión de Formatos";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonImportFormats);
            this.panel1.Controls.Add(this.buttonBack);
            this.panel1.Controls.Add(this.buttonCreateStyle);
            this.panel1.Controls.Add(this.buttonADdFormat);
            this.panel1.Controls.Add(this.labelTItle);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 305);
            this.panel1.TabIndex = 1;
            // 
            // buttonImportFormats
            // 
            this.buttonImportFormats.Location = new System.Drawing.Point(69, 171);
            this.buttonImportFormats.Name = "buttonImportFormats";
            this.buttonImportFormats.Size = new System.Drawing.Size(138, 23);
            this.buttonImportFormats.TabIndex = 4;
            this.buttonImportFormats.Text = "Importar Formatos";
            this.buttonImportFormats.UseVisualStyleBackColor = true;
            this.buttonImportFormats.Click += new System.EventHandler(this.buttonImportFormats_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(69, 228);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(138, 23);
            this.buttonBack.TabIndex = 3;
            this.buttonBack.Text = "Atrás";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonCreateStyle
            // 
            this.buttonCreateStyle.Location = new System.Drawing.Point(69, 128);
            this.buttonCreateStyle.Name = "buttonCreateStyle";
            this.buttonCreateStyle.Size = new System.Drawing.Size(138, 23);
            this.buttonCreateStyle.TabIndex = 2;
            this.buttonCreateStyle.Text = "Crear Estilo";
            this.buttonCreateStyle.UseVisualStyleBackColor = true;
            // 
            // buttonADdFormat
            // 
            this.buttonADdFormat.Location = new System.Drawing.Point(69, 86);
            this.buttonADdFormat.Name = "buttonADdFormat";
            this.buttonADdFormat.Size = new System.Drawing.Size(138, 23);
            this.buttonADdFormat.TabIndex = 1;
            this.buttonADdFormat.Text = "Crear Formato";
            this.buttonADdFormat.UseVisualStyleBackColor = true;
            this.buttonADdFormat.Click += new System.EventHandler(this.buttonADdFormat_Click);
            // 
            // ManageFormat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ManageFormat";
            this.Size = new System.Drawing.Size(284, 310);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTItle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonCreateStyle;
        private System.Windows.Forms.Button buttonADdFormat;
        private System.Windows.Forms.Button buttonImportFormats;
    }
}
