using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class Advertisement
    {
        public Guid Id { get; set; }
        public Guid? InstitutionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
