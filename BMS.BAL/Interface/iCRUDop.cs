using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface
{
    public interface iCRUDop<T>
    {
        Task<bool> AddNewAsync(T entity);
        Task<bool> DeleteAsync(int ID, int? UserID);
        Task<bool> UpdateAsync(T entity);
        Task<List<T>> GetAllAsync(int? PageNumber, int? Records, string? FilterColumn = null, string? FilterValue = null);
        Task<T> GetInfoAsync(int ID);
        Task<T> GetInfoAsync(string Title);
        Task<bool> SaveAsync(T entity);
        Task<int> GetNumberOfRecordsAsync(string TableName);
    }
}
