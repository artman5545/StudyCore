using System;
using System.Collections.Generic;

namespace App.DBModel.Models
{
    public partial class EmployeeRole
    {
        public long EmployeeId { get; set; }
        public long RoleId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Role Role { get; set; }
    }
}
