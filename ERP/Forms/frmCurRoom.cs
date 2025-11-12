using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class frmCurRoom : Form
    {
        public frmCurRoom()
        {
            InitializeComponent();
        }
        public string serialnum;
        private void frmCurRoom_Load(object sender, EventArgs e)
        {
            fillroomsAll();
            
        }
        public void fillroomsAll()
        {
            cmbRoomAll.DataSource = Query.roomAll();
            cmbRoomAll.DisplayMember = "fullname";
            cmbRoomAll.ValueMember = "id";
            cmbRoomAll.SelectedIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DML.inpcurrentroom_Add_edit(cmbRoomAll.SelectedIndex, serialnum, DateTime.UtcNow.ToString("dd-MMM-yyyy"));
            MessageBox.Show("Room Status Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
