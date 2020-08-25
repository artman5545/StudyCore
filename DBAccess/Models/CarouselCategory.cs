using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class CarouselCategory
    {
        public CarouselCategory()
        {
            Carousels = new HashSet<Carousel>();
            InverseParent = new HashSet<CarouselCategory>();
            Tinstitutions = new HashSet<Tinstitution>();
        }

        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public string Name { get; set; }
        public string IntroText { get; set; }
        public Guid? ParentId { get; set; }
        public int SortNo { get; set; }
        public bool Disabled { get; set; }
        public bool Deleted { get; set; }

        public virtual CarouselCategory Parent { get; set; }
        public virtual ICollection<Carousel> Carousels { get; set; }
        public virtual ICollection<CarouselCategory> InverseParent { get; set; }
        public virtual ICollection<Tinstitution> Tinstitutions { get; set; }
    }
}
