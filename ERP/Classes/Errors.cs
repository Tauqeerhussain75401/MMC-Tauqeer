using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ERP
{
    class Errors
    {
        public static DateTime datetme = DateTime.Now;
        public static string fmt = "dd-MM-yyyy";
        public static FileStream MyFileStream = new FileStream("Log.txt", FileMode.Append);
        public static StreamWriter _error = new StreamWriter(MyFileStream);

        public static void writeline(string line, string From)
        {
            
                _error.WriteLine(DateTime.Now.ToString()+"("+From+")"+line );
                _error.WriteLine("===============================================");
                _error.Flush();
        }
    }
}
