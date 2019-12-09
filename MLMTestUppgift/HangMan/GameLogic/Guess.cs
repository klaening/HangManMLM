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
            //tar in key som checkar om det är enter och isf returnera senaste bokstaven

            Regex validCharacters = new Regex("^[a-zA-Z]$");

            //ConsoleKeyInfo info;
            //string letter = string.Empty;

            Console.Write("\b");

            if (key != ConsoleKey.Enter)
            {
                letter = key.ToString();
            }
            else if (key == ConsoleKey.Enter)
            {
                //Stoppa detta i en egen metod? Förslag: CheckLetter(letter)
                //Skapa isf RegEx i den metoden
                //Gör koden mer läsbar också med att vi kommer ha mer kod i else senare
                if (!validCharacters.IsMatch(letter))
                {
                    Console.WriteLine();
                    Helpers.Messages.ErrorMessage("Invalid character!");

                    letter = string.Empty;
                }
                else
                {
                    //TO DO: Kod som kollar om bokstaven redan finns i listan
                    Lists.guessedLetters.Add(Convert.ToChar(letter.ToLower()));
                    //TO DO: Felmeddelande
                    //TO DO: Sätt letter till string.Empty
                }
                //
            }
            //else if (info.Key == ConsoleKey.Escape)
            //{
            //// Kanske implementera möjligheten att få en bokstav men offrar ett liv för det
            //    letter = "esc";
            //    Console.SetCursorPosition(0, Console.CursorTop);

            //    if (Guess.Word(word))
            //        win = true;
            //    else
            //        win = false;
            //}

            return letter;
        }
    }
}
