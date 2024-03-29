﻿using System;
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
        static Regex validCharacters = new Regex("^[a-zA-Z0-9]+$");

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

            Player player = new Player();
            bool validName;

            do
            {
                string name = Console.ReadLine();

                validName = CheckName(name);

                if (!validName)
                {
                    Helpers.Messages.ErrorMessage("Invalid name");
                }
                else
                {
                    player.name = name;
                }
            } while (!validName);

            player.score = 0;

            Helpers.Colors.Green("\n~*Player created!*~\n");
            System.Threading.Thread.Sleep(800);

            return player;
        }

        public static bool CheckName(string name)
        {
            if (!validCharacters.IsMatch(name) || name.Length > 10)
            {
                return false;
            }

            return true;
        }

        public Player()
        {

        }

        public Player(string aName, int aScore)
        {
            name = aName;
            score = aScore;
        }
    }
}
