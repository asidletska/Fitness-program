using System;
using The_first_stage.Controller;
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

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write("Enter your gender: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                var weight = ParseDouble("weight)");
                var height = ParseDouble("height");

                userController.SetNewUserData(gender, birthDate, weight, height);

            }
            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine(" Select action: \n E - Add mealtime ");
            var key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach(var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t {item.Key} - {item.Value}");
            }

            Console.ReadLine();
        }

        private static (Food Food, double Weight)EnterEating()
        {
            Console.Write("Enter the product name: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("calories:");
            var protein = ParseDouble("protein:");
            var fats = ParseDouble("fats:");
            var carbohydrates = ParseDouble("carbohydrates:");

            Console.Write("Enter the serving weight: ");
            var weight = ParseDouble("The serving weight: ");

            var product = new Food(food, calories, protein, fats, carbohydrates);

            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
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

            return birthDate;
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
