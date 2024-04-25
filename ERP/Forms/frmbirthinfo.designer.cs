namespace ERP
{
    partial class frmbirthinfo
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
            this.tabDetail = new System.Windows.Forms.TabControl();
            this.tbDetail = new System.Windows.Forms.TabPage();
            this.txtbirthid = new System.Windows.Forms.TextBox();
            this.txtserialno = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnnew = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.btnpreview = new System.Windows.Forms.Button();
            this.grprecptinfo = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.chkisactive = new System.Windows.Forms.CheckBox();
            this.txtrecrelation = new System.Windows.Forms.TextBox();
            this.txtrecname = new System.Windows.Forms.TextBox();
            this.txtremarks = new System.Windows.Forms.TextBox();
            this.dtprectime = new System.Windows.Forms.DateTimePicker();
            this.dtprecdate = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.grpchildinfo = new System.Windows.Forms.GroupBox();
            this.cmbcname = new System.Windows.Forms.ComboBox();
            this.txtRegAlpha = new System.Windows.Forms.TextBox();
            this.ntxtRegNo = new System.Windows.Forms.NumericUpDown();
            this.txtnote = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.ntxtweightkg = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.ntxtweightlbs = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.txtfname = new System.Windows.Forms.TextBox();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.txtgrand = new System.Windows.Forms.TextBox();
            this.txtmname = new System.Windows.Forms.TextBox();
            this.cmbgender = new System.Windows.Forms.ComboBox();
            this.dtpbirthtime = new System.Windows.Forms.DateTimePicker();
            this.dtpbirthdate = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbQuery = new System.Windows.Forms.TabPage();
            this.label23 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMother = new System.Windows.Forms.TextBox();
            this.txtFather = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvSearch = new System.Windows.Forms.DataGridView();
            this.clnFileNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnMother = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnFather = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnBirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabDetail.SuspendLayout();
            this.tbDetail.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grprecptinfo.SuspendLayout();
            this.grpchildinfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtRegNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtweightkg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtweightlbs)).BeginInit();
            this.tbQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // tabDetail
            // 
            this.tabDetail.Controls.Add(this.tbDetail);
            this.tabDetail.Controls.Add(this.tbQuery);
            this.tabDetail.Location = new System.Drawing.Point(1, 0);
            this.tabDetail.Name = "tabDetail";
            this.tabDetail.SelectedIndex = 0;
            this.tabDetail.Size = new System.Drawing.Size(781, 355);
            this.tabDetail.TabIndex = 0;
            this.tabDetail.TabStop = false;
            // 
            // tbDetail
            // 
            this.tbDetail.Controls.Add(this.txtbirthid);
            this.tbDetail.Controls.Add(this.txtserialno);
            this.tbDetail.Controls.Add(this.label17);
            this.tbDetail.Controls.Add(this.groupBox3);
            this.tbDetail.Controls.Add(this.grprecptinfo);
            this.tbDetail.Controls.Add(this.grpchildinfo);
            this.tbDetail.Controls.Add(this.label1);
            this.tbDetail.Location = new System.Drawing.Point(4, 22);
            this.tbDetail.Name = "tbDetail";
            this.tbDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tbDetail.Size = new System.Drawing.Size(773, 329);
            this.tbDetail.TabIndex = 0;
            this.tbDetail.Text = "Detail";
            this.tbDetail.UseVisualStyleBackColor = true;
            // 
            // txtbirthid
            // 
            this.txtbirthid.Location = new System.Drawing.Point(375, 10);
            this.txtbirthid.Name = "txtbirthid";
            this.txtbirthid.Size = new System.Drawing.Size(100, 20);
            this.txtbirthid.TabIndex = 18;
            this.txtbirthid.TabStop = false;
            this.txtbirthid.Visible = false;
            // 
            // txtserialno
            // 
            this.txtserialno.Location = new System.Drawing.Point(253, 9);
            this.txtserialno.Name = "txtserialno";
            this.txtserialno.Size = new System.Drawing.Size(100, 20);
            this.txtserialno.TabIndex = 17;
            this.txtserialno.TabStop = false;
            this.txtserialno.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(10, 160);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(192, 29);
            this.label17.TabIndex = 16;
            this.label17.Text = "Receiving Status";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnnew);
            this.groupBox3.Controls.Add(this.btnclose);
            this.groupBox3.Controls.Add(this.btnsave);
            this.groupBox3.Controls.Add(this.btnprint);
            this.groupBox3.Controls.Add(this.btnpreview);
            this.groupBox3.Location = new System.Drawing.Point(1, 277);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(416, 50);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            // 
            // btnnew
            // 
            this.btnnew.Location = new System.Drawing.Point(9, 17);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(75, 23);
            this.btnnew.TabIndex = 3;
            this.btnnew.Text = "&New";
            this.btnnew.UseVisualStyleBackColor = true;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(333, 17);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 7;
            this.btnclose.Text = "&Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(90, 17);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 0;
            this.btnsave.Text = "&Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnprint
            // 
            this.btnprint.Location = new System.Drawing.Point(252, 17);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(75, 23);
            this.btnprint.TabIndex = 6;
            this.btnprint.Text = "&Print";
            this.btnprint.UseVisualStyleBackColor = true;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // btnpreview
            // 
            this.btnpreview.Location = new System.Drawing.Point(171, 17);
            this.btnpreview.Name = "btnpreview";
            this.btnpreview.Size = new System.Drawing.Size(75, 23);
            this.btnpreview.TabIndex = 5;
            this.btnpreview.Text = "Pre&view";
            this.btnpreview.UseVisualStyleBackColor = true;
            this.btnpreview.Click += new System.EventHandler(this.btnpreview_Click);
            // 
            // grprecptinfo
            // 
            this.grprecptinfo.Controls.Add(this.label26);
            this.grprecptinfo.Controls.Add(this.label16);
            this.grprecptinfo.Controls.Add(this.chkisactive);
            this.grprecptinfo.Controls.Add(this.txtrecrelation);
            this.grprecptinfo.Controls.Add(this.txtrecname);
            this.grprecptinfo.Controls.Add(this.txtremarks);
            this.grprecptinfo.Controls.Add(this.dtprectime);
            this.grprecptinfo.Controls.Add(this.dtprecdate);
            this.grprecptinfo.Controls.Add(this.label18);
            this.grprecptinfo.Controls.Add(this.label20);
            this.grprecptinfo.Controls.Add(this.label25);
            this.grprecptinfo.Controls.Add(this.label28);
            this.grprecptinfo.Controls.Add(this.label29);
            this.grprecptinfo.Location = new System.Drawing.Point(1, 204);
            this.grprecptinfo.Name = "grprecptinfo";
            this.grprecptinfo.Size = new System.Drawing.Size(760, 67);
            this.grprecptinfo.TabIndex = 14;
            this.grprecptinfo.TabStop = false;
            this.grprecptinfo.Text = "Recpt.Info";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(401, 16);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(123, 13);
            this.label26.TabIndex = 30;
            this.label26.Text = "Person (Receiver Name)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(259, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 13);
            this.label16.TabIndex = 29;
            this.label16.Text = "Time";
            // 
            // chkisactive
            // 
            this.chkisactive.AutoSize = true;
            this.chkisactive.Location = new System.Drawing.Point(99, 15);
            this.chkisactive.Name = "chkisactive";
            this.chkisactive.Size = new System.Drawing.Size(15, 14);
            this.chkisactive.TabIndex = 13;
            this.chkisactive.UseVisualStyleBackColor = true;
            // 
            // txtrecrelation
            // 
            this.txtrecrelation.Location = new System.Drawing.Point(58, 37);
            this.txtrecrelation.Name = "txtrecrelation";
            this.txtrecrelation.Size = new System.Drawing.Size(241, 20);
            this.txtrecrelation.TabIndex = 17;
            // 
            // txtrecname
            // 
            this.txtrecname.Location = new System.Drawing.Point(530, 12);
            this.txtrecname.Name = "txtrecname";
            this.txtrecname.Size = new System.Drawing.Size(212, 20);
            this.txtrecname.TabIndex = 16;
            // 
            // txtremarks
            // 
            this.txtremarks.Location = new System.Drawing.Point(355, 37);
            this.txtremarks.Name = "txtremarks";
            this.txtremarks.Size = new System.Drawing.Size(387, 20);
            this.txtremarks.TabIndex = 18;
            // 
            // dtprectime
            // 
            this.dtprectime.CustomFormat = "hh:mm tt";
            this.dtprectime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtprectime.Location = new System.Drawing.Point(295, 12);
            this.dtprectime.Name = "dtprectime";
            this.dtprectime.Size = new System.Drawing.Size(93, 20);
            this.dtprectime.TabIndex = 15;
            // 
            // dtprecdate
            // 
            this.dtprecdate.CustomFormat = "dd-MMM-yyyy";
            this.dtprecdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtprecdate.Location = new System.Drawing.Point(154, 12);
            this.dtprecdate.MaxDate = new System.DateTime(2060, 12, 3, 0, 0, 0, 0);
            this.dtprecdate.Name = "dtprecdate";
            this.dtprecdate.Size = new System.Drawing.Size(99, 20);
            this.dtprecdate.TabIndex = 14;
            this.dtprecdate.Value = new System.DateTime(2019, 12, 3, 0, 0, 0, 0);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(366, 60);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(0, 13);
            this.label18.TabIndex = 14;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(306, 41);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(49, 13);
            this.label20.TabIndex = 12;
            this.label20.Text = "Remarks";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(8, 41);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(46, 13);
            this.label25.TabIndex = 5;
            this.label25.Text = "Relation";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(121, 16);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(30, 13);
            this.label28.TabIndex = 1;
            this.label28.Text = "Date";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(6, 16);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(82, 13);
            this.label29.TabIndex = 0;
            this.label29.Text = "Received (Y/N)";
            // 
            // grpchildinfo
            // 
            this.grpchildinfo.Controls.Add(this.cmbcname);
            this.grpchildinfo.Controls.Add(this.txtRegAlpha);
            this.grpchildinfo.Controls.Add(this.ntxtRegNo);
            this.grpchildinfo.Controls.Add(this.txtnote);
            this.grpchildinfo.Controls.Add(this.label21);
            this.grpchildinfo.Controls.Add(this.ntxtweightkg);
            this.grpchildinfo.Controls.Add(this.label6);
            this.grpchildinfo.Controls.Add(this.ntxtweightlbs);
            this.grpchildinfo.Controls.Add(this.label13);
            this.grpchildinfo.Controls.Add(this.txtfname);
            this.grpchildinfo.Controls.Add(this.txtaddress);
            this.grpchildinfo.Controls.Add(this.txtgrand);
            this.grpchildinfo.Controls.Add(this.txtmname);
            this.grpchildinfo.Controls.Add(this.cmbgender);
            this.grpchildinfo.Controls.Add(this.dtpbirthtime);
            this.grpchildinfo.Controls.Add(this.dtpbirthdate);
            this.grpchildinfo.Controls.Add(this.label15);
            this.grpchildinfo.Controls.Add(this.label12);
            this.grpchildinfo.Controls.Add(this.label14);
            this.grpchildinfo.Controls.Add(this.label11);
            this.grpchildinfo.Controls.Add(this.label10);
            this.grpchildinfo.Controls.Add(this.label9);
            this.grpchildinfo.Controls.Add(this.label8);
            this.grpchildinfo.Controls.Add(this.label7);
            this.grpchildinfo.Controls.Add(this.label5);
            this.grpchildinfo.Controls.Add(this.label4);
            this.grpchildinfo.Controls.Add(this.label3);
            this.grpchildinfo.Location = new System.Drawing.Point(6, 43);
            this.grpchildinfo.Name = "grpchildinfo";
            this.grpchildinfo.Size = new System.Drawing.Size(765, 114);
            this.grpchildinfo.TabIndex = 12;
            this.grpchildinfo.TabStop = false;
            this.grpchildinfo.Text = "Child Info";
            // 
            // cmbcname
            // 
            this.cmbcname.FormattingEnabled = true;
            this.cmbcname.Items.AddRange(new object[] {
            "Dr.Zia"});
            this.cmbcname.Location = new System.Drawing.Point(387, 62);
            this.cmbcname.Name = "cmbcname";
            this.cmbcname.Size = new System.Drawing.Size(126, 21);
            this.cmbcname.TabIndex = 11;
            // 
            // txtRegAlpha
            // 
            this.txtRegAlpha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRegAlpha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegAlpha.Location = new System.Drawing.Point(65, 11);
            this.txtRegAlpha.Margin = new System.Windows.Forms.Padding(4);
            this.txtRegAlpha.MaxLength = 1;
            this.txtRegAlpha.Name = "txtRegAlpha";
            this.txtRegAlpha.Size = new System.Drawing.Size(27, 23);
            this.txtRegAlpha.TabIndex = 0;
            this.txtRegAlpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRegAlpha.Validated += new System.EventHandler(this.txtRegAlpha_Validated);
            // 
            // ntxtRegNo
            // 
            this.ntxtRegNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntxtRegNo.Location = new System.Drawing.Point(110, 11);
            this.ntxtRegNo.Margin = new System.Windows.Forms.Padding(4);
            this.ntxtRegNo.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.ntxtRegNo.Name = "ntxtRegNo";
            this.ntxtRegNo.Size = new System.Drawing.Size(50, 23);
            this.ntxtRegNo.TabIndex = 1;
            this.ntxtRegNo.Validated += new System.EventHandler(this.ntxtRegNo_Validated);
            // 
            // txtnote
            // 
            this.txtnote.Location = new System.Drawing.Point(557, 62);
            this.txtnote.Name = "txtnote";
            this.txtnote.Size = new System.Drawing.Size(198, 20);
            this.txtnote.TabIndex = 12;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(8, 14);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(58, 16);
            this.label21.TabIndex = 194;
            this.label21.Text = "Reg No.";
            // 
            // ntxtweightkg
            // 
            this.ntxtweightkg.DecimalPlaces = 5;
            this.ntxtweightkg.Location = new System.Drawing.Point(77, 62);
            this.ntxtweightkg.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.ntxtweightkg.Name = "ntxtweightkg";
            this.ntxtweightkg.Size = new System.Drawing.Size(72, 20);
            this.ntxtweightkg.TabIndex = 9;
            this.ntxtweightkg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntxtweightkg.Validated += new System.EventHandler(this.ntxtweightkg_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(91, 9);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 26);
            this.label6.TabIndex = 195;
            this.label6.Text = "-";
            // 
            // ntxtweightlbs
            // 
            this.ntxtweightlbs.DecimalPlaces = 5;
            this.ntxtweightlbs.Enabled = false;
            this.ntxtweightlbs.Location = new System.Drawing.Point(222, 62);
            this.ntxtweightlbs.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.ntxtweightlbs.Name = "ntxtweightlbs";
            this.ntxtweightlbs.Size = new System.Drawing.Size(72, 20);
            this.ntxtweightlbs.TabIndex = 10;
            this.ntxtweightlbs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "Weight (Kg)";
            // 
            // txtfname
            // 
            this.txtfname.Location = new System.Drawing.Point(604, 12);
            this.txtfname.Name = "txtfname";
            this.txtfname.Size = new System.Drawing.Size(152, 20);
            this.txtfname.TabIndex = 5;
            // 
            // txtaddress
            // 
            this.txtaddress.Location = new System.Drawing.Point(517, 37);
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(238, 20);
            this.txtaddress.TabIndex = 8;
            // 
            // txtgrand
            // 
            this.txtgrand.Location = new System.Drawing.Point(342, 37);
            this.txtgrand.Name = "txtgrand";
            this.txtgrand.Size = new System.Drawing.Size(122, 20);
            this.txtgrand.TabIndex = 7;
            // 
            // txtmname
            // 
            this.txtmname.Location = new System.Drawing.Point(77, 38);
            this.txtmname.Name = "txtmname";
            this.txtmname.Size = new System.Drawing.Size(152, 20);
            this.txtmname.TabIndex = 6;
            // 
            // cmbgender
            // 
            this.cmbgender.FormattingEnabled = true;
            this.cmbgender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbgender.Location = new System.Drawing.Point(453, 12);
            this.cmbgender.Name = "cmbgender";
            this.cmbgender.Size = new System.Drawing.Size(72, 21);
            this.cmbgender.TabIndex = 4;
            // 
            // dtpbirthtime
            // 
            this.dtpbirthtime.CustomFormat = "hh:mm tt";
            this.dtpbirthtime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpbirthtime.Location = new System.Drawing.Point(313, 12);
            this.dtpbirthtime.Name = "dtpbirthtime";
            this.dtpbirthtime.Size = new System.Drawing.Size(90, 20);
            this.dtpbirthtime.TabIndex = 3;
            // 
            // dtpbirthdate
            // 
            this.dtpbirthdate.CustomFormat = "dd-MMM-yyyy";
            this.dtpbirthdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpbirthdate.Location = new System.Drawing.Point(196, 12);
            this.dtpbirthdate.MaxDate = new System.DateTime(2060, 12, 3, 0, 0, 0, 0);
            this.dtpbirthdate.Name = "dtpbirthdate";
            this.dtpbirthdate.Size = new System.Drawing.Size(84, 20);
            this.dtpbirthdate.TabIndex = 2;
            this.dtpbirthdate.Value = new System.DateTime(2019, 12, 3, 0, 0, 0, 0);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(366, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(0, 13);
            this.label15.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(155, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Weight (Lbs)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(469, 41);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "Address";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(298, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Consultant Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(514, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Note";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Mother Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(231, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = " Grand Father/Mother";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(530, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Father Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(405, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Gender";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(283, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(166, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 29);
            this.label1.TabIndex = 13;
            this.label1.Text = "Birth Information";
            // 
            // tbQuery
            // 
            this.tbQuery.Controls.Add(this.label23);
            this.tbQuery.Controls.Add(this.dtpTo);
            this.tbQuery.Controls.Add(this.label22);
            this.tbQuery.Controls.Add(this.dtpFrom);
            this.tbQuery.Controls.Add(this.label19);
            this.tbQuery.Controls.Add(this.label2);
            this.tbQuery.Controls.Add(this.txtMother);
            this.tbQuery.Controls.Add(this.txtFather);
            this.tbQuery.Controls.Add(this.btnSearch);
            this.tbQuery.Controls.Add(this.dgvSearch);
            this.tbQuery.Location = new System.Drawing.Point(4, 22);
            this.tbQuery.Name = "tbQuery";
            this.tbQuery.Padding = new System.Windows.Forms.Padding(3);
            this.tbQuery.Size = new System.Drawing.Size(773, 329);
            this.tbQuery.TabIndex = 1;
            this.tbQuery.Text = "Query";
            this.tbQuery.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(526, 271);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(26, 13);
            this.label23.TabIndex = 20;
            this.label23.Text = "To: ";
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd MMM yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(552, 267);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(100, 20);
            this.dtpTo.TabIndex = 19;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(380, 271);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(33, 13);
            this.label22.TabIndex = 18;
            this.label22.Text = "From:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd MMM yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(414, 267);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpFrom.TabIndex = 17;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(193, 271);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 13);
            this.label19.TabIndex = 16;
            this.label19.Text = "Mother Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Father Name:";
            // 
            // txtMother
            // 
            this.txtMother.Location = new System.Drawing.Point(267, 267);
            this.txtMother.Name = "txtMother";
            this.txtMother.Size = new System.Drawing.Size(100, 20);
            this.txtMother.TabIndex = 14;
            // 
            // txtFather
            // 
            this.txtFather.Location = new System.Drawing.Point(78, 267);
            this.txtFather.Name = "txtFather";
            this.txtFather.Size = new System.Drawing.Size(100, 20);
            this.txtFather.TabIndex = 13;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(667, 266);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 23);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvSearch
            // 
            this.dgvSearch.AllowUserToAddRows = false;
            this.dgvSearch.AllowUserToDeleteRows = false;
            this.dgvSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSearch.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSearch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnFileNo,
            this.clnMother,
            this.clnFather,
            this.clnBirthDate});
            this.dgvSearch.Location = new System.Drawing.Point(6, 6);
            this.dgvSearch.Name = "dgvSearch";
            this.dgvSearch.RowHeadersVisible = false;
            this.dgvSearch.Size = new System.Drawing.Size(761, 255);
            this.dgvSearch.TabIndex = 11;
            // 
            // clnFileNo
            // 
            this.clnFileNo.HeaderText = "File #";
            this.clnFileNo.Name = "clnFileNo";
            // 
            // clnMother
            // 
            this.clnMother.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clnMother.HeaderText = "Mother Name";
            this.clnMother.Name = "clnMother";
            // 
            // clnFather
            // 
            this.clnFather.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clnFather.HeaderText = "Father Name";
            this.clnFather.Name = "clnFather";
            // 
            // clnBirthDate
            // 
            this.clnBirthDate.HeaderText = "Birth Date";
            this.clnBirthDate.Name = "clnBirthDate";
            // 
            // frmbirthinfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 357);
            this.Controls.Add(this.tabDetail);
            this.KeyPreview = true;
            this.Name = "frmbirthinfo";
            this.Text = "frmbirthinfo";
            this.Load += new System.EventHandler(this.frmbirthinfo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmbirthinfo_KeyDown);
            this.tabDetail.ResumeLayout(false);
            this.tbDetail.ResumeLayout(false);
            this.tbDetail.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.grprecptinfo.ResumeLayout(false);
            this.grprecptinfo.PerformLayout();
            this.grpchildinfo.ResumeLayout(false);
            this.grpchildinfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtRegNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtweightkg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtweightlbs)).EndInit();
            this.tbQuery.ResumeLayout(false);
            this.tbQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabDetail;
        private System.Windows.Forms.TabPage tbDetail;
        private System.Windows.Forms.TextBox txtbirthid;
        private System.Windows.Forms.TextBox txtserialno;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnpreview;
        private System.Windows.Forms.GroupBox grprecptinfo;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox chkisactive;
        private System.Windows.Forms.TextBox txtrecrelation;
        private System.Windows.Forms.TextBox txtrecname;
        private System.Windows.Forms.TextBox txtremarks;
        private System.Windows.Forms.DateTimePicker dtprectime;
        private System.Windows.Forms.DateTimePicker dtprecdate;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.GroupBox grpchildinfo;
        private System.Windows.Forms.ComboBox cmbcname;
        private System.Windows.Forms.TextBox txtRegAlpha;
        private System.Windows.Forms.NumericUpDown ntxtRegNo;
        private System.Windows.Forms.TextBox txtnote;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown ntxtweightkg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown ntxtweightlbs;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtfname;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.TextBox txtgrand;
        private System.Windows.Forms.TextBox txtmname;
        private System.Windows.Forms.ComboBox cmbgender;
        private System.Windows.Forms.DateTimePicker dtpbirthtime;
        private System.Windows.Forms.DateTimePicker dtpbirthdate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tbQuery;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMother;
        private System.Windows.Forms.TextBox txtFather;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnFileNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnMother;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnFather;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnBirthDate;
    }
}