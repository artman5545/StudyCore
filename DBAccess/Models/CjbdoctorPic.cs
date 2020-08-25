using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class CjbdoctorPic
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public Guid? PicIdCard0 { get; set; }
        public string UrlCard0 { get; set; }
        public Guid? PicIdCard1 { get; set; }
        public string UrlCard1 { get; set; }
        public Guid? PicIdQual0 { get; set; }
        public Guid? PicIdQual1 { get; set; }
        public Guid? PicIdQual2 { get; set; }
        public Guid? PicIdQual3 { get; set; }
        public Guid? PicIdQual4 { get; set; }
        public string UrlQual0 { get; set; }
        public string UrlQual1 { get; set; }
        public string UrlQual2 { get; set; }
        public string UrlQual3 { get; set; }
        public string UrlQual4 { get; set; }
        public Guid? PicIdPrac0 { get; set; }
        public Guid? PicIdPrac1 { get; set; }
        public Guid? PicIdPrac2 { get; set; }
        public Guid? PicIdPrac3 { get; set; }
        public Guid? PicIdPrac4 { get; set; }
        public string UrlPrac0 { get; set; }
        public string UrlPrac1 { get; set; }
        public string UrlPrac2 { get; set; }
        public string UrlPrac3 { get; set; }
        public string UrlPrac4 { get; set; }
        public Guid? PicIdTitle0 { get; set; }
        public Guid? PicIdTitle1 { get; set; }
        public Guid? PicIdTitle2 { get; set; }
        public Guid? PicIdTitle3 { get; set; }
        public Guid? PicIdTitle4 { get; set; }
        public string UrlTitle0 { get; set; }
        public string UrlTitle1 { get; set; }
        public string UrlTitle2 { get; set; }
        public string UrlTitle3 { get; set; }
        public string UrlTitle4 { get; set; }
        public Guid? PicIdFace { get; set; }
        public string UrlFace { get; set; }
    }
}
