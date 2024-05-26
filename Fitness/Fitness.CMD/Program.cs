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

            var userController = new UserController(name);
            if(userController.IsNewUser)
            {
                Console.Write("Enter your gender: ");
                var gender = Console.ReadLine();
                DateTime birthDate;
                double weight;
                double height;

                while (true)
                {
                    Console.Write("\nEnter your date of birth (dd.MM.yyyy): ");
                    if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input");
                    }
                }


              //  userController.SetNewUserData()

            }
            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
        }
        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Enter your {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Incorrect input {name}");
                }
            }
        }
    }
}
