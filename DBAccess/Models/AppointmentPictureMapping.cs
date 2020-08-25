using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class AppointmentPictureMapping
    {
        public Guid Id { get; set; }
        public Guid AppointmentId { get; set; }
        public Guid PictureId { get; set; }
        public string ThumbUrl { get; set; }

        public virtual Appointment Appointment { get; set; }
    }
}
