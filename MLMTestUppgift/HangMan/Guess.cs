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

            Console.WriteLine("Choose a letter to guess");

            do
            {
                Console.Write("\b");

                info = Console.ReadKey();

                if (info.Key != ConsoleKey.Enter && info.Key != ConsoleKey.Escape)
                {
                    letter = info.KeyChar.ToString();
                }
                else if (info.Key == ConsoleKey.Enter)
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
                        Lists.guessedLetters.Add(Convert.ToChar(letter));
                        //TO DO: Felmeddelande
                        //TO DO: Sätt letter till string.Empty
                    }
                    //
                }
                else if (info.Key == ConsoleKey.Escape)
                {
                    letter = "esc";
                    Console.SetCursorPosition(0, Console.CursorTop);

                    if (Guess.Word(ref gameOver, word))
                        win = true;
                    else
                        win = false;
                }

            } while (info.Key != ConsoleKey.Enter && info.Key != ConsoleKey.Escape || letter == string.Empty);

            return letter;
        }

        private static bool Word(ref bool gameOver, string word)
        {
            //Tänka om med det här?
            Console.Write("Take a guess: ");
            string guess = Console.ReadLine();

            gameOver = true;

            return guess.ToLower() == word.ToLower();
        }
    }
}
