using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class frmTimings : Form
    {
        private string _consultantId;
        private readonly HashSet<string> _originalIds = new HashSet<string>();

        public frmTimings()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        public frmTimings(string consultantId) : this()
        {
            _consultantId = consultantId;
            SetupGrid();
            LoadTimings();
        }

        private void SetupGrid()
        {
            var daysCol = dgvTimings.Columns["days"] as DataGridViewComboBoxColumn;
            if (daysCol != null)
            {
                daysCol.Items.AddRange("Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday");
                daysCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            }

            dgvTimings.DefaultValuesNeeded += dgvTimings_DefaultValuesNeeded;
            btnsave.Click += btnsave_Click;
            btncancel.Click += btncancel_Click;
        }

        private void dgvTimings_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["days"].Value = "Monday";
            e.Row.Cells["status"].Value = true;
        }

        private void LoadTimings()
        {
            if (string.IsNullOrWhiteSpace(_consultantId)) return;

            _originalIds.Clear();
            DataTable dt = Query.GetDocTimings(_consultantId);

            dgvTimings.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                string id = row["id"].ToString();
                _originalIds.Add(id);

                int idx = dgvTimings.Rows.Add();
                DataGridViewRow gridRow = dgvTimings.Rows[idx];
                gridRow.Cells["clnID"].Value = id;
                gridRow.Cells["days"].Value = row["days"].ToString();
                if (row["start_time"] != DBNull.Value)
                    gridRow.Cells["start_time"].Value = Convert.ToDateTime(row["start_time"]);
                if (row["end_time"] != DBNull.Value)
                    gridRow.Cells["end_time"].Value = Convert.ToDateTime(row["end_time"]);
                gridRow.Cells["status"].Value = row["status"].ToString() == "1";
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            dgvTimings.EndEdit();

            var currentIds = new HashSet<string>();

            // Validate all rows first
            foreach (DataGridViewRow row in dgvTimings.Rows)
            {
                if (row.IsNewRow) continue;

                string day = Convert.ToString(row.Cells["days"].Value);
                object startVal = row.Cells["start_time"].Value;
                object endVal = row.Cells["end_time"].Value;

                if (string.IsNullOrWhiteSpace(day))
                {
                    MessageBox.Show("Please select a day for each row.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (startVal == null || startVal == DBNull.Value)
                {
                    MessageBox.Show("Please enter start time for " + day + ".", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (endVal == null || endVal == DBNull.Value)
                {
                    MessageBox.Show("Please enter end time for " + day + ".", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime start = Convert.ToDateTime(startVal);
                DateTime end = Convert.ToDateTime(endVal);

                string existingId = Convert.ToString(row.Cells["clnID"].Value);
                if (!string.IsNullOrWhiteSpace(existingId))
                    currentIds.Add(existingId);
            }

            // Delete rows removed from the grid
            foreach (string id in _originalIds)
            {
                if (!currentIds.Contains(id))
                    DML.DeleteDocTiming(id);
            }

            // Save (insert or update) each row
            foreach (DataGridViewRow row in dgvTimings.Rows)
            {
                if (row.IsNewRow) continue;

                string day = Convert.ToString(row.Cells["days"].Value);
                DateTime start = Convert.ToDateTime(row.Cells["start_time"].Value);
                DateTime end = Convert.ToDateTime(row.Cells["end_time"].Value);
                bool isActive = row.Cells["status"].Value != null && row.Cells["status"].Value != DBNull.Value
                    && Convert.ToBoolean(row.Cells["status"].Value);
                int statusVal = isActive ? 1 : 0;
                string existingId = Convert.ToString(row.Cells["clnID"].Value);

                DML.SaveDocTiming(existingId, day, _consultantId, start, end, statusVal);
            }

            MessageBox.Show("Timings saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
