using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class DuserLogin
    {
        public DuserLogin()
        {
            InverseMainMember = new HashSet<DuserLogin>();
            ParentUserChildUserMappingChildUsers = new HashSet<ParentUserChildUserMapping>();
            ParentUserChildUserMappingParentUsers = new HashSet<ParentUserChildUserMapping>();
            ServicesReviews = new HashSet<ServicesReview>();
            UserInstitutionMappings = new HashSet<UserInstitutionMapping>();
        }

        public Guid Id { get; set; }
        public string HeadImageUrl { get; set; }
        public string MobNo { get; set; }
        public string UserName { get; set; }
        public int Sex { get; set; }
        public Guid? HealthCardId { get; set; }
        public Guid? MainMemberId { get; set; }
        public DateTime? LoginTime { get; set; }
        public string LoginDevice { get; set; }
        public string LoginPoint { get; set; }
        public DateTime? Birthday { get; set; }
        public string IdCard { get; set; }
        public string DomicilePlace { get; set; }
        public string Residence { get; set; }
        public string NickName { get; set; }

        public virtual DuserLogin MainMember { get; set; }
        public virtual ICollection<DuserLogin> InverseMainMember { get; set; }
        public virtual ICollection<ParentUserChildUserMapping> ParentUserChildUserMappingChildUsers { get; set; }
        public virtual ICollection<ParentUserChildUserMapping> ParentUserChildUserMappingParentUsers { get; set; }
        public virtual ICollection<ServicesReview> ServicesReviews { get; set; }
        public virtual ICollection<UserInstitutionMapping> UserInstitutionMappings { get; set; }
    }
}
