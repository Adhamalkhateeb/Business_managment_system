using System.Data;
using BAL;

namespace BMS
{
    public partial class frmDepartmentList : Form
    {
        private DataTable _dtAllDepartments;
        private int _PageNumber = 1;
        private int _PageSize = 8;

        public frmDepartmentList()
        {
            InitializeComponent();

        }


        private async void frmDepartments_Load(object sender, EventArgs e)
        {

            btnBack.Enabled = _PageNumber > 1;



            clsglobalSettings.AdjustGridDesign(dgvDepartments);

            _dtAllDepartments = await Task.Run(() => Department.GetAllDepartments(_PageNumber, _PageSize));
            dgvDepartments.DataSource = _dtAllDepartments;
            cbFilter.SelectedIndex = 0;


            lblCount.Text = dgvDepartments.Rows.Count.ToString();


            if (dgvDepartments.Rows.Count > 0)
            {

                cbFilter.Visible = true;

                dgvDepartments.Columns[0].HeaderText = "رقم المسلسل";
                dgvDepartments.Columns[0].Width = 120;

                dgvDepartments.Columns[1].HeaderText = "القسم";
                dgvDepartments.Columns[1].Width = 190;

                dgvDepartments.Columns[2].HeaderText = "وصف القسم";
                dgvDepartments.Columns[2].Width = 300;

                dgvDepartments.Columns[3].HeaderText = "تاريخ التعديل";
                dgvDepartments.Columns[3].Width = 165;
            }

            btnForward.Enabled = (dgvDepartments.Rows.Count == 8);
        }



        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

            btnSearch.Enabled = btnSearch.Visible  = txtFilter.Visible = cbFilter.Text != "الكل";

            if (txtFilter.Visible)
                { txtFilter.Focus();  txtFilter.Text = ""; }
            else
                frmDepartments_Load(null, null);
                
           



        }



        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedIndex == 1)
                e.Handled = !char.IsDigit(e.KeyChar) && !(e.KeyChar == (char)Keys.Back);
        }

        




        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddEditDepartments frm = new frmAddEditDepartments();
            frm.ShowDialog();

            // Refresh the grid with latest data after adding or editing a department
            frmDepartments_Load(null, null);
        }

        private void AddDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditDepartments frm = new frmAddEditDepartments();
            frm.ShowDialog();
            frmDepartments_Load(null, null);
        }

        private void UpdateDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditDepartments frm = new frmAddEditDepartments(Convert.ToInt32(dgvDepartments.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
            frmDepartments_Load(null, null);
        }

        private async void حذفالقسمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت متأكد انك تريد حذف القسم", "حذف القسم", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            Department _Department = await Department.GetDepartment((int)(dgvDepartments.CurrentRow.Cells[0].Value));

            if (_Department != null && await _Department.DeleteDepartment())
            {
                MessageBox.Show("تم حذف القسم بنجاح", "حذف القسم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmDepartments_Load(null, null);
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

        private void ShwoDepartmentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepartmentDetails frmDepartmentDetails = new frmDepartmentDetails(Convert.ToInt32(dgvDepartments.CurrentRow.Cells[0].Value));
            frmDepartmentDetails.ShowDialog();


            frmDepartments_Load(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _PageNumber++;
            frmDepartments_Load(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_PageNumber > 1)
            {
                _PageNumber--;

                frmDepartments_Load(null, null);

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
                "رقم المسلسل" => "DepartmentID",
                "اسم القسم" => "DepartmentName",
                _ => string.Empty
            };

            if (string.IsNullOrEmpty(filterColumn) || string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                _PageNumber = 1; // Reset to first page
                frmDepartments_Load(null, null);
                return;
            }



            string filterValue = filterColumn == "DepartmentID" ? txtFilter.Text.Trim() : $"%{txtFilter.Text.Trim()}%";

            _PageNumber = 1; 
            _dtAllDepartments = await Department.GetAllDepartments(_PageNumber, _PageSize, filterColumn, filterValue);
            dgvDepartments.DataSource = _dtAllDepartments;
            lblCount.Text = dgvDepartments.Rows.Count.ToString();


          
        }
    }
}
