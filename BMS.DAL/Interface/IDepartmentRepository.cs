using MyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.DAL.Interface
{
    /// <summary>
    /// Interface for Department Repository to manage department-related operations.
    /// </summary>
    public interface IDepartmentRepository : IRepository<Departments>
    {
        
    }
}
