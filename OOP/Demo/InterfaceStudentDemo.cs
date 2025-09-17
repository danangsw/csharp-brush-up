using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP
{
    /// <summary>
    /// Comprehensive demonstration of Interface implementations in Student class
    /// Coverage: >80% of all interface methods and properties
    /// </summary>
    public class InterfaceStudentDemo
    {
        // Comprehensive Demo - Full >80% coverage testing
        public static void RunComprehensiveDemo()
        {
            Console.WriteLine("🎯 === COMPREHENSIVE INTERFACE STUDENTS DEMO ===");
            Console.WriteLine("Coverage: >80% of Interface Implementation\n");

            try
            {
                // Create test students
                var students = CreateTestStudents();

                // Run comprehensive demos
                DemonstrateILearnableInterface(students);
                DemonstrateIExaminableInterface(students);
                DemonstrateIGradeableInterface(students);
                DemonstratePolymorphismWithInterfaces(students);
                DemonstrateEdgeCasesAndErrorHandling(students[0]);
                DemonstratePerformanceAnalysis(students);
                DemonstrateStudentLifecycle(students[1]);

                Console.WriteLine("✅ Interface demonstration completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Demo error: {ex.Message}");
            }

            Console.WriteLine("\n🎉 === COMPREHENSIVE DEMO COMPLETE ===");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        #region Test Data Creation
        private static List<Student> CreateTestStudents()
        {
            Console.WriteLine("👥 === CREATING TEST STUDENTS ===");

            var students = new List<Student>
            {
                new Student("Alice Johnson", 20, "STU001", "Computer Science"),
                new Student("Bob Williams", 19, "STU002", "Mathematics"),
                new Student("Carol Davis", 21, "STU003", "Physics"),
                new Student("David Brown", 22, "STU004", "Engineering")
            };

            foreach (var student in students)
            {
                Console.WriteLine($"✅ Created: {student}");
            }
            Console.WriteLine();
            return students;
        }
        #endregion

        #region ILearnable Interface Demo
        private static void DemonstrateILearnableInterface(List<Student> students)
        {
            Console.WriteLine("🧠 === ILearnable INTERFACE COMPREHENSIVE DEMO ===");

            var alice = students[0];
            var bob = students[1];

            // Test Learn method with various skills
            Console.WriteLine("📚 Learning Skills Demonstration:");
            alice.Learn("C# Programming", 15);
            alice.Learn("Data Structures", 20);
            alice.Learn("Algorithm Design", 25);
            alice.Learn("Database Management", 18);

            // Test duplicate learning (should handle gracefully)
            alice.Learn("C# Programming", 10); // Should indicate already learned

            bob.Learn("Calculus", 30);
            bob.Learn("Linear Algebra", 25);
            bob.Learn("Statistics", 20);

            // Test HasLearned method
            Console.WriteLine("\n🔍 Skill Verification:");
            Console.WriteLine($"Alice has learned C#: {alice.HasLearned("C# Programming")}");
            Console.WriteLine($"Alice has learned Python: {alice.HasLearned("Python")}");
            Console.WriteLine($"Bob has learned Calculus: {bob.HasLearned("Calculus")}");

            // Test GetLearnedSkills method
            Console.WriteLine("\n📝 Learned Skills Summary:");
            DisplayLearnedSkills(alice);
            DisplayLearnedSkills(bob);

            // Test LearningHours property (getter and setter)
            Console.WriteLine("\n⏰ Learning Hours Management:");
            Console.WriteLine($"Alice's learning hours: {alice.LearningHours}");
            Console.WriteLine($"Bob's learning hours: {bob.LearningHours}");

            // Test setting learning hours directly
            alice.LearningHours += 50; // Additional self-study
            Console.WriteLine($"After additional study, Alice's hours: {alice.LearningHours}");

            // Test negative hours protection
            alice.LearningHours = -10; // Should be set to 0
            Console.WriteLine($"After setting negative hours, Alice's hours: {alice.LearningHours}");

            Console.WriteLine();
        }

        private static void DisplayLearnedSkills(ILearnable learner)
        {
            var student = learner as Student;
            var skills = learner.GetLearnedSkills();
            Console.WriteLine($"{student?.Name ?? "Unknown"} learned skills ({skills.Count}): {string.Join(", ", skills)}");
        }
        #endregion

        #region IExaminable Interface Demo
        private static void DemonstrateIExaminableInterface(List<Student> students)
        {
            Console.WriteLine("📝 === IExaminable INTERFACE COMPREHENSIVE DEMO ===");

            var carol = students[2];
            var david = students[3];

            // Test PrepareForExam method with various scenarios
            Console.WriteLine("📖 Exam Preparation Demonstration:");
            carol.PrepareForExam("Physics Midterm", 25);
            carol.PrepareForExam("Quantum Mechanics", 30);
            carol.PrepareForExam("Thermodynamics", 20);

            david.PrepareForExam("Engineering Ethics", 15);
            david.PrepareForExam("Structural Analysis", 35);
            david.PrepareForExam("Materials Science", 28);

            // Test GetExamResults method
            Console.WriteLine("\n📊 Exam Results Analysis:");
            DisplayExamResults(carol);
            DisplayExamResults(david);

            // Test HasPassed method with different passing grades
            Console.WriteLine("\n✅ Pass/Fail Analysis:");
            TestExamPassStatus(carol, "Physics Midterm", 2.0);
            TestExamPassStatus(carol, "Quantum Mechanics", 2.5);
            TestExamPassStatus(carol, "Thermodynamics", 3.0);

            TestExamPassStatus(david, "Engineering Ethics", 2.0);
            TestExamPassStatus(david, "Structural Analysis", 3.5);
            TestExamPassStatus(david, "Materials Science", 2.5);

            // Test with non-existent exam
            Console.WriteLine($"Carol passed non-existent exam: {carol.HasPassed("Non-existent Exam")}");

            Console.WriteLine();
        }

        private static void DisplayExamResults(IExaminable examinee)
        {
            var student = examinee as Student;
            var results = examinee.GetExamResults();
            Console.WriteLine($"{student?.Name ?? "Unknown"} exam results:");
            foreach (var result in results)
            {
                Console.WriteLine($"  📋 {result.Key}: {result.Value:F1} ({(result.Value >= 2.0 ? "PASS" : "FAIL")})");
            }
        }

        private static void TestExamPassStatus(IExaminable examinee, string examName, double passingGrade)
        {
            var student = examinee as Student;
            var passed = examinee.HasPassed(examName, passingGrade);
            Console.WriteLine($"  {student?.Name ?? "Unknown"} passed {examName} (≥{passingGrade:F1}): {passed}");
        }
        #endregion

        #region IGradeable Interface Demo
        private static void DemonstrateIGradeableInterface(List<Student> students)
        {
            Console.WriteLine("📊 === IGradeable INTERFACE COMPREHENSIVE DEMO ===");

            var alice = students[0];
            var bob = students[1];

            // Set up courses for testing
            SetupCoursesForGrading(alice);
            SetupCoursesForGrading(bob);

            // Test AddGrade and GetGrade methods
            Console.WriteLine("📝 Grade Management Demonstration:");
            TestGradeOperations(alice);
            TestGradeOperations(bob);

            // Test CalculatedGPA method
            Console.WriteLine("\n🎯 GPA Calculation:");
            foreach (var student in students.Take(2))
            {
                Console.WriteLine($"{student.Name} calculated GPA: {student.CalculatedGPA():F2}");
                Console.WriteLine($"{student.Name} actual GPA: {student.GPA:F2}");
            }

            // Test IsPassingGrade method with various grades
            Console.WriteLine("\n✅ Passing Grade Analysis:");
            TestPassingGrades(alice);

            // Test PerformanceLevel property
            Console.WriteLine("\n🏆 Performance Level Analysis:");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name} (GPA: {student.GPA:F2}) - Performance: {student.PerformanceLevel}");
            }

            Console.WriteLine();
        }

        private static void SetupCoursesForGrading(Student student)
        {
            var courses = new[] { "Math 101", "Science 201", "English 102", "History 150" };
            foreach (var course in courses)
            {
                student.EnrollInCourse(course);
            }
        }

        private static void TestGradeOperations(Student student)
        {
            Console.WriteLine($"\n{student.Name} Grade Operations:");

            // Add grades
            student.AddGrade("Math 101", 3.5);
            student.AddGrade("Science 201", 3.8);
            student.AddGrade("English 102", 3.2);
            student.AddGrade("History 150", 2.9);

            // Get grades
            foreach (var course in student.Courses)
            {
                var grade = student.GetGrade(course);
                Console.WriteLine($"  📚 {course}: {grade?.ToString("F1") ?? "No grade"}");
            }
        }

        private static void TestPassingGrades(IGradeable gradeable)
        {
            var grades = new[] { 0.5, 1.5, 2.0, 2.5, 3.0, 3.5, 4.0 };
            var student = gradeable as Student;

            Console.WriteLine($"{student?.Name ?? "Unknown"} passing grade tests:");
            foreach (var grade in grades)
            {
                var isPassing = gradeable.IsPassingGrade(grade);
                Console.WriteLine($"  Grade {grade:F1}: {(isPassing ? "PASSING" : "FAILING")}");
            }
        }
        #endregion

        #region Polymorphism Demo
        private static void DemonstratePolymorphismWithInterfaces(List<Student> students)
        {
            Console.WriteLine("🔄 === INTERFACE POLYMORPHISM DEMONSTRATION ===");

            // Treat students as different interface types
            Console.WriteLine("📚 Polymorphic ILearnable operations:");
            foreach (ILearnable learner in students)
            {
                learner.Learn($"Advanced {(learner as Student)?.Major}", 40);
                Console.WriteLine($"  Learning hours: {learner.LearningHours}");
            }

            Console.WriteLine("\n📝 Polymorphic IExaminable operations:");
            foreach (IExaminable examinee in students)
            {
                var student = examinee as Student;
                examinee.PrepareForExam($"{student?.Major} Final", 50);
            }

            Console.WriteLine("\n📊 Polymorphic IGradeable operations:");
            foreach (IGradeable gradeable in students)
            {
                var student = gradeable as Student;
                Console.WriteLine($"  {student?.Name} performance: {gradeable.PerformanceLevel}");
            }

            Console.WriteLine();
        }
        #endregion

        #region Error Handling Demo
        private static void DemonstrateEdgeCasesAndErrorHandling(Student student)
        {
            Console.WriteLine("⚠️ === ERROR HANDLING & EDGE CASES DEMO ===");

            Console.WriteLine("Testing ILearnable error handling:");
            try
            {
                student.Learn("", 10); // Empty skill
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"✅ Caught expected error: {ex.Message}");
            }

            try
            {
                student.Learn(null!, 10); // Null skill
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"✅ Caught expected error: {ex.Message}");
            }

            Console.WriteLine("\nTesting IExaminable error handling:");
            try
            {
                student.PrepareForExam("", 10); // Empty exam name
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"✅ Caught expected error: {ex.Message}");
            }

            try
            {
                student.PrepareForExam("Valid Exam", -5); // Negative hours
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"✅ Caught expected error: {ex.Message}");
            }

            Console.WriteLine("\nTesting boundary conditions:");
            // Test with zero hours
            student.PrepareForExam("Zero Hours Exam", 0);

            // Test with very high hours
            student.Learn("Intensive Skill", 1000);
            Console.WriteLine($"Learning hours after intensive learning: {student.LearningHours}");

            Console.WriteLine();
        }
        #endregion

        #region Performance Analysis
        private static void DemonstratePerformanceAnalysis(List<Student> students)
        {
            Console.WriteLine("📈 === PERFORMANCE ANALYSIS DEMO ===");

            // Analyze learning efficiency
            Console.WriteLine("Learning Efficiency Analysis:");
            foreach (var student in students)
            {
                var skills = student.GetLearnedSkills();
                var hoursPerSkill = skills.Count > 0 ? (double)student.LearningHours / skills.Count : 0;
                Console.WriteLine($"  {student.Name}: {skills.Count} skills, {student.LearningHours} hours, {hoursPerSkill:F1} hours/skill");
            }

            // Analyze exam performance
            Console.WriteLine("\nExam Performance Analysis:");
            foreach (var student in students)
            {
                var examResults = student.GetExamResults();
                if (examResults.Count > 0)
                {
                    var avgExamScore = examResults.Values.Average();
                    var passedExams = examResults.Count(r => student.HasPassed(r.Key));
                    var passRate = (double)passedExams / examResults.Count * 100;

                    Console.WriteLine($"  {student.Name}: {examResults.Count} exams, avg score {avgExamScore:F2}, {passRate:F1}% pass rate");
                }
            }

            // Overall performance ranking
            Console.WriteLine("\nOverall Performance Ranking:");
            var rankedStudents = students
                .Where(s => s.GPA > 0)
                .OrderByDescending(s => s.GPA)
                .ThenByDescending(s => s.LearningHours)
                .ToList();

            for (int i = 0; i < rankedStudents.Count; i++)
            {
                var student = rankedStudents[i];
                Console.WriteLine($"  #{i + 1}: {student.Name} - GPA: {student.GPA:F2}, Level: {student.PerformanceLevel}");
            }

            Console.WriteLine();
        }
        #endregion

        #region Student Lifecycle Demo
        private static void DemonstrateStudentLifecycle(Student student)
        {
            Console.WriteLine($"🎓 === STUDENT LIFECYCLE DEMO: {student.Name} ===");

            // Phase 1: Enrollment and initial learning
            Console.WriteLine("Phase 1: Enrollment & Initial Learning");
            student.EnrollInCourse("Introduction to Programming");
            student.EnrollInCourse("Discrete Mathematics");
            student.Learn("Programming Fundamentals", 30);
            student.Learn("Mathematical Logic", 25);

            // Phase 2: Study and exam preparation
            Console.WriteLine("\nPhase 2: Study & Exam Preparation");
            student.PrepareForExam("Programming Midterm", 20);
            student.PrepareForExam("Math Midterm", 25);
            student.Study("Data Structures");

            // Phase 3: Taking exams and receiving grades
            Console.WriteLine("\nPhase 3: Exams & Grading");
            student.TakeExam("Introduction to Programming");
            student.TakeExam("Discrete Mathematics");

            // Phase 4: Advanced learning
            Console.WriteLine("\nPhase 4: Advanced Learning");
            student.Learn("Advanced Algorithms", 40);
            student.Learn("Software Engineering", 35);
            student.EnrollInCourse("Advanced Programming");
            student.PrepareForExam("Advanced Programming Final", 45);

            // Phase 5: Final assessment
            Console.WriteLine("\nPhase 5: Final Assessment");
            Console.WriteLine($"Final GPA: {student.GPA:F2}");
            Console.WriteLine($"Performance Level: {student.PerformanceLevel}");
            Console.WriteLine($"Total Learning Hours: {student.LearningHours}");
            Console.WriteLine($"Skills Acquired: {string.Join(", ", student.GetLearnedSkills())}");
            Console.WriteLine($"Can Graduate: {student.CanGraduate()}");

            // Attempt graduation
            if (student.CanGraduate())
            {
                student.Graduate();
            }
            else
            {
                Console.WriteLine("Additional courses needed for graduation...");
                // Add more courses to meet requirements
                var additionalCourses = new[] { "Course1", "Course2", "Course3", "Course4", "Course5", "Course6" };
                foreach (var course in additionalCourses)
                {
                    student.EnrollInCourse(course);
                    student.AddGrade(course, 3.0); // Add decent grades
                }
                student.Graduate(); // Try again
            }

            Console.WriteLine();
        }
        #endregion

        #region Utility Methods
        // Quick Interface Test - Rapid functionality verification
        public static void RunQuickInterfaceTest()
        {
            Console.WriteLine("🚀 === QUICK INTERFACE TEST ===");

            var testStudent = new Student("Test Student", 20, "TEST001", "Computer Science");

            // Quick test of each interface
            Console.WriteLine("ILearnable test:");
            testStudent.Learn("Quick Skill", 5);
            Console.WriteLine($"Has learned: {testStudent.HasLearned("Quick Skill")}");

            Console.WriteLine("\nIExaminable test:");
            testStudent.PrepareForExam("Quick Exam", 10);
            Console.WriteLine($"Exam results count: {testStudent.GetExamResults().Count}");

            Console.WriteLine("\nIGradeable test:");
            testStudent.EnrollInCourse("Test Course");
            testStudent.AddGrade("Test Course", 3.5);
            Console.WriteLine($"Performance level: {testStudent.PerformanceLevel}");

            Console.WriteLine("✅ Quick test completed!\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        #endregion

        public static void Run()
        {
            Console.WriteLine("Choose demo type:");
            Console.WriteLine("1. Comprehensive Demo (>80% coverage)");
            Console.WriteLine("2. Quick Interface Test");
            Console.Write("Enter choice (1 or 2): ");
            string input = Console.ReadLine() ?? "1";
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    RunComprehensiveDemo();
                    break;
                case "2":
                    RunQuickInterfaceTest();
                    break;
                default:
                    Console.WriteLine("Running comprehensive demo by default...\n");
                    RunQuickInterfaceTest();
                    break;
            }
        }
    }
}