using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class TdutyDepartment
    {
        public TdutyDepartment()
        {
            DdutyDoctors = new HashSet<DdutyDoctor>();
        }

        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public Guid DepartId { get; set; }
        public string DutyTitle { get; set; }
        public string Descption { get; set; }
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int SortNo { get; set; }
        public bool IsDelete { get; set; }

        public virtual Tdepartment Depart { get; set; }
        public virtual ICollection<DdutyDoctor> DdutyDoctors { get; set; }
    }
}
