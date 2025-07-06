
using System;
using System.Collections.Generic;
using System.Data;
using DAL;
using Utilities;
namespace BAL
{
    /// <summary>
    /// Represents a department entity with properties for ID, Name, Description, and other metadata.
    /// </summary>
    public class Departments
    {
        /// <summary>
        /// Gets or sets the unique identifier for the department.
        /// </summary>
        public int ID { get; set; } = -1;

        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        public  string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the department.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who created the department.
        /// </summary>
        public int CreatedByUserID { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the department.
        /// </summary>
        public  string CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who last updated the department.
        /// </summary>
        public int? UpdatedByUserID { get; set; }

        /// <summary>
        /// Gets or sets the last updated date of the department.
        /// </summary>
        public string? LastUpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the department is active.
        /// </summary>
        public bool IsActive { get; set; }
    }
}
