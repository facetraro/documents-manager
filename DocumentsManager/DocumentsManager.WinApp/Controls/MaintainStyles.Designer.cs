namespace DocumentsManager.WinApp.Controls
{
    partial class MaintainStyles
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
            this.label2 = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonDeleteStyle = new System.Windows.Forms.Button();
            this.buttonModifyStyle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxStyles = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Seleccione un Estilo para tomar una acción: ";
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonBack.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonBack.Location = new System.Drawing.Point(11, 423);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(69, 24);
            this.buttonBack.TabIndex = 10;
            this.buttonBack.Text = "Volver";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonDeleteStyle
            // 
            this.buttonDeleteStyle.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonDeleteStyle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonDeleteStyle.Location = new System.Drawing.Point(278, 423);
            this.buttonDeleteStyle.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDeleteStyle.Name = "buttonDeleteStyle";
            this.buttonDeleteStyle.Size = new System.Drawing.Size(69, 24);
            this.buttonDeleteStyle.TabIndex = 9;
            this.buttonDeleteStyle.Text = "Eliminar";
            this.buttonDeleteStyle.UseVisualStyleBackColor = false;
            this.buttonDeleteStyle.Click += new System.EventHandler(this.buttonDeleteStyle_Click);
            // 
            // buttonModifyStyle
            // 
            this.buttonModifyStyle.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonModifyStyle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonModifyStyle.Location = new System.Drawing.Point(545, 423);
            this.buttonModifyStyle.Margin = new System.Windows.Forms.Padding(2);
            this.buttonModifyStyle.Name = "buttonModifyStyle";
            this.buttonModifyStyle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonModifyStyle.Size = new System.Drawing.Size(69, 24);
            this.buttonModifyStyle.TabIndex = 8;
            this.buttonModifyStyle.Text = "Modificar";
            this.buttonModifyStyle.UseVisualStyleBackColor = false;
            this.buttonModifyStyle.Click += new System.EventHandler(this.buttonModifyStyle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(120, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mantener Estilos";
            // 
            // listBoxStyles
            // 
            this.listBoxStyles.FormattingEnabled = true;
            this.listBoxStyles.Location = new System.Drawing.Point(29, 78);
            this.listBoxStyles.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxStyles.Name = "listBoxStyles";
            this.listBoxStyles.Size = new System.Drawing.Size(569, 316);
            this.listBoxStyles.TabIndex = 6;
            // 
            // MaintainStyles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonDeleteStyle);
            this.Controls.Add(this.buttonModifyStyle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxStyles);
            this.Name = "MaintainStyles";
            this.Size = new System.Drawing.Size(627, 462);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonDeleteStyle;
        private System.Windows.Forms.Button buttonModifyStyle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxStyles;
    }
}
