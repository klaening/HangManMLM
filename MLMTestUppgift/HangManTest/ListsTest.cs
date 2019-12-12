using System;
using System.Collections.Generic;
using System.Text;
using HangMan;
using NUnit.Framework;

namespace HangManTest
{
    class ListsTest
    {
        [Test]
        public void CreateHiddenWordArray_GivenWord_ReturnsArrayWithSameLength()
        {
            // Arrange
            string word = "word";

            // Act
            string[] answer = Lists.CreateHiddenWordArray(word);

            // Assert
            Assert.AreEqual(answer.Length, word.Length);
        }

        [Test]
        public void CreateHiddenWordArray_GivenWord_ReturnsArrayWithUnderscores()
        {
            // Arrange
            string word = "word";

            // Act
            string[] answer = Lists.CreateHiddenWordArray(word);

            // Assert
            Assert.Contains("_", answer);
        }
    }
}
