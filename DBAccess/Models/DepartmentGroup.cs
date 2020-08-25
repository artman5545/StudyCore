using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class DepartmentGroup
    {
        public DepartmentGroup()
        {
            Tdepartments = new HashSet<Tdepartment>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Tdepartment> Tdepartments { get; set; }
    }
}
