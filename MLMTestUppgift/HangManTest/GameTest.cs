using System;
using System.Collections.Generic;
using System.Text;
using HangMan;
using NUnit.Framework;

namespace HangManTest
{
    public class GameTest
    {
        [Test]
        public void RightOrWrongGuess_GivenRightLetterLowerCase_ReturnsFalse()
        {
            // Assign
            string letter = "l";
            string word = "POLICY";
            Player player = new Player();

            // Act
            bool answer = Game.RightOrWrongGuess(letter, word, player);

            // Assert
            Assert.IsFalse(answer);
        }

        [Test]
        public void RightOrWrongGuess_GivenRightLetterUpperCase_ReturnsTrue()
        {
            // Assign
            string letter = "L";
            string word = "POLICY";
            Player player = new Player();

            // Act
            bool answer = Game.RightOrWrongGuess(letter, word, player);

            // Assert
            Assert.IsTrue(answer);
        }

        [Test]
        public void RightOrWrongGuess_GivenWrongLetterUpperCase_ReturnsFalse()
        {
            // Assign
            string letter = "K";
            string word = "POLICY";
            Player player = new Player();

            // Act
            bool answer = Game.RightOrWrongGuess(letter, word, player);

            // Assert
            Assert.IsFalse(answer);
        }

        [Test]
        public void RightOrWrongGuess_GivenNumber_ReturnsFalse()
        {
            // Assign
            string letter = "5";
            string word = "POLICY";
            Player player = new Player();

            // Act
            bool answer = Game.RightOrWrongGuess(letter, word, player);

            // Assert
            Assert.IsFalse(answer);
        }
    }
}
