using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class AdministratorRole
    {
        public AdministratorRole()
        {
            AdministratorAdministratorRoleMappings = new HashSet<AdministratorAdministratorRoleMapping>();
            PermissionRecordRoleMappings = new HashSet<PermissionRecordRoleMapping>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool IsSystemRole { get; set; }
        public string SystemName { get; set; }
        public Guid InstitutionId { get; set; }

        public virtual ICollection<AdministratorAdministratorRoleMapping> AdministratorAdministratorRoleMappings { get; set; }
        public virtual ICollection<PermissionRecordRoleMapping> PermissionRecordRoleMappings { get; set; }
    }
}
