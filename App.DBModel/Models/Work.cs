using System;
using System.Collections.Generic;

namespace App.DBModel.Models
{
    public partial class Work
    {
        public Work()
        {
            WorkVote = new HashSet<WorkVote>();
        }

        public long Id { get; set; }
        public long? ProjectId { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Memo { get; set; }
        public DateTime? AddTime { get; set; }
        public DateTime? PlanStartTime { get; set; }
        public DateTime? PlanEndTime { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal? Complete { get; set; }
        public DateTime? CompleteTime { get; set; }
        public string CompleteMemo { get; set; }
        public string Urgency { get; set; }
        public long? ExcuteEmployeeId { get; set; }
        public long? CreateEmployeeId { get; set; }
        public string ReceivingStatus { get; set; }
        public string RefuseReason { get; set; }
        public long? UpId { get; set; }
        public string LevelCodes { get; set; }
        public string DeleteStatus { get; set; }
        public int? SubCount { get; set; }
        public string Pinying { get; set; }
        public string Spinying { get; set; }

        public virtual Employee CreateEmployee { get; set; }
        public virtual Employee ExcuteEmployee { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<WorkVote> WorkVote { get; set; }
    }
}
