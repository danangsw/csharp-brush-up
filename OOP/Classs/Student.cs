using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;

namespace OOP
{
    /// <summary>
    /// Student class that inherits from Person
    /// Demonstrates inheritance, method overriding, and additional properties
    /// </summary>
    public class Student : Person, ILearnable, IExaminable, IGradeable
    {
        // Additional fields specific to Student
        private string studentId = string.Empty;
        private string major = string.Empty;
        private List<string> courses = new List<string>();
        private Dictionary<string, double> grades = new Dictionary<string, double>();

        private List<string> learnedSkills = new List<string>();
        private int learningHours = 0;
        private Dictionary<string, double> examResults = new Dictionary<string, double>();

        public int LearningHours
        {
            get { return learningHours; }
            set { learningHours = Math.Max(0, value); } // Ensure non-negative
        }

        public string PerformanceLevel
        {
            get
            {
                if (GPA >= 3.5) return "Excellent";
                if (GPA >= 3.0) return "Good";
                if (GPA >= 2.0) return "Average";
                return "Poor";
            }
        }

        // Additional properties
        public string StudentId
        {
            get { return studentId; }
            set { studentId = value ?? throw new ArgumentNullException(nameof(value), "Student ID cannot be null"); }
        }

        public string Major
        {
            get { return major; }
            set { major = value ?? throw new ArgumentNullException(nameof(value), "Major cannot be null"); }
        }

        public List<string> Courses
        {
            get { return new List<string>(courses); } // Return a copy to maintain encapsulation
        }

        public double GPA => grades.Count > 0 ? grades.Values.Average() : 0.0;

        // Constructors
        public Student(string name, int age, string studentId, string major)
            : base(name, age) // Call parent constructor
        {
            StudentId = studentId;
            Major = major;
        }

        public Student(string name, DateTime dateOfBirth, string studentId, string major)
            : base(name, dateOfBirth) // Call parent constructor
        {
            StudentId = studentId;
            Major = major;
        }

        // Default constructor
        public Student() : base("Unknown Student", 18)
        {
            StudentId = "STU000";
            Major = "Undeclared";
        }

        // ILearnable implementation
        public void Learn(string skill, int hours)
        {
            if (string.IsNullOrWhiteSpace(skill))
                throw new ArgumentException("Skill cannot be empty", nameof(skill));
            if (!HasLearned(skill))
            {
                learnedSkills.Add(skill);
                LearningHours += hours; // Assume each skill takes 1 hour to learn
                Console.WriteLine($"{Name} has learned a new skill: {skill}");
            }
            else
            {
                Console.WriteLine($"{Name} already learned the skill: {skill}");
            }
        }

        public List<string> GetLearnedSkills()
        {
            return new List<string>(learnedSkills); // Return a copy to maintain encapsulation
        }

        public bool HasLearned(string skill)
        {
            return learnedSkills.Contains(skill);
        }

        // IEXaminable implementation
        public Dictionary<string, double> GetExamResults()
        {
            // Return a copy to maintain encapsulation
            return new Dictionary<string, double>(examResults);
        }

        public bool HasPassed(string examName, double passingGrade = 2.0)
        {
            return examResults.TryGetValue(examName, out double grade) && grade >= passingGrade;
        }

        public void PrepareForExam(string examName, int studyHours)
        {
            if (string.IsNullOrWhiteSpace(examName))
                throw new ArgumentException("Exam name cannot be empty", nameof(examName));
            if (studyHours < 0)
                throw new ArgumentException("Study hours cannot be negative", nameof(studyHours));
            LearningHours += studyHours;
            Console.WriteLine($"{Name} prepared for {examName} with {studyHours} hours of study,\nTotal learning hours now {LearningHours}.");
            // Simulate exam result based on study hours
            var random = new Random();
            double grade = Math.Min(4.0, Math.Round((studyHours / 10.0) + random.NextDouble(), 1)); // Simple formula
            examResults[examName] = grade;
            Console.WriteLine($"{Name} {examName} exam result: {grade:F1} - Exam results: {(this.IsPassingGrade(grade) ? "PASSED" : "FAILED")}");
        }

        // Implement IGradeable
        public double CalculatedGPA()
        {
            return GPA; // Use existing GPA property
        }

        public bool IsPassingGrade(double grade)
        {
            return grade >= 2.0; // D or better
        }

