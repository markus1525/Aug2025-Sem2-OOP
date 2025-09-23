// PutCommandTests.cs
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class PutCommandTests
    {
        private PutCommand _putCommand;
        private Player _player;
        private Location _location;
        private Item _sword;
        private Bag _bag;

        [SetUp]
        public void Setup()
        {
            _putCommand = new PutCommand();
            _player = new Player("Test Player", "A test player");
            _location = new Location("Test Room", "A test room");
            _player.Location = _location;
            _sword = new Item(new string[] { "sword" }, "bronze sword", "A short sword cast from bronze");
            _bag = new Bag(new string[] { "bag" }, "leather bag", "A small brown leather bag");
        }

        [Test]
        public void TestPutCommandIdentifiable()
        {
            Assert.That(_putCommand.AreYou("put"), Is.True);
            Assert.That(_putCommand.AreYou("drop"), Is.True);
        }

        [Test]
        public void TestPutWithoutItem()
        {
            string result = _putCommand.Execute(_player, new string[] { "put" });
            Assert.That(result, Is.EqualTo("What do you want to put down?"));
        }

        [Test]
        public void TestPutInRoom()
        {
            _player.Inventory.Put(_sword);
            string result = _putCommand.Execute(_player, new string[] { "put", "sword" });
            Assert.That(result, Is.EqualTo("You have put the bronze sword in the Test Room"));
            Assert.That(_location.Inventory.HasItem("sword"), Is.True);
            Assert.That(_player.Inventory.HasItem("sword"), Is.False);
        }

        [Test]
        public void TestPutItemNotInInventory()
        {
            string result = _putCommand.Execute(_player, new string[] { "put", "sword" });
            Assert.That(result, Is.EqualTo("I can't find any sword"));
        }

        [Test]
        public void TestPutInContainer()
        {
            _player.Inventory.Put(_sword);
            _player.Inventory.Put(_bag);
            string result = _putCommand.Execute(_player, new string[] { "put", "sword", "in", "bag" });
            Assert.That(result, Is.EqualTo("You have put the bronze sword in the leather bag"));
            Assert.That(_bag.Inventory.HasItem("sword"), Is.True);
            Assert.That(_player.Inventory.HasItem("sword"), Is.False);
        }
    }
}