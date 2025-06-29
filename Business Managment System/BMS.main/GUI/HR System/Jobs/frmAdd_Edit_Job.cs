
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BAL;

namespace BMS
{
    public partial class frmAdd_Edit_Job_ٍShow : Form
    {
        private string _JobTitle = string.Empty;
        private Job _job;

        public enum enMode { AddNew = 1, Update = 2, Show = 3 }
        private enMode _Mode = enMode.AddNew;
        public frmAdd_Edit_Job_ٍShow()
        {
            InitializeComponent();

            btnClose.CausesValidation = false;
            this.Text = lblTitle.Text = "إضافة وظيفة";
            _Mode = enMode.AddNew;
        }

        public frmAdd_Edit_Job_ٍShow(string jobTitle, bool Show = false)
        {
            InitializeComponent();

            _JobTitle = jobTitle;
            btnClose.CausesValidation = false;
            if (!Show)
            {
                this.Text = lblTitle.Text = "تعديل وظيفة";
                _Mode = enMode.Update;
            }
            else
            {
                this.Text = lblTitle.Text = "بينات الوظيفة";
                _Mode = enMode.Show;
                btnSave.Visible = false;
                btnClose.Location = new Point(btnSave.Location.X, btnClose.Location.Y);
                txtJob.Enabled = false;
                cbDeaprtments.Enabled = false;
                pnlShowData.Visible = true;
            }
        }

        private async Task LoadDepartments()
        {
            try
            {

                DataTable departments = await Department.GetAllDepartments(null, null);

                
                cbDeaprtments.DisplayMember = "DepartmentName";
                cbDeaprtments.ValueMember = "DepartmentID";
                cbDeaprtments.DataSource = departments;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load departments: " + ex.Message);
            }
        }

        private async Task LoadJobData()
        {
            if (_Mode == enMode.Update || _Mode == enMode.Show)
            {
                _job = await Task.Run(() => Job.GetJob(_JobTitle));
                if (_job == null)
                {
                    MessageBox.Show("لا توجد بيانات للوظيفة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                lblJobID.Text = _job.JobID.ToString();
                txtJob.Text = _job.JobTitle;
                txtJob.SelectAll();
                lblUserID.Text = _job.JobID.ToString();


                if (_job.Department != null)
                {
                    cbDeaprtments.SelectedValue = _job.Department.DepartmentID;
                }
                else
                {
                    cbDeaprtments.SelectedIndex = -1;
                }
            }
            else
            {
                _job = new Job();
            }
        }

        private async void frmAdd_Edit_Job_Load(object? sender, EventArgs? e)
        {
            btnClose.CausesValidation = false;
            txtJob.Focus();
             await LoadDepartments();

             await LoadJobData();

        }

       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void txtDepartment_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtJob.Text))
            {
                e.Cancel = true;
                ep.SetError(txtJob, "يجب إدخال الوظيفة اولا");
            }
            else
                ep.SetError(txtJob, null);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                _job.JobTitle = txtJob.Text;
                if (_Mode == enMode.AddNew)
                {
                    _job.CreatedByUserID = 1;
                    // Here will be Active User ID

                }
                else
                {
                    _job.ModifiedByUserID = 1;
                    // Here will be Active User ID

                }
                _job.DepartmentID =  (int)cbDeaprtments.SelectedValue;

                if (await _job.Save())
                {
                    MessageBox.Show("تم الحفظ بنجاح", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblJobID.Text = _job.JobID.ToString();
                    btnClose.Focus();
                    this.Text = lblTitle.Text = "تعديل الوظيفة";
                    this.btnSave.Text = "تعديل";

                }
                else
                {
                    MessageBox.Show("حدث خطأ أثناء الحفظ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }

            }
        }

        private void cbDeaprtments_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cbDeaprtments.Text))
            {
                e.Cancel = true;
                ep.SetError(cbDeaprtments, "يجب إختيار القسم اولا");
            }
            else
                ep.SetError(cbDeaprtments, null);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
