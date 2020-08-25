using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class Cjbpatient
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string IdNo { get; set; }
        public string MobNo { get; set; }
        public int? Sex { get; set; }
        public int? Age { get; set; }
        public string JsfullName { get; set; }
        public string JsmobNo { get; set; }
        public DateTime? BillTime { get; set; }
        public string Describe { get; set; }
        public string History { get; set; }
        public string HeartRate { get; set; }
        public string SysPress { get; set; }
        public string DiaPress { get; set; }
        public string Diagnosis { get; set; }
        public string Advice { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? Active { get; set; }
        public Guid? Creator { get; set; }
    }
}
