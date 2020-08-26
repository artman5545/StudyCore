using System;
using System.Collections.Generic;

namespace App.DBModel.Models
{
    public partial class OrganizationType
    {
        public OrganizationType()
        {
            Organization = new HashSet<Organization>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Organization> Organization { get; set; }
    }
}
