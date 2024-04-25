namespace ERP
{
    partial class frmReference
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
            this.label1 = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.chkInReport = new System.Windows.Forms.CheckBox();
            this.txtRname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.dgvRefdetails = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpReferenceInfo = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.clnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnReport = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clnActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefdetails)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.grpReferenceInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActive.Location = new System.Drawing.Point(215, 25);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(65, 21);
            this.chkActive.TabIndex = 1;
            this.chkActive.Text = "Active";
            this.chkActive.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // chkInReport
            // 
            this.chkInReport.AutoSize = true;
            this.chkInReport.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkInReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInReport.Location = new System.Drawing.Point(118, 25);
            this.chkInReport.Name = "chkInReport";
            this.chkInReport.Size = new System.Drawing.Size(85, 21);
            this.chkInReport.TabIndex = 2;
            this.chkInReport.Text = "In Report";
            this.chkInReport.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.chkInReport.UseVisualStyleBackColor = true;
            // 
            // txtRname
            // 
            this.txtRname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRname.Location = new System.Drawing.Point(62, 53);
            this.txtRname.Name = "txtRname";
            this.txtRname.Size = new System.Drawing.Size(221, 23);
            this.txtRname.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "ID";
            // 
            // txtid
            // 
            this.txtid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtid.Location = new System.Drawing.Point(62, 24);
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            this.txtid.Size = new System.Drawing.Size(50, 23);
            this.txtid.TabIndex = 5;
            // 
            // dgvRefdetails
            // 
            this.dgvRefdetails.AllowUserToAddRows = false;
            this.dgvRefdetails.AllowUserToDeleteRows = false;
            this.dgvRefdetails.AllowUserToResizeColumns = false;
            this.dgvRefdetails.AllowUserToResizeRows = false;
            this.dgvRefdetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRefdetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnID,
            this.clnName,
            this.clnReport,
            this.clnActive});
            this.dgvRefdetails.Location = new System.Drawing.Point(11, 214);
            this.dgvRefdetails.MultiSelect = false;
            this.dgvRefdetails.Name = "dgvRefdetails";
            this.dgvRefdetails.ReadOnly = true;
            this.dgvRefdetails.RowHeadersVisible = false;
            this.dgvRefdetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRefdetails.Size = new System.Drawing.Size(532, 427);
            this.dgvRefdetails.TabIndex = 6;
            this.dgvRefdetails.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRefdetails_CellDoubleClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnPrint);
            this.groupBox4.Controls.Add(this.btnExit);
            this.groupBox4.Controls.Add(this.btnPreview);
            this.groupBox4.Controls.Add(this.btnNew);
            this.groupBox4.Controls.Add(this.btnSave);
            this.groupBox4.Location = new System.Drawing.Point(11, 136);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(404, 47);
            this.groupBox4.TabIndex = 252;
            this.groupBox4.TabStop = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(162, 10);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(79, 30);
            this.btnPrint.TabIndex = 255;
            this.btnPrint.Text = "&Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(320, 10);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(79, 30);
            this.btnExit.TabIndex = 254;
            this.btnExit.Text = "E&xit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Enabled = false;
            this.btnPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(241, 10);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(79, 30);
            this.btnPreview.TabIndex = 253;
            this.btnPreview.Text = "Pre&view";
            this.btnPreview.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPreview.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(4, 10);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(79, 30);
            this.btnNew.TabIndex = 251;
            this.btnNew.Text = "&New";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(83, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 30);
            this.btnSave.TabIndex = 250;
            this.btnSave.Text = "&Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpReferenceInfo
            // 
            this.grpReferenceInfo.Controls.Add(this.txtid);
            this.grpReferenceInfo.Controls.Add(this.label1);
            this.grpReferenceInfo.Controls.Add(this.chkActive);
            this.grpReferenceInfo.Controls.Add(this.chkInReport);
            this.grpReferenceInfo.Controls.Add(this.label2);
            this.grpReferenceInfo.Controls.Add(this.txtRname);
            this.grpReferenceInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpReferenceInfo.Location = new System.Drawing.Point(11, 48);
            this.grpReferenceInfo.Name = "grpReferenceInfo";
            this.grpReferenceInfo.Size = new System.Drawing.Size(305, 82);
            this.grpReferenceInfo.TabIndex = 253;
            this.grpReferenceInfo.TabStop = false;
            this.grpReferenceInfo.Text = "Refernce Info";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(149, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(248, 26);
            this.label3.TabIndex = 254;
            this.label3.Text = "Reference Information";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(14, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 255;
            this.label4.Text = "(Double Click to retrieve)";
            // 
            // clnID
            // 
            this.clnID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clnID.HeaderText = "ID";
            this.clnID.Name = "clnID";
            this.clnID.ReadOnly = true;
            this.clnID.Width = 43;
            // 
            // clnName
            // 
            this.clnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clnName.HeaderText = "Name";
            this.clnName.Name = "clnName";
            this.clnName.ReadOnly = true;
            // 
            // clnReport
            // 
            this.clnReport.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clnReport.HeaderText = "Report";
            this.clnReport.Name = "clnReport";
            this.clnReport.ReadOnly = true;
            this.clnReport.Width = 45;
            // 
            // clnActive
            // 
            this.clnActive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clnActive.HeaderText = "Active";
            this.clnActive.Name = "clnActive";
            this.clnActive.ReadOnly = true;
            this.clnActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clnActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clnActive.Width = 62;
            // 
            // frmReference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 650);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grpReferenceInfo);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.dgvRefdetails);
            this.Name = "frmReference";
            this.Text = "Reference Info";
            this.Load += new System.EventHandler(this.frmReference_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefdetails)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.grpReferenceInfo.ResumeLayout(false);
            this.grpReferenceInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.CheckBox chkInReport;
        private System.Windows.Forms.TextBox txtRname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.DataGridView dgvRefdetails;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpReferenceInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clnReport;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clnActive;
    }
}