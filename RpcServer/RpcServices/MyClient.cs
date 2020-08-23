using Grpc.Core;
using MagicOnion.Client;
using RpcClient.Mapping;
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
        public static async Task<MUserInfo> GetUserInfoAsync(int id,string url,int port)
        {
            try
            {
                var channel = new Channel(url, port, ChannelCredentials.Insecure);
                Console.WriteLine("开始连接服务器...");
                await channel.ConnectAsync();
                Console.WriteLine("连接成功！开始获取数据");

                var client = MagicOnionClient.Create<IMyService>(channel);
                var result = client.GetUserInfo(id).ResponseAsync.Result;
                await channel.ShutdownAsync();

                return result;

            }
            catch (Exception ex)
            {
                return new MUserInfo { UserName = ex.Message };
            }
        }
    }
}
