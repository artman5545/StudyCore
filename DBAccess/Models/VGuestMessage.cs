using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class VGuestMessage
    {
        public Guid? AddUserId { get; set; }
        public DateTime? Addtime { get; set; }
        public Guid? DoctorId { get; set; }
        public Guid InstitutionId { get; set; }
    }
}
