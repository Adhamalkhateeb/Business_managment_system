using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BMS.DTOs
{
    public  class PosDTO :BaseDTOs
    {
        private decimal _balance;
        public string Name { get; set; }
        public decimal Balance
        {
            get { return _balance; }
            set
            { 
                if(value < 0)
                throw new ArgumentOutOfRangeException(nameof(Balance), "Balance cannot be negative.");
                _balance = value;

            } 
        }

        public PosDTO() 
        {
            ID = -1;
            Name = null!;
            Balance = 0;
            CreatedByUserID = -1;
            CreationDate = DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss");
            UpdatedByUserID = -1;
            LastUpdatedDate = DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss");
            IsActive = true;
        }
        public PosDTO(int iD, string name, decimal balance, int createdByUserID, string creationDate, int? updatedByUserID, string? lastUpdatedDate, bool isActive)
        {
            ID = iD;
            Name = name;
            Balance = balance;
            CreatedByUserID = createdByUserID;
            CreationDate = creationDate;
            UpdatedByUserID = updatedByUserID;
            LastUpdatedDate = lastUpdatedDate;
            IsActive = isActive;
        }
    }
}
