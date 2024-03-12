using System;
using System.Collections.Generic;

namespace MyHashTableImplementation
{

    class Program
    {
        static void Main(string[] args)
        {
            MyDictionary<string, string> myDictionary = new(10);

            myDictionary.Add("Person", "Gabriela");
            myDictionary.Add("Sister", "Patricia");
            myDictionary.Add("Dog", "Meleca");
            
            Console.WriteLine("My Version of dictionary: " + myDictionary.Lookup("Person"));
            Console.WriteLine("My Version of dictionary: " + myDictionary.Lookup("Sister"));
            Console.WriteLine("My Version of dictionary: " + myDictionary.Lookup("Dog"));
            Console.WriteLine("My Version of dictionary: " + myDictionary.Lookup("Unexisting Value"));

            myDictionary.Remove("Human");
            Console.WriteLine("My Version of dictionary: " + myDictionary.Lookup("Human"));

            Console.ReadKey();
        }
    }
}
