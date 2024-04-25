using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ERP
{
  public static class InteropStuff
  {
    public const int WM_LBUTTONDOWN = 0x0201;

    [DllImport("User32.dll", EntryPoint="SendMessage")]
    public static extern int SendMessage(IntPtr hWnd, uint uMsg, int wParam, int lParam);
  }
}
