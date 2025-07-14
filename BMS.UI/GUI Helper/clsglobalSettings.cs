

namespace BMS
{
   public  class clsglobalSettings
    {
      
        private readonly frmMain main;

        public clsglobalSettings(frmMain main)
        {
            this.main = main;
        }

        static public void AdjustGridDesign(DataGridView dataGridView)
        {

           
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2C3E50");
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersHeight = 45;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14F, FontStyle.Bold);


            dataGridView.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F8F9FA");
            dataGridView.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#2C3E50");

           
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#E9ECEF");

            dataGridView.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#3498DB");
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView.AllowUserToOrderColumns = true;
        }


        public  static  void ConfigureColumn(string name, string headerText, int width, int displayIndex, DataGridView dgv)
        {
            var column = dgv.Columns[name];
            column.HeaderText = headerText;
            column.Width = width;
            column.Visible = true;
            column.DisplayIndex = displayIndex;
        }

    }
}
