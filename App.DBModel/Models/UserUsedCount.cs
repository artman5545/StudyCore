using System;
using System.Collections.Generic;

namespace App.DBModel.Models
{
    public partial class UserUsedCount
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public long UsedCount { get; set; }
        public long CreateEmployeeId { get; set; }
        public DateTime? LastTime { get; set; }
    }
}
