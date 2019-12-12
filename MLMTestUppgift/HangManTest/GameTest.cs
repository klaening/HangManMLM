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
            FakeRandom rnd = new FakeRandom();
            string letter = "a";
            string word = Lists.GetRandomWord(rnd); // returns word "according"
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
            FakeRandom rnd = new FakeRandom();
            string letter = "A";
            string word = Lists.GetRandomWord(rnd); // returns word "according"
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
            FakeRandom rnd = new FakeRandom();
            string letter = "K";
            string word = Lists.GetRandomWord(rnd); // returns word "according"
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
            FakeRandom rnd = new FakeRandom();
            string letter = "5";
            string word = Lists.GetRandomWord(rnd); // returns word "according"
            Player player = new Player();

            // Act
            bool answer = Game.RightOrWrongGuess(letter, word, player);

            // Assert
            Assert.IsFalse(answer);
        }

        #endregion

        #region GetRandomWordTest

        [Test]
        public void GetRandomWord_RandomReturns5_ReturnsAccording()
        {
            // Arrange
            FakeRandom rnd = new FakeRandom();
            string returnWord = "ACCORDING";

            // Act
            string answer = Lists.GetRandomWord(rnd);

            // Assert
            Assert.AreEqual(returnWord, answer);
        }

        #endregion
    }
}
