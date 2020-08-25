using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class AdvertisementTerminalMapping
    {
        public Guid? AdvertisementId { get; set; }
        public Guid? TerminalId { get; set; }
    }
}
