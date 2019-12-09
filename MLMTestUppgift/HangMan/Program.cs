using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();

            GFX.ASCII.WelcomeScreen();

            Game.StartGame(player);
        }
    }
}
