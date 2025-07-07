
using BMS.DAL.Interface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Utilities;

/// <include file='DAL.xml' path='docs/members[@name=T:BMS.DAL.DataBaseExecuter]'/>
public class DataBaseExecuter : IStoredProcedureRunner
{
    private readonly ISqlConnectionFactory _connectionFactory;

    /// <include file='DAL.xml' path='docs/members[@name=M:BMS.DAL.DataBaseExecuter.#ctor(System.Data.SqlClient.ISqlConnectionFactory)]'/>
    public DataBaseExecuter(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    /// <include file='DAL.xml' path='docs/members[@name=M:BMS.DAL.DataBaseExecuter.GetAllBySPAsync``1(System.String,System.Data.SqlClient.SqlParameter[])]'/>
    public async Task<List<T>> GetAllBySPAsync<T>(string procedureName, SqlParameter[]? parameters = null) where T : new()
    {
        var result = new List<T>();
        using var conn = _connectionFactory.CreateConnection();
        using var cmd = new SqlCommand(procedureName, conn)
        {
            CommandType = CommandType.StoredProcedure
        };
        AddParameters(cmd, parameters);

        try
        {
            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            var props = typeof(T).GetProperties();

            while (await reader.ReadAsync())
            {
                T item = new T();
                foreach (var prop in props)
                {
                    if (!reader.HasColumn(prop.Name))
                        continue;
                    if (!reader.IsDBNull(reader.GetOrdinal(prop.Name)))
                    {
                        var value = reader[prop.Name];
                        var targetType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                        prop.SetValue(item, Convert.ChangeType(value, targetType));
                    }
                }
                result.Add(item);
            }

            return result;
        }
        catch (Exception ex)
        {
            Logger.LogError($"[SP: {procedureName}] GetAll error: {ex.Message}", true);
            throw;
        }
    }

    /// <include file='DAL.xml' path='docs/members[@name=M:BMS.DAL.DataBaseExecuter.GetSingleRecordBySPAsync``1(System.String,System.Data.SqlClient.SqlParameter[])]'/>
    public async Task<T> GetSingleRecordBySPAsync<T>(string ProcedureName, SqlParameter[]? parameters = null) where T : new()
    {
        using var conn = _connectionFactory.CreateConnection();
        using (SqlCommand command = new SqlCommand(ProcedureName, conn))
        {
            command.CommandType = CommandType.StoredProcedure;
            AddParameters(command, parameters);

            T item = new T();
            var props = typeof(T).GetProperties();

            try
            {
                await conn.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.Read())
                    {
                        foreach (var prop in props)
                        {
                            object value = reader[prop.Name];

                            if (value != DBNull.Value)
                                prop.SetValue(item, Convert.ChangeType(value, prop.PropertyType));
                        }
                    }
                }
                return item;
            }
            catch (SqlException ex)
            {
                Logger.LogError($"Procedure: {ProcedureName}, Error: {ex.Message}", true);
                throw new Exception("An error occurred while processing your request. Please contact the administrator.", ex);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Procedure: {ProcedureName}, Error: {ex.Message}", true);
                throw new Exception("An error occurred while processing your request. Please contact the administrator.", ex);
            }
        }
    }

    /// <include file='DAL.xml' path='docs/members[@name=M:BMS.DAL.DataBaseExecuter.ExecuteNonQueryAsync(System.String,System.Data.SqlClient.SqlParameter[])]'/>
    public async Task<int> ExecuteNonQueryAsync(string procedureName, SqlParameter[]? parameters = null)
    {
        using var conn = _connectionFactory.CreateConnection();
        using (SqlCommand cmd = new SqlCommand(procedureName, conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            AddParameters(cmd, parameters);
            SqlParameter returnParam = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParam.Direction = ParameterDirection.ReturnValue;
            try
            {
                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                return (int)returnParam.Value;
            }
            catch (SqlException ex)
            {
                Logger.LogError($"Procedure: {procedureName}, Error: {ex.Message}", true);
                throw new Exception("An error occurred while processing your request. Please contact the administrator.", ex);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Procedure: {procedureName}, Error: {ex.Message}", true);
                throw new Exception("An error occurred while processing your request. Please contact the administrator.", ex);
            }
        }
    }

    /// <include file='DAL.xml' path='docs/members[@name=M:BMS.DAL.DataBaseExecuter.GetNumberOfActiveRecordsAsync(System.String,System.Data.SqlClient.SqlParameter[])]'/>
    public async Task<int> GetNumberOfActiveRecordsAsync(string procedureName, SqlParameter[]? parameters = null)
    {
        int Result = 0;
        using var conn = _connectionFactory.CreateConnection();
        using (SqlCommand cmd = new SqlCommand(procedureName, conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            AddParameters(cmd, parameters);
            try
            {
                await conn.OpenAsync();
                if (cmd.ExecuteScalar() is int count)
                {
                    Result = count;
                }
            }
            catch (SqlException ex)
            {
                Logger.LogError($"Procedure: {procedureName}, Error: {ex.Message}", true);
                throw new Exception("An error occurred while processing your request. Please contact the administrator.", ex);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Procedure: {procedureName}, Error: {ex.Message}", true);
                throw new Exception("An error occurred while processing your request. Please contact the administrator.", ex);
            }
        }

        return Result;
    }

    // Helper method to and to sql command parameters
    private static void AddParameters(SqlCommand cmd, SqlParameter[]? parameters = null)
    {
        if (parameters != null && parameters.Length > 0)
        {
            foreach (var param in parameters)
            {
                if (param.Value == null)
                {
                    param.Value = DBNull.Value;
                }
                cmd.Parameters.Add(param);
            }
        }
    }
}



