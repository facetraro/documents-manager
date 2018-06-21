﻿namespace DocumentsManager.WinApp.Controls
{
    partial class FormatCreator
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
            this.textBoxFormatName = new System.Windows.Forms.TextBox();
            this.buttonAddAStyle = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.listBoxStylesToAdd = new System.Windows.Forms.ListBox();
            this.listBoxPossibleStyles = new System.Windows.Forms.ListBox();
            this.labelStylesToAdd1 = new System.Windows.Forms.Label();
            this.labelFormatName = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonCreateFormat = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonDeleteStyle);
            this.panel1.Controls.Add(this.labelStylesToAdd2);
            this.panel1.Controls.Add(this.labelAddedStyles);
            this.panel1.Controls.Add(this.textBoxFormatName);
            this.panel1.Controls.Add(this.buttonAddAStyle);
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Controls.Add(this.listBoxStylesToAdd);
            this.panel1.Controls.Add(this.listBoxPossibleStyles);
            this.panel1.Controls.Add(this.labelStylesToAdd1);
            this.panel1.Controls.Add(this.labelFormatName);
            this.panel1.Controls.Add(this.buttonBack);
            this.panel1.Controls.Add(this.buttonCreateFormat);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(615, 565);
            this.panel1.TabIndex = 0;
            // 
            // buttonDeleteStyle
            // 
            this.buttonDeleteStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonDeleteStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.buttonDeleteStyle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonDeleteStyle.Location = new System.Drawing.Point(227, 280);
            this.buttonDeleteStyle.Name = "buttonDeleteStyle";
            this.buttonDeleteStyle.Size = new System.Drawing.Size(61, 44);
            this.buttonDeleteStyle.TabIndex = 11;
            this.buttonDeleteStyle.Text = "▲";
            this.buttonDeleteStyle.UseVisualStyleBackColor = false;
            this.buttonDeleteStyle.Click += new System.EventHandler(this.buttonDeleteStyle_Click);
            // 
            // labelStylesToAdd2
            // 
            this.labelStylesToAdd2.AutoSize = true;
            this.labelStylesToAdd2.Location = new System.Drawing.Point(48, 201);
            this.labelStylesToAdd2.Name = "labelStylesToAdd2";
            this.labelStylesToAdd2.Size = new System.Drawing.Size(74, 17);
            this.labelStylesToAdd2.TabIndex = 10;
            this.labelStylesToAdd2.Text = "a agregar:";
            // 
            // labelAddedStyles
            // 
            this.labelAddedStyles.AutoSize = true;
            this.labelAddedStyles.Location = new System.Drawing.Point(29, 381);
            this.labelAddedStyles.Name = "labelAddedStyles";
            this.labelAddedStyles.Size = new System.Drawing.Size(125, 17);
            this.labelAddedStyles.TabIndex = 9;
            this.labelAddedStyles.Text = "Estilos agregados:";
            // 
            // textBoxFormatName
            // 
            this.textBoxFormatName.Location = new System.Drawing.Point(227, 75);
            this.textBoxFormatName.Name = "textBoxFormatName";
            this.textBoxFormatName.Size = new System.Drawing.Size(221, 22);
            this.textBoxFormatName.TabIndex = 8;
            // 
            // buttonAddAStyle
            // 
            this.buttonAddAStyle.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonAddAStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.buttonAddAStyle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonAddAStyle.Location = new System.Drawing.Point(386, 280);
            this.buttonAddAStyle.Name = "buttonAddAStyle";
            this.buttonAddAStyle.Size = new System.Drawing.Size(62, 44);
            this.buttonAddAStyle.TabIndex = 7;
            this.buttonAddAStyle.Text = "▼";
            this.buttonAddAStyle.UseVisualStyleBackColor = false;
            this.buttonAddAStyle.Click += new System.EventHandler(this.buttonAddAStyle_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelTitle.Location = new System.Drawing.Point(222, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(208, 29);
            this.labelTitle.TabIndex = 6;
            this.labelTitle.Text = "Agreagar Formato";
            // 
            // listBoxStylesToAdd
            // 
            this.listBoxStylesToAdd.FormattingEnabled = true;
            this.listBoxStylesToAdd.ItemHeight = 16;
            this.listBoxStylesToAdd.Location = new System.Drawing.Point(178, 330);
            this.listBoxStylesToAdd.Name = "listBoxStylesToAdd";
            this.listBoxStylesToAdd.Size = new System.Drawing.Size(309, 148);
            this.listBoxStylesToAdd.TabIndex = 5;
            // 
            // listBoxPossibleStyles
            // 
            this.listBoxPossibleStyles.FormattingEnabled = true;
            this.listBoxPossibleStyles.ItemHeight = 16;
            this.listBoxPossibleStyles.Location = new System.Drawing.Point(178, 125);
            this.listBoxPossibleStyles.Name = "listBoxPossibleStyles";
            this.listBoxPossibleStyles.Size = new System.Drawing.Size(309, 148);
            this.listBoxPossibleStyles.TabIndex = 4;
            // 
            // labelStylesToAdd1
            // 
            this.labelStylesToAdd1.AutoSize = true;
            this.labelStylesToAdd1.Location = new System.Drawing.Point(29, 184);
            this.labelStylesToAdd1.Name = "labelStylesToAdd1";
            this.labelStylesToAdd1.Size = new System.Drawing.Size(121, 17);
            this.labelStylesToAdd1.TabIndex = 3;
            this.labelStylesToAdd1.Text = "Seleccione estilos";
            // 
            // labelFormatName
            // 
            this.labelFormatName.AutoSize = true;
            this.labelFormatName.Location = new System.Drawing.Point(29, 78);
            this.labelFormatName.Name = "labelFormatName";
            this.labelFormatName.Size = new System.Drawing.Size(138, 17);
            this.labelFormatName.TabIndex = 2;
            this.labelFormatName.Text = "Nombre de Formato:";
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonBack.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonBack.Location = new System.Drawing.Point(23, 509);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(81, 35);
            this.buttonBack.TabIndex = 1;
            this.buttonBack.Text = "Volver";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonCreateFormat
            // 
            this.buttonCreateFormat.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonCreateFormat.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonCreateFormat.Location = new System.Drawing.Point(499, 509);
            this.buttonCreateFormat.Name = "buttonCreateFormat";
            this.buttonCreateFormat.Size = new System.Drawing.Size(84, 35);
            this.buttonCreateFormat.TabIndex = 0;
            this.buttonCreateFormat.Text = "Crear";
            this.buttonCreateFormat.UseVisualStyleBackColor = false;
            this.buttonCreateFormat.Click += new System.EventHandler(this.buttonCreateFormat_Click);
            // 
            // FormatCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "FormatCreator";
            this.Size = new System.Drawing.Size(618, 569);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonAddAStyle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ListBox listBoxStylesToAdd;
        private System.Windows.Forms.ListBox listBoxPossibleStyles;
        private System.Windows.Forms.Label labelStylesToAdd1;
        private System.Windows.Forms.Label labelFormatName;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonCreateFormat;
        private System.Windows.Forms.Label labelAddedStyles;
        private System.Windows.Forms.TextBox textBoxFormatName;
        private System.Windows.Forms.Label labelStylesToAdd2;
        private System.Windows.Forms.Button buttonDeleteStyle;
    }
}
