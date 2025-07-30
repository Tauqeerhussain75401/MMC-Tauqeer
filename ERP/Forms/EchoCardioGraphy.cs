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
            FillControls.FillcmbTemplateIndex(cmbTemplate);
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
                dtpIssueDate.BackColor = Color.White;  // White background for enabled DateTimePicker
            }
            else
            {
                dtpIssueDate.Enabled = false;
                dtpIssueDate.BackColor = Color.LightGray;  // Gray background for disabled DateTimePicker
            }

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
                txtSlipDate.Text = ((DateTime)dt.Rows[0]["receiptdate"]).ToString("dd-MMM-yyyy");
                txtPatientName.Text = dt.Rows[0]["title"].ToString() + dt.Rows[0]["patientname"].ToString();
                txtAge.Text = dt.Rows[0]["age"].ToString() + " " + dt.Rows[0]["ymd"].ToString();
                txtGender.Text = dt.Rows[0]["gender"].ToString();
                txtcontact.Text = dt.Rows[0]["mobile"].ToString();
            }
            else
            {
                MessageBox.Show("Slip number not found. Please check and try again.", "Invalid Slip No", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReportNo.Text = "";
                txtSlipDate.Text = "";
                txtPatientName.Text = "";
                txtAge.Text = "";
                txtGender.Text = "";
                txtcontact.Text = "";
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
                txtSlipDate.Text = ((DateTime)dt.Rows[0]["Vdate"]).ToString("dd-MMM-yyyy");
                txtPatientName.Text = dt.Rows[0]["patienttitle"].ToString() + dt.Rows[0]["patientname"].ToString();
                txtAge.Text = dt.Rows[0]["age"].ToString() + " " + dt.Rows[0]["ageunit"].ToString();
                txtGender.Text = dt.Rows[0]["gender"].ToString();
                txtcontact.Text = dt.Rows[0]["contactno"].ToString();
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

            //if (e.KeyCode == Keys.Enter)
            //{
            //    // Use BeginInvoke to wait until the new line is created
            //    this.BeginInvoke((MethodInvoker)delegate
            //    {
            //        // Reset formatting (font, color, alignment)
            //        richTextBoxDesc.SelectionFont = richTextBoxDesc.Font; // default font
            //        richTextBoxDesc.SelectionColor = richTextBoxDesc.ForeColor; // default color
            //        richTextBoxDesc.SelectionAlignment = HorizontalAlignment.Left; // default alignment
            //    });
            //}

        }

        private bool ValidatePatientDetails()
        {
            if (string.IsNullOrWhiteSpace(txtPatientName.Text))
            {
                MessageBox.Show("Please enter the patient's name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPatientName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtClinicalDiagnose.Text))
            {
                MessageBox.Show("Please enter the clinical diagnosis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClinicalDiagnose.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtRefPhysician.Text))
            {
                MessageBox.Show("Please enter the referring physician's name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRefPhysician.Focus();
                return false;
            }
            return true; 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidatePatientDetails())
                return;

            if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to save this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int? id = string.IsNullOrWhiteSpace(txtReportNo.Text) ? (int?)null : Convert.ToInt32(txtReportNo.Text);
                bool result = DML.cardiography_add_edit(
                ref id,
                DateTime.Parse(dtpIssueDate.Text),
                Convert.ToInt32(cmbIpdOpd.SelectedValue),
                txtPatientName.Text,
                txtAge.Text,
                txtSlipNo.Text,
                "0",
                "0",
                Convert.ToDecimal(txtheight.Text),
                Convert.ToDecimal(txtWeight.Text),
                txtClinicalDiagnose.Text,
                txtRefPhysician.Text,
                Convert.ToDecimal(numericUpDownLVstolic.Text),
                Convert.ToDecimal(numericUpDownLVdstolic.Text),
                Convert.ToDecimal(numericUpDownLVst.Text),  
                Convert.ToDecimal(numericUpDownLeftAtrium.Text),
                Convert.ToDecimal(numericUpDownRightVentricle.Text),
                Convert.ToDecimal(numericUpDownEF.Text),
                Convert.ToDecimal(numericUpDownPWT.Text),
                Convert.ToDecimal(numericUpDownAortic.Text),
                Convert.ToDecimal(numericUpDownAorticValve.Text),
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
                    FillQuery();
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

            // Reset NumericUpDowns
            numericUpDownLVstolic.Text = string.Empty;
            numericUpDownLVdstolic.Text = string.Empty;
            numericUpDownLVst.Text = string.Empty;
            numericUpDownLeftAtrium.Text = string.Empty;
            numericUpDownRightVentricle.Text = string.Empty;
            numericUpDownEF.Text = string.Empty;
            numericUpDownPWT.Text = string.Empty;
            numericUpDownAortic.Text = string.Empty;
            numericUpDownAorticValve.Text = string.Empty;

            // Reset DecimalUpDowns for height and weight
            txtheight.Text = string.Empty;
            txtWeight.Text = string.Empty;

            // Reset ComboBox
            cmbIpdOpd.SelectedIndex = 1;

            // Clear RichTextBox
            rtxtDoc.Clear();
            rtxtDoc2.Clear();
            rtxtDoc3.Clear();

            dtpIssueDate.Value = DateTime.Now;
            // Set focus to the first field
            txtSlipNo.Focus();
        }

        void FillQuery()
        {
            dgvQuery.Rows.Clear();
            DataTable dtQuery = new DataTable();
            if (UserInfo.UserLevel == "Admin")
            {
                dtQuery = Query.getData("select * from echocardiography");
            }
            else
            {
                dtQuery = Query.getData("select * from echocardiography where status = 0 and createdby = '" + UserInfo.UserId + "'");
            }
            foreach (DataRow row in dtQuery.Rows)
            {
                DateTime vdate = row["vdate"] != DBNull.Value ? (DateTime)row["vdate"] : DateTime.MinValue;

                dgvQuery.Rows.Add(
                    row["slipno"]?.ToString() ?? string.Empty,
                    vdate.ToString("dd MMM yyyy"),
                    row["PatientName"]?.ToString() ?? string.Empty,
                    row["echono"]?.ToString() ?? string.Empty,
                    row["tapeno"]?.ToString() ?? string.Empty,
                    row["clinical_diagnosis"]?.ToString() ?? string.Empty,
                    row["ref_physician"]?.ToString() ?? string.Empty
                );
            }
            lblTotRecordsFetched.Text = "Total Records : " + dtQuery.Rows.Count.ToString("N0");
        }

        private void dgvQuery_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex < 0) return;
            
            string slipNo = dgvQuery.Rows[e.RowIndex].Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(slipNo)) return;

            string sql = "SELECT * FROM echocardiography WHERE slipno = '"+ slipNo + "'";
            DataTable dt = Query.getData(sql);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRow row = dt.Rows[0];

            // Populate form controls
            txtSlipNo.Text = row["slipno"]?.ToString();
            dtpIssueDate.Value = row["vdate"] != DBNull.Value ? (DateTime)row["vdate"] : DateTime.Now;
            cmbIpdOpd.SelectedValue = row["Type"] != DBNull.Value ? Convert.ToInt32(row["Type"]) : 0;
            txtheight.Text = Convert.ToString(row["height"] != DBNull.Value ? Convert.ToDecimal(row["height"]) : 0);
            txtWeight.Text = Convert.ToString(row["weight"] != DBNull.Value ? Convert.ToDecimal(row["weight"]) : 0);
            txtClinicalDiagnose.Text = row["clinical_diagnosis"]?.ToString();
            txtRefPhysician.Text = row["ref_physician"]?.ToString();
            numericUpDownLVstolic.Text = Convert.ToString(row["lv_systolic"] != DBNull.Value ? Convert.ToDecimal(row["lv_systolic"]) : 0);
            numericUpDownLVdstolic.Text = Convert.ToString(row["lv_diastolic"] != DBNull.Value ? Convert.ToDecimal(row["lv_diastolic"]) : 0);
            numericUpDownLVst.Text = Convert.ToString(row["lv_spetal_thickness"] != DBNull.Value ? Convert.ToDecimal(row["lv_spetal_thickness"]) : 0);
            numericUpDownLeftAtrium.Text = Convert.ToString(row["left_atrium"] != DBNull.Value ? Convert.ToDecimal(row["left_atrium"]) : 0);
            numericUpDownRightVentricle.Text = Convert.ToString(row["right_ventricle"] != DBNull.Value ? Convert.ToDecimal(row["right_ventricle"]) : 0);
            numericUpDownEF.Text = Convert.ToString(row["ef"] != DBNull.Value ? Convert.ToDecimal(row["ef"]) : 0);
            numericUpDownPWT.Text = Convert.ToString(row["post_wall_thickness"] != DBNull.Value ? Convert.ToDecimal(row["post_wall_thickness"]) : 0);
            numericUpDownAortic.Text = Convert.ToString(row["aortic"] != DBNull.Value ? Convert.ToDecimal(row["aortic"]) : 0);
            numericUpDownAorticValve.Text = Convert.ToString(row["aortic_valve_opening"] != DBNull.Value ? Convert.ToDecimal(row["aortic_valve_opening"]) : 0);
            rtxtDoc.Rtf = row["description"]?.ToString() ?? string.Empty;
            rtxtDoc2.Rtf = row["description1"]?.ToString() ?? string.Empty;
            rtxtDoc3.Rtf = row["description2"]?.ToString() ?? string.Empty;
            txtReportNo.Text = row["id"]?.ToString();

            txtSlipNo_Validated(txtSlipNo, EventArgs.Empty);
            tabDetailQuery.SelectedTab = tabpgDetail;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReportView frm = new frmReportView();
            Reports.Echocardiography rpt = new Reports.Echocardiography();
            rpt.SetParameterValue("@Name", txtPatientName.Text);
            rpt.SetParameterValue("@RegNo", cmbIpdOpd.Text + "-" + txtReportNo.Text);
            rpt.SetParameterValue("@Date", dtpIssueDate.Value.ToString("dd MMM yyyy"));
            rpt.SetParameterValue("@Age", txtAge.Text);
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
            frm.Show();
        }
        void LoadTemplate()
        {

            string Id = (string)cmbTemplate.SelectedValue;
            DataTable dt = Query.getData("SELECT templatedoc FROM DocTemplate WHERE id = '" + Id + "'");
            if (dt.Rows.Count > 0)
            {
                if (tabControl1.SelectedTab == PgDoc1)
                    rtxtDoc.Rtf = dt.Rows[0][0].ToString();
                else if (tabControl1.SelectedTab == PgDoc2)
                    rtxtDoc2.Rtf = dt.Rows[0][0].ToString();
                else
                    rtxtDoc3.Rtf = dt.Rows[0][0].ToString();
            }
        }
        private void btnLoadTemplate_Click(object sender, EventArgs e)
        {
            LoadTemplate();
        }
    }
}
