using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class TdoctorList
    {
        public TdoctorList()
        {
            DdutyDoctors = new HashSet<DdutyDoctor>();
            DoctorDepartmentMappings = new HashSet<DoctorDepartmentMapping>();
            LdepartDoctors = new HashSet<LdepartDoctor>();
        }

        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public Guid? UserId { get; set; }
        public Guid PictureId { get; set; }
        public string HeadImageUrl { get; set; }
        public string FullName { get; set; }
        public string BeGoodAt { get; set; }
        public string DoctorMemo { get; set; }
        public int Sex { get; set; }
        public int EmployeeTypeId { get; set; }
        public int? Age { get; set; }
        public string ProTitle { get; set; }
        public int SortNo { get; set; }
        public bool IsDisable { get; set; }
        public bool IsDelete { get; set; }
        public string Kudos { get; set; }
        public string HisSystemId { get; set; }
        public bool? IsOnlineChat { get; set; }
        public decimal? OnlineChatPrice { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public string OnlineStatus { get; set; }
        public DateTime? LastOnlineTime { get; set; }
        public string Clientid { get; set; }

        public virtual ICollection<DdutyDoctor> DdutyDoctors { get; set; }
        public virtual ICollection<DoctorDepartmentMapping> DoctorDepartmentMappings { get; set; }
        public virtual ICollection<LdepartDoctor> LdepartDoctors { get; set; }
    }
}
