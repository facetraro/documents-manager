namespace DocumentsManager.WinApp.Controls
{
    partial class ManageStyles
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonAddStyle = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonMaintainStyle = new System.Windows.Forms.Button();
            this.labelTItle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAddStyle
            // 
            this.buttonAddStyle.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonAddStyle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonAddStyle.Location = new System.Drawing.Point(74, 70);
            this.buttonAddStyle.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddStyle.Name = "buttonAddStyle";
            this.buttonAddStyle.Size = new System.Drawing.Size(116, 30);
            this.buttonAddStyle.TabIndex = 6;
            this.buttonAddStyle.Text = "Crear Estilo";
            this.buttonAddStyle.UseVisualStyleBackColor = false;
            this.buttonAddStyle.Click += new System.EventHandler(this.buttonAddStyle_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonBack.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonBack.Location = new System.Drawing.Point(74, 189);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(116, 30);
            this.buttonBack.TabIndex = 8;
            this.buttonBack.Text = "Volver";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonMaintainStyle
            // 
            this.buttonMaintainStyle.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonMaintainStyle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonMaintainStyle.Location = new System.Drawing.Point(74, 105);
            this.buttonMaintainStyle.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMaintainStyle.Name = "buttonMaintainStyle";
            this.buttonMaintainStyle.Size = new System.Drawing.Size(116, 30);
            this.buttonMaintainStyle.TabIndex = 7;
            this.buttonMaintainStyle.Text = "Mantener Estilos";
            this.buttonMaintainStyle.UseVisualStyleBackColor = false;
            this.buttonMaintainStyle.Click += new System.EventHandler(this.buttonMaintainStyle_Click);
            // 
            // labelTItle
            // 
            this.labelTItle.AutoSize = true;
            this.labelTItle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelTItle.Location = new System.Drawing.Point(48, 13);
            this.labelTItle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTItle.Name = "labelTItle";
            this.labelTItle.Size = new System.Drawing.Size(168, 25);
            this.labelTItle.TabIndex = 5;
            this.labelTItle.Text = "Gestión de Estilos";
            // 
            // ManageStyles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonAddStyle);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonMaintainStyle);
            this.Controls.Add(this.labelTItle);
            this.Name = "ManageStyles";
            this.Size = new System.Drawing.Size(250, 263);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonAddStyle;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonMaintainStyle;
        private System.Windows.Forms.Label labelTItle;
    }
}
