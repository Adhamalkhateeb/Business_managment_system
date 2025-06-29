
using System;
using System.Collections.Generic;
using System.Data;
using DAL;
namespace BAL
{
    public class  Department
    {
        public enum enMode { AddNew = 1, Update = 2 }
        private enMode _Mode = enMode.AddNew;
        public int DepartmentID { get; private set; }
        public string DepartmentName { get; set; }
        public string? Description { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedByUserID { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public Department()
        {
            DepartmentID = -1;
            DepartmentName = string.Empty;
            Description = null;
            CreatedByUserID = -1;
            ModifiedByUserID = null;
            CreatedDate =DateTime.Now;
            ModifiedDate = null;
            IsActive = true;

            _Mode = enMode.AddNew;

        }

        private Department(int departmentID, string departmentName,string? Description,int createdByUserID, DateTime createdDate, int? modifiedByUserID, DateTime? modifiedDate, bool IsActive)
        {
            this.DepartmentID = departmentID;
            this.DepartmentName = departmentName;
            this.Description = Description;
            this.CreatedByUserID = createdByUserID;
            this.CreatedDate = createdDate;
            this.ModifiedByUserID = modifiedByUserID;
            this.ModifiedDate = modifiedDate;
            this.IsActive = IsActive;

            _Mode = enMode.Update;
        }


        /// <summary>
        /// Get part of Departments Asyncronusly by page number and rows count
        /// </summary>
        /// <returns> Data table filled with Departments/returns>
        static public async Task<DataTable> GetAllDepartments(int? Page,int? RowCount,string? FilterColumn = null,string? Filtervalue = null)
        {
           return await clsDepartmentData.GetAllDepartmentsAsync(Page,RowCount,FilterColumn,Filtervalue);
        }


        /// <summary>
        /// Get Department By ID Asyncronusly
        /// </summary>
        /// <param name="departmentID"></param>
        /// <returns></returns>
        static public async Task<Department> GetDepartment(int departmentID)
        {
             Dictionary<string,object> result = await clsDepartmentData.GetDepartmentByIDAsync(departmentID);

            if(result != null)
            {
                return new Department(
                      (int)result["DepartmentID"],
                      result["DepartmentName"].ToString(),
                      result["Description"]?.ToString(),
                      (int)result["CreatedBy"],
                      (DateTime)result["CreationDate"],
                      result["UpdatedBy"] == null ? (int?)null : (int?)result["UpdatedBy"],
                     result["UpdateDate"] == null ? null : (DateTime?)result["UpdateDate"],
                      (bool)result["IsActive"]) ;                   
            }
            else
            {
                return null;
            }

        }



        /// <summary>
        /// Get Department By Name Asyncronusly
        /// </summary>
        /// <param name="DepartmentName"></param>
        /// <returns></returns>
        static public async Task<Department> GetDepartment(string DepartmentName)
        {
            Dictionary<string, object> result = await clsDepartmentData.GetDepartmentByNameAsync(DepartmentName);

            if (result != null)
            {
                return new Department(
                      (int)result["DepartmentID"],
                      result["DepartmentName"].ToString(),
                      result["Description"]?.ToString(),
                      (int)result["CreatedBy"],
                      (DateTime)result["CreationDate"],
                      result["UpdatedBy"] == null ? (int?)null : (int?)result["UpdatedBy"],
                     result["UpdateDate"] == null ? (DateTime?)null : (DateTime?)result["UpdateDate"],
                      (bool)result["IsActive"]);
            }
            else
            {
                return null;
            }

        }


   
        private async Task <bool> AddDepartment()
        {
             this.DepartmentID = (await clsDepartmentData.AddDepartmentAsync(this.DepartmentName,this.Description , this.CreatedByUserID));
            return this.DepartmentID != -1;
        }


  
        private async Task<bool> UpdateDepartment()
        {
            return  await clsDepartmentData.UpdateDepartmentAsync(this.DepartmentID, this.Description,this.DepartmentName,this.ModifiedByUserID);
        }


        /// <summary>
        ///  Soft Delete Department Asyncronusly
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DeleteDepartment()
        {
            
            return await clsDepartmentData.DeleteDepartmentAsync(this.DepartmentID,this.ModifiedByUserID);
        }




        /// <summary>
        /// Save new department or update existing one depending on mode
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                   if( await AddDepartment())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                   else
                    {
                        return false;
                   }
                case enMode.Update:
                    return await UpdateDepartment();
                default:
                    return false;
            }
        }



        public override string ToString()
        {
            return DepartmentName;
        }
    }
}
