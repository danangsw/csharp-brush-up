using System;
using Xunit;
using FluentAssertions;
using CSharpBrushUp.Library.DSA;    

namespace CSharpBrushUp.Tests.DSA
{
    /// <summary>
    /// Comprehensive unit tests for ClimbStairs class
    /// Tests the dynamic programming solution for climbing stairs problem
    /// </summary>
    public class ClimbStairsTests
    {
        private readonly ClimbStairs _climbStairs;

        public ClimbStairsTests()
        {
            _climbStairs = new ClimbStairs();
        }

        #region Basic Functionality Tests

        [Fact]
        public void Solution1_WithOneStep_ShouldReturnOne()
        {
            // Arrange
            int n = 1;
            int expected = 1;

            // Act
            int result = _climbStairs.Solution1(n);

            // Assert
            result.Should().Be(expected, "there is only 1 way to climb 1 step: [1]");
        }

        [Fact]
        public void Solution1_WithTwoSteps_ShouldReturnTwo()
        {
            // Arrange
            int n = 2;
            int expected = 2;

            // Act
            int result = _climbStairs.Solution1(n);

            // Assert
            result.Should().Be(expected, "there are 2 ways to climb 2 steps: [1,1] or [2]");
        }

        [Fact]
        public void Solution1_WithThreeSteps_ShouldReturnThree()
        {
            // Arrange
            int n = 3;
            int expected = 3;

            // Act
            int result = _climbStairs.Solution1(n);

            // Assert
            result.Should().Be(expected, "there are 3 ways to climb 3 steps: [1,1,1], [1,2], [2,1]");
        }

        [Fact]
        public void Solution1_WithFourSteps_ShouldReturnFive()
        {
            // Arrange
            int n = 4;
            int expected = 5;

            // Act
            int result = _climbStairs.Solution1(n);

            // Assert
            result.Should().Be(expected, "there are 5 ways to climb 4 steps");
        }

        [Fact]
        public void Solution1_WithFiveSteps_ShouldReturnEight()
        {
            // Arrange
            int n = 5;
            int expected = 8;

            // Act
            int result = _climbStairs.Solution1(n);

            // Assert
            result.Should().Be(expected, "there are 8 ways to climb 5 steps (Fibonacci sequence)");
        }

        #endregion

        #region Fibonacci Sequence Tests

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(4, 5)]
        [InlineData(5, 8)]
        [InlineData(6, 13)]
        [InlineData(7, 21)]
        [InlineData(8, 34)]
        [InlineData(9, 55)]
        [InlineData(10, 89)]
        public void Solution1_WithVariousInputs_ShouldFollowFibonacciSequence(int input, int expected)
        {
            // Act
            int result = _climbStairs.Solution1(input);

            // Assert
            result.Should().Be(expected, $"climbing {input} steps should return {expected} ways (Fibonacci pattern)");
        }

        #endregion

        #region Edge Cases and Boundary Tests

