using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HangMan
{
    public class Player
    {
        public string name;
        public int score;
        //Säger att den ska ha ett start och ett slut alltså ett ord och inte bara att den innehåller nån av karaktärerna. + indikerar att man kan ha
        //flera karaktärer
        private Regex validCharacters = new Regex("^[a-zA-Z0-9]+$");

        public string Name { get; set; }

        public int Score { get; set; }

        public static void CreatePlayer(ref Player player)
        {
            Console.WriteLine("[Create Player]\n");

            Console.WriteLine("Enter player name");

            Helpers.Messages.PlayerNameInfoMessage();

            do
            {
                string name = Console.ReadLine();

                player = SetName(name);
                player.score = 0;

                if (player.name == null)
                {
                    Helpers.Messages.ErrorMessage("Invalid name");
                }
            } while (player.name == null);

            Helpers.Colors.Green("\n~*Player created!*~\n");
            System.Threading.Thread.Sleep(800);
            Console.Clear();

            Console.WriteLine($"Welcome {player.name}!");
            Console.WriteLine($"Your score: {player.score}");


            Helpers.Colors.Grey("\nPress enter to start game");

            Graphics.EnterToStart();
        }

        public static Player SetName(string name)
        {
            Player player = new Player();

            if (player.validCharacters.IsMatch(name))
            {
                player.name = name;
            }

            return player;
        }

        public Player()
        {

        }

        //public Player(string aName)
        //{
        //    name = aName;
        //}

        //public Player(string aName, int aScore)
        //{
        //    name = aName;
        //    score = aScore;
        //}
    }
}
