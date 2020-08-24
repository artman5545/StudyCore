using System;
using System.Collections.Generic;
using System.Text;
using MessagePack;

namespace WebClient.Mapping
{
    /// <summary>
    /// 
    /// </summary>
    [MessagePackObject(true)]
    public class MUserInfo
    {
        [Key(0)]
        public int Id { get; set; }
        [Key(1)]
        public string UserAccount { get; set; }
        [Key(2)]
        public string UserPassword { get; set; }
        [Key(3)]
        public string UserName { get; set; }
        [Key(4)]
        public string Gender { get; set; }
        [Key(5)]
        public int? Age { get; set; }
        [Key(6)]
        public string Email { get; set; }
    }
}
