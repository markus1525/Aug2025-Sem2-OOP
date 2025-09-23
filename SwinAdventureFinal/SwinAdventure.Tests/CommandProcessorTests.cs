// CommandProcessorTests.cs
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class CommandProcessorTests
    {
        private CommandProcessor _processor;
        private Player _player;
        private Location _location;

        [SetUp]
        public void Setup()
        {
            _processor = new CommandProcessor();
            _player = new Player("Test Player", "A test player");
            _location = new Location("Test Room", "A test room");
            _player.Location = _location;
        }

        [Test]
        public void TestQuitCommand()
        {
            string result = _processor.Process("quit", _player);
            Assert.That(result, Is.EqualTo("quit"));
        }

        [Test]
        public void TestLookCommand()
        {
            string result = _processor.Process("look", _player);
            Assert.That(result, Does.Contain("Test Room"));
        }

        [Test]
        public void TestInvalidCommand()
        {
            string result = _processor.Process("invalidcommand", _player);
            Assert.That(result, Is.EqualTo("I don't understand invalidcommand"));
        }

        [Test]
        public void TestEmptyInput()
        {
            string result = _processor.Process("", _player);
            Assert.That(result, Is.EqualTo("I don't understand"));
        }

        [Test]
        public void TestInventoryCommand()
        {
            string result = _processor.Process("inventory", _player);
            Assert.That(result, Does.Contain("Test Player"));
        }
    }
}