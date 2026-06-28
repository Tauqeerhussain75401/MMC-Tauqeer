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
    public partial class frmPatient : Form
    {
        string Id = "";
        public frmPatient()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbPatientTitle.Text = "";
            txtPatientName.Text = "";
            txtContactNo.Text = "";
            dtpDOB.Text = "";
        }

        private void frmPatient_Load(object sender, EventArgs e)
        {
            btnClear_Click(null, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string dob = dtpDOB.Value == null ? null : DateTime.Parse(dtpDOB.Value.ToString()).ToString("dd MMM yyyy");
            Query.get_Patients(cmbPatientTitle.Text, txtPatientName.Text, txtContactNo.Text, dob, cmbGender.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(cmbPatientTitle.SelectedValue == null ||
            txtPatientName.Text == "" ||
            txtContactNo.Text == "" ||
            dtpDOB.Value == null ||
            cmbGender.SelectedValue == null ||
            Id == "")
            {
                MessageBox.Show("Please fill all fields!");
                return;
            }

            if (txtContactNo.Text.Length != 11)
            {
                MessageBox.Show("Please enter a valid contact number. It should be exactly 11 digits.");
                return;
            }
            string dob = dtpDOB.Value == null ? null : DateTime.Parse(dtpDOB.Value.ToString()).ToString("dd MMM yyyy");
            Query.save_Patient(Id, cmbPatientTitle.Text, txtPatientName.Text, txtContactNo.Text, dob, cmbGender.Text);
        }
    }
}
