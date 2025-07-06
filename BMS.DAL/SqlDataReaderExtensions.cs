using Microsoft.Data.SqlClient;
// Add the following extension method to handle the 'HasColumn' functionality.
public static class SqlDataReaderExtensions
{
    /// <summary>
    /// Checks if the SqlDataReader contains a column with the specified name.
    /// </summary>
    /// <param name="reader">The SqlDataReader instance.</param>
    /// <param name="columnName">The name of the column to check.</param>
    /// <returns>True if the column exists; otherwise, false.</returns>
    public static bool HasColumn(this SqlDataReader reader, string columnName)
    {
        for (int i = 0; i < reader.FieldCount; i++)
        {
            if (reader.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }
}



