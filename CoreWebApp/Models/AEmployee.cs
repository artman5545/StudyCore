using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApp.Models
{
    public class AEmployee
    {

        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string Name { get; set; }
        public DateTime? AddTime { get; set; }
        public DateTime? LoginTime { get; set; }
        public string DeleteStatus { get; set; }
        public string Pinying { get; set; }
        public string Spinying { get; set; }
    }
}
