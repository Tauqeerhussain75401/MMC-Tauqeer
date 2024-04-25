using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP
{
    class SoftwareInfo
    {
        private static string _Terminal;

        internal  static string Terminal
        {
            get { return SoftwareInfo._Terminal; }
            set { SoftwareInfo._Terminal = value; }
        }

        private static DateTime _ServerDate;

        internal static DateTime  ServerDate
        {
            get { return SoftwareInfo._ServerDate; }
            set { SoftwareInfo._ServerDate  = value; }
        }
        
    }
}
