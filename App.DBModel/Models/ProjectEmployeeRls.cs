using System;
using System.Collections.Generic;

namespace App.DBModel.Models
{
    public partial class ProjectEmployeeRls
    {
        public long EmployeeId { get; set; }
        public long ProjectId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }
    }
}
