using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    public static class Menus
    {
        public static void MainMenu()
        {
            Console.Title = "Main Menu";
            Console.Clear();

            Console.WriteLine("Main Menu");
            Console.WriteLine("_________\n");

            Console.WriteLine("1. Create Player");
            Console.WriteLine("2. High Score");

            ConsoleKeyInfo info;

            do
            {
                info = Console.ReadKey();

                switch (info.KeyChar.ToString())
                {
                    case "1":
                        Player player = Player.CreatePlayer();
                        PlayerMenu(player);
                        break;

                    case "2":
                        GFX.Display.PrintHighScore();
                        MainMenu();
                        break;

                    default:
                        Helpers.Messages.ErrorMessage("\nWrong input!");
                        break;
                }
            } while (info.Key != ConsoleKey.D1 && info.Key != ConsoleKey.D2);
        }

        public static void PlayerMenu(Player player)
        {
            Console.Title = "Player Menu";
            Console.Clear();

            Console.WriteLine($"Welcome {player.name}!");
            Console.WriteLine("______________________\n");
            Console.WriteLine($"Your score: {player.score}");
            Console.WriteLine("______________________\n");
            Console.WriteLine($"Your high score: \n");

            Helpers.Colors.Grey("\nPress enter to start game");

            GFX.Display.EnterToStart();

            Game.StartGame(player);
        }
    }
}
