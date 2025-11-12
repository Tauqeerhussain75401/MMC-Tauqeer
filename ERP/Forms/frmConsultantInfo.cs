using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Oracle.DataAccess.Client;
using System.Globalization;



namespace ERP
{
    public partial class frmConsultantInfo : Form
    {
        public frmConsultantInfo()
        {
            InitializeComponent();
            FillControls.FillcmbTestCatagory(cmbType);
            FillControls.FillcmbTestCatagory(cmbType2);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            FillQuery();
            fillActiveConsultant();
            cmbCharges.Enabled = false;
            fillSurgery();
        }
        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            if (dtQuery == null)
            {
                return;
            }
            string search = tb_search.Text.Trim().Replace("'", "'");

            DataView dv = new DataView(dtQuery);
            string filter = $"CONVERT(ID, 'System.String') LIKE '%{search}%' OR name LIKE '%{search}%'";

            if (!string.IsNullOrEmpty(cmbType2.Text) && cmbType2.SelectedIndex > 0)
            {
                filter += $" AND testtypeid = {cmbType2.SelectedValue}";
            }
            dv.RowFilter = filter;
            dgvDetail.DataSource = dv;
            if (string.IsNullOrWhiteSpace(tb_search.Text) && (string.IsNullOrWhiteSpace(cmbType2.Text) || cmbType2.SelectedIndex < 1))
            {
                FillQuery();
            }
        }
        private void tb_search_surgery_TextChanged(object sender, EventArgs e)
        {
            if(dtSurgery == null)
            {
                return;
            }
            string search = tb_search_surgery.Text.Trim().Replace("'", "'");
            
            DataView dv = new DataView(dtSurgery);
            dv.RowFilter = $"CONVERT(package_id, 'System.String') LIKE '%{search}%' OR packagename_name LIKE '%{search}%'";
            dgvSurgery.DataSource = dv;
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtConsultantName.Text == "" || numConsultantCharges.Value <= 0 || cmbType.SelectedValue == null)
            {
                MessageBox.Show("Please Enter Fields");
                return;
            }
            if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to save this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvSurgery.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells[clnChk.Index].Value);
                    if (isSelected)
                    {
                        DML.addSurgeryDetails(txtConsultantid.Text, Convert.ToString(row.Cells[clnIdSurgery.Index].Value), Convert.ToString(row.Cells[clnConsultantShare.Index].Value), Convert.ToString(row.Cells[clnHospCharges.Index].Value));
                    }

                }

                string RetId = txtConsultantid.Text;
                DML.consultant_add_edit(txtConsultantid.Text, txtConsultantName.Text, txtAddress.Text,
                                        txtTelephone.Text, txtFax.Text, txtMobilenumber.Text,
                                        txtEmail.Text, numConsultantCharges.Text, txtDegrees.Text, //nudHosInPatient
                                        txtTiming.Text, txtFaculty.Text, cmbType.SelectedValue.ToString(),
                                        nudHosOutPatient.Value.ToString(), nudConOutPatient.Value.ToString(),
                                        nudConInPatient.Value.ToString(), nudHosInPatient.Value.ToString(),
                                        chkDeactivate.Checked == true ? "1" : "0", ref RetId);
                DataTable dt = Query.ConsultantDetail(RetId);
                DataRow dr = dtQuery.Select("id = '" + dt.Rows[0]["id"].ToString() + "'").FirstOrDefault();
                if (dr != null)
                    dtQuery.Rows.Remove(dr);
                dtQuery.ImportRow(dt.Rows[0]);

            }
            MessageBox.Show("Record Successfully Saved..!");
            //this.FillQuery();
            btnNew.Focus();
        }

        DataTable dtQuery;
        DataTable dtSurgery;
        DataTable dtConsultantFaculty;

        void consultantCategoryFill()
        {
            DataView view = new DataView(dtConsultantFaculty);
            DataTable distinctTable = view.ToTable(true, "faculty");

            // Add a default row at the top
            DataRow newRow = distinctTable.NewRow();
            newRow["faculty"] = "All";
            distinctTable.Rows.InsertAt(newRow, 0);

            cmbType2.DataSource = distinctTable;
            cmbType2.DisplayMember = "ColumnName";
            cmbType2.ValueMember = "ColumnName";
        }
        void FillQuery()
        {
            if (dgvDetail.Rows.Count > 0)
            {
                dgvDetail.AutoGenerateColumns = false;
                dtQuery = Query.ConsultantIndexAll();
                dtSurgery = Query.surgeryAll();
                
                dgvDetail.Columns[clnID.Index].DataPropertyName = "id";
                dgvDetail.Columns[clnName.Index].DataPropertyName = "name";
                dgvDetail.Columns[clnMobile.Index].DataPropertyName = "mobile";
                dgvDetail.Columns[clnHospitalRate.Index].DataPropertyName = "hospitalrate";
                dgvDetail.Columns[clnDegrees.Index].DataPropertyName = "degrees";
                dgvDetail.Columns[clnTimings.Index].DataPropertyName = "timings";
                dgvDetail.Columns[clnFaculty.Index].DataPropertyName = "faculty";
                dgvDetail.Columns[clnisDeactivate.Index].DataPropertyName = "isdeactivate";
                dgvDetail.DataSource = dtQuery;

                cmbConsultant.DataSource = dtQuery;
                cmbConsultant.DisplayMember = "name";
                cmbConsultant.ValueMember = "id";

               

                //cmbSurgery.DataSource = dtSurgery;
                //cmbSurgery.DisplayMember = "packagename_name";
                //cmbSurgery.ValueMember = "package_id";

                cmbCharges.DataSource = dtSurgery;
                cmbCharges.DisplayMember = "amount";
                cmbCharges.ValueMember = "package_id";
            }
            else
            {
                dgvDetail.Rows.Clear();
                dgvDetail.AutoGenerateColumns = false;
                dtQuery = Query.ConsultantIndexAll();
                dtSurgery = Query.surgeryAll();
                dgvDetail.Columns[clnID.Index].DataPropertyName = "id";
                dgvDetail.Columns[clnName.Index].DataPropertyName = "name";
                dgvDetail.Columns[clnMobile.Index].DataPropertyName = "mobile";
                dgvDetail.Columns[clnHospitalRate.Index].DataPropertyName = "hospitalrate";
                dgvDetail.Columns[clnDegrees.Index].DataPropertyName = "degrees";
                dgvDetail.Columns[clnTimings.Index].DataPropertyName = "timings";
                dgvDetail.Columns[clnFaculty.Index].DataPropertyName = "faculty";
                dgvDetail.Columns[clnisDeactivate.Index].DataPropertyName = "isdeactivate";
                dgvDetail.DataSource = dtQuery;

                cmbConsultant.DataSource = dtQuery;
                cmbConsultant.DisplayMember = "name";
                cmbConsultant.ValueMember = "id";

                //cmbSurgery.DataSource = dtSurgery;
                //cmbSurgery.DisplayMember = "packagename_name";
                //cmbSurgery.ValueMember = "package_id";

                cmbCharges.DataSource = dtSurgery;
                cmbCharges.DisplayMember = "amount";
                cmbCharges.ValueMember = "package_id";
            }
        }

        void fillSurgery()
        {

            //  dgvSurgery.Rows.Clear();
            dgvSurgery.AutoGenerateColumns = false;

            dtSurgery = Query.surgeryAll();
            dgvSurgery.Columns[clnIdSurgery.Index].DataPropertyName = "package_id";
            dgvSurgery.Columns[clnSurgeryName.Index].DataPropertyName = "packagename_name";
            dgvSurgery.Columns[clnAmount.Index].DataPropertyName = "amount";
            dgvSurgery.Columns[clnChk.Index].DataPropertyName = "SCheck";
            dgvSurgery.Columns[clnConsultantShare.Index].DataPropertyName = "consulShare";
            dgvSurgery.Columns[clnHospCharges.Index].DataPropertyName = "hospShare";
            dgvSurgery.DataSource = dtSurgery;

        }

        void fillActiveConsultant() // Work by Usman for Showing the active consultant
        {
            DataTable dt = Query.MasterQueryEC("SELECT Count(*) AS total FROM consultant WHERE isdeactivate = 0\r\n\r\n");
            string  number = dt.Rows[0]["total"].ToString(); 
            tb_activeNumber.Text = $"Number of Active Consultant : {number}";
        }
        internal void FillDetail(string ID)
        {
            DataTable dt;
            dt = Query.ConsultantDetail(ID);
            /////////////////////
            txtConsultantid.Text = ID;
            if (dt.Rows.Count > 0)
            {
                chkDeactivate.Checked = dt.Rows[0]["isdeactivate"].ToString() == "0" ? false : true;
                txtConsultantName.Text = dt.Rows[0]["name"].ToString();
                txtDegrees.Text = dt.Rows[0]["degrees"].ToString();
                txtTiming.Text = dt.Rows[0]["timings"].ToString();
                txtFaculty.Text = dt.Rows[0]["faculty"].ToString();
                txtAddress.Text = dt.Rows[0]["address"].ToString();
                txtMobilenumber.Text = dt.Rows[0]["mobile"].ToString();
                txtMobilenumber.Text = dt.Rows[0]["tel"].ToString();
                txtTelephone.Text = dt.Rows[0]["tel"].ToString();
                txtFax.Text = dt.Rows[0]["fax"].ToString();
                txtEmail.Text = dt.Rows[0]["email"].ToString();
                numConsultantCharges.Value = (Decimal)dt.Rows[0]["hospitalrate"];
                nudConInPatient.Value = Convert.ToDecimal(dt.Rows[0]["consultantshareindoor"]);
                nudConOutPatient.Value = Convert.ToDecimal(dt.Rows[0]["consultantshareoutdoor"]);
                nudHosInPatient.Value = Convert.ToDecimal(dt.Rows[0]["hospitalshareindoor"]);
                nudHosOutPatient.Value = Convert.ToDecimal(dt.Rows[0]["hospitalshareoutdoor"]);
                cmbType.SelectedValue = Convert.ToDecimal(dt.Rows[0]["testtypeid"]);

                if (Convert.ToString(dt.Rows[0]["package_id"]) != "")
                {
                    dt.Rows.Cast<DataRow>().ToList().ForEach(fe =>
                {
                    var getRow = dtSurgery.Rows.Cast<DataRow>().Where(w => Convert.ToString(w["package_id"]) == Convert.ToString(fe["package_id"])).ToList();
                    getRow[0]["consulShare"] = fe["consulShare"];
                    getRow[0]["hospShare"] = fe["hospShare"];
                    getRow[0]["SCheck"] = "1";
                });
                    chkShowAllSurgery.Checked = false;
                }
                else
                {
                    dtSurgery.Rows.Cast<DataRow>().ToList().ForEach(fe =>
                    {
                        fe["consulShare"] = "";
                        fe["hospShare"] = "";
                        fe["SCheck"] = "0";
                    });
                    chkShowAllSurgery.Checked = true;
                    //dgvSurgery.Rows.Cast<DataGridViewRow>().ToList().ForEach(fe => fe.Visible = true);
                }
                ////if (dt.Rows[0]["package_id"] == DBNull.Value || dt.Rows[0]["package_id"] == null || String.IsNullOrWhiteSpace(dt.Rows[0]["package_id"].ToString()))
                ////{
                ////    fillSurgery();
                ////}
                ////else
                ////{
                ////    dgvSurgery.AutoGenerateColumns = false;
                ////    dgvSurgery.DataSource = dt;
                ////    dgvSurgery.Columns[clnIdSurgery.Index].DataPropertyName = "package_id";
                ////    dgvSurgery.Columns[clnChk.Index].DataPropertyName = "surExist";
                ////    dgvSurgery.Columns[clnSurgeryName.Index].DataPropertyName = "packagename_name";
                ////    dgvSurgery.Columns[clnAmount.Index].DataPropertyName = "amount";
                ////    dgvSurgery.Columns[clnConsultantShare.Index].DataPropertyName = "consulShare";
                ////    dgvSurgery.Columns[clnHospCharges.Index].DataPropertyName = "hospShare";
                ////
                ////}
            }
        }

        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
                FillDetail(dgvDetail.Rows[e.RowIndex].Cells[clnID.Index].Value.ToString());
        }

        private void numConsultantCharges_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Validation.Clear(this);
        }
        string cmbshare;
        double consShare;
        double hospShare;
 
        public void CalCoNshare()
        {
            consShare = Convert.ToDouble(cmbshare) * 0.75;

        }
        public void HospShare()
        {
            hospShare = Convert.ToDouble(cmbshare) - Convert.ToDouble(txtShare.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            //if(txtShare.Text=="")
            ////{
            ////    txtShare.Text = "0";
            ////}
            //try
            //{
            //    if (rdoAmount.Checked == true)
            //    {

            //        CalCoNshare();
            //        HospShare();
            //        txtHospShare.Text = Convert.ToString(hospShare);
            //        if (Convert.ToDouble(txtShare.Text) > consShare)
            //        {
            //            MessageBox.Show("Consultant share cannot exceed 75%", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            txtShare.Text = "";
            //            txtHospShare.Text = "";
            //        }
            //    }
            //    if (rdoPercent.Checked == true)
            //    {
            //        if (Convert.ToDouble(txtShare.Text) > 75)
            //        {
            //            MessageBox.Show("Consultant share cannot exceed 75%", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            txtShare.Text = "";
            //            txtHospShare.Text = "";
            //        }
            //        else
            //        {
            //            percent = Convert.ToDouble(txtShare.Text) / 100;
            //            percentAmount = Convert.ToDouble(cmbshare) * percent;
            //            percentHospShare = Convert.ToDouble(cmbshare) - percentAmount;
            //            txtHospShare.Text = Convert.ToString(percentHospShare);
            //        }

            //    }

            //}
            //catch
            //{

            //    txtShare.Text = "";
            //    txtHospShare.Text = "";
            //}
        }

        private void cmbCharges_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbshare = cmbCharges.Text;
        }

        private void rdoPercent_CheckedChanged(object sender, EventArgs e)
        {
            txtShare.Clear();
            txtHospShare.Clear();
        }

        private void rdoAmount_CheckedChanged(object sender, EventArgs e)
        {
            txtShare.Clear();
            txtHospShare.Clear();
        }

        private void dgvSurgery_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var textbox = e.Control as TextBox;

            textbox.KeyPress += new KeyPressEventHandler(textbox_KeyPress);
            textbox.Validated += new EventHandler(textbox_Validated);
        }
        void textbox_Validated(object sender, EventArgs e)
        {
            try
            {
                if (dgvSurgery.CurrentRow.Cells[dgvSurgery.CurrentCell.ColumnIndex].Value.ToString().Contains("%"))
                {
                    double newValue = Convert.ToDouble(dgvSurgery.CurrentRow.Cells[dgvSurgery.CurrentCell.ColumnIndex].Value.ToString().Replace("%", ""));
                    if (newValue > 75)
                    {
                        MessageBox.Show("Consultant share shouldn't exceed 75%, Please enter again", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dgvSurgery.CurrentRow.Cells[dgvSurgery.CurrentCell.ColumnIndex].Value = "";
                        
                    }
                    else
                    {
                        //  double withoutPercent = Convert.ToDouble(dgvSurgery.CurrentRow.Cells[dgvSurgery.CurrentCell.ColumnIndex].Value);
                        double percentValueNoround = newValue / 100;
                        double percentValue = Math.Round(percentValueNoround, 4);
                        double calcPercentamtNoround = Convert.ToDouble(dgvSurgery.CurrentRow.Cells[3].Value) * percentValue;
                        double calcPercentamt = Math.Round(calcPercentamtNoround, 2);
                        dgvSurgery.CurrentRow.Cells[4].Value = calcPercentamt;
                        dgvSurgery.CurrentRow.Cells[5].Value = Convert.ToDouble(dgvSurgery.CurrentRow.Cells[3].Value) - calcPercentamt;

                        //  Convert.ToDouble(dgvSurgery.CurrentRow.Cells[4].Value) = Convert.ToDouble(dgvSurgery.CurrentRow.Cells[2].Value)

                        //percent = Convert.ToDouble(txtShare.Text) / 100;
                        //percentAmount = Convert.ToDouble(cmbshare) * percent;
                        //percentHospShare = Convert.ToDouble(cmbshare) - percentAmount;
                    }
                }
                else
                {
                    double amount = Convert.ToDouble(dgvSurgery.CurrentRow.Cells[3].Value);
                    string abc = Convert.ToString(dgvSurgery.CurrentRow.Cells[dgvSurgery.CurrentCell.ColumnIndex].Value);
                    double calcAmount = amount * 0.75;
                    if (Convert.ToDouble(dgvSurgery.CurrentRow.Cells[dgvSurgery.CurrentCell.ColumnIndex].Value) > calcAmount)
                    {
                        MessageBox.Show("Consultant share is exceeding 75% of the amount,please enter again.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dgvSurgery.CurrentRow.Cells[dgvSurgery.CurrentCell.ColumnIndex].Value = "";
                        return;
                    }
                    else
                    {
                        dgvSurgery.CurrentRow.Cells[5].Value = amount - Convert.ToDouble(abc);
                    }
                }
            }
            catch
            {

            }
        }
        void textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 37 && e.KeyChar != 8 &&

                            e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                            e.KeyChar != 9)
            {
                MessageBox.Show("Invalid character '" + e.KeyChar +

                    "' Only keys 0 to 9 and . and % are valid for this field");

                e.Handled = true;
            }
        }
        private void txtShare_Validated(object sender, EventArgs e)
        {

        }

        private void txtShare_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void chkShowAllSurgery_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkShowAllSurgery.Checked == true)
            //{
            //    fillSurgery();
            //}
            if (!chkShowAllSurgery.Checked)
            {
                CurrencyManager cmdgv = (CurrencyManager)BindingContext[dgvSurgery.DataSource];
                cmdgv.SuspendBinding();
                dgvSurgery.Rows.Cast<DataGridViewRow>().Where(w => Convert.ToString(w.Cells[clnChk.Index].Value) != "1").ToList().ForEach(fe => fe.Visible = false);
                cmdgv.ResumeBinding();
            }
            else
                dgvSurgery.Rows.Cast<DataGridViewRow>().ToList().ForEach(fe => fe.Visible = true);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtQuery == null)
            {
                return;
            }
            string search = tb_search.Text.Trim().Replace("'", "'");

            DataView dv = new DataView(dtQuery);
            string filter = $"testtypeid = {cmbType2.SelectedValue} ";
            if(!string.IsNullOrWhiteSpace(search))
            {
                filter = $"CONVERT(ID, 'System.String') LIKE '%{search}%' OR name LIKE '%{search}%'";


                filter += $" and testtypeid = {cmbType2.SelectedValue} ";
            }
                
            
            dv.RowFilter = filter;
            dgvDetail.DataSource = dv;
            if (string.IsNullOrWhiteSpace(tb_search.Text) && (string.IsNullOrWhiteSpace(cmbType2.Text) || cmbType2.SelectedIndex < 1 ))
            {
                dgvDetail.DataSource = dtQuery;
                cmbConsultant.DataSource = dtQuery;
                //FillQuery();
            }
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void brnPrev_Click(object sender, EventArgs e)
        {
            DataTable resultTable = new DataTable();
            resultTable.Columns.Add("ID", typeof(int));
            resultTable.Columns.Add("Name", typeof(string));
            resultTable.Columns.Add("mobile", typeof(string));
            resultTable.Columns.Add("hospitalrate", typeof(string));
            resultTable.Columns.Add("degrees", typeof(string));
            resultTable.Columns.Add("timings", typeof(string));
            resultTable.Columns.Add("faculty", typeof(string));
            resultTable.Columns.Add("isdeactivate", typeof(int));
            resultTable.Columns.Add("Title", typeof(string));

            DataTable det;
            if (dgvDetail.DataSource is DataView dv1)
                det = dv1.ToTable();
            else
                det = (DataTable)dgvDetail.DataSource;

            DataTable type;
            if (cmbType2.DataSource is DataView dv2)
                type = dv2.ToTable();
            else
                type = (DataTable)cmbType2.DataSource;


            var query = from t1 in det.AsEnumerable()
                        where !string.IsNullOrWhiteSpace(t1["testtypeid"].ToString())
                        join t2 in type.AsEnumerable()
                             .Where(x => Convert.ToInt32(x["id"]) != 0)
                        on t1["testtypeid"].ToString() equals t2["id"].ToString()
                        select new
                        {
                            ID = Convert.ToInt32(t1["ID"]),
                            Name = t1["Name"].ToString(),
                            mobile = t1["mobile"].ToString(),
                            hospitalrate = Convert.ToInt32(t1["hospitalrate"]),
                            degrees = t1["degrees"].ToString(),
                            timings = t1["timings"].ToString(),
                            faculty = t1["faculty"].ToString(),
                            isdeactivate = Convert.ToInt32(t1["isdeactivate"]),
                            Title = t2["Title"].ToString()
                        };

            foreach (var row in query)
            {
                resultTable.Rows.Add(row.ID, row.Name, row.mobile, row.hospitalrate,
                                     row.degrees, row.timings, row.faculty,
                                     row.isdeactivate, row.Title);
            }

            
            //resultTable.DefaultView.Sort = "ID ASC";
            //resultTable = resultTable.DefaultView.ToTable();
            

            frmReportView frm = new frmReportView();
            Reports.ConsultantIndex rpt = new Reports.ConsultantIndex();
            rpt.SetDataSource(resultTable);
            frm.rptViewer.ReportSource = rpt;
            frm.Show();
        }
    }
}
