using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class PlayerTest
    {
        private Player _player;
        private Item _sword;
        private Item _gem;

        [SetUp]
        public void Setup()
        {
            // Create a player for testing
            _player = new Player("Markus", "an explorer");

            // Create test items
            _sword = new Item(new string[] { "sword", "bronze sword" }, "bronze sword", "A basic bronze sword");
            _gem = new Item(new string[] { "gem", "ruby" }, "red gem", "A shiny red ruby");
        }

        [Test]
        public void TestPlayerIsIdentifiable()
        {
            // Test if player is identifiable with "me" and "inventory"
            Assert.That(_player.AreYou("me"), Is.True, "Player should respond to 'me'");
            Assert.That(_player.AreYou("inventory"), Is.True, "Player should respond to 'inventory'");
        }

        [Test]
        public void TestPlayerLocatesItems()
        {
            // Add items to the player's inventory
            _player.Inventory.Put(_sword);
            _player.Inventory.Put(_gem);

            // Test if player can locate items in its inventory
            Assert.That(_player.Locate("sword"), Is.SameAs(_sword), "Player should locate sword in inventory");
            Assert.That(_player.Locate("gem"), Is.SameAs(_gem), "Player should locate gem in inventory");

            // Test if items remain in the player's inventory after locating
            Assert.That(_player.Inventory.HasItem("sword"), Is.True, "Sword should still be in inventory after locate");
            Assert.That(_player.Inventory.HasItem("gem"), Is.True, "Gem should still be in inventory after locate");
        }

        [Test]
        public void TestPlayerLocatesItself()
        {
            // Test if player returns itself if asked to locate "me" or "inventory"
            Assert.That(_player.Locate("me"), Is.SameAs(_player), "Player should locate itself with 'me'");
            Assert.That(_player.Locate("inventory"), Is.SameAs(_player), "Player should locate itself with 'inventory'");
        }

        [Test]
        public void TestPlayerLocatesNothing()
        {
            // Test if player returns null if asked to locate something it does not have
            Assert.That(_player.Locate("sword"), Is.Null, "Player should return null for item not in inventory");
            Assert.That(_player.Locate("shield"), Is.Null, "Player should return null for non-existent item");
            Assert.That(_player.Locate("potion"), Is.Null, "Player should return null for non-existent item");
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            // Add items to the player's inventory
            _player.Inventory.Put(_sword);
            _player.Inventory.Put(_gem);

            // Test if player's full description contains expected information
            string description = _player.FullDescription;

            Assert.That(description.Contains("You are Markus"), Is.True, "Description should contain player name");
            Assert.That(description.Contains("an explorer"), Is.True, "Description should contain player description");
            Assert.That(description.Contains("You are carrying"), Is.True, "Description should mention carrying items");
            Assert.That(description.Contains("bronze sword (sword)"), Is.True, "Description should list sword");
            Assert.That(description.Contains("red gem (gem)"), Is.True, "Description should list gem");
        }
    }
}