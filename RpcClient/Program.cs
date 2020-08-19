using Grpc.Core;
using MagicOnion.Server;
using System;

namespace RpcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("RPC服务端已启动。。。");

            var service = MagicOnionEngine.BuildServerServiceDefinition(isReturnExceptionStackTraceInErrorDetail: true);
            var server = new global::Grpc.Core.Server
            {
                Services = { service },
                Ports = { new ServerPort("localhost", 19021, ServerCredentials.Insecure) }
            };

            server.Start();

            Console.ReadLine();
        }
    }
}
