using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.BAL
{
    [AttributeUsage(AttributeTargets.Property , AllowMultiple = false)]
    public  class clsDisplayAttribute : Attribute
    {
        public string DisplayName { get;  }
        public bool IsTableColumn { get; set; } = false;
        public bool IsComboBoxAttribute { get; set; } = false;
        public int Order { get; set; } = 0;
        public int Width { get; set; } = 0;

        public clsDisplayAttribute(string displayName,bool isTablefield,
            bool isComboBoxAttribute,int order,int width)
        {
            DisplayName = displayName;
            IsTableColumn = isTablefield;
            IsComboBoxAttribute = isComboBoxAttribute;
            Order = order;
            Width = width;
        }
    }
}
