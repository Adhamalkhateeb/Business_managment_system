using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BAL
{
    public class DepartmentService : IDepartmentService
    {


        private readonly IDepartmentRepository _departmentRepository;


        public DepartmentService(IDepartmentRepository repo)
        {
            _departmentRepository = repo;
        }

        /// <summary>
        /// Get part of Departments Asyncronusly by page number and rows count
        /// </summary>
        /// <returns> List filled with Departments/returns>
        public async Task<List<Departments>> GetAllDepartmentsAsync(int? page, int? rowCount, string? column = null, string? value = null)
        {
            return await _departmentRepository.GetAllDepartmentsAsync<Departments>(page, rowCount, column, value);
        }


        /// <summary>
        /// Get Department By ID Asyncronusly
        /// </summary>
        /// <param name="departmentID"></param>
        /// <returns></returns>
        public async Task<Departments> GetDepartmentAsync(int departmentID)
        {
            Departments result = await _departmentRepository.GetDepartmentByIDAsync<Departments>(departmentID);
            return result;

        }



        /// <summary>
        /// Get Department By Name Asyncronusly
        /// </summary>
        /// <param name="DepartmentName"></param>
        /// <returns></returns>
        public async Task<Departments> GetDepartment(string DepartmentName)
        {
            Departments result = await _departmentRepository.GetDepartmentByNameAsync<Departments>(DepartmentName);
            return result;

        }



        /// <summary>
        /// Save new department or update existing one depending on mode
        /// </summary>
        /// <returns>bool</returns>
        public async Task<bool> SaveAsync(Departments department)
        {
            if (department.ID == -1)
            {
                var newId = await _departmentRepository.AddDepartmentAsync(department.Name, department.Description, department.CreatedByUserID);
                department.ID = newId;
                return newId != -1;
            }
            else
            {
                return await _departmentRepository.UpdateDepartmentAsync(department.ID, department.Description, department.Name, department.UpdatedByUserID);
            }
        }



        /// <summary>
        ///  Soft Delete Department Asyncronusly
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DeleteDepartmentAsync(int id, int? modifiedBy)
        {

            return await _departmentRepository.DeleteDepartmentAsync(id, modifiedBy);
        }


        public async Task<int> GetNumberOfDepartmentsAsync(string TableName)
        {
            return await _departmentRepository.GetNumberOfDepartmentsRecordsAsync(TableName);

        }
    }
}



