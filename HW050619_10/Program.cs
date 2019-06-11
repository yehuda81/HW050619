using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW050619_10
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine($"Time in Israel is {IsraelTime.GetTime()}");            
            AsyncPrinter async = new AsyncPrinter();
            for (int i = 0; i < 10; i++)
            {
                new Thread(() => async.CheckPrintMessage()).Start();
            }
            for (int i = 0; i < 100; i++)
            {                
                async.AddMessage(IsraelTime.GetTime());
                Thread.Sleep(100);
            } 
        }
    }
}
