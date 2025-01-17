﻿namespace DocumentsManager.WinApp.Controls
{
    partial class StyleCreator
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.comboBoxAttributeValue = new System.Windows.Forms.ComboBox();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.buttonDeleteStyle = new System.Windows.Forms.Button();
            this.labelAddedStyles = new System.Windows.Forms.Label();
            this.textBoxStyleName = new System.Windows.Forms.TextBox();
            this.buttonAddAStyle = new System.Windows.Forms.Button();
            this.listBoxAttributesToAdd = new System.Windows.Forms.ListBox();
            this.labelStylesToAdd1 = new System.Windows.Forms.Label();
            this.labelFormatName = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonCreateFormat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxBasedOn = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelTitle.Location = new System.Drawing.Point(247, 15);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(128, 24);
            this.labelTitle.TabIndex = 6;
            this.labelTitle.Text = "Agregar Estilo";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.comboBoxBasedOn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numericUpDown);
            this.panel1.Controls.Add(this.comboBoxAttributeValue);
            this.panel1.Controls.Add(this.comboBox);
            this.panel1.Controls.Add(this.buttonDeleteStyle);
            this.panel1.Controls.Add(this.labelAddedStyles);
            this.panel1.Controls.Add(this.textBoxStyleName);
            this.panel1.Controls.Add(this.buttonAddAStyle);
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Controls.Add(this.listBoxAttributesToAdd);
            this.panel1.Controls.Add(this.labelStylesToAdd1);
            this.panel1.Controls.Add(this.labelFormatName);
            this.panel1.Controls.Add(this.buttonBack);
            this.panel1.Controls.Add(this.buttonCreateFormat);
            this.panel1.Location = new System.Drawing.Point(2, 7);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(627, 462);
            this.panel1.TabIndex = 1;
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(134, 190);
            this.numericUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(454, 20);
            this.numericUpDown.TabIndex = 14;
            this.numericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // comboBoxAttributeValue
            // 
            this.comboBoxAttributeValue.FormattingEnabled = true;
            this.comboBoxAttributeValue.Location = new System.Drawing.Point(134, 189);
            this.comboBoxAttributeValue.Name = "comboBoxAttributeValue";
            this.comboBoxAttributeValue.Size = new System.Drawing.Size(454, 21);
            this.comboBoxAttributeValue.TabIndex = 13;
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(134, 144);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(454, 21);
            this.comboBox.TabIndex = 12;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // buttonDeleteStyle
            // 
            this.buttonDeleteStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonDeleteStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.buttonDeleteStyle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonDeleteStyle.Location = new System.Drawing.Point(134, 219);
            this.buttonDeleteStyle.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDeleteStyle.Name = "buttonDeleteStyle";
            this.buttonDeleteStyle.Size = new System.Drawing.Size(46, 36);
            this.buttonDeleteStyle.TabIndex = 11;
            this.buttonDeleteStyle.Text = "▲";
            this.buttonDeleteStyle.UseVisualStyleBackColor = false;
            this.buttonDeleteStyle.Click += new System.EventHandler(this.buttonDeleteStyle_Click);
            // 
            // labelAddedStyles
            // 
            this.labelAddedStyles.AutoSize = true;
            this.labelAddedStyles.Location = new System.Drawing.Point(22, 310);
            this.labelAddedStyles.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAddedStyles.Name = "labelAddedStyles";
            this.labelAddedStyles.Size = new System.Drawing.Size(104, 13);
            this.labelAddedStyles.TabIndex = 9;
            this.labelAddedStyles.Text = "Atributos agregados:";
            // 
            // textBoxStyleName
            // 
            this.textBoxStyleName.Location = new System.Drawing.Point(134, 61);
            this.textBoxStyleName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxStyleName.Name = "textBoxStyleName";
            this.textBoxStyleName.Size = new System.Drawing.Size(454, 20);
            this.textBoxStyleName.TabIndex = 8;
            // 
            // buttonAddAStyle
            // 
            this.buttonAddAStyle.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonAddAStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.buttonAddAStyle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonAddAStyle.Location = new System.Drawing.Point(542, 219);
            this.buttonAddAStyle.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddAStyle.Name = "buttonAddAStyle";
            this.buttonAddAStyle.Size = new System.Drawing.Size(46, 36);
            this.buttonAddAStyle.TabIndex = 7;
            this.buttonAddAStyle.Text = "▼";
            this.buttonAddAStyle.UseVisualStyleBackColor = false;
            this.buttonAddAStyle.Click += new System.EventHandler(this.buttonAddAStyle_Click);
            // 
            // listBoxAttributesToAdd
            // 
            this.listBoxAttributesToAdd.FormattingEnabled = true;
            this.listBoxAttributesToAdd.Location = new System.Drawing.Point(134, 268);
            this.listBoxAttributesToAdd.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxAttributesToAdd.Name = "listBoxAttributesToAdd";
            this.listBoxAttributesToAdd.Size = new System.Drawing.Size(454, 121);
            this.listBoxAttributesToAdd.TabIndex = 5;
            // 
            // labelStylesToAdd1
            // 
            this.labelStylesToAdd1.AutoSize = true;
            this.labelStylesToAdd1.Location = new System.Drawing.Point(22, 147);
            this.labelStylesToAdd1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStylesToAdd1.Name = "labelStylesToAdd1";
            this.labelStylesToAdd1.Size = new System.Drawing.Size(79, 13);
            this.labelStylesToAdd1.TabIndex = 3;
            this.labelStylesToAdd1.Text = "Añadir Atributo:";
            // 
            // labelFormatName
            // 
            this.labelFormatName.AutoSize = true;
            this.labelFormatName.Location = new System.Drawing.Point(22, 63);
            this.labelFormatName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFormatName.Name = "labelFormatName";
            this.labelFormatName.Size = new System.Drawing.Size(92, 13);
            this.labelFormatName.TabIndex = 2;
            this.labelFormatName.Text = "Nombre del Estilo:";
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonBack.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonBack.Location = new System.Drawing.Point(2, 427);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(61, 28);
            this.buttonBack.TabIndex = 1;
            this.buttonBack.Text = "Volver";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonCreateFormat
            // 
            this.buttonCreateFormat.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonCreateFormat.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonCreateFormat.Location = new System.Drawing.Point(555, 427);
            this.buttonCreateFormat.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCreateFormat.Name = "buttonCreateFormat";
            this.buttonCreateFormat.Size = new System.Drawing.Size(63, 28);
            this.buttonCreateFormat.TabIndex = 0;
            this.buttonCreateFormat.Text = "Crear";
            this.buttonCreateFormat.UseVisualStyleBackColor = false;
            this.buttonCreateFormat.Click += new System.EventHandler(this.buttonCreateFormat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 108);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Basado en:";
            // 
            // comboBoxBasedOn
            // 
            this.comboBoxBasedOn.FormattingEnabled = true;
            this.comboBoxBasedOn.Location = new System.Drawing.Point(134, 105);
            this.comboBoxBasedOn.Name = "comboBoxBasedOn";
            this.comboBoxBasedOn.Size = new System.Drawing.Size(384, 21);
            this.comboBoxBasedOn.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(529, 99);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 28);
            this.button1.TabIndex = 17;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StyleCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Name = "StyleCreator";
            this.Size = new System.Drawing.Size(627, 462);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDeleteStyle;
        private System.Windows.Forms.Label labelAddedStyles;
        private System.Windows.Forms.TextBox textBoxStyleName;
        private System.Windows.Forms.Button buttonAddAStyle;
        private System.Windows.Forms.ListBox listBoxAttributesToAdd;
        private System.Windows.Forms.Label labelStylesToAdd1;
        private System.Windows.Forms.Label labelFormatName;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonCreateFormat;
        private System.Windows.Forms.ComboBox comboBoxAttributeValue;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.ComboBox comboBoxBasedOn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}
