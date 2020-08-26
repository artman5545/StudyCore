using System;
using System.Collections.Generic;

namespace App.DBModel.Models
{
    public partial class SystemPage
    {
        public SystemPage()
        {
            RoleSystemPage = new HashSet<RoleSystemPage>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string PageUrl { get; set; }
        public bool? IsDisable { get; set; }
        public long? ParentId { get; set; }
        public string Icon { get; set; }
        public int? Sort { get; set; }

        public virtual ICollection<RoleSystemPage> RoleSystemPage { get; set; }
    }
}
