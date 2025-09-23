// BagTests.cs
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class BagTests
    {
        private Bag _bag;
        private Item _gem;

        [SetUp]
        public void Setup()
        {
            _bag = new Bag(new string[] { "bag", "leather bag" }, "leather bag", "A small brown leather bag.");
            _gem = new Item(new string[] { "gem", "red gem" }, "red gem", "A bright red ruby the size of your fist!");
        }

        [Test]
        public void TestBagIsIdentifiable()
        {
            Assert.That(_bag.AreYou("bag"), Is.True);
            Assert.That(_bag.AreYou("leather bag"), Is.True);
            Assert.That(_bag.AreYou("BAG"), Is.True);
        }

        [Test]
        public void TestBagInventory()
        {
            Assert.That(_bag.Inventory, Is.Not.Null);
            _bag.Inventory.Put(_gem);
            Assert.That(_bag.Inventory.HasItem("gem"), Is.True);
        }

        [Test]
        public void TestBagFullDescription()
        {
            // Test empty bag
            string description = _bag.FullDescription;
            Assert.That(description, Does.Contain("A small brown leather bag"));
            Assert.That(description, Does.Contain("You look in the leather bag and see:"));
            Assert.That(description, Does.Contain("nothing"));

            // Test bag with item
            _bag.Inventory.Put(_gem);
            description = _bag.FullDescription;
            Assert.That(description, Does.Contain("a red gem (gem)"));
        }
    }
}