
using System.ComponentModel;

using DAL;
using BMS.BAL.Interface;
using BMS.DTOs;

namespace BMS
{


    public partial class frmAddEditDepartments : Form
    {
        private int DepartmentID = -1;
        private IDepartmentService _DepartmentService;
        private DepartmentDTO _Department;


        public event EventHandler DepartmentSaved;

        private void OnDepartmentSaved()
        {
            DepartmentSaved?.Invoke(this, EventArgs.Empty);
        }

        public enum enMode { AddNew = 1, Update = 2 }
        private enMode _Mode = enMode.AddNew;


        public frmAddEditDepartments()
        {
            InitializeComponent();
        }
        public frmAddEditDepartments(IDepartmentService departmentService) : this()
        {

            _DepartmentService = departmentService;
            _Mode = enMode.AddNew;
            _Department = new DepartmentDTO();


            btnClose.CausesValidation = false;
            this.Text = lblTitle.Text = "إضافة قسم";
        }

        public frmAddEditDepartments(int departmentID, IDepartmentService departmentService) : this()
        {

            _DepartmentService = departmentService;
            DepartmentID = departmentID;
            _Mode = enMode.Update;



            btnClose.CausesValidation = false;
            this.Text = lblTitle.Text = "تعديل بيانات القسم";
            this.btnSave.Text = "تعديل";

        }

        private void txtDepartment_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDepartment.Text))
            {

                ep.SetError(txtDepartment, "يجب إدخال أسم القسم");
                e.Cancel = true;
            }
            else
                ep.SetError(txtDepartment, null);






        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren()) return;
            btnSave.Enabled = false;

            try
            {




                _Department.Name = txtDepartment.Text.Trim();
                _Department.Description = string.IsNullOrEmpty(txtDescription.Text) ? null : txtDescription.Text;
                if (_Mode == enMode.AddNew)
                {
                    _Department.CreatedByUserID = 1;
                    // Here will be Active User ID

                }
                else
                {
                    _Department.UpdatedByUserID = 1;
                    // Here will be Active User ID

                }



                if (await _DepartmentService.SaveAsync(_Department))
                {
                    MessageBox.Show("تم الحفظ بنجاح", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    lblDepartmentID.Text = _Department.ID.ToString();
                    this.Text = lblTitle.Text = "تعديل بيانات القسم";
                    btnSave.Text = "تعديل";
                    _Mode = enMode.Update;
                    btnNew.Visible = true;
                    btnNew.Focus();
                    OnDepartmentSaved(); 

                }
                else
                {
                    MessageBox.Show("حدث خطأ اثناء الحفظ , يرجي التاكد من عدم انشاء هذا القسم مسبقا", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                } 
            }finally
            {
                btnSave.Enabled = true;
            }

           


        }

        private async void frmAddEditDepartments_Load_1(object sender, EventArgs e)
        {

            txtDepartment.Focus();



            btnClose.CausesValidation = false;


            if (_Mode == enMode.Update)
            {
                _Department = await _DepartmentService.GetInfoAsync(DepartmentID);

                if (_Department != null)
                {
                    lblDepartmentID.Text = _Department.ID.ToString();
                    txtDepartment.Text = _Department.Name;
                    txtDescription.Text = (string)(_Department.Description ?? "");
                    txtDepartment.SelectAll();
                }
                else
                {
                    MessageBox.Show("حدث خطأ أثناء تحميل بيانات القسم", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }



        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            _Mode = enMode.AddNew;
            lblDepartmentID.Text = "تلقائي";
            txtDepartment.Text = "";
            txtDescription.Text = "";
            btnNew.Visible = false;
            btnSave.Text = "حفظ";
            lblTitle.Text = "إضافة قسم";
            _Department = new DepartmentDTO();


        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (txtDescription.Text.Length > 250)
            {
                ep.SetError(txtDescription, "الوصف طويل جدًا (أقصى حد 250 حرف).");
                e.Cancel = true;
            }
            else
                ep.SetError(txtDescription, null);
        }
    }
}
