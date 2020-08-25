using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class DfuntionList
    {
        public DfuntionList()
        {
            InverseParent = new HashSet<DfuntionList>();
        }

        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public Guid? AppId { get; set; }
        public string Title { get; set; }
        public int ActionArea { get; set; }
        public int ActionType { get; set; }
        public string LinkUrl { get; set; }
        public string PicUrl { get; set; }
        public string IconUrl { get; set; }
        public string FunctionMemo { get; set; }
        public Guid? ParentId { get; set; }
        public string ParentIdlist { get; set; }
        public int Depth { get; set; }
        public int SortNo { get; set; }
        public bool IsDisable { get; set; }
        public bool IsDelete { get; set; }

        public virtual DfuntionList Parent { get; set; }
        public virtual ICollection<DfuntionList> InverseParent { get; set; }
    }
}
