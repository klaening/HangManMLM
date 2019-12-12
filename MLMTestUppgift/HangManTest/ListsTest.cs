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
        public void CreateHiddenWordArray_GivenWord_ReturnsArrayWithOnlyUnderscores()
        {
            // Arrange
            string word = "word";
            string underScore = "_";
            // Act
            string[] answer = Lists.CreateHiddenWordArray(word);

            // Assert
            for (int i = 0; i < word.Length; i++)
            {
                Assert.AreEqual(underScore, answer[i]);
            }
        }
    }
}
