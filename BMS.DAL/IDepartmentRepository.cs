using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDepartmentRepository
    {
        Task<int>  AddDepartmentAsync(string departmentName, string Description, int CreatedBy);
        Task<bool> UpdateDepartmentAsync(int departmentID, string Description, string departmentName, int? modifiedByUserID);
        Task<List<T>> GetAllDepartmentsAsync<T>(int? PageNumber, int? Records, string? FilterColumn, string? FilterValue) where T : new();
        Task<bool> DeleteDepartmentAsync(int departmentID, int? UserID);
        Task<T> GetDepartmentByIDAsync<T>(int departmentID) where T : new();
        Task<T> GetDepartmentByNameAsync<T>(string DepartmentName) where T : new();
    }
}
