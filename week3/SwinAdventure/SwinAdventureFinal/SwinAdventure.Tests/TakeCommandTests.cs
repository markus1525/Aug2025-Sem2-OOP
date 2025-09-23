// TakeCommandTests.cs
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class TakeCommandTests
    {
        private TakeCommand _takeCommand;
        private Player _player;
        private Location _location;
        private Item _sword;
        private Bag _bag;
        private Item _gem;

        [SetUp]
        public void Setup()
        {
            _takeCommand = new TakeCommand();
            _player = new Player("Test Player", "A test player");
            _location = new Location("Test Room", "A test room");
            _player.Location = _location;
            _sword = new Item(new string[] { "sword" }, "bronze sword", "A short sword cast from bronze");
            _bag = new Bag(new string[] { "bag" }, "leather bag", "A small brown leather bag");
            _gem = new Item(new string[] { "gem" }, "red gem", "A bright red ruby");
        }

        [Test]
        public void TestTakeCommandIdentifiable()
        {
            Assert.That(_takeCommand.AreYou("take"), Is.True);
            Assert.That(_takeCommand.AreYou("pickup"), Is.True);
        }

        [Test]
        public void TestTakeWithoutItem()
        {
            string result = _takeCommand.Execute(_player, new string[] { "take" });
            Assert.That(result, Is.EqualTo("What do you want to take?"));
        }

        [Test]
        public void TestTakeFromRoom()
        {
            _location.Inventory.Put(_sword);
            string result = _takeCommand.Execute(_player, new string[] { "take", "sword" });
            Assert.That(result, Is.EqualTo("You have taken the bronze sword from the Test Room"));
            Assert.That(_player.Inventory.HasItem("sword"), Is.True);
            Assert.That(_location.Inventory.HasItem("sword"), Is.False);
        }

        [Test]
        public void TestTakeNonExistentItem()
        {
            string result = _takeCommand.Execute(_player, new string[] { "take", "nonexistent" });
            Assert.That(result, Is.EqualTo("I can't find any nonexistent"));
        }

        [Test]
        public void TestTakeFromContainer()
        {
            _bag.Inventory.Put(_gem);
            _player.Inventory.Put(_bag);
            string result = _takeCommand.Execute(_player, new string[] { "take", "gem", "from", "bag" });
            Assert.That(result, Is.EqualTo("You have taken the red gem from the leather bag"));
            Assert.That(_player.Inventory.HasItem("gem"), Is.True);
            Assert.That(_bag.Inventory.HasItem("gem"), Is.False);
        }
    }
}
