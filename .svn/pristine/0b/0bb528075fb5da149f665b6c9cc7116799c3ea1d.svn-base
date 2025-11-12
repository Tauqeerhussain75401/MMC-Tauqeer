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
    public partial class frmMasterRegister : Form
    {
        public frmMasterRegister()
        {
            InitializeComponent();
        }
        void FillForm()
        {
            string IsDateAll = rdbAll.Checked ? "1" : "0";
            string Status = cmbStatus.SelectedIndex == 0 ? "status" : cmbStatus.SelectedIndex == 1 ? "1" : "0";

            string statusIO = cmbIOstatus.SelectedIndex == 0 ? "OPD" : "IPD";

            string sql = "SELECT case when status = '0' then 'Pending' else 'Received' end  status , receiptno, io, vdate, patientname,age, wm_concat(title) tests FROM  vu_MasterReg where (trunc(vdate) between '" + dtpFDate.Value.ToString("dd-MMM-yyyy") + "' and '" + dtpTDate.Value.ToString("dd-MMM-yyyy") + "' or 1 = " + IsDateAll + ") and status = " + Status + " AND io = '"+ statusIO.ToString() +"' GROUP BY status, receiptno, io, vdate, patientname, age order by to_number(receiptno) desc";
            DataTable dt = Query.getData(sql);
            dgvExpenses.Rows.Clear();   
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgvExpenses.Rows.Add(false, dt.Rows[i]["status"].ToString(), dt.Rows[i]["receiptno"].ToString(), dt.Rows[i]["io"].ToString(), dt.Rows[i]["vdate"].ToString(), dt.Rows[i]["patientname"].ToString(), dt.Rows[i]["age"].ToString()
                    , dt.Rows[i]["tests"].ToString());
            }           
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            FillForm();
        }


        private void btnReceived_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to save this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow  item in dgvExpenses.Rows  )
                {
                    if ((bool)item.Cells [clnSelect.Index].Value == true)
                    {
                        DML.LabMasterReg_StatusChanged(item.Cells[clnReceiptNo.Index].Value.ToString(), "1",item.Cells[clnIO.Index].Value.ToString());                        
                    }
                }
                MessageBox.Show("Successfully Saved..!");
            }
        }

        private void frmMasterRegister_Load(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = 2;
            cmbIOstatus.SelectedIndex = 0;
        }
    }
}
