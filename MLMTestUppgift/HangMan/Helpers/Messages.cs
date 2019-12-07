using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan.Helpers
{
    public static class Messages
    {
        public static void ErrorMessage(string message)
        {
            Colors.Red(message);
            System.Threading.Thread.Sleep(400);

            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write("                         ");
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write("                         ");
            Console.SetCursorPosition(0, Console.CursorTop);
        }

        public static void PlayerNameInfoMessage()
        {
            Colors.Grey("[Name may contain letters and numbers]");
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.ReadKey();
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write("                                       ");
            Console.SetCursorPosition(0, Console.CursorTop);
        }
    }
}
