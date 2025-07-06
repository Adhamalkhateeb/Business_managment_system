using Microsoft.Data.SqlClient;
/// <summary>
/// Provides extension methods for the <see cref="SqlDataReader"/> class.
/// </summary>
public static class SqlDataReaderExtensions
{
    /// <summary>
    /// Checks if the <see cref="SqlDataReader"/> contains a column with the specified name.
    /// </summary>
    /// <param name="reader">The <see cref="SqlDataReader"/> instance.</param>
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



