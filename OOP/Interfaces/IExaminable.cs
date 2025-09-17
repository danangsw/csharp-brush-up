using System;

namespace OOP
{
    /// <summary>
    /// Interface defining examinable behavior
    /// </summary>
    public interface IExaminable
    {
        void TakeExam(string examName);
        Dictionary<string, double> GetExamResults();
        bool HasPassed(string examName, double passingGrade = 2.0);
    }
}