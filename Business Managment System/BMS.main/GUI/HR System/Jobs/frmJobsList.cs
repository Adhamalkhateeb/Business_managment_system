
using BAL;
using System.Data;


namespace BMS
{
    public partial class frmJobsList : Form
    {

        private DataTable? _dtAllJobs;
        private int _PageNumber = 1;
        private int _PageSize = 8;
        public frmJobsList() => InitializeComponent();

        private async void frmJobsList_Load(object? sender, EventArgs? e)
        {

            btnBack.Enabled = _PageNumber > 1;
            clsglobalSettings.AdjustGridDesign(dgvJobs);

            _dtAllJobs = await Task.Run(() => Job.GetAllJobs(_PageNumber, _PageSize));
            dgvJobs.DataSource = _dtAllJobs;
            cbFilter.SelectedIndex = 0;


            lblCount.Text = dgvJobs.Rows.Count.ToString();


            if (dgvJobs.Rows.Count > 0)
            {
                cbFilter.Visible = true;



                dgvJobs.Columns[0].HeaderText = "الوظيفة";
                dgvJobs.Columns[0].Width = 190;

                dgvJobs.Columns[1].HeaderText = "القسم التابع";
                dgvJobs.Columns[1].Width = 190;

                dgvJobs.Columns[2].HeaderText = "تاريخ التعديل";
                dgvJobs.Columns[2].Width = 170;
            }


            btnForward.Enabled = (dgvJobs.Rows.Count == 8);
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSearch.Enabled = btnSearch.Visible = txtFilter.Visible = cbFilter.Text != "الكل";

            if (txtFilter.Visible)
            { txtFilter.Focus(); txtFilter.Text = ""; }
            else
                frmJobsList_Load(null, null);
        }

       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAdd_Edit_Job_ٍShow frmAdd_Edit_Job = new frmAdd_Edit_Job_ٍShow();
            frmAdd_Edit_Job.ShowDialog();
            frmJobsList_Load(null, null);

        }

        private void AddDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdd_Edit_Job_ٍShow frmAdd_Edit_Job = new frmAdd_Edit_Job_ٍShow();
            frmAdd_Edit_Job.ShowDialog();
        }

        private async void حذفالقسمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت متأكد انك تريد حذف الوظيفة ", "حذف الوظيفة ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            Job JOB = await Job.GetJob((string)dgvJobs.CurrentRow.Cells[0].Value);

            if (JOB != null && await (JOB.DeleteJob()))
            {
                MessageBox.Show("تم حذف  الوظيفة بنجاح", "حذف الوظيفة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmJobsList_Load(null, null);
            }
            else
            {
                MessageBox.Show("فشل  حذف الوظيفة", "حذف الوظيفة", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void UpdateJobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdd_Edit_Job_ٍShow frmAdd_Edit_Job = new frmAdd_Edit_Job_ٍShow((string)dgvJobs.CurrentRow.Cells[0].Value);
            frmAdd_Edit_Job.ShowDialog();
            frmJobsList_Load(null, null);
        }

        private void عرضالوظيفةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdd_Edit_Job_ٍShow frmAdd_Edit_Job = new frmAdd_Edit_Job_ٍShow((string)dgvJobs.CurrentRow.Cells[0].Value, true);
            frmAdd_Edit_Job.ShowDialog();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            _PageNumber++;
            frmJobsList_Load(null, null);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (_PageNumber > 1)
            {
                _PageNumber--;

                frmJobsList_Load(null, null);

            }
        }

        private void frmJobsList_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string filterColumn = cbFilter.Text switch
            {
                "الوظيفة" => "JobTitle",
                "القسم" => "DepartmentName",
                _ => string.Empty
            };

            if (string.IsNullOrEmpty(filterColumn) || string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                _PageNumber = 1; // Reset to first page
                frmJobsList_Load(null, null);
                return;
            }



            string filterValue = $"%{txtFilter.Text.Trim()}%";

            _PageNumber = 1;
            _dtAllJobs = await Job.GetAllJobs(_PageNumber, _PageSize, filterColumn, filterValue);
            dgvJobs.DataSource = _dtAllJobs;
            lblCount.Text = dgvJobs.Rows.Count.ToString();


        }
    }
}
