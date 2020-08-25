using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class Building
    {
        public Building()
        {
            HeapMaps = new HashSet<HeapMap>();
        }

        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public Guid PictureId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual ICollection<HeapMap> HeapMaps { get; set; }
    }
}
