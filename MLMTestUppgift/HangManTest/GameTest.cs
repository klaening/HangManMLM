using System;
using System.Collections.Generic;
using System.Text;
using HangMan;
using NUnit.Framework;

namespace HangManTest
{
    public class GameTest
    {
        #region RightOrWrongGuessTest

        [Test]
        public void RightOrWrongGuess_GivenRightLetterLowerCase_ReturnsFalse()
        {
            // Arrange
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
            // Arrange
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
            // Arrange
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
            // Arrange
            string letter = "5";
            string word = "POLICY";
            Player player = new Player();

            // Act
            bool answer = Game.RightOrWrongGuess(letter, word, player);

            // Assert
            Assert.IsFalse(answer);
        }

        #endregion


    }
}
