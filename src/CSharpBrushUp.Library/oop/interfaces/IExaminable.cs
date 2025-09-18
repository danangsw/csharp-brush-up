using System;

namespace CSharpBrushUp.Library.OOP
{
    /// <summary>
    /// Interface defining examinable behavior
    /// </summary>
    public interface IExaminable
    {
        void PrepareForExam(string examName, int studyHours);
        Dictionary<string, double> GetExamResults();
        bool HasPassed(string examName, double passingGrade = 2.0);
    }
}