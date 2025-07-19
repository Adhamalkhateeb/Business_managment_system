using BMS.BAL;
using BMS.BAL.Interface;
using BMS.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMS.GUI.Controls
{
    public partial class testControls : Form
    {
        private IService<DepartmentDTO> _service;
        public testControls(IService<DepartmentDTO> service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            InitializeComponent();
        }

        private void testControls_Load(object sender, EventArgs e)
        {
           genericListControl1.Init<DepartmentDTO>(_service);
        }
    }
}
