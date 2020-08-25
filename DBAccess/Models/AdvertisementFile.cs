using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class AdvertisementFile
    {
        public Guid Id { get; set; }
        public Guid? InstitutionId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Guid? AdvertisementId { get; set; }
        public int? AdFileTypeId { get; set; }
    }
}
