using System;
using System.Collections.Generic;

namespace HangMan
{
    public static class Graphics
    {
        internal static void UpdateDisplay(List<char> letters, string[] hiddenLetters)
        {
            Console.Clear();
            TenLivesLeft();
            PrintHiddenLetters(hiddenLetters);
            GuessedLetters(letters);
        }

        internal static void InitialUpdate(string[] hiddenLetters)
        {
            Console.Clear();
            TenLivesLeft();
            PrintHiddenLetters(hiddenLetters);
            Console.WriteLine("\n\n____________________");
        }

        public static void ChangeHiddenLetters(ref string[] hiddenLetters, string indexPlaces, string letter)
        {
            string[] indexString = indexPlaces.Split(',');
            int[] indexInt = new int[indexString.Length];

            if (indexPlaces != "")
            {
                for (int i = 0; i < indexInt.Length; i++)
                {
                    indexInt[i] = int.Parse(indexString[i]);
                }

                for (int i = 0; i < hiddenLetters.Length; i++)
                {
                    for (int j = 0; j < indexInt.Length; j++)
                    {
                        if (i == indexInt[j])
                        {
                            hiddenLetters[i] = letter;
                            UpdateDisplay(Lists.guessedLetters, hiddenLetters);
                        }
                    }
                }
            }
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








      ____________________________
   __/                            \__
__/                                  \__
");
        }
        static void EightLivesLeft()
        {
            Console.WriteLine(@"
              __
             |  |       
             |  |       
             |  |       
             |  |       
             |  |       
             |  |       
             |  |       
      _______|__|_________________
   __/                            \__
__/                                  \__
");
        }
        static void ZeroLivesLeft()
        {
            Console.WriteLine(@"
              __ ________
             |  |________| 
             |  | //    |
             |  |//     |
             |  |/      Q
             |  |      /[]\
             |  |       /\             
             |  |       
      _______|__|_________________
   __/                            \__
__/                                  \__
");
        }
    }
}