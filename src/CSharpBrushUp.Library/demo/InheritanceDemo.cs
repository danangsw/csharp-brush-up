using CSharpBrushUp.Library.OOP;
using System;

namespace CSharpBrushUp.Library.Demo
{
    public class InheritanceDemo
    {
        public static void Run()
        {
            Console.WriteLine("🎯 === INHERITANCE DEMONSTRATION ===\n");

            try
            {
                // Demonstrate basic inheritance hierarchy
                DemonstratePerson();
                DemonstrateStudent();
                DemonstrateEmployee();
                DemonstrateTeacher();
                DemonstratePolymorphism();
                DemonstrateTypeChecking();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }

            Console.WriteLine("\n🎉 === INHERITANCE DEMO COMPLETE ===");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        static void DemonstratePerson()
        {
            Console.WriteLine("👤 === PERSON CLASS (BASE CLASS) ===");
            var person = new Person("John Doe", 30);
            person.PersonInfo();
            Console.WriteLine(person.Greet());
            person.CelebrateBirthday();
            Console.WriteLine();
        }

        static void DemonstrateStudent()
        {
            Console.WriteLine("🎓 === STUDENT CLASS (INHERITS FROM PERSON) ===");
            var student = new Student("Alice Johnson", 20, "STU12345", "Computer Science");

            // Show inherited behavior
            student.PersonInfo(); // Overridden method
            Console.WriteLine(student.Greet()); // Overridden method

            // Show student-specific behavior
            student.EnrollInCourse("Data Structures");
            student.EnrollInCourse("Algorithms");
            student.EnrollInCourse("Database Systems");
            student.Study("Programming");
            student.TakeExam("Data Structures");
            student.TakeExam("Algorithms");

            Console.WriteLine($"Can graduate: {student.CanGraduate()}");
            Console.WriteLine();
        }

        static void DemonstrateEmployee()
        {
            Console.WriteLine("💼 === EMPLOYEE CLASS (INHERITS FROM PERSON) ===");
            var employee = new Employee("Bob Smith", 35, "EMP98765", "IT", "Software Developer", 75000);

            // Show inherited behavior
            employee.PersonInfo(); // Overridden method
            Console.WriteLine(employee.Greet()); // Overridden method

            // Show employee-specific behavior
            employee.AddSkill("C#");
            employee.AddSkill("SQL");
            employee.Work();
            employee.AttendMeeting("Sprint Planning");
            employee.SubmitReport("Monthly Progress Report");

            var bonus = employee.CalculateBonus();
            Console.WriteLine($"Annual bonus: ${bonus:N2}");

            employee.GetPromotion("Senior Software Developer", 10000);
            Console.WriteLine();
        }

        static void DemonstrateTeacher()
        {
            Console.WriteLine("👩‍🏫 === TEACHER CLASS (MULTI-LEVEL INHERITANCE: PERSON -> EMPLOYEE -> TEACHER) ===");
            var teacher = new Teacher("Dr. Sarah Wilson", 40, "TCH55555", "Mathematics", "Room 205", 60000);
            teacher.StudentsCount = 25;
            teacher.YearsTeaching = 8;

            // Show inherited behavior from Person and Employee
            teacher.PersonInfo(); // Overridden at each level
            Console.WriteLine(teacher.Greet()); // Overridden method

            // Show teacher-specific behavior
            teacher.TeachLesson("Calculus Integration");
            teacher.AssignHomework("Complete exercises 1-10", DateTime.Now.AddDays(3));
            teacher.GradeAssignments(1);
            teacher.HoldOfficeHours("2:00 PM - 4:00 PM");
            teacher.ConductExam("Midterm");
            teacher.ProfessionalDevelopment("Online Learning Platforms");

            var teacherBonus = teacher.CalculateBonus();
            Console.WriteLine($"Teacher's annual bonus: ${teacherBonus:N2}");

            teacher.ApplyForTenure();
            Console.WriteLine();
        }

        static void DemonstratePolymorphism()
        {
            Console.WriteLine("🔄 === POLYMORPHISM DEMONSTRATION ===");

            // Create array of Person references pointing to different derived objects
            Person[] people = {
                new Person("Generic Person", 25),
                new Student("Student Mike", 19, "STU11111", "Physics"),
                new Employee("Employee Jane", 30, "EMP22222", "HR", "Manager", 65000),
                new Teacher("Teacher Mark", 45, "TCH33333", "English", "Room 101", 55000)
            };

            Console.WriteLine("Demonstrating polymorphic behavior with Greet() method:");
            foreach (var person in people)
            {
                Console.WriteLine($"- {person.GetType().Name}: {person.Greet()}");
            }

            Console.WriteLine("\nDemonstrating polymorphic behavior with CelebrateBirthday() method:");
            foreach (var person in people)
            {
                Console.WriteLine($"\n{person.GetType().Name} celebrating birthday:");
                person.CelebrateBirthday();
            }
            Console.WriteLine();
        }

        static void DemonstrateTypeChecking()
        {
            Console.WriteLine("🔍 === TYPE CHECKING AND CASTING ===");

            Person[] people = {
                new Student("Emma Watson", 22, "STU99999", "Literature"),
                new Employee("James Bond", 35, "EMP00007", "Security", "Agent", 85000),
                new Teacher("Prof. McGonagall", 50, "TCH77777", "Transfiguration", "Room 142", 70000)
            };

            foreach (var person in people)
            {
                Console.WriteLine($"\nAnalyzing {person.Name} ({person.GetType().Name}):");

                // Type checking with 'is' operator
                if (person is Student student)
                {
                    Console.WriteLine($"  📚 Student in {student.Major} with ID {student.StudentId}");
                    Console.WriteLine($"  📊 Current GPA: {student.GPA:F2}");
                }
                else if (person is Teacher teacher)
                {
                    Console.WriteLine($"  👩‍🏫 Teacher of {teacher.Subject} in {teacher.Classroom}");
                    Console.WriteLine($"  👥 Teaching {teacher.StudentsCount} students");
                    Console.WriteLine($"  🏆 Tenure eligible: {teacher.IsEligibleForTenure()}");
                }
                else if (person is Employee employee)
                {
                    Console.WriteLine($"  💼 Employee in {employee.Department} as {employee.Position}");
                    Console.WriteLine($"  💰 Salary: ${employee.Salary:N2}");
                    Console.WriteLine($"  🏖️ Retirement eligible: {employee.IsEligibleForRetirement()}");
                }

                // Demonstrate method resolution
                Console.WriteLine($"  💬 Greeting: {person.Greet()}");
            }

            // Demonstrate casting
            Console.WriteLine("\n🔄 === SAFE CASTING DEMONSTRATION ===");
            Person genericPerson = new Student("Cast Test Student", 20, "STU12121", "Engineering");

            // Safe casting with 'as' operator
            Student? castStudent = genericPerson as Student;
            if (castStudent != null)
            {
                Console.WriteLine($"✅ Successfully cast Person to Student: {castStudent.Major}");
                castStudent.EnrollInCourse("Thermodynamics");
            }

            // Attempt invalid cast
            Employee? invalidCast = genericPerson as Employee;
            if (invalidCast == null)
            {
                Console.WriteLine("❌ Cannot cast Student to Employee (expected behavior)");
            }

            Console.WriteLine();
        }
    }
}