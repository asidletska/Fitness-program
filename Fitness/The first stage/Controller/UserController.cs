using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using The_first_stage.Model;

namespace The_first_stage.Controller
{
    public class UserController
    {
        public User User { get; }

        public UserController(string userName, string genderName,) 
        {
            // TODO: check
            var gander = new Gender(genderName);
            var user = new User(userName, gender, )
            User = user  ?? throw new ArgumentNullException("User can`t be equal to Null", nameof(user));
        }
        /// <summary>
        /// Save user data.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using(var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
        /// <summary>
        /// Take user data.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileLoadException"></exception>
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if(formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
                // TODO: Что делать если пользователя не прочитали

               /* if(formatter.Deserialize(fs) is User user)
                {
                    return user;
                }
                else
                {
                    return null;
                    throw new FileLoadException("Failed to retrieve user data from the file", "users.dat");
                }*/
            }
        }
    }
}
