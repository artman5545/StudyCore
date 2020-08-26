using System;
using System.Collections.Generic;

namespace App.DBModel.Models
{
    public partial class RoleSystemPage
    {
        public long RoleId { get; set; }
        public long SystemPageId { get; set; }

        public virtual Role Role { get; set; }
        public virtual SystemPage SystemPage { get; set; }
    }
}
