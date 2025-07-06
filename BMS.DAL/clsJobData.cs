using System;
using System.Data;
using Microsoft.Data.SqlClient;


namespace DAL
{

    public class clsJobData
    {



 
        ///// <summary>
        ///// Add new job Async to DataBase
        ///// </summary>
        ///// <param name="JobTitle"></param>
        ///// <param name="CreatedBy"></param>
        ///// <param name="DepartmentID"></param>
        ///// <returns> new Job ID</returns>
        //public static async Task<int> AddJobAsync(string JobTitle, int CreatedBy,int DepartmentID)
        //{
        //    return await DataBaseExecuter.ExecuteNonQueryAsync("SP_AddNewJob", new SqlParameter[]
        //    { new SqlParameter("@JobTitle", JobTitle),
        //     new SqlParameter("@DepartmentID", DepartmentID) ,
        //     new SqlParameter("@CreatedBy",CreatedBy) });
        //}


        ///// <summary>
        ///// Update Job Async
        ///// </summary>
        ///// <param name="JobID"></param>
        ///// <param name="JobTitle"></param>
        ///// <param name="modifiedByUserID"></param>
        ///// <param name="DepartmentID"></param>
        ///// <returns> true if job updated successfully else false </returns>
        //public static async Task<bool> UpdatejobAsync(int JobID, string JobTitle, int? modifiedByUserID,int DepartmentID)
        //{
        //    return await DataBaseExecuter.ExecuteNonQueryAsync("SP_UpdateJob", new SqlParameter[]
        //    { new SqlParameter("@JobID", JobID),
        //      new SqlParameter("@DepartmentID", DepartmentID),
        //      new SqlParameter("@JobTitle", JobTitle) ,
        //      new SqlParameter("@UpdatedBy",modifiedByUserID) }) != -1;
        //}

        ///// <summary>
        ///// Get All Jobs Records Asyncronusly
        ///// </summary>
        ///// <returns>Data Table Filled with Jobs Records </returns>
        //public static async Task<DataTable> GetAlljobsAsync(int? PageNumber, int? Records,string? FilterColumn,string? FilterValue) =>
        //    await DataBaseExecuter.GetAllBySPAsync("SP_GetAll_Jobs", new SqlParameter[]
        //    {
        //    new SqlParameter("@PageNumber",PageNumber),
        //    new SqlParameter("@Records",Records),
        //    new SqlParameter("@FilterColumn",FilterColumn),
        //    new SqlParameter("@FilterValue",FilterValue)

        //    });


        ///// <summary>
        ///// Soft Delete for Job
        ///// </summary>
        ///// <param name="JobID"></param>
        ///// <param name="UserID"></param>
        ///// <returns>Success or Fail of Deleting Record</returns>
        //public static async Task<bool> DeleteJobAsync(int JobID, int? UserID)
        //{
        //    if (await DataBaseExecuter.ExecuteNonQueryAsync("CheckjobDependencies", new SqlParameter[] { new SqlParameter("@JobID", JobID) }) != 1)
        //        return await DataBaseExecuter.ExecuteNonQueryAsync("SP_DeleteJob", new SqlParameter[]
        //        {
        //         new SqlParameter("@JobID", JobID),
        //         new SqlParameter("@UpdatedBy", UserID)
        //        }) != -1;
        //    else
        //        return false;
        //}


        ///// <summary>
        ///// Get Job By ID
        ///// </summary>
        ///// <param name="JobID"></param>
        ///// <returns>Dictionary<string ,object> contains Record data</returns>
        //public static async Task<Dictionary<string, object>> GetJobByIDAsync(int JobID) =>
        //     await DataBaseExecuter.GetSingleRecordBySPAsync("SP_Get_job", new SqlParameter[]
        //     {
        //         new SqlParameter("@JobID",JobID)
        //     });



        ///// <summary>
        ///// Get Job By Name
        ///// </summary>
        ///// <param name="JobTitle"></param>
        ///// <returns> Dictionary<string ,object> contains Record data </returns>
        //public static async Task<Dictionary<string, object>> GetJobByNameAsync(string JobTitle) =>
        //      await DataBaseExecuter.GetSingleRecordBySPAsync("sp_Get_Job_ByName", new SqlParameter[]
        //      {
        //         new SqlParameter("@JobTitle",JobTitle)
        //      });


    }
}