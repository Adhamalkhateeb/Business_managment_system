using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
   

        public interface IDepartmentService
        {
            Task<List<Departments>> GetAllDepartmentsAsync(int? page, int? rowCount, string? column = null, string? value = null);
            Task<Departments> GetDepartmentAsync(int id);
            Task<bool> SaveAsync(Departments dept);
            Task<bool> DeleteDepartmentAsync(int id, int? modifiedBy);
            Task<int> GetNumberOfDepartmentsAsync(string TableName);
        }
   
}
