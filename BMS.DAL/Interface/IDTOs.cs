using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.DAL.Interface
{
    public abstract class IDTOs
    {
        public abstract int ID { get; set; }
        public abstract int CreatedByUserID { get; set; }
        public abstract string CreationDate { get; set; }
        public abstract int? UpdatedByUserID { get; set; }
        public abstract string? LastUpdatedDate { get; set; }
        public abstract bool IsActive { get; set; }
    }
}
