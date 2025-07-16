

using BMS.BAL.Interface;

namespace BMS
{
    public partial class frmDepartmentDetails : Form
    {
        private int DepartmentID = -1;

        private readonly IDepartmentService _dataListervice;
        public frmDepartmentDetails(int departmentID, IDepartmentService departmentService)
        {
            InitializeComponent();
            DepartmentID = departmentID;
            _dataListervice = departmentService;

            ctrlDepartmenttInfo2.SetService(_dataListervice);
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void frmDepartmentDetails_Load(object sender, EventArgs e)
        {
            ctrlDepartmenttInfo2.ShowUpdateDepartment = true;
            await ctrlDepartmenttInfo2.LoadDepartmentInfo(DepartmentID);

        }

        
    }
}
