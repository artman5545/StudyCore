using System;
using System.Collections.Generic;

namespace App.DBModel.Models
{
    public partial class Organization
    {
        public Organization()
        {
            OrgEmpRls = new HashSet<OrgEmpRls>();
            OrgManagerRls = new HashSet<OrgManagerRls>();
            OrganizationManage = new HashSet<OrganizationManage>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long? UpId { get; set; }
        public string Memo { get; set; }
        public bool? DeleteStatus { get; set; }
        public long? OrganizationTypeId { get; set; }
        public string LevelCodes { get; set; }

        public virtual OrganizationType OrganizationType { get; set; }
        public virtual ICollection<OrgEmpRls> OrgEmpRls { get; set; }
        public virtual ICollection<OrgManagerRls> OrgManagerRls { get; set; }
        public virtual ICollection<OrganizationManage> OrganizationManage { get; set; }
    }
}
