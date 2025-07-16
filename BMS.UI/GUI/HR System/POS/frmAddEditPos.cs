using BMS.BAL.Interface;
using BMS.DTOs;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMS.GUI.HR_System.POS
{
    public partial class frmAddEditPos : Form
    {
        private enum FormMode { AddNew = 1, Update = 2 }

        private readonly IPosServices _posService;
        private PosDTO _pos;
        private FormMode _mode;

        private int PosID { get; set; } = -1;



        public event EventHandler PosSaved;

        public frmAddEditPos(IPosServices PosService)
            : this(PosService, -1) { }

        public frmAddEditPos(IPosServices PosService, int PosID)
        {
            InitializeComponent();
            _posService = PosService ?? throw new ArgumentNullException(nameof(PosService));

            InitializeForm(PosID);
            ConfigureFormBehavior();
        }





        #region Initialization



        private void InitializeForm(int PosID)
        {
            if (PosID > 0)
            {
                _mode = FormMode.Update;
                this.PosID = PosID;
                ConfigureUpdateMode();
            }
            else
            {
                _mode = FormMode.AddNew;
                _pos = new PosDTO();
                ConfigureAddMode();
            }
        }


        private void ConfigureFormBehavior()
        {
            btnClose.CausesValidation = false;
        }

        private void ConfigureAddMode()
        {
            this.Text = lblTitle.Text = "إضافة نقطة البيع";
            btnSave.Text = "حفظ";
            btnNew.Visible = false;
            lblDepartmentID.Text = "تلقائي";
        }

        private void ConfigureUpdateMode()
        {
            this.Text = lblTitle.Text = "تعديل بيانات نقطة البيع";
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
                await SavePos();
            }
            finally
            {
                btnSave.Enabled = true;
            }


        }

        private async void frmAddEditPos_Load(object sender, EventArgs e)
        {

            if (_mode == FormMode.Update)
            {
                await LoadPosData();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ResetFormForNewEntry();
        }

        #endregion


        #region Validation


        private void txtBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == '.');
        }
        private void txtBalance_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBalance.Text))
            {
                ep.SetError(txtBalance, "يجب إدخال الرصيد الحالي لنقطة البيع ");
                e.Cancel = true;
            }
            else ep.SetError(txtBalance, null);
        }
        private void txtPos_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPos.Text))
            {

                ep.SetError(txtPos, "يجب إدخال أسم نقطة البيع ");
                e.Cancel = true;
            }
            else
                ep.SetError(txtPos, null);


        }

        private bool ValidateForm()
        {
            return ValidateChildren(ValidationConstraints.Enabled);
        }

        #endregion

        #region Data Operations


        private async Task LoadPosData()
        {
            _pos = await _posService.GetInfoAsync(PosID);

            if (_pos == null)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل بيانات نقطة البيع", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            PopulateFormFields();
        }

        private void PopulateFormFields()
        {
            lblDepartmentID.Text = _pos.ID.ToString();
            txtPos.Text = _pos.Name;
            txtBalance.Text = _pos.Balance.ToString();
        }

        private async Task SavePos()
        {
            UpdatePosFromForm();

            bool saveResult = await _posService.SaveAsync(_pos);

            if (saveResult)
            {
                ShowSuccessMessage();
                HandleSuccessfulSave();
                OnPosSaved();
            }
            else
            {
                ShowErrorMessage();
            }
        }


        private void UpdatePosFromForm()
        {
            _pos.Name = txtPos.Text.Trim();
            _pos.Balance = decimal.TryParse(txtBalance.Text.Trim(), out decimal balance) ? balance : 0;

            // TODO: Replace with actual user ID from session/context
            if (_mode == FormMode.AddNew)
            {
                _pos.CreatedByUserID = 1;
            }
            else
            {
                _pos.UpdatedByUserID = 1;
            }
        }

        #endregion


        #region UI Helpers

        private void ResetFormForNewEntry()
        {
            _mode = FormMode.AddNew;
            _pos = new PosDTO();
            ConfigureAddMode();
            ClearFormFields();
        }

        private void ClearFormFields()
        {
            lblDepartmentID.Text = "تلقائي";
            txtPos.Text = string.Empty;
            txtBalance.Text = string.Empty;
        }

        private void ShowSuccessMessage()
        {
            MessageBox.Show("تم الحفظ بنجاح", "تم الحفظ",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowErrorMessage()
        {
            MessageBox.Show("حدث خطأ اثناء الحفظ , يرجي التاكد من عدم انشاء نقطة بيع بنفس الاسم مسبقا",
                "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void HandleSuccessfulSave()
        {
            if (_mode == FormMode.AddNew)
            {
                _mode = FormMode.Update;
                ConfigureUpdateMode();
                lblDepartmentID.Text = _pos.ID.ToString();
            }
        }

        protected virtual void OnPosSaved()
        {
            PosSaved?.Invoke(this, EventArgs.Empty);
        }

        #endregion


       
    }
}
