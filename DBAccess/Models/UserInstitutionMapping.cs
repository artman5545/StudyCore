using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class UserInstitutionMapping
    {
        public Guid UserId { get; set; }
        public Guid InstitutionId { get; set; }

        public virtual Tinstitution Institution { get; set; }
        public virtual DuserLogin User { get; set; }
    }
}
