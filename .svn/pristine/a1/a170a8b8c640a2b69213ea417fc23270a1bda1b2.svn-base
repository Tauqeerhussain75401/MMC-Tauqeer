using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

using System.Windows.Forms;
using System.Drawing;
using System.Globalization;

namespace ERP
{
    public partial class MultiColumnComboBox : ComboBox 
    {
        //public MultiColumnComboBox()
        //{
        //    InitializeComponent();
        //}

        //public MultiColumnComboBox(IContainer container)
        //{
        //    container.Add(this);

        //    InitializeComponent();
        //}
        public MultiColumnComboBox()
        {
            this.Tag = "UnLock";
            DrawMode = DrawMode.OwnerDrawVariable;
            this.KeyUp  +=new KeyEventHandler(MultiColumnComboBox_KeyUp);
            this.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.AutoCompleteSource = AutoCompleteSource.ListItems;           
        }
      
        private void MultiColumnComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.Tag.ToString() != "LockKeyUp")
            {
                //int index;
                //string actual;
                //string found;
                //if ((e.KeyCode == Keys.Back) ||
                //    (e.KeyCode == Keys.Left) ||
                //    (e.KeyCode == Keys.Right) ||
                //    (e.KeyCode == Keys.Up) ||
                //    (e.KeyCode == Keys.Down) ||
                //    (e.KeyCode == Keys.Delete) ||
                //    (e.KeyCode == Keys.PageUp) ||
                //    (e.KeyCode == Keys.PageDown) ||
                //    (e.KeyCode == Keys.Home) ||
                //    (e.KeyCode == Keys.End) ||
                //    (e.KeyCode == Keys.Shift) ||
                //    (e.KeyCode == Keys.ShiftKey) || this.Tag.ToString() != "UnLock")
                //{
                //    return;
                //}
                //actual = this.Text;
                //index = this.FindString(actual);
                //if (index > -1)
                //{
                //    if (this.Text.Length > 0)
                //    {
                //        found = this.Items[index].ToString();

                //        this.SelectedIndex = index;
                //        this.SelectionStart = actual.Length;
                //        this.SelectionLength = found.Length;
                //    }
                //}
            }
        }
        public new DrawMode DrawMode
        {
            get
            {
                return base.DrawMode;
            }
            set
            {
                if (value != DrawMode.OwnerDrawVariable)
                {
                    throw new NotSupportedException("Needs to be DrawMode.OwnerDrawVariable");
                }
                base.DrawMode = value;
            }
        }

        public new ComboBoxStyle DropDownStyle
        {
            get
            {
                return base.DropDownStyle;
            }
            set
            {
                if (value == ComboBoxStyle.Simple)
                {
                    throw new NotSupportedException("ComboBoxStyle.Simple not supported");
                }
                base.DropDownStyle = value;
            }
        }

        protected override void OnDataSourceChanged(EventArgs e)
        {
            base.OnDataSourceChanged(e);

            InitializeColumns();
        }

        protected override void OnValueMemberChanged(EventArgs e)
        {
            base.OnValueMemberChanged(e);

            InitializeValueMemberColumn();
        }

        protected override void OnDropDown(EventArgs e)
        {
            base.OnDropDown(e);
            this.DropDownWidth = (int)CalculateTotalWidth();
        }

        const int columnPadding = 5;
        private float[] columnWidths = new float[0];
        private String[] columnNames = new String[0];
        private int valueMemberColumnIndex = 0;

        private void InitializeColumns()
        {
            PropertyDescriptorCollection propertyDescriptorCollection = DataManager.GetItemProperties();

            columnWidths = new float[propertyDescriptorCollection.Count];
            columnNames = new String[propertyDescriptorCollection.Count];

            for (int colIndex = 0; colIndex < propertyDescriptorCollection.Count; colIndex++)
            {
                String name = propertyDescriptorCollection[colIndex].Name;
                columnNames[colIndex] = name;
            }
        }

        private void InitializeValueMemberColumn()
        {
            int colIndex = 0;
            foreach (String columnName in columnNames)
            {
                if (String.Compare(columnName, ValueMember, true, CultureInfo.CurrentUICulture) == 0)
                {
                    valueMemberColumnIndex = colIndex;
                    break;
                }
                colIndex++;
            }
        }

        private float CalculateTotalWidth()
        {
            float totWidth = 0;
            foreach (int width in columnWidths)
            {
                totWidth += (width + columnPadding);
            }
            return totWidth + SystemInformation.VerticalScrollBarWidth;
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            base.OnMeasureItem(e);

            if (DesignMode)
                return;

            for (int colIndex = 0; colIndex < columnNames.Length; colIndex++)
            {
                string item = Convert.ToString(FilterItemOnProperty(Items[e.Index], columnNames[colIndex]));
                SizeF sizeF = e.Graphics.MeasureString(item, Font);
                columnWidths[colIndex] = Math.Max(columnWidths[colIndex], sizeF.Width);
            }

            float totWidth = CalculateTotalWidth();

            e.ItemWidth = (int)totWidth;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);

            if (DesignMode)
                return;

            e.DrawBackground();

            Rectangle boundsRect = e.Bounds;
            int lastRight = 0;

            using (Pen linePen = new Pen(SystemColors.GrayText))
            {
                using (SolidBrush brush = new SolidBrush(ForeColor))
                {
                    if (columnNames.Length == 0)
                    {
                        e.Graphics.DrawString(Convert.ToString(Items[e.Index]), Font, brush, boundsRect);
                    }
                    else
                    {
                        for (int colIndex = 0; colIndex < columnNames.Length; colIndex++)
                        {
                            string item = Convert.ToString(FilterItemOnProperty(Items[e.Index], columnNames[colIndex]));

                            boundsRect.X = lastRight;
                            boundsRect.Width = (int)columnWidths[colIndex] + columnPadding;
                            lastRight = boundsRect.Right;

                            if (colIndex == valueMemberColumnIndex)
                            {
                                using (Font boldFont = new Font(Font, FontStyle.Bold))
                                {
                                    e.Graphics.DrawString(item, boldFont, brush, boundsRect);
                                }
                            }
                            else
                            {
                                e.Graphics.DrawString(item, Font, brush, boundsRect);
                            }

                            if (colIndex < columnNames.Length - 1)
                            {
                                e.Graphics.DrawLine(linePen, boundsRect.Right, boundsRect.Top, boundsRect.Right, boundsRect.Bottom);
                            }
                        }
                    }
                }
            }

            e.DrawFocusRectangle();
        }
    }
}
