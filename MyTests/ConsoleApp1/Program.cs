using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, everyone!");

            //create an object of Person class
            Person p = new Person();
            p.Name = "Alice";
            Console.WriteLine("Name of this person is " + p.Name + " and age is " + p.Age + "years old.");

            Person p2 = new Person();
            p2.Name = "Bob";
            Console.WriteLine("Name of this person is " + p2.Name + " and age is " + p2.Age + "years old.");
        }
    }
}
