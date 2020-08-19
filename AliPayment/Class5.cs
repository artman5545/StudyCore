using com.sun.org.apache.bcel.@internal.generic;
using java.awt;
using java.nio.file;
using sun.tools.tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliPayment
{
    public class Class5
    {
        public static void ReadFile()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 50; i++)
            {
                list.Add(i);
            }
            Console.WriteLine("beging main thread id=" + System.Threading.Thread.CurrentThread.ManagedThreadId);
            //await list.ForEachAsync(WriteDAsync);
            list.ForEach(async e =>
            {
                Console.WriteLine("foreach item thread id="
                    + System.Threading.Thread.CurrentThread.ManagedThreadId
                    + "--------- task thread id="
                    //System.Threading.Thread.CurrentThread.ManagedThreadId==
                    + (await Task.Run<int>(() =>
                    {
                        System.Threading.Thread.Sleep(new Random().Next(1, 10) * 100);
                        //Console.WriteLine("writed thread id=" + System.Threading.Thread.CurrentThread.ManagedThreadId);
                        Console.WriteLine("task item=" + e + " and thread id=" + System.Threading.Thread.CurrentThread.ManagedThreadId);
                        return System.Threading.Thread.CurrentThread.ManagedThreadId;
                    })
                    == System.Threading.Thread.CurrentThread.ManagedThreadId
                    )
                   );
            });

            Console.WriteLine("end main thread");
        }
    }
}
