using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmLabRemarks : Form
    {
        bool FLogin = true;
        public frmLabRemarks()
        {
            InitializeComponent();
            FillControls.FillcmbDepartmentIndex(cmbDepartment);
        }
        internal void FillForm(string departmentID)

        {

            DataTable dt = Query.TestRemarksIndex(departmentID);
            dgvNarration.Rows.Clear();
            for (int i = 0; i < dt.Rows.Count  ; i++)
            {
                dgvNarration.Rows.Add(dt.Rows[i]["id"].ToString(),dt.Rows[i]["Remarks"].ToString(),"0");  
            }
        
        }
        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            int code = 0;
            try
            {                      
            code = (int)(from DataGridViewRow row in dgvNarration.Rows
                         where row.Cells[clnCode.Index].Value != null && row.Cells[clnCode.Index].Value.ToString()  != ""
                    select int.Parse (row.Cells[clnCode.Index].Value.ToString()  )).Max();
            //dgvNarration.Rows[dgvNarration.Rows.Count - 2].Cells[clnCode.Index].Value = (code + 1).ToString("D3");
            dgvNarration.Rows[dgvNarration.Rows.Count - 2].Cells[clnCode.Index].Value = (00).ToString("D3");
            dgvNarration.Rows[dgvNarration.Rows.Count - 2].Cells[clnStatus .Index].Value = "0";
            dgvNarration.Rows[dgvNarration.Rows.Count - 2].Cells[clnIsEdit.Index].Value = "1"; 

            }
            catch (Exception)
            {
                dgvNarration.Rows[dgvNarration.Rows.Count - 2].Cells[clnCode.Index].Value = (code + 1).ToString("D3");
                dgvNarration.Rows[dgvNarration.Rows.Count - 2].Cells[clnStatus.Index].Value = "0";
                dgvNarration.Rows[dgvNarration.Rows.Count - 2].Cells[clnIsEdit.Index].Value = "1";  
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void dgvNarration_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!FLogin )
            {
                dgvNarration.CurrentRow .Cells[clnIsEdit.Index].Value = "1";  
            }
        }

        private void frmNarration_Load(object sender, EventArgs e)
        { 
            //FillForm(); 
            FLogin = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to Save this...!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvNarration.Rows)
                {
                    if (row.Cells[clnCode.Index].Value != null && row.Cells[clnDescription.Index].Value != null && row.Cells[clnIsEdit.Index].Value == "1")
                        DML.LabTestremarks_add_edit(row.Cells[clnCode.Index].Value.ToString(),
                            cmbDepartment.SelectedValue.ToString(),
                            row.Cells[clnDescription.Index].Value.ToString());
                }
                MessageBox.Show("Record Successfully Saved..!");
            }
        }

        private void dgvNarration_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvNarration .Rows[e.RowIndex].Selected = true;
                dgvNarration.CurrentCell = this.dgvNarration.Rows[e.RowIndex].Cells[e.ColumnIndex];
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void deleteRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to Delete this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dgvNarration[clnCode.Index, dgvNarration.CurrentRow.Index].Value != null)
                {
                    DML.NarrationAdd_Edit(dgvNarration.CurrentRow.Cells[clnCode.Index].Value.ToString(),
                           dgvNarration.CurrentRow.Cells[clnDescription.Index].Value.ToString(),
                           "1");
                    dgvNarration.Rows.RemoveAt(dgvNarration.CurrentRow.Index);
                    MessageBox.Show("Record Successfully Deleted..!");
                }
            }
        }
        
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cmbDepartment.SelectedIndex != -1)
            {
                //if(consultant==t)   
                DataRowView dr = (DataRowView)cmbDepartment.SelectedItem;
                if (dr != null)
                {
                    FillForm(cmbDepartment.SelectedValue.ToString());
                    
                }
            }
        }

  

      
    }
}
