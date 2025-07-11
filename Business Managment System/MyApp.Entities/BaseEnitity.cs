using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.BAL
{
    public abstract class BaseEnitity
    {
        public int ID { get; set; }
        public int CreatedByUserID { get; set; }
        public string CreationDate { get; set; }
        public int? UpdatedByUserID { get; set; }
        public string? LastUpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
