using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class PillReminder
    {
        public Guid Id { get; set; }
        public string HealthCardNumber { get; set; }
        public string PatientName { get; set; }
        public string MedicineName { get; set; }
        public int Period { get; set; }
        public int Frequency { get; set; }
        public int Days { get; set; }
        public int Times { get; set; }
        public bool IsSend { get; set; }
        public DateTime CreateTime { get; set; }
        public string RemindContent { get; set; }
    }
}
