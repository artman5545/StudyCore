using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class DchatMessage
    {
        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public Guid ChatSessionId { get; set; }
        public Guid ClientAppid { get; set; }
        public Guid DutyAppid { get; set; }
        public Guid SendId { get; set; }
        public Guid ToId { get; set; }
        public Guid HelpId { get; set; }
        public byte? MsgType { get; set; }
        public DateTime? SendTime { get; set; }
        public DateTime? ReciveTime { get; set; }
        public string MsgContent { get; set; }
        public bool IsRead { get; set; }
        public bool IsDelete { get; set; }

        public virtual DchatSession ChatSession { get; set; }
    }
}
