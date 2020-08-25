using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class DguestReplay
    {
        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public string MsgTitle { get; set; }
        public Guid DguestMessageEntityId { get; set; }
        public string MsgContent { get; set; }
        public bool IsRead { get; set; }
        public int SortNo { get; set; }
        public bool IsDisable { get; set; }
        public bool IsDelete { get; set; }
        public Guid? AddUserId { get; set; }
        public DateTime? AddTime { get; set; }
        public Guid? EditUserId { get; set; }
        public DateTime? EditTime { get; set; }
        public bool? IsNew { get; set; }

        public virtual DguestMessage DguestMessageEntity { get; set; }
    }
}
