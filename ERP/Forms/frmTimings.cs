using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class frmTimings : Form
    {

        public frmTimings()
        {
            InitializeComponent();
        }
        public frmTimings(DataTable dtTimings)
        {
            InitializeComponent();
            dt = dtTimings.Copy();

        }
        public DataTable dt;
        public bool gridEdited = false;
        private void frmTimings_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;
            
            dt.Columns["start_time"].AllowDBNull = true;
            dt.Columns["end_time"].AllowDBNull = true;
            
            DataGridViewTextBoxColumn clnDayId = new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "Id",
                DataPropertyName = "day_id",
                Visible = false,
                ReadOnly = true
            };

            DataGridViewTextBoxColumn clnTimingId = new DataGridViewTextBoxColumn
            {
                Name = "timing_id",
                HeaderText = "timing id",
                DataPropertyName = "timing_id",
                Visible = false,
                ReadOnly = true
            };

            DataGridViewTextBoxColumn clnDay = new DataGridViewTextBoxColumn
            {
                Name = "clnDay",
                HeaderText = "Day",
                DataPropertyName = "day_of_week",
                Visible = true,
                ReadOnly = true
            };

           
            
            dataGridView1.Columns.Add(clnDayId);
            dataGridView1.Columns.Add(clnTimingId);
            dataGridView1.Columns.Add(clnDay);
            

            if (!dataGridView1.Columns.Contains("clnStartTime"))
            {
                TimeCalendarColumn clnStartTime = new TimeCalendarColumn
                {
                    Name = "clnStartTime",
                    HeaderText = "Start Time",
                    DataPropertyName = "start_time"
                };

                TimeCalendarColumn clnEndTime = new TimeCalendarColumn
                {
                    Name = "clnEndTime",
                    HeaderText = "End Time",
                    DataPropertyName = "end_time"
                };

                dataGridView1.Columns.Add(clnStartTime);
                dataGridView1.Columns.Add(clnEndTime);
            }
            if(!dt.Columns.Contains("IsEdit"))
                dt.Columns.Add("IsEdit");
            dataGridView1.DataSource = dt;
            dataGridView1.KeyDown += dataGridView1_KeyDown;
           // dataGridView1.CurrentCellDirtyStateChanged += DataGridView1_CurrentCellDirtyStateChanged;
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back) &&
                dataGridView1.CurrentCell != null &&
                dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex] is TimeCalendarColumn &&
                !dataGridView1.CurrentCell.ReadOnly &&
                !dataGridView1.CurrentRow.IsNewRow)
                {
                dataGridView1.CurrentCell.Value = DBNull.Value;

                dataGridView1.NotifyCurrentCellDirty(true);
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                dataGridView1.EndEdit();

                e.Handled = true;
                }

        }
        private void DataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            this.DialogResult = DialogResult.OK;
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                gridEdited = true;
                dt.Rows[e.RowIndex]["IsEdit"] = 1;
            }
        }
    }
}
