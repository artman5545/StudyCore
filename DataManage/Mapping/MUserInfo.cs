using System;
using System.Collections.Generic;
using System.Text;
using DataManage.Models;
using MessagePack;

namespace DataManage.Mapping
{
    /// <summary>
    /// 
    /// </summary>
    [MessagePackObject(true)]
    public class MUserInfo:UserInfo
    {
    }
}
