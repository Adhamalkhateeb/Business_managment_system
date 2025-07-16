using BMS.DAL.Interfaces;
using BMS.DTOs;
using BMS.InfraStructure;
using BMS.InfraStructure.InfraStructure.interfaces;
using DAL;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.DAL
{
    public  class PosRepository :IRepository<PosDTO>
    {
        private readonly IStoredProcedureRunner _sp;

       
        public PosRepository(IStoredProcedureRunner SP)
        {
            _sp = SP;
        }

       
        public async Task<int> AddNewAsync(PosDTO Pos)
        {
            var param = new DynamicParameters();
            param.Add("@Name", Pos.Name);
            param.Add("@Balance", Pos.Balance);
            param.Add("@CreatedByUserID", Pos.CreatedByUserID);

            return await _sp.ExecuteNonQueryAsync(SPHelper.GetName(SPPos.AddPos),
              param);
        }


      
        public async Task<bool> UpdateAsync(PosDTO pos)
        {
            var param = new DynamicParameters();
            param.Add("@ID", pos.ID);
            param.Add("@Name", pos.Name);
            param.Add("@Balance", pos.Balance);
            param.Add("@UpdatedByUserID", pos.UpdatedByUserID);
            return await _sp.ExecuteNonQueryAsync(SPHelper.GetName(SPPos.UpdatePos), param) != -1;
        }




       
        public async Task<List<PosDTO>> GetAllAsync(int? PageNumber, int? Records, string? FilterColumn, string? FilterValue) =>

                 await _sp.GetAllBySPAsync<PosDTO>(SPHelper.GetName(SPPos.GetAllPos),
                new
                {
                    PageNumber = PageNumber,
                    PageSize = Records,
                    FilterColumn = FilterColumn,
                    FilterValue = FilterValue
                });


      
        public async Task<bool> DeleteAsync(int departmentID, int? UserID)
        {

            var param = new DynamicParameters();
            param.Add("@ID", departmentID);


            if (await _sp.ExecuteNonQueryAsync(SPHelper.GetName(SPPos.CheckDependencies), param) == -1)
            {
                param.Add("@UpdatedByUserID", UserID);
                return await _sp.ExecuteNonQueryAsync(SPHelper.GetName(SPPos.DeletePos), param) != -1;
            }
            else
                return false;


        }

        
        public async Task<PosDTO> GetInfoAsync(int PosID) =>
                await _sp.GetSingleRecordBySPAsync<PosDTO>(SPHelper.GetName(SPPos.GetPosByID), new
                { ID = PosID  }
                );



    
        public async Task<PosDTO> GetInfoAsync(string PosName)
        {
            return await _sp.GetSingleRecordBySPAsync<PosDTO>(SPHelper.GetName(SPPos.GetPosByName),
                new { Name = PosName  }
           );
        }

    
        public async Task<long> GetNumberOfRecordsAsync(string TableName)
        {
            if (string.IsNullOrEmpty(TableName))
                throw new ArgumentException("TableName cannot be null or empty", nameof(TableName));

            var result = await _sp.GetNumberOfActiveRecordsAsync(SPHelper.GetName(SPGeneral.GetNumberOfActiveRecords), new { TableName = TableName });
            return result;

        }
    }
}
