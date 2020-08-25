using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class Setting
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public Guid InstitutionId { get; set; }
        public string Memo { get; set; }
    }
}
