using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    public class Lists
    {
        public static List<char> guessedLetters = new List<char>();

        public static string[] CreateHiddenWordArray(string word)
        {
            string[] hiddenWord = new string[word.Length];
            for (int i = 0; i < hiddenWord.Length; i++)
            {
                hiddenWord[i] = "_";
            }
            return hiddenWord;
        }
    }
}
