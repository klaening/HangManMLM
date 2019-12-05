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

        public static void CreatePlayer(Player player)
        {
            Console.Write("Enter player name: ");
            string name = Console.ReadLine();

            player = SetName(name);
            player.score = 0;
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
