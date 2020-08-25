using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class PermissionRecordRoleMapping
    {
        public Guid PermissionRecordId { get; set; }
        public Guid AdministratorRoleId { get; set; }

        public virtual AdministratorRole AdministratorRole { get; set; }
        public virtual PermissionRecord PermissionRecord { get; set; }
    }
}
