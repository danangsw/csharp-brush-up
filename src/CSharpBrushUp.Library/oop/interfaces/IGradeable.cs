using System;

namespace CSharpBrushUp.Library.OOP
{
    public interface IGradeable
    {
        void AddGrade(string subject, double grade);
        double? GetGrade(string subject);
        double CalculatedGPA();
        bool IsPassingGrade(double grade);

        string PerformanceLevel { get; }
    }
}