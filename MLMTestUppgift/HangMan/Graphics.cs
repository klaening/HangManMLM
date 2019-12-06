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

        internal static void UpdateDisplay(List<char> letters, string[] hiddenLetters)
        {
            Console.Clear();
            TenLivesLeft();
            PrintHiddenLetters(hiddenLetters);
            GuessedLetters(letters);
            ChangeHiddenLetters();
        }

        private static void PrintHiddenLetters(string[] hiddenLetters)
        {
            Console.Write("  ");
            foreach (var letter in hiddenLetters)
            {
                Console.Write(letter + "  ");
            }
            Console.WriteLine("\n\n____________________");

        }

        static void GuessedLetters(List<char> letters)
        {
            foreach (var letter in letters)
            {
                Console.Write(letter + "  ");
            }
            Console.WriteLine("\n\n");
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