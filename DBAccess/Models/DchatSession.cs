using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class DchatSession
    {
        public DchatSession()
        {
            DchatMessages = new HashSet<DchatMessage>();
        }

        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public Guid DepartId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid ClientId { get; set; }
        public string Title { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime LastMsgTime { get; set; }
        public string LastMsgText { get; set; }
        public int? NotReadCount { get; set; }
        public byte ChatState { get; set; }
        public bool IsClosed { get; set; }

        public virtual ICollection<DchatMessage> DchatMessages { get; set; }
    }
}
