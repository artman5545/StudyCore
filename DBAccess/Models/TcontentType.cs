using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class TcontentType
    {
        public Guid Id { get; set; }
        public byte Code { get; set; }
        public string Name { get; set; }
    }
}
