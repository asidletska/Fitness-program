using System;

namespace The_first_stage.Model
{
    public class User
    {
        public string Name { get; }
        public Gender Gender { get; }
        public Gender gender { get; }

        public DateTime BirthDate { get; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public User (string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Condition check
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("User name can`t be empty", nameof(name));
            }
            if (gender == null)
            {
                throw new ArgumentNullException("The field name cannot be empty", nameof(gender));
            }
            if(birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
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
        public override string ToString()
        {
            return Name;
        }
    }
}
