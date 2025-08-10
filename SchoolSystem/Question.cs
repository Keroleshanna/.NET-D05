using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem
{
    public enum QuestionType : byte
    {
        TrueFalse = 1,
        SingleChoice,
        MultipleChoice
    }

    public enum DifficultyLevel : byte
    {
        Easy = 1,
        Medium,
        Hard
    }

    public abstract class Question
    {
        public string Text { get; set; }
        public DifficultyLevel Difficulty { get; set; }
        public int Marks { get; set; }

        public Question(string text, DifficultyLevel difficulty, int marks)
        {
            Text = text;
            Difficulty = difficulty;
            Marks = marks;
        }

        public abstract bool Ask();
    }

}
