using System;

namespace OOP
{
    /// <summary>
    /// Teacher class that inherits from Employee
    /// Demonstrates multi-level inheritance (Person -> Employee -> Teacher)
    /// </summary>
    public class Teacher : Employee
    {
        // Additional fields specific to Teacher
        private string subject = string.Empty;
        private string classroom = string.Empty;
        private int studentsCount;
        private int yearsTeaching;

        // Additional properties
        public string Subject
        {
            get { return subject; }
            set { subject = value ?? throw new ArgumentNullException(nameof(value), "Subject cannot be null"); }
        }

        public string Classroom
        {
            get { return classroom; }
            set { classroom = value ?? throw new ArgumentNullException(nameof(value), "Classroom cannot be null"); }
        }

        public int StudentsCount
        {
            get { return studentsCount; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Students count cannot be negative", nameof(value));
                studentsCount = value;
            }
        }

        public int YearsTeaching
        {
            get { return yearsTeaching; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Years teaching cannot be negative", nameof(value));
                yearsTeaching = value;
            }
        }

        // Constructors
        public Teacher(string name, int age, string employeeId, string subject, string classroom, decimal salary)
            : base(name, age, employeeId, "Education", "Teacher", salary)
        {
            Subject = subject;
            Classroom = classroom;
            StudentsCount = 0;
            YearsTeaching = 0;
        }

        public Teacher(string name, DateTime dateOfBirth, string employeeId, string subject, string classroom, decimal salary, DateTime hireDate)
            : base(name, dateOfBirth, employeeId, "Education", "Teacher", salary, hireDate)
        {
            Subject = subject;
            Classroom = classroom;
            StudentsCount = 0;
            YearsTeaching = YearsOfService; // Calculate based on hire date
        }

        // Default constructor
        public Teacher() : base("Unknown Teacher", 30, "TCH000", "Education", "Teacher", 45000)
        {
            Subject = "General Studies";
            Classroom = "Room 101";
            StudentsCount = 20;
            YearsTeaching = 1;
        }

        // Method overrides
        /// <summary>
        /// Override PersonInfo to include teacher-specific information
        /// </summary>
        public override void PersonInfo()
        {
            base.PersonInfo(); // Call parent method (Employee's PersonInfo)
            Console.WriteLine($"Subject: {Subject}");
            Console.WriteLine($"Classroom: {Classroom}");
            Console.WriteLine($"Students Count: {StudentsCount}");
            Console.WriteLine($"Years Teaching: {YearsTeaching}");
        }

        /// <summary>
        /// Override Greet to include teacher-specific greeting
        /// </summary>
        public override string Greet()
        {
            return $"Hello, I'm {Name} and I teach {Subject} in {Classroom}. I have {StudentsCount} students.";
        }

        /// <summary>
        /// Override Work method with teacher-specific implementation
        /// </summary>
        public override void Work()
        {
            Console.WriteLine($"📚 Teacher {Name} is teaching {Subject} to {StudentsCount} students in {Classroom}");
        }

        /// <summary>
        /// Override AttendMeeting with teacher-specific context
        /// </summary>
        public override void AttendMeeting(string meetingTopic)
        {
            Console.WriteLine($"🏫 Teacher {Name} is attending a faculty meeting about: {meetingTopic}");
        }

        /// <summary>
        /// Override ToString for teacher-specific representation
        /// </summary>
        public override string ToString()
        {
            return $"Teacher: {Name}, Subject: {Subject}, Classroom: {Classroom}";
        }

        /// <summary>
        /// Override GetPromotion with teacher-specific implementation
        /// </summary>
        public override void GetPromotion(string newPosition, decimal salaryIncrease)
        {
            base.GetPromotion(newPosition, salaryIncrease);
            Console.WriteLine($"   {Name} continues teaching {Subject} with additional responsibilities");
        }

        /// <summary>
        /// Override CalculateBonus with teacher-specific calculation
        /// </summary>
        public override decimal CalculateBonus()
        {
            var baseBonus = base.CalculateBonus();
            var teachingBonus = YearsTeaching * 500m; // $500 per year of teaching
            var studentBonus = StudentsCount * 10m; // $10 per student
            return Math.Round(baseBonus + teachingBonus + studentBonus, 2);
        }

