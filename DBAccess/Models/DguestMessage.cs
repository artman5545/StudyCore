using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class DguestMessage
    {
        public DguestMessage()
        {
            DguestReplays = new HashSet<DguestReplay>();
            GuestMessagePictureMappings = new HashSet<GuestMessagePictureMapping>();
        }

        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public string MsgTitle { get; set; }
        public string Address { get; set; }
        public string MsgContent { get; set; }
        public bool IsReplay { get; set; }
        public int SortNo { get; set; }
        public bool IsDisable { get; set; }
        public bool IsDelete { get; set; }
        public Guid? AddUserId { get; set; }
        public DateTime? AddTime { get; set; }
        public Guid? EditUserId { get; set; }
        public DateTime? EditTime { get; set; }
        public Guid? DoctorId { get; set; }
        public Guid? DepartmentId { get; set; }
        public bool? IsLike { get; set; }
        public bool? IsNew { get; set; }
        public bool? IsRead { get; set; }

        public virtual ICollection<DguestReplay> DguestReplays { get; set; }
        public virtual ICollection<GuestMessagePictureMapping> GuestMessagePictureMappings { get; set; }
    }
}
