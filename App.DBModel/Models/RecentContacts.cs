using System;
using System.Collections.Generic;

namespace App.DBModel.Models
{
    public partial class RecentContacts
    {
        public long Id { get; set; }
        public long? EmployeeId { get; set; }
        public long? AddEmployeeId { get; set; }
        public DateTime? AddTime { get; set; }
    }
}
