using System;
using System.Collections.Generic;

namespace App.DBModel.Models
{
    public partial class Role
    {
        public Role()
        {
            EmployeeRole = new HashSet<EmployeeRole>();
            RoleSystemPage = new HashSet<RoleSystemPage>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public bool? IsDisable { get; set; }

        public virtual ICollection<EmployeeRole> EmployeeRole { get; set; }
        public virtual ICollection<RoleSystemPage> RoleSystemPage { get; set; }
    }
}
