using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class frmRoomStatus : Form
    {
        public frmRoomStatus()
        {
            InitializeComponent();
        }
        void FillSummary(string Floor,int Empty ,int Occupied,int ind)
        {
            GroupBox groupBox1 = new GroupBox ();
            Label label1 = new Label ();
            Label lblOccupied = new Label ();
            Label lblEmpty = new Label ();
            Label label4 = new Label ();
            Label lblTot = new Label ();
             // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblTot);
            groupBox1.Controls.Add(lblEmpty);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(lblOccupied);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            groupBox1.Location = new System.Drawing.Point(12 + (ind*185), 610);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(182, 100);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = Floor ;
            // 
            // label1
            // 
            label1.BackColor = System.Drawing.Color.Red;
            label1.Location = new System.Drawing.Point(5, 51);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(18, 18);
            label1.TabIndex = 1;
            // 
            // lblOccupied
            // 
            lblOccupied.AutoSize = true;
            lblOccupied.Location = new System.Drawing.Point(34, 53);
            lblOccupied.Name = "lblOccupied";
            lblOccupied.Size = new System.Drawing.Size(51, 20);
            lblOccupied.TabIndex = 1;
            lblOccupied.Text = "Occupied = " + Occupied.ToString();
            // 
            // lblEmpty
            // 
            lblEmpty.AutoSize = true;
            lblEmpty.Location = new System.Drawing.Point(34, 73);
            lblEmpty.Name = "lblEmpty";
            lblEmpty.Size = new System.Drawing.Size(51, 20);
            lblEmpty.TabIndex = 3;
            lblEmpty.Text = "Empty = " + Empty.ToString();
            // 
            // label4
            // 
            label4.BackColor = System.Drawing.Color.Green;
            label4.Location = new System.Drawing.Point(5, 71);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(18, 19);
            label4.TabIndex = 2;
            // 
            // lblTot
            // 
            lblTot.AutoSize = true;
            lblTot.Location = new System.Drawing.Point(34, 33);
            lblTot.Name = "lblTot";
            lblTot.Size = new System.Drawing.Size(51, 20);
            lblTot.TabIndex = 4;
            lblTot.Text = "Total = " + (Empty + Occupied).ToString();
            this.Controls.Add(groupBox1); 
        }

        void FillForm()
        {                        
            DataTable dt = Query.RoomIndex();
            object[] dtFloor = dt.AsEnumerable()
                                .GroupBy(r => new { Col1 = r["floornumber"] }).Select(g => g.Key.Col1).ToArray();
       
            for (int i = 0; i < dtFloor.Count()  ; i++)
            {
                Label lbl = new Label();
                lbl.Text = dtFloor[i].ToString();
                lbl.Name = "lbl" + i.ToString();                
                lbl.AutoSize = true;
                lbl.Font = new System.Drawing.Font("Calibri", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lbl.Location = new System.Drawing.Point(50 + (i * 185), 60);
                lbl.Size = new System.Drawing.Size(92, 37);
                Controls.Add(lbl);  
                
                DataGridView dataGridView1 = new DataGridView();
                dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
                dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;            
                dataGridView1.Location = new System.Drawing.Point(13 + (i * 185), 104 );
                dataGridView1.Name = dtFloor[i].ToString();
                dataGridView1.Size = new System.Drawing.Size(185, 485);
                dataGridView1.TabIndex = 0;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.RowHeadersVisible = false;  
                dataGridView1.ReadOnly = true ;
                DataTable dtNew = dt.Select("floornumber = '" + dtFloor[i].ToString() + "'").CopyToDataTable();                
                dataGridView1.DataSource = dtNew;
                Controls.Add(dataGridView1);

                dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
                dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(dataGridView1_CellDoubleClick); 
                dataGridView1.Columns["Id"].Visible = false;
                dataGridView1.Columns["floornumber"].Visible = false;
                dataGridView1.Columns["Room"].HeaderText = "Room";
                dataGridView1.Columns["regno"].HeaderText = "Reg";
                


                object Empty = dtNew.Compute("count(room)", "regno = '-' and floornumber = '" + dtFloor[i].ToString() + "'");
                object Occupied = dtNew.Compute("count(room)", "regno <> '-' and floornumber = '" + dtFloor[i].ToString() + "'");
                FillSummary(dtFloor[i].ToString(),Convert .ToInt16 (Empty) ,Convert .ToInt16 (Occupied ),i);
            }
            object TotEmpty = dt.Compute("count(room)", "regno = '-' ");
            object TotOccupied = dt.Compute("count(room)", "regno <> '-' ");

            FillSummary("Summary", Convert.ToInt16(TotEmpty), Convert.ToInt16(TotOccupied), dtFloor.Count());
        }
        internal string roomId = "";
        internal string roomName = "";
        void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((sender as DataGridView).Rows[e.RowIndex].Cells["regno"].Value.ToString() == "-")
            {
                roomId = (sender as DataGridView).Rows[e.RowIndex].Cells["id"].Value.ToString();
                roomName = (sender as DataGridView).Rows[e.RowIndex].Cells["room"].Value.ToString();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Room already reserved...!"); 
            }
        }

        void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == (sender as DataGridView).Columns["RegNo"].Index)
            {
                if ((sender as DataGridView).Rows[e.RowIndex].Cells["RegNo"].Value.ToString() != "-")
                {
                    (sender as DataGridView).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                    (sender as DataGridView).Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                }
                else
                    (sender as DataGridView).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green; 
            }
        }
        private void frmRoomStatus_Load(object sender, EventArgs e)
        {
            FillForm();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();  
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillForm();
        }

      
    }
}
