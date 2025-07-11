
using System;
using System.Collections.Generic;
using System.Data;
using BMS.BAL;

namespace MyApp.Entities
{
    /// <summary>
    /// Represents a department entity with properties for ID, Name, Description, and other metadata.
    /// </summary>
    public class Departments : BaseEnitity
    {
        public string Name { get; set; }
        public object Description { get; set; }

        public Departments(int iD, string name, string? description, int createdByUserID, string creationDate, int? updatedByUserID, string? lastUpdatedDate, bool isActive)
        {
            ID = iD;
            Name = name;
            Description = description;
            CreatedByUserID = createdByUserID;
            CreationDate = creationDate;
            UpdatedByUserID = updatedByUserID;
            LastUpdatedDate = lastUpdatedDate;
            IsActive = isActive;
        }

        public Departments()
        {
            ID = -1;
            Name = string.Empty;
            Description = null;
            CreatedByUserID = -1;
            CreationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            UpdatedByUserID = null;
            LastUpdatedDate = null;
            IsActive = true;
        }

        
    }
}
