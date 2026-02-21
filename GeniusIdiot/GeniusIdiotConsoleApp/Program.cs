namespace GeniusIdiotConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Пожалуйста,введите Ваше имя!");
            string userName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(userName))
            {
                Console.WriteLine("Имя не может быть пустым. Пожалуйста, представьтесь...");
                userName = Console.ReadLine();
            }
            while (true) 
            {
                List<string> questions = GetQuestions();
                List<int> answers = GetAnswers();
                int countCorrectAnswers = 0;
                int countQuestions = questions.Count();
                Random random = new Random();
                for (int i = 0; i < countQuestions; i++)
                {
                    int randomQuestionsIndex = random.Next(0, questions.Count);
                    Console.WriteLine($"Вопрос №{i + 1}: {questions[randomQuestionsIndex]}");
                    string input = Console.ReadLine();
                    double userAnswer;    
                    while (!double.TryParse(input, out userAnswer))
                    {
                        Console.WriteLine("Пожалуйста, введите число!");
                        input = Console.ReadLine();
                    }
                    if (userAnswer == answers[randomQuestionsIndex])
                    {
                        countCorrectAnswers++;
                    }
                    questions.RemoveAt(randomQuestionsIndex);
                    answers.RemoveAt(randomQuestionsIndex);
                }
                string[] diagnoses = GetDiagnoses();
                Console.WriteLine($"{userName}, Вы {diagnoses[countCorrectAnswers]}");
                Console.WriteLine($"{userName}, есть желание попробовать пройти тест еще раз?");

                string userChoice = "";
                var Choice = GetUserChoice(userChoice);
                if (!Choice)
                {
                    break;
                }
            }
        }
        static List<string> GetQuestions()
        {
            List<string> result = new List<string>()
            {"Сколько будет два плюс два умноженное на два?",
             "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?",
             "На двух руках 10 пальцев. Сколько пальцев на 5 руках?",
             "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?",
             "Пять свечей горело, две потухли. Сколько свечей осталось?"};
            return result;
        }
        static List<int> GetAnswers()
        {
            List<int> result = new List<int> { 6, 9, 25, 60, 2 };
            return result;
        }
        static string[] GetDiagnoses()
        {
            string[] diagnoses = new string[]
            {
                "Идиот",
                "Кретин",
                "Дурак",
                "Нормальный",
                "Талант",
                "Гений"
            };
            return diagnoses;
        }
        static bool GetUserChoice(string userchoice)
        {
            string userChoice = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(userChoice))
            {
                Console.WriteLine("Пожалуйста,введите \"да\" или \"нет\"");
                userChoice = Console.ReadLine().ToLower();
            }
            if (userChoice == "нет")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

