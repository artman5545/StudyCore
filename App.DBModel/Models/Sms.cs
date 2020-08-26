using System;
using System.Collections.Generic;

namespace App.DBModel.Models
{
    public partial class Sms
    {
        public long Id { get; set; }
        public string Mobile { get; set; }
        public string Code { get; set; }
        public DateTime? AddTime { get; set; }
    }
}
