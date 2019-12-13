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
        public void CheckLetter_GivenCorrectLowerCaseLetter_ReturnsLetter()
        {
            // Arrange
            string letter = "b";

            // Act
            string answer = Guess.CheckLetter(letter);

            // Assert
            Assert.AreEqual(letter, answer);
        }

        [Test]
        public void CheckLetter_GivenCorrectUpperCaseLetter_ReturnsLetter()
        {
            // Arrange
            string letter = "B";

            // Act
            string answer = Guess.CheckLetter(letter);

            // Assert
            Assert.AreEqual(letter, answer);
        }

        [Test]
        public void CheckLetter_GivenInvalidLetter_ThrowsException()
        {
            // Arrange
            string letter = " ";

            // Act
            string answer = Guess.CheckLetter(letter);

            // Assert
            Assert.Throws<Exception>(()=>Guess.CheckLetter(letter));
        }

        [Test]
        public void CheckLetter_GivenWhiteSpace_ThrowsException()
        {
            // Arrange
            string letter = " ";

            // Act
            string answer = Guess.CheckLetter(letter);

            // Assert
            Assert.Throws<Exception>(() => Guess.CheckLetter(letter));
        }

        [Test]
        public void CheckLetter_GivenNumbers_ThrowsException()
        {
            // Arrange
            string letter = "2";

            // Act
            string answer = Guess.CheckLetter(letter);

            // Assert
            Assert.Throws<Exception>(() => Guess.CheckLetter(letter));
        }

        [Test]
        public void CheckLetter_GivenEmptyString_ThrowsException()
        {
            // Arrange
            string letter = "";

            // Act
            string answer = Guess.CheckLetter(letter);

            // Assert
            Assert.Throws<Exception>(()=> Guess.CheckLetter(letter));
        }
    }
}
