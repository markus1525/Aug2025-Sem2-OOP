// CommandTests.cs
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class CommandTests
    {
        private LookCommand _lookCommand;
        private MoveCommand _moveCommand;
        private Player _player;
        private Location _location;

        [SetUp]
        public void Setup()
        {
            _lookCommand = new LookCommand();
            _moveCommand = new MoveCommand();
            _player = new Player("Test Player", "A test player");
            _location = new Location("Test Room", "A test room");
            _player.Location = _location;
        }

        [Test]
        public void TestLookCommandIdentifiable()
        {
            Assert.That(_lookCommand.AreYou("look"), Is.True);
        }

        [Test]
        public void TestMoveCommandIdentifiable()
        {
            Assert.That(_moveCommand.AreYou("move"), Is.True);
            Assert.That(_moveCommand.AreYou("go"), Is.True);
            Assert.That(_moveCommand.AreYou("head"), Is.True);
            Assert.That(_moveCommand.AreYou("leave"), Is.True);
        }

        [Test]
        public void TestLookCommandExecution()
        {
            string result = _lookCommand.Execute(_player, new string[] { "look" });
            Assert.That(result, Does.Contain("Test Room"));
        }

        [Test]
        public void TestMoveCommandWithoutDirection()
        {
            string result = _moveCommand.Execute(_player, new string[] { "move" });
            Assert.That(result, Is.EqualTo("Where do you want to go?"));
        }
    }
}
