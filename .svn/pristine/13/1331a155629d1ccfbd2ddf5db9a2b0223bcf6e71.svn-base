using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERP{
  public static class Extensions
  {
    public static void ShowDropDown(this DateTimePicker dtPicker)
    {
      
      int x = dtPicker.Width - 10;
      int y = dtPicker.Height / 2;

      int lParam = x + y * 0x00010000;
      InteropStuff.SendMessage(dtPicker.Handle, InteropStuff.WM_LBUTTONDOWN, 1, lParam);      
      //DateTimePicker
    }
    public static void ShowDropDown(this CalendarEditingControl dtPicker)
    {
      //(dtPicker as DateTimePicker).ShowDropDown();
    }
  }
}
