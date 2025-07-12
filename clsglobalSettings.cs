using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Utilities;
using System.Runtime.InteropServices;

namespace BMS.Utilities
{
    public class clsglobalSettings
    {
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
        }
    }
}
