using HelloWorld;

namespace appTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [Test]
    public void Test2(){
        Message myMessage = new Message("This is the default message");
        myMessage.Print();
        string currentContent = myMessage.GetMessage();

        Assert.That(currentContent, Is.EqualTo("This is the default message"));
        
        
        int counter = 14748361;

        unchecked  
        {  
            int IterationStep = (int)(214748369999 - int.MaxValue);
            // or
            counter  = (int)(214748369999);
        }
        
        int delta= int.MaxValue;
        for (int index = 0 ; index < 145336128698 ; index ++){
                delta += 1;
        }

    }
}
