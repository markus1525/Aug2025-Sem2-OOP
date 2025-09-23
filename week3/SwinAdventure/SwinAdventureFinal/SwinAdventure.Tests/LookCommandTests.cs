// LookCommandTests.cs  
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class LookCommandTests
    {
        private LookCommand _lookCommand;
        private Player _player;
        private Location _location;
        private Item _sword;
        private Bag _bag;
        private Item _gem;

        [SetUp]
        public void Setup()
        {
            _lookCommand = new LookCommand();
            _player = new Player("Test Player", "A test player");
            _location = new Location("Test Room", "A test room");
            _player.Location = _location;
            _sword = new Item(new string[] { "sword" }, "bronze sword", "A short sword cast from bronze");
            _bag = new Bag(new string[] { "bag" }, "leather bag", "A small brown leather bag");
            _gem = new Item(new string[] { "gem" }, "red gem", "A bright red ruby");
        }

        [Test]
        public void TestLookCommandIdentifiable()
        {
            Assert.That(_lookCommand.AreYou("look"), Is.True);
        }

        [Test]
        public void TestLookRoom()
        {
            string result = _lookCommand.Execute(_player, new string[] { "look" });
            Assert.That(result, Does.Contain("Test Room"));
            Assert.That(result, Does.Contain("A test room"));
        }

        [Test]
        public void TestLookAtItem()
        {
            _location.Inventory.Put(_sword);
            string result = _lookCommand.Execute(_player, new string[] { "look", "at", "sword" });
            Assert.That(result, Is.EqualTo("A short sword cast from bronze"));
        }

        [Test]
        public void TestLookAtItemInContainer()
        {
            _bag.Inventory.Put(_gem);
            _player.Inventory.Put(_bag);
            string result = _lookCommand.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" });
            Assert.That(result, Is.EqualTo("A bright red ruby"));
        }

        [Test]
        public void TestLookAtNonExistentItem()
        {
            string result = _lookCommand.Execute(_player, new string[] { "look", "at", "nonexistent" });
            Assert.That(result, Is.EqualTo("I can't find any nonexistent"));
        }

        [Test]
        public void TestInvalidLookCommand()
        {
            string result = _lookCommand.Execute(_player, new string[] { "look", "under", "table" });
            Assert.That(result, Is.EqualTo("I don't know how to look like that"));
        }
    }
}