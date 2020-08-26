using System;
using System.Collections.Generic;

namespace App.DBModel.Models
{
    public partial class SysLog
    {
        public long Id { get; set; }
        public long? EmployeeId { get; set; }
        public DateTime? AddTime { get; set; }
        public string Content { get; set; }
    }
}
