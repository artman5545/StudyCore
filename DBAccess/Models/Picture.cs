using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class Picture
    {
        public Picture()
        {
            ArticlePictureMappings = new HashSet<ArticlePictureMapping>();
            Carousels = new HashSet<Carousel>();
            GuestMessagePictureMappings = new HashSet<GuestMessagePictureMapping>();
            HealthRecordPictures = new HashSet<HealthRecordPicture>();
        }

        public Guid Id { get; set; }
        public byte[] PictureBinary { get; set; }
        public string MimeType { get; set; }
        public string SeoFilename { get; set; }
        public string AltAttribute { get; set; }
        public string TitleAttribute { get; set; }
        public bool IsNew { get; set; }

        public virtual ICollection<ArticlePictureMapping> ArticlePictureMappings { get; set; }
        public virtual ICollection<Carousel> Carousels { get; set; }
        public virtual ICollection<GuestMessagePictureMapping> GuestMessagePictureMappings { get; set; }
        public virtual ICollection<HealthRecordPicture> HealthRecordPictures { get; set; }
    }
}
