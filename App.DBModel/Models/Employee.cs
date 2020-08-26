using System;
using System.Collections.Generic;

namespace App.DBModel.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeRole = new HashSet<EmployeeRole>();
            OrgEmpRls = new HashSet<OrgEmpRls>();
            OrgManagerRls = new HashSet<OrgManagerRls>();
            ProjectEmployeeRls = new HashSet<ProjectEmployeeRls>();
            WorkCreateEmployee = new HashSet<Work>();
            WorkExcuteEmployee = new HashSet<Work>();
        }

        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string Name { get; set; }
        public DateTime? AddTime { get; set; }
        public DateTime? LoginTime { get; set; }
        public string DeleteStatus { get; set; }
        public string Pinying { get; set; }
        public string Spinying { get; set; }

        public virtual ICollection<EmployeeRole> EmployeeRole { get; set; }
        public virtual ICollection<OrgEmpRls> OrgEmpRls { get; set; }
        public virtual ICollection<OrgManagerRls> OrgManagerRls { get; set; }
        public virtual ICollection<ProjectEmployeeRls> ProjectEmployeeRls { get; set; }
        public virtual ICollection<Work> WorkCreateEmployee { get; set; }
        public virtual ICollection<Work> WorkExcuteEmployee { get; set; }
    }
}
