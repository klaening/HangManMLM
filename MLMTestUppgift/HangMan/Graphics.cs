using System;

namespace HangMan
{
    public class Graphics
    {
        internal static void LetterContainers(string randomWord)
        {
            for (int i = 0; i < randomWord.Length; i++)
            {
                Console.Write("--  ");
            }

            Console.WriteLine();
        }
    }
}