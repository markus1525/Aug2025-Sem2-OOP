// PathTests.cs
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class PathTests
    {
        private Path _path;
        private Location _destination;

        [SetUp]
        public void Setup()
        {
            _destination = new Location("Destination", "The destination room");
            _path = new Path(new string[] { "north", "n" }, "a wooden door", _destination);
        }

        [Test]
        public void TestPathIsIdentifiable()
        {
            Assert.That(_path.AreYou("north"), Is.True);
            Assert.That(_path.AreYou("n"), Is.True);
            Assert.That(_path.AreYou("NORTH"), Is.True);
        }

        [Test]
        public void TestPathDestination()
        {
            Assert.That(_path.Destination, Is.EqualTo(_destination));
        }

        [Test]
        public void TestPathDescription()
        {
            Assert.That(_path.Description, Is.EqualTo("a wooden door"));
        }
    }
}