using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class CrmMenu
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int? Upid { get; set; }
        public string Url { get; set; }
    }
}
