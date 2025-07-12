
using BMS.BAL.Interface;
using BMS.DTOs;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Diagnostics;
using System.Windows.Forms;


namespace BMS
{
    public partial class frmDepartmentList : Form
    {
        private List<DepartmentDTO> _dtAllDepartments;
        private readonly IDepartmentService _departmentService;
        private int _PageNumber = 1;
        private int _PageSize = 8;



        public frmDepartmentList(IDepartmentService departmentService)
        {
            InitializeComponent();
            _departmentService = departmentService;
            // dgvDepartments.RightToLeft = RightToLeft.Yes;


        }






        private async void frmDepartments_Load(object sender, EventArgs e)
        {

            cbFilter.SelectedIndex = 0;
            await LoadDepartmentsAsync();

        }


        private async Task LoadDepartmentsAsync()
        {
            btnBack.Enabled = _PageNumber > 1;

            clsglobalSettings.AdjustGridDesign(dgvDepartments);

            _dtAllDepartments = await _departmentService.GetAllAsync(_PageNumber, _PageSize, null, null);

            if (_dtAllDepartments == null)
            {
                MessageBox.Show("حدث خطأ اثناء استرجاع البيانات. يرجى إعادة المحاولة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvDepartments.DataSource = _dtAllDepartments;

            FormatGrid();

            btnForward.Enabled = (await _departmentService.GetCountAsync("Departments") > _PageSize * _PageNumber);
        }





        private void FormatGrid()
        {
            


            foreach (DataGridViewColumn col in dgvDepartments.Columns)
            {
                col.Visible = false;
            }


            dgvDepartments.Columns["ID"].HeaderText = "رقم المسلسل";
            dgvDepartments.Columns["ID"].Width = 120;
            dgvDepartments.Columns["ID"].Visible = true;
            dgvDepartments.Columns["ID"].DisplayIndex = 0;

            dgvDepartments.Columns["Name"].HeaderText = "القسم";
            dgvDepartments.Columns["Name"].Width = 190;
            dgvDepartments.Columns["Name"].Visible = true;
            dgvDepartments.Columns["Name"].DisplayIndex = 1;

            dgvDepartments.Columns["Description"].HeaderText = "وصف القسم";
            dgvDepartments.Columns["Description"].Width = 250;
            dgvDepartments.Columns["Description"].Visible = true;
            dgvDepartments.Columns["Description"].DisplayIndex = 2;

            dgvDepartments.Columns["LastUpdatedDate"].HeaderText = "تاريخ التعديل";
            dgvDepartments.Columns["LastUpdatedDate"].Width = 215;
            dgvDepartments.Columns["LastUpdatedDate"].Visible = true;
            dgvDepartments.Columns["LastUpdatedDate"].DisplayIndex = 3;



            cbFilter.Visible = true;
        }




        private async void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isAll = cbFilter.Text == "الكل";
            btnSearch.Enabled = btnSearch.Visible = txtFilter.Visible = !isAll;



            if (!isAll)
            {
                txtFilter.Text = "";
                txtFilter.Focus();
            }
            else
            {
                _PageNumber = 1;
                await LoadDepartmentsAsync();
            }

        }



        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedIndex == 1)
                e.Handled = !char.IsDigit(e.KeyChar) && !(e.KeyChar == (char)Keys.Back);
        }






        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using var frm = new frmAddEditDepartments(_departmentService);
            frm.DepartmentSaved += async (s, e) =>
            {
                await LoadDepartmentsAsync();
            };

            frm.ShowDialog();

