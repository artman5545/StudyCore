using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class JobTrigger
    {
        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public string SchedName { get; set; }
        public string JobGroupName { get; set; }
        public string JobName { get; set; }
        public string TriggerGroupName { get; set; }
        public string TriggerName { get; set; }
        public string Cron { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime NextTime { get; set; }
        public DateTime PrevTime { get; set; }
        public string State { get; set; }
        public DateTime CreateTime { get; set; }
        public Guid? JobTypeId { get; set; }
        public string JobTypeName { get; set; }
    }
}
