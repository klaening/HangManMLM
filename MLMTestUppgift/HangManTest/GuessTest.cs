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
        public void GuessLetter_GivenLetter_ReturnsLetter()
        {
            // Assign
            string letter = "l";
            bool win = false;
            bool gameOver = false;

            // Act
            string answer = Guess.Letter(ref win, ref gameOver, letter);

            // Assert
            Assert.AreEqual(letter, answer);
        }
    }
}
