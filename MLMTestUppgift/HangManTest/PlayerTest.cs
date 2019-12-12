using NUnit.Framework;
using HangMan;

namespace HangManTest
{
    public class PlayerTest
    {
        [Test]
        public void CheckName_GivenName_ReturnsTrue()
        {
            // Arrange
            string name = "Lollo";

            // Act
            bool answer = Player.CheckName(name);

            // Assert
            Assert.IsTrue(answer);     
        }

        [Test]
        public void CheckName_GivenInvalidCharacters_ReturnsFalse()
        {
            // Arrange
            string name = "/";

            // Act
            bool answer = Player.CheckName(name);

            // Assert
            Assert.IsFalse(answer);
        }

        [Test]
        public void CheckName_GivenNameWithNumbers_ReturnsTrue()
        {
            // Arrange
            string name = "Lollo4";

            // Act
            bool answer = Player.CheckName(name);

            // Assert
            Assert.IsTrue(answer);
        }

        [Test]
        public void CheckName_GivenCharacterOutsideOfRegEx_ReturnsFalse()
        {
            // Arrange
            string name = "Lollo4*£";

            // Act
            bool answer = Player.CheckName(name);

            // Assert
            Assert.IsFalse(answer);
        }

        [Test]
        public void CheckName_GivenEmptyString_ReturnsFalse()
        {
            // Arrange
            string name = string.Empty;

            // Act
            bool answer = Player.CheckName(name);

            // Assert
            Assert.IsFalse(answer);
        }

        [Test]
        public void CheckName_GivenBlanks_ReturnsFalse()
        {
            // Arrange
            string name = "Lollo 4";

            // Act
            bool answer = Player.CheckName(name);

            // Assert
            Assert.IsFalse(answer);
        }

        [Test]
        public void CheckName_GivenWhiteSpace_ReturnsFalse()
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