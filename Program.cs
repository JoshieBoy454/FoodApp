using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Food App!");
            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Hello, " + name + "!");
            Console.WriteLine("Please enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("You are " + age + " years old.");
            Console.WriteLine("Please enter your favorite food: ");
            string food = Console.ReadLine();
            Console.WriteLine("Your favorite food is " + food + ".");
            Console.WriteLine("Please enter your favorite drink: ");
            string drink = Console.ReadLine();
            Console.WriteLine("Your favorite drink is " + drink + ".");
            Console.WriteLine("Thank you for using the Food App!");
            Console.ReadLine();
        }
    }
}
