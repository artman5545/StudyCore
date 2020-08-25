using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class ModuleCategory
    {
        public ModuleCategory()
        {
            Modules = new HashSet<Module>();
        }

        public Guid Id { get; set; }
        public Guid? InstitutionId { get; set; }
        public string Title { get; set; }
        public string IntroText { get; set; }
        public Guid? ParentId { get; set; }
        public int? Depth { get; set; }
        public int? SortNo { get; set; }
        public bool? Disabled { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }

        public virtual ICollection<Module> Modules { get; set; }
    }
}
