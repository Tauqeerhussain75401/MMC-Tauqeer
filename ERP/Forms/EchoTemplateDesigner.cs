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
    public partial class EchoTemplateDesigner: Form
    {
        public EchoTemplateDesigner()
        {
            InitializeComponent();
            FillControls.FillcmbTemplateIndexEcho(cmbTemplate);
        }

        private void EchoTemplateDesigner_Load(object sender, EventArgs e)
        {
            SelectionFont = rtxtDoc.SelectionFont;
        }

        Font SelectionFont;
        private void btnBold_Click(object sender, EventArgs e)
        {
            FontStyle style = rtxtDoc.SelectionFont.Style;
            if (rtxtDoc.SelectionFont.Bold)
            {
                style &= ~FontStyle.Bold;
                btnBold.BackColor = Color.LightGray;
            }
            else
            {
                style |= FontStyle.Bold;
                btnBold.BackColor = Color.DarkGray;
            }
            rtxtDoc.SelectionFont = new Font(rtxtDoc.SelectionFont, style);
            SelectionFont = rtxtDoc.SelectionFont;
            rtxtDoc.Focus();
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            FontStyle style = rtxtDoc.SelectionFont.Style;
            if (rtxtDoc.SelectionFont.Italic)
            {
                style &= ~FontStyle.Italic;
                btnItalic.BackColor = Color.LightGray;
            }
            else
            {
                style |= FontStyle.Italic;
                btnItalic.BackColor = Color.DarkGray;
            }
            rtxtDoc.SelectionFont = new Font(rtxtDoc.SelectionFont, style);
            SelectionFont = rtxtDoc.SelectionFont;
            rtxtDoc.Focus();
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            FontStyle style = rtxtDoc.SelectionFont.Style;
            if (rtxtDoc.SelectionFont.Underline)
            {
                style &= ~FontStyle.Underline;
                btnUnderline.BackColor = Color.LightGray;
            }
            else
            {
                style |= FontStyle.Underline;
                btnUnderline.BackColor = Color.DarkGray;
            }
            rtxtDoc.SelectionFont = new Font(rtxtDoc.SelectionFont, style);
            SelectionFont = rtxtDoc.SelectionFont;
            rtxtDoc.Focus();
        }

        private void btnFontColor_Click(object sender, EventArgs e)
        {
            ColorDialog ColorDlg = new ColorDialog();
            if (ColorDlg.ShowDialog() == DialogResult.OK)
            {
                rtxtDoc.SelectionColor = ColorDlg.Color;
            }
        }

        private void btnFontStyle_Click(object sender, EventArgs e)
        {
            FontDialog FontDlg = new FontDialog();
            if (FontDlg.ShowDialog() == DialogResult.OK)
            {
                rtxtDoc.SelectionFont = FontDlg.Font;
            }
            SelectionFont = rtxtDoc.SelectionFont;
            rtxtDoc.Focus();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            btnLeft.BackColor = Color.LightGray;
            btnCentre.BackColor = Color.LightGray;
            btnRight.BackColor = Color.LightGray;
            if (rtxtDoc.SelectionAlignment != HorizontalAlignment.Left)
            {
                btnLeft.BackColor = Color.LightGray;
            }
            else
            {
                btnLeft.BackColor = Color.DarkGray;
            }
            rtxtDoc.SelectionAlignment = HorizontalAlignment.Left;
            rtxtDoc.Focus();
        }

        private void btnCentre_Click(object sender, EventArgs e)
        {
            if (rtxtDoc.SelectionAlignment != HorizontalAlignment.Center)
            {
                btnCentre.BackColor = Color.LightGray;
            }
            else
            {
                btnCentre.BackColor = Color.DarkGray;
            }
            rtxtDoc.SelectionAlignment = HorizontalAlignment.Center;
            rtxtDoc.Focus();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (rtxtDoc.SelectionAlignment != HorizontalAlignment.Right)
            {
                btnCentre.BackColor = Color.LightGray;
            }
            else
            {
                btnCentre.BackColor = Color.DarkGray;
            }
            rtxtDoc.SelectionAlignment = HorizontalAlignment.Right;
            rtxtDoc.Focus();
        }
        void LoadTemplate()
        {
            string Id = (string)cmbTemplate.SelectedValue;
            DataTable dt = Query.getData("SELECT * FROM DocTemplate WHERE isecho = 1 and id = '" + Id + "'");
            rtxtDoc.Rtf = "";
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtNewTemplate.Text = row["templatename"].ToString();
                rtxtDoc.Rtf = row["templatedoc"].ToString();
            }
        }
        private void btnLoadTemplate_Click(object sender, EventArgs e)
        {
            LoadTemplate();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cmbTemplate.SelectedIndex = -1;
            LoadTemplate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to save this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string Id = (string)cmbTemplate.SelectedValue;
                DML.docTemplate_add_edit(Id, txtNewTemplate.Text, rtxtDoc.Rtf,"1");
                MessageBox.Show("Record Successfully Saved..!");
                FillControls.FillcmbTemplateIndexEcho(cmbTemplate);

            }
        }
    }
}
