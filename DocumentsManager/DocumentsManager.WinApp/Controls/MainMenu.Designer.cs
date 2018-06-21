namespace DocumentsManager.WinApp.Controls
{
    partial class MainMenu
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
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonManageStyles = new System.Windows.Forms.Button();
            this.buttonManageFormats = new System.Windows.Forms.Button();
            this.labelMainMenu = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonExit);
            this.panel1.Controls.Add(this.buttonManageStyles);
            this.panel1.Controls.Add(this.buttonManageFormats);
            this.panel1.Controls.Add(this.labelMainMenu);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(385, 346);
            this.panel1.TabIndex = 0;
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonExit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonExit.Location = new System.Drawing.Point(122, 216);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(142, 30);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.Text = "Salir";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonManageStyles
            // 
            this.buttonManageStyles.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonManageStyles.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonManageStyles.Location = new System.Drawing.Point(122, 162);
            this.buttonManageStyles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonManageStyles.Name = "buttonManageStyles";
            this.buttonManageStyles.Size = new System.Drawing.Size(142, 30);
            this.buttonManageStyles.TabIndex = 4;
            this.buttonManageStyles.Text = "Gestión de Estilos";
            this.buttonManageStyles.UseVisualStyleBackColor = false;
            this.buttonManageStyles.Click += new System.EventHandler(this.buttonManageStyles_Click);
            // 
            // buttonManageFormats
            // 
            this.buttonManageFormats.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonManageFormats.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonManageFormats.Location = new System.Drawing.Point(122, 106);
            this.buttonManageFormats.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonManageFormats.Name = "buttonManageFormats";
            this.buttonManageFormats.Size = new System.Drawing.Size(142, 30);
            this.buttonManageFormats.TabIndex = 1;
            this.buttonManageFormats.Text = "Gestión de Formatos";
            this.buttonManageFormats.UseVisualStyleBackColor = false;
            this.buttonManageFormats.Click += new System.EventHandler(this.buttonManageFormats_Click);
            // 
            // labelMainMenu
            // 
            this.labelMainMenu.AutoSize = true;
            this.labelMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelMainMenu.Location = new System.Drawing.Point(118, 24);
            this.labelMainMenu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMainMenu.Name = "labelMainMenu";
            this.labelMainMenu.Size = new System.Drawing.Size(141, 25);
            this.labelMainMenu.TabIndex = 0;
            this.labelMainMenu.Text = "Menú Principal";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainMenu";
            this.Size = new System.Drawing.Size(386, 348);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonManageFormats;
        private System.Windows.Forms.Label labelMainMenu;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonManageStyles;
    }
}
