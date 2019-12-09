using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using HangMan;

namespace HangManTest
{
    public class GuessTest
    {
        [Test]
        public void ValidateLetter_GivenLetter_ReturnsLetter()
        {
            // Assign
            ConsoleKey key = ConsoleKey.Enter;
            string letter = "l";

            // Act
            string answer = Guess.ValidateLetter(key, ref letter);

            // Assert
            Assert.AreEqual(letter, answer);
        }

        //[Test]
        //public void ValidateLetter_GivenLetterOutOfRegex_ReturnsEmptyString()
        //{
        //    // Assign
        //    ConsoleKey key = ConsoleKey.Enter;
        //    string letter = "å";

        //    // Act
        //    string answer = Guess.ValidateLetter(key, ref letter);

        //    // Assert
        //    Assert.AreEqual("", answer);
        ////}

        //[Test]
        //public void ValidateLetter_GivenNumber_ReturnsEmptyString()
        //{
        //    // Assign
        //    ConsoleKey key = ConsoleKey.Enter;
        //    string letter = "5";

        //    // Act
        //    string answer = Guess.ValidateLetter(key, ref letter);

        //    // Assert
        //    Assert.AreEqual("", answer);
        ////}

        //[Test]
        //public void ValidateLetter_GivenWhiteSpace_ReturnsEmptyString()
        //{
        //    // Assign
        //    ConsoleKey key = ConsoleKey.Enter;
        //    string letter = " ";

        //    // Act
        //    string answer = Guess.ValidateLetter(key, ref letter);

        //    // Assert
        //    Assert.AreEqual("", answer);
        //}
    }
}
