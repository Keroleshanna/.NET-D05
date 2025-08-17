using SchoolSystem.Questiontype;

namespace SchoolSystem
{
    internal class Program
    {
        static T GetEnumChoice<T>() where T : struct, Enum
        {
            T result;
            T result1;
            bool validChoice = false;

            do
            {
                string input = Console.ReadLine() ?? string.Empty;

                validChoice = Enum.TryParse(input, out result) && Enum.IsDefined(typeof(T), result);

                if (!validChoice)
                    Console.WriteLine($"Invalid choice. Please enter a valid {typeof(T).Name} value.");

            } while (!validChoice);

            return result;
        }

        static void Main()
        {
            ExamManager manager = new ExamManager();

            Console.WriteLine("Are you a Doctor (D) or Student (S)?");
            string mode = Console.ReadLine()!.ToUpper();

            if (mode == "D")
            {
                while (true)
                {

                    Console.WriteLine("\n--- Doctor Mode ---");
                    Console.WriteLine("Select question type: 1- True/False, 2- Single Choice, 3- Multiple Choice");
                    QuestionType questionType = GetEnumChoice<QuestionType>();

                    Console.WriteLine("Select difficulty: 1- Easy, 2- Medium, 3- Hard");
                    DifficultyLevel difficulty = GetEnumChoice<DifficultyLevel>();

                    Console.WriteLine("Enter question text:");
                    string text = Console.ReadLine() ?? "No Question Enput";

                    Console.WriteLine("Enter marks:");
                    int marks = int.Parse(Console.ReadLine() ?? "No Question Enput");

                    switch (questionType)
                    {
                        case QuestionType.TrueFalse:
                            Console.WriteLine("Enter correct answer (true/false):");
                            bool tfAnswer = bool.Parse(Console.ReadLine() ?? "No Question Enput");
                            manager.AddQuestion(new TrueFalseQuestion(text, difficulty, marks, tfAnswer));
                            break;

                        case QuestionType.SingleChoice:
                            Console.WriteLine("Enter options (comma separated):");
                            var options = Console.ReadLine()?.Split(',').Select(o => o.Trim()).ToList();
                            Console.WriteLine("Enter correct option number:");
                            int correctIndex = int.Parse(Console.ReadLine() ?? "0") - 1;
                            manager.AddQuestion(new SingleChoiceQuestion(text, difficulty, marks, options!, correctIndex));
                            break;

                        case QuestionType.MultipleChoice:
                            Console.WriteLine("Enter options (comma separated):");
                            var mcOptions = Console.ReadLine()?.Split(',').Select(o => o.Trim()).ToList();
                            Console.WriteLine("Enter correct option numbers (comma separated):");
                            var correctAnswers = Console.ReadLine()?.Split(',').Select(a => int.Parse(a.Trim()) - 1).ToList();
                            manager.AddQuestion(new MultipleChoiceQuestion(text, difficulty, marks, mcOptions!, correctAnswers!));
                            break;
                    }

                    Console.WriteLine("Do you want to add another question? (y/n)");
                    if (Console.ReadLine()?.ToLower() != "y")
                        break;
                }
            }

            Console.WriteLine("\n--- Student Mode ---");
            Console.WriteLine("Select difficulty: 1- Easy, 2- Medium, 3- Hard");
            DifficultyLevel selectedDifficulty = (DifficultyLevel)int.Parse(Console.ReadLine() ?? " ");

            manager.StartExam(selectedDifficulty);
        }
    }
}
