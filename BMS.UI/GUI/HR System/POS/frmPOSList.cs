using BMS.BAL;
using BMS.BAL.Interface;
using BMS.DTOs;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMS.GUI.HR_System.POS
{
    public partial class frmPOSList : Form
    {
        private List<PosDTO> _pos;
        private readonly IPosServices _posServices;
        private int _pageNumber = 1;
        private const int PageSize = 8;
        private long _totalRecords;
        private int _loadingDotCount = 1;
        private readonly PosGridFormatter _gridFormatter;
        private readonly PosExporter _exporter;
        public frmPOSList(IPosServices posServices)
        {
            InitializeComponent();

            _posServices = posServices;
            _gridFormatter = new PosGridFormatter(dgvPOS);
            _exporter = new PosExporter();
        }


        #region Form Lifecycle
        private async void frmPOS_Load(object sender, EventArgs e)
        {

            cbFilter.SelectedIndex = 0;
            _totalRecords = await _posServices.GetCountAsync("POS");
            await LoadPosAsync();

        }

        private void frmPosList_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        #endregion


        #region Data Loading
        private async Task LoadPosAsync(string filterColumn = null, string filterValue = null)
        {
            try
            {
                SetLoadingState(true);

                _pos = await _posServices.GetAllAsync(_pageNumber, PageSize, filterColumn, filterValue);

                if (_pos == null)
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
            dgvPOS.Visible = !isLoading;
            this.Cursor = isLoading ? Cursors.WaitCursor : Cursors.Default;

            if (isLoading)
                timerLoading.Start();
            else
                timerLoading.Stop();
        }

        private void BindDataToGrid()
        {
            dgvPOS.SuspendLayout();
            dgvPOS.DataSource = _pos;
            _gridFormatter.FormatGrid();
            dgvPOS.ResumeLayout();

            lblCount.Text = _pos.Count.ToString();
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
                await LoadPosAsync();
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
            await ShowPosForm(null);

        }

      

        private async void AddPosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ShowPosForm(null);

        }

        private async void UpdatePosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedPosId(out int id)) return;
            await ShowPosForm(id);

        }

        private async Task ShowPosForm(int? PosID)
        {
            using var form = PosID.HasValue ?
                new frmAddEditPos(_posServices, PosID.Value) :
                new frmAddEditPos(_posServices);

            form.PosSaved += async (s, e) =>
            {
                _totalRecords++;
                await LoadPosAsync();
            };

            form.ShowDialog();


        }

        private async void DeletePosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedPosId(out int id)) return;

            if (!ConfirmDeletion()) return;

            var result = await TryDeletePosAsync(id);
            ShowDeletionResult(result);
        }

        private async Task<bool> TryDeletePosAsync(int id)
        {
            var Pos = await _posServices.GetInfoAsync(id);
            if (Pos == null) return false;

            return await _posServices.DeleteAsync(Pos.ID, Pos.UpdatedByUserID);
        }


        private bool ConfirmDeletion()
        {
            return MessageBox.Show("هل انت متأكد انك تريد حذف نقطة البيع",
                "حذف نقطة البيع",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }


        private void ShowDeletionResult(bool success)
        {
            if (success)
            {
                MessageBox.Show("تم حذف نقطة البيع بنجاح", "حذف نقطة البيع ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _totalRecords--;
                LoadPosAsync();
            }
            else
            {
                MessageBox.Show("فشل حذف نقطة البيع ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void ShowPosDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (!TryGetSelectedPosId(out int id)) return;

            //using var frmDepartmentDetails = new frmDepartmentDetails(id, _posServices);
            //frmDepartmentDetails.ctrlDepartmenttInfo2.DepartmentUpdated += async (s, eArgs) =>
            //{
            //    await LoadPosAsync();
            //};
            //frmDepartmentDetails.ShowDialog();



        }

        private async void buttonForward_Click(object sender, EventArgs e)
        {
            _pageNumber++;
            await LoadPosAsync();
        }

        private async void buttonBack_Click(object sender, EventArgs e)
        {
            if (_pageNumber > 1)
            {
                _pageNumber--;
                await LoadPosAsync();
            }

        }


        private async void btnSearch_Click(object sender, EventArgs e)
        {


            string filterColumn = cbFilter.Text switch
            {
                "رقم المسلسل" => "ID",
                "اسم نقطة البيع" => "Name",
                _ => string.Empty
            };

            if (string.IsNullOrEmpty(filterColumn) || string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                _pageNumber = 1;
                await LoadPosAsync();
                return;
            }

            string filterValue = filterColumn == "ID" ?
                txtFilter.Text.Trim() :
                $"%{txtFilter.Text.Trim()}%";

            _pageNumber = 1;
            await LoadPosAsync(filterColumn, filterValue);
        }


        private async void dgvPos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0) return;
            //if (!TryGetSelectedPosId(out int id)) return;

            //using var form = new frmDepartmentDetails(id, _posServices);
            //form.ctrlDepartmenttInfo2.DepartmentUpdated += async (s, eArgs) =>
            //{
            //    await LoadPosAsync();
            //};

            //form.ShowDialog();


        }



        private async void btnExport_Click(object sender, EventArgs e)
        {
            if (_pos == null || !_pos.Any())
            {
                ShowWarningMessage("لا توجد بيانات للتصدير");
                return;
            }

            string filePath = GetExportFilePath();
            if (string.IsNullOrEmpty(filePath)) return;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                _exporter.ExportToExcel(await _posServices.GetAllAsync(null, null, null, null), filePath);

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




        private bool TryGetSelectedPosId(out int id)
        {
            id = -1;
            if (dgvPOS.CurrentRow == null)
            {
                MessageBox.Show("يرجى اختيار نقطة بيع أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            id = Convert.ToInt32(dgvPOS.CurrentRow.Cells["ID"].Value);
            return true;
        }

        private string GetExportFilePath()
        {
            using var saveDialog = new SaveFileDialog
            {
                Filter = "Excel WorkBook (*.xlsx)|*.xlsx",
                Title = "تصدير نثاط البيع إلى ملف Excel",
                FileName = "Point of Sales.xlsx"
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
        

        public class PosGridFormatter
        {
            private readonly DataGridView _grid;

            public PosGridFormatter(DataGridView grid)
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

                clsglobalSettings.ConfigureColumn("ID", "رقم المسلسل", 120, 0, _grid);
                clsglobalSettings.ConfigureColumn("Name", "نقطة البيع", 190, 1, _grid);
                clsglobalSettings.ConfigureColumn("Balance", "الرصيد الحالي", 250, 2, _grid);
                clsglobalSettings.ConfigureColumn("LastUpdatedDate", "تاريخ التعديل", 215, 3, _grid);

                _grid.AllowUserToOrderColumns = true;
            }


        }


        public class PosExporter
        {
            public void ExportToExcel(List<PosDTO> Pos, string filePath)
            {
                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Point of sales");


                worksheet.Cell(1, 1).Value = "رقم المسلسل";
                worksheet.Cell(1, 2).Value = "نقطة البيع";
                worksheet.Cell(1, 3).Value = "الرصيد الحالي";
                worksheet.Cell(1, 4).Value = "تاريخ التعديل";


                var data = Pos.Select(d => new
                {
                    d.ID,
                    d.Name,
                    d.Balance,
                    d.LastUpdatedDate
                });

                worksheet.Cell(2, 1).InsertData(data);


                var range = worksheet.Range(1, 1, Pos.Count + 1, 4);
                var table = range.CreateTable();
                table.Theme = XLTableTheme.TableStyleMedium13;
                worksheet.Columns().AdjustToContents();
                worksheet.RightToLeft = true;

                workbook.SaveAs(filePath);
            }
        }
    }
}