        // Method overrides
        /// <summary>
        /// Override PersonInfo to include student-specific information
        /// </summary>
        public override void PersonInfo()
        {
            base.PersonInfo(); // Call parent method first
            Console.WriteLine($"Student ID: {StudentId}");
            Console.WriteLine($"Major: {Major}");
            Console.WriteLine($"Courses Enrolled: {courses.Count}");
            Console.WriteLine($"Current GPA: {GPA:F2}");
        }

        /// <summary>
        /// Override Greet to include student-specific greeting
        /// </summary>
        public override string Greet()
        {
            return $"{base.Greet()} I'm studying {Major} with student ID {StudentId}.";
        }

        /// <summary>
        /// Override CelebrateBirthday with student-specific celebration
        /// </summary>
        public override void CelebrateBirthday()
        {
            base.CelebrateBirthday(); // Call parent method
            Console.WriteLine($"🎓 Another year closer to graduation in {Major}!");
        }

        /// <summary>
        /// Override ToString for student-specific representation
        /// </summary>
        public override string ToString()
        {
            return $"Student: {Name}, Age: {Age}, ID: {StudentId}, Major: {Major}";
        }

        // Student-specific methods
        /// <summary>
        /// Enroll in a new course
        /// </summary>
        public void EnrollInCourse(string courseName)
        {
            if (string.IsNullOrWhiteSpace(courseName))
                throw new ArgumentException("Course name cannot be empty", nameof(courseName));

            if (!courses.Contains(courseName))
            {
                courses.Add(courseName);
                Console.WriteLine($"📚 {Name} enrolled in {courseName}");
            }
            else
            {
                Console.WriteLine($"⚠️ {Name} is already enrolled in {courseName}");
            }
        }

        /// <summary>
        /// Drop a course
        /// </summary>
        public void DropCourse(string courseName)
        {
            if (courses.Remove(courseName))
            {
                grades.Remove(courseName); // Remove grade if exists
                Console.WriteLine($"📤 {Name} dropped {courseName}");
            }
            else
            {
                Console.WriteLine($"⚠️ {Name} is not enrolled in {courseName}");
            }
        }

        /// <summary>
        /// Add a grade for a course
        /// </summary>
        public void AddGrade(string courseName, double grade)
        {
            if (!courses.Contains(courseName))
                throw new InvalidOperationException($"Student is not enrolled in {courseName}");

            if (grade < 0.0 || grade > 4.0)
                throw new ArgumentException("Grade must be between 0.0 and 4.0", nameof(grade));

            grades[courseName] = grade;
            Console.WriteLine($"✅ Grade {grade:F1} added for {courseName}");
        }

        /// <summary>
        /// Get grade for a specific course
        /// </summary>
        public double? GetGrade(string courseName)
        {
            return grades.TryGetValue(courseName, out var grade) ? grade : null;
        }

        /// <summary>
        /// Study method - student-specific behavior
        /// </summary>
        public virtual void Study(string subject)
        {
            Console.WriteLine($"📖 {Name} is studying {subject}");
        }

        /// <summary>
        /// Take an exam - student-specific behavior
        /// </summary>
        public virtual void TakeExam(string courseName)
        {
            if (!courses.Contains(courseName))
            {
                Console.WriteLine($"❌ {Name} cannot take exam for {courseName} - not enrolled");
                return;
            }

            Console.WriteLine($"📝 {Name} is taking an exam for {courseName}");

            // Simulate random grade for demo purposes
            var random = new Random();
            var grade = Math.Round(random.NextDouble() * 4.0, 1);
            AddGrade(courseName, grade);
            Console.WriteLine($"{Name} {courseName} exam result: {grade:F1} - Exam results: {(this.IsPassingGrade(grade) ? "PASSED" : "FAILED")}");
        }

        /// <summary>
        /// Check if student can graduate based on GPA and course count
        /// </summary>
        public bool CanGraduate()
        {
            return courses.Count >= 8 && GPA >= 2.0; // Simple graduation requirements
        }

        /// <summary>
        /// Graduate the student
        /// </summary>
        public void Graduate()
        {
            if (CanGraduate())
            {
                Console.WriteLine($"🎓 Congratulations {Name}! You graduated with a {GPA:F2} GPA in {Major}!");
            }
            else
            {
                Console.WriteLine($"❌ {Name} cannot graduate yet. Requirements: 8+ courses and 2.0+ GPA");
                Console.WriteLine($"   Current: {courses.Count} courses, {GPA:F2} GPA");
            }
        }
    }
}