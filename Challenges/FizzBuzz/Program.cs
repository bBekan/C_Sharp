using System;
using System.Collections.Generic;

namespace FizzBuzz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an integer:");
            bool valid = true;
            var values = new Dictionary<int, String> { { 3, "Fizz" }, { 5, "Buzz" },{ 7, "Jazz"} };
            int num;
            do
            {
                valid = int.TryParse(Console.ReadLine(), out num);
                if (!valid)
                {
                    Console.WriteLine("Entry must be an integer");
                }
            } while (!valid);
            values.Add(4, "Whizz");
            checkNum(num, values);
        }

        private static void checkNum(int num, Dictionary<int, String> values)
        {
            foreach(var pair in values)
            {
                if(num % pair.Key == 0)
                {
                    Console.Write(pair.Value);
                }
            }
            Console.WriteLine();
        }
    }
}
