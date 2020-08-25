using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class DmessageSendLog
    {
        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public Guid FormNo { get; set; }
        public byte SystemType { get; set; }
        public byte HisBussinessType { get; set; }
        public DateTime BillTime { get; set; }
        public string HealthCardNo { get; set; }
        public int MessageType { get; set; }
        public string MessageTitle { get; set; }
        public string MessageContent { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? SendTime { get; set; }
        public string BillNo { get; set; }
        public string Link { get; set; }
        public bool IsRead { get; set; }
    }
}
