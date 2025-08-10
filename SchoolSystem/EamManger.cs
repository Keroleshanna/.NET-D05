using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem
{
    public class ExamManager
    {
        private List<Question> _questions = new List<Question>();

        public void AddQuestion(Question q)
        {
            _questions.Add(q);
        }

        public void StartExam(DifficultyLevel difficulty)
        {
            var filtered = _questions.Where(q => q.Difficulty == difficulty).ToList();
            int score = 0;

            foreach (var q in filtered)
            {
                if (q.Ask())
                {
                    score += q.Marks;
                    Console.WriteLine("Correct!\n");
                }
                else
                {
                    Console.WriteLine("Wrong!\n");
                }
            }

            Console.WriteLine($"Your score: {score} / {filtered.Sum(q => q.Marks)}");
        }
    }

}
