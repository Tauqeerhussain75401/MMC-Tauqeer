namespace ERP.Forms
{
    partial class frmTestParameters
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbTest = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.grpInvoiceDetail = new System.Windows.Forms.GroupBox();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomHeading = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvTestParameters = new System.Windows.Forms.DataGridView();
            this.clnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnApproxResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnRangeNewBorn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnRange1MTo1Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnRange1yTo14y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnRange14YToAbove = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnIsHeading = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clnRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAppResult = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRangeNewBorn = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRange1Mto1Y = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRange14YToAbove = new System.Windows.Forms.TextBox();
            this.txtRange1Yto14Y = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtremarks = new System.Windows.Forms.TextBox();
            this.grpParam = new System.Windows.Forms.GroupBox();
            this.Delete = new System.Windows.Forms.Button();
            this.chkIsHeading = new System.Windows.Forms.CheckBox();
            this.btnNewParam = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
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
            this.grpInvoiceDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestParameters)).BeginInit();
            this.grpParam.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbTest
            // 
            this.cmbTest.AutoCompleteCustomSource.AddRange(new string[] {
            "Male",
            "Female"});
            this.cmbTest.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbTest.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTest.FormattingEnabled = true;
            this.cmbTest.Location = new System.Drawing.Point(68, 28);
            this.cmbTest.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTest.Name = "cmbTest";
            this.cmbTest.Size = new System.Drawing.Size(271, 24);
            this.cmbTest.TabIndex = 181;
            this.cmbTest.SelectedIndexChanged += new System.EventHandler(this.cmbUser_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(13, 32);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 16);
            this.label15.TabIndex = 182;
            this.label15.Text = "Test :";
            // 
            // grpInvoiceDetail
            // 
            this.grpInvoiceDetail.Controls.Add(this.txtDepartment);
            this.grpInvoiceDetail.Controls.Add(this.label1);
            this.grpInvoiceDetail.Controls.Add(this.txtCustomHeading);
            this.grpInvoiceDetail.Controls.Add(this.label8);
            this.grpInvoiceDetail.Controls.Add(this.cmbTest);
            this.grpInvoiceDetail.Controls.Add(this.label15);
            this.grpInvoiceDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInvoiceDetail.Location = new System.Drawing.Point(12, 18);
            this.grpInvoiceDetail.Name = "grpInvoiceDetail";
            this.grpInvoiceDetail.Size = new System.Drawing.Size(1167, 71);
            this.grpInvoiceDetail.TabIndex = 183;
            this.grpInvoiceDetail.TabStop = false;
            this.grpInvoiceDetail.Text = "Master Detail ";
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(854, 29);
            this.txtDepartment.Margin = new System.Windows.Forms.Padding(4);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(281, 22);
            this.txtDepartment.TabIndex = 220;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(760, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 221;
            this.label1.Text = "Department";
            // 
            // txtCustomHeading
            // 
            this.txtCustomHeading.Location = new System.Drawing.Point(469, 29);
            this.txtCustomHeading.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomHeading.Name = "txtCustomHeading";
            this.txtCustomHeading.Size = new System.Drawing.Size(281, 22);
            this.txtCustomHeading.TabIndex = 218;
            this.txtCustomHeading.TextChanged += new System.EventHandler(this.txtClinicalDiags_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(347, 32);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 16);
            this.label8.TabIndex = 219;
            this.label8.Text = "Custom Heading";
            // 
            // dgvTestParameters
            // 
            this.dgvTestParameters.AllowUserToAddRows = false;
            this.dgvTestParameters.AllowUserToDeleteRows = false;
            this.dgvTestParameters.AllowUserToOrderColumns = true;
            this.dgvTestParameters.AllowUserToResizeColumns = false;
            this.dgvTestParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTestParameters.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTestParameters.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTestParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestParameters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnId,
            this.clnTitle,
            this.clnApproxResult,
            this.clnRangeNewBorn,
            this.clnRange1MTo1Y,
            this.clnRange1yTo14y,
            this.clnRange14YToAbove,
            this.clnUnit,
            this.clnIsHeading,
            this.clnRemarks});
            this.dgvTestParameters.Location = new System.Drawing.Point(10, 205);
            this.dgvTestParameters.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTestParameters.MultiSelect = false;
            this.dgvTestParameters.Name = "dgvTestParameters";
            this.dgvTestParameters.ReadOnly = true;
            this.dgvTestParameters.RowHeadersWidth = 30;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTestParameters.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTestParameters.RowTemplate.Height = 30;
            this.dgvTestParameters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTestParameters.Size = new System.Drawing.Size(1264, 542);
            this.dgvTestParameters.TabIndex = 165;
            this.dgvTestParameters.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTestParameters_CellContentDoubleClick);
            this.dgvTestParameters.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTestParameters_CellDoubleClick);
            // 
            // clnId
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clnId.DefaultCellStyle = dataGridViewCellStyle2;
            this.clnId.HeaderText = "ID";
            this.clnId.MinimumWidth = 120;
            this.clnId.Name = "clnId";
            this.clnId.ReadOnly = true;
            this.clnId.Width = 120;
            // 
            // clnTitle
            // 
            this.clnTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle3.NullValue = null;
            this.clnTitle.DefaultCellStyle = dataGridViewCellStyle3;
            this.clnTitle.FillWeight = 50F;
            this.clnTitle.HeaderText = "Title";
            this.clnTitle.MinimumWidth = 110;
            this.clnTitle.Name = "clnTitle";
            this.clnTitle.ReadOnly = true;
            this.clnTitle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // clnApproxResult
            // 
            this.clnApproxResult.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clnApproxResult.DefaultCellStyle = dataGridViewCellStyle4;
            this.clnApproxResult.FillWeight = 50F;
            this.clnApproxResult.HeaderText = "Approx., Result";
            this.clnApproxResult.MinimumWidth = 110;
            this.clnApproxResult.Name = "clnApproxResult";
            this.clnApproxResult.ReadOnly = true;
            // 
            // clnRangeNewBorn
            // 
            this.clnRangeNewBorn.HeaderText = "Range New Born";
            this.clnRangeNewBorn.Name = "clnRangeNewBorn";
            this.clnRangeNewBorn.ReadOnly = true;
            // 
            // clnRange1MTo1Y
            // 
            this.clnRange1MTo1Y.HeaderText = "Range 1 Month to 1 Year";
            this.clnRange1MTo1Y.Name = "clnRange1MTo1Y";
            this.clnRange1MTo1Y.ReadOnly = true;
            // 
            // clnRange1yTo14y
            // 
            this.clnRange1yTo14y.HeaderText = "Range 1 Year To14 Year";
            this.clnRange1yTo14y.Name = "clnRange1yTo14y";
            this.clnRange1yTo14y.ReadOnly = true;
            // 
            // clnRange14YToAbove
            // 
            this.clnRange14YToAbove.HeaderText = "Range 14 Year To Above";
            this.clnRange14YToAbove.Name = "clnRange14YToAbove";
            this.clnRange14YToAbove.ReadOnly = true;
            // 
            // clnUnit
            // 
            this.clnUnit.HeaderText = "Unit";
            this.clnUnit.Name = "clnUnit";
            this.clnUnit.ReadOnly = true;
            // 
            // clnIsHeading
            // 
            this.clnIsHeading.HeaderText = "Is Heading";
            this.clnIsHeading.MinimumWidth = 70;
            this.clnIsHeading.Name = "clnIsHeading";
            this.clnIsHeading.ReadOnly = true;
            this.clnIsHeading.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clnIsHeading.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clnIsHeading.Width = 70;
            // 
            // clnRemarks
            // 
            this.clnRemarks.HeaderText = "Remarks";
            this.clnRemarks.Name = "clnRemarks";
            this.clnRemarks.ReadOnly = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(152, 65);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 25);
            this.btnSave.TabIndex = 184;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(172, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 185;
            this.label2.Text = "Title";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(217, 12);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(4);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(153, 20);
            this.txtTitle.TabIndex = 219;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(378, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 220;
            this.label3.Text = "Approx Result";
            // 
            // txtAppResult
            // 
            this.txtAppResult.Location = new System.Drawing.Point(487, 12);
            this.txtAppResult.Margin = new System.Windows.Forms.Padding(4);
            this.txtAppResult.Name = "txtAppResult";
            this.txtAppResult.Size = new System.Drawing.Size(153, 20);
            this.txtAppResult.TabIndex = 221;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(660, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 16);
            this.label4.TabIndex = 222;
            this.label4.Text = "Range New Born";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(939, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 16);
            this.label5.TabIndex = 223;
            this.label5.Text = "Range 1 Month to 1 Year";
            // 
            // txtRangeNewBorn
            // 
            this.txtRangeNewBorn.Location = new System.Drawing.Point(778, 12);
            this.txtRangeNewBorn.Margin = new System.Windows.Forms.Padding(4);
            this.txtRangeNewBorn.Name = "txtRangeNewBorn";
            this.txtRangeNewBorn.Size = new System.Drawing.Size(153, 20);
            this.txtRangeNewBorn.TabIndex = 224;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(638, 137);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 16);
            this.label6.TabIndex = 225;
            this.label6.Text = "Unit";
            // 
            // txtRange1Mto1Y
            // 
            this.txtRange1Mto1Y.Location = new System.Drawing.Point(1101, 12);
            this.txtRange1Mto1Y.Margin = new System.Windows.Forms.Padding(4);
            this.txtRange1Mto1Y.Name = "txtRange1Mto1Y";
            this.txtRange1Mto1Y.Size = new System.Drawing.Size(153, 20);
            this.txtRange1Mto1Y.TabIndex = 226;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(321, 42);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 16);
            this.label7.TabIndex = 227;
            this.label7.Text = "Range 14 Year to Above";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 42);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 16);
            this.label9.TabIndex = 228;
            this.label9.Text = "Range 1 Year to 14 Year";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(952, 43);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 16);
            this.label12.TabIndex = 231;
            this.label12.Text = "Remarks";
            // 
            // txtRange14YToAbove
            // 
            this.txtRange14YToAbove.Location = new System.Drawing.Point(480, 40);
            this.txtRange14YToAbove.Margin = new System.Windows.Forms.Padding(4);
            this.txtRange14YToAbove.Name = "txtRange14YToAbove";
            this.txtRange14YToAbove.Size = new System.Drawing.Size(146, 20);
            this.txtRange14YToAbove.TabIndex = 232;
            // 
            // txtRange1Yto14Y
            // 
            this.txtRange1Yto14Y.Location = new System.Drawing.Point(165, 40);
            this.txtRange1Yto14Y.Margin = new System.Windows.Forms.Padding(4);
            this.txtRange1Yto14Y.Name = "txtRange1Yto14Y";
            this.txtRange1Yto14Y.Size = new System.Drawing.Size(153, 20);
            this.txtRange1Yto14Y.TabIndex = 233;
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(670, 40);
            this.txtUnit.Margin = new System.Windows.Forms.Padding(4);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(153, 20);
            this.txtUnit.TabIndex = 234;
            // 
            // txtremarks
            // 
            this.txtremarks.Location = new System.Drawing.Point(1023, 41);
            this.txtremarks.Margin = new System.Windows.Forms.Padding(4);
            this.txtremarks.Name = "txtremarks";
            this.txtremarks.Size = new System.Drawing.Size(153, 20);
            this.txtremarks.TabIndex = 236;
            // 
            // grpParam
            // 
            this.grpParam.Controls.Add(this.Delete);
            this.grpParam.Controls.Add(this.chkIsHeading);
            this.grpParam.Controls.Add(this.btnSave);
            this.grpParam.Controls.Add(this.btnNewParam);
            this.grpParam.Controls.Add(this.label10);
            this.grpParam.Controls.Add(this.txtID);
            this.grpParam.Controls.Add(this.txtremarks);
            this.grpParam.Controls.Add(this.label2);
            this.grpParam.Controls.Add(this.txtTitle);
            this.grpParam.Controls.Add(this.txtUnit);
            this.grpParam.Controls.Add(this.label3);
            this.grpParam.Controls.Add(this.txtRange1Yto14Y);
            this.grpParam.Controls.Add(this.txtAppResult);
            this.grpParam.Controls.Add(this.txtRange14YToAbove);
            this.grpParam.Controls.Add(this.label4);
            this.grpParam.Controls.Add(this.label12);
            this.grpParam.Controls.Add(this.label5);
            this.grpParam.Controls.Add(this.txtRangeNewBorn);
            this.grpParam.Controls.Add(this.label9);
            this.grpParam.Controls.Add(this.txtRange1Mto1Y);
            this.grpParam.Controls.Add(this.label7);
            this.grpParam.Location = new System.Drawing.Point(12, 95);
            this.grpParam.Name = "grpParam";
            this.grpParam.Size = new System.Drawing.Size(1308, 97);
            this.grpParam.TabIndex = 237;
            this.grpParam.TabStop = false;
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(244, 66);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(86, 25);
            this.Delete.TabIndex = 241;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // chkIsHeading
            // 
            this.chkIsHeading.AutoSize = true;
            this.chkIsHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsHeading.Location = new System.Drawing.Point(837, 40);
            this.chkIsHeading.Name = "chkIsHeading";
            this.chkIsHeading.Size = new System.Drawing.Size(94, 21);
            this.chkIsHeading.TabIndex = 240;
            this.chkIsHeading.Text = "Is Heading";
            this.chkIsHeading.UseVisualStyleBackColor = true;
            // 
            // btnNewParam
            // 
            this.btnNewParam.Location = new System.Drawing.Point(10, 66);
            this.btnNewParam.Name = "btnNewParam";
            this.btnNewParam.Size = new System.Drawing.Size(136, 25);
            this.btnNewParam.TabIndex = 239;
            this.btnNewParam.Text = "New Parameters";
            this.btnNewParam.UseVisualStyleBackColor = true;
            this.btnNewParam.Click += new System.EventHandler(this.btnNewParam_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(11, 14);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 16);
            this.label10.TabIndex = 237;
            this.label10.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(56, 12);
            this.txtID.Margin = new System.Windows.Forms.Padding(4);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(105, 20);
            this.txtID.TabIndex = 238;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn1.HeaderText = "Voucher #";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 120;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn2.FillWeight = 50F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Date";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 110;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn3.FillWeight = 50F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Catagory";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 110;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Consultant";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Patient Type";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "PatientName";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 120;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Unit";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Edit By";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 180;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 180;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Remarks";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // frmTestParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 743);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.grpInvoiceDetail);
            this.Controls.Add(this.dgvTestParameters);
            this.Controls.Add(this.grpParam);
            this.Name = "frmTestParameters";
            this.Text = "frmUserSession";
            this.Load += new System.EventHandler(this.frmUserSession_Load);
            this.grpInvoiceDetail.ResumeLayout(false);
            this.grpInvoiceDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestParameters)).EndInit();
            this.grpParam.ResumeLayout(false);
            this.grpParam.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.ComboBox cmbTest;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox grpInvoiceDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomHeading;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridView dgvTestParameters;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnApproxResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRangeNewBorn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRange1MTo1Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRange1yTo14y;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRange14YToAbove;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnUnit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clnIsHeading;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRemarks;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAppResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRangeNewBorn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRange1Mto1Y;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtRange14YToAbove;
        private System.Windows.Forms.TextBox txtRange1Yto14Y;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtremarks;
        private System.Windows.Forms.GroupBox grpParam;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnNewParam;
        private System.Windows.Forms.CheckBox chkIsHeading;
        private System.Windows.Forms.Button Delete;
    }
}