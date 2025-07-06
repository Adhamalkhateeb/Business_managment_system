
using System;
using System.Collections.Generic;
using System.Data;
using DAL;
namespace BAL
{
    public class  Department  
    {
       /// private readonly IDepartmentRepository _departmentRepository;


        public enum enMode { AddNew = 1, Update = 2 }
        private enMode _Mode = enMode.AddNew;
        public int ID { get;  set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreationDate { get; set; }
        public int? UpdatedByUserID { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool IsActive { get; set; }
        
    }
}
