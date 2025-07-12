
using BMS.BAL.Interface;
using BMS.DAL.Interfaces;
using BMS.DTOs;
using BMS.InfraStructure.InfraStructure.interfaces;



namespace BMS.BAL
{
    /// <summary>
    /// Provides services for managing departments, including retrieval, creation, updating, and deletion.
    /// </summary>
    public class DepartmentService : IDepartmentService
    {
        private const string className = nameof(DepartmentService);
        private readonly IRepository<DepartmentDTO> _departmentRepository;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentService"/> class with the specified repository.
        /// </summary>
        /// <param name="repo">The repository used for department operations.</param>
        public DepartmentService(IRepository<DepartmentDTO> departmentRepository, ILogger logger)
        {
            _departmentRepository = departmentRepository;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves a paginated list of departments asynchronously.
        /// </summary>
        /// <param name="page">The page number to retrieve.</param>
        /// <param name="rowCount">The number of rows per page.</param>
        /// <param name="column">The column to filter by (optional).</param>
        /// <param name="value">The value to filter by (optional).</param>
        /// <returns>A list of departments.</returns>
        public async Task<List<DepartmentDTO>> GetAllAsync(int? page, int? rowCount, string? column , string? value) 
        {
            try
            {
                return await _departmentRepository.GetAllAsync(page, rowCount, column, value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{className}.{nameof(GetAllAsync)}] {ex.Message}");
                return new List<DepartmentDTO>(); // return empty list instead of null
            }
        }

        /// <summary>
        /// Retrieves a department by its ID asynchronously.
        /// </summary>
        /// <param name="departmentID">The ID of the department.</param>
        /// <returns>The department with the specified ID.</returns>
        public async Task<DepartmentDTO> GetInfoAsync(int id)
        {
            try
            {
                return await _departmentRepository.GetInfoAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{className}.{nameof(GetInfoAsync)},ByID] ID: {id}, Error: {ex.Message}");
                return null!;
            }
        }

        /// <summary>
        /// Retrieves a department by its name asynchronously.
        /// </summary>
        /// <param name="DepartmentName">The name of the department.</param>
        /// <returns>The department with the specified name.</returns>
        public async Task<DepartmentDTO> GetInfoAsync(string name)
        {
            try
            {
                return await _departmentRepository.GetInfoAsync(name);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{className}.{nameof(GetInfoAsync)},ByName] Name: {name}, Error: {ex.Message}");
                return null!;
            }
        }

 
        /// <summary>
        /// Updates an existing department asynchronously.
        /// </summary>
        /// <param name="department">The department to update.</param>
        /// <returns>True if the update was successful; otherwise, false.</returns>
        public async Task<bool> UpdateAsync(DepartmentDTO department)
        {
            try
            {
                return await _departmentRepository.UpdateAsync(department);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{className}.{nameof(UpdateAsync)}] ID: {department.ID}, Error: {ex.Message}");
                return false;
            }
        }



        /// <summary>
        /// Adds a new department asynchronously.
        /// </summary>
        /// <param name="department">The department to add.</param>
        /// <returns>The ID of the newly added department, or -1 if failed.</returns>
        public async Task<int> AddAsync(DepartmentDTO department)
        {
            try
            {
                return await _departmentRepository.AddNewAsync(department);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{className}.{nameof(AddAsync)}] {ex.Message}");
                return -1;
            }
        }

        /// <summary>
        /// Soft deletes a department asynchronously.
        /// </summary>
        /// <param name="id">The ID of the department to delete.</param>
        /// <param name="UserID">The ID of the user performing the deletion (optional).</param>
        /// <returns>True if the operation was successful; otherwise, false.</returns>
        public async Task<bool> DeleteAsync(int id, int? userId)
        {
            try
            {
                return await _departmentRepository.DeleteAsync(id, userId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{className}.{nameof(DeleteAsync)}] ID: {id}, Error: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Retrieves the total number of department records asynchronously.
        /// </summary>
        /// <param name="TableName">The name of the table containing department records.</param>
        /// <returns>The total number of department records.</returns>
        public async Task<int> GetCountAsync(string tableName)
        {
            try
            {
                return await _departmentRepository.GetNumberOfRecordsAsync(tableName);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{className}.{nameof(GetCountAsync)}] Table: {tableName}, Error: {ex.Message}");
                return 0;
            }
        }


        /// <summary>
        /// Saves a new department or updates an existing one asynchronously.
        /// </summary>
        /// <param name="department">The department to save or update.</param>
        /// <returns>True if the operation was successful; otherwise, false.</returns>
        public async Task<bool> SaveAsync(DepartmentDTO department)
        {
            try
            {
                if (department.ID == -1)
                {
                    var id = await AddAsync(department);
                    department.ID = id;
                    return id != -1;
                }
                else
                {
                    return await UpdateAsync(department);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{className}.{nameof(SaveAsync)}] {ex.Message}");
                return false;
            }
        }
    }
}



