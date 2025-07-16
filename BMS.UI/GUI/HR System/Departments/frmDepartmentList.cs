
using BMS;
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
        private List<DepartmentDTO> _dataList;
        private readonly IDepartmentService _dataListervice;
        private int _pageNumber = 1;
        private const int PageSize = 8;
        private long _totalRecords;
        private int _loadingDotCount = 1;
        private readonly DepartmentGridFormatter _gridFormatter;
        private readonly DepartmentExporter _exporter;

        public frmDepartmentList(IDepartmentService departmentService)
        {
            InitializeComponent();
            _dataListervice = departmentService;
            _gridFormatter = new DepartmentGridFormatter(dgvList);
            _exporter = new DepartmentExporter();
        }

        #region Form Lifecycle
        private async void frmDepartments_Load(object sender, EventArgs e)
        {
            
            cbFilter.SelectedIndex = 0;
            _totalRecords = await _dataListervice.GetCountAsync("Departments");
            await LoadDepartmentsAsync();

        }

        private void frmDepartmentList_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        #endregion

        #region Data Loading
        private async Task LoadDepartmentsAsync(string filterColumn = null, string filterValue = null)
        {
            try
            {
                SetLoadingState(true);

                _dataList = await _dataListervice.GetAllAsync(_pageNumber, PageSize, filterColumn, filterValue);

                if (_dataList == null)
                {
                    ShowErrorMessage("حدث خطأ اثناء استرجاع البيانات. يرجى إعادة المحاولة");
                    return;
                }

                BindDataToGrid();
                UpdatePaginationControls();
            }
            finally
            {
                SetLoadingState(false);
            }
        }

        private void SetLoadingState(bool isLoading)
        {
            lblLoading.Visible = isLoading;
            dgvList.Visible = !isLoading;
            this.Cursor = isLoading ? Cursors.WaitCursor : Cursors.Default;

            if (isLoading)
                timerLoading.Start();
            else
                timerLoading.Stop();
        }

        private void BindDataToGrid()
        {
            dgvList.SuspendLayout();
            dgvList.DataSource = _dataList;
            _gridFormatter.FormatGrid();
            dgvList.ResumeLayout();

            lblCount.Text = _dataList.Count.ToString();
        }

        private void UpdatePaginationControls()
        {
            btnBack.Enabled = _pageNumber > 1;
            btnForward.Enabled = (_totalRecords > PageSize * _pageNumber);
        }

        #endregion

        #region Event Handlers


        private async void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool showAll = cbFilter.Text == "الكل";
            btnSearch.Enabled = btnSearch.Visible = txtFilter.Visible = !showAll;

            if (showAll)
            {
                _pageNumber = 1;
                await LoadDepartmentsAsync();
            }
            else
            {
                txtFilter.Clear();
                txtFilter.Focus();
            }

        }



        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedIndex == 1)
                e.Handled = !char.IsDigit(e.KeyChar) && !(e.KeyChar == (char)Keys.Back);
        }


        private async void btnAdd_Click(object sender, EventArgs e)
        {
            await ShowDepartmentForm(null);

        }

        private async void AddDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ShowDepartmentForm(null);

        }

        private async void UpdateDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedDepartmentId(out int id)) return;
            await ShowDepartmentForm(id);

        }

        private async Task ShowDepartmentForm(int? departmentId)
        {
            using var form = departmentId.HasValue ?
                new frmAddEditDepartments( _dataListervice, departmentId.Value) :
                new frmAddEditDepartments(_dataListervice);

            form.DepartmentSaved += async (s, e) =>
            {
                _totalRecords++;
                await LoadDepartmentsAsync();
            };

            form.ShowDialog();

           
        }

        private async void DeleteDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedDepartmentId(out int id)) return;

            if (!ConfirmDeletion()) return;

            var result = await TryDeleteDepartmentAsync(id);
            ShowDeletionResult(result);
        }

        private async Task<bool> TryDeleteDepartmentAsync(int id)
        {
            var department = await _dataListervice.GetInfoAsync(id);
            if (department == null) return false;

            return await _dataListervice.DeleteAsync(department.ID, department.UpdatedByUserID);
        }


        private bool ConfirmDeletion()
        {
            return MessageBox.Show("هل انت متأكد انك تريد حذف القسم",
                "حذف القسم",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }


        private void ShowDeletionResult(bool success)
        {
            if (success)
            {
                MessageBox.Show("تم حذف القسم بنجاح", "حذف القسم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _totalRecords--;
                LoadDepartmentsAsync();
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

            using var frmDepartmentDetails = new frmDepartmentDetails(id, _dataListervice);
            frmDepartmentDetails.ctrlDepartmenttInfo2.DepartmentUpdated += async (s, eArgs) =>
            {
                await LoadDepartmentsAsync();
            };
            frmDepartmentDetails.ShowDialog();

            

        }

        private async void buttonForward_Click(object sender, EventArgs e)
        {
            _pageNumber++;
            await LoadDepartmentsAsync();
        }

        private async void buttonBack_Click(object sender, EventArgs e)
        {
            if (_pageNumber > 1)
            {
                _pageNumber--;
                await LoadDepartmentsAsync();
            }

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
                _pageNumber = 1;
                await LoadDepartmentsAsync();
                return;
            }

            string filterValue = filterColumn == "ID" ?
                txtFilter.Text.Trim() :
                $"%{txtFilter.Text.Trim()}%";

            _pageNumber = 1;
            await LoadDepartmentsAsync(filterColumn, filterValue);
        }


        private async void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!TryGetSelectedDepartmentId(out int id)) return;

            using var form = new frmDepartmentDetails(id, _dataListervice);
            form.ctrlDepartmenttInfo2.DepartmentUpdated += async (s, eArgs) =>
            {
                await LoadDepartmentsAsync();
            };

            form.ShowDialog();

           
        }



        private async void btnExport_Click(object sender, EventArgs e)
        {
            if (_dataList == null || !_dataList.Any())
            {
                ShowWarningMessage("لا توجد بيانات للتصدير");
                return;
            }

            string filePath = GetExportFilePath();
            if (string.IsNullOrEmpty(filePath)) return;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                _exporter.ExportToExcel(await _dataListervice.GetAllAsync(null,null,null,null), filePath);

                if (ConfirmOpenExportedFile())
                {
                    OpenExportedFile(filePath);
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"فشل تصدير البيانات: {ex.Message}");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        



        private void timerLoading_Tick(object sender, EventArgs e)
        {
            _loadingDotCount = (_loadingDotCount % 3) + 1;
            lblLoading.Text = "جاري التحميل" + new string('.', _loadingDotCount);
        }
        #endregion

        #region Helper Methods




        private bool TryGetSelectedDepartmentId(out int id)
        {
            id = -1;
            if (dgvList.CurrentRow == null)
            {
                MessageBox.Show("يرجى اختيار قسم أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            id = Convert.ToInt32(dgvList.CurrentRow.Cells["ID"].Value);
            return true;
        }

        private string GetExportFilePath()
        {
            using var saveDialog = new SaveFileDialog
            {
                Filter = "Excel WorkBook (*.xlsx)|*.xlsx",
                Title = "تصدير الأقسام إلى ملف Excel",
                FileName = "Departments.xlsx"
            };

            return saveDialog.ShowDialog() == DialogResult.OK ? saveDialog.FileName : null;
        }

        private bool ConfirmOpenExportedFile()
        {
            return MessageBox.Show("تم تصدير البيانات بنجاح. هل تريد فتح الملف الآن؟",
                "نجاح", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void OpenExportedFile(string filePath)
        {
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }

        private void ShowWarningMessage(string message)
        {
            MessageBox.Show(message, "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

    }


}

    public class DepartmentGridFormatter
    {
        private readonly DataGridView _grid;

        public DepartmentGridFormatter(DataGridView grid)
        {
            _grid = grid;
        }

        public void FormatGrid()
        {
            clsglobalSettings.AdjustGridDesign(_grid);

        _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            foreach (DataGridViewColumn col in _grid.Columns)
            {
                col.Visible = false;
            }

            clsglobalSettings.ConfigureColumn("ID", "رقم المسلسل", 120, 0,_grid);
            clsglobalSettings.ConfigureColumn("Name", "القسم", 190, 1,_grid);
            clsglobalSettings.ConfigureColumn("Description", "وصف القسم", 250, 2, _grid);
            clsglobalSettings.ConfigureColumn("LastUpdatedDate", "تاريخ التعديل", 215, 3, _grid);

            _grid.AllowUserToOrderColumns = true;
        }

        
    }


    public class DepartmentExporter
    {
        public void ExportToExcel( List<DepartmentDTO> departments,string filePath)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Departments");

           
            worksheet.Cell(1, 1).Value = "رقم المسلسل";
            worksheet.Cell(1, 2).Value = "القسم";
            worksheet.Cell(1, 3).Value = "وصف القسم";
            worksheet.Cell(1, 4).Value = "تاريخ التعديل";

           
            var data = departments.Select(d => new
            {
                d.ID,
                d.Name,
                d.Description,
                d.LastUpdatedDate
            });

            worksheet.Cell(2, 1).InsertData(data);

          
            var range = worksheet.Range(1, 1, departments.Count + 1, 4);
            var table = range.CreateTable();
            table.Theme = XLTableTheme.TableStyleMedium13;
            worksheet.Columns().AdjustToContents();
            worksheet.RightToLeft = true;

            workbook.SaveAs(filePath);
        }
    }

