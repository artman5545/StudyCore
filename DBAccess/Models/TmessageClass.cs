using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class TmessageClass
    {
        public TmessageClass()
        {
            DmessageLists = new HashSet<DmessageList>();
            InverseParent = new HashSet<TmessageClass>();
        }

        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public string Title { get; set; }
        public string IconImageUrl { get; set; }
        public string IntroText { get; set; }
        public Guid? ParentId { get; set; }
        public string ParentIdlist { get; set; }
        public int Depth { get; set; }
        public int SortNo { get; set; }
        public bool IsSystemCategory { get; set; }
        public bool IsDisable { get; set; }
        public bool IsDelete { get; set; }

        public virtual TmessageClass Parent { get; set; }
        public virtual ICollection<DmessageList> DmessageLists { get; set; }
        public virtual ICollection<TmessageClass> InverseParent { get; set; }
    }
}
