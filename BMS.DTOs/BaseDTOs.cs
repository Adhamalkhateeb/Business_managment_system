using System.ComponentModel.DataAnnotations;

namespace BMS.DTOs
{
    public abstract class BaseDTOs
    {
        
        public int ID { get; set; }
        public int CreatedByUserID { get; set; }
        public string? CreationDate { get; set; }
        public bool IsActive { get; set; }
        public int? UpdatedByUserID { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd   HH:mm}")]
        public string? LastUpdatedDate { get; set; }
    }
}
