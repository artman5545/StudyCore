using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class TsystemType
    {
        public Guid Id { get; set; }
        public byte Code { get; set; }
        public string Name { get; set; }
    }
}
