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
    public partial class frmInPatientSearch : Form
    {
        public frmInPatientSearch()
        {
            InitializeComponent();
            FillControls.FillcmbRoomindex(cmbRoomtype);
            FillControls.FillcmbCunsultant(cmbConsultant);
            cmbRoomtype.SelectedIndex = 0;
            cmbRoomtype.Enabled = false;

            dtpDateFromAdm.Value = SoftwareInfo.ServerDate.AddMonths(-6); //DateTime.Now;
            dtpDateToAdm.Value = SoftwareInfo.ServerDate; //DateTime.Now;
            dtpDisDateFrom.Value = SoftwareInfo.ServerDate; //DateTime.Now;
            dtpDisDateTo.Value = SoftwareInfo.ServerDate; //DateTime.Now;
            rdoAdmRangeFrom.Checked = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //string admdate=!rdbAdmAll.Checked?"and trunc(admdate) between'"+dtpDateFromAdm.Value.ToDBFormat()+"' and '"+dtpDateToAdm.Value.ToDBFormat()+"'":"";
            //string dischargedate=!rdoDisAll.Checked?"and trunc(dischargedate) between'"+dtpDisDateFrom.Value.ToDBFormat()+"' and '"+dtpDisDateTo.Value.ToDBFormat()+"'":"";
            //string admittedChecked = rdoAdmitted.Checked ? "0" : "1";
            //string admitted = "and dischargeyn='" + admittedChecked + "'";
            //string room=!rdoRoomAll.Checked?"and roomid='"+(string)cmbRoomtype.SelectedValue+"'":"";
            //string consultant = !rdoConsultantAll.Checked ? "and consultantid='"+(string)cmbConsultant.SelectedValue+"'" : "";
            //string patientname = txtPatientName.Text != "" ? " and lower(patientname) like '%" + txtPatientName.Text.ToLower() + "%'" : "";
            //string relationname = txtRelationName.Text != "" ? " and lower(relationname) like '%" + txtRelationName.Text.ToLower() + "%'" : "";
            //string contactno = txtContactNo.Text != "" ? " and lower(emergency) like '%" + txtContactNo.Text.ToLower() + "%'" : "";

            //FillDetail(new string[] {
            //admdate,dischargedate,admitted,room,consultant,patientname,relationname,contactno
            
            //});

            GridLoad();
        }

        private void GridLoad()
       {
            string admdate = !rdbAdmAll.Checked ? "and trunc(admdate) between'" + dtpDateFromAdm.Value.ToDBFormat() + "' and '" + dtpDateToAdm.Value.ToDBFormat() + "'" : "";
            string dischargedate = !rdoDisAll.Checked ? "and trunc(dischargedate) between'" + dtpDisDateFrom.Value.ToDBFormat() + "' and '" + dtpDisDateTo.Value.ToDBFormat() + "'" : "";
            string admittedChecked = rdoAdmitted.Checked ? "0" : "1";
            string admitted = "and dischargeyn='" + admittedChecked + "'";
            string room = !rdoRoomAll.Checked ? "and roomid='" + (string)cmbRoomtype.SelectedValue + "'" : "";
            string consultant = !rdoConsultantAll.Checked ? "and consultantid='" + (string)cmbConsultant.SelectedValue + "'" : "";
            string patientname = txtPatientName.Text != "" ? " and lower(patientname) like '%" + txtPatientName.Text.ToLower() + "%'" : "";
            string relationname = txtRelationName.Text != "" ? " and lower(relationname) like '%" + txtRelationName.Text.ToLower() + "%'" : "";
            string contactno = txtContactNo.Text != "" ? " and lower(emergency) like '%" + txtContactNo.Text.ToLower() + "%'" : "";

            FillDetail(new string[] {
            admdate,dischargedate,admitted,room,consultant,patientname,relationname,contactno
            
            });
        }

        DataTable dt;
        void FillDetail(string[] filter) 
       {
            dt = Query.InPSearch(filter);
            dgvInPatientSearch.AutoGenerateColumns = false;
            dgvInPatientSearch.DataSource = dt;
        
        
        }

        private void rdbAdmAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAdmAll.Checked)
            {
                dtpDateFromAdm.Enabled = false;
                dtpDateToAdm.Enabled = false;
            }
            else
            {
                dtpDateFromAdm.Enabled = true;
                dtpDateToAdm.Enabled = true;
                GridLoad();
            }
        }

        private void rdoDisAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDisAll.Checked)
            {
                dtpDisDateFrom.Enabled = false;
                dtpDisDateTo.Enabled = false;
            }
            else
            {
                dtpDisDateFrom.Enabled = true;
                dtpDisDateTo.Enabled = true;
            }
        }

        private void rdoRoomAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRoomAll.Checked)
            {
                cmbRoomtype.Enabled = false;
            }
            else
            {
                cmbRoomtype.Enabled = true;
            }
        }

        private void rdoConsultantAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoConsultantAll.Checked)
            {
                cmbConsultant.Enabled = false;
            }
            else
            {
                cmbConsultant.Enabled = true;
            }
        }

        private void frmInPatientSearch_Load(object sender, EventArgs e)
        {

        }

        private void txtPatientName_TextChanged(object sender, EventArgs e)
        {
            
            if (txtPatientName.Text != "")
            {
                
                //dt.DefaultView.RowFilter = "patientname like '%" + txtPatientName.Text + "%'";
                //dgvInPatientSearch.DataSource = dt;

                BindingSource bds = new BindingSource();
                bds.DataSource = dgvInPatientSearch.DataSource;
                bds.Filter = "patientname like '%" + txtPatientName.Text + "%'";
                dgvInPatientSearch.DataSource = bds;
            }
            else if (rdoAdmitted.Checked || rdoDischarged.Checked)
            {
                GridLoad();
            }

        }

        private void txtRelationName_TextChanged(object sender, EventArgs e)
        {
            if (txtPatientName.Text != "")
            {
                //dt.DefaultView.RowFilter = "relationname like '%" + txtPatientName.Text + "%'";
                //dgvInPatientSearch.DataSource = dt;

                BindingSource bds = new BindingSource();
                bds.DataSource = dgvInPatientSearch.DataSource;
                bds.Filter = "relationname like '%" + txtPatientName.Text + "%'";
                dgvInPatientSearch.DataSource = bds;
            }
            else if (rdoAdmitted.Checked || rdoDischarged.Checked)
            {
                GridLoad();
            }
        }

        private void txtContactNo_TextChanged(object sender, EventArgs e)
        {
            if (txtPatientName.Text != "")
            {
                //dt.DefaultView.RowFilter = "emergency like '%" + txtPatientName.Text + "%'";
                //dgvInPatientSearch.DataSource = dt;

                BindingSource bds = new BindingSource();
                bds.DataSource = dgvInPatientSearch.DataSource;
                bds.Filter = "emergency like '%" + txtPatientName.Text + "%'";
                dgvInPatientSearch.DataSource = bds;
            }
            else if (rdoAdmitted.Checked || rdoDischarged.Checked)
            {
                GridLoad();
            }
        }

        

       
       

      
    }
}
