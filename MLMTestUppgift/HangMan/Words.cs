using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HangMan
{
    public class Words
    {
        public static string GetRandomWord()
        {
            string randomWord = string.Empty;
            string[] wordArray = File.ReadAllLines("Words.txt");

            Random rnd = new Random();
            int word = rnd.Next(0, wordArray.Length);

            for (int i = 0; i <= wordArray.Length; i++)
            {
                if (word == i)
                {
                    randomWord = wordArray[i];
                }
            }
            return randomWord;
        }
    }
}
