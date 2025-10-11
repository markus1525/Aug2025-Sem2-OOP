using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class ItemTest
    {
        private Item _testItem;

        [SetUp]
        public void Setup()
        {
            // Initialize the test item with sample identifiers.
            _testItem = new Item(new string[] { "sword", "bronze sword" }, "bronze sword", "A short sword cast from bronze");
        }

        [Test]
        public void TestItemIsIdentifiable()
        {
            // Test that item responds correctly to AreYou requests
            Assert.That(_testItem.AreYou("sword"), Is.True);
            Assert.That(_testItem.AreYou("bronze sword"), Is.True);
            Assert.That(_testItem.AreYou("SWORD"), Is.True);
            Assert.That(_testItem.AreYou("axe"), Is.False);
        }

        [Test]
        public void TestShortDescription()
        {
            // Test short description format: "name (first id)"
            Assert.That(_testItem.ShortDescription, Is.EqualTo("bronze sword (sword)"));
        }

        [Test]
        public void TestFullDescription()
        {
            // Test that full description returns the item's description
            Assert.That(_testItem.FullDescription, Is.EqualTo("A short sword cast from bronze"));
        }

        [Test]
        public void TestPrivilegeEscalation()
        {
            // Test privilege escalation with correct PIN
            _testItem.PrivilegeEscalation("4881");
            Assert.That(_testItem.FirstId, Is.EqualTo("TUTE01"));
        }
    }
}