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

        public static ConsoleKey GuessLetter()
        {
            //Funktionen ska returera en key som vi gissat på

            ConsoleKeyInfo info;

            Console.Write("\b");

            info = Console.ReadKey();
            ConsoleKey key = info.Key;

            return key;
        }

        public static string ValidateLetter(ConsoleKey key, ref string letter)
        {
            Console.Write("\b");

            if (key != ConsoleKey.Enter)
            {
                letter = key.ToString().ToLower();
            }
            else
            {
                letter = CheckLetter(letter);
            }

            return letter;
        }

        private static string CheckLetter(string letter)
        {
            Regex validCharacters = new Regex("^[a-zA-Z]$");

            if (!validCharacters.IsMatch(letter))
            {
                Console.WriteLine();
                Helpers.Messages.ErrorMessage("Invalid character!");

                letter = string.Empty;
            }
            else
            {
                letter = CheckIfLetterIsGuessed(letter);
            }

            return letter;
        }

        private static string CheckIfLetterIsGuessed(string letter)
        {
            if (Lists.guessedLetters.Contains(Convert.ToChar(letter)))
            {
                Helpers.Messages.ErrorMessage("\nLetter already guessed!");
                letter = string.Empty;
            }
            else
            {
                //Om den finns med i ordet addera inte
                Lists.guessedLetters.Add(Convert.ToChar(letter));
            }

            return letter;
        }
    }
}
