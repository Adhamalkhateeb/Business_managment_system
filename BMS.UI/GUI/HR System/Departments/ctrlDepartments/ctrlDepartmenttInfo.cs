
using BMS.BAL.Interface;
using BMS.DTOs;
using System.ComponentModel;



namespace BMS
{
    public partial class ctrlDepartmenttInfo: UserControl
    {
        private int _departmentID = -1;
        private DepartmentDTO _Department;
        private IDepartmentService _departmentService;
        private bool enableUpdateDepartment = true;


        public event EventHandler<DepartmentDTO>? DepartmentUpdated;

        public int DepartmentID => _departmentID;
        public DepartmentDTO SelectedDepartment => _Department;

        public bool ShowUpdateDepartment
        {
            get => enableUpdateDepartment;
            set
            {
                enableUpdateDepartment = value;
                llblUpdateDepartment.Visible = enableUpdateDepartment;
            }
        }

        public ctrlDepartmenttInfo()
        {
            InitializeComponent();

            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

        }
       

        public async Task LoadDepartmentInfo(int DepartmentID)
        {
            try
            {
                _departmentID = DepartmentID;
                _Department = await _departmentService.GetInfoAsync(_departmentID);

                if (_Department is null)
                {
                    ResetDepartmentInfo();
                    MessageBox.Show($" {DepartmentID} لا يوجد قسم برقم ", "حدث خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _FillDepartmentInfo();
            }
            catch (Exception ex)
            {
                ResetDepartmentInfo();
                MessageBox.Show($"فشل في تحميل بيانات القسم: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void _FillDepartmentInfo()
        {
            lblDepartmentID.Text = _Department.ID.ToString();
            lblDepartmentName.Text = _Department.Name;
            lblCreationDate.Text = _Department.CreationDate;
            lblUpdateDate.Text = _Department.LastUpdatedDate;
            lblMadeByUser.Text = _Department.CreatedByUserID.ToString();
            lblUpdatedbyUser.Text = _Department.UpdatedByUserID?.ToString();

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

        private async void  llblUpdateDepartment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using var frm = new frmAddEditDepartments(_departmentID,_departmentService);
            frm.ShowDialog();
            await LoadDepartmentInfo(_departmentID);

            DepartmentUpdated?.Invoke(this, _Department);
        }


        public void SetService(IDepartmentService service)
        {
            _departmentService = service;
        }
    }
}
