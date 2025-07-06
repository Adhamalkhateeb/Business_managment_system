
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BMS.main;
using BMS.Properties;

namespace BMS
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            // Get Window State
            GetScreenState();
            // Get main screen menu order
            LoadMenuOrder();
        }

        private void GetScreenState()
        {
            this.WindowState = Settings.Default.IsMaximized ? FormWindowState.Maximized : FormWindowState.Normal;
        }
        private void LoadMenuOrder()
        {
            string order = Properties.Settings.Default.MenuOrder;

            if (string.IsNullOrWhiteSpace(order)) return;

            string[] names = order.Split(',');

            var orderedItems = new List<ToolStripItem>();

            foreach (string name in names)
            {
                var item = msMain.Items.Find(name, true).FirstOrDefault();
                if (item != null)
                    orderedItems.Add(item);
            }

            msMain.Items.Clear();
            msMain.Items.AddRange(orderedItems.ToArray());
        }
        public static void ShowFormIfNotOpen<T>() where T : Form, new()
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is T)
                {
                    frm.Show();
                    frm.BringToFront();
                    CenterForm(frm);
                    return;
                }
            }

            T newForm = new T();
            newForm.Show();
        }

        public static void ShowFormIfNotOpen<T>(Func<T> formFactory) where T : Form
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is T)
                {
                    frm.Show();
                    frm.BringToFront();
                    CenterForm(frm);
                    return;
                }
            }

            T newForm = formFactory();
            newForm.Show();
        }

        private static void CenterForm(Form frm)
        {
            int x = (Screen.PrimaryScreen.Bounds.Width - frm.Width) / 2;
            int y = (Screen.PrimaryScreen.Bounds.Height - frm.Height) / 2;
            frm.Location = new Point(x, y);
        }



        private void SearchDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormIfNotOpen(() => new frmDepartmentList(Program.DepartmentService));
        }

        private void AddDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormIfNotOpen(() => new frmAddEditDepartments(Program.DepartmentService));
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
            SaveScreenState();
            SaveMenuOrder();
        }


        private void SaveScreenState()
        {
            Settings.Default.IsMaximized = (WindowState == FormWindowState.Maximized) ? true : false;
            Settings.Default.Save();
        }

        // Save Items of Menu that user orderd for next launch
        private void SaveMenuOrder()
        {

            var items = msMain.Items.OfType<ToolStripMenuItem>().Select(x => x.Name).ToList();
            string order = string.Join(",", items);
            Settings.Default.MenuOrder = order;
            Settings.Default.Save();
        }

       
    }
}
