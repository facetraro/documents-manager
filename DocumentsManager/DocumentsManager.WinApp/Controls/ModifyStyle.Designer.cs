namespace DocumentsManager.WinApp.Controls
{
    partial class ModifyStyle
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
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.buttonDeleteStyle = new System.Windows.Forms.Button();
            this.labelAddedStyles = new System.Windows.Forms.Label();
            this.textBoxStyleName = new System.Windows.Forms.TextBox();
            this.buttonAddAStyle = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.listBoxAttributesToAdd = new System.Windows.Forms.ListBox();
            this.labelStylesToAdd1 = new System.Windows.Forms.Label();
            this.labelFormatName = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonCreateFormat = new System.Windows.Forms.Button();
            this.comboBoxAttributeValue = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(138, 160);
            this.numericUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(233, 20);
            this.numericUpDown.TabIndex = 26;
            this.numericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(138, 106);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(233, 21);
            this.comboBox.TabIndex = 25;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // buttonDeleteStyle
            // 
            this.buttonDeleteStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonDeleteStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.buttonDeleteStyle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonDeleteStyle.Location = new System.Drawing.Point(138, 216);
            this.buttonDeleteStyle.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDeleteStyle.Name = "buttonDeleteStyle";
            this.buttonDeleteStyle.Size = new System.Drawing.Size(46, 36);
            this.buttonDeleteStyle.TabIndex = 24;
            this.buttonDeleteStyle.Text = "▲";
            this.buttonDeleteStyle.UseVisualStyleBackColor = false;
            this.buttonDeleteStyle.Click += new System.EventHandler(this.buttonDeleteStyle_Click);
            // 
            // labelAddedStyles
            // 
            this.labelAddedStyles.AutoSize = true;
            this.labelAddedStyles.Location = new System.Drawing.Point(26, 307);
            this.labelAddedStyles.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAddedStyles.Name = "labelAddedStyles";
            this.labelAddedStyles.Size = new System.Drawing.Size(104, 13);
            this.labelAddedStyles.TabIndex = 23;
            this.labelAddedStyles.Text = "Atributos agregados:";
            // 
            // textBoxStyleName
            // 
            this.textBoxStyleName.Location = new System.Drawing.Point(138, 58);
            this.textBoxStyleName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxStyleName.Name = "textBoxStyleName";
            this.textBoxStyleName.Size = new System.Drawing.Size(233, 20);
            this.textBoxStyleName.TabIndex = 22;
            // 
            // buttonAddAStyle
            // 
            this.buttonAddAStyle.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonAddAStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.buttonAddAStyle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonAddAStyle.Location = new System.Drawing.Point(325, 216);
            this.buttonAddAStyle.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddAStyle.Name = "buttonAddAStyle";
            this.buttonAddAStyle.Size = new System.Drawing.Size(46, 36);
            this.buttonAddAStyle.TabIndex = 21;
            this.buttonAddAStyle.Text = "▼";
            this.buttonAddAStyle.UseVisualStyleBackColor = false;
            this.buttonAddAStyle.Click += new System.EventHandler(this.buttonAddAStyle_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelTitle.Location = new System.Drawing.Point(177, 14);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(136, 24);
            this.labelTitle.TabIndex = 20;
            this.labelTitle.Text = "Modificar Estilo";
            // 
            // listBoxAttributesToAdd
            // 
            this.listBoxAttributesToAdd.FormattingEnabled = true;
            this.listBoxAttributesToAdd.Location = new System.Drawing.Point(138, 265);
            this.listBoxAttributesToAdd.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxAttributesToAdd.Name = "listBoxAttributesToAdd";
            this.listBoxAttributesToAdd.Size = new System.Drawing.Size(233, 121);
            this.listBoxAttributesToAdd.TabIndex = 19;
            // 
            // labelStylesToAdd1
            // 
            this.labelStylesToAdd1.AutoSize = true;
            this.labelStylesToAdd1.Location = new System.Drawing.Point(26, 109);
            this.labelStylesToAdd1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStylesToAdd1.Name = "labelStylesToAdd1";
            this.labelStylesToAdd1.Size = new System.Drawing.Size(79, 13);
            this.labelStylesToAdd1.TabIndex = 18;
            this.labelStylesToAdd1.Text = "Añadir Atributo:";
            // 
            // labelFormatName
            // 
            this.labelFormatName.AutoSize = true;
            this.labelFormatName.Location = new System.Drawing.Point(26, 60);
            this.labelFormatName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFormatName.Name = "labelFormatName";
            this.labelFormatName.Size = new System.Drawing.Size(92, 13);
            this.labelFormatName.TabIndex = 17;
            this.labelFormatName.Text = "Nombre del Estilo:";
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonBack.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonBack.Location = new System.Drawing.Point(14, 403);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(61, 28);
            this.buttonBack.TabIndex = 16;
            this.buttonBack.Text = "Volver";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonCreateFormat
            // 
            this.buttonCreateFormat.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonCreateFormat.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonCreateFormat.Location = new System.Drawing.Point(406, 404);
            this.buttonCreateFormat.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCreateFormat.Name = "buttonCreateFormat";
            this.buttonCreateFormat.Size = new System.Drawing.Size(63, 28);
            this.buttonCreateFormat.TabIndex = 15;
            this.buttonCreateFormat.Text = "Crear";
            this.buttonCreateFormat.UseVisualStyleBackColor = false;
            this.buttonCreateFormat.Click += new System.EventHandler(this.buttonCreateFormat_Click);
            // 
            // comboBoxAttributeValue
            // 
            this.comboBoxAttributeValue.FormattingEnabled = true;
            this.comboBoxAttributeValue.Location = new System.Drawing.Point(138, 159);
            this.comboBoxAttributeValue.Name = "comboBoxAttributeValue";
            this.comboBoxAttributeValue.Size = new System.Drawing.Size(233, 21);
            this.comboBoxAttributeValue.TabIndex = 27;
            // 
            // ModifyStyle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxAttributeValue);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.buttonDeleteStyle);
            this.Controls.Add(this.labelAddedStyles);
            this.Controls.Add(this.textBoxStyleName);
            this.Controls.Add(this.buttonAddAStyle);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.listBoxAttributesToAdd);
            this.Controls.Add(this.labelStylesToAdd1);
            this.Controls.Add(this.labelFormatName);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonCreateFormat);
            this.Name = "ModifyStyle";
            this.Size = new System.Drawing.Size(482, 447);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Button buttonDeleteStyle;
        private System.Windows.Forms.Label labelAddedStyles;
        private System.Windows.Forms.TextBox textBoxStyleName;
        private System.Windows.Forms.Button buttonAddAStyle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ListBox listBoxAttributesToAdd;
        private System.Windows.Forms.Label labelStylesToAdd1;
        private System.Windows.Forms.Label labelFormatName;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonCreateFormat;
        private System.Windows.Forms.ComboBox comboBoxAttributeValue;
    }
}
