using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class CrmPower2
    {
        public long Id { get; set; }
        public Guid? Did { get; set; }
        public int? Power1 { get; set; }
        public int? Power2 { get; set; }
        public string Url { get; set; }
    }
}
