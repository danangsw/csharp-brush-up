using System;
using DSA.Testing;

namespace TestRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("🧪 === MANUAL TEST RUNNER FOR ClimbStairsTests ===\n");
            
            var testClass = new ClimbStairsTests();
            
            try
            {
                // Run some key tests manually
                Console.WriteLine("Running Solution1_WithOneStep_ShouldReturnOne...");
                testClass.Solution1_WithOneStep_ShouldReturnOne();
                Console.WriteLine("✅ PASSED\n");
                
                Console.WriteLine("Running Solution1_WithTwoSteps_ShouldReturnTwo...");
                testClass.Solution1_WithTwoSteps_ShouldReturnTwo();
                Console.WriteLine("✅ PASSED\n");
                
                Console.WriteLine("Running Solution1_WithThreeSteps_ShouldReturnThree...");
                testClass.Solution1_WithThreeSteps_ShouldReturnThree();
                Console.WriteLine("✅ PASSED\n");
                
                Console.WriteLine("Running Solution1_WithFourSteps_ShouldReturnFive...");
                testClass.Solution1_WithFourSteps_ShouldReturnFive();
                Console.WriteLine("✅ PASSED\n");
                
                Console.WriteLine("Running Solution1_WithFiveSteps_ShouldReturnEight...");
                testClass.Solution1_WithFiveSteps_ShouldReturnEight();
                Console.WriteLine("✅ PASSED\n");
                
                Console.WriteLine("Running Solution1_WithZeroSteps_ShouldReturnZero...");
                testClass.Solution1_WithZeroSteps_ShouldReturnZero();
                Console.WriteLine("✅ PASSED\n");
                
                Console.WriteLine("Running ClimbStairs_ClassShouldExist...");
                testClass.ClimbStairs_ClassShouldExist();
                Console.WriteLine("✅ PASSED\n");
                
                Console.WriteLine("Running Solution1_MethodShouldExist...");
                testClass.Solution1_MethodShouldExist();
                Console.WriteLine("✅ PASSED\n");
                
                Console.WriteLine("🎉 All manual tests completed successfully!");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Test failed: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}