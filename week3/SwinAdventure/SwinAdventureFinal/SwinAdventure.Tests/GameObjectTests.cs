// GameObjectTests.cs
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    // Concrete implementation of GameObject for testing purposes
    public class TestGameObject : GameObject
    {
        public TestGameObject(string[] ids, string name, string description)
            : base(ids, name, description)
        {
        }
    }

    [TestFixture]
    public class GameObjectTests
    {
        private TestGameObject _gameObject;

        [SetUp]
        public void Setup()
        {
            _gameObject = new TestGameObject(new string[] { "test", "object" }, "Test Object", "A test game object");
        }

        [Test]
        public void TestGameObjectIsIdentifiable()
        {
            // Test that GameObject inherits IdentifiableObject functionality
            Assert.That(_gameObject.AreYou("test"), Is.True);
            Assert.That(_gameObject.AreYou("object"), Is.True);
            Assert.That(_gameObject.AreYou("TEST"), Is.True);
            Assert.That(_gameObject.AreYou("invalid"), Is.False);
        }

        [Test]
        public void TestGameObjectName()
        {
            Assert.That(_gameObject.Name, Is.EqualTo("Test Object"));
        }

        [Test]
        public void TestGameObjectDescription()
        {
            Assert.That(_gameObject.Description, Is.EqualTo("A test game object"));
        }

        [Test]
        public void TestGameObjectShortDescription()
        {
            Assert.That(_gameObject.ShortDescription, Is.EqualTo("Test Object (test)"));
        }

        [Test]
        public void TestGameObjectFullDescription()
        {
            Assert.That(_gameObject.FullDescription, Is.EqualTo("A test game object"));
        }

        [Test]
        public void TestGameObjectFirstId()
        {
            Assert.That(_gameObject.FirstId, Is.EqualTo("test"));
        }
    }
}