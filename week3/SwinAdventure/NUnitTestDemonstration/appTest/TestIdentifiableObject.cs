
using SwinAdventure;

public class TestIdentifiableObject
{
    private IdentifiableObject _testObj;

    [SetUp]
    public void  SetUp(){
        _testObj  = new  IdentifiableObject(new string[] { "fred", "bob" });
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [Test]
    public void TestAreYou(){

        Assert.That(_testObj.AreYou("fred"),Is.True);
        
    }

    [Test]
    public void TestNotAreYou(){
        Assert.That(_testObj.AreYou("wilma"),Is.False);
        
    }

        [Test]
    public void TestCaseSensitive(){
        Assert.That(_testObj.AreYou("FrED"),Is.True);
        
    }
}