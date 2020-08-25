using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class HisBussinessType
    {
        public HisBussinessType()
        {
            Dbills = new HashSet<Dbill>();
        }

        public byte Code { get; set; }
        public Guid InstitutionId { get; set; }
        public string Name { get; set; }
        public Guid Id { get; set; }

        public virtual ICollection<Dbill> Dbills { get; set; }
    }
}
