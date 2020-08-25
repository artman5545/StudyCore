using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class Tinstitution
    {
        public Tinstitution()
        {
            UserInstitutionMappings = new HashSet<UserInstitutionMapping>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public Guid? CarouseCategoryId { get; set; }
        public int SortNo { get; set; }
        public bool IsDisable { get; set; }
        public bool IsDelete { get; set; }
        public string Version { get; set; }

        public virtual CarouselCategory CarouseCategory { get; set; }
        public virtual ICollection<UserInstitutionMapping> UserInstitutionMappings { get; set; }
    }
}
