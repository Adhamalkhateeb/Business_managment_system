using BMS.BAL;
using BMS.BAL.Interface;
using BMS.GUI.Controls;

using System.Linq;
using System.Reflection;


namespace BMS.GUI_Helper
{
    public class GenericListControlLogic<T> where T : class
    {
        private readonly GenericListControl _ui;
        private readonly IService<T> _service;
        private readonly GridFormatter<T> _formatter;
        private List<T> _dataList = new();
        private int _pageNumber = 1;
        private const int PageSize = 8;
        private long _totalRecords;




        public GenericListControlLogic(GenericListControl ui, IService<T> service)
        {
            _ui = ui;
            _service = service;
            _formatter = new GridFormatter<T>(_ui.dgvList);
        }

        #region LoadData
        public async Task LoadAsync(string? filterColumn = null, string? filterValue = null)
        {
            try
            {
                SetLoading(true);

                _dataList = await _service.GetAllAsync(_pageNumber, PageSize, filterColumn, filterValue);

                if (_dataList == null)
                {
                    ShowError("حدث خطأ اثناء استرجاع البيانات. يرجى إعادة المحاولة");
                    return;
                }

                BindDataToGrid();
                UpdatePaginationControls();
            }
            finally
            {
                SetLoading(false);
            }
        }

        private void BindDataToGrid()
        {
            _ui.dgvList.SuspendLayout();
            _ui.dgvList.DataSource = _dataList;
            _formatter.FormatGrid();
            _ui.dgvList.ResumeLayout();

            _ui.lblCount.Text = _ui.dgvList.Rows.Count.ToString();
        }


        private void UpdatePaginationControls()
        {
            _ui.btnBack.Enabled = _pageNumber > 1;
            _ui.btnForward.Enabled = (_totalRecords > PageSize * _pageNumber);
        }

        private void SetLoading(bool loading)
        {
            
            _ui.lblLoading.Visible = loading;
            _ui.dgvList.Visible = !loading;
            _ui.Cursor = loading ? Cursors.WaitCursor : Cursors.Default;

            if (loading)
                _ui.timerLoading.Start();
            else
                _ui.timerLoading.Stop();
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion


    }

    public class GridFormatter<T> where T : class
    {
        private readonly DataGridView _grid;

        public GridFormatter(DataGridView grid)
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



            typeof(T).GetProperties().ToList().ForEach(prop =>
             {
                 if (prop.GetCustomAttribute<clsDisplayAttribute>() is clsDisplayAttribute displaysettings)
                 {
                     if (displaysettings.IsTableColumn)
                     {
                         clsglobalSettings.ConfigureColumn(prop.Name, displaysettings.DisplayName, displaysettings.Width, displaysettings.Order, _grid);
                     }
                 }
             });

            _grid.AllowUserToOrderColumns = true;
        }

    }
}

  


