using System;
using System.Collections.Generic;
using System.Text;
using DataManage.Models;
using Microsoft.EntityFrameworkCore;

namespace DataManage.Service
{
    public class UserService : BaseBLL<UserInfo>, IUserService {
        public UserService(DbContext _db) : base(_db) { }
    }

    public interface IUserService : IBaseBLL<UserInfo> { }
}
