
namespace BMS.BAL.Interface;
public interface ICrudService<T>
{
    Task<List<T>> GetAllAsync(int? page, int? size, string? filterCol, string? filterVal);
    Task<T> GetInfoAsync(int id);
    Task<T> GetInfoAsync(string name);
    Task<int> AddAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(int id, int? userId);
    Task<int> GetCountAsync(string tableName);

    Task<bool> SaveAsync(T entity);
}