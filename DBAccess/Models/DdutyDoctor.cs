using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class DdutyDoctor : Entity<Guid>
    {
        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public Guid DepartId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid DutyDepartId { get; set; }
        public bool IsOnline { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public DateTime? LastLogoutTime { get; set; }

        public virtual Tdepartment Depart { get; set; }
        public virtual TdoctorList Doctor { get; set; }
        public virtual TdutyDepartment DutyDepart { get; set; }
    }
}
