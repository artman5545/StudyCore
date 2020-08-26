using System;
using System.Collections.Generic;

namespace App.DBModel.Models
{
    public partial class WorkVote
    {
        public long Id { get; set; }
        public long? WorkId { get; set; }
        public long? TalkEmployeeId { get; set; }
        public string Content { get; set; }
        public DateTime? AddTime { get; set; }
        public string Support { get; set; }

        public virtual Work Work { get; set; }
    }
}
