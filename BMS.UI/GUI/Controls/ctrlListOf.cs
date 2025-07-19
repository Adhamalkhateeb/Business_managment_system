using BMS;
using BMS.BAL;
using BMS.BAL.Interface;
using BMS.GUI_Helper;
using DAL;
using NPOI.SS.Formula.Functions;
using System.Data;
using System.Reflection;


namespace BMS.GUI.Controls
{
    public partial class GenericListControl : UserControl
    {

        private object? _logicInstance;
        private int _loadingDotCount = 1;


        public void Init<T>(IService<T> service) where T : class
        {
            var logic = new GenericListControlLogic<T>(this, service);
            _logicInstance = logic;
            _ = logic.LoadAsync();
        }

        public GenericListControl()
        {
            InitializeComponent();
          
        }





  
       
       

        



       
       

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void timerLoading_Tick(object sender, EventArgs e)
        {
            _loadingDotCount = (_loadingDotCount % 3) + 1;
            lblLoading.Text = "جاري التحميل" + new string('.', _loadingDotCount);
        }
    }




   


    //public class Exporter<T>
    //    where T : class
    //{
    //    public void ExportToExcel(List<T> Table, string filePath)
    //    {
    //        using var workbook = new XLWorkbook();
    //        var worksheet = workbook.Worksheets.Add(nameof(Table));


    //        worksheet.Cell(1, 1).Value = "رقم المسلسل";
    //        worksheet.Cell(1, 2).Value = "القسم";
    //        worksheet.Cell(1, 3).Value = "وصف القسم";
    //        worksheet.Cell(1, 4).Value = "تاريخ التعديل";


    //        var data = departments.Select(d => new
    //        {
    //            d.ID,
    //            d.Name,
    //            d.Description,
    //            d.LastUpdatedDate
    //        });

    //        worksheet.Cell(2, 1).InsertData(data);


    //        var range = worksheet.Range(1, 1, departments.Count + 1, 4);
    //        var table = range.CreateTable();
    //        table.Theme = XLTableTheme.TableStyleMedium13;
    //        worksheet.Columns().AdjustToContents();
    //        worksheet.RightToLeft = true;

    //        workbook.SaveAs(filePath);
    //    }
    //}
}

