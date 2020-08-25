using System;
using System.Collections.Generic;

#nullable disable

namespace DBAccess.Models
{
    public partial class Cjbdoctor
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? PasswordFormatId { get; set; }
        public string PasswordSalt { get; set; }
        public bool? Active { get; set; }
        public string LastIpAddress { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public Guid? PictureId { get; set; }
        public string HeadImageUrl { get; set; }
        public string FullName { get; set; }
        public string BeGoodAt { get; set; }
        public string DoctorMemo { get; set; }
        public int? Sex { get; set; }
        public int? Age { get; set; }
        public string ProTitle { get; set; }
        public int? SortNo { get; set; }
        public bool? IsDisable { get; set; }
        public bool? IsDelete { get; set; }
        public string Kudos { get; set; }
        public string IdNo { get; set; }
        public string MobNo { get; set; }
        public bool? Examine { get; set; }
        public string Remarks { get; set; }
    }
}
