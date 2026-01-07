namespace ERP.Forms
{
    partial class frmHussainiReportEntry
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtRoom = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRegNo = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.DgvShortList = new System.Windows.Forms.DataGridView();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgvTestParameters = new System.Windows.Forms.DataGridView();
            this.clnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnApproxResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbIOstatus = new System.Windows.Forms.ComboBox();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.txtSlipNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRefBy = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSlipDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpIssueDate = new System.Windows.Forms.DateTimePicker();
            this.txtcontact = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReportNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvShortList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestParameters)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRoom
            // 
            this.txtRoom.Location = new System.Drawing.Point(78, 165);
            this.txtRoom.Margin = new System.Windows.Forms.Padding(4);
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.Size = new System.Drawing.Size(81, 20);
            this.txtRoom.TabIndex = 236;
            this.txtRoom.Tag = "Lock";
            this.txtRoom.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(16, 166);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 16);
            this.label14.TabIndex = 238;
            this.label14.Text = "Room #";
            this.label14.Visible = false;
            // 
            // txtRegNo
            // 
            this.txtRegNo.Location = new System.Drawing.Point(175, -15);
            this.txtRegNo.Name = "txtRegNo";
            this.txtRegNo.Size = new System.Drawing.Size(100, 22);
            this.txtRegNo.TabIndex = 237;
            this.txtRegNo.Visible = false;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(78, 548);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(4);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(903, 20);
            this.txtRemarks.TabIndex = 234;
            this.txtRemarks.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(16, 551);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 16);
            this.label11.TabIndex = 235;
            this.label11.Text = "Remarks :";
            // 
            // DgvShortList
            // 
            this.DgvShortList.AllowUserToAddRows = false;
            this.DgvShortList.AllowUserToDeleteRows = false;
            this.DgvShortList.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.DgvShortList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvShortList.Location = new System.Drawing.Point(281, 316);
            this.DgvShortList.Name = "DgvShortList";
            this.DgvShortList.ReadOnly = true;
            this.DgvShortList.Size = new System.Drawing.Size(526, 150);
            this.DgvShortList.TabIndex = 233;
            this.DgvShortList.Tag = "Lock";
            this.DgvShortList.Visible = false;
            // 
            // btnPreview
            // 
            this.btnPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(881, 156);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(93, 34);
            this.btnPreview.TabIndex = 232;
            this.btnPreview.Text = "Pre&view";
            this.btnPreview.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(782, 156);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(93, 34);
            this.btnPrint.TabIndex = 230;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // dgvTestParameters
            // 
            this.dgvTestParameters.AllowUserToAddRows = false;
            this.dgvTestParameters.AllowUserToDeleteRows = false;
            this.dgvTestParameters.AllowUserToOrderColumns = true;
            this.dgvTestParameters.AllowUserToResizeColumns = false;
            this.dgvTestParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTestParameters.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTestParameters.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvTestParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestParameters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnId,
            this.clnTitle,
            this.clnResult,
            this.clnUnit,
            this.clnApproxResult});
            this.dgvTestParameters.Location = new System.Drawing.Point(13, 197);
            this.dgvTestParameters.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTestParameters.MultiSelect = false;
            this.dgvTestParameters.Name = "dgvTestParameters";
            this.dgvTestParameters.RowHeadersWidth = 30;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTestParameters.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvTestParameters.RowTemplate.Height = 30;
            this.dgvTestParameters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvTestParameters.Size = new System.Drawing.Size(968, 342);
            this.dgvTestParameters.TabIndex = 228;
            // 
            // clnId
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clnId.DefaultCellStyle = dataGridViewCellStyle8;
            this.clnId.HeaderText = "ID";
            this.clnId.MinimumWidth = 120;
            this.clnId.Name = "clnId";
            this.clnId.ReadOnly = true;
            this.clnId.Visible = false;
            this.clnId.Width = 120;
            // 
            // clnTitle
            // 
            this.clnTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle9.NullValue = null;
            this.clnTitle.DefaultCellStyle = dataGridViewCellStyle9;
            this.clnTitle.FillWeight = 50F;
            this.clnTitle.HeaderText = "Title";
            this.clnTitle.MinimumWidth = 180;
            this.clnTitle.Name = "clnTitle";
            this.clnTitle.ReadOnly = true;
            this.clnTitle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // clnResult
            // 
            this.clnResult.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.clnResult.DefaultCellStyle = dataGridViewCellStyle10;
            this.clnResult.FillWeight = 50F;
            this.clnResult.HeaderText = "Result";
            this.clnResult.MinimumWidth = 180;
            this.clnResult.Name = "clnResult";
            // 
            // clnUnit
            // 
            this.clnUnit.HeaderText = "Unit";
            this.clnUnit.MinimumWidth = 80;
            this.clnUnit.Name = "clnUnit";
            this.clnUnit.ReadOnly = true;
            this.clnUnit.Width = 80;
            // 
            // clnApproxResult
            // 
            this.clnApproxResult.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clnApproxResult.DefaultCellStyle = dataGridViewCellStyle11;
            this.clnApproxResult.FillWeight = 50F;
            this.clnApproxResult.HeaderText = "Approx., Result";
            this.clnApproxResult.MinimumWidth = 180;
            this.clnApproxResult.Name = "clnApproxResult";
            this.clnApproxResult.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cmbLocation);
            this.groupBox1.Controls.Add(this.txtRegNo);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cmbIOstatus);
            this.groupBox1.Controls.Add(this.cmbDepartment);
            this.groupBox1.Controls.Add(this.txtSlipNo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtRefBy);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtSlipDate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.dtpIssueDate);
            this.groupBox1.Controls.Add(this.txtcontact);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtGender);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAge);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPatientName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtReportNo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 27);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(968, 118);
            this.groupBox1.TabIndex = 227;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Patient Info";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(405, 26);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 16);
            this.label12.TabIndex = 224;
            this.label12.Text = "Status";
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
            this.cmbIOstatus.Location = new System.Drawing.Point(463, 21);
            this.cmbIOstatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbIOstatus.Name = "cmbIOstatus";
            this.cmbIOstatus.Size = new System.Drawing.Size(50, 24);
            this.cmbIOstatus.TabIndex = 0;
            this.cmbIOstatus.Tag = "Lock";
            // 
            // cmbLocation
            // 
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(801, 83);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(160, 24);
            this.cmbLocation.TabIndex = 5;
            this.cmbLocation.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(735, 85);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 16);
            this.label10.TabIndex = 221;
            this.label10.Text = "Location";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(116, 83);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(281, 24);
            this.cmbDepartment.TabIndex = 3;
            this.cmbDepartment.Tag = "Lock";
            // 
            // txtSlipNo
            // 
            this.txtSlipNo.Location = new System.Drawing.Point(268, 22);
            this.txtSlipNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtSlipNo.Name = "txtSlipNo";
            this.txtSlipNo.Size = new System.Drawing.Size(129, 22);
            this.txtSlipNo.TabIndex = 1;
            this.txtSlipNo.Tag = "Lock";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(224, 26);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 16);
            this.label9.TabIndex = 219;
            this.label9.Text = "Slip #";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 86);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 16);
            this.label8.TabIndex = 217;
            this.label8.Text = "Department";
            // 
            // txtRefBy
            // 
            this.txtRefBy.Location = new System.Drawing.Point(463, 85);
            this.txtRefBy.Margin = new System.Windows.Forms.Padding(4);
            this.txtRefBy.Name = "txtRefBy";
            this.txtRefBy.Size = new System.Drawing.Size(256, 22);
            this.txtRefBy.TabIndex = 4;
            this.txtRefBy.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(405, 86);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 16);
            this.label7.TabIndex = 215;
            this.label7.Text = "Ref. By";
            // 
            // txtSlipDate
            // 
            this.txtSlipDate.Location = new System.Drawing.Point(801, 23);
            this.txtSlipDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtSlipDate.Name = "txtSlipDate";
            this.txtSlipDate.ReadOnly = true;
            this.txtSlipDate.Size = new System.Drawing.Size(160, 22);
            this.txtSlipDate.TabIndex = 2;
            this.txtSlipDate.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(731, 25);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 16);
            this.label6.TabIndex = 213;
            this.label6.Text = "Slip Date";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(519, 25);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 16);
            this.label13.TabIndex = 212;
            this.label13.Text = "Report Date";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dtpIssueDate
            // 
            this.dtpIssueDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpIssueDate.Enabled = false;
            this.dtpIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpIssueDate.Location = new System.Drawing.Point(606, 21);
            this.dtpIssueDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpIssueDate.Name = "dtpIssueDate";
            this.dtpIssueDate.Size = new System.Drawing.Size(113, 22);
            this.dtpIssueDate.TabIndex = 2;
            this.dtpIssueDate.TabStop = false;
            // 
            // txtcontact
            // 
            this.txtcontact.Location = new System.Drawing.Point(801, 53);
            this.txtcontact.Margin = new System.Windows.Forms.Padding(4);
            this.txtcontact.Name = "txtcontact";
            this.txtcontact.ReadOnly = true;
            this.txtcontact.Size = new System.Drawing.Size(160, 22);
            this.txtcontact.TabIndex = 6;
            this.txtcontact.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(741, 56);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 209;
            this.label5.Text = "Contact";
            // 
            // txtGender
            // 
            this.txtGender.Location = new System.Drawing.Point(611, 53);
            this.txtGender.Margin = new System.Windows.Forms.Padding(4);
            this.txtGender.Name = "txtGender";
            this.txtGender.ReadOnly = true;
            this.txtGender.Size = new System.Drawing.Size(108, 22);
            this.txtGender.TabIndex = 5;
            this.txtGender.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(548, 56);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 207;
            this.label3.Text = "Gender";
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(463, 52);
            this.txtAge.Margin = new System.Windows.Forms.Padding(4);
            this.txtAge.Name = "txtAge";
            this.txtAge.ReadOnly = true;
            this.txtAge.Size = new System.Drawing.Size(77, 22);
            this.txtAge.TabIndex = 4;
            this.txtAge.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(405, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 205;
            this.label2.Text = "Age";
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(116, 53);
            this.txtPatientName.Margin = new System.Windows.Forms.Padding(4);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.ReadOnly = true;
            this.txtPatientName.Size = new System.Drawing.Size(281, 22);
            this.txtPatientName.TabIndex = 3;
            this.txtPatientName.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 203;
            this.label1.Text = "Patient Name";
            // 
            // txtReportNo
            // 
            this.txtReportNo.Location = new System.Drawing.Point(116, 23);
            this.txtReportNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtReportNo.MaxLength = 10000000;
            this.txtReportNo.Name = "txtReportNo";
            this.txtReportNo.ReadOnly = true;
            this.txtReportNo.Size = new System.Drawing.Size(100, 22);
            this.txtReportNo.TabIndex = 202;
            this.txtReportNo.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 201;
            this.label4.Text = "Report #";
            // 
            // frmHussainiReportEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 587);
            this.Controls.Add(this.txtRoom);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.DgvShortList);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgvTestParameters);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmHussainiReportEntry";
            this.Text = "frmHussainiReportEntry";
            this.Load += new System.EventHandler(this.frmHussainiReportEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvShortList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestParameters)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtRegNo;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView DgvShortList;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dgvTestParameters;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnApproxResult;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbIOstatus;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.TextBox txtSlipNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRefBy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSlipDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpIssueDate;
        private System.Windows.Forms.TextBox txtcontact;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReportNo;
        private System.Windows.Forms.Label label4;
    }
}