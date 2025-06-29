using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMS
{
    public partial class frmDepartmentDetails : Form
    {
        private int DepartmentID = -1;
        public frmDepartmentDetails(int departmentID)
        {
            InitializeComponent();
            DepartmentID = departmentID;
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDepartmentDetails_Load(object sender, EventArgs e)
        {
            ctrlDepartmenttInfo1.LoadDepartmentInfo(DepartmentID);
            ctrlDepartmenttInfo1.ShowUpdateDepartment = true;
        }

        private void frmDepartmentDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
