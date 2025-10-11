using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class InventoryTest
    {
        private Inventory _inventory;
        private Item _testItem1;
        private Item _testItem2;

        [SetUp]
        public void Setup()
        {
            _inventory = new Inventory();
            _testItem1 = new Item(new string[] { "sword", "axe" }, "bronze sword", "A basic bronze sword");
            _testItem2 = new Item(new string[] { "gem", "ruby" }, "red gem", "A shiny red ruby");
        }

        [Test] //The Inventory has items that are put in it.
        public void TestFindItem()
        {
            // Arrange
            _inventory.Put(_testItem1);
            _inventory.Put(_testItem2);

            // Act & Assert
            Assert.That(_inventory.HasItem("sword"), Is.True, "Should find sword in inventory");
            Assert.That(_inventory.HasItem("axe"), Is.True, "Should find weapon identifier for sword");
            Assert.That(_inventory.HasItem("gem"), Is.True, "Should find gem in inventory");
            Assert.That(_inventory.HasItem("ruby"), Is.True, "Should find ruby identifier for gem");
        }

        [Test] //The Inventory does not have items it does not contain.
        public void TestNoItemFind()
        {
            // Arrange
            _inventory.Put(_testItem1);

            // Act & Assert
            Assert.That(_inventory.HasItem("shield"), Is.False, "Should not find shield in inventory");
            Assert.That(_inventory.HasItem("potion"), Is.False, "Should not find potion in inventory");
            Assert.That(_inventory.HasItem("gold"), Is.False, "Should not find gem when not in inventory");
        }

        [Test] //Returns items it has, and the item remains in the inventory.
        public void TestFetchItem()
        {
            // Arrange
            _inventory.Put(_testItem1);
            _inventory.Put(_testItem2);

            // Act
            Item? fetchedSword = _inventory.Fetch("sword");
            Item? fetchedGem = _inventory.Fetch("gem");

            // Assert
            Assert.That(fetchedSword, Is.Not.Null, "Should return a valid item");
            Assert.That(fetchedGem, Is.Not.Null, "Should return a valid item");
            Assert.That(fetchedSword, Is.SameAs(_testItem1), "Should return the same sword item");
            Assert.That(fetchedGem, Is.SameAs(_testItem2), "Should return the same gem item");

            // Verify items are still in inventory after fetch
            Assert.That(_inventory.HasItem("sword"), Is.True, "Sword should still be in inventory after fetch");
            Assert.That(_inventory.HasItem("gem"), Is.True, "Gem should still be in inventory after fetch");
        }

        [Test] // Returns the item, and the item is no longer in the inventory.
        public void TestTakeItem()
        {
            // Arrange
            _inventory.Put(_testItem1);
            _inventory.Put(_testItem2);

            // Act
            Item? takenSword = _inventory.Take("sword");
            Item? takenGem = _inventory.Take("gem");

            // Assert
            Assert.That(takenSword, Is.Not.Null, "Should return a valid item");
            Assert.That(takenGem, Is.Not.Null, "Should return a valid item");
            Assert.That(takenSword, Is.SameAs(_testItem1), "Should return the same sword item");
            Assert.That(takenGem, Is.SameAs(_testItem2), "Should return the same gem item");

            // Verify item is no longer in inventory after take
            Assert.That(_inventory.HasItem("sword"), Is.False, "Sword should not be in inventory after take");
            Assert.That(_inventory.HasItem("gem"), Is.False, "Gem should not be in inventory after take");
        }

        [Test] //Returns a string containing multiple lines. Each line contains a tab-indented short description of an item in the Inventory.
        public void TestItemList()
        {
            // Arrange
            _inventory.Put(_testItem1);
            _inventory.Put(_testItem2);

            // Act
            string itemList = _inventory.ItemList;

            // Assert
            Assert.That(itemList.Contains("bronze sword (sword)"), Is.True, "Item list should contain tabbed sword description");
            Assert.That(itemList.Contains("red gem (gem)"), Is.True, "Item list should contain tabbed gem description");
        }
    }
}