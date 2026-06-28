namespace ERP.Forms
{
    partial class frmTimings
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
            this.dgvTimings = new System.Windows.Forms.DataGridView();
            this.clnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.days = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.start_time = new ERP.TimeCalendarColumn();
            this.end_time = new ERP.TimeCalendarColumn();
            this.status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnsave = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeCalendarColumn1 = new ERP.TimeCalendarColumn();
            this.timeCalendarColumn2 = new ERP.TimeCalendarColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimings)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTimings
            // 
            this.dgvTimings.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvTimings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnID,
            this.days,
            this.start_time,
            this.end_time,
            this.status});
            this.dgvTimings.Location = new System.Drawing.Point(6, 68);
            this.dgvTimings.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTimings.MultiSelect = false;
            this.dgvTimings.Name = "dgvTimings";
            this.dgvTimings.RowHeadersVisible = false;
            this.dgvTimings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTimings.Size = new System.Drawing.Size(631, 278);
            this.dgvTimings.TabIndex = 38;
            // 
            // clnID
            // 
            this.clnID.HeaderText = "ID";
            this.clnID.Name = "clnID";
            this.clnID.ReadOnly = true;
            this.clnID.Visible = false;
            // 
            // days
            // 
            this.days.HeaderText = "Days";
            this.days.MinimumWidth = 150;
            this.days.Name = "days";
            this.days.Width = 150;
            // 
            // start_time
            // 
            dataGridViewCellStyle1.Format = "hh:mm tt";
            this.start_time.DefaultCellStyle = dataGridViewCellStyle1;
            this.start_time.HeaderText = "Start Time";
            this.start_time.MinimumWidth = 120;
            this.start_time.Name = "start_time";
            this.start_time.Width = 120;
            // 
            // end_time
            // 
            dataGridViewCellStyle2.Format = "hh:mm tt";
            this.end_time.DefaultCellStyle = dataGridViewCellStyle2;
            this.end_time.HeaderText = "End Time";
            this.end_time.MinimumWidth = 120;
            this.end_time.Name = "end_time";
            this.end_time.Width = 120;
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.MinimumWidth = 80;
            this.status.Name = "status";
            this.status.Width = 80;
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(228, 353);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(96, 29);
            this.btnsave.TabIndex = 39;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(330, 353);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(96, 29);
            this.btncancel.TabIndex = 40;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(223, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 29);
            this.label1.TabIndex = 41;
            this.label1.Text = "Doctor Timing";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Days";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // timeCalendarColumn1
            // 
            dataGridViewCellStyle3.Format = "hh:mm tt";
            this.timeCalendarColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.timeCalendarColumn1.HeaderText = "Start Time";
            this.timeCalendarColumn1.MinimumWidth = 120;
            this.timeCalendarColumn1.Name = "timeCalendarColumn1";
            this.timeCalendarColumn1.Width = 120;
            // 
            // timeCalendarColumn2
            // 
            dataGridViewCellStyle4.Format = "hh:mm tt";
            this.timeCalendarColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.timeCalendarColumn2.HeaderText = "End Time";
            this.timeCalendarColumn2.MinimumWidth = 120;
            this.timeCalendarColumn2.Name = "timeCalendarColumn2";
            this.timeCalendarColumn2.Width = 120;
            // 
            // frmTimings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 394);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.dgvTimings);
            this.Name = "frmTimings";
            this.Text = "frmTimings";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTimings;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnID;
        private System.Windows.Forms.DataGridViewComboBoxColumn days;
        private TimeCalendarColumn start_time;
        private TimeCalendarColumn end_time;
        private System.Windows.Forms.DataGridViewCheckBoxColumn status;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private TimeCalendarColumn timeCalendarColumn1;
        private TimeCalendarColumn timeCalendarColumn2;
    }
}