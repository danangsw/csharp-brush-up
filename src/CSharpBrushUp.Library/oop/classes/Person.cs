using System;

namespace CSharpBrushUp.Library.OOP
{
    /// <summary>
    /// Represents a Person with basic properties and behaviors
    /// </summary>
    public class Person
    {
        // Fields
        private string name = string.Empty;
        private int age;
        private DateTime dateOfBirth;

        // Properties
        public string Name
        {
            get { return name; }
            set { name = value ?? throw new ArgumentNullException(nameof(value), "Name cannot be null"); }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Age cannot be negative", nameof(value));
                age = value;
            }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Date of birth cannot be in the future", nameof(value));
                dateOfBirth = value;
                // Automatically calculate age based on date of birth
                age = CalculateAge(value);
            }
        }

        // Read-only property to check if person is an adult
        public bool IsAdult => Age >= 18;

        // Constructors
        public Person(string name, int age)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name), "Name cannot be null");
            Age = age;
            // Estimate date of birth based on age
            DateOfBirth = DateTime.Now.AddYears(-age);
        }

        public Person(string name, DateTime dateOfBirth)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name), "Name cannot be null");
            DateOfBirth = dateOfBirth; // This will automatically set the age
        }

        // Default constructor
        public Person() : this("Unknown", 0)
        {
        }

        // Methods
        /// <summary>
        /// Displays person information to the console
        /// </summary>
        public virtual void PersonInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Date of Birth: {DateOfBirth:yyyy-MM-dd}");
            Console.WriteLine($"Is Adult: {(IsAdult ? "Yes" : "No")}");
        }

        /// <summary>
        /// Returns a greeting message from the person
        /// </summary>
        public virtual string Greet()
        {
            return $"Hello, my name is {Name} and I am {Age} years old.";
        }

        /// <summary>
        /// Celebrates the person's birthday by incrementing age
        /// </summary>
        public virtual void CelebrateBirthday()
        {
            Age++;
            Console.WriteLine($"🎉 Happy Birthday {Name}! You are now {Age} years old!");
        }

        /// <summary>
        /// Calculates age based on date of birth
        /// </summary>
        private int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Now;
            var age = today.Year - birthDate.Year;

            // Subtract a year if birthday hasn't occurred this year yet
            if (birthDate.Date > today.AddYears(-age))
                age--;

            return Math.Max(0, age); // Ensure age is never negative
        }

        /// <summary>
        /// Override ToString for better string representation
        /// </summary>
        public override string ToString()
        {
            return $"Person: {Name}, Age: {Age}";
        }

        /// <summary>
        /// Override Equals for proper comparison
        /// </summary>
        public override bool Equals(object? obj)
        {
            if (obj is Person other)
            {
                return Name.Equals(other.Name, StringComparison.OrdinalIgnoreCase) &&
                       DateOfBirth.Date == other.DateOfBirth.Date;
            }
            return false;
        }

        /// <summary>
        /// Override GetHashCode for proper hashing
        /// </summary>
        public override int GetHashCode()
        {
            return HashCode.Combine(Name.ToLowerInvariant(), DateOfBirth.Date);
        }
    }
}