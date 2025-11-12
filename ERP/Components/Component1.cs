using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
 
namespace ERP
{
    public partial class Component1 : System.Windows.Forms.ComboBox  
    {
        DataGridView grd = new DataGridView(); 
        public Component1()
        {
            InitializeComponent();
        }

        public Component1(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
       
    }
}
