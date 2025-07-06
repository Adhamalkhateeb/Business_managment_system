using System.Data;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BAL;

namespace BMS
{
    public partial class frmDepartmentList : Form
    {
        private List<Departments> _dtAllDepartments;
        private readonly IDepartmentService _departmentService;
        private int _PageNumber = 1;
        private int _PageSize = 8;



        public  frmDepartmentList(IDepartmentService departmentService)
        {
            InitializeComponent();
            _departmentService = departmentService;
           
        }


        private async Task LoadDepartmentsAsync()
        {
            btnBack.Enabled = _PageNumber > 1;

            clsglobalSettings.AdjustGridDesign(dgvDepartments);

            _dtAllDepartments = await _departmentService.GetAllDepartmentsAsync(_PageNumber, _PageSize);

            if(_dtAllDepartments == null)
            {
                MessageBox.Show("حدث خطأ اثناء استرجاع البينات يرجي اعاده المحاولة"); return;
            }

            dgvDepartments.DataSource = _dtAllDepartments;

            HandleDataGridView();

            btnForward.Enabled = (await _departmentService.GetNumberOfDepartmentsAsync(nameof(Departments)) > _PageSize * _PageNumber);
        }

        private void HandleDataGridView()
        {

            

            foreach (DataGridViewColumn col in dgvDepartments.Columns)
            {
                if (col.Name != "ID" && col.Name != "Name" && col.Name != "Description" && col.Name != "LastUpdatedDate")
                    col.Visible = false;
            }

            

            if (dgvDepartments.Rows.Count > 0)
            {
                cbFilter.Visible = true;

                dgvDepartments.Columns[0].HeaderText = "رقم المسلسل";
                dgvDepartments.Columns[0].Width = 120;

                dgvDepartments.Columns[1].HeaderText = "القسم";
                dgvDepartments.Columns[1].Width = 190;

                dgvDepartments.Columns[2].HeaderText = "وصف القسم";
                dgvDepartments.Columns[2].Width = 250;

                dgvDepartments.Columns[6].HeaderText = "تاريخ التعديل";
                dgvDepartments.Columns[6].Width = 215;
            }

            lblCount.Text = dgvDepartments.Rows.Count.ToString();
        }



        private void frmDepartments_Load(object sender, EventArgs e)
        {

            cbFilter.SelectedIndex = 0;

        }



        private async void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

            btnSearch.Enabled = btnSearch.Visible = txtFilter.Visible = cbFilter.Text != "الكل";

            if (txtFilter.Visible)
            { txtFilter.Focus(); txtFilter.Text = ""; }
            else
               { await LoadDepartmentsAsync(); _PageNumber = 1; }

        }



        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedIndex == 1)
                e.Handled = !char.IsDigit(e.KeyChar) && !(e.KeyChar == (char)Keys.Back);
        }






        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using var frm = new frmAddEditDepartments(_departmentService);
            frm.ShowDialog();

            // Refresh the grid with latest data after adding or editing a department
            await LoadDepartmentsAsync();
        }

        private async void AddDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var frm = new frmAddEditDepartments(_departmentService);
            frm.ShowDialog();
            await LoadDepartmentsAsync();
        }

        private async void UpdateDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvDepartments.CurrentRow.Cells[0].Value);
            using var frm = new frmAddEditDepartments(id,_departmentService);
            frm.ShowDialog();
            await LoadDepartmentsAsync();

        }

        private async void DeleteDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت متأكد انك تريد حذف القسم", "حذف القسم", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            Departments Department = await _departmentService.GetDepartmentAsync((int)(dgvDepartments.CurrentRow.Cells[0].Value));

            if (Department != null && await _departmentService.DeleteDepartmentAsync(Department.ID,Department.UpdatedByUserID))
            {
                MessageBox.Show("تم حذف القسم بنجاح", "حذف القسم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDepartmentsAsync();
            }
            else
            {
                MessageBox.Show("فشل حذف القسم", "حذف القسم", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private async void ShwoDepartmentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var frmDepartmentDetails = new frmDepartmentDetails(Convert.ToInt32(dgvDepartments.CurrentRow.Cells[0].Value));
            frmDepartmentDetails.ShowDialog();

            await LoadDepartmentsAsync();

        }

        private async void buttonForward_Click(object sender, EventArgs e)
        {
            _PageNumber++;
            await LoadDepartmentsAsync();
        }

        private async void buttonBack_Click(object sender, EventArgs e)
        {
            if (_PageNumber > 1)
            {
                _PageNumber--;

                await LoadDepartmentsAsync();

            }

        }

        private void frmDepartments_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {


            string filterColumn = cbFilter.Text switch
            {
                "رقم المسلسل" => "ID",
                "اسم القسم" => "Name",
                _ => string.Empty
            };

            if (string.IsNullOrEmpty(filterColumn) || string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                _PageNumber = 1; // Reset to first page
                await LoadDepartmentsAsync();
                return;
            }



            string filterValue = filterColumn == "ID" ? txtFilter.Text.Trim() : $"%{txtFilter.Text.Trim()}%";

            _PageNumber = 1;
            _dtAllDepartments = await _departmentService.GetAllDepartmentsAsync(_PageNumber, _PageSize, filterColumn, filterValue);
            dgvDepartments.DataSource = _dtAllDepartments;
            lblCount.Text = dgvDepartments.Rows.Count.ToString();



        }

       
    }
}
