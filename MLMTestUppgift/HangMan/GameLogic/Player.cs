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
        public int lives = 10;
        //Säger att den ska ha ett start och ett slut alltså ett ord och inte bara att den innehåller nån av karaktärerna. + indikerar att man kan ha
        //flera karaktärer
        private Regex validCharacters = new Regex("^[a-zA-Z0-9]+$");

        public string Name 
        {
            get 
            {
                return name;
            }
            set 
            {
                Name = name;
            } 
        }

        public int Score { get; set; }

        public static Player CreatePlayer()
        {
            //Namn får inte vara för långt
            
            Console.Title = "Create Player";
            Console.Clear();

            Console.WriteLine("[Create Player]\n");
            Console.WriteLine("Enter player name");
            Helpers.Messages.PlayerNameInfoMessage("[Name may contain letters and numbers]");

            Player player;

            do
            {
                string name = Console.ReadLine();

                player = SetName(name);

                if (player.name == null)
                {
                    Helpers.Messages.ErrorMessage("Invalid name");
                }
            } while (player.name == null);

            player.score = 0;

            Helpers.Colors.Green("\n~*Player created!*~\n");
            System.Threading.Thread.Sleep(800);

            return player;
        }

        public static Player SetName(string name)
        {
            Player player = new Player();

            //Namn får inte vara hur långt som helst. 10 karaktärer kanske?
            if (player.validCharacters.IsMatch(name))
            {
                player.name = name;
            }

            return player;
        }

        public Player()
        {

        }
    }
}
