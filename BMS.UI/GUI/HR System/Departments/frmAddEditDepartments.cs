
using BMS.BAL.Interface;
using BMS.DTOs;
using DAL;
using DocumentFormat.OpenXml.Bibliography;
using System.ComponentModel;

namespace BMS
{


    public partial class frmAddEditDepartments : Form
    {
        private enum FormMode { AddNew = 1, Update = 2 }

        private readonly IDepartmentService _departmentService;
        private DepartmentDTO _department;
        private FormMode _mode;
        private const int MaxDescriptionLength = 250;

       
        private int DepartmentID { get; set; } = -1;

       

        public event EventHandler DepartmentSaved;

        public frmAddEditDepartments(IDepartmentService departmentService)
            : this(departmentService, -1) { }

        public frmAddEditDepartments(IDepartmentService departmentService, int departmentId)
        {
            InitializeComponent();
            _departmentService = departmentService ?? throw new ArgumentNullException(nameof(departmentService));

            InitializeForm(departmentId);
            ConfigureFormBehavior();
        }

       
        


        #region Initialization



        private void InitializeForm(int departmentId)
        {
            if (departmentId > 0)
            {
                _mode = FormMode.Update;
                DepartmentID = departmentId;
                ConfigureUpdateMode();
            }
            else
            {
                _mode = FormMode.AddNew;
                _department = new DepartmentDTO();
                ConfigureAddMode();
            }
        }


        private void ConfigureFormBehavior()
        {
            btnClose.CausesValidation = false;
            this.ActiveControl = txtDepartment;
        }

        private void ConfigureAddMode()
        {
            this.Text = lblTitle.Text = "إضافة قسم";
            btnSave.Text = "حفظ";
            btnNew.Visible = false;
            lblDepartmentID.Text = "تلقائي";
        }

        private void ConfigureUpdateMode()
        {
            this.Text = lblTitle.Text = "تعديل بيانات القسم";
            btnSave.Text = "تعديل";
            btnNew.Visible = true;
        }

        #endregion



        #region Event Handlers


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                btnSave.Enabled = false;
                await SaveDepartment();
            }
            finally
            {
                btnSave.Enabled = true;
            }


        }

        private async void frmAddEditDepartments_Load(object sender, EventArgs e)
        {

            if (_mode == FormMode.Update)
            {
                await LoadDepartmentData();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ResetFormForNewEntry();
        }

        #endregion


        #region Validation
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

        private bool ValidateForm()
        {
            return ValidateChildren(ValidationConstraints.Enabled);
        }

        #endregion

        #region Data Operations


        private async Task LoadDepartmentData()
        {
            _department = await _departmentService.GetInfoAsync(DepartmentID);

            if (_department == null)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل بيانات القسم", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            PopulateFormFields();
        }

        private void PopulateFormFields()
        {
            lblDepartmentID.Text = _department.ID.ToString();
            txtDepartment.Text = _department.Name;
            txtDescription.Text = _department.Description ?? string.Empty;
            txtDepartment.SelectAll();
        }

        private async Task SaveDepartment()
        {
            UpdateDepartmentFromForm();

            bool saveResult = await _departmentService.SaveAsync(_department);

            if (saveResult)
            {
                ShowSuccessMessage();
                HandleSuccessfulSave();
                OnDepartmentSaved();
            }
            else
            {
                ShowErrorMessage();
            }
        }


        private void UpdateDepartmentFromForm()
        {
            _department.Name = txtDepartment.Text.Trim();
            _department.Description = string.IsNullOrEmpty(txtDescription.Text) ? null : txtDescription.Text;

            // TODO: Replace with actual user ID from session/context
            if (_mode == FormMode.AddNew)
            {
                _department.CreatedByUserID = 1;
            }
            else
            {
                _department.UpdatedByUserID = 1;
            }
        }

        #endregion


        #region UI Helpers

        private void ResetFormForNewEntry()
        {
            _mode = FormMode.AddNew;
            _department = new DepartmentDTO();
            ConfigureAddMode();
            ClearFormFields();
        }

        private void ClearFormFields()
        {
            lblDepartmentID.Text = "تلقائي";
            txtDepartment.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }

        private void ShowSuccessMessage()
        {
            MessageBox.Show("تم الحفظ بنجاح", "تم الحفظ",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowErrorMessage()
        {
            MessageBox.Show("حدث خطأ اثناء الحفظ , يرجي التاكد من عدم انشاء هذا القسم مسبقا",
                "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void HandleSuccessfulSave()
        {
            if (_mode == FormMode.AddNew)
            {
                _mode = FormMode.Update;
                ConfigureUpdateMode();
                lblDepartmentID.Text = _department.ID.ToString();
            }
        }

        protected virtual void OnDepartmentSaved()
        {
            DepartmentSaved?.Invoke(this, EventArgs.Empty);
        }

        #endregion

     

    }

}
