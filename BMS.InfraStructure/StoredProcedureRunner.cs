using BMS.InfraStructure.Core.Interfaces;
using BMS.InfraStructure.InfraStructure.interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;


namespace BMS.InfraStructure;
public class StoredProcedureRunner : IStoredProcedureRunner
{
    private readonly ISqlConnectionFactory _connectionFactory;

    
    public StoredProcedureRunner(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    

  
    public async Task<List<T>> GetAllBySPAsync<T>(string procedureName, object? parameters = null) where T : new()
    {
        using var conn = _connectionFactory.CreateConnection();
        var result = await conn.QueryAsync<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        return result.ToList();

    }

    public async Task<T> GetSingleRecordBySPAsync<T>(string procedureName, object? parameters = null) where T : new()
    {
        using var conn = _connectionFactory.CreateConnection();
        return await conn.QueryFirstOrDefaultAsync<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<int> ExecuteNonQueryAsync(string procedureName, DynamicParameters param)
    {
        using var conn = _connectionFactory.CreateConnection();

          
        
        param.Add("@ReturnVal", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

        await conn.ExecuteAsync(procedureName, param, commandType: CommandType.StoredProcedure);
        return param.Get<int>("@ReturnVal");
    }

    public async Task<long> GetNumberOfActiveRecordsAsync(string procedureName, object? parameters = null)
    {
        using var conn = _connectionFactory.CreateConnection();
        return await conn.ExecuteScalarAsync<int>(procedureName, parameters, commandType: CommandType.StoredProcedure);
    }

}



