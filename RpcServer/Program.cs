using RpcServer.Common;
using System;
using System.Threading.Tasks;
namespace RpcServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("启动客户端,是否调用接口？y/n");
            var result = Console.ReadKey();
            while (result.KeyChar=='y')
            {
                GetInfoAsync();
                Console.WriteLine("是否继续调用？y/n");
                result = Console.ReadKey();
            }
            Console.ReadLine();
        }

        public static async void GetInfoAsync()
        {
            var userInfo = await MyClient.GetUserInfoAsync(1);
            Console.WriteLine(userInfo.UserName);
        }
    }
}
