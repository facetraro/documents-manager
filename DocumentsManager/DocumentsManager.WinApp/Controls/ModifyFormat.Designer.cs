namespace DocumentsManager.WinApp.Controls
{
    partial class ModifyFormat
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
            this.buttonDeleteStyle = new System.Windows.Forms.Button();
            this.labelStylesToAdd2 = new System.Windows.Forms.Label();
            this.labelAddedStyles = new System.Windows.Forms.Label();
            this.buttonAddAStyle = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelStylesToAdd1 = new System.Windows.Forms.Label();
            this.labelFormatName = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonCreateFormat = new System.Windows.Forms.Button();
            this.textBoxFN = new System.Windows.Forms.TextBox();
            this.listBoxStylesKeep = new System.Windows.Forms.ListBox();
            this.listBoxStylesToLeave = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonDeleteStyle);
            this.panel1.Controls.Add(this.labelStylesToAdd2);
            this.panel1.Controls.Add(this.labelAddedStyles);
            this.panel1.Controls.Add(this.buttonAddAStyle);
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Controls.Add(this.labelStylesToAdd1);
            this.panel1.Controls.Add(this.labelFormatName);
            this.panel1.Controls.Add(this.buttonBack);
            this.panel1.Controls.Add(this.buttonCreateFormat);
            this.panel1.Controls.Add(this.textBoxFN);
            this.panel1.Controls.Add(this.listBoxStylesKeep);
            this.panel1.Controls.Add(this.listBoxStylesToLeave);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(609, 558);
            this.panel1.TabIndex = 0;
            // 
            // buttonDeleteStyle
            // 
            this.buttonDeleteStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonDeleteStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.buttonDeleteStyle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonDeleteStyle.Location = new System.Drawing.Point(214, 268);
            this.buttonDeleteStyle.Name = "buttonDeleteStyle";
            this.buttonDeleteStyle.Size = new System.Drawing.Size(61, 44);
            this.buttonDeleteStyle.TabIndex = 20;
            this.buttonDeleteStyle.Text = "▲";
            this.buttonDeleteStyle.UseVisualStyleBackColor = false;
            this.buttonDeleteStyle.Click += new System.EventHandler(this.buttonDeleteStyle_Click);
            // 
            // labelStylesToAdd2
            // 
            this.labelStylesToAdd2.AutoSize = true;
            this.labelStylesToAdd2.Location = new System.Drawing.Point(8, 183);
            this.labelStylesToAdd2.Name = "labelStylesToAdd2";
            this.labelStylesToAdd2.Size = new System.Drawing.Size(74, 17);
            this.labelStylesToAdd2.TabIndex = 19;
            this.labelStylesToAdd2.Text = "a agregar:";
            // 
            // labelAddedStyles
            // 
            this.labelAddedStyles.AutoSize = true;
            this.labelAddedStyles.Location = new System.Drawing.Point(8, 357);
            this.labelAddedStyles.Name = "labelAddedStyles";
            this.labelAddedStyles.Size = new System.Drawing.Size(125, 17);
            this.labelAddedStyles.TabIndex = 18;
            this.labelAddedStyles.Text = "Estilos agregados:";
            // 
            // buttonAddAStyle
            // 
            this.buttonAddAStyle.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonAddAStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.buttonAddAStyle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonAddAStyle.Location = new System.Drawing.Point(376, 268);
            this.buttonAddAStyle.Name = "buttonAddAStyle";
            this.buttonAddAStyle.Size = new System.Drawing.Size(62, 44);
            this.buttonAddAStyle.TabIndex = 17;
            this.buttonAddAStyle.Text = "▼";
            this.buttonAddAStyle.UseVisualStyleBackColor = false;
            this.buttonAddAStyle.Click += new System.EventHandler(this.buttonAddAStyle_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelTitle.Location = new System.Drawing.Point(209, 12);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(208, 29);
            this.labelTitle.TabIndex = 16;
            this.labelTitle.Text = "Agreagar Formato";
            // 
            // labelStylesToAdd1
            // 
            this.labelStylesToAdd1.AutoSize = true;
            this.labelStylesToAdd1.Location = new System.Drawing.Point(8, 166);
            this.labelStylesToAdd1.Name = "labelStylesToAdd1";
            this.labelStylesToAdd1.Size = new System.Drawing.Size(121, 17);
            this.labelStylesToAdd1.TabIndex = 15;
            this.labelStylesToAdd1.Text = "Seleccione estilos";
            // 
            // labelFormatName
            // 
            this.labelFormatName.AutoSize = true;
            this.labelFormatName.Location = new System.Drawing.Point(3, 60);
            this.labelFormatName.Name = "labelFormatName";
            this.labelFormatName.Size = new System.Drawing.Size(141, 17);
            this.labelFormatName.TabIndex = 14;
            this.labelFormatName.Text = "Nombre del Formato:";
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonBack.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonBack.Location = new System.Drawing.Point(11, 514);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(81, 35);
            this.buttonBack.TabIndex = 13;
            this.buttonBack.Text = "Volver";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonCreateFormat
            // 
            this.buttonCreateFormat.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonCreateFormat.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonCreateFormat.Location = new System.Drawing.Point(513, 514);
            this.buttonCreateFormat.Name = "buttonCreateFormat";
            this.buttonCreateFormat.Size = new System.Drawing.Size(84, 35);
            this.buttonCreateFormat.TabIndex = 12;
            this.buttonCreateFormat.Text = "Crear";
            this.buttonCreateFormat.UseVisualStyleBackColor = false;
            this.buttonCreateFormat.Click += new System.EventHandler(this.buttonCreateFormat_Click);
            // 
            // textBoxFN
            // 
            this.textBoxFN.Location = new System.Drawing.Point(214, 60);
            this.textBoxFN.Name = "textBoxFN";
            this.textBoxFN.Size = new System.Drawing.Size(203, 22);
            this.textBoxFN.TabIndex = 2;
            // 
            // listBoxStylesKeep
            // 
            this.listBoxStylesKeep.FormattingEnabled = true;
            this.listBoxStylesKeep.ItemHeight = 16;
            this.listBoxStylesKeep.Location = new System.Drawing.Point(161, 318);
            this.listBoxStylesKeep.Name = "listBoxStylesKeep";
            this.listBoxStylesKeep.Size = new System.Drawing.Size(387, 148);
            this.listBoxStylesKeep.TabIndex = 1;
            // 
            // listBoxStylesToLeave
            // 
            this.listBoxStylesToLeave.FormattingEnabled = true;
            this.listBoxStylesToLeave.ItemHeight = 16;
            this.listBoxStylesToLeave.Location = new System.Drawing.Point(161, 98);
            this.listBoxStylesToLeave.Name = "listBoxStylesToLeave";
            this.listBoxStylesToLeave.Size = new System.Drawing.Size(387, 164);
            this.listBoxStylesToLeave.TabIndex = 0;
            // 
            // ModifyFormat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ModifyFormat";
            this.Size = new System.Drawing.Size(616, 560);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBoxStylesKeep;
        private System.Windows.Forms.ListBox listBoxStylesToLeave;
        private System.Windows.Forms.TextBox textBoxFN;
        private System.Windows.Forms.Button buttonDeleteStyle;
        private System.Windows.Forms.Label labelStylesToAdd2;
        private System.Windows.Forms.Label labelAddedStyles;
        private System.Windows.Forms.Button buttonAddAStyle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelStylesToAdd1;
        private System.Windows.Forms.Label labelFormatName;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonCreateFormat;
    }
}
