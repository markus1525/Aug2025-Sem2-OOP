// IdentifiableObjectTests.cs
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class IdentifiableObjectTests
    {
        private IdentifiableObject _testObject;

        [SetUp]
        public void Setup()
        {
            // Using sample identifiers - replace with your actual student details
            _testObject = new IdentifiableObject(new string[] { "12345678", "John", "Smith" });
        }

        [Test]
        public void TestAreYou()
        {
            // Test that it responds True when identifier matches
            Assert.That(_testObject.AreYou("12345678"), Is.True);
            Assert.That(_testObject.AreYou("John"), Is.True);
            Assert.That(_testObject.AreYou("Smith"), Is.True);
        }

        [Test]
        public void TestNotAreYou()
        {
            // Test that it responds False when identifier doesn't match
            Assert.That(_testObject.AreYou("87654321"), Is.False);
            Assert.That(_testObject.AreYou("Jane"), Is.False);
            Assert.That(_testObject.AreYou("Doe"), Is.False);
        }

        [Test]
        public void TestCaseSensitive()
        {
            // Test that matching is case insensitive
            Assert.That(_testObject.AreYou("JOHN"), Is.True);
            Assert.That(_testObject.AreYou("smith"), Is.True);
            Assert.That(_testObject.AreYou("JoHn"), Is.True);
        }

        [Test]
        public void TestFirstID()
        {
            // Test that first id returns the first identifier
            Assert.That(_testObject.FirstId, Is.EqualTo("12345678"));
        }

        [Test]
        public void TestFirstIDWithNoIDs()
        {
            // Test empty string is returned when no identifiers
            IdentifiableObject emptyObject = new IdentifiableObject(new string[] { });
            Assert.That(emptyObject.FirstId, Is.EqualTo(""));
        }

        [Test]
        public void TestAddID()
        {
            // Test that identifiers can be added
            _testObject.AddIdentifier("TestID");
            Assert.That(_testObject.AreYou("TestID"), Is.True);
            Assert.That(_testObject.AreYou("testid"), Is.True);
        }

        [Test]
        public void TestPrivilegeEscalation()
        {
            // Test privilege escalation with correct PIN (using sample - replace with your student ID last 4 digits)
            _testObject.PrivilegeEscalation("4881");
            Assert.That(_testObject.FirstId, Is.EqualTo("TUTE01"));

            // Test with wrong PIN
            IdentifiableObject testObject2 = new IdentifiableObject(new string[] { "test", "object" });
            testObject2.PrivilegeEscalation("1234");
            Assert.That(testObject2.FirstId, Is.EqualTo("test")); // Should remain unchanged
        }
    }
}