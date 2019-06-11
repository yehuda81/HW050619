using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW050619_10
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
        public static string GetTime()
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
            
            return _instance.timeIL;
        }
    }
}
