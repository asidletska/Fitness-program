using System;
using The_first_stage.Controller;


namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You`re welcomed by the app Fitness!");
            Console.WriteLine("Enter your name: ");
            var name = Console.ReadLine();

            Console.WriteLine("Enter your gender: ");
            var gender = Console.ReadLine();

            Console.WriteLine("Enter your date of birth: ");
            var birthdate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter your weight: ");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter your height: ");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthdate, weight, height);
            userController.Save();
        }
    }
}
