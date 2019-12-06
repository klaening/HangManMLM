using System;
using System.Collections.Generic;

namespace HangMan
{
    public class Graphics
    {
        internal static void LetterContainers(string randomWord)
        {

        }

        internal static void UpdateConsole(string indexPlaces, string letter, string randomWord)
        {
            
        }

        internal static void UpdateDisplay(List<char> letters)
        {
            Console.Clear();
            TenLivesLeft();
            GuessedLetters(letters);
        }

        static void GuessedLetters(List<char> letters)
        {
            foreach (var letter in letters)
            {
                Console.Write(letter + "  ");
            }
            Console.WriteLine();
        }

        public static void EnterToStart()
        {
            ConsoleKeyInfo info = new ConsoleKeyInfo();

            do
            {
                info = Console.ReadKey();
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(" ");
                Console.SetCursorPosition(0, Console.CursorTop);
            } while (info.Key != ConsoleKey.Enter);
        }

        static void TenLivesLeft()
        {
            Console.WriteLine(@"






");
        }
        static void NineLivesLeft()
        {
            Console.WriteLine(@"






");
        }

    }
}