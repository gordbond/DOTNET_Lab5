using System;
using System.Collections.Generic;

namespace stringTests
{
    class Program
    {
        static void Main(string[] args)
        {
            string string1 = "   hello";
            string string2 = "world";

            Console.WriteLine(string1.Contains("lo"));
            Console.ReadLine();
            string1 = string1.Trim();
            
            Console.WriteLine(string1.Substring(0,5));
            Console.ReadLine();

            Console.WriteLine(string1.Replace("o","x"));
            Console.ReadLine();

            if (string1.Contains("ll"))
                Console.WriteLine(string1.Replace("ll", "BUTTZ"));
            Console.ReadLine();

            string[] twoStrings = string1.Split("e");

            foreach (string s in twoStrings)
            {
                Console.WriteLine(s);
                Console.ReadLine();
            }
            
            if (string2.Contains("r")) {
                string2 = string2.Remove(string2.IndexOf("r"));
            }

            Console.WriteLine(string2);
            Console.ReadLine();

            string string2Clone = (string)string2.Clone();
            Console.WriteLine(string2Clone);
            Console.ReadLine();

            string2 += "rld";

            Console.WriteLine(string2);
            Console.ReadLine();

            //string2Clone = (string)string2.Clone();
            Console.WriteLine(string2Clone);
            Console.ReadLine();


        }
    }
}
