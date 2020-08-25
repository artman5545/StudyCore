using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class DhealthRecord
    {
        public DhealthRecord()
        {
            HealthRecordPictures = new HashSet<HealthRecordPicture>();
        }

        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public Guid? MemberId { get; set; }
        public int RecordType { get; set; }
        public int RecordCateType { get; set; }
        public DateTime CreateTime { get; set; }
        public string Creator { get; set; }
        public string Content { get; set; }
        public string Location { get; set; }
        public bool IsDelete { get; set; }

        public virtual ICollection<HealthRecordPicture> HealthRecordPictures { get; set; }
    }
}
