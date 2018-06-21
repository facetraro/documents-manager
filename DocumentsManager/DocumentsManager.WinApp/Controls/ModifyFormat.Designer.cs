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
            this.panel1.BackColor = System.Drawing.Color.Transparent;
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
            this.panel1.Location = new System.Drawing.Point(2, 7);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 453);
            this.panel1.TabIndex = 0;
            // 
            // buttonDeleteStyle
            // 
            this.buttonDeleteStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonDeleteStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.buttonDeleteStyle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonDeleteStyle.Location = new System.Drawing.Point(121, 218);
            this.buttonDeleteStyle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonDeleteStyle.Name = "buttonDeleteStyle";
            this.buttonDeleteStyle.Size = new System.Drawing.Size(46, 36);
            this.buttonDeleteStyle.TabIndex = 20;
            this.buttonDeleteStyle.Text = "▲";
            this.buttonDeleteStyle.UseVisualStyleBackColor = false;
            this.buttonDeleteStyle.Click += new System.EventHandler(this.buttonDeleteStyle_Click);
            // 
            // labelStylesToAdd2
            // 
            this.labelStylesToAdd2.AutoSize = true;
            this.labelStylesToAdd2.Location = new System.Drawing.Point(6, 149);
            this.labelStylesToAdd2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStylesToAdd2.Name = "labelStylesToAdd2";
            this.labelStylesToAdd2.Size = new System.Drawing.Size(55, 13);
            this.labelStylesToAdd2.TabIndex = 19;
            this.labelStylesToAdd2.Text = "a agregar:";
            // 
            // labelAddedStyles
            // 
            this.labelAddedStyles.AutoSize = true;
            this.labelAddedStyles.Location = new System.Drawing.Point(6, 290);
            this.labelAddedStyles.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAddedStyles.Name = "labelAddedStyles";
            this.labelAddedStyles.Size = new System.Drawing.Size(93, 13);
            this.labelAddedStyles.TabIndex = 18;
            this.labelAddedStyles.Text = "Estilos agregados:";
            // 
            // buttonAddAStyle
            // 
            this.buttonAddAStyle.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonAddAStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.buttonAddAStyle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonAddAStyle.Location = new System.Drawing.Point(559, 218);
            this.buttonAddAStyle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAddAStyle.Name = "buttonAddAStyle";
            this.buttonAddAStyle.Size = new System.Drawing.Size(46, 36);
            this.buttonAddAStyle.TabIndex = 17;
            this.buttonAddAStyle.Text = "▼";
            this.buttonAddAStyle.UseVisualStyleBackColor = false;
            this.buttonAddAStyle.Click += new System.EventHandler(this.buttonAddAStyle_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelTitle.Location = new System.Drawing.Point(219, 10);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(163, 24);
            this.labelTitle.TabIndex = 16;
            this.labelTitle.Text = "Agreagar Formato";
            // 
            // labelStylesToAdd1
            // 
            this.labelStylesToAdd1.AutoSize = true;
            this.labelStylesToAdd1.Location = new System.Drawing.Point(6, 135);
            this.labelStylesToAdd1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStylesToAdd1.Name = "labelStylesToAdd1";
            this.labelStylesToAdd1.Size = new System.Drawing.Size(92, 13);
            this.labelStylesToAdd1.TabIndex = 15;
            this.labelStylesToAdd1.Text = "Seleccione estilos";
            // 
            // labelFormatName
            // 
            this.labelFormatName.AutoSize = true;
            this.labelFormatName.Location = new System.Drawing.Point(2, 49);
            this.labelFormatName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFormatName.Name = "labelFormatName";
            this.labelFormatName.Size = new System.Drawing.Size(105, 13);
            this.labelFormatName.TabIndex = 14;
            this.labelFormatName.Text = "Nombre del Formato:";
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonBack.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonBack.Location = new System.Drawing.Point(5, 423);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(61, 28);
            this.buttonBack.TabIndex = 13;
            this.buttonBack.Text = "Volver";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonCreateFormat
            // 
            this.buttonCreateFormat.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonCreateFormat.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonCreateFormat.Location = new System.Drawing.Point(559, 423);
            this.buttonCreateFormat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonCreateFormat.Name = "buttonCreateFormat";
            this.buttonCreateFormat.Size = new System.Drawing.Size(63, 28);
            this.buttonCreateFormat.TabIndex = 12;
            this.buttonCreateFormat.Text = "Crear";
            this.buttonCreateFormat.UseVisualStyleBackColor = false;
            this.buttonCreateFormat.Click += new System.EventHandler(this.buttonCreateFormat_Click);
            // 
            // textBoxFN
            // 
            this.textBoxFN.Location = new System.Drawing.Point(121, 49);
            this.textBoxFN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxFN.Name = "textBoxFN";
            this.textBoxFN.Size = new System.Drawing.Size(487, 20);
            this.textBoxFN.TabIndex = 2;
            // 
            // listBoxStylesKeep
            // 
            this.listBoxStylesKeep.FormattingEnabled = true;
            this.listBoxStylesKeep.Location = new System.Drawing.Point(121, 258);
            this.listBoxStylesKeep.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBoxStylesKeep.Name = "listBoxStylesKeep";
            this.listBoxStylesKeep.Size = new System.Drawing.Size(487, 134);
            this.listBoxStylesKeep.TabIndex = 1;
            // 
            // listBoxStylesToLeave
            // 
            this.listBoxStylesToLeave.FormattingEnabled = true;
            this.listBoxStylesToLeave.Location = new System.Drawing.Point(121, 80);
            this.listBoxStylesToLeave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBoxStylesToLeave.Name = "listBoxStylesToLeave";
            this.listBoxStylesToLeave.Size = new System.Drawing.Size(487, 134);
            this.listBoxStylesToLeave.TabIndex = 0;
            // 
            // ModifyFormat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ModifyFormat";
            this.Size = new System.Drawing.Size(627, 462);
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
