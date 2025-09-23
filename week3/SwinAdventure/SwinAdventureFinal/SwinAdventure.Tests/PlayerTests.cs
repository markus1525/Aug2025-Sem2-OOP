// PlayerTests.cs
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        private Player _player;
        private Item _sword;
        private Location _location;

        [SetUp]
        public void Setup()
        {
            _player = new Player("Fred", "the mighty programmer");
            _sword = new Item(new string[] { "sword" }, "bronze sword", "A short sword cast from bronze");
            _location = new Location("Test Room", "A test room");
        }

        [Test]
        public void TestPlayerIsIdentifiable()
        {
            Assert.That(_player.AreYou("me"), Is.True);
            Assert.That(_player.AreYou("inventory"), Is.True);
        }

        [Test]
        public void TestPlayerInventory()
        {
            Assert.That(_player.Inventory, Is.Not.Null);
            _player.Inventory.Put(_sword);
            Assert.That(_player.Inventory.HasItem("sword"), Is.True);
        }

        [Test]
        public void TestPlayerLocation()
        {
            _player.Location = _location;
            Assert.That(_player.Location, Is.EqualTo(_location));
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            string description = _player.FullDescription;
            Assert.That(description, Does.Contain("Fred"));
            Assert.That(description, Does.Contain("the mighty programmer"));
            Assert.That(description, Does.Contain("You are not carrying anything."));
        }

        [Test]
        public void TestPlayerLocate()
        {
            // Test locating self
            Assert.That(_player.Locate("me"), Is.EqualTo(_player));

            // Test locating item in inventory
            _player.Inventory.Put(_sword);
            Assert.That(_player.Locate("sword"), Is.EqualTo(_sword));

            // Test locating location
            _player.Location = _location;
            Assert.That(_player.Locate("room"), Is.EqualTo(_location));

            // Test locating item in location
            Item shovel = new Item(new string[] { "shovel" }, "shovel", "A sturdy shovel");
            _location.Inventory.Put(shovel);
            Assert.That(_player.Locate("shovel"), Is.EqualTo(shovel));
        }
    }
}