using System;
using System.Collections.Generic;

namespace MyHashTableImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDictionary myDictionary = new(10);

            myDictionary.Add("SC", 5);
            myDictionary.Add("DF", 3);  
            myDictionary.Add("TF", 0);
            
            Console.WriteLine("My Version of dictionary: " + myDictionary.Lookup("SC"));
            Console.WriteLine("My Version of dictionary: " + myDictionary.Lookup("DF"));
            Console.WriteLine("My Version of dictionary: " + myDictionary.Lookup("TF"));
            Console.WriteLine("My Version of dictionary: " + myDictionary.Lookup("Unexisting item"));

            myDictionary.Remove("SC");
            Console.WriteLine("My Version of dictionary: " + myDictionary.Lookup("SC"));

            Console.ReadKey();
        }
    }
}
