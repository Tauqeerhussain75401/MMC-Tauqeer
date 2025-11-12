namespace ERP.Forms
{
    partial class frmVersionUpdater
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
            this.prgbar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLocation = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // prgbar
            // 
            this.prgbar.Location = new System.Drawing.Point(81, 65);
            this.prgbar.Name = "prgbar";
            this.prgbar.Size = new System.Drawing.Size(291, 22);
            this.prgbar.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Location :";
            // 
            // btnLocation
            // 
            this.btnLocation.Location = new System.Drawing.Point(432, 35);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Size = new System.Drawing.Size(25, 23);
            this.btnLocation.TabIndex = 11;
            this.btnLocation.Text = "...";
            this.btnLocation.UseVisualStyleBackColor = true;
            this.btnLocation.Click += new System.EventHandler(this.btnLocation_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(378, 64);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 12;
            this.btnLoad.Text = "&Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(81, 37);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.ReadOnly = true;
            this.txtLocation.Size = new System.Drawing.Size(345, 20);
            this.txtLocation.TabIndex = 10;
            // 
            // frmVersionUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 103);
            this.Controls.Add(this.prgbar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLocation);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtLocation);
            this.Name = "frmVersionUpdater";
            this.Text = "frmVersionUpdater";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar prgbar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLocation;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtLocation;
    }
}