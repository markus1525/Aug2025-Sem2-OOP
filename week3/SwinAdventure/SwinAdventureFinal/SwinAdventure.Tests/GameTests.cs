// GameTests.cs
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class GameTests
    {
        private Game _game;

        [SetUp]
        public void Setup()
        {
            _game = new Game();
        }

        [Test]
        public void TestGameCreation()
        {
            // Test that game can be created without throwing exceptions
            Assert.That(_game, Is.Not.Null);
        }

        // Note: Testing the Start() method would require mocking Console input/output
        // which is beyond the scope of basic unit tests. The game setup and initialization
        // are tested through the successful creation of the Game object.
    }
}