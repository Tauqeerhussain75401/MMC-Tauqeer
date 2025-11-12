namespace ERP.Forms
{
    partial class frmSearchHisByContactNo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchHisByContactNo));
            this.dgvQuery = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTokenNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnVoucherNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnOPDCatagory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnConsultant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPatientType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnCreatedby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnEditby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuery)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvQuery
            // 
            this.dgvQuery.AllowUserToAddRows = false;
            this.dgvQuery.AllowUserToDeleteRows = false;
            this.dgvQuery.AllowUserToOrderColumns = true;
            this.dgvQuery.AllowUserToResizeColumns = false;
            this.dgvQuery.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dgvQuery.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQuery.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuery.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnTokenNo,
            this.clnVoucherNum,
            this.clnDate,
            this.clnOPDCatagory,
            this.clnConsultant,
            this.clnPatientType,
            this.clnPatientName,
            this.dataGridViewTextBoxColumn8,
            this.ClnCreatedby,
            this.clnEditby});
            this.dgvQuery.Location = new System.Drawing.Point(4, 13);
            this.dgvQuery.Margin = new System.Windows.Forms.Padding(4);
            this.dgvQuery.MultiSelect = false;
            this.dgvQuery.Name = "dgvQuery";
            this.dgvQuery.ReadOnly = true;
            this.dgvQuery.RowHeadersWidth = 30;
            this.dgvQuery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuery.Size = new System.Drawing.Size(847, 410);
            this.dgvQuery.TabIndex = 165;
            this.dgvQuery.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuery_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Token No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Voucher #";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle4.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn3.FillWeight = 50F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Date";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 110;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.Width = 110;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Catagory";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Consultant";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Patient Type";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "PatientName";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn8.FillWeight = 50F;
            this.dataGridViewTextBoxColumn8.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 120;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Created By";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 180;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 180;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Edit By";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 180;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 180;
            // 
            // clnTokenNo
            // 
            this.clnTokenNo.HeaderText = "Token No";
            this.clnTokenNo.Name = "clnTokenNo";
            this.clnTokenNo.ReadOnly = true;
            // 
            // clnVoucherNum
            // 
            this.clnVoucherNum.HeaderText = "Voucher #";
            this.clnVoucherNum.Name = "clnVoucherNum";
            this.clnVoucherNum.ReadOnly = true;
            // 
            // clnDate
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle2.NullValue = null;
            this.clnDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.clnDate.FillWeight = 50F;
            this.clnDate.HeaderText = "Date";
            this.clnDate.MinimumWidth = 110;
            this.clnDate.Name = "clnDate";
            this.clnDate.ReadOnly = true;
            this.clnDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clnDate.Width = 110;
            // 
            // clnOPDCatagory
            // 
            this.clnOPDCatagory.HeaderText = "Catagory";
            this.clnOPDCatagory.Name = "clnOPDCatagory";
            this.clnOPDCatagory.ReadOnly = true;
            // 
            // clnConsultant
            // 
            this.clnConsultant.HeaderText = "Consultant";
            this.clnConsultant.Name = "clnConsultant";
            this.clnConsultant.ReadOnly = true;
            // 
            // clnPatientType
            // 
            this.clnPatientType.HeaderText = "Patient Type";
            this.clnPatientType.Name = "clnPatientType";
            this.clnPatientType.ReadOnly = true;
            // 
            // clnPatientName
            // 
            this.clnPatientName.HeaderText = "PatientName";
            this.clnPatientName.Name = "clnPatientName";
            this.clnPatientName.ReadOnly = true;
            // 
            // ClnCreatedby
            // 
            this.ClnCreatedby.HeaderText = "Created By";
            this.ClnCreatedby.MinimumWidth = 180;
            this.ClnCreatedby.Name = "ClnCreatedby";
            this.ClnCreatedby.ReadOnly = true;
            this.ClnCreatedby.Width = 180;
            // 
            // clnEditby
            // 
            this.clnEditby.HeaderText = "Edit By";
            this.clnEditby.MinimumWidth = 180;
            this.clnEditby.Name = "clnEditby";
            this.clnEditby.ReadOnly = true;
            this.clnEditby.Width = 180;
            // 
            // frmSearchHisByContactNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 432);
            this.Controls.Add(this.dgvQuery);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSearchHisByContactNo";
            this.Text = "Search History By Contact No";
            this.Load += new System.EventHandler(this.frmSearchHisByContactNo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuery)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn clnTokenNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnVoucherNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnOPDCatagory;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnConsultant;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPatientType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnCreatedby;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnEditby;
        public System.Windows.Forms.DataGridView dgvQuery;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
    }
}