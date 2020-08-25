using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class MigrationLogCurrent
    {
        public Guid MigrationId { get; set; }
        public string ScriptChecksum { get; set; }
        public string ScriptFilename { get; set; }
        public DateTime CompleteDt { get; set; }
        public string AppliedBy { get; set; }
        public byte Deployed { get; set; }
    }
}
