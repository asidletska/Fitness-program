using System;
using The_first_stage.Model;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You`re welcomed by the app Fitness!");
            Console.WriteLine("Enter your name: ");

            var name = Console.ReadLine();
            var user = new User();
        }
    }
}
