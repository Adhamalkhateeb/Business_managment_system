using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.DAL.Interface
{
    public interface iCRUDop
    {
        public int Add();
        public bool Delete();
        public bool Update();
        public DataTable GetAllData();

    }
}
