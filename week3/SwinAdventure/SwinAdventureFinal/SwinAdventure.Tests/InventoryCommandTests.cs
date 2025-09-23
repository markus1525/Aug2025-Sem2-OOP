// InventoryCommandTests.cs
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class InventoryCommandTests
    {
        private InventoryCommand _inventoryCommand;
        private Player _player;

        [SetUp]
        public void Setup()
        {
            _inventoryCommand = new InventoryCommand();
            _player = new Player("Test Player", "A test player");
        }

        [Test]
        public void TestInventoryCommandIdentifiable()
        {
            Assert.That(_inventoryCommand.AreYou("inventory"), Is.True);
            Assert.That(_inventoryCommand.AreYou("inv"), Is.True);
            Assert.That(_inventoryCommand.AreYou("i"), Is.True);
        }

        [Test]
        public void TestInventoryCommandExecution()
        {
            string result = _inventoryCommand.Execute(_player, new string[] { "inventory" });
            Assert.That(result, Does.Contain("Test Player"));
            Assert.That(result, Does.Contain("You are not carrying anything."));
        }

        [Test]
        public void TestInventoryCommandWithItems()
        {
            Item sword = new Item(new string[] { "sword" }, "bronze sword", "A short sword");
            _player.Inventory.Put(sword);
            string result = _inventoryCommand.Execute(_player, new string[] { "inventory" });
            Assert.That(result, Does.Contain("Test Player"));
            Assert.That(result, Does.Contain("You are carrying:"));
            Assert.That(result, Does.Contain("a bronze sword (sword)"));
        }
    }
}
