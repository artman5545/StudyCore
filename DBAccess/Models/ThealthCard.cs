using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class ThealthCard
    {
        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public Guid? UserId { get; set; }
        public string HealthCardNo { get; set; }
        public string MobNo { get; set; }
        public string CardName { get; set; }
        public DateTime? BindTime { get; set; }
        public string CardId { get; set; }
        public bool? IsDisable { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
        public string IdNo { get; set; }
    }
}
