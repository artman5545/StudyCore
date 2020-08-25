using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class CjbdoctorInstitution
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public string InstitutionName { get; set; }
        public string DepartmentName { get; set; }
        public string EmployeeTypeName { get; set; }
        public string GoodAt { get; set; }
        public Guid? InstitutionId { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? EmployeeTypeId { get; set; }
    }
}
