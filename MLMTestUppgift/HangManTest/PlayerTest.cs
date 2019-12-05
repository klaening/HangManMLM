using NUnit.Framework;
using HangMan;

namespace HangManTest
{
    public class Tests
    {
        [Test]
        public void CreatePlayer_GivenName_ReturnsName()
        {
            // Assign
            string name = "Lollo";

            // Act
            Player player = Player.CreatePlayer(name);

            // Assert
            Assert.AreEqual(name, player.name);
        }

        [Test]
        public void CreatePlayer_GivenInvalidCharacters_ReturnsNull()
        {
            // Assign
            string name = "/";

            // Act
            Player player = Player.CreatePlayer(name);

            // Assert
            Assert.IsNull(player.name);
        }

        [Test]
        public void CreatePlayer_GivenNameWithNumbers_ReturnsName()
        {
            // Assign
            string name = "Lollo4";

            // Act
            Player player = Player.CreatePlayer(name);

            // Assert
            Assert.AreEqual(name, player.name);
        }

        [Test]
        public void CreatePlayer_GivenCharacterOutsideOfRegEx_ReturnsNull()
        {
            // Assign
            string name = "Lollo4*£";

            // Act
            Player player = Player.CreatePlayer(name);

            // Assert
            Assert.IsNull(player.name);
        }

        [Test]
        public void CreatePlayer_GivenEmptyString_ReturnsNull()
        {
            // Assign
            string name = string.Empty;

            // Act
            Player player = Player.CreatePlayer(name);

            // Assert
            Assert.IsNull(player.name);
        }

        [Test]
        public void CreatePlayer_GivenBlanks_ReturnsNull()
        {
            // Assign
            string name = "Lollo 4";

            // Act
            Player player = Player.CreatePlayer(name);

            // Assert
            Assert.IsNull(player.name);
        }
    }
}