            // Refresh the grid with latest data after adding or editing a department

        }

        private async void AddDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var frm = new frmAddEditDepartments(_departmentService);
            frm.DepartmentSaved += async (s, e) =>
            {
                await LoadDepartmentsAsync();
            };
            frm.ShowDialog();

        }

        private async void UpdateDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedDepartmentId(out int id)) return;

            using var frm = new frmAddEditDepartments(id, _departmentService);
            frm.DepartmentSaved += async (s, e) =>
            {
                await LoadDepartmentsAsync();
            };
            frm.ShowDialog();


        }

        private async void DeleteDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedDepartmentId(out int id)) return;

            if (MessageBox.Show("هل انت متأكد انك تريد حذف القسم", "حذف القسم", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;


            DepartmentDTO Department = await _departmentService.GetInfoAsync(id);

            if (Department != null && await _departmentService.DeleteAsync(Department.ID, Department.UpdatedByUserID))
            {
                MessageBox.Show("تم حذف القسم بنجاح", "حذف القسم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDepartmentsAsync();
            }
            else
            {
                MessageBox.Show("فشل حذف القسم", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void ShwoDepartmentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedDepartmentId(out int id)) return;

            using var frmDepartmentDetails = new frmDepartmentDetails(id, _departmentService);
            frmDepartmentDetails.ctrlDepartmenttInfo2.DepartmentUpdated += async (s, eArgs) =>
            {
                await LoadDepartmentsAsync();
            };
            frmDepartmentDetails.ShowDialog();



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
                _PageNumber = 1;
                await LoadDepartmentsAsync();
                return;
            }



            string filterValue = filterColumn == "ID" ? txtFilter.Text.Trim() : $"%{txtFilter.Text.Trim()}%";

            _PageNumber = 1;
            _dtAllDepartments = await _departmentService.GetAllAsync(_PageNumber, _PageSize, filterColumn, filterValue);
            dgvDepartments.DataSource = _dtAllDepartments;
            lblCount.Text = dgvDepartments.Rows.Count.ToString();



        }



        private bool TryGetSelectedDepartmentId(out int id)
        {
            id = -1;
            if (dgvDepartments.CurrentRow == null)
            {
                MessageBox.Show("يرجى اختيار قسم أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            id = Convert.ToInt32(dgvDepartments.CurrentRow.Cells["ID"].Value);
            return true;
        }

        private void dgvDepartments_DoubleClick(object sender, EventArgs e)
        {

        }

        private async void dgvDepartments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (!TryGetSelectedDepartmentId(out int id)) return;

                using var frm = new frmDepartmentDetails(id, _departmentService);
                frm.ctrlDepartmenttInfo2.DepartmentUpdated += async (s, eArgs) =>
                {
                    await LoadDepartmentsAsync();
                };
                frm.ShowDialog();

            }
        }



        private async void btnExport_Click(object sender, EventArgs e)
        {
            if (_dtAllDepartments == null || !_dtAllDepartments.Any())
            {
                MessageBox.Show("لا توجد بيانات للتصدير", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using SaveFileDialog svg = new SaveFileDialog
            {
                Filter = "Excel WorkBook (*.xlsx)|*.xlsx",
                Title = "تصدير الأقسام إلى ملف Excel",
                FileName = "Departments.xlsx"
            };

            if (svg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Departments");


                        worksheet.Cell(1, 1).Value = "رقم المسلسل";
                        worksheet.Cell(1, 2).Value = "القسم";
                        worksheet.Cell(1, 3).Value = "وصف القسم";
                        worksheet.Cell(1, 4).Value = "تاريخ التعديل";


                        int row = 2;
                        var orderedData = _dtAllDepartments.Select(d => new
                        {
                            ID = d.ID,
                            Name = d.Name,
                            Description = d.Description,
                            LastUpdatedDate = d.LastUpdatedDate
                        });

                        worksheet.Cell(2, 1).InsertData(orderedData);


                        var range = worksheet.Range(1, 1, _dtAllDepartments.Count + 1, 4);
                        var table = range.CreateTable();
                        table.Theme = XLTableTheme.TableStyleMedium13;
                        worksheet.Columns().AdjustToContents();
                        worksheet.RightToLeft = true;

                        workbook.SaveAs(svg.FileName);
                    }

                    if (MessageBox.Show("تم تصدير البيانات بنجاح. هل تريد فتح الملف الآن؟",
                                      "نجاح", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Process.Start(new ProcessStartInfo(svg.FileName) { UseShellExecute = true });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"فشل تصدير البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void dgvDepartments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
