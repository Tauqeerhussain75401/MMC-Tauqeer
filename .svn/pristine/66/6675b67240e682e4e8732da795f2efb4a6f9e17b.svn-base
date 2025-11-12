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
    public partial class frmTestParameters : Form
    {
        public frmTestParameters()
        {
            InitializeComponent();
        }

        void FillDetail(string TestId)
        {
            Validation.Clear(grpParam); 
            dgvTestParameters.Rows.Clear();
            DataTable dt = Query.getData("SELECT * from testparameter where testid = '" + TestId + "' And status!=1 order by to_number(id) ");
            txtCustomHeading.Text = dt.Rows.Count > 0 ? dt.Rows[0]["testparametercustomheading"].ToString() : "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgvTestParameters.Rows.Add(dt.Rows[i]["Id"].ToString(),
                      dt.Rows[i]["Title"].ToString(),
                      dt.Rows[i]["approxresult"].ToString(),
                      dt.Rows[i]["rangenewborn"].ToString(),
                      dt.Rows[i]["range1mto1y"].ToString(),
                      dt.Rows[i]["range1yto14y"].ToString(),
                      dt.Rows[i]["range14yabove"].ToString(),
                      dt.Rows[i]["unit"].ToString(),
                      dt.Rows[i]["IsHeading"].ToString() == "1" ? true : false,
                      dt.Rows[i]["remarks"].ToString()
                      );
            }
        }
        private void frmUserSession_Load(object sender, EventArgs e)
        {
            FillControls.FillcmbLabTest(cmbTest);
        }

        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView dr = (DataRowView)cmbTest.SelectedItem;
            dgvTestParameters.Rows.Clear();
            if (dr != null)
            {
                txtDepartment.Text = dr["HeadTitle"].ToString();
                FillDetail(dr["Id"].ToString());
            }
        }

        private void txtClinicalDiags_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvTestParameters_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvTestParameters.BeginEdit(true);
        }

        private void btnNewParam_Click(object sender, EventArgs e)
        {
            Validation.Clear(grpParam);
        }

        private void dgvTestParameters_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtID.Text = dgvTestParameters[clnId.Index, e.RowIndex].Value.ToString();
                txtTitle.Text = dgvTestParameters[clnTitle.Index, e.RowIndex].Value.ToString();
                txtAppResult.Text = dgvTestParameters[clnApproxResult.Index, e.RowIndex].Value.ToString();
                txtRangeNewBorn.Text = dgvTestParameters[clnRangeNewBorn.Index, e.RowIndex].Value.ToString();
                txtRange1Mto1Y.Text = dgvTestParameters[clnRange1MTo1Y.Index, e.RowIndex].Value.ToString();
                txtRange1Yto14Y.Text = dgvTestParameters[clnRange1yTo14y.Index, e.RowIndex].Value.ToString();
                txtRange14YToAbove.Text = dgvTestParameters[clnRange14YToAbove.Index, e.RowIndex].Value.ToString();
                txtUnit.Text = dgvTestParameters[clnUnit.Index, e.RowIndex].Value.ToString();
                chkIsHeading.Checked = Convert.ToBoolean(dgvTestParameters[clnIsHeading.Index, e.RowIndex].Value);
                txtremarks.Text = dgvTestParameters[clnRemarks.Index, e.RowIndex].Value.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to save this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DML.testreportparameter_add_edit(txtID.Text, txtTitle.Text, txtAppResult.Text, txtRangeNewBorn.Text, txtRange1Mto1Y.Text, txtRange1Yto14Y.Text, txtRange14YToAbove.Text, txtUnit.Text, txtremarks.Text, (string )cmbTest.SelectedValue  , txtCustomHeading.Text, chkIsHeading.Checked ? "1" : "0", UserInfo.UserId, "0"); 
                MessageBox.Show("Record Successfully Saved..!");

            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Field is required");
                return;
            }
            else
                if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to Delete this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataTable dt = Query.getData("update testparameter set status=1 where id='" + txtID.Text+"' And testid='"+cmbTest.SelectedValue.ToString()+"'" );
                    MessageBox.Show("Record deleted successfully!");

                }
            
           
        }
    }




}

