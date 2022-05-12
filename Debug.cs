using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRogueLife
{
    internal static class Debug
    {
        public static void Div()
        {
            if (!Globle.isDebug)
                return;
            System.Diagnostics.Debug.WriteLine("--------------------");
        }
        //输出调试信息，默认info
        public static void Print(string message,int type = 0)
        {
            if(!Globle.isDebug)
                return;
            string prefix = type switch
            {
                0 => "[Info]",
                1 => "[Error]",
                2 => "[Warning]",
                _ => "[Info]",
            };
            System.Diagnostics.Debug.WriteLine(DateTime.Now.ToLongTimeString() + " " + message,prefix);
        }
    }
}
