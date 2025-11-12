namespace ERP
{
    partial class frmUserInfo
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
            this.dgvUserDetails = new System.Windows.Forms.DataGridView();
            this.clnLoginId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnDesignation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnLock = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clnMultiLogin = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpUserInfo = new System.Windows.Forms.GroupBox();
            this.chkMultiLogin = new System.Windows.Forms.CheckBox();
            this.chkLock = new System.Windows.Forms.CheckBox();
            this.txtCnfrmPassword = new System.Windows.Forms.TextBox();
            this.Cpass = new System.Windows.Forms.Label();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbUserLevel = new System.Windows.Forms.ComboBox();
            this.grpbtns = new System.Windows.Forms.GroupBox();
            this.btNew = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUname = new System.Windows.Forms.TextBox();
            this.txtUserid = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserDetails)).BeginInit();
            this.grpUserInfo.SuspendLayout();
            this.grpbtns.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUserDetails
            // 
            this.dgvUserDetails.AllowUserToAddRows = false;
            this.dgvUserDetails.AllowUserToDeleteRows = false;
            this.dgvUserDetails.AllowUserToResizeColumns = false;
            this.dgvUserDetails.AllowUserToResizeRows = false;
            this.dgvUserDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUserDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvUserDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnLoginId,
            this.clnName,
            this.clnDesignation,
            this.clnLock,
            this.clnMultiLogin,
            this.clnStatus});
            this.dgvUserDetails.Location = new System.Drawing.Point(12, 247);
            this.dgvUserDetails.MultiSelect = false;
            this.dgvUserDetails.Name = "dgvUserDetails";
            this.dgvUserDetails.ReadOnly = true;
            this.dgvUserDetails.RowHeadersVisible = false;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.dgvUserDetails.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUserDetails.RowTemplate.Height = 25;
            this.dgvUserDetails.RowTemplate.ReadOnly = true;
            this.dgvUserDetails.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUserDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserDetails.Size = new System.Drawing.Size(538, 320);
            this.dgvUserDetails.TabIndex = 0;
            this.dgvUserDetails.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserDetails_CellDoubleClick);
            // 
            // clnLoginId
            // 
            this.clnLoginId.HeaderText = "User Id";
            this.clnLoginId.Name = "clnLoginId";
            this.clnLoginId.ReadOnly = true;
            this.clnLoginId.Width = 66;
            // 
            // clnName
            // 
            this.clnName.HeaderText = "User Name";
            this.clnName.Name = "clnName";
            this.clnName.ReadOnly = true;
            this.clnName.Width = 85;
            // 
            // clnDesignation
            // 
            this.clnDesignation.HeaderText = "User Level";
            this.clnDesignation.Name = "clnDesignation";
            this.clnDesignation.ReadOnly = true;
            this.clnDesignation.Width = 83;
            // 
            // clnLock
            // 
            this.clnLock.HeaderText = "Lock";
            this.clnLock.Name = "clnLock";
            this.clnLock.ReadOnly = true;
            this.clnLock.Width = 37;
            // 
            // clnMultiLogin
            // 
            this.clnMultiLogin.HeaderText = "MultiLogin";
            this.clnMultiLogin.Name = "clnMultiLogin";
            this.clnMultiLogin.ReadOnly = true;
            this.clnMultiLogin.Width = 61;
            // 
            // clnStatus
            // 
            this.clnStatus.HeaderText = "Status";
            this.clnStatus.Name = "clnStatus";
            this.clnStatus.ReadOnly = true;
            this.clnStatus.Width = 62;
            // 
            // grpUserInfo
            // 
            this.grpUserInfo.Controls.Add(this.chkMultiLogin);
            this.grpUserInfo.Controls.Add(this.chkLock);
            this.grpUserInfo.Controls.Add(this.txtCnfrmPassword);
            this.grpUserInfo.Controls.Add(this.Cpass);
            this.grpUserInfo.Controls.Add(this.txtpass);
            this.grpUserInfo.Controls.Add(this.label4);
            this.grpUserInfo.Controls.Add(this.label3);
            this.grpUserInfo.Controls.Add(this.cmbUserLevel);
            this.grpUserInfo.Controls.Add(this.grpbtns);
            this.grpUserInfo.Controls.Add(this.label2);
            this.grpUserInfo.Controls.Add(this.label1);
            this.grpUserInfo.Controls.Add(this.txtUname);
            this.grpUserInfo.Controls.Add(this.txtUserid);
            this.grpUserInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpUserInfo.Location = new System.Drawing.Point(12, 49);
            this.grpUserInfo.Name = "grpUserInfo";
            this.grpUserInfo.Size = new System.Drawing.Size(542, 168);
            this.grpUserInfo.TabIndex = 1;
            this.grpUserInfo.TabStop = false;
            this.grpUserInfo.Text = "User Info";
            // 
            // chkMultiLogin
            // 
            this.chkMultiLogin.AutoSize = true;
            this.chkMultiLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMultiLogin.Location = new System.Drawing.Point(277, 49);
            this.chkMultiLogin.Name = "chkMultiLogin";
            this.chkMultiLogin.Size = new System.Drawing.Size(87, 19);
            this.chkMultiLogin.TabIndex = 15;
            this.chkMultiLogin.Text = "Multi Login";
            this.chkMultiLogin.UseVisualStyleBackColor = true;
            // 
            // chkLock
            // 
            this.chkLock.AutoSize = true;
            this.chkLock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLock.Location = new System.Drawing.Point(277, 22);
            this.chkLock.Name = "chkLock";
            this.chkLock.Size = new System.Drawing.Size(52, 19);
            this.chkLock.TabIndex = 14;
            this.chkLock.Text = "Lock";
            this.chkLock.UseVisualStyleBackColor = true;
            // 
            // txtCnfrmPassword
            // 
            this.txtCnfrmPassword.Location = new System.Drawing.Point(112, 133);
            this.txtCnfrmPassword.Name = "txtCnfrmPassword";
            this.txtCnfrmPassword.PasswordChar = '*';
            this.txtCnfrmPassword.Size = new System.Drawing.Size(134, 23);
            this.txtCnfrmPassword.TabIndex = 4;
            this.txtCnfrmPassword.UseSystemPasswordChar = true;
            // 
            // Cpass
            // 
            this.Cpass.AutoSize = true;
            this.Cpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cpass.Location = new System.Drawing.Point(12, 138);
            this.Cpass.Name = "Cpass";
            this.Cpass.Size = new System.Drawing.Size(97, 15);
            this.Cpass.TabIndex = 11;
            this.Cpass.Text = "Cnfrm Password";
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(112, 105);
            this.txtpass.Name = "txtpass";
            this.txtpass.PasswordChar = '*';
            this.txtpass.Size = new System.Drawing.Size(134, 23);
            this.txtpass.TabIndex = 3;
            this.txtpass.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "User Level";
            // 
            // cmbUserLevel
            // 
            this.cmbUserLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserLevel.FormattingEnabled = true;
            this.cmbUserLevel.Location = new System.Drawing.Point(112, 20);
            this.cmbUserLevel.Name = "cmbUserLevel";
            this.cmbUserLevel.Size = new System.Drawing.Size(134, 24);
            this.cmbUserLevel.TabIndex = 0;
            // 
            // grpbtns
            // 
            this.grpbtns.Controls.Add(this.btNew);
            this.grpbtns.Controls.Add(this.btnClose);
            this.grpbtns.Controls.Add(this.btnSave);
            this.grpbtns.Location = new System.Drawing.Point(265, 93);
            this.grpbtns.Name = "grpbtns";
            this.grpbtns.Size = new System.Drawing.Size(259, 63);
            this.grpbtns.TabIndex = 7;
            this.grpbtns.TabStop = false;
            // 
            // btNew
            // 
            this.btNew.Location = new System.Drawing.Point(14, 19);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(75, 30);
            this.btNew.TabIndex = 0;
            this.btNew.Text = "&New";
            this.btNew.UseVisualStyleBackColor = true;
            this.btNew.Click += new System.EventHandler(this.btNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(176, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(95, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "User Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "User ID";
            // 
            // txtUname
            // 
            this.txtUname.Location = new System.Drawing.Point(112, 77);
            this.txtUname.Name = "txtUname";
            this.txtUname.Size = new System.Drawing.Size(134, 23);
            this.txtUname.TabIndex = 2;
            // 
            // txtUserid
            // 
            this.txtUserid.Location = new System.Drawing.Point(112, 50);
            this.txtUserid.Name = "txtUserid";
            this.txtUserid.Size = new System.Drawing.Size(134, 23);
            this.txtUserid.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(161, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 29);
            this.label5.TabIndex = 4;
            this.label5.Text = "User Registration";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(12, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "(Double click to retrieve)";
            // 
            // frmUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 576);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grpUserInfo);
            this.Controls.Add(this.dgvUserDetails);
            this.Name = "frmUserInfo";
            this.Text = "User Information";
            this.Load += new System.EventHandler(this.frmUserInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserDetails)).EndInit();
            this.grpUserInfo.ResumeLayout(false);
            this.grpUserInfo.PerformLayout();
            this.grpbtns.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUserDetails;
        private System.Windows.Forms.GroupBox grpUserInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUname;
        private System.Windows.Forms.TextBox txtUserid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbUserLevel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grpbtns;
        private System.Windows.Forms.Button btNew;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCnfrmPassword;
        private System.Windows.Forms.Label Cpass;
        private System.Windows.Forms.CheckBox chkMultiLogin;
        private System.Windows.Forms.CheckBox chkLock;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnLoginId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnDesignation;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clnLock;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clnMultiLogin;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnStatus;
    }
}