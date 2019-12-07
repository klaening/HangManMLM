using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan.Helpers
{
    public static class Colors
    {
        public static void Grey(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(text);
            Console.ResetColor();
        }
        public static void Red(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(text);
            Console.ResetColor();
        }
        public static void Green(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
