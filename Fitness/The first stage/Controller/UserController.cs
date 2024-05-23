using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using The_first_stage.Model;

namespace The_first_stage.Controller
{
    public class UserController
    {
        public User User { get; }

        public UserController(string userName, string genderName, DateTime birthDay, double weight, double height)
        {
            // TODO: check
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDay, weight, height);

        }
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
            }
        }

        /// <summary>
        /// Save user data.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
        /// <summary>
        /// Take user data.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileLoadException"></exception>
        
    }
}
