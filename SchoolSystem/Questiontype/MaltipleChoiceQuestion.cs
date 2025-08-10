using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Questiontype
{
    public class MultipleChoiceQuestion : Question
    {
        public List<string> Options { get; set; }
        public List<int> CorrectAnswers { get; set; }

        public MultipleChoiceQuestion(string text, DifficultyLevel difficulty, int marks, List<string> options, List<int> correctAnswers)
            : base(text, difficulty, marks)
        {
            Options = options;
            CorrectAnswers = correctAnswers;
        }

        public override bool Ask()
        {
            Console.WriteLine(Text);
            for (int i = 0; i < Options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Options[i]}");
            }

            Console.WriteLine("Enter your answers separated by commas (e.g., 1,3): ");
            string input = Console.ReadLine() ?? " ";
            var answers = input.Split(',').Select(a => int.Parse(a.Trim()) - 1).ToList();

            return !CorrectAnswers.Except(answers).Any() && !answers.Except(CorrectAnswers).Any();
        }
    }

}
