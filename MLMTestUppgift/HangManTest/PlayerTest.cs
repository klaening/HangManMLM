//using NUnit.Framework;
//using HangMan;

//namespace HangManTest
//{
//    public class Tests
//    {
//        [Test]
//        public void CreatePlayer_GivenName_ReturnsName()
//        {
//            // Assign
//            string name = "Lollo";
//            Player player = new Player();

//            // Act
//            player.name = Player.CheckName(name);

//            // Assert
//            Assert.AreEqual(name, player.name);
//        }

//        [Test]
//        public void CreatePlayer_GivenInvalidCharacters_ReturnsNull()
//        {
//            // Assign
//            string name = "/";

//            // Act
//            Player player = Player.CheckName(name);

//            // Assert
//            Assert.IsNull(player.Name);
//        }

//        [Test]
//        public void CreatePlayer_GivenNameWithNumbers_ReturnsName()
//        {
//            // Assign
//            string name = "Lollo4";

//            // Act
//            Player player = Player.CheckName(name);

//            // Assert
//            Assert.AreEqual(name, player.name);
//        }

//        [Test]
//        public void CreatePlayer_GivenCharacterOutsideOfRegEx_ReturnsNull()
//        {
//            // Assign
//            string name = "Lollo4*£";

//            // Act
//            Player player = Player.CheckName(name);

//            // Assert
//            Assert.IsNull(player.Name);
//        }

//        [Test]
//        public void CreatePlayer_GivenEmptyString_ReturnsNull()
//        {
//            // Assign
//            string name = string.Empty;

//            // Act
//            Player player = Player.CheckName(name);

//            // Assert
//            Assert.IsNull(player.Name);
//        }

//        [Test]
//        public void CreatePlayer_GivenBlanks_ReturnsNull()
//        {
//            // Assign
//            string name = "Lollo 4";

//            // Act
//            Player player = Player.CheckName(name);

//            // Assert
//            Assert.IsNull(player.Name);
//        }

//        [Test]
//        public void CreatePlayer_GivenWhiteSpace_ReturnsNull()
//        {
//            // Assign
//            string name = string.Empty;

//            // Act
//            Player player = Player.CheckName(name);

//            // Assert
//            Assert.IsNull(player.Name);
//        }
//    }
//}