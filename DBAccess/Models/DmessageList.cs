using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class DmessageList
    {
        public DmessageList()
        {
            ArticlePictureMappings = new HashSet<ArticlePictureMapping>();
        }

        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public string MsgTitle { get; set; }
        public string MsgContent { get; set; }
        public Guid MsgClassId { get; set; }
        public string IntroImageUrl { get; set; }
        public string LinkUrl { get; set; }
        public DateTime PostTime { get; set; }
        public DateTime? TopTime { get; set; }
        public DateTime? TopOverTime { get; set; }
        public int? Hits { get; set; }
        public int SortNo { get; set; }
        public bool IsDisable { get; set; }
        public bool IsDelete { get; set; }
        public bool ShowOnBanner { get; set; }
        public Guid? DepartmentId { get; set; }

        public virtual TmessageClass MsgClass { get; set; }
        public virtual ICollection<ArticlePictureMapping> ArticlePictureMappings { get; set; }
    }
}
