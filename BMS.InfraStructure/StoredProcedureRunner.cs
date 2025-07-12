using Microsoft.Data.SqlClient;
using System.Data;
using BMS.InfraStructure.InfraStructure.interfaces;
using BMS.InfraStructure.Core.Interfaces;


namespace BMS.InfraStructure;
public class StoredProcedureRunner : IStoredProcedureRunner
{
    private readonly ISqlConnectionFactory _connectionFactory;

    
    public StoredProcedureRunner(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

  
    public async Task<List<T>> GetAllBySPAsync<T>(string procedureName, SqlParameter[]? parameters = null) where T : new()
    {
        var result = new List<T>();
        using var conn = _connectionFactory.CreateConnection();
        using var cmd = new SqlCommand(procedureName, conn)
        {
            CommandType = CommandType.StoredProcedure
        };
        AddParameters(cmd, parameters);

       
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

    public async Task<T> GetSingleRecordBySPAsync<T>(string ProcedureName, SqlParameter[]? parameters = null) where T : new()
    {
        using var conn = _connectionFactory.CreateConnection();
        using (SqlCommand command = new SqlCommand(ProcedureName, conn))
        {
            command.CommandType = CommandType.StoredProcedure;
            AddParameters(command, parameters);

            T item = new T();
            var props = typeof(T).GetProperties();

           
                await conn.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {

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
                    }
                }
                return item;
           
        }
    }

    public async Task<int> ExecuteNonQueryAsync(string procedureName, SqlParameter[]? parameters = null)
    {
        using var conn = _connectionFactory.CreateConnection();
        using (SqlCommand cmd = new SqlCommand(procedureName, conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            AddParameters(cmd, parameters);
            SqlParameter returnParam = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParam.Direction = ParameterDirection.ReturnValue;
           
             await conn.OpenAsync();
             await cmd.ExecuteNonQueryAsync();
             return (int)returnParam.Value;
           
        }
    }

    public async Task<int> GetNumberOfActiveRecordsAsync(string procedureName, SqlParameter[]? parameters = null)
    {
        int Result = 0;
        using var conn = _connectionFactory.CreateConnection();
        using (SqlCommand cmd = new SqlCommand(procedureName, conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            AddParameters(cmd, parameters);
           
            await conn.OpenAsync();
            if (cmd.ExecuteScalar() is int count)
            {
                Result = count;
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



