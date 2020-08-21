using DataManage.Mapping;
using Grpc.Core;
using MagicOnion.Client;
using System;
using System.Threading.Tasks;

namespace RpcClient.RpcServices
{
    /// <summary>
    /// 111
    /// </summary>
    public class MyClient
    {
        /// <summary>
        /// 1111
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<MUserInfo> GetUserInfoAsync(int id)
        {
            try
            {
                var channel = new Channel("localhost", 8500, ChannelCredentials.Insecure);
                Console.WriteLine("开始连接服务器...");
                await channel.ConnectAsync();
                Console.WriteLine("连接成功！开始获取数据");

                var client = MagicOnionClient.Create<IMyService>(channel);
                var result = client.GetUserInfo(id);
                await channel.ShutdownAsync();

                return await result;

            }
            catch (Exception ex)
            {
                return new MUserInfo { UserName = ex.Message };
            }
        }
    }
}
