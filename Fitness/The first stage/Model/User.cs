using System;

namespace The_first_stage.Model
{
    [Serializable]
    public class User
    {
        public string Name { get; }
        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }
         
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Condition check
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Username can`t be empty", nameof(name));
            }
            if (gender == null)
            {
                throw new ArgumentNullException("The field name cannot be empty", nameof(gender));
            }
            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Impossible date of birth", nameof(birthDate));
            }
            if (weight <= 0)
            {
                throw new ArgumentException("Incorrect value", nameof(weight));
            }
            if (height <= 0)
            {
                throw new ArgumentException("Incorrect value", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;

        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Username can`t be empty", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
