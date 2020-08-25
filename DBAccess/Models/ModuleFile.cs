using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class ModuleFile
    {
        public Guid Id { get; set; }
        public Guid? InstitutionId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Guid ModuleId { get; set; }
        public int? FileTypeId { get; set; }

        public virtual Module Module { get; set; }
    }
}
