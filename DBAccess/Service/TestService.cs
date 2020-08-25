using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBAccess.Service
{
    public interface ITestService
    {
        int GetO(int i);
    }
    public class TestService : ITestService, ITransientDependency
    {
        public int GetO(int i)
        {
            return i + new Random().Next(10);
        }
    }
}
