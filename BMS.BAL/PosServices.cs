using BMS.BAL.Interface;
using BMS.DAL.Interfaces;
using BMS.DTOs;
using BMS.InfraStructure.InfraStructure.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.BAL
{
    public  class PosServices : IPosServices
    {
        private const string className = nameof(PosServices);
        private readonly IRepository<PosDTO> _posRepository;
        private readonly ILogger _logger;

       
        public PosServices(IRepository<PosDTO> posRepository, ILogger logger)
        {
            _posRepository = posRepository;
            _logger = logger;
        }

      
        public async Task<List<PosDTO>> GetAllAsync(int? page, int? rowCount, string? column, string? value)
        {
            try
            {
                return await _posRepository.GetAllAsync(page, rowCount, column, value);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{className}.{nameof(GetAllAsync)}] {ex.Message}");
                return new List<PosDTO>(); 
            }
        }

       
        public async Task<PosDTO> GetInfoAsync(int id)
        {
            try
            {
                return await _posRepository.GetInfoAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{className}.{nameof(GetInfoAsync)},ByID] ID: {id}, Error: {ex.Message}");
                return null!;
            }
        }

       
        public async Task<PosDTO> GetInfoAsync(string name)
        {
            try
            {
                return await _posRepository.GetInfoAsync(name);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{className}.{nameof(GetInfoAsync)},ByName] Name: {name}, Error: {ex.Message}");
                return null!;
            }
        }


        public async Task<bool> UpdateAsync(PosDTO Pos)
        {
            try
            {
                return await _posRepository.UpdateAsync(Pos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{className}.{nameof(UpdateAsync)}] ID: {Pos.ID}, Error: {ex.Message}");
                return false;
            }
        }



        
        public async Task<int> AddAsync(PosDTO Pos)
        {
            try
            {
                return await _posRepository.AddNewAsync(Pos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{className}.{nameof(AddAsync)}] {ex.Message}");
                return -1;
            }
        }

      
        public async Task<bool> DeleteAsync(int id, int? userId)
        {
            try
            {
                return await _posRepository.DeleteAsync(id, userId);
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
        public async Task<long> GetCountAsync(string tableName)
        {
            try
            {
                return await _posRepository.GetNumberOfRecordsAsync(tableName);
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
        /// <param name="Pos">The department to save or update.</param>
        /// <returns>True if the operation was successful; otherwise, false.</returns>
        public async Task<bool> SaveAsync(PosDTO Pos)
        {
            try
            {
                if (Pos.ID == -1)
                {
                    var id = await AddAsync(Pos);
                    Pos.ID = id;
                    return id != -1;
                }
                else
                {
                    return await UpdateAsync(Pos);
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
