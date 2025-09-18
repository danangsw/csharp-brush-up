using System;
using System.Runtime.CompilerServices;

namespace CSharpBrushUp.Library.OOP
{
    /// <summary>
    /// Interface defining learnable behavior
    /// </summary>
    public interface ILearnable
    {
        void Learn(string skill, int hours);
        bool HasLearned(string skill);
        List<string> GetLearnedSkills();

        int LearningHours { get; set; }
    }
}