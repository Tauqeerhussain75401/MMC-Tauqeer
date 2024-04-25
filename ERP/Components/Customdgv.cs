using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERP.Components
{
    public partial class Customdgv : DataGridView 
    {
        public Customdgv()
        {
            InitializeComponent();
        }
        private int currentRow;
        private bool resetRow = false;
        public Customdgv(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void Customdgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (this[e.ColumnIndex, e.RowIndex].GetType() != typeof(DataGridViewCheckBoxCell))
            {
                resetRow = true;
                currentRow = e.RowIndex;
            }
        }

        private void Customdgv_SelectionChanged(object sender, EventArgs e)
        {
            if (resetRow)
            {
                resetRow = false;
                this.CurrentCell = this.Rows[currentRow].Cells[this.CurrentCell.ColumnIndex];
            }
        }

        private void Customdgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{tab}");
            }
        }

        

        private void Customdgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this[e.ColumnIndex, e.RowIndex].ReadOnly == true )
            {
                SendKeys.Send("{tab}");
            }
        }
       
    }
}
