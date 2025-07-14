using BMS.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BMS.GUI_Helper.TablesNameEnum;

namespace BMS.GUI.Controls
{
    public partial class ctrlListOf : UserControl
    {
        public ctrlListOf()
        {
            InitializeComponent();
        }

        DataTable _dataTable = new DataTable();
        private enTableNames _TableName { get; set; }

        public ctrlListOf(enTableNames enTableNames)
        {
            InitializeComponent();
            _TableName = enTableNames;
            lblTitle.Text = enTableNames.ToString();
            _LoadDataInfo();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void _LoadDataInfo()
        {
            switch (_TableName)
            {
                case enTableNames.Users:
                    _ResetControlsForUsers();
                    break;
                case enTableNames.Employees:
                    break;
                case enTableNames.Departments:
                    _ResetControlsForDepartments();
                    break;
                case enTableNames.Jobs:
                    break;
                default:
                    break;
            }
        }

        private void _ResetControlsForUsers()
        {
            _ResetCbxFilterForUsers();
            _ResetDgvUsers();


        }

        private void _ResetCbxFilterForUsers()
        {
            cbxFilter.Items.Clear();

            cbxFilter.Items.Add("All");
            cbxFilter.Items.Add("Active");
            cbxFilter.Items.Add("Inactive");
            cbxFilter.Items.Add("ID");
            cbxFilter.Items.Add("Name");
            cbxFilter.Items.Add("Email");

            cbxFilter.SelectedIndex = 0;
            cbxFilter.SelectedIndex = -1;
        }

        private void _ResetDgvUsers()
        {
            dgvList.DataSource = null;
            dgvList.Columns.Clear();
            dgvList.Rows.Clear();
            dgvList.Refresh();

            dgvList.Columns.Add("ID", "ID");
            dgvList.Columns.Add("Name", "Name");
            dgvList.Columns.Add("Email", "Email");
            dgvList.Columns.Add("IsActive", "Is Active");

        }

        private void _ResetControlsForDepartments()
        {
            _ResetCbxFilterForDepartments();
            _ResetDgvDepartments();
        }

        private void _ResetDgvDepartments()
        { 
            dgvList.DataSource = null;
            dgvList.Columns.Clear();
            dgvList.Rows.Clear();
            dgvList.Refresh();
            dgvList.Columns.Add("ID", "ID");
            dgvList.Columns.Add("Name", "Name");
            dgvList.Columns.Add("Description", "Description");
            dgvList.Columns.Add("IsActive", "Is Active");
            dgvList.Columns.Add("CreatedBy", "Created By");
            dgvList.Columns.Add("CreatedDate", "Created Date");

            dgvList.Refresh();

        }

        private void _ResetCbxFilterForDepartments()
        {
            cbxFilter.Items.Clear();
            cbxFilter.Items.Add("All");
            cbxFilter.Items.Add("Active");
            cbxFilter.Items.Add("Inactive");
            cbxFilter.Items.Add("ID");
            cbxFilter.Items.Add("Name");
            cbxFilter.Items.Add("Description");
            cbxFilter.SelectedIndex = 0;
        }
    }
}
