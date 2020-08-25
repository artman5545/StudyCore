using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class NursingTeam
    {
        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public string IntroText { get; set; }
        public Guid DepartmentId { get; set; }
        public bool IsDelete { get; set; }
        public bool Disabled { get; set; }

        public virtual Tdepartment Department { get; set; }
    }
}
