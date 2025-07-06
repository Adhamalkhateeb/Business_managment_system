
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using Utilities;



namespace DAL
{

    public class clsDepartmentData :IDepartmentRepository
    {
        private readonly  IStoredProcedureRunner _db;
        public clsDepartmentData(IStoredProcedureRunner db)
        {
            _db = db;
        }

        /// <summary>
        /// Add Department Asyncronusly 
        /// </summary>
        /// <param name="departmentName"></param>
        /// <param name="Description"></param>
        /// <param name="CreatedBy"></param>
        /// <returns>New Department ID </returns>
        public  async Task<int> AddDepartmentAsync(string departmentName, string Description, int CreatedBy)
        {
           return  await _db.ExecuteNonQueryAsync(SPHelper.GetName(SPDept.AddDepartment), new SqlParameter[]
           { new SqlParameter("@DepartmentName", departmentName),
             new SqlParameter("@Description", Description) , 
             new SqlParameter("@CreatedBy",CreatedBy) });
        }


        /// <summary>
        /// Update Department Asyncronusly
        /// </summary>
        /// <param name="departmentID"></param>
        /// <param name="Description"></param>
        /// <param name="departmentName"></param>
        /// <param name="modifiedByUserID"></param>
        /// <returns>True if Department updated Successfully , false if Error happened </returns>
        public  async Task<bool> UpdateDepartmentAsync(int departmentID, string Description ,string departmentName, int? modifiedByUserID) =>
            await _db.ExecuteNonQueryAsync(SPHelper.GetName(SPDept.UpdateDepartment), new SqlParameter[]
            { new SqlParameter("@DepartmentName", departmentName),
              new SqlParameter("@DepartmentID", departmentID),
              new SqlParameter("@Description", Description) ,
              new SqlParameter("@UpdatedBy",modifiedByUserID) }) != -1;
        

        /// <summary>
        /// Get All Departments Records Asyncronusly
        /// </summary>
<<<<<<< HEAD
        /// <returns>List Filled with Departments Records</returns>
        public async Task<List<T>> GetAllDepartmentsAsync<T>(int? PageNumber, int? Records, string? FilterColumn, string? FilterValue) where T : new() =>
            await _db.GetAllBySPAsync<T>(SPHelper.GetName(SPDept.GetAllDepartments), new SqlParameter[]
=======
        /// <returns>Data Table Filled with Departments Records </returns>
        public static async Task<DataTable> GetAllDepartmentsAsync(int? PageNumber,int? Records,string? FilterColumn,string? FilterValue) =>
            await clsGlobalDatabase.GetAllAsyncByStoredProcedure("SP_GetAllDepartments", new SqlParameter[] 
>>>>>>> ee1f3eec5ded94f0497950c9b86f6922072ee88c
            {
                new SqlParameter("@PageNumber", PageNumber ?? 1),
                new SqlParameter("@Records", Records ?? 10),
                new SqlParameter("@FilterColumn", FilterColumn),
                new SqlParameter("@FilterValue", FilterValue)
            });


        /// <summary>
        /// Soft Delete for Department
        /// </summary>
        /// <param name="departmentID"></param>
        /// <param name="UserID"></param>
        /// <returns>Success or Fail of Deleting Record</returns>
        public  async Task<bool> DeleteDepartmentAsync(int departmentID, int? UserID)
        {
<<<<<<< HEAD
            if (await _db.ExecuteNonQueryAsync("CheckDepartmentDependencies", new SqlParameter[] { new SqlParameter("@DepartmentID", departmentID) }) != 1)
             return await _db.ExecuteNonQueryAsync(SPHelper.GetName(SPDept.DeleteDepartment), new SqlParameter[]
=======
            if (await clsGlobalDatabase.ExecuteNonQueryAsync("CheckDepartmentDependencies", new SqlParameter[] { new SqlParameter("@DepartmentID", departmentID) }) != -1)
             return await clsGlobalDatabase.ExecuteNonQueryAsync("SP_DeleteDepartment", new SqlParameter[]
>>>>>>> ee1f3eec5ded94f0497950c9b86f6922072ee88c
             { 
                 new SqlParameter("@DepartmentID", departmentID),
                 new SqlParameter("@UpdatedBy", UserID)
             }) != -1;
            else
                return false;
        
        }


        /// <summary>
        /// Get Department By ID
        /// </summary>
        /// <param name="departmentID"></param>
        /// <returns>Dictionary<string ,object> contains Record data</returns>
<<<<<<< HEAD
        public  async Task<T> GetDepartmentByIDAsync<T>(int departmentID) where T : new()  =>
             await _db.GetSingleRecordBySPAsync<T>(SPHelper.GetName(SPDept.GetDepartmentByID), new SqlParameter[]
=======
        public static async Task<Dictionary<string, object>> GetDepartmentByIDAsync(int departmentID) =>
             await clsGlobalDatabase.GetSingleRecord("SP_GetDepartmentByID", new SqlParameter[]
>>>>>>> ee1f3eec5ded94f0497950c9b86f6922072ee88c
             {
                 new SqlParameter("@DepartmentID",departmentID)
             });



        /// <summary>
        /// Get Department By Name
        /// </summary>
        /// <param name="DepartmentName"></param>
        /// <returns> Dictionary<string ,object> contains Record data </returns>
<<<<<<< HEAD
        public  async Task<T> GetDepartmentByNameAsync<T>(string DepartmentName) where T :  new()=>
              await _db.GetSingleRecordBySPAsync<T>(SPHelper.GetName(SPDept.GetDepartmentByName), new SqlParameter[]
=======
        public static async Task<Dictionary<string, object>> GetDepartmentByNameAsync(string DepartmentName) =>
              await clsGlobalDatabase.GetSingleRecord("SP_GetDepartmentByName", new SqlParameter[]
>>>>>>> ee1f3eec5ded94f0497950c9b86f6922072ee88c
              {
                 new SqlParameter("@DepartmentName",DepartmentName)
              });


        public async Task<int> GetNumberOfDepartmentsRecordsAsync(string TableName)
        {
            var result = await _db.GetNumberOfActiveRecordsAsync(SPHelper.GetName(SPDept.GetNumberOfDepartmentsRecords), new SqlParameter[]
            {
                new SqlParameter("@TableName", TableName),
            });
            return result;
        }


    }
}