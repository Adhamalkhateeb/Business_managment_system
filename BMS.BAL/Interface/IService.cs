using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.BAL.Interface
{
    public interface IService<T> where T : class
    {

        Task<List<T>> GetAllAsync(int? page, int? size, string? filterCol, string? filterVal);
        Task<T> GetInfoAsync(int id);
        Task<T> GetInfoAsync    (string name);
        Task<int> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id, int? userId);
        Task<long> GetCountAsync(string tableName);

        Task<bool> SaveAsync(T entity);
    }
}
