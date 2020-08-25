using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class LdepartDoctor
    {
        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid DepartId { get; set; }
        public string HisDepartId { get; set; }
        public string HisDoctorId { get; set; }

        public virtual Tdepartment Depart { get; set; }
        public virtual TdoctorList Doctor { get; set; }
    }
}
