using Utilities;
using BAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace BMS
{
    public partial class frmAddEditDepartments : Form
    {
        private int DepartmentID = -1;
        private IDepartmentService _DepartmentService;
        private Departments _Department;
        

        public enum enMode { AddNew = 1, Update = 2 }
        private enMode _Mode = enMode.AddNew;
        public frmAddEditDepartments(IDepartmentService departmentService)
        {
            InitializeComponent();

            _DepartmentService = departmentService;
            _Mode = enMode.AddNew;
            _Department = new Departments();


            btnClose.CausesValidation = false;
            this.Text = lblTitle.Text = "إضافة قسم";

        }

        public frmAddEditDepartments(int departmentID, IDepartmentService departmentService)
        {
            InitializeComponent();


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
                this.btnSave.Text = "تعديل";
                _Mode = enMode.Update;

            }
            else
            {
                MessageBox.Show("حدث خطأ أثناء الحفظ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }

            btnNew.Visible = true;
            btnNew.Focus();


        }

        private async void frmAddEditDepartments_Load_1(object sender, EventArgs e)
        {

            txtDepartment.Focus();
           


            btnClose.CausesValidation = false;


            if (_Mode == enMode.Update)
            {
                _Department = await _DepartmentService.GetDepartmentAsync(DepartmentID);

                if (_Department != null)
                {
                    lblDepartmentID.Text = _Department.ID.ToString();
                    txtDepartment.Text = _Department.Name;
                    txtDescription.Text = _Department.Description ?? "";
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

        }
    }
}
