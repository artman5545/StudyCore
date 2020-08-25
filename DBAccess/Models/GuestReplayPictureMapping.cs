using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class GuestReplayPictureMapping
    {
        public Guid Id { get; set; }
        public Guid GuestMessageReplayId { get; set; }
        public Guid PictureId { get; set; }
        public string ThumbUrl { get; set; }
        public int DisplayOrder { get; set; }
    }
}
