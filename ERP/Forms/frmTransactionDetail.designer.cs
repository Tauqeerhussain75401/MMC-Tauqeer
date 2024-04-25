namespace ERP
{
    partial class frmTransactionDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransactionDetail));
            this.dgvTransactionDetail = new System.Windows.Forms.DataGridView();
            this.clnTransCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTransNarration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsEdit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTransactionIndex = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusRight = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpSC = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.picTransactionLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionDetail)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.grpSC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTransactionLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTransactionDetail
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTransactionDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTransactionDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransactionDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransactionDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTransactionDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactionDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnTransCode,
            this.clnTransNarration,
            this.IsEdit});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTransactionDetail.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTransactionDetail.Location = new System.Drawing.Point(5, 101);
            this.dgvTransactionDetail.Name = "dgvTransactionDetail";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransactionDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTransactionDetail.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTransactionDetail.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTransactionDetail.Size = new System.Drawing.Size(479, 217);
            this.dgvTransactionDetail.TabIndex = 0;
            this.dgvTransactionDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransactionDetail_CellValueChanged);
            this.dgvTransactionDetail.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvTransactionDetail_EditingControlShowing);
            // 
            // clnTransCode
            // 
            this.clnTransCode.HeaderText = "Transaction Code";
            this.clnTransCode.MinimumWidth = 100;
            this.clnTransCode.Name = "clnTransCode";
            // 
            // clnTransNarration
            // 
            this.clnTransNarration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clnTransNarration.HeaderText = "Transaction Narration";
            this.clnTransNarration.MinimumWidth = 100;
            this.clnTransNarration.Name = "clnTransNarration";
            // 
            // IsEdit
            // 
            this.IsEdit.HeaderText = "IsEdit";
            this.IsEdit.Name = "IsEdit";
            this.IsEdit.ReadOnly = true;
            this.IsEdit.Visible = false;
            // 
            // lblTransactionIndex
            // 
            this.lblTransactionIndex.AutoSize = true;
            this.lblTransactionIndex.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionIndex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTransactionIndex.Location = new System.Drawing.Point(107, 20);
            this.lblTransactionIndex.Name = "lblTransactionIndex";
            this.lblTransactionIndex.Size = new System.Drawing.Size(395, 55);
            this.lblTransactionIndex.TabIndex = 1;
            this.lblTransactionIndex.Text = "Transaction Index";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusUserName,
            this.statusRight,
            this.statusDateTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 385);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(489, 24);
            this.statusStrip1.TabIndex = 114;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusUserName
            // 
            this.statusUserName.Name = "statusUserName";
            this.statusUserName.Size = new System.Drawing.Size(128, 19);
            this.statusUserName.Text = "User Name : Admin";
            // 
            // statusRight
            // 
            this.statusRight.Name = "statusRight";
            this.statusRight.Size = new System.Drawing.Size(92, 19);
            this.statusRight.Text = "Right : Admin";
            // 
            // statusDateTime
            // 
            this.statusDateTime.Name = "statusDateTime";
            this.statusDateTime.Size = new System.Drawing.Size(101, 19);
            this.statusDateTime.Text = "LoginDateTime";
            // 
            // grpSC
            // 
            this.grpSC.BackColor = System.Drawing.Color.Transparent;
            this.grpSC.Controls.Add(this.btnCancel);
            this.grpSC.Controls.Add(this.btnSave);
            this.grpSC.Location = new System.Drawing.Point(159, 324);
            this.grpSC.Name = "grpSC";
            this.grpSC.Size = new System.Drawing.Size(172, 52);
            this.grpSC.TabIndex = 116;
            this.grpSC.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(88, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 34);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(6, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 34);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // picTransactionLogo
            // 
            this.picTransactionLogo.Image = ((System.Drawing.Image)(resources.GetObject("picTransactionLogo.Image")));
            this.picTransactionLogo.Location = new System.Drawing.Point(13, 0);
            this.picTransactionLogo.Name = "picTransactionLogo";
            this.picTransactionLogo.Size = new System.Drawing.Size(100, 96);
            this.picTransactionLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTransactionLogo.TabIndex = 115;
            this.picTransactionLogo.TabStop = false;
            // 
            // frmTransactionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(489, 409);
            this.Controls.Add(this.grpSC);
            this.Controls.Add(this.picTransactionLogo);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblTransactionIndex);
            this.Controls.Add(this.dgvTransactionDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTransactionDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTransactionIndex";
            this.Load += new System.EventHandler(this.frmTransactionDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionDetail)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grpSC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTransactionLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTransactionDetail;
        private System.Windows.Forms.Label lblTransactionIndex;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusUserName;
        private System.Windows.Forms.ToolStripStatusLabel statusRight;
        private System.Windows.Forms.ToolStripStatusLabel statusDateTime;
        private System.Windows.Forms.PictureBox picTransactionLogo;
        private System.Windows.Forms.GroupBox grpSC;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTransCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTransNarration;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsEdit;
    }
}