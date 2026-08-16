using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ERP.Forms
{
    public partial class EchoCardioGraphy : Form
    {
        public EchoCardioGraphy()
        {
            InitializeComponent();
            FillControls.FillcmbTemplateIndexEcho(cmbTemplate);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EchoCardioGraphy_Load(object sender, EventArgs e)
        {
            cmbIpdOpd.SelectedIndex = 1;
            FillQuery();

            if (UserInfo.UserLevel == "Admin")
            {
                dtpIssueDate.Enabled = true;
                dtpIssueDate.BackColor = Color.White; 
            }
            else
            {
                dtpIssueDate.Enabled = false;
                dtpIssueDate.BackColor = Color.LightGray;
                RpatientInfo.ReadOnly = true;
            }
            if (txtReportNo.Text == string.Empty)
            {
                btnPrint.Enabled = false;
            }

            txtSlipNo.Focus();
        }

        private void txtSlipNo_Validated(object sender, EventArgs e)
        {
            if (cmbIpdOpd.SelectedIndex == 1)
            {
                LoadPatientInfoOPD();
            }
            else if (cmbIpdOpd.SelectedIndex == 0)
            {
                LoadPatientInfoIPD();
            }
        }

        void LoadPatientInfoIPD()
        {
            DataTable dt = Query.IPDAdmissioninfo(txtSlipNo.Text);
            if (dt.Rows.Count > 0)
            {
                string slipDate = ((DateTime)dt.Rows[0]["receiptdate"]).ToString("dd-MMM-yyyy");
                string patientName = dt.Rows[0]["title"].ToString() + " " + dt.Rows[0]["patientname"].ToString();
                string age = dt.Rows[0]["age"].ToString() + " " + dt.Rows[0]["ymd"].ToString();
                string gender = dt.Rows[0]["gender"].ToString();
                string contact = dt.Rows[0]["emergency"].ToString();

                RpatientInfo.Text = $"Patient Name: {patientName}\n" +
                      $"Age: {age} | Gender: {gender}\n" +
                      $"Contact: {contact}\n" +
                      $"Slip Date: {slipDate}";

                decimal ageValue = 0;
                decimal.TryParse(dt.Rows[0]["age"].ToString(), out ageValue);

                string ymd = dt.Rows[0]["ymd"].ToString();

                if (ymd == "Year" && ageValue > 15)
                {
                    cmbType.SelectedIndex = 0; // Adult
                }
                else
                {
                    cmbType.SelectedIndex = 1; // Child
                }
            }
            else
            {
                RpatientInfo.Text = "";
            }
        }

        void LoadPatientInfoOPD()
        {
            if (txtSlipNo.Text == "")
            {
                return;
            }
            DataTable dt = Query.OPDReceiptDetail(txtSlipNo.Text);
            if (dt.Rows.Count > 0)
            {
                string pName = dt.Rows[0]["patienttitle"].ToString() + " " + dt.Rows[0]["patientname"].ToString();

                decimal ageValue = 0;
                decimal.TryParse(dt.Rows[0]["age"].ToString(), out ageValue);

                string ageUnit = dt.Rows[0]["ageunit"].ToString();
                string pAge = ageValue + " " + ageUnit;

                string pGender = dt.Rows[0]["gender"].ToString();
                string pContact = dt.Rows[0]["contactno"].ToString();
                string pDate = ((DateTime)dt.Rows[0]["Vdate"]).ToString("dd-MMM-yyyy");

                RpatientInfo.Text = $"Patient Name: {pName}\n" +
                                    $"Age: {pAge} | Gender: {pGender}\n" +
                                    $"Contact: {pContact}\n" +
                                    $"Slip Date: {pDate}";

                if (ageUnit == "Year" && ageValue > 15)
                {
                    cmbType.SelectedIndex = 0; // Adult
                }
                else
                {
                    cmbType.SelectedIndex = 1; // Child
                }
            }
        }

        Font SelectionFont;
        private void btnBold_Click(object sender, EventArgs e)
        {
            FontStyle style = (tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).SelectionFont.Style;
            if ((tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).SelectionFont.Bold)
            {
                style &= ~FontStyle.Bold;
                btnBold.BackColor = Color.LightGray;
            }
            else
            {
                style |= FontStyle.Bold;
                btnBold.BackColor = Color.DarkGray;
            }
            (tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).SelectionFont = new Font((tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).SelectionFont, style);
            SelectionFont = (tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).SelectionFont;
            (tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).Focus();
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            FontStyle style = (tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).SelectionFont.Style;
            if ((tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).SelectionFont.Italic)
            {
                style &= ~FontStyle.Italic;
                btnItalic.BackColor = Color.LightGray;
            }
            else
            {
                style |= FontStyle.Italic;
                btnItalic.BackColor = Color.DarkGray;
            }
            (tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).SelectionFont = new Font((tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).SelectionFont, style);
            SelectionFont = (tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).SelectionFont;
            (tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).Focus();
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            FontStyle style = (tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).SelectionFont.Style;
            if ((tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).SelectionFont.Underline)
            {
                style &= ~FontStyle.Underline;
                btnUnderline.BackColor = Color.LightGray;
            }
            else
            {
                style |= FontStyle.Underline;
                btnUnderline.BackColor = Color.DarkGray;
            }
            (tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).SelectionFont = new Font((tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).SelectionFont, style);
            SelectionFont = (tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).SelectionFont;
            (tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).Focus();
        }

        private void btnFontColor_Click(object sender, EventArgs e)
        {
            ColorDialog ColorDlg = new ColorDialog();
            if (ColorDlg.ShowDialog() == DialogResult.OK)
            {
                (tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).SelectionColor = ColorDlg.Color;
            }
        }

        private void btnFontStyle_Click(object sender, EventArgs e)
        {
            FontDialog FontDlg = new FontDialog();
            if (FontDlg.ShowDialog() == DialogResult.OK)
            {
                (tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).SelectionFont = FontDlg.Font;
            }
            SelectionFont = (tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).SelectionFont;
            (tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).Focus();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            btnLeft.BackColor = Color.LightGray;
            btnCentre.BackColor = Color.LightGray;
            btnRight.BackColor = Color.LightGray;
            if ((tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).SelectionAlignment != HorizontalAlignment.Left)
            {
                btnLeft.BackColor = Color.LightGray;
            }
            else
            {
                btnLeft.BackColor = Color.DarkGray;
            }
            (tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).SelectionAlignment = HorizontalAlignment.Left;
            (tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).Focus();
        }

        private void btnCentre_Click(object sender, EventArgs e)
        {
            if ((tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).SelectionAlignment != HorizontalAlignment.Center)
            {
                btnCentre.BackColor = Color.LightGray;
            }
            else
            {
                btnCentre.BackColor = Color.DarkGray;
            }
            (tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).SelectionAlignment = HorizontalAlignment.Center;
            (tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).Focus();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if ((tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).SelectionAlignment != HorizontalAlignment.Right)
            {
                btnCentre.BackColor = Color.LightGray;
            }
            else
            {
                btnCentre.BackColor = Color.DarkGray;
            }
            (tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).SelectionAlignment = HorizontalAlignment.Right;
            (tabControl1.SelectedTab == PgDoc1 ? rtxtDoc : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2 : rtxtDoc3).Focus();
        }

        private void richTextBoxDesc_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private bool ValidatePatientDetails()
        {
            if (string.IsNullOrWhiteSpace(RpatientInfo.Text))
            {
                MessageBox.Show("Report content is empty. Please generate or enter report details.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                RpatientInfo.Focus();
                return false;
            }
            return true; 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidatePatientDetails())
                return;

            if (txtReportNo.Text == string.Empty)
            {
                string sql = "SELECT * FROM echocardiography WHERE slipno = '" + txtSlipNo.Text + "'";
                DataTable dt = Query.getData(sql);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Slip already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to save this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string text = RpatientInfo.Text;

                var nameMatch = System.Text.RegularExpressions.Regex.Match(text, @"Patient Name:\s*(.*)");
                var ageMatch = System.Text.RegularExpressions.Regex.Match(text, @"Age:\s*([^|]+)");

                string patientName = nameMatch.Groups[1].Value.Trim();
                string age = ageMatch.Groups[1].Value.Trim();

                int? id = string.IsNullOrWhiteSpace(txtReportNo.Text) ? (int?)null : Convert.ToInt32(txtReportNo.Text);
                string height = string.IsNullOrWhiteSpace(txtheight.Text) ? null : txtheight.Text;
                string weight = string.IsNullOrWhiteSpace(txtWeight.Text) ? null : txtWeight.Text;
                int type = cmbIpdOpd.SelectedIndex;

                bool result = DML.cardiography_add_edit(
                    ref id,
                    DateTime.Parse(dtpIssueDate.Text),
                    type,
                    patientName,
                    age,
                    txtSlipNo.Text,
                    "0",
                    "0",
                    height,
                    weight,
                    txtClinicalDiagnose.Text,
                    txtRefPhysician.Text,
                    numericUpDownLVstolic.Text,
                    numericUpDownLVdstolic.Text,
                    numericUpDownLVst.Text,
                    numericUpDownLeftAtrium.Text,
                    numericUpDownRightVentricle.Text,
                    numericUpDownEF.Text,
                    numericUpDownPWT.Text,
                    numericUpDownAortic.Text,
                    numericUpDownAorticValve.Text,
                    rtxtDoc.Rtf,
                    UserInfo.UserId,
                    DateTime.Now,
                    0,
                    UserInfo.UserId,
                    rtxtDoc2.Rtf,
                    rtxtDoc3.Rtf
                );

                if (result)
                {
                    MessageBox.Show("Record Successfully Saved..!");
                    btnPrint.Enabled = true;
                    FillQuery();
                    print();
                    ClearForm();
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            // Clear TextBoxes
            txtReportNo.Clear();
            txtSlipNo.Clear();
            txtClinicalDiagnose.Clear();
            txtRefPhysician.Clear();

            numericUpDownLVstolic.Text = string.Empty;
            numericUpDownLVdstolic.Text = string.Empty;
            numericUpDownLVst.Text = string.Empty;
            numericUpDownLeftAtrium.Text = string.Empty;
            numericUpDownRightVentricle.Text = string.Empty;
            numericUpDownEF.Text = string.Empty;
            numericUpDownPWT.Text = string.Empty;
            numericUpDownAortic.Text = string.Empty;
            numericUpDownAorticValve.Text = string.Empty;

            txtheight.Text = string.Empty;
            txtWeight.Text = string.Empty;

            cmbIpdOpd.SelectedIndex = 1;
            rtxtDoc.Clear();
            rtxtDoc2.Clear();
            rtxtDoc3.Clear();
            btnPrint.Enabled = false;

            RpatientInfo.Text = "";
            dtpIssueDate.Value = DateTime.Now;
            txtSlipNo.Focus();
        }

        void FillQuery()
        {
            dgvQuery.Rows.Clear();
            DataTable dtQuery = new DataTable();
            if (UserInfo.UserLevel == "Admin")
            {
                dtQuery = Query.getData("select * from echocardiography ORDER BY Id DESC");
            }
            else
            {
                dtQuery = Query.getData("select * from echocardiography where status = 0 and createdby = '" + UserInfo.UserId + "' ORDER BY Id DESC");
            }
            foreach (DataRow row in dtQuery.Rows)
            {
                DateTime vdate = row["vdate"] != DBNull.Value ? (DateTime)row["vdate"] : DateTime.MinValue;
                string type = Convert.ToInt32(row["type"]) == 0 ? "IPD" : "OPD";
                dgvQuery.Rows.Add(
                    type,
                    row["slipno"]?.ToString() ?? string.Empty,
                    vdate.ToString("dd MMM yyyy"),
                    row["PatientName"]?.ToString() ?? string.Empty,
                    row["clinical_diagnosis"]?.ToString() ?? string.Empty,
                    row["ref_physician"]?.ToString() ?? string.Empty,
                    row["createdby"]?.ToString() ?? string.Empty,
                    row["createdtime"]?.ToString() ?? string.Empty
                );
            }
            lblTotRecordsFetched.Text = "Total Records : " + dtQuery.Rows.Count.ToString("N0");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            print();
        }
       
        void LoadTemplate()
        {
            string Id = (string)cmbTemplate.SelectedValue;
            DataTable dt = Query.getData("SELECT * FROM DocTemplate WHERE Isecho = 1 and id = '" + Id + "'");
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                numericUpDownLVstolic.Text = row["lv_systolic"].ToString();
                numericUpDownLVdstolic.Text = row["lv_diastolic"].ToString();
                numericUpDownLVst.Text = row["lv_spetal_thickness"].ToString();
                numericUpDownLeftAtrium.Text = row["left_atrium"].ToString();
                numericUpDownRightVentricle.Text = row["right_ventricle"].ToString();
                numericUpDownEF.Text = row["ef"].ToString();
                numericUpDownPWT.Text = row["post_wall_thickness"].ToString();
                numericUpDownAortic.Text = row["aortic"].ToString();
                numericUpDownAorticValve.Text = row["aortic_valve_opening"].ToString();

                if (tabControl1.SelectedTab == PgDoc1)
                    rtxtDoc.Rtf = row["templatedoc"].ToString();
                else if (tabControl1.SelectedTab == PgDoc2)
                    rtxtDoc2.Rtf = row["templatedoc"].ToString();
                else
                    rtxtDoc3.Rtf = row["templatedoc"].ToString();
            }
        }

        private void btnLoadTemplate_Click(object sender, EventArgs e)
        {
            LoadTemplate();
        }

        private void txtSlipNo_Enter(object sender, EventArgs e)
        {
            if (cmbIpdOpd.SelectedIndex == 1)
            {
                LoadPatientInfoOPD();
            }
            else if (cmbIpdOpd.SelectedIndex == 0)
            {
                LoadPatientInfoIPD();
            }
        }

        private void txtSlipNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbIpdOpd.SelectedIndex == 1)
                {
                    LoadPatientInfoOPD();
                }
                else if (cmbIpdOpd.SelectedIndex == 0)
                {
                    LoadPatientInfoIPD();
                }
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            DateTime? fromDate = dtpDateFrom.Value.Date;
            DateTime? toDate = dtpDateTo.Value.Date;

            string patientName = txtSpatientName.Text.Trim();
            string receiptNo = txtSReceiptNo.Text.Trim();

            FillQuery(fromDate, toDate, patientName, receiptNo);
        }

        void FillQuery(DateTime? fromDate = null, DateTime? toDate = null, string patientName = "", string receiptNo = "")
        {
            dgvQuery.Rows.Clear();

            string query = "select * from echocardiography where 1=1 ";
            if (!rdbDateall.Checked)
            {
                query += " and vdate >= TO_DATE('" + fromDate.Value.ToString("yyyy-MM-dd") + "','YYYY-MM-DD')";
                query += " and vdate < TO_DATE('" + toDate.Value.AddDays(1).ToString("yyyy-MM-dd") + "','YYYY-MM-DD')";
            }

            if (!string.IsNullOrWhiteSpace(patientName))
            {
                query += " AND LOWER(patientname) LIKE '%" + patientName.ToLower() + "%'";
            }

            if (!string.IsNullOrWhiteSpace(receiptNo))
            {
                query += " and slipno like '%" + receiptNo + "%'";
            }
            if (ddlType != null)
            {
                if (ddlType.SelectedIndex == 0)
                {
                    query += " and type = '0'";
                }
                else if (ddlType.SelectedIndex == 1)
                {
                    query += " and type = '1'";
                }
            }
            DataTable dtQuery = Query.getData(query);

            foreach (DataRow row in dtQuery.Rows)
            {
                DateTime vdate = row["vdate"] != DBNull.Value ? (DateTime)row["vdate"] : DateTime.MinValue;

                string type = Convert.ToInt32(row["type"]) == 0 ? "IPD" : "OPD";
                dgvQuery.Rows.Add(
                    type,
                    row["slipno"]?.ToString() ?? string.Empty,
                    vdate.ToString("dd MMM yyyy"),
                    row["PatientName"]?.ToString() ?? string.Empty,
                    row["clinical_diagnosis"]?.ToString() ?? string.Empty,
                    row["ref_physician"]?.ToString() ?? string.Empty,
                    row["createdby"]?.ToString() ?? string.Empty,
                    row["createdtime"]?.ToString() ?? string.Empty
                );
            }

            lblTotRecordsFetched.Text = "Total Records : " + dtQuery.Rows.Count.ToString("N0");
        }

        void print()
        {
            frmReportView frm = new frmReportView();
            Reports.Echocardiography rpt = new Reports.Echocardiography();

            string text = RpatientInfo.Text;

            var nameMatch = System.Text.RegularExpressions.Regex.Match(text, @"Patient Name:\s*(.*)");
            var ageMatch = System.Text.RegularExpressions.Regex.Match(text, @"Age:\s*([^|]+)");

            string patientName = nameMatch.Groups[1].Value.Trim();
            string age = ageMatch.Groups[1].Value.Trim();

            rpt.SetParameterValue("@Name", patientName.ToUpper());
            rpt.SetParameterValue("@Age", age);
            if (Convert.ToInt32(cmbIpdOpd.SelectedIndex) == 0)
            {
                string sql = " SELECT * FROM admissioninfo adm left JOIN inptestcharges inp ON inp.serialno  =adm.serialno AND adm.status=0 where  inp.status=0  and receiptno = '"+ txtSlipNo.Text + "' ";
                DataTable dt = Query.getData(sql);

                string regNo = dt.Rows[0]["regnoalpha"].ToString() + "-" +
               dt.Rows[0]["regnonumeric"].ToString() +"  "+"(" + txtSlipNo.Text + ")";

                rpt.SetParameterValue("@RegNo", regNo);
            }
            else
            {
                rpt.SetParameterValue("@RegNo", cmbIpdOpd.Text + "-" + txtSlipNo.Text);
            }
            if (cmbType.SelectedIndex == 0)
            {
                rpt.SetParameterValue("@Headername", "ECHOCARDIOGRAPHY REPORT");
            }
            else
            {
                rpt.SetParameterValue("@Headername", "PEDIATRIC ECHOCARDIOGRAPHY REPORT");
            }
            rpt.SetParameterValue("@Date", dtpIssueDate.Value.ToString("dd-MMM-yyyy hh:mm tt"));
            rpt.SetParameterValue("@Height", txtheight.Text);
            rpt.SetParameterValue("@Weight", txtWeight.Text);
            rpt.SetParameterValue("@ClinicalDiagnosis", txtClinicalDiagnose.Text);
            rpt.SetParameterValue("@ReferencePhysician", txtRefPhysician.Text);
            rpt.SetParameterValue("@LVsystolic", numericUpDownLVstolic.Text);
            rpt.SetParameterValue("@LVdstolic", numericUpDownLVdstolic.Text);
            rpt.SetParameterValue("@LVspetalThickness", numericUpDownLVst.Text);
            rpt.SetParameterValue("@LeftAtrium", numericUpDownLeftAtrium.Text);
            rpt.SetParameterValue("@RightVentricle", numericUpDownRightVentricle.Text);
            rpt.SetParameterValue("@EF", numericUpDownEF.Text);
            rpt.SetParameterValue("@PostWallThickness", numericUpDownPWT.Text);
            rpt.SetParameterValue("@Aortic", numericUpDownAortic.Text);
            rpt.SetParameterValue("@AorticValve", numericUpDownAorticValve.Text);
            rpt.SetParameterValue("@Description", (tabControl1.SelectedTab == PgDoc1 ? rtxtDoc.Rtf : tabControl1.SelectedTab == PgDoc2 ? rtxtDoc2.Rtf : rtxtDoc3.Rtf));
            frm.rptViewer.ReportSource = rpt;
            frm.TopMost = true;
            frm.Show();
        }

        private void dgvQuery_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string slipNo = dgvQuery.Rows[e.RowIndex].Cells[1].Value?.ToString();
            if (string.IsNullOrEmpty(slipNo)) return;

            string sql = "SELECT * FROM echocardiography WHERE slipno = '" + slipNo + "'";
            DataTable dt = Query.getData(sql);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRow row = dt.Rows[0]; 

            txtSlipNo.Text = row["slipno"]?.ToString();
            dtpIssueDate.Value = row["vdate"] != DBNull.Value ? (DateTime)row["vdate"] : DateTime.Now;
            cmbIpdOpd.SelectedIndex = Convert.ToInt32(row["Type"]) == 0 ? 0 : 1;
            txtheight.Text = row["height"].ToString(); 
            txtWeight.Text = row["weight"].ToString(); 
            txtClinicalDiagnose.Text = row["clinical_diagnosis"]?.ToString();
            txtRefPhysician.Text = row["ref_physician"]?.ToString();
            numericUpDownLVstolic.Text = row["lv_systolic"].ToString();
            numericUpDownLVdstolic.Text = row["lv_diastolic"].ToString();
            numericUpDownLVst.Text = row["lv_spetal_thickness"].ToString();
            numericUpDownLeftAtrium.Text = row["left_atrium"].ToString();
            numericUpDownRightVentricle.Text = row["right_ventricle"].ToString();
            numericUpDownEF.Text = row["ef"].ToString();
            numericUpDownPWT.Text = row["post_wall_thickness"].ToString();
            numericUpDownAortic.Text = row["aortic"].ToString();
            numericUpDownAorticValve.Text = row["aortic_valve_opening"].ToString();
            rtxtDoc.Rtf = row["description"]?.ToString() ?? string.Empty;
            rtxtDoc2.Rtf = row["description1"]?.ToString() ?? string.Empty;
            rtxtDoc3.Rtf = row["description2"]?.ToString() ?? string.Empty;
            txtReportNo.Text = row["id"]?.ToString();
            txtSlipNo_Validated(txtSlipNo, EventArgs.Empty);
            tabDetailQuery.SelectedTab = tabpgDetail;
            btnPrint.Enabled = true;
        }

        private void rdbDateall_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDateall.Checked)
            {
                dtpDateFrom.Enabled = false;
                dtpDateTo.Enabled = false;
            }
            else
            {
                dtpDateFrom.Enabled = true;
                dtpDateTo.Enabled = true;
            }
        }
    }
}
