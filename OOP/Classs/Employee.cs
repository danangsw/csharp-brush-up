using System;
using System.Collections.Generic;

namespace OOP
{
    /// <summary>
    /// Employee class that inherits from Person
    /// Demonstrates inheritance with different specialization
    /// </summary>
    public class Employee : Person
    {
        // Additional fields specific to Employee
        private string employeeId = string.Empty;
        private string department = string.Empty;
        private string position = string.Empty;
        private decimal salary;
        private DateTime hireDate;
        private List<string> skills = new List<string>();

        // Additional properties
        public string EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value ?? throw new ArgumentNullException(nameof(value), "Employee ID cannot be null"); }
        }

        public string Department
        {
            get { return department; }
            set { department = value ?? throw new ArgumentNullException(nameof(value), "Department cannot be null"); }
        }

        public string Position
        {
            get { return position; }
            set { position = value ?? throw new ArgumentNullException(nameof(value), "Position cannot be null"); }
        }

        public decimal Salary
        {
            get { return salary; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Salary cannot be negative", nameof(value));
                salary = value;
            }
        }

        public DateTime HireDate
        {
            get { return hireDate; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Hire date cannot be in the future", nameof(value));
                hireDate = value;
            }
        }

        public List<string> Skills
        {
            get { return new List<string>(skills); } // Return a copy
        }

        public int YearsOfService => (int)((DateTime.Now - HireDate).TotalDays / 365.25);

        // Constructors
        public Employee(string name, int age, string employeeId, string department, string position, decimal salary)
            : base(name, age)
        {
            EmployeeId = employeeId;
            Department = department;
            Position = position;
            Salary = salary;
            HireDate = DateTime.Now; // Default to today
        }

        public Employee(string name, DateTime dateOfBirth, string employeeId, string department, string position, decimal salary, DateTime hireDate)
            : base(name, dateOfBirth)
        {
            EmployeeId = employeeId;
            Department = department;
            Position = position;
            Salary = salary;
            HireDate = hireDate;
        }

        // Default constructor
        public Employee() : base("Unknown Employee", 25)
        {
            EmployeeId = "EMP000";
            Department = "General";
            Position = "Associate";
            Salary = 0;
            HireDate = DateTime.Now;
        }

        // Method overrides
        /// <summary>
        /// Override PersonInfo to include employee-specific information
        /// </summary>
        public override void PersonInfo()
        {
            base.PersonInfo(); // Call parent method first
            Console.WriteLine($"Employee ID: {EmployeeId}");
            Console.WriteLine($"Department: {Department}");
            Console.WriteLine($"Position: {Position}");
            Console.WriteLine($"Salary: ${Salary:N2}");
            Console.WriteLine($"Hire Date: {HireDate:yyyy-MM-dd}");
            Console.WriteLine($"Years of Service: {YearsOfService}");
            Console.WriteLine($"Skills: {string.Join(", ", skills)}");
        }

        /// <summary>
        /// Override Greet to include employee-specific greeting
        /// </summary>
        public override string Greet()
        {
            return $"{base.Greet()} I work as a {Position} in the {Department} department.";
        }

        /// <summary>
        /// Override CelebrateBirthday with employee-specific celebration
        /// </summary>
        public override void CelebrateBirthday()
        {
            base.CelebrateBirthday(); // Call parent method
            Console.WriteLine($"🎂 The {Department} team wishes you a wonderful year ahead!");
        }

        /// <summary>
        /// Override ToString for employee-specific representation
        /// </summary>
        public override string ToString()
        {
            return $"Employee: {Name}, ID: {EmployeeId}, {Position} in {Department}";
        }

        // Employee-specific methods
        /// <summary>
        /// Work method - employee-specific behavior
        /// </summary>
        public virtual void Work()
        {
            Console.WriteLine($"💼 {Name} is working as a {Position} in {Department}");
        }

        /// <summary>
        /// Attend a meeting
        /// </summary>
        public virtual void AttendMeeting(string meetingTopic)
        {
            Console.WriteLine($"🏢 {Name} is attending a meeting about: {meetingTopic}");
        }

        /// <summary>
        /// Add a skill
        /// </summary>
        public void AddSkill(string skill)
        {
            if (string.IsNullOrWhiteSpace(skill))
                throw new ArgumentException("Skill cannot be empty", nameof(skill));

            if (!skills.Contains(skill))
            {
                skills.Add(skill);
                Console.WriteLine($"✅ {Name} learned new skill: {skill}");
            }
            else
            {
                Console.WriteLine($"⚠️ {Name} already has the skill: {skill}");
            }
        }

        /// <summary>
        /// Remove a skill
        /// </summary>
        public void RemoveSkill(string skill)
        {
            if (skills.Remove(skill))
            {
                Console.WriteLine($"🗑️ {Name} removed skill: {skill}");
            }
            else
            {
                Console.WriteLine($"⚠️ {Name} doesn't have the skill: {skill}");
            }
        }

        /// <summary>
        /// Get a promotion
        /// </summary>
        public virtual void GetPromotion(string newPosition, decimal salaryIncrease)
        {
            var oldPosition = Position;
            var oldSalary = Salary;

            Position = newPosition;
            Salary += salaryIncrease;

            Console.WriteLine($"🎉 Congratulations {Name}!");
            Console.WriteLine($"   Promoted from {oldPosition} to {newPosition}");
            Console.WriteLine($"   Salary increased from ${oldSalary:N2} to ${Salary:N2}");
        }

        /// <summary>
        /// Request time off
        /// </summary>
        public virtual void RequestTimeOff(DateTime startDate, DateTime endDate, string reason)
        {
            if (startDate > endDate)
                throw new ArgumentException("Start date cannot be after end date");

            var days = (endDate - startDate).Days + 1;
            Console.WriteLine($"📅 {Name} requested {days} days off from {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}");
            Console.WriteLine($"   Reason: {reason}");
        }

        /// <summary>
        /// Submit a report
        /// </summary>
        public virtual void SubmitReport(string reportTitle)
        {
            Console.WriteLine($"📊 {Name} submitted report: {reportTitle}");
        }

        /// <summary>
        /// Calculate annual bonus based on salary and years of service
        /// </summary>
        public virtual decimal CalculateBonus()
        {
            var baseBonus = Salary * 0.05m; // 5% of salary
            var serviceBonus = YearsOfService * 0.01m * Salary; // 1% per year of service
            return Math.Round(baseBonus + serviceBonus, 2);
        }

        /// <summary>
        /// Check if eligible for retirement (simplified criteria)
        /// </summary>
        public bool IsEligibleForRetirement()
        {
            return Age >= 65 || (Age >= 55 && YearsOfService >= 30);
        }

        /// <summary>
        /// Retire the employee
        /// </summary>
        public void Retire()
        {
            if (IsEligibleForRetirement())
            {
                Console.WriteLine($"🏖️ {Name} is retiring after {YearsOfService} years of service!");
                Console.WriteLine($"   Enjoy your retirement from {Department}!");
            }
            else
            {
                Console.WriteLine($"❌ {Name} is not eligible for retirement yet.");
                Console.WriteLine($"   Requirements: Age 65+ OR (Age 55+ AND 30+ years of service)");
                Console.WriteLine($"   Current: Age {Age}, {YearsOfService} years of service");
            }
        }
    }
}