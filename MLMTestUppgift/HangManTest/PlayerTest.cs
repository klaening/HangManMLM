using NUnit.Framework;
using HangMan;

namespace HangManTest
{
    public class Tests
    {
        [Test]
        public void CreatePlayer_GivenName_ReturnsTrue()
        {
            // Arrange
            string name = "Lollo";

            // Act
            bool answer = Player.CheckName(name);

            // Assert
            Assert.IsTrue(answer);     
        }

        [Test]
        public void CreatePlayer_GivenInvalidCharacters_ReturnsFalse()
        {
            // Arrange
            string name = "/";

            // Act
            bool answer = Player.CheckName(name);

            // Assert
            Assert.IsFalse(answer);
        }

        [Test]
        public void CreatePlayer_GivenNameWithNumbers_ReturnsTrue()
        {
            // Arrange
            string name = "Lollo4";

            // Act
            bool answer = Player.CheckName(name);

            // Assert
            Assert.IsTrue(answer);
        }

        [Test]
        public void CreatePlayer_GivenCharacterOutsideOfRegEx_ReturnsFalse()
        {
            // Arrange
            string name = "Lollo4*£";

            // Act
            bool answer = Player.CheckName(name);

            // Assert
            Assert.IsFalse(answer);
        }

        [Test]
        public void CreatePlayer_GivenEmptyString_ReturnsFalse()
        {
            // Arrange
            string name = string.Empty;

            // Act
            bool answer = Player.CheckName(name);

            // Assert
            Assert.IsFalse(answer);
        }

        [Test]
        public void CreatePlayer_GivenBlanks_ReturnsFalse()
        {
            // Arrange
            string name = "Lollo 4";

            // Act
            bool answer = Player.CheckName(name);

            // Assert
            Assert.IsFalse(answer);
        }

        [Test]
        public void CreatePlayer_GivenWhiteSpace_ReturnsFalse()
        {
            // Arrange
            string name = string.Empty;

            // Act
            bool answer = Player.CheckName(name);

            // Assert
            Assert.IsFalse(answer);
        }
    }
}