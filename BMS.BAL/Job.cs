
using System;
using System.Collections.Generic;
using System.Data;
using DAL;
namespace BAL
{
    //public class Job
    //{
    //    public enum enMode { AddNew = 1, Update = 2 }
    //    private enMode _Mode = enMode.AddNew;
    //    public int JobID { get; private set; }
    //    public string JobTitle { get; set; }
    //    public int CreatedByUserID { get; set; }
    //    public DateTime CreatedDate { get; set; }
    //    public int? ModifiedByUserID { get; set; }
    //    public DateTime? ModifiedDate { get; set; }
    //    public bool IsActive { get; set; }
    //    public int DepartmentID { get; set; }
    //    public Department? Department { get; set; }

    //    public Job()
    //    {
    //        JobID = -1;
    //        JobTitle = string.Empty;
    //        CreatedByUserID = -1;
    //        ModifiedByUserID = null;
    //        CreatedDate = DateTime.Now;
    //        ModifiedDate = null;
    //        IsActive = true;
    //        DepartmentID = -1;

    //        _Mode = enMode.AddNew;

    //    }

    //    private Job(int JobID, string JobTitle,int createdByUserID, DateTime createdDate, int? modifiedByUserID, DateTime? modifiedDate, bool IsActive,int DepartmentID)
    //    {
    //        this.JobID = JobID;
    //        this.JobTitle = JobTitle;
    //        this.CreatedByUserID = createdByUserID;
    //        this.CreatedDate = createdDate;
    //        this.ModifiedByUserID = modifiedByUserID;
    //        this.ModifiedDate = modifiedDate;
    //        this.IsActive = IsActive;
    //        this.DepartmentID = DepartmentID; 

    //        _Mode = enMode.Update;
    //    }


    //    /// <summary>
    //    /// Get part of Jobs Asyncronusly by page number and rows count
    //    /// </summary>
    //    /// <returns> Data table filled with Jobs/returns>
    //    static public async Task<DataTable> GetAllJobs(int? Page, int? RowCount,string? FilterColumn = null,string? FilterValue = null)
    //    {
    //        return await clsJobData.GetAlljobsAsync(Page, RowCount,FilterColumn,FilterValue);
    //    }


    //    /// <summary>
    //    /// Get Job By ID Asyncronusly
    //    /// </summary>
    //    /// <param name="JobID"></param>
    //    /// <returns return Job object filled with data ></returns>
    //    static public async Task<Job> GetJob(int JobID)
    //    {
    //        Dictionary<string, object> result = await clsJobData.GetJobByIDAsync(JobID);

    //        if (result != null)
    //        {
    //            var job = new Job(
    //                 (int)result["JobID"],
    //                  result["JobTitle"].ToString(),
    //                  (int)result["CreatedBy"],
    //                  (DateTime)result["CreationDate"],
    //                  result["UpdatedBy"] == null ? (int?)null : (int?)result["UpdatedBy"],
    //                  result["UpdateDate"] == null ? null : (DateTime?)result["UpdateDate"],
    //                  (bool)result["IsActive"],
    //                  (int)result["DepartmentID"]
    //            );

    //            job.Department = await Department.GetInfoAsync(job.DepartmentID);
    //            return job;
    //        }
    //        else
    //        {
    //            return null;
    //        }

    //    }



    //    /// <summary>
    //    /// Get Job By title Asyncronusly
    //    /// </summary>
    //    /// <param name="JobTitle"></param>
    //    /// <returns> return Job object filled with data </returns>
    //    static public async Task<Job> GetJob(string JobTitle)
    //    {
    //        Dictionary<string, object> result = await clsJobData.GetJobByNameAsync(JobTitle);

    //        if (result != null)
    //        {

    //            var job = new Job(
    //                 (int)result["JobID"],
    //                  result["JobTitle"].ToString(),
    //                  (int)result["CreatedBy"],
    //                  (DateTime)result["CreationDate"],
    //                  result["UpdatedBy"] == null ? (int?)null : (int?)result["UpdatedBy"],
    //                  result["UpdateDate"] == null ? null : (DateTime?)result["UpdateDate"],
    //                  (bool)result["IsActive"],
    //                  (int)result["DepartmentID"]
    //            );

    //            job.Department = await Department.GetInfoAsync(job.DepartmentID); 
    //            return job;
    //        }
    //        else
    //        {
    //            return null;
    //        }

    //    }



    //    private async Task<bool> AddJob()
    //    {
    //        this.JobID = (await clsJobData.AddJobAsync(this.JobTitle,this.CreatedByUserID,this.DepartmentID));
    //        return this.JobID != -1;
    //    }



    //    private async Task<bool> UpdateJob()
    //    {
    //        return await clsJobData.UpdatejobAsync(this.JobID,  this.JobTitle, this.ModifiedByUserID,this.DepartmentID);
    //    }


    //    /// <summary>
    //    ///  Soft Delete Job Asyncronusly
    //    /// </summary>
    //    /// <returns>true if Deleted else false</returns>
    //    public async Task<bool> DeleteJob()
    //    {

    //        return await clsJobData.DeleteJobAsync(this.JobID, this.ModifiedByUserID);
    //    }




    //    /// <summary>
    //    /// Save new Job or update existing one depending on mode
    //    /// </summary>
    //    /// <returns></returns>
    //    public async Task<bool> Save()
    //    {
    //        switch (_Mode)
    //        {
    //            case enMode.AddNew:
    //                if (await AddJob())
    //                {
    //                    _Mode = enMode.Update;
    //                    return true;
    //                }
    //                else
    //                {
    //                    return false;
    //                }
    //            case enMode.Update:
    //                return await UpdateJob();
    //            default:
    //                return false;
    //        }
    //    }



    //    public override string ToString()
    //    {
    //        return JobTitle;
    //    }
    //}
}
