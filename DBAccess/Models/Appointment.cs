using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class Appointment
    {
        public Appointment()
        {
            AppointmentPictureMappings = new HashSet<AppointmentPictureMapping>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public int Sex { get; set; }
        public int SexId { get; set; }
        public string CardNo { get; set; }
        public Guid? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public DateTime BookingTime { get; set; }
        public DateTime LastWaitTime { get; set; }
        public bool IsAudit { get; set; }
        public int AuditStatus { get; set; }
        public string ReplyContent { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsDelete { get; set; }
        public Guid InstitutionId { get; set; }

        public virtual ICollection<AppointmentPictureMapping> AppointmentPictureMappings { get; set; }
    }
}
