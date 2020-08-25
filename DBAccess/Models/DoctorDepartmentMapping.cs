using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class DoctorDepartmentMapping
    {
        public Guid EmployeeId { get; set; }
        public Guid DepartmentId { get; set; }

        public virtual Tdepartment Department { get; set; }
        public virtual TdoctorList Employee { get; set; }
    }
}
