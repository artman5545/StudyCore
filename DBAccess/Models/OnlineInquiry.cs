using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class OnlineInquiry
    {
        public long Id { get; set; }
        public Guid? DoctorId { get; set; }
        public Guid? PatientId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime? Time { get; set; }
    }
}
