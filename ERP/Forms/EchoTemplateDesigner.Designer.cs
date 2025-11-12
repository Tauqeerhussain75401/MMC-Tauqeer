namespace ERP.Forms
{
    partial class EchoTemplateDesigner
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EchoTemplateDesigner));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.txtNewTemplate = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbTemplate = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnLoadTemplate = new System.Windows.Forms.Button();
            this.btnItalic = new System.Windows.Forms.Button();
            this.btnUnderline = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnCentre = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnFontStyle = new System.Windows.Forms.Button();
            this.btnFontColor = new System.Windows.Forms.Button();
            this.btnBold = new System.Windows.Forms.Button();
            this.rtxtDoc = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Location = new System.Drawing.Point(25, 119);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 46);
            this.panel1.TabIndex = 239;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(219, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 36);
            this.btnClose.TabIndex = 163;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(113, 4);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 36);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Location = new System.Drawing.Point(7, 4);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(97, 36);
            this.btnNew.TabIndex = 161;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label17.Location = new System.Drawing.Point(430, 20);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(625, 73);
            this.label17.TabIndex = 238;
            this.label17.Text = "Echo Template Designer";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNewTemplate
            // 
            this.txtNewTemplate.Location = new System.Drawing.Point(828, 144);
            this.txtNewTemplate.Margin = new System.Windows.Forms.Padding(5);
            this.txtNewTemplate.Name = "txtNewTemplate";
            this.txtNewTemplate.Size = new System.Drawing.Size(428, 22);
            this.txtNewTemplate.TabIndex = 236;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(602, 145);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(195, 25);
            this.label11.TabIndex = 237;
            this.label11.Text = "New Template Name";
            // 
            // cmbTemplate
            // 
            this.cmbTemplate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbTemplate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTemplate.FormattingEnabled = true;
            this.cmbTemplate.Location = new System.Drawing.Point(828, 178);
            this.cmbTemplate.Margin = new System.Windows.Forms.Padding(5);
            this.cmbTemplate.Name = "cmbTemplate";
            this.cmbTemplate.Size = new System.Drawing.Size(428, 24);
            this.cmbTemplate.TabIndex = 233;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(716, 178);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 25);
            this.label10.TabIndex = 234;
            this.label10.Text = "Template";
            // 
            // btnLoadTemplate
            // 
            this.btnLoadTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadTemplate.Location = new System.Drawing.Point(1266, 172);
            this.btnLoadTemplate.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadTemplate.Name = "btnLoadTemplate";
            this.btnLoadTemplate.Size = new System.Drawing.Size(101, 37);
            this.btnLoadTemplate.TabIndex = 235;
            this.btnLoadTemplate.Text = "Load";
            this.btnLoadTemplate.UseVisualStyleBackColor = true;
            this.btnLoadTemplate.Click += new System.EventHandler(this.btnLoadTemplate_Click);
            // 
            // btnItalic
            // 
            this.btnItalic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItalic.Location = new System.Drawing.Point(72, 173);
            this.btnItalic.Margin = new System.Windows.Forms.Padding(4);
            this.btnItalic.Name = "btnItalic";
            this.btnItalic.Size = new System.Drawing.Size(53, 43);
            this.btnItalic.TabIndex = 226;
            this.btnItalic.TabStop = false;
            this.btnItalic.Text = "I";
            this.btnItalic.UseVisualStyleBackColor = true;
            this.btnItalic.Click += new System.EventHandler(this.btnItalic_Click);
            // 
            // btnUnderline
            // 
            this.btnUnderline.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnderline.Location = new System.Drawing.Point(125, 173);
            this.btnUnderline.Margin = new System.Windows.Forms.Padding(4);
            this.btnUnderline.Name = "btnUnderline";
            this.btnUnderline.Size = new System.Drawing.Size(53, 43);
            this.btnUnderline.TabIndex = 227;
            this.btnUnderline.TabStop = false;
            this.btnUnderline.Text = "U";
            this.btnUnderline.UseVisualStyleBackColor = true;
            this.btnUnderline.Click += new System.EventHandler(this.btnUnderline_Click);
            // 
            // btnRight
            // 
            this.btnRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRight.BackgroundImage")));
            this.btnRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRight.Location = new System.Drawing.Point(478, 173);
            this.btnRight.Margin = new System.Windows.Forms.Padding(4);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(53, 43);
            this.btnRight.TabIndex = 232;
            this.btnRight.TabStop = false;
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnCentre
            // 
            this.btnCentre.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCentre.BackgroundImage")));
            this.btnCentre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCentre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCentre.Location = new System.Drawing.Point(425, 173);
            this.btnCentre.Margin = new System.Windows.Forms.Padding(4);
            this.btnCentre.Name = "btnCentre";
            this.btnCentre.Size = new System.Drawing.Size(53, 43);
            this.btnCentre.TabIndex = 231;
            this.btnCentre.TabStop = false;
            this.btnCentre.UseVisualStyleBackColor = true;
            this.btnCentre.Click += new System.EventHandler(this.btnCentre_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLeft.BackgroundImage")));
            this.btnLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeft.Location = new System.Drawing.Point(372, 173);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(4);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(53, 43);
            this.btnLeft.TabIndex = 230;
            this.btnLeft.TabStop = false;
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnFontStyle
            // 
            this.btnFontStyle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFontStyle.BackgroundImage")));
            this.btnFontStyle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFontStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFontStyle.Location = new System.Drawing.Point(297, 173);
            this.btnFontStyle.Margin = new System.Windows.Forms.Padding(4);
            this.btnFontStyle.Name = "btnFontStyle";
            this.btnFontStyle.Size = new System.Drawing.Size(53, 43);
            this.btnFontStyle.TabIndex = 229;
            this.btnFontStyle.TabStop = false;
            this.btnFontStyle.UseVisualStyleBackColor = true;
            this.btnFontStyle.Click += new System.EventHandler(this.btnFontStyle_Click);
            // 
            // btnFontColor
            // 
            this.btnFontColor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFontColor.BackgroundImage")));
            this.btnFontColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFontColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFontColor.Location = new System.Drawing.Point(244, 173);
            this.btnFontColor.Margin = new System.Windows.Forms.Padding(4);
            this.btnFontColor.Name = "btnFontColor";
            this.btnFontColor.Size = new System.Drawing.Size(53, 43);
            this.btnFontColor.TabIndex = 228;
            this.btnFontColor.TabStop = false;
            this.btnFontColor.UseVisualStyleBackColor = true;
            this.btnFontColor.Click += new System.EventHandler(this.btnFontColor_Click);
            // 
            // btnBold
            // 
            this.btnBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBold.Location = new System.Drawing.Point(19, 173);
            this.btnBold.Margin = new System.Windows.Forms.Padding(4);
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(53, 43);
            this.btnBold.TabIndex = 240;
            this.btnBold.TabStop = false;
            this.btnBold.Text = "B";
            this.btnBold.UseVisualStyleBackColor = true;
            this.btnBold.Click += new System.EventHandler(this.btnBold_Click);
            // 
            // rtxtDoc
            // 
            this.rtxtDoc.AcceptsTab = true;
            this.rtxtDoc.AutoWordSelection = true;
            this.rtxtDoc.EnableAutoDragDrop = true;
            this.rtxtDoc.ImeMode = System.Windows.Forms.ImeMode.On;
            this.rtxtDoc.Location = new System.Drawing.Point(19, 238);
            this.rtxtDoc.Margin = new System.Windows.Forms.Padding(4);
            this.rtxtDoc.Name = "rtxtDoc";
            this.rtxtDoc.ShowSelectionMargin = true;
            this.rtxtDoc.Size = new System.Drawing.Size(1368, 759);
            this.rtxtDoc.TabIndex = 241;
            this.rtxtDoc.Text = "";
            // 
            // EchoTemplateDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 1010);
            this.Controls.Add(this.rtxtDoc);
            this.Controls.Add(this.btnBold);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtNewTemplate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbTemplate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnLoadTemplate);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnItalic);
            this.Controls.Add(this.btnCentre);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnFontStyle);
            this.Controls.Add(this.btnFontColor);
            this.Controls.Add(this.btnUnderline);
            this.Name = "EchoTemplateDesigner";
            this.Text = "EchoTemplateDesigner";
            this.Load += new System.EventHandler(this.EchoTemplateDesigner_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtNewTemplate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbTemplate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnLoadTemplate;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnItalic;
        private System.Windows.Forms.Button btnCentre;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnFontStyle;
        private System.Windows.Forms.Button btnFontColor;
        private System.Windows.Forms.Button btnUnderline;
        private System.Windows.Forms.Button btnBold;
        private System.Windows.Forms.RichTextBox rtxtDoc;
    }
}