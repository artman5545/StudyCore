using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class HealthRecordPicture
    {
        public Guid Id { get; set; }
        public Guid HealthRecordId { get; set; }
        public Guid PictureId { get; set; }
        public int DisplayOrder { get; set; }

        public virtual DhealthRecord HealthRecord { get; set; }
        public virtual Picture Picture { get; set; }
    }
}
