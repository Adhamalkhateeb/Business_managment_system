
using System;
using System.Collections.Generic;
using System.Data;
using DAL;
using Utilities;
namespace BAL
{
    public class  Departments  
    {
        /// private readonly IDepartmentRepository _departmentRepository;

        public int ID { get; set; } = -1;
        public string Name { get; set; }
        public string? Description { get; set; }
        public int CreatedByUserID { get; set; }
        public string CreationDate { get; set; }
        public int? UpdatedByUserID { get; set; }
        public string? LastUpdatedDate { get; set; }
        public bool IsActive { get; set; }
        

    }
}
