
namespace DataManage.Models
{
    public partial class UserInfo
    {
        public int Id { get; set; }
        public string UserAccount { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
    }
}
