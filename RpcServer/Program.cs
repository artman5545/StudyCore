using Abp;
using Abp.Grpc.Client.Utility;
using Consul;
using RpcClient.RpcServices;
using System;
namespace RpcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("启动客户端,是否调用接口？y/n");
            var result = Console.ReadKey();
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

        public static async void GetInfoAsync()
        {
            var userInfo = await MyClient.GetUserInfoAsync(1);
            Console.WriteLine(userInfo);
        }
        public static async void GetInfo2Async(AbpBootstrapper bootstrapper)
        {
            // 调用接口
            var connectionUtility = bootstrapper.IocManager.Resolve<IGrpcConnectionUtility>();
            var server = connectionUtility.GetRemoteServiceForDirectConnection<IMyService>("RpcWebApi");
            if (server != null)
            {
                var result = await server.GetUserInfo(1);
                //// 展示结果
                Console.WriteLine("Result:" + result);
            }

        }
    }
}
