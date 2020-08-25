using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class SchemaSnapshot
    {
        public byte[] Snapshot { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
