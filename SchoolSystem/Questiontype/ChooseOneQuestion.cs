using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Questiontype
{
    public class SingleChoiceQuestion : Question
    {
        public List<string> Options { get; set; }
        public int CorrectOptionIndex { get; set; }

        public SingleChoiceQuestion(string text, DifficultyLevel difficulty, int marks, List<string> options, int correctIndex)
            : base(text, difficulty, marks)
        {
            Options = options;
            CorrectOptionIndex = correctIndex;
        }

        public override bool Ask()
        {
            Console.WriteLine(Text);
            for (int i = 0; i < Options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Options[i]}");
            }

            Console.Write("Your answer: ");
            if (int.TryParse(Console.ReadLine(), out int answerIndex))
            {
                return answerIndex - 1 == CorrectOptionIndex;
            }
            return false;
        }
    }

}
