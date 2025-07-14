using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Interfaces
{
    public interface IFormManager
    {
        void ShowForm<T>(Form parent) where T : Form;
        void ShowDialogForm<T>(Form Owner) where T : Form;
    }
}
