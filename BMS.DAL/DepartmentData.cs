using System;
using System.Data;
using Microsoft.Data.SqlClient;


namespace DAL
{

    public class clsDepartmentData
    {

        /// <summary>
        /// Add Department Asyncronusly 
        /// </summary>
        /// <param name="departmentName"></param>
        /// <param name="Description"></param>
        /// <param name="CreatedBy"></param>
        /// <returns>New Department ID </returns>
        public static async Task<int> AddDepartmentAsync(string departmentName, string Description, int CreatedBy)
        {
           return  await clsGlobalDatabase.ExecuteNonQueryAsync("SP_AddNewDepartment", new SqlParameter[]
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
        public static async Task<bool> UpdateDepartmentAsync(int departmentID, string Description ,string departmentName, int? modifiedByUserID)
        {
            return await clsGlobalDatabase.ExecuteNonQueryAsync("SP_UpdateDepartment", new SqlParameter[]
            { new SqlParameter("@DepartmentName", departmentName),
              new SqlParameter("@DepartmentID", departmentID),
              new SqlParameter("@Description", Description) ,
              new SqlParameter("@UpdatedBy",modifiedByUserID) }) != -1;
        }

        /// <summary>
        /// Get All Departments Records Asyncronusly
        /// </summary>
        /// <returns>Data Table Filled with Departments Records </returns>
        public static async Task<DataTable> GetAllDepartmentsAsync(int? PageNumber,int? Records,string? FilterColumn,string? FilterValue) =>
            await clsGlobalDatabase.GetAllAsyncByStoredProcedure("sp_GetAll_Departments", new SqlParameter[] 
            {
            new SqlParameter("@PageNumber",PageNumber),
            new SqlParameter("@Records",Records),
            new SqlParameter("@FilterColumn",FilterColumn),
            new SqlParameter("@FilterValue",FilterValue)

            });


        /// <summary>
        /// Soft Delete for Department
        /// </summary>
        /// <param name="departmentID"></param>
        /// <param name="UserID"></param>
        /// <returns>Success or Fail of Deleting Record</returns>
        public static async Task<bool> DeleteDepartmentAsync(int departmentID, int? UserID)
        {
            if (await clsGlobalDatabase.ExecuteNonQueryAsync("CheckDepartmentDependencies", new SqlParameter[] { new SqlParameter("@DepartmentID", departmentID) }) != 1)
             return await clsGlobalDatabase.ExecuteNonQueryAsync("sp_Delete_Department", new SqlParameter[]
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
        public static async Task<Dictionary<string, object>> GetDepartmentByIDAsync(int departmentID) =>
             await clsGlobalDatabase.GetSingleRecord("sp_Get_Department", new SqlParameter[]
             {
                 new SqlParameter("@DepartmentID",departmentID)
             });



        /// <summary>
        /// Get Department By Name
        /// </summary>
        /// <param name="DepartmentName"></param>
        /// <returns> Dictionary<string ,object> contains Record data </returns>
        public static async Task<Dictionary<string, object>> GetDepartmentByNameAsync(string DepartmentName) =>
              await clsGlobalDatabase.GetSingleRecord("sp_Get_Department_ByName", new SqlParameter[]
              {
                 new SqlParameter("@DepartmentName",DepartmentName)
              });
 

    }
}