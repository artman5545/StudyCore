using System;
using System.Collections.Generic;

namespace App.DBModel.Models
{
    public partial class OrganizationManage
    {
        public long OrganizationId { get; set; }
        public long EmployeeId { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
