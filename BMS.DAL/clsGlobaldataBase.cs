using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Utilities;
using Microsoft.Data.SqlClient;

public static class clsGlobalDatabase 
{


    private static readonly string _connectionString = ConfigReader.GetConnectionString();




    /// <summary>
    /// This method is used to get  records from a table using a stored procedure.
    /// </summary>
    /// <param name="ProcedureName"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    /// <exception cref="SqlException"></exception>
    public static async Task <DataTable> GetAllAsyncByStoredProcedure(string ProcedureName, SqlParameter[]? parameters = null)
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            using (SqlCommand command = new SqlCommand(ProcedureName, connection))
            {
               
                command.CommandType = CommandType.StoredProcedure;
                AddParameters(command, parameters);



                try
                {
                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        DataTable results = new DataTable();
                        results.Load(reader);
                        return results;
                    }
                }
                catch(SqlException ex)
                {
                    Logger.LogError($"Procedure: {ProcedureName}, Error: {ex.Message}", true);
                    throw new Exception("An error occurred while processing your request. Please contact the administrator.", ex);
                }
                catch(Exception ex)
                {
                    Logger.LogError($"Procedure: {ProcedureName}, Error: {ex.Message}", true);
                    throw new Exception("An error occurred while processing your request. Please contact the administrator.", ex);

                }
            }
        }     
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="ProcedureName"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    /// <exception cref="SqlException"></exception>
    public static async Task<Dictionary<string,object>> GetSingleRecord(string ProcedureName, SqlParameter[]? parameters = null)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            using (SqlCommand command = new SqlCommand(ProcedureName, connection))
            {
                
                command.CommandType = CommandType.StoredProcedure;
                AddParameters(command, parameters);

                Dictionary<string, object?> RecordData = new Dictionary<string, object?>();


                try
                {
                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string ColumnName = reader.GetName(i);

                                object? value = reader.IsDBNull(i) ? null : reader.GetValue(i);
                                RecordData[ColumnName] = value ;
                            }

                        }
                    }
                    return RecordData;
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
    }




    /// <summary>
    ///  This method is used to execute a stored procedure that returns a single value (scalar).
    ///  its used in Adding , Updating ,Deleting
    /// </summary>
    /// <param name="procedureName"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    /// <exception cref="SqlException"></exception>
    public static  async Task<int> ExecuteNonQueryAsync(string procedureName, SqlParameter[]? parameters = null)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
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
    }


 
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




