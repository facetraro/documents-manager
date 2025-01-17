﻿namespace DocumentsManager.WinApp.Controls
{
    partial class MaintainFormats
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
            this.label2 = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonDeleteFormat = new System.Windows.Forms.Button();
            this.buttonModifyFormat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxFormats = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.buttonBack);
            this.panel1.Controls.Add(this.buttonDeleteFormat);
            this.panel1.Controls.Add(this.buttonModifyFormat);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.listBoxFormats);
            this.panel1.Location = new System.Drawing.Point(-3, -9);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 460);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Seleccione un Formato para tomar una acción: ";
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonBack.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonBack.Location = new System.Drawing.Point(2, 434);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(69, 24);
            this.buttonBack.TabIndex = 4;
            this.buttonBack.Text = "Volver";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonDeleteFormat
            // 
            this.buttonDeleteFormat.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonDeleteFormat.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonDeleteFormat.Location = new System.Drawing.Point(283, 434);
            this.buttonDeleteFormat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonDeleteFormat.Name = "buttonDeleteFormat";
            this.buttonDeleteFormat.Size = new System.Drawing.Size(69, 24);
            this.buttonDeleteFormat.TabIndex = 3;
            this.buttonDeleteFormat.Text = "Eliminar";
            this.buttonDeleteFormat.UseVisualStyleBackColor = false;
            this.buttonDeleteFormat.Click += new System.EventHandler(this.buttonDeleteFormat_Click);
            // 
            // buttonModifyFormat
            // 
            this.buttonModifyFormat.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonModifyFormat.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonModifyFormat.Location = new System.Drawing.Point(554, 434);
            this.buttonModifyFormat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonModifyFormat.Name = "buttonModifyFormat";
            this.buttonModifyFormat.Size = new System.Drawing.Size(69, 24);
            this.buttonModifyFormat.TabIndex = 2;
            this.buttonModifyFormat.Text = "Modificar";
            this.buttonModifyFormat.UseVisualStyleBackColor = false;
            this.buttonModifyFormat.Click += new System.EventHandler(this.buttonModifyFormat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(216, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mantener Formatos";
            // 
            // listBoxFormats
            // 
            this.listBoxFormats.FormattingEnabled = true;
            this.listBoxFormats.Location = new System.Drawing.Point(33, 71);
            this.listBoxFormats.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBoxFormats.Name = "listBoxFormats";
            this.listBoxFormats.Size = new System.Drawing.Size(564, 303);
            this.listBoxFormats.TabIndex = 0;
            // 
            // MaintainFormats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MaintainFormats";
            this.Size = new System.Drawing.Size(627, 462);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonDeleteFormat;
        private System.Windows.Forms.Button buttonModifyFormat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxFormats;
    }
}
