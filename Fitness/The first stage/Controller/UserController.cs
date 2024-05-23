using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using The_first_stage.Model;

namespace The_first_stage.Controller
{
    public class UserController
    {
        public List<User> Users { get; }
        public User CurrentUser { get; }   
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Username can`t be empty", nameof(userName));
            }
            Users = new List<User>();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                Save();
            }

        }
        /// <summary>
        /// Получить сохраненный список пользователей.
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
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
                formatter.Serialize(fs, Users);
            }
        }
        /// <summary>
        /// Take user data.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileLoadException"></exception>
        
    }
}
