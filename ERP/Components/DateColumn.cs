using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using ERP;
using System.ComponentModel;

namespace ERP
{
    public class CalendarColumn : DataGridViewColumn
    {
        public CalendarColumn()
          : base(new CalendarCell())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a CalendarCell.
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(CalendarCell)))
                {
                    throw new InvalidCastException("Must be a CalendarCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    public class CalendarCell : DataGridViewTextBoxCell
    {

        public CalendarCell()
          : base()
        {
            // Use the short date format.

            this.Style.Format = "dd-MMM-yyyy";

        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            CalendarEditingControl ctl =
                DataGridView.EditingControl as CalendarEditingControl;
            try
            {
                if (!(this.Value is DBNull))
                {
                    if (this.Value != null)
                        ctl.Value = (DateTime)this.Value;
                }
            }
            catch (Exception EE)
            {

            }

        }

        public override Type EditType
        {
            get
            {
                // Return the type of the editing contol that CalendarCell uses.
                return typeof(CalendarEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that CalendarCell contains.

                return typeof(DateTime);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                // Use the current date and time as the default value.
                return DBNull.Value; //sknake
            }
        }
    }

    public class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public CalendarEditingControl()
        {
            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = "dd-MMM-yyyy";
        }

        // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
        // property.
        public object EditingControlFormattedValue
        {
            get
            {
                return this.Value.ToShortDateString();

            }
            set
            {
                if (value is String)
                {
                    this.Value = DateTime.Parse((String)value);
                }
            }
        }

        // Implements the 
        // IDataGridViewEditingControl.GetEditingControlFormattedValue method.
        public object GetEditingControlFormattedValue(
            DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        // Implements the 
        // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
        public void ApplyCellStyleToEditingControl(
            DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
            this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
        }

        // Implements the IDataGridViewEditingControl.EditingControlRowIndex 
        // property.
        public int EditingControlRowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }

        // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey 
        // method.
        public bool EditingControlWantsInputKey(
            Keys key, bool dataGridViewWantsInputKey)
        {
            // Let the DateTimePicker handle the keys listed.
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit 
        // method.
        public void PrepareEditingControlForEdit(bool selectAll)
        {
            if (dataGridView.EditingControl == this)
            {
                Rectangle rect = dataGridView.GetCellDisplayRectangle(dataGridView.CurrentCell.ColumnIndex, rowIndex, true);
                MouseInfo mi = new MouseInfo(Control.MouseButtons);
                Point mousePos = dataGridView.PointToClient(Control.MousePosition);
                if (rect.Contains(mousePos) && (((rect.Left + rect.Width) - mousePos.X) <= 15))
                {
                    this.ShowDropDown();

                }

            }
        }

        // Implements the IDataGridViewEditingControl
        // .RepositionEditingControlOnValueChange property.
        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingControlDataGridView property.
        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingControlValueChanged property.
        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingPanelCursor property.
        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

        protected override void OnValueChanged(EventArgs eventargs)
        {
            // Notify the DataGridView that the contents of the cell
            // have changed.
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }
    }
    public class TimeEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        private DataGridView _dgv;
        private bool _valueChanged;
        private int _rowIndex;

        public TimeEditingControl()
        {
            Format = DateTimePickerFormat.Custom;
            CustomFormat = "hh:mm tt";
            ShowUpDown = true;
        }

        public object EditingControlFormattedValue
        {
            get { return Value; }
            set
            {
                if (value == null || value == DBNull.Value)
                {
                    Value = DateTime.Today;
                }
                else if (value is DateTime)
                {
                    Value = (DateTime)value;
                }
                else
                {
                    DateTime parsed;
                    if (value is string && DateTime.TryParse((string)value, out parsed))
                        Value = parsed;
                }
            }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return Value;
        }

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            Font = dataGridViewCellStyle.Font;
        }

        public int EditingControlRowIndex
        {
            get { return _rowIndex; }
            set { _rowIndex = value; }
        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageUp:
                case Keys.PageDown:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        public void PrepareEditingControlForEdit(bool selectAll) { }

        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }

        public DataGridView EditingControlDataGridView
        {
            get { return _dgv; }
            set { _dgv = value; }
        }

        public bool EditingControlValueChanged
        {
            get { return _valueChanged; }
            set { _valueChanged = value; }
        }

        public Cursor EditingPanelCursor
        {
            get { return base.Cursor; }
        }

        protected override void OnValueChanged(EventArgs eventargs)
        {
            _valueChanged = true;
            if (_dgv != null)
                _dgv.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }
    }

    public class TimeCalendarCell : DataGridViewTextBoxCell
    {
        public override Type EditType
        {
            get { return typeof(TimeEditingControl); }
        }

        public override Type ValueType
        {
            get { return typeof(DateTime); }
        }

        public override object DefaultNewRowValue
        {
            get { return DBNull.Value; }
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            TimeEditingControl ctl = DataGridView.EditingControl as TimeEditingControl;
            if (ctl == null) return;
            if (Value != null && Value != DBNull.Value)
                ctl.Value = Convert.ToDateTime(Value);
            else
                ctl.Value = DateTime.Today;
        }

        public override object ParseFormattedValue(
            object formattedValue,
            DataGridViewCellStyle cellStyle,
            System.ComponentModel.TypeConverter formattedValueTypeConverter,
            System.ComponentModel.TypeConverter valueTypeConverter)
        {
            if (formattedValue == null || formattedValue == DBNull.Value)
                return DBNull.Value;
            if (formattedValue is DateTime)
                return (DateTime)formattedValue;
            DateTime parsed;
            if (formattedValue is string && DateTime.TryParse((string)formattedValue, out parsed))
                return parsed;
            return base.ParseFormattedValue(formattedValue, cellStyle, formattedValueTypeConverter, valueTypeConverter);
        }
    }
    public class TimeCalendarColumn : DataGridViewColumn
    {
        public TimeCalendarColumn()
            : base(new TimeCalendarCell())
        {
            DefaultCellStyle.Format = "hh:mm tt";
        }
    }


}
