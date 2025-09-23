// InventoryTests.cs
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class InventoryTests
    {
        private Inventory _inventory;
        private Item _sword;
        private Item _shovel;

        [SetUp]
        public void Setup()
        {
            _inventory = new Inventory();
            _sword = new Item(new string[] { "sword" }, "bronze sword", "A short sword cast from bronze");
            _shovel = new Item(new string[] { "shovel" }, "shovel", "A sturdy digging shovel");
        }

        [Test]
        public void TestHasItem()
        {
            Assert.That(_inventory.HasItem("sword"), Is.False);
            _inventory.Put(_sword);
            Assert.That(_inventory.HasItem("sword"), Is.True);
        }

        [Test]
        public void TestTakeItem()
        {
            _inventory.Put(_sword);
            Item taken = _inventory.Take("sword");
            Assert.That(taken, Is.EqualTo(_sword));
            Assert.That(_inventory.HasItem("sword"), Is.False);
        }

        [Test]
        public void TestTakeNonExistentItem()
        {
            Item taken = _inventory.Take("nonexistent");
            Assert.That(taken, Is.Null);
        }

        [Test]
        public void TestFetchItem()
        {
            _inventory.Put(_sword);
            Item fetched = _inventory.Fetch("sword");
            Assert.That(fetched, Is.EqualTo(_sword));
            Assert.That(_inventory.HasItem("sword"), Is.True); // Should still be there
        }

        [Test]
        public void TestItemListEmpty()
        {
            Assert.That(_inventory.ItemList, Is.EqualTo("You are not carrying anything."));
        }

        [Test]
        public void TestItemListWithItems()
        {
            _inventory.Put(_sword);
            _inventory.Put(_shovel);
            string itemList = _inventory.ItemList;
            Assert.That(itemList, Does.Contain("You are carrying:"));
            Assert.That(itemList, Does.Contain("a bronze sword (sword)"));
            Assert.That(itemList, Does.Contain("a shovel (shovel)"));
        }
    }
}