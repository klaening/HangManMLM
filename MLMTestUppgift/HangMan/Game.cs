using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HangMan
{
    class Game
    {
        public static void StartGame()
        {
            Player player = new Player();

            Console.WriteLine("Welcome to Hang Man!");

            Player.CreatePlayer(ref player);

            string randomWord = GetWord();

            Graphics.LetterContainers(randomWord);
            GuessLetter();
        }

        private static string GuessLetter()
        {
            Regex validCharacters = new Regex("^[a-zA-Z]$");

            ConsoleKeyInfo info;
            string letter = string.Empty;

            Console.WriteLine("Choose a letter to guess");

            do
            {
                Console.SetCursorPosition(0, Console.CursorTop);

                info = Console.ReadKey();

                if (info.Key != ConsoleKey.Enter && info.Key != ConsoleKey.Escape)
                {
                    letter = info.KeyChar.ToString();
                }
                else if (info.Key == ConsoleKey.Enter)
                {
                    if (!validCharacters.IsMatch(letter))
                    {
                        Console.WriteLine();
                        Console.SetCursorPosition(0, Console.CursorTop);
                        Console.WriteLine("Error, invalid character!");
                        //TO DO: set cursor ta bort error meddelande. sen en till set cursor en rad upp.

                        letter = string.Empty;
                    }
                }
                else if (info.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Exiting game");
                    System.Threading.Thread.Sleep(600);
                    Environment.Exit(0);
                }
                
            } while (info.Key != ConsoleKey.Enter && info.Key != ConsoleKey.Escape || letter == string.Empty);


            return letter;
        }
    }
}
