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
        string name;
        int score;
        //Säger att den ska ha ett start och ett slut alltså ett ord och inte bara att den innehåller nån av karaktärerna. + indikerar att man kan ha
        //flera karaktärer
        private Regex validCharacters = new Regex("^[a-zA-Z0-9]+$");

        public string Name { get; set; }

        public int Score { get; set; }

        public static void CreatePlayer(ref Player player)
        {
            Console.WriteLine("\nName may contain letters and numbers\n");

            do
            {
                Console.Write("Enter player name: ");
                string name = Console.ReadLine();

                player = SetName(name);
                player.score = 0;

                if (player.name == null)
                {
                    Console.WriteLine("Invalid player name\n");
                }
            } while (player.name == null);

            Console.Clear();

            Console.WriteLine("Player created!\n");
            Console.WriteLine($"Player name: {player.name}");

            Console.WriteLine("\nPress enter to start game");

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

        public Player(string aName)
        {
            name = aName;
        }

        public Player(string aName, int aScore)
        {
            name = aName;
            score = aScore;
        }
    }
}
