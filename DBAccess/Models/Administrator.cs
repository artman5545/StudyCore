using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class Administrator : Entity<Guid>
    {
        public Administrator()
        {
            AdministratorAdministratorRoleMappings = new HashSet<AdministratorAdministratorRoleMapping>();
        }

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Guid InstitutionId { get; set; }
        public string Password { get; set; }
        public int PasswordFormatId { get; set; }
        public string PasswordSalt { get; set; }
        public bool Active { get; set; }
        public string LastIpAddress { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime LastActivityDate { get; set; }

        public virtual ICollection<AdministratorAdministratorRoleMapping> AdministratorAdministratorRoleMappings { get; set; }
    }
}
