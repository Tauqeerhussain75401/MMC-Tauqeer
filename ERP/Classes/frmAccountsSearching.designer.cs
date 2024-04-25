namespace ERP
{
    partial class frmAccountsSearching
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.rdoTradingAccount = new System.Windows.Forms.RadioButton();
            this.rdoGeneralAcc = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvClientCodeList = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientCodeList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 45);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtCode);
            this.panel2.Controls.Add(this.rdoTradingAccount);
            this.panel2.Controls.Add(this.rdoGeneralAcc);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(399, 91);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Client Code";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(88, 53);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(193, 20);
            this.txtCode.TabIndex = 3;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            // 
            // rdoTradingAccount
            // 
            this.rdoTradingAccount.AutoSize = true;
            this.rdoTradingAccount.Location = new System.Drawing.Point(125, 17);
            this.rdoTradingAccount.Name = "rdoTradingAccount";
            this.rdoTradingAccount.Size = new System.Drawing.Size(104, 17);
            this.rdoTradingAccount.TabIndex = 2;
            this.rdoTradingAccount.TabStop = true;
            this.rdoTradingAccount.Text = "Trading Account";
            this.rdoTradingAccount.UseVisualStyleBackColor = true;
            // 
            // rdoGeneralAcc
            // 
            this.rdoGeneralAcc.AutoSize = true;
            this.rdoGeneralAcc.Location = new System.Drawing.Point(18, 17);
            this.rdoGeneralAcc.Name = "rdoGeneralAcc";
            this.rdoGeneralAcc.Size = new System.Drawing.Size(105, 17);
            this.rdoGeneralAcc.TabIndex = 1;
            this.rdoGeneralAcc.TabStop = true;
            this.rdoGeneralAcc.Text = "General Account";
            this.rdoGeneralAcc.UseVisualStyleBackColor = true;
            this.rdoGeneralAcc.CheckedChanged += new System.EventHandler(this.rdoGeneralAcc_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvClientCodeList);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 136);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(399, 220);
            this.panel3.TabIndex = 2;
            // 
            // dgvClientCodeList
            // 
            this.dgvClientCodeList.AllowUserToAddRows = false;
            this.dgvClientCodeList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientCodeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClientCodeList.Location = new System.Drawing.Point(0, 0);
            this.dgvClientCodeList.Name = "dgvClientCodeList";
            this.dgvClientCodeList.ReadOnly = true;
            this.dgvClientCodeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientCodeList.Size = new System.Drawing.Size(399, 220);
            this.dgvClientCodeList.TabIndex = 0;
            this.dgvClientCodeList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientCodeList_CellDoubleClick);
            // 
            // frmAccountsSearching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 356);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmAccountsSearching";
            this.Text = "frmSearching";
            this.Load += new System.EventHandler(this.frmSearching_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientCodeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvClientCodeList;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.RadioButton rdoTradingAccount;
        public System.Windows.Forms.RadioButton rdoGeneralAcc;
    }
}