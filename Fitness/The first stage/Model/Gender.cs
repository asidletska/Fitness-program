using System;

namespace The_first_stage.Model
{
    /// <summary>
    /// Gender
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// Title
        /// </summary>
        public string Name { get;  }
        
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("The field name cannot be empty", nameof(name));
            }
            Name = name;

        }
        public override string ToString()
        {
            return Name;
        }
    }
}
