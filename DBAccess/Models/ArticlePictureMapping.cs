using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class ArticlePictureMapping
    {
        public Guid Id { get; set; }
        public Guid ArticleId { get; set; }
        public string ThumbUrl { get; set; }
        public Guid PictureId { get; set; }
        public int DisplayOrder { get; set; }

        public virtual DmessageList Article { get; set; }
        public virtual Picture Picture { get; set; }
    }
}
