// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!" + "COS20007");


using System.Diagnostics.Metrics;
using HelloWorld;

class Program{
    
    public static void swapInteger(int a, int b){

        int tempValue = a;
        a = b;
        b = tempValue;
        
        Console.WriteLine("In swapInteger function, current value of a = " + a);
        Console.WriteLine("In swapInteger function, current value of b = " + b);

    }

    public static void swapObject(Message  a, Message b){
        a._text = b._text;

    }

    public static void Main(string[] args){

        int a = 10;

        int b = 20;

        swapInteger(a,b);

        Console.WriteLine("current value of a = " + a);
        Console.WriteLine("current value of b = " + b);

        Message myMessage1 = new Message("This is my  message 1");
        Message myMessage2 = new Message("This is my Message 2");

        swapObject(myMessage1,myMessage2);

        Console.WriteLine("my message 1's text is" + myMessage1._text);


        string currentText = myMessage1._text;

        myMessage1.Print();

        //PrintCounter(myCounters); //as used in Week 2

        Car myCar = new Car();

        int windScreenHeight = myCar.windScreen.getHeight();

    }
}