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

        #region ReturnIndexPlace

        [Test]
        public void ReturnIndexPlace_GivenLowerCaseLetterInUpperCaseWord_ReturnsIndexPlace()
        {
            // Arrange
            string letter = "o";
            string word = "WORD";

            // Act
            string indexPlaces = Game.ReturnIndexPlace(letter, word);

            // Assert
            Assert.AreEqual("1", indexPlaces);
        }

        [Test]
        public void ReturnIndexPlace_GivenUpperCaseLetterInUpperCaseWord_ReturnsIndexPlace()
        {
            // Arrange
            string letter = "O";
            string word = "WORD";

            // Act
            string indexPlaces = Game.ReturnIndexPlace(letter, word);

            // Assert
            Assert.AreEqual("1", indexPlaces);
        }

        [Test]
        public void ReturnIndexPlace_GivenLowerCaseLetterInLowerCaseWord_ReturnsEmptyString()
        {
            // Arrange
            string letter = "o";
            string word = "word";

            // Act
            string indexPlaces = Game.ReturnIndexPlace(letter, word);

            // Assert
            Assert.AreEqual(string.Empty, indexPlaces);
        }

        [Test]
        public void ReturnIndexPlace_GivenUpperCaseLetterInLowerCaseWord_ReturnsEmptyString()
        {
            // Arrange
            string letter = "O";
            string word = "word";

            // Act
            string indexPlaces = Game.ReturnIndexPlace(letter, word);

            // Assert
            Assert.AreEqual(string.Empty, indexPlaces);
        }

        #endregion
    }
}
