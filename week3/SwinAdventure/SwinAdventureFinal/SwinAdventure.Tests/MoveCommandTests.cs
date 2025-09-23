// MoveCommandTests.cs
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class MoveCommandTests
    {
        private MoveCommand _moveCommand;
        private Player _player;
        private Location _startLocation;
        private Location _endLocation;
        private Path _northPath;

        [SetUp]
        public void Setup()
        {
            _moveCommand = new MoveCommand();
            _player = new Player("Test Player", "A test player");
            _startLocation = new Location("Start Room", "The starting room");
            _endLocation = new Location("End Room", "The ending room");
            _northPath = new Path(new string[] { "north", "n" }, "a doorway", _endLocation);
            _startLocation.AddPath(_northPath);
            _player.Location = _startLocation;
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
        public void TestMoveWithoutDirection()
        {
            string result = _moveCommand.Execute(_player, new string[] { "move" });
            Assert.That(result, Is.EqualTo("Where do you want to go?"));
        }

        [Test]
        public void TestMoveValidDirection()
        {
            string result = _moveCommand.Execute(_player, new string[] { "move", "north" });
            Assert.That(result, Does.Contain("You head NORTH"));
            Assert.That(result, Does.Contain("You go through a doorway"));
            Assert.That(result, Does.Contain("You have arrived in the End Room"));
            Assert.That(_player.Location, Is.EqualTo(_endLocation));
        }

        [Test]
        public void TestMoveInvalidDirection()
        {
            string result = _moveCommand.Execute(_player, new string[] { "move", "south" });
            Assert.That(result, Is.EqualTo("I can't go south"));
        }

        [Test]
        public void TestMoveWithNoLocation()
        {
            _player.Location = null;
            string result = _moveCommand.Execute(_player, new string[] { "move", "north" });
            Assert.That(result, Is.EqualTo("You are nowhere!"));
        }
    }
}