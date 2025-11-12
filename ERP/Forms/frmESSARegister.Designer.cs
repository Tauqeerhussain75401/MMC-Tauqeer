namespace ERP.Forms
{
    partial class frmESSARegister
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvExpenses = new System.Windows.Forms.DataGridView();
            this.clnSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnReceiptNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnReceiptDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnContact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbRangeWise = new System.Windows.Forms.RadioButton();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.dtpFDate = new System.Windows.Forms.DateTimePicker();
            this.dtpTDate = new System.Windows.Forms.DateTimePicker();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbIOstatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvExpenses
            // 
            this.dgvExpenses.AllowUserToAddRows = false;
            this.dgvExpenses.AllowUserToDeleteRows = false;
            this.dgvExpenses.AllowUserToOrderColumns = true;
            this.dgvExpenses.AllowUserToResizeColumns = false;
            this.dgvExpenses.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExpenses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvExpenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpenses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnSelect,
            this.clnStatus,
            this.clnReceiptNo,
            this.clnIO,
            this.clnReceiptDate,
            this.clnPatientName,
            this.clnAge,
            this.clnTest,
            this.clnContact});
            this.dgvExpenses.Location = new System.Drawing.Point(13, 126);
            this.dgvExpenses.Margin = new System.Windows.Forms.Padding(4);
            this.dgvExpenses.MultiSelect = false;
            this.dgvExpenses.Name = "dgvExpenses";
            this.dgvExpenses.RowHeadersVisible = false;
            this.dgvExpenses.RowHeadersWidth = 30;
            this.dgvExpenses.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvExpenses.RowTemplate.Height = 25;
            this.dgvExpenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvExpenses.Size = new System.Drawing.Size(1222, 489);
            this.dgvExpenses.TabIndex = 2;
            // 
            // clnSelect
            // 
            this.clnSelect.HeaderText = "Select";
            this.clnSelect.MinimumWidth = 70;
            this.clnSelect.Name = "clnSelect";
            this.clnSelect.Width = 70;
            // 
            // clnStatus
            // 
            this.clnStatus.HeaderText = "Status";
            this.clnStatus.MinimumWidth = 100;
            this.clnStatus.Name = "clnStatus";
            this.clnStatus.ReadOnly = true;
            // 
            // clnReceiptNo
            // 
            this.clnReceiptNo.HeaderText = "Receipt No";
            this.clnReceiptNo.MinimumWidth = 70;
            this.clnReceiptNo.Name = "clnReceiptNo";
            this.clnReceiptNo.ReadOnly = true;
            this.clnReceiptNo.Width = 70;
            // 
            // clnIO
            // 
            this.clnIO.HeaderText = "I/O";
            this.clnIO.MinimumWidth = 50;
            this.clnIO.Name = "clnIO";
            this.clnIO.ReadOnly = true;
            this.clnIO.Width = 50;
            // 
            // clnReceiptDate
            // 
            this.clnReceiptDate.HeaderText = "Receipt Date";
            this.clnReceiptDate.MinimumWidth = 130;
            this.clnReceiptDate.Name = "clnReceiptDate";
            this.clnReceiptDate.ReadOnly = true;
            this.clnReceiptDate.Width = 130;
            // 
            // clnPatientName
            // 
            this.clnPatientName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clnPatientName.FillWeight = 70F;
            this.clnPatientName.HeaderText = "Patient Name";
            this.clnPatientName.MinimumWidth = 150;
            this.clnPatientName.Name = "clnPatientName";
            this.clnPatientName.ReadOnly = true;
            // 
            // clnAge
            // 
            this.clnAge.HeaderText = "Age";
            this.clnAge.MinimumWidth = 100;
            this.clnAge.Name = "clnAge";
            this.clnAge.ReadOnly = true;
            // 
            // clnTest
            // 
            this.clnTest.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clnTest.HeaderText = "Test";
            this.clnTest.MinimumWidth = 200;
            this.clnTest.Name = "clnTest";
            this.clnTest.ReadOnly = true;
            this.clnTest.Width = 200;
            // 
            // clnContact
            // 
            this.clnContact.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clnContact.HeaderText = "Contact No";
            this.clnContact.MinimumWidth = 120;
            this.clnContact.Name = "clnContact";
            this.clnContact.ReadOnly = true;
            this.clnContact.Width = 120;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbIOstatus);
            this.groupBox1.Controls.Add(this.rdbRangeWise);
            this.groupBox1.Controls.Add(this.rdbAll);
            this.groupBox1.Controls.Add(this.dtpFDate);
            this.groupBox1.Controls.Add(this.dtpTDate);
            this.groupBox1.Controls.Add(this.cmbStatus);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 25);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1072, 68);
            this.groupBox1.TabIndex = 189;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // rdbRangeWise
            // 
            this.rdbRangeWise.AutoSize = true;
            this.rdbRangeWise.Checked = true;
            this.rdbRangeWise.Location = new System.Drawing.Point(81, 26);
            this.rdbRangeWise.Name = "rdbRangeWise";
            this.rdbRangeWise.Size = new System.Drawing.Size(101, 20);
            this.rdbRangeWise.TabIndex = 208;
            this.rdbRangeWise.TabStop = true;
            this.rdbRangeWise.Text = "Range Wise";
            this.rdbRangeWise.UseVisualStyleBackColor = true;
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Location = new System.Drawing.Point(17, 26);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(49, 20);
            this.rdbAll.TabIndex = 207;
            this.rdbAll.Text = "ALL";
            this.rdbAll.UseVisualStyleBackColor = true;
            // 
            // dtpFDate
            // 
            this.dtpFDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpFDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFDate.Location = new System.Drawing.Point(201, 25);
            this.dtpFDate.Name = "dtpFDate";
            this.dtpFDate.Size = new System.Drawing.Size(125, 22);
            this.dtpFDate.TabIndex = 206;
            // 
            // dtpTDate
            // 
            this.dtpTDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpTDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTDate.Location = new System.Drawing.Point(382, 25);
            this.dtpTDate.Name = "dtpTDate";
            this.dtpTDate.Size = new System.Drawing.Size(125, 22);
            this.dtpTDate.TabIndex = 205;
            // 
            // cmbStatus
            // 
            this.cmbStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "ALL",
            "SENT",
            "NOT SENT"});
            this.cmbStatus.Location = new System.Drawing.Point(591, 24);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(195, 24);
            this.cmbStatus.TabIndex = 203;
            this.cmbStatus.Tag = "Lock";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(523, 28);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(45, 16);
            this.label19.TabIndex = 204;
            this.label19.Text = "Status";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(344, 28);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 16);
            this.label6.TabIndex = 193;
            this.label6.Text = "To :";
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Location = new System.Drawing.Point(951, 19);
            this.btnFind.Margin = new System.Windows.Forms.Padding(4);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(85, 34);
            this.btnFind.TabIndex = 165;
            this.btnFind.Text = "&Find";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreview.Location = new System.Drawing.Point(13, 622);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(4);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(85, 34);
            this.btnPreview.TabIndex = 209;
            this.btnPreview.Text = "&Preview";
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Status";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Receipt No";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 70;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "I/O";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Receipt Date";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 130;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 130;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.FillWeight = 70F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Patient Name";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Age";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.HeaderText = "Test";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // cmbIOstatus
            // 
            this.cmbIOstatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbIOstatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbIOstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIOstatus.FormattingEnabled = true;
            this.cmbIOstatus.Items.AddRange(new object[] {
            "OPD",
            "IPD"});
            this.cmbIOstatus.Location = new System.Drawing.Point(864, 24);
            this.cmbIOstatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbIOstatus.Name = "cmbIOstatus";
            this.cmbIOstatus.Size = new System.Drawing.Size(58, 24);
            this.cmbIOstatus.TabIndex = 209;
            this.cmbIOstatus.Tag = "Lock";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(794, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 210;
            this.label1.Text = "OPD/IPD";
            // 
            // frmESSARegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 669);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvExpenses);
            this.Name = "frmESSARegister";
            this.Text = "ESSA Register";
            this.Load += new System.EventHandler(this.frmMasterRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvExpenses;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.DateTimePicker dtpFDate;
        private System.Windows.Forms.DateTimePicker dtpTDate;
        private System.Windows.Forms.RadioButton rdbRangeWise;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clnSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnReceiptNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnReceiptDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnContact;
        private System.Windows.Forms.ComboBox cmbIOstatus;
        private System.Windows.Forms.Label label1;
    }
}