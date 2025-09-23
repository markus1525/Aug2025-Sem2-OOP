using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class IdentifiableObjectTests
    {
        private IdentifiableObject _testObject;
        private string _studentID = "105684881";
        private string _firstName = "Min Thu Kyaw";
        private string _familyName = "Khaung";

        [SetUp]
        public void Setup()
        {
            // Initialize the test object with sample identifiers.
            _testObject = new IdentifiableObject(new string[] { _studentID, _firstName, _familyName });
        }

        [Test]
        public void TestAreYou()
        {
            // Test that it responds True when identifier matches
            Assert.That(_testObject.AreYou(_studentID), Is.True);
            Assert.That(_testObject.AreYou(_firstName), Is.True);
            Assert.That(_testObject.AreYou(_familyName), Is.True);
        }

        [Test]
        public void TestNotAreYou()
        {
            // Test that it responds False when identifier doesn't match
            Assert.That(_testObject.AreYou("1O5684881"), Is.False);
            Assert.That(_testObject.AreYou("Taaj"), Is.False);
            Assert.That(_testObject.AreYou("Jack"), Is.False);
        }

        [Test]
        public void TestCaseSensitive()
        {
            // Test that matching is case insensitive
            Assert.That(_testObject.AreYou(_firstName.ToUpper()), Is.True);
            Assert.That(_testObject.AreYou(_familyName.ToLower()), Is.True);
            Assert.That(_testObject.AreYou("min Thu kyaW"), Is.True);
            Assert.That(_testObject.AreYou("MiN ThU KyAW"), Is.True);
        }

        [Test]
        public void TestFirstID()
        {
            // Test that first id returns the first identifier
            Assert.That(_testObject.FirstId, Is.EqualTo(_studentID));
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
            // Test privilege escalation with correct PIN
            _testObject.PrivilegeEscalation("4881");
            Assert.That(_testObject.FirstId, Is.EqualTo("TUTE01"));

            // Test with wrong PIN
            IdentifiableObject testObject2 = new IdentifiableObject(new string[] { "test", "object" });
            testObject2.PrivilegeEscalation("1234");
            Assert.That(testObject2.FirstId, Is.EqualTo("test")); // Should remain unchanged
        }
    }
}