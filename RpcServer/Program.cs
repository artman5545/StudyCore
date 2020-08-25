using Abp;
using Abp.Grpc.Client.Utility;
using Consul;
using RpcClient.RpcServices;
using System;
using System.Linq;
namespace RpcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("启动客户端,是否调用接口？y/n");
            var result = Console.ReadKey();
            //ConsulClient client = new ConsulClient(c =>
            //  {
            //      c.Address = new Uri("http://127.0.0.1:8500/");
            //      c.Datacenter = "dc1";
            //  });
            //var response = client.Agent.Services().Result.Response;
            //Uri uri = new Uri("http://RpcWebApi/GetUserInfo");
            //string groupName = uri.Host;
            //AgentService agentService = null;
            //var serviceDictionary = response.Where(e => e.Value.Service.Equals(groupName, StringComparison.OrdinalIgnoreCase)).ToArray();
            //{
            //    agentService = serviceDictionary[0].Value;
            //}
            //string url = $"{uri.Scheme}://{agentService.Address}:{agentService.Port}{uri.PathAndQuery}";
            //Console.WriteLine(url);
            //var user = MyClient.GetUserInfoAsync(new Random().Next(), agentService.Address, agentService.Port).Result;
            //Console.WriteLine(user.UserName);
            using (var bootstrapper = AbpBootstrapper.Create<AbpGrpcClientDemoModule>())
            {
                bootstrapper.Initialize();
                while (result.KeyChar == 'y')
                {
                    GetInfo2Async(bootstrapper);
                    Console.WriteLine("是否继续调用？y/n");
                    result = Console.ReadKey();
                }
            }
            Console.ReadLine();
        }

        //public static async void GetInfoAsync()
        //{
        //    var userInfo = await MyClient.GetUserInfoAsync(1);
        //    Console.WriteLine(userInfo);
        //}
        public static async void GetInfo2Async(AbpBootstrapper bootstrapper)
        {
            // 调用接口
            var connectionUtility = bootstrapper.IocManager.Resolve<IGrpcConnectionUtility>();
            var server = connectionUtility.GetRemoteServiceForDirectConnection<IMyService>("RpcWebApi");
            if (server != null)
            {
                var result = await server.GetUserInfo(1);
                //// 展示结果
                Console.WriteLine("Result:" + result.UserName);
            }

        }
    }
}
