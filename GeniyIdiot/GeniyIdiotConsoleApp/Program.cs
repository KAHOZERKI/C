namespace GeniusIdiotConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Пожалуйста,введите Ваше имя!");
           string userName =Console.ReadLine();
            userName = CheckForNullorWhiteSpace(userName);
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
                    input = CheckForNullorWhiteSpace(input);
                    while (!CheckDigit(input))
                    {
                        Console.WriteLine("Пожалуйста, введите число!");
                        input = Console.ReadLine();  
                    }
                    double userAnswer = Convert.ToDouble(input);
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
                string userChoice = Console.ReadLine().ToLower();
                userChoice = CheckForNullorWhiteSpace(userChoice);
                bool choice = GetUserChoice(userChoice);
                if (choice)
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
            while (userchoice != "да" && userchoice != "нет")
            {
                Console.WriteLine("Пожалуйста, введите ДА или НЕТ");
                userchoice = Console.ReadLine().ToLower();
                userchoice = CheckForNullorWhiteSpace(userchoice);
            }
            if (userchoice == "нет")
            {
                return true;
            }
            return false;
        }
        static bool CheckDigit(string input)
        {
            foreach (var symbol in input)
            {
                if (!char.IsDigit(symbol))
                {
                    return false;
                }
            }
            return true;
        }
        static string CheckForNullorWhiteSpace(string input)
        {

            while (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Пожалуйста,не оставляйте эту строку пустой");
                input = Console.ReadLine();
            }
            return input;
        }
    }
}

