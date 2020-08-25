using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class GuestMessagePictureMapping
    {
        public Guid Id { get; set; }
        public Guid GuestMessageId { get; set; }
        public Guid PictureId { get; set; }
        public string ThumbUrl { get; set; }
        public int DisplayOrder { get; set; }

        public virtual DguestMessage GuestMessage { get; set; }
        public virtual Picture Picture { get; set; }
    }
}
