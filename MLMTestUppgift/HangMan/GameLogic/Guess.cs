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

        public static ConsoleKeyInfo GuessLetter()
        {
            Console.Write("\b");

            ConsoleKeyInfo info = Console.ReadKey();

            return info;
        }

        public static string ValidateLetter(ConsoleKeyInfo key, ref string letter)
        {
            Console.Write("\b");

            if (key.Key != ConsoleKey.Enter)
            {
                letter = key.KeyChar.ToString().ToLower();
            }
            else
            {
                try
                {
                    letter = CheckLetter(letter);
                }
                catch
                {
                    Helpers.Messages.ErrorMessage("\nInvalid character!");
                    letter = string.Empty;
                }
            }

            return letter;
        }

        public static string CheckLetter(string letter)
        {
            Regex validCharacters = new Regex("^[a-zA-Z]$");

            if (!validCharacters.IsMatch(letter))
            {
                throw new Exception();
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
                Lists.guessedLetters.Add(Convert.ToChar(letter));
            }

            return letter;
        }
    }
}
