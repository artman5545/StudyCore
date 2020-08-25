using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class TmessageType
    {
        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public int SortNo { get; set; }
        public bool IsDelete { get; set; }
    }
}
