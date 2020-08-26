using System;
using System.Collections.Generic;

namespace App.DBModel.Models
{
    public partial class Project
    {
        public Project()
        {
            ProjectEmployeeRls = new HashSet<ProjectEmployeeRls>();
            Work = new HashSet<Work>();
        }

        public long Id { get; set; }
        public string ProjectName { get; set; }
        public string Memo { get; set; }
        public DateTime? AddTime { get; set; }
        public long? Uid { get; set; }
        public bool? IsDisable { get; set; }
        public string Pingyin { get; set; }
        public string Spingyin { get; set; }

        public virtual ICollection<ProjectEmployeeRls> ProjectEmployeeRls { get; set; }
        public virtual ICollection<Work> Work { get; set; }
    }
}