        // Teacher-specific methods
        /// <summary>
        /// Teach a lesson
        /// </summary>
        public virtual void TeachLesson(string lessonTopic)
        {
            Console.WriteLine($"👩‍🏫 {Name} is teaching a lesson on '{lessonTopic}' in {Classroom}");
            Console.WriteLine($"   Subject: {Subject}, Students: {StudentsCount}");
        }

        /// <summary>
        /// Grade assignments
        /// </summary>
        public virtual void GradeAssignments(int assignmentCount)
        {
            Console.WriteLine($"📝 {Name} is grading {assignmentCount} assignments for {Subject}");
            var totalToGrade = assignmentCount * StudentsCount;
            Console.WriteLine($"   Total assignments to grade: {totalToGrade}");
        }

        /// <summary>
        /// Hold office hours
        /// </summary>
        public virtual void HoldOfficeHours(string timeSlot)
        {
            Console.WriteLine($"🕐 {Name} is holding office hours in {Classroom} during {timeSlot}");
            Console.WriteLine($"   Available for {Subject} questions and tutoring");
        }

        /// <summary>
        /// Assign homework
        /// </summary>
        public virtual void AssignHomework(string homeworkDescription, DateTime dueDate)
        {
            Console.WriteLine($"📋 {Name} assigned homework to {StudentsCount} students:");
            Console.WriteLine($"   Assignment: {homeworkDescription}");
            Console.WriteLine($"   Due Date: {dueDate:yyyy-MM-dd}");
            Console.WriteLine($"   Subject: {Subject}");
        }

        /// <summary>
        /// Conduct exam
        /// </summary>
        public virtual void ConductExam(string examType)
        {
            Console.WriteLine($"📝 {Name} is conducting a {examType} exam for {Subject}");
            Console.WriteLine($"   Location: {Classroom}");
            Console.WriteLine($"   Students taking exam: {StudentsCount}");
        }

        /// <summary>
        /// Update student count (for new semester, etc.)
        /// </summary>
        public void UpdateStudentCount(int newCount)
        {
            var oldCount = StudentsCount;
            StudentsCount = newCount;
            Console.WriteLine($"📊 {Name}'s class size changed from {oldCount} to {newCount} students");
        }

        /// <summary>
        /// Prepare lesson plan
        /// </summary>
        public virtual void PrepareLessonPlan(string topic, int durationMinutes)
        {
            Console.WriteLine($"📚 {Name} is preparing a {durationMinutes}-minute lesson plan on '{topic}'");
            Console.WriteLine($"   Subject: {Subject}");
            Console.WriteLine($"   For {StudentsCount} students in {Classroom}");
        }

        /// <summary>
        /// Participate in professional development
        /// </summary>
        public virtual void ProfessionalDevelopment(string trainingTopic)
        {
            Console.WriteLine($"🎓 {Name} is participating in professional development training:");
            Console.WriteLine($"   Topic: {trainingTopic}");
            Console.WriteLine($"   To improve {Subject} teaching skills");

            // Add skill based on training
            AddSkill($"Advanced {trainingTopic}");
        }

        /// <summary>
        /// Check if eligible for tenure (simplified criteria)
        /// </summary>
        public bool IsEligibleForTenure()
        {
            return YearsTeaching >= 6 && Salary >= 50000;
        }

        /// <summary>
        /// Apply for tenure
        /// </summary>
        public void ApplyForTenure()
        {
            if (IsEligibleForTenure())
            {
                Console.WriteLine($"🏆 {Name} is eligible and applying for tenure!");
                Console.WriteLine($"   Teaching experience: {YearsTeaching} years in {Subject}");
                Console.WriteLine($"   Current salary: ${Salary:N2}");
            }
            else
            {
                Console.WriteLine($"❌ {Name} is not yet eligible for tenure.");
                Console.WriteLine($"   Requirements: 6+ years teaching AND $50,000+ salary");
                Console.WriteLine($"   Current: {YearsTeaching} years, ${Salary:N2} salary");
            }
        }
    }
}