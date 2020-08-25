using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class QrtzCalendar
    {
        public string SchedName { get; set; }
        public string CalendarName { get; set; }
        public byte[] Calendar { get; set; }
    }
}
