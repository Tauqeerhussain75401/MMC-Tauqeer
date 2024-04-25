namespace ERP.Forms
{
    partial class frmCurrentCashStatus
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ntxtCurrentCash = new System.Windows.Forms.NumericUpDown();
            this.ntxtOPD = new System.Windows.Forms.NumericUpDown();
            this.ntxtTotalIPD = new System.Windows.Forms.NumericUpDown();
            this.ntxtRefundAmount = new System.Windows.Forms.NumericUpDown();
            this.ntxtAdvAmount = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtCurrentCash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtOPD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtTotalIPD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtRefundAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtAdvAmount)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 47);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Cash Status";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ntxtCurrentCash);
            this.panel2.Controls.Add(this.ntxtOPD);
            this.panel2.Controls.Add(this.ntxtTotalIPD);
            this.panel2.Controls.Add(this.ntxtRefundAmount);
            this.panel2.Controls.Add(this.ntxtAdvAmount);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(475, 234);
            this.panel2.TabIndex = 1;
            // 
            // ntxtCurrentCash
            // 
            this.ntxtCurrentCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntxtCurrentCash.Location = new System.Drawing.Point(339, 20);
            this.ntxtCurrentCash.Maximum = new decimal(new int[] {
            -402653184,
            -1613725636,
            54210108,
            0});
            this.ntxtCurrentCash.Name = "ntxtCurrentCash";
            this.ntxtCurrentCash.ReadOnly = true;
            this.ntxtCurrentCash.Size = new System.Drawing.Size(120, 23);
            this.ntxtCurrentCash.TabIndex = 9;
            this.ntxtCurrentCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntxtCurrentCash.Visible = false;
            // 
            // ntxtOPD
            // 
            this.ntxtOPD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntxtOPD.Location = new System.Drawing.Point(114, 121);
            this.ntxtOPD.Maximum = new decimal(new int[] {
            -402653184,
            -1613725636,
            54210108,
            0});
            this.ntxtOPD.Name = "ntxtOPD";
            this.ntxtOPD.ReadOnly = true;
            this.ntxtOPD.Size = new System.Drawing.Size(120, 23);
            this.ntxtOPD.TabIndex = 8;
            this.ntxtOPD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ntxtTotalIPD
            // 
            this.ntxtTotalIPD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntxtTotalIPD.Location = new System.Drawing.Point(114, 86);
            this.ntxtTotalIPD.Maximum = new decimal(new int[] {
            -402653184,
            -1613725636,
            54210108,
            0});
            this.ntxtTotalIPD.Name = "ntxtTotalIPD";
            this.ntxtTotalIPD.ReadOnly = true;
            this.ntxtTotalIPD.Size = new System.Drawing.Size(120, 23);
            this.ntxtTotalIPD.TabIndex = 7;
            this.ntxtTotalIPD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ntxtRefundAmount
            // 
            this.ntxtRefundAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntxtRefundAmount.Location = new System.Drawing.Point(114, 49);
            this.ntxtRefundAmount.Maximum = new decimal(new int[] {
            -402653184,
            -1613725636,
            54210108,
            0});
            this.ntxtRefundAmount.Name = "ntxtRefundAmount";
            this.ntxtRefundAmount.ReadOnly = true;
            this.ntxtRefundAmount.Size = new System.Drawing.Size(120, 23);
            this.ntxtRefundAmount.TabIndex = 6;
            this.ntxtRefundAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ntxtAdvAmount
            // 
            this.ntxtAdvAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntxtAdvAmount.Location = new System.Drawing.Point(114, 15);
            this.ntxtAdvAmount.Maximum = new decimal(new int[] {
            -402653184,
            -1613725636,
            54210108,
            0});
            this.ntxtAdvAmount.Name = "ntxtAdvAmount";
            this.ntxtAdvAmount.ReadOnly = true;
            this.ntxtAdvAmount.Size = new System.Drawing.Size(120, 23);
            this.ntxtAdvAmount.TabIndex = 5;
            this.ntxtAdvAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(237, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Current Cash";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "OPD";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total IPD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Refund Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Advance Receipt";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 206);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(475, 75);
            this.panel3.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(475, 69);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(163, 14);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 43);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(62, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 43);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmCurrentCashStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 281);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmCurrentCashStatus";
            this.Text = "frmCurrentCashStatus";
            this.Load += new System.EventHandler(this.frmCurrentCashStatus_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtCurrentCash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtOPD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtTotalIPD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtRefundAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtAdvAmount)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown ntxtCurrentCash;
        private System.Windows.Forms.NumericUpDown ntxtOPD;
        private System.Windows.Forms.NumericUpDown ntxtTotalIPD;
        private System.Windows.Forms.NumericUpDown ntxtRefundAmount;
        private System.Windows.Forms.NumericUpDown ntxtAdvAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRefresh;
    }
}