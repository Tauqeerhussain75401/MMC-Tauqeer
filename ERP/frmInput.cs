using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP
{
    public partial class frmInput : Form
    {
        public string inputText;
        public frmInput()
        {
            InitializeComponent();
        }
        public frmInput(string label)
        {
            InitializeComponent();
            label1.Text = label;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmInput_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inputText = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmInput_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void frmInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }
    }
}
