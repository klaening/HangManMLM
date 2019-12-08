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
            for (int i = 0; i <= message.Length; i++)
            {
                Console.Write(" ");
            }

            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write("                         ");

            Console.SetCursorPosition(0, Console.CursorTop);
        }

        public static void PlayerNameInfoMessage(string message)
        {
            Colors.Grey(message);
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.ReadKey();

            Console.SetCursorPosition(0, Console.CursorTop);
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(" ");
            }

            Console.SetCursorPosition(0, Console.CursorTop);
        }
    }
}
