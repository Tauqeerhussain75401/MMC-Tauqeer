using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ERP
{
    public partial class NumericTextbox : System .Windows .Forms .TextBox 
    {
        public NumericTextbox()
        {
            InitializeComponent();
        }

        public NumericTextbox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        int Value = 0;
        private void NumericTextbox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            if (this.SelectedText.Length > 0 && !int.TryParse(this.Text, out Value))
                {
                    int selind = this.SelectionStart;
                    this.Text = this.Text.Replace(this.SelectedText, "");
                    this.SelectionStart = selind;
                    this.SelectionLength = 0;
                }
                if (!char.IsControl(e.KeyChar)
           && !char.IsDigit(e.KeyChar)
                    )
                {
                    e.Handled = true;
                }
            
        }

        private void NumericTextbox_Validated(object sender, EventArgs e)
        {
            int.TryParse(this.Text, out Value);
            if (this.Text == "") this.Text = "0";
            else this.Text = Value.ToString();
        }

        private void NumericTextbox_Enter(object sender, EventArgs e)
        {

        }
    }
}
