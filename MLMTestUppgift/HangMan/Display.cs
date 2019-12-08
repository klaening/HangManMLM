using System;
using System.Collections.Generic;

namespace HangMan
{
    public static class Display
    {
        internal static void UpdateDisplay(List<char> letters, string[] hiddenLetters)
        {
            Console.Clear();
            //TO DO: switch case för olika metoder eller ha det i en egen metod? Isf måste UpdateDisplay ta in player som argument.
            GFX.ASCII.ZeroLivesLeft();
            PrintHiddenLetters(hiddenLetters);
            GuessedLetters(letters);
        }

        internal static void InitialUpdate(string[] hiddenLetters)
        {
            Console.Clear();
            GFX.ASCII.TenLivesLeft();
            PrintHiddenLetters(hiddenLetters);
            Console.WriteLine("\n\n");
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
            StartPrintingFrom(hiddenLetters);

            foreach (var letter in hiddenLetters)
            {
                Console.Write(letter + "  ");
            }
            Helpers.Colors.Grey("\n\n____________________________________________\n");
        }

        static void GuessedLetters(List<char> letters)
        {
            Console.Write("  ");
            foreach (var letter in letters)
            {
                Console.Write(letter + "  ");
            }
            Console.WriteLine("\n\n");
        }

        public static void StartPrintingFrom(string[] word)
        {
            Console.SetCursorPosition(21, Console.CursorTop);

            int ctr = 0;

            foreach (var letter in word)
            {
                Console.Write("\b");
                ctr++;

                if (word.Length > 5 && ctr % 3 == 0)
                {
                    Console.Write("\b");
                }
            }

            if (word.Length >= 14)
            {
                Console.Write("\b");
            }
        }

        public static void EnterToStart()
        {
            ConsoleKeyInfo info;

            do
            {
                info = Console.ReadKey();
                Console.Write("\b \b");

            } while (info.Key != ConsoleKey.Enter);
        }
    }
}