using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using The_first_stage.Model;

namespace The_first_stage.Controller
{
    public class EatingController
    {
        private readonly User user;
        public List<Food> Foods { get; set; }
        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Username can`t be empty", nameof(user));

            Foods = GetAllFoods();
        }
        private List<Food> GetAllFoods()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("foods.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is List<Food> foods)
                {
                    return foods;
                }
                else
                {
                    return new List<Food>();
                }
            }
        }
        
    }
}
