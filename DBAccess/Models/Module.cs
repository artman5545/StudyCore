using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class Module
    {
        public Module()
        {
            ModuleFiles = new HashSet<ModuleFile>();
        }

        public Guid Id { get; set; }
        public Guid? InstitutionId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int? ModuleTypeId { get; set; }
        public Guid? ModuleCategoryId { get; set; }
        public Guid TerminalId { get; set; }

        public virtual ModuleCategory ModuleCategory { get; set; }
        public virtual ICollection<ModuleFile> ModuleFiles { get; set; }
    }
}
