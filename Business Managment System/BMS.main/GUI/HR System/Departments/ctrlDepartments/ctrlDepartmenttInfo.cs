using BAL;
using System.Windows.Forms;


namespace BMS
{
    public partial class ctrlDepartmenttInfo: UserControl
    {
        private int _departmentID = -1;
        private Department _Department;
        private bool enableUpdateDepartment = true;

        public int DepartmentID { get { return _departmentID; } }
        public Department SelectedDepartment { get { return _Department; } }

        public bool ShowUpdateDepartment
        {
            get { return enableUpdateDepartment; }
            set
            {
                enableUpdateDepartment = value;
                llblUpdateDepartment.Visible = enableUpdateDepartment;
            }
        }
        public ctrlDepartmenttInfo()
        {
            InitializeComponent();
        }
        
        public async void LoadDepartmentInfo(int DepartmentID)
        {
            _departmentID = DepartmentID;
            _Department = await Department.GetDepartment(_departmentID);

            if (_Department is null)
            {
                ResetDepartmentInfo();
                MessageBox.Show($" {DepartmentID} لا يوجد قسم برقم ","حدث خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _FillDepartmentInfo();
            }
        }

        private void _FillDepartmentInfo()
        {
            lblDepartmentID.Text = _Department.DepartmentID.ToString();
            lblDepartmentName.Text = _Department.DepartmentName;
            lblCreationDate.Text = _Department.CreatedDate.ToString("tt hh:mm  dd/MM/yyyy ");
            lblUpdateDate.Text = _Department.ModifiedDate?.ToString("tt hh:mm  dd/MM/yyyy ") ?? "-";
            lblMadeByUser.Text = _Department.CreatedByUserID.ToString();
            lblUpdatedbyUser.Text = _Department.ModifiedByUserID?.ToString();

            // Will put user Name later not ID
        }


       

        private void ResetDepartmentInfo()
        {
            _departmentID = -1;
            lblDepartmentID.Text = "لا يوجد قسم بهذا الرقم";
            lblDepartmentName.Text = "[????]";
            lblCreationDate.Text = "[????]";
            lblMadeByUser.Text = "[????]";
            lblUpdateDate.Text = "[????]";
            lblUpdatedbyUser.Text = "[????]";
        }

        private void llblUpdateDepartment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditDepartments frm = new frmAddEditDepartments(_departmentID);
            frm.ShowDialog();
            LoadDepartmentInfo(_departmentID);
        }
    }
}
