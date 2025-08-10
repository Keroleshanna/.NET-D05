using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Questiontype
{
    public class TrueFalseQuestion : Question
    {
        public bool CorrectAnswer { get; set; }

        public TrueFalseQuestion(string text, DifficultyLevel difficulty, int marks, bool correctAnswer)
            : base(text, difficulty, marks)
        {
            CorrectAnswer = correctAnswer;
        }

        public override bool Ask()
        {
            Console.WriteLine($"{Text} (True/False): ");
            string userInput = Console.ReadLine() ?? " ";
            return bool.TryParse(userInput, out bool answer) && answer == CorrectAnswer;
        }
    }

}
