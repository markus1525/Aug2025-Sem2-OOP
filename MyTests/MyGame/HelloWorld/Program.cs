using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Message message = new Message("Hello");
            message.Print();
        }
    }
}