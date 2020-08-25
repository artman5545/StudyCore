using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class QrtzCronTrigger
    {
        public string SchedName { get; set; }
        public string TriggerName { get; set; }
        public string TriggerGroup { get; set; }
        public string CronExpression { get; set; }
        public string TimeZoneId { get; set; }

        public virtual QrtzTrigger QrtzTrigger { get; set; }
    }
}
