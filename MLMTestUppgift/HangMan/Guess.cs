using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HangMan
{
    public class Guess
    {
        public static string Letter(ref bool win, ref bool gameOver, string word)
        {
            Regex validCharacters = new Regex("^[a-zA-Z]$");

            ConsoleKeyInfo info;
            string letter = string.Empty;

            Graphics.UpdateDisplay(Lists.guessedLetters);

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
                        Console.WriteLine("Error, invalid character!");
                        //TO DO: set cursor ta bort error meddelande. sen en till set cursor en rad upp.

                        Console.ReadKey();
                        Console.SetCursorPosition(0, Console.CursorTop);
                        Console.WriteLine(" ");
                        Console.SetCursorPosition(0, Console.CursorTop - 2);
                        Console.WriteLine("                         ");
                        Console.SetCursorPosition(0, Console.CursorTop - 2);

                        letter = string.Empty;
                    }
                    else
                    {                        
                        Lists.guessedLetters.Add(Convert.ToChar(letter));
                    }
                }
                else if (info.Key == ConsoleKey.Escape)
                {
                    letter = "esc";
                    if (Word(ref gameOver, word))
                        win = true;
                    else
                        win = false;
                }

            } while (info.Key != ConsoleKey.Enter && info.Key != ConsoleKey.Escape || letter == string.Empty);

            return letter;
        }

        private static bool Word(ref bool gameOver, string word)
        {
            Console.Write("Take a guess: ");
            string guess = Console.ReadLine();

            gameOver = true;

            return guess.ToLower() == word.ToLower();
        }
    }
}
