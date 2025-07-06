using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{


    // Department stored procedures enum
    public enum SPDept
    {
            AddDepartment,
            UpdateDepartment,
            GetAllDepartments,
            DeleteDepartment,
            GetDepartmentByName,
            GetDepartmentByID,
            GetNumberOfDepartmentsRecords
    }



    /// <summary>
    ///  the class is used to map stored procedure names to enum values.
    /// </summary>

    public static class SPHelper
    {
        private static readonly Dictionary<Type, Dictionary<Enum, string>> _enumMaps = new()
        {
             [typeof(SPDept)] = new Dictionary<Enum, string>
             {
                 { SPDept.AddDepartment,"SP_AddNewDepartment" },
                 { SPDept.UpdateDepartment,"SP_UpdateDepartment" },
                 { SPDept.GetAllDepartments,"SP_GetAllDepartments"},
                 { SPDept.DeleteDepartment,"SP_DeleteDepartment"},
                 { SPDept.GetDepartmentByName,"SP_GetDepartmentByName"},
                 { SPDept.GetDepartmentByID,"SP_GetDepartmentByID"},
                 {SPDept.GetNumberOfDepartmentsRecords, "SP_GetNumberOfDepartmentsRecords" }
             }




        };

        public static string GetName<TEnum>(TEnum sp) where TEnum : Enum
        {
            var enumType = typeof(TEnum);

            if (_enumMaps.TryGetValue(enumType, out var map))
            {
                return map[sp];
            }

            throw new ArgumentException($"No map found for enum type {enumType.Name}");
        }

    }

    
}
