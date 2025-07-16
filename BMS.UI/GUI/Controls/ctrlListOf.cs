using BMS.BAL;
using BMS.BAL.Interface;
using BMS.DTOs;
using BMS.InfraStructure;
using BMS.InfraStructure.Logging;
using DAL;
using NPOI.SS.Formula.Functions;
using System.Data;
using System.Reflection;
using static BMS.GUI_Helper.TablesNameEnum;

namespace BMS.GUI.Controls
{
    public partial class ctrlListOf<T, TService> : UserControl
        where T : BaseDTOs
    where TService : ICrudService<T>

    {
        private List<T> _dataList = new List<T>();
        private TService _crudService;
        private int _pageNumber = 1;
        private const int PageSize = 8;
        private long _totalRecords;
        private int _loadingDotCount = 1;
        private List<PropertyInfo> _propertes;

        //private enTableNames _TableName { get; set; }

        public ctrlListOf()
        {
            InitializeComponent();
            _propertes = GetAllProperties();
            _ResetControls();
        }

        

        private async void _ResetControls()
        {
            
            _ResetCbxFilterForUsers();
            _ResetDgvUsers();
            await _LoadData();

        }

        private async Task _LoadData(string? filterColumn = null, string? filterValue = null)
        {
            try
            {
                //SetLoadingState(true);

                _dataList = await _crudService.GetAllAsync(_pageNumber, PageSize, filterColumn, filterValue);

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
            //lblLoading.Visible = isLoading;
            //dgvList.Visible = !isLoading;
            //this.Cursor = isLoading ? Cursors.WaitCursor : Cursors.Default;

            //if (isLoading)
            //    timerLoading.Start();
            //else
            //    timerLoading.Stop();
        }

        private void BindDataToGrid()
        {
            dgvList.SuspendLayout();
            dgvList.DataSource = _dataList;
            //_gridFormatter.FormatGrid();
            dgvList.ResumeLayout();

            lblCount.Text = _dataList.Count.ToString();
        }

        private void UpdatePaginationControls()
        {
            btnBack.Enabled = _pageNumber > 1;
            btnForward.Enabled = (_totalRecords > PageSize * _pageNumber);
        }

        private List<PropertyInfo> GetAllProperties()
        {
            return typeof(T).GetProperties().ToList();
        }

        private void _ResetCbxFilterForUsers()
        {
            cbxFilter.Items.Clear();

            foreach (var property in _propertes)
            {
                
                cbxFilter.Items.Add(property.Name);
                
            }

            cbxFilter.SelectedIndex = 0;
        }

        private void _ResetDgvUsers()
        {
            dgvList.DataSource = null;
            dgvList.Columns.Clear();
            dgvList.Rows.Clear();
            dgvList.Refresh();

            foreach (var property in _propertes)
            {
                var column = new DataGridViewTextBoxColumn
                {
                    Name = property.Name,
                    HeaderText = property.Name,
                    DataPropertyName = property.Name,
                    Width = 150,
                    Visible = true
                };
                dgvList.Columns.Add(column);
            }

        }


        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
    }

    
}

