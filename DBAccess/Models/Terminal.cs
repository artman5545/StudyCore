using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class Terminal
    {
        public Guid Id { get; set; }
        public Guid? InstitutionId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string MacAddress { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string Position { get; set; }
        public int? TypeId { get; set; }
        public bool? Disabled { get; set; }
    }
}
