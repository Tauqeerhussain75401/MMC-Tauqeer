using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
namespace VersionUpdater
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
        }
        public static void ChangeFile(string Newfile,string Origfile,Process  process)
        {
            process.Close(); 
            File.Replace(Newfile, Origfile, Newfile + "old");
        }
    }
}
