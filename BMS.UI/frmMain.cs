

using BMS.GUI.HR_System.POS;
using BMS.Interfaces;
using BMS.Properties;
using BMS.UI;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace BMS
{
    public partial class frmMain : Form
    {

        private readonly IServiceProvider _serviceProvider;
        private readonly IFormManager _formManager;

        public frmMain(IServiceProvider serviceProvider, IFormManager formManager)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _formManager = formManager;

            RestoreWindowState();
            RestoreMenuOrder();
        }

        #region Form State Management

        private void RestoreWindowState()
        {
            this.WindowState = Settings.Default.IsMaximized ?
                FormWindowState.Maximized : FormWindowState.Normal;
        }
        private void RestoreMenuOrder()
        {
            string order = Properties.Settings.Default.MenuOrder;
            if (string.IsNullOrWhiteSpace(order)) return;

            var orderedItems = new List<ToolStripItem>();

            foreach (string name in order.Split(','))
            {
                var item = msMain.Items.Find(name, true).FirstOrDefault();
                if (item != null)
                    orderedItems.Add(item);
            }

            if (orderedItems.Any())
            {
                msMain.Items.Clear();
                msMain.Items.AddRange(orderedItems.ToArray());
            }
        }

        private void SaveWindowState()
        {
            Settings.Default.IsMaximized = (WindowState == FormWindowState.Maximized);
            Settings.Default.Save();
        }

        private void SaveMenuOrder()
        {
            var items = msMain.Items.OfType<ToolStripMenuItem>()
                .Where(x => !string.IsNullOrEmpty(x.Name))
                .Select(x => x.Name);

            Settings.Default.MenuOrder = string.Join(",", items);
            Settings.Default.Save();
        }

        #endregion


        #region Event Handlers




        private void SearchDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _formManager.ShowForm<frmDepartmentList>(this);
        }

        private void AddDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _formManager.ShowDialogForm<frmAddEditDepartments>(this);
        }

        private void SearchJobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ShowFormIfNotOpen<frmJobsList>();
        }

        private void AddJobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ShowFormIfNotOpen<frmAdd_Edit_Job_ٍShow>();
        }





        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveWindowState();
            SaveMenuOrder();
        }








        private void EmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void AddPosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _formManager.ShowForm<frmAddEditPos>(this);
        }

        private void SearchPosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _formManager.ShowForm<frmPOSList>(this);
        }

        private void قاطالبيعToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
