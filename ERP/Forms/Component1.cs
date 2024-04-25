using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing ;
using  System.Windows .Forms;
using System.Data;

namespace ERP
{
    public partial class Component1 : System.Windows.Forms.ComboBox
    {
        //DataGridView dgv = new DataGridView();
        public Component1()
        {
            InitializeComponent();

        }
        public string a = "";
        public Component1(IContainer container)
        {
            //this.DroppedDown = false;
            //dgv.AllowUserToAddRows = false;
            //dgv.AllowUserToDeleteRows = false;
            //dgv.AllowUserToOrderColumns = true;
            //dgv.AllowUserToResizeColumns = false;
            //dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            //dgv.CellMouseLeave += new DataGridViewCellEventHandler(dgv_CellMouseLeave);
            //dgv.CellMouseEnter += new DataGridViewCellEventHandler(dgv_CellMouseEnter);
            //dgv.Name = "dataGridView1";
            //dgv.ReadOnly = true;
            //dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            //dgv.Size = new System.Drawing.Size(309, 150);
            container.Add(this);

            InitializeComponent();



        }

        //void dgv_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex != -1)
        //        dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightCoral;
        //}

        //void dgv_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex != -1)
        //        dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightGray;
        //}







        bool Flogin = true;
        DataTable dt = new DataTable();
        private void Component1_DropDown(object sender, EventArgs e)
        {
            if (Flogin)
            {
                this.DropDownWidth = 300;
                
                dt = (DataTable)this.DataSource;
              //  dgv.DataSource = dt;
               // this.FindForm().Controls.Add(dgv);
                Flogin = false;
               // dgv.Location = new System.Drawing.Point(this.Location.X, this.Location.Y + this.Size.Height);
            }
          //  dgv.Visible = true;
           // this.DropDownHeight = 1;
        }

        private void Component1_DropDownClosed(object sender, EventArgs e)
        {
           // dgv.Visible = false;
        }

        private void Component1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            e.DrawBackground();
            if (e.Index == 0)
            {
           
                using (Pen Pen = new Pen(Color.Black, 1))
                    e.Graphics.DrawRectangle(Pen, new Rectangle(2, 2, e.Bounds.Width , e.Bounds.Height)); 
                Point p1 = new Point(100, 5);
                Point p2 = new Point(100, this.DropDownWidth - 5);
                using (Pen SolidmyPen = new Pen(Color.Black, 1))
                    e.Graphics.DrawLine(SolidmyPen, p1, p2);
            }
           
            e.Graphics.DrawString(dt.Rows[e.Index][0].ToString(), this.Font, System.Drawing.Brushes.Black, new Point(e.Bounds.X + 5, e.Bounds.Y + 2));
            e.Graphics.DrawString(dt.Rows[e.Index][1].ToString(), this.Font, System.Drawing.Brushes.Black, new Point(e.Bounds.X + 120, e.Bounds.Y + 2));

            //e.DrawFocusRectangle();
  
        }

        private void Component1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            switch (e.Index)
            {
                case 0:
                    e.ItemHeight = 45;
                    break;
                case 1:
                    e.ItemHeight = 20;
                    break;
                case 2:
                    e.ItemHeight = 35;
                    break;
            }
            e.ItemWidth = 260;

        }
    }
}
