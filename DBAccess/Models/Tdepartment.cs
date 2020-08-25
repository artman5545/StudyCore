using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class Tdepartment
    {
        public Tdepartment()
        {
            DdutyDoctors = new HashSet<DdutyDoctor>();
            DoctorDepartmentMappings = new HashSet<DoctorDepartmentMapping>();
            InverseParent = new HashSet<Tdepartment>();
            LdepartDoctors = new HashSet<LdepartDoctor>();
            NursingTeams = new HashSet<NursingTeam>();
            TdutyDepartments = new HashSet<TdutyDepartment>();
        }

        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public string Title { get; set; }
        public Guid? PictureId { get; set; }
        public string IconImageUrl { get; set; }
        public string IntroText { get; set; }
        public Guid? ParentId { get; set; }
        public string ParentIdlist { get; set; }
        public int Depth { get; set; }
        public int SortNo { get; set; }
        public bool IsDisable { get; set; }
        public bool IsDelete { get; set; }
        public string HisSystemId { get; set; }
        public bool? IsPatientDepartment { get; set; }
        public Guid? DepartmentGroupId { get; set; }
        public string IconName { get; set; }
        public string Address { get; set; }
        public bool? IsOnlineChat { get; set; }

        public virtual DepartmentGroup DepartmentGroup { get; set; }
        public virtual Tdepartment Parent { get; set; }
        public virtual ICollection<DdutyDoctor> DdutyDoctors { get; set; }
        public virtual ICollection<DoctorDepartmentMapping> DoctorDepartmentMappings { get; set; }
        public virtual ICollection<Tdepartment> InverseParent { get; set; }
        public virtual ICollection<LdepartDoctor> LdepartDoctors { get; set; }
        public virtual ICollection<NursingTeam> NursingTeams { get; set; }
        public virtual ICollection<TdutyDepartment> TdutyDepartments { get; set; }
    }
}
