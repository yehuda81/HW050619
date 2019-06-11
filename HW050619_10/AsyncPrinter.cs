using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW050619_10
{
    class AsyncPrinter
    {
        Queue<string> ts = new Queue<string>();
        object key = new object();
        int index = 0;
        public void AddMessage(string Message)
        {
            lock(key)
            {
                ts.Enqueue(Message);
                Monitor.Pulse(key);
                new Thread(() => CheckPrintMessage()).Start();
            }
        }
        public void CheckPrintMessage()
        {
            lock(key)
            {
                if (ts.Count > 0)
                {
                    Console.WriteLine(ts.Dequeue());
                }
                else
                {
                    Monitor.Wait(key);
                    Console.WriteLine(ts.Dequeue());
                }
                index++;
                if (index == 100)
                {
                    Console.WriteLine("thread ninja!");
                }
            }
        }
    }
   
}
