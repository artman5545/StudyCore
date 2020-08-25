using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class Carousel
    {
        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public Guid CarouselCategoryId { get; set; }
        public Guid PictureId { get; set; }
        public string Title { get; set; }
        public string PictureUrl { get; set; }
        public string LinkAddress { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public bool Disabled { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual CarouselCategory CarouselCategory { get; set; }
        public virtual Picture Picture { get; set; }
    }
}
