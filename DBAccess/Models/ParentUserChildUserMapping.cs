using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class ParentUserChildUserMapping
    {
        public Guid ChildUserId { get; set; }
        public Guid ParentUserId { get; set; }

        public virtual DuserLogin ChildUser { get; set; }
        public virtual DuserLogin ParentUser { get; set; }
    }
}
