using System;
using System.Collections.Generic;

namespace HangMan.GFX
{
    public static class Display
    {
        internal static void UpdateDisplay(string[] hiddenLetters, Player player)
        {
            Console.Clear();

            PlayerInfo(player);
            HowManyLivesLeft(player);
            PrintHiddenLetters(hiddenLetters);
            GuessedLetters();
        }

        public static void HowManyLivesLeft(Player player)
        {
            switch (player.lives)
            {
                case 10:
                    ASCII.TenLivesLeft();
                    break;
                case 9:
                    ASCII.NineLivesLeft();
                    break;
                case 8:
                    ASCII.EightLivesLeft();
                    break;
                case 7:
                    ASCII.SevenLivesLeft();
                    break;
                case 6:
                    ASCII.SixLivesLeft();
                    break;
                case 5:
                    ASCII.FiveLivesLeft();
                    break;
                case 4:
                    ASCII.FourLivesLeft();
                    break;
                case 3:
                    ASCII.ThreeLivesLeft();
                    break;
                case 2:
                    ASCII.TwoLivesLeft();
                    break;
                case 1:
                    ASCII.OneLifeLeft();
                    break;
                case 0:
                    ASCII.ZeroLivesLeft();
                    break;
            }
        }

        internal static void PrintHighScore()
        {
            string rawString = Lists.GetHighScore();
            string[] everyNewLine = Lists.SplitForEveryLine(rawString);
            List<Player> topTenPlayerHighScores = Lists.SplitAndSort(everyNewLine);

            PrintHighScoreList(topTenPlayerHighScores);
        }

        private static void PrintHighScoreList(List<Player> topTenPlayerHighScores)
        {
            Console.Title = "High Score";
            Console.Clear();
            Console.WriteLine("Top Ten Highscores!");
            Console.WriteLine("___________________\n");

            int ctr = 1;

            foreach (Player player in topTenPlayerHighScores)
            {
                Console.Write(ctr + ". ");
                Console.Write(player.name);
                Console.SetCursorPosition(22, Console.CursorTop);
                Console.WriteLine(player.score);
                ctr++;
            }

            Helpers.Colors.Grey("\n\nPress enter to go back to main menu");
            Helpers.Messages.PressEnterToContinue();
        }

        internal static void InitialUpdate(string[] hiddenLetters, Player player)
        {
            Console.Clear();
            PlayerInfo(player);
            HowManyLivesLeft(player);
            PrintHiddenLetters(hiddenLetters);
            Console.WriteLine("\n\n");
        }

        internal static void WinDisplay(Player player)
        {
            PlayerInfo(player);
            HowManyLivesLeft(player);
            Console.SetCursorPosition(18, Console.CursorTop);
            Helpers.Colors.Green("YOU WIN!");
            Helpers.Colors.Grey("\n\n____________________________________________\n");

            Console.WriteLine($"\n\nYour current score: " + player.score);
        }

        public static void LoseDisplay(Player player, string randomWord)
        {
            Console.WriteLine("");
            HowManyLivesLeft(player);
            Console.SetCursorPosition(18, Console.CursorTop);
            Helpers.Colors.Red("YOU LOSE");
            Helpers.Colors.Grey("\n\n____________________________________________\n");

            Console.WriteLine("\n\nYour total score was: " + player.score);
            Console.WriteLine("Secret word was: " + randomWord.ToUpper());
        }

        private static void PlayerInfo(Player player)
        {
            Helpers.Colors.Grey($"Player: {player.Name}\n" + $"Score: {player.score}");
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

        static void GuessedLetters()
        {
            Console.Write("  ");
            foreach (var letter in Lists.guessedLetters)
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
    }
}