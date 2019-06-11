using System;

namespace HW0506_09
{
    class IsraelTime
    {
        private static IsraelTime _instance;
        string timeIL;
        private static object key = new object();
        private IsraelTime()
        {
            timeIL = DateTime.Now.ToString();
        }
        public static void GetTime()
        {
            if (_instance == null)
            {
                lock (key)
                {
                    if (_instance == null)
                    {
                        _instance = new IsraelTime();
                    }
                }
            }
            Console.WriteLine($"Time in Israel is {_instance.timeIL}");           
        }

    }
}