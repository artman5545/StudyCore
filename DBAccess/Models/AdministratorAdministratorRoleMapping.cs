using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class AdministratorAdministratorRoleMapping
    {
        public Guid AdministratorId { get; set; }
        public Guid AdministratorRoleId { get; set; }

        public virtual Administrator Administrator { get; set; }
        public virtual AdministratorRole AdministratorRole { get; set; }
    }
}
