﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class QrtzSimpleTrigger
    {
        public string SchedName { get; set; }
        public string TriggerName { get; set; }
        public string TriggerGroup { get; set; }
        public int RepeatCount { get; set; }
        public long RepeatInterval { get; set; }
        public int TimesTriggered { get; set; }

        public virtual QrtzTrigger QrtzTrigger { get; set; }
    }
}
