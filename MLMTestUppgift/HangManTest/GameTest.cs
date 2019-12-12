﻿using System;
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
            FakeRandom rnd = new FakeRandom(); // returns int 5
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
            FakeRandom rnd = new FakeRandom(); // returns int 5
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
            FakeRandom rnd = new FakeRandom(); // returns int 5
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
            FakeRandom rnd = new FakeRandom(); // returns int 5
            string letter = "5";
            string word = Lists.GetRandomWord(rnd); // returns word "according"
            Player player = new Player();

            // Act
            bool answer = Game.RightOrWrongGuess(letter, word, player);

            // Assert
            Assert.IsFalse(answer);
        }

        [Test]
        public void RightOrWrongGuess_GivenWrongGuess_ReducePlayerLives()
        {
            // Arrange
            FakeRandom rnd = new FakeRandom(); // returns int 5
            string letter = "b";
            string word = Lists.GetRandomWord(rnd); // returns word "according"
            
            Player player = new Player();
            player.lives = 10;
            int expectedLivesLeft = 9;

            // Act
            Game.RightOrWrongGuess(letter, word, player);

            // Assert
            Assert.AreEqual(player.lives, expectedLivesLeft);
        }

        [Test]
        public void RightOrWrongGuess_GivenRightGuess_PlayerLivesUnaffected()
        {
            // Arrange
            FakeRandom rnd = new FakeRandom(); // returns int 5
            string letter = "a";
            string word = Lists.GetRandomWord(rnd); // returns word "according"

            Player player = new Player();
            player.lives = 10;
            int expectedLivesLeft = 10;

            // Act
            Game.RightOrWrongGuess(letter, word, player);

            // Assert
            Assert.AreEqual(player.lives, expectedLivesLeft);
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
            string expectedResult = "1";

            // Act
            string indexPlaces = Game.ReturnIndexPlace(letter, word);

            // Assert
            Assert.AreEqual(expectedResult, indexPlaces);
        }

        [Test]
        public void ReturnIndexPlace_GivenUpperCaseLetterInUpperCaseWord_ReturnsIndexPlace()
        {
            // Arrange
            string letter = "O";
            string word = "WORD";
            string expectedResult = "1";

            // Act
            string indexPlaces = Game.ReturnIndexPlace(letter, word);

            // Assert
            Assert.AreEqual(expectedResult, indexPlaces);
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

        [Test]
        public void ReturnIndexPlace_GivenLetterNotInWord_ReturnsEmptyString()
        {
            // Arrange
            string letter = "a";
            string word = "WORD";

            // Act
            string indexPlaces = Game.ReturnIndexPlace(letter, word);

            // Assert
            Assert.AreEqual(string.Empty, indexPlaces);
        }

        [Test]
        public void ReturnIndexPlace_GivenLetterMultipleOccurencesInWord_ReturnsIndexPlacesWithComma()
        {
            // Arrange
            string letter = "o";
            string word = "COLOUR";
            string expectedResult = "1,3";

            // Act
            string indexPlaces = Game.ReturnIndexPlace(letter, word);

            // Assert
            Assert.AreEqual(expectedResult, indexPlaces);
        }

        #endregion

        #region AddPoints

        [Test]
        public void AddPoints_PlayerWinsWithFullLife_Adds500Points()
        {
            // Arrange
            Player player = new Player();
            player.lives = 10;
            player.score = 0;
            int expectedResult = 500;

            // Act
            Game.AddPoints(player);

            // Assert
            Assert.AreEqual(expectedResult, player.score);
        }

        [Test]
        public void AddPoints_PlayerWinsWithNineLives_Adds100Points()
        {
            // Arrange
            Player player = new Player();
            player.lives = 9;
            player.score = 0;
            int expectedResult = 100;

            // Act
            Game.AddPoints(player);

            // Assert
            Assert.AreEqual(expectedResult, player.score);
        }

        [Test]
        public void AddPoints_PlayerWinsWithEightLives_Adds80Points()
        {
            // Arrange
            Player player = new Player();
            player.lives = 8;
            player.score = 0;
            int expectedResult = 80;

            // Act
            Game.AddPoints(player);

            // Assert
            Assert.AreEqual(expectedResult, player.score);
        }

        [Test]
        public void AddPoints_PlayerWinsWithSevenLives_Adds80Points()
        {
            // Arrange
            Player player = new Player();
            player.lives = 7;
            player.score = 0;
            int expectedResult = 80;

            // Act
            Game.AddPoints(player);

            // Assert
            Assert.AreEqual(expectedResult, player.score);
        }

        [Test]
        public void AddPoints_PlayerWinsWithSixLives_Adds60Points()
        {
            // Arrange
            Player player = new Player();
            player.lives = 6;
            player.score = 0;
            int expectedResult = 60;

            // Act
            Game.AddPoints(player);

            // Assert
            Assert.AreEqual(expectedResult, player.score);
        }

        [Test]
        public void AddPoints_PlayerWinsWithFiveLives_Adds60Points()
        {
            // Arrange
            Player player = new Player();
            player.lives = 5;
            player.score = 0;
            int expectedResult = 60;

            // Act
            Game.AddPoints(player);

            // Assert
            Assert.AreEqual(expectedResult, player.score);
        }

        [Test]
        public void AddPoints_PlayerWinsWithFourLives_Adds40Points()
        {
            // Arrange
            Player player = new Player();
            player.lives = 4;
            player.score = 0;
            int expectedResult = 40;

            // Act
            Game.AddPoints(player);

            // Assert
            Assert.AreEqual(expectedResult, player.score);
        }

        [Test]
        public void AddPoints_PlayerWinsWithThreeLives_Adds40Points()
        {
            // Arrange
            Player player = new Player();
            player.lives = 4;
            player.score = 0;
            int expectedResult = 40;

            // Act
            Game.AddPoints(player);

            // Assert
            Assert.AreEqual(expectedResult, player.score);
        }

        [Test]
        public void AddPoints_PlayerWinsWithTwoLives_Adds20Points()
        {
            // Arrange
            Player player = new Player();
            player.lives = 2;
            player.score = 0;
            int expectedResult = 20;

            // Act
            Game.AddPoints(player);

            // Assert
            Assert.AreEqual(expectedResult, player.score);
        }

        [Test]
        public void AddPoints_PlayerWinsWithOneLife_Adds20Points()
        {
            // Arrange
            Player player = new Player();
            player.lives = 1;
            player.score = 0;
            int expectedResult = 20;

            // Act
            Game.AddPoints(player);

            // Assert
            Assert.AreEqual(expectedResult, player.score);
        }

        #endregion
    }
}
