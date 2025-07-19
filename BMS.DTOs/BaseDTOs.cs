using BMS.BAL;
using System.ComponentModel.DataAnnotations;

namespace BMS.DTOs
{
    public abstract class BaseDTOs
    {
        [clsDisplay("رقم المسلسل", true, true,0,120)]
        public int ID { get; set; }
        public int CreatedByUserID { get; set; }
        public string? CreationDate { get; set; }
        public bool IsActive { get; set; }
        public int? UpdatedByUserID { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd   HH:mm}")]
        [clsDisplay("اخر تاريخ للتعديل", true, true,3,215)]
        public string? LastUpdatedDate { get; set; }
    }
}
