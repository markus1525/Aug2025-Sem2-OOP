// LocationTests.cs
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class LocationTests
    {
        private Location _location;
        private Item _sword;
        private Path _northPath;
        private Location _otherLocation;

        [SetUp]
        public void Setup()
        {
            _location = new Location("Test Room", "A test room for testing");
            _sword = new Item(new string[] { "sword" }, "bronze sword", "A short sword cast from bronze");
            _otherLocation = new Location("Other Room", "Another room");
            _northPath = new Path(new string[] { "north", "n" }, "a doorway", _otherLocation);
        }

        [Test]
        public void TestLocationIsIdentifiable()
        {
            Assert.That(_location.AreYou("room"), Is.True);
            Assert.That(_location.AreYou("here"), Is.True);
        }

        [Test]
        public void TestLocationInventory()
        {
            Assert.That(_location.Inventory, Is.Not.Null);
            _location.Inventory.Put(_sword);
            Assert.That(_location.Inventory.HasItem("sword"), Is.True);
        }

        [Test]
        public void TestAddPath()
        {
            _location.AddPath(_northPath);
            Assert.That(_location.GetPath("north"), Is.EqualTo(_northPath));
            Assert.That(_location.GetPath("n"), Is.EqualTo(_northPath));
        }

        [Test]
        public void TestGetPathNonExistent()
        {
            Assert.That(_location.GetPath("south"), Is.Null);
        }

        [Test]
        public void TestLocationFullDescription()
        {
            _location.AddPath(_northPath);
            _location.Inventory.Put(_sword);

            string description = _location.FullDescription;
            Assert.That(description, Does.Contain("You are in the Test Room"));
            Assert.That(description, Does.Contain("A test room for testing"));
            Assert.That(description, Does.Contain("There are exits to the north"));
            Assert.That(description, Does.Contain("In this room you can see:"));
            Assert.That(description, Does.Contain("a bronze sword (sword)"));
        }
    }
}