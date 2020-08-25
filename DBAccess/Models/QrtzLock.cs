using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class QrtzLock
    {
        public string SchedName { get; set; }
        public string LockName { get; set; }
    }
}
