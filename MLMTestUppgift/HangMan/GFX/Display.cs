using System;
using System.Collections.Generic;

namespace HangMan.GFX
{
    public static class Display
    {
        internal static void UpdateDisplay(List<char> letters, string[] hiddenLetters, Player player)
        {
            Console.Clear();

            Helpers.Colors.Grey($"Player: {player.Name}\n" +
                $"Points: {player.score}");

            switch (player.lives)
            {
                case 10:
                    GFX.ASCII.TenLivesLeft();
                    break;
                case 9:
                    GFX.ASCII.NineLivesLeft();
                    break;
                case 8:
                    GFX.ASCII.EightLivesLeft();
                    break;
                case 7:
                    GFX.ASCII.SevenLivesLeft();
                    break;
                case 6:
                    GFX.ASCII.SixLivesLeft();
                    break;
                case 5:
                    GFX.ASCII.FiveLivesLeft();
                    break;
                case 4:
                    GFX.ASCII.FourLivesLeft();
                    break;
                case 3:
                    GFX.ASCII.ThreeLivesLeft();
                    break;
                case 2:
                    GFX.ASCII.TwoLivesLeft();
                    break;
                case 1:
                    GFX.ASCII.OneLifeLeft();
                    break;
                case 0:
                    GFX.ASCII.ZeroLivesLeft();
                    break;
            }
            PrintHiddenLetters(hiddenLetters);
            GuessedLetters(letters);
        }

        internal static void InitialUpdate(string[] hiddenLetters, Player player)
        {
            Console.Clear();
            Helpers.Colors.Grey($"Player: {player.Name}\n" +
                $"Points: {player.score}");
            GFX.ASCII.TenLivesLeft();
            PrintHiddenLetters(hiddenLetters);
            Console.WriteLine("\n\n");
        }

        public static void ChangeHiddenLetters(ref string[] hiddenLetters, string indexPlaces, string letter, Player player)
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
                            UpdateDisplay(Lists.guessedLetters, hiddenLetters, player);
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