        [Fact]
        public void Solution1_WithZeroSteps_ShouldReturnZero()
        {
            // Arrange
            int n = 0;
            int expected = 0;

            // Act
            int result = _climbStairs.Solution1(n);

            // Assert
            result.Should().Be(expected, "zero steps should return zero ways");
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-5)]
        [InlineData(-10)]
        public void Solution1_WithNegativeInput_ShouldReturnNegativeValue(int negativeInput)
        {
            // Act
            int result = _climbStairs.Solution1(negativeInput);

            // Assert
            // Note: The current implementation doesn't handle negative inputs properly
            // This test documents the current behavior - ideally should throw exception
            result.Should().Be(negativeInput, "current implementation returns the negative input as-is");
        }

        #endregion

        #region Performance Tests

        [Theory]
        [InlineData(15, 987)]
        [InlineData(20, 10946)]
        [InlineData(25, 121393)]
        [InlineData(30, 1346269)]
        public void Solution1_WithLargerInputs_ShouldHandleEfficiently(int input, int expected)
        {
            // Act
            var startTime = DateTime.UtcNow;
            int result = _climbStairs.Solution1(input);
            var endTime = DateTime.UtcNow;
            var executionTime = endTime - startTime;

            // Assert
            result.Should().Be(expected, $"should correctly calculate ways for {input} steps");
            executionTime.TotalMilliseconds.Should().BeLessThan(100, "should execute within reasonable time");
        }

        [Fact]
        public void Solution1_WithConstraintMaxValue_ShouldHandleMaxInput()
        {
            // Arrange - Based on problem constraint: 1 <= n <= 45
            int n = 45;
            // Expected value for 45th Fibonacci number (climbing stairs follows Fibonacci pattern)
            long expected = 1836311903; // F(46) = ways to climb 45 steps

            // Act
            int result = _climbStairs.Solution1(n);

            // Assert
            result.Should().Be((int)expected, "should handle maximum constraint value correctly");
        }

        #endregion

        #region Mathematical Property Tests

        [Fact]
        public void Solution1_ShouldSatisfyRecurrenceRelation()
        {
            // Arrange - Test that f(n) = f(n-1) + f(n-2) for various values
            for (int n = 3; n <= 10; n++)
            {
                // Act
                int fn = _climbStairs.Solution1(n);
                int fn_1 = _climbStairs.Solution1(n - 1);
                int fn_2 = _climbStairs.Solution1(n - 2);

                // Assert
                fn.Should().Be(fn_1 + fn_2, $"f({n}) should equal f({n - 1}) + f({n - 2})");
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(15)]
        public void Solution1_ShouldBeConsistent_WhenCalledMultipleTimes(int input)
        {
            // Act
            int result1 = _climbStairs.Solution1(input);
            int result2 = _climbStairs.Solution1(input);
            int result3 = _climbStairs.Solution1(input);

            // Assert
            result1.Should().Be(result2, "should return consistent results");
            result2.Should().Be(result3, "should return consistent results");
            result1.Should().Be(result3, "should return consistent results");
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void Solution1_WithSequentialCalls_ShouldMaintainCorrectState()
        {
            // Arrange & Act - Call method multiple times with different inputs
            var results = new[]
            {
                _climbStairs.Solution1(1),
                _climbStairs.Solution1(2),
                _climbStairs.Solution1(3),
                _climbStairs.Solution1(4),
                _climbStairs.Solution1(5)
            };

            // Assert
            results.Should().BeEquivalentTo(new[] { 1, 2, 3, 5, 8 }, "should maintain correct state across calls");
        }

        #endregion

        #region Documentation Tests

        [Fact]
        public void ClimbStairs_ClassShouldExist()
        {
            // Act & Assert
            _climbStairs.Should().NotBeNull("ClimbStairs class should be instantiable");
            _climbStairs.Should().BeOfType<ClimbStairs>("should be of correct type");
        }

        [Fact]
        public void Solution1_MethodShouldExist()
        {
            // Arrange
            var methodInfo = typeof(ClimbStairs).GetMethod("Solution1");

            // Assert
            methodInfo.Should().NotBeNull("Solution1 method should exist");
            methodInfo!.ReturnType.Should().Be(typeof(int), "should return int");
            methodInfo.GetParameters().Should().HaveCount(1, "should take exactly one parameter");
            methodInfo.GetParameters()[0].ParameterType.Should().Be(typeof(int), "parameter should be int");
        }

        #endregion

        #region Real-World Scenario Tests

        [Fact]
        public void Solution1_ProblemExample1_ShouldWork()
        {
            // Arrange - From problem description: Example 1
            int n = 2;
            int expected = 2;
            string expectedExplanation = "Two ways: 1+1 or 2";

            // Act
            int result = _climbStairs.Solution1(n);

            // Assert
            result.Should().Be(expected, expectedExplanation);
        }

        [Fact]
        public void Solution1_ProblemExample2_ShouldWork()
        {
            // Arrange - From problem description: Example 2
            int n = 3;
            int expected = 3;
            string expectedExplanation = "Three ways: 1+1+1, 1+2, or 2+1";

            // Act
            int result = _climbStairs.Solution1(n);

            // Assert
            result.Should().Be(expected, expectedExplanation);
        }

        #endregion

        #region Stress Tests

        [Fact]
        public void Solution1_WithRepeatedLargeCalls_ShouldRemainStable()
        {
            // Arrange
            const int iterations = 100;
            const int testValue = 20;
            const int expectedResult = 10946;

            // Act & Assert
            for (int i = 0; i < iterations; i++)
            {
                int result = _climbStairs.Solution1(testValue);
                result.Should().Be(expectedResult, $"should remain stable on iteration {i + 1}");
            }
        }

        #endregion

        #region Test Utilities

        /// <summary>
        /// Helper method to verify Fibonacci relationship
        /// </summary>
        private bool VerifyFibonacciRelation(int n, int result)
        {
            if (n <= 2) return result == n;

            int prev1 = _climbStairs.Solution1(n - 1);
            int prev2 = _climbStairs.Solution1(n - 2);
            return result == prev1 + prev2;
        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        public void VerifyFibonacciRelation_ShouldWork(int n)
        {
            // Act
            int result = _climbStairs.Solution1(n);

            // Assert
            VerifyFibonacciRelation(n, result).Should().BeTrue($"result for n={n} should follow Fibonacci relation");
        }

        #endregion
    }
}