using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
   

        public interface IDepartmentService
        {
            Task<List<Department>> GetAllDepartmentsAsync(int? page, int? rowCount, string? column = null, string? value = null);
            Task<Department> GetDepartmentAsync(int id);
            Task<bool> SaveAsync(Department dept);
            Task<bool> DeleteDepartmentAsync(int id, int? modifiedBy);
        }
   
}
