using System;
using System.Collections.Generic;
using System.Linq;
using The_first_stage.Model;

namespace The_first_stage.Controller
{
    public class UserController : ControllerBase
    {
        private const string USER_FILE_NAME = "users.dat";
        public List<User> Users { get; }
        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;
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
                IsNewUser = true;
                Save();
            }

        }
        /// <summary>
        /// Получить сохраненный список пользователей.
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            return Load<List<User>>(USER_FILE_NAME) ?? new List<User>();           
        }

        private T Load<T>(string uSER_FILE_NAME)
        {
            throw new NotImplementedException();
        }

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            // Check
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }
        /// <summary>
        /// Save user data.
        /// </summary>
        public void Save()
        {
            Save(USER_FILE_NAME, Users);
        }  
    }
}
