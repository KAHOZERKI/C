namespace GeniusIdiotConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Пожалуйста,введите Ваше имя!");
            var userName = Console.ReadLine();
            userName = CheckForNullorWhiteSpace(userName);
            while (true)
            {
                var questions = GetQuestions();
                var answers = GetAnswers();
                var correctAnswersCount = 0;
                var questionsCount = questions.Count();
                var random = new Random();
                for (int i = 0; i < questionsCount; i++)
                {
                    var randomQuestionsIndex = random.Next(0, questions.Count);
                    Console.WriteLine($"Вопрос №{i + 1}: {questions[randomQuestionsIndex]}");
                    var input = Console.ReadLine();
                    input = CheckForNullorWhiteSpace(input);
                    while (!CheckDigit(input))
                    {
                        Console.WriteLine("Пожалуйста, введите число!");
                        input = Console.ReadLine();
                        input = CheckForNullorWhiteSpace(input);
                    }
                    double userAnswer = Convert.ToDouble(input);
                    if (userAnswer == answers[randomQuestionsIndex])
                    {
                        correctAnswersCount++;
                    }
                    questions.RemoveAt(randomQuestionsIndex);
                    answers.RemoveAt(randomQuestionsIndex);
                }
                string[] diagnoses = GetDiagnoses();
                var userResult = GetDiagnosesFromPercent(questionsCount, correctAnswersCount);
                Console.WriteLine($"{userName}, Вы {diagnoses[userResult]}");
                Console.WriteLine($"{userName}, есть желание попробовать пройти тест еще раз?");
                Console.WriteLine("Пожалуйста, введите ДА или НЕТ");
                var userChoice = Console.ReadLine().ToLower();
                userChoice = CheckForNullorWhiteSpace(userChoice);
                bool choice = GetUserChoice(userChoice);
                if (choice)
                {
                    string writePath = @"D:\repositor\note.txt";
                    Directory.CreateDirectory(Path.GetDirectoryName(writePath));
                    string table = string.Format("|| {0,-15} || {1,-15} || {2,-15} ||", "ФИО", "кол-во правильных ответ", "Диагноз");
                    string userDataForTable = string.Format("|| {0,-15} || {1,15} || {2,15} ||", userName, countCorrectAnswers, diagnoses[digitDiagnoses]);
                    using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                    {
                        if (new FileInfo(writePath).Length == 0)
                        {
                            sw.WriteLine(table);
                        }
                        sw.WriteLine(userDataForTable);
                    }
                    Console.WriteLine("Хотите посмотреть результаты тестирования?");
                    Console.WriteLine("Ответьте да или нет");
                    string userAnswerForWatchingTable = Console.ReadLine();
                    userAnswerForWatchingTable = CheckForNullorWhiteSpace(userAnswerForWatchingTable);
                    if (!GetUserChoice(userAnswerForWatchingTable))
                    {
                        string path = @"D:\repositor\note.txt";
                        using (StreamReader sr = new StreamReader(path))
                        {
                            Console.WriteLine(sr.ReadToEnd());
                        }
                    }
                    break;
                }
            }
        }
        static List<string> GetQuestions()
        {
            var result = new List<string>()
            {"Сколько будет два плюс два умноженное на два?",
             "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?",
             "На двух руках 10 пальцев. Сколько пальцев на 5 руках?",
             "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?",
             "Пять свечей горело, две потухли. Сколько свечей осталось?"};
            return result;
        }
        static List<int> GetAnswers()
        {
            var result = new List<int> { 6, 9, 25, 60, 2 };
            return result;
        }
        static int GetDiagnosesFromPercent(int countQuestions, int countCorrectAnswers)
        {
            double PercentCorrectAnswers = ((double)countCorrectAnswers / countQuestions) * 100;
            switch (PercentCorrectAnswers)
            {
                case < 20: return 0; break;
                case < 40: return 1; break;
                case < 60: return 2; break;
                case < 80: return 3; break;
                case < 95: return 4; break;
                default: return 5; break;
            }
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
        static int GetDiagnosesFromPercent(int countQuestions, int countCorrectAnswers)
        {
            double PercentCorrectAnswers = ((double)countCorrectAnswers / countQuestions) * 100;
            switch (PercentCorrectAnswers)
            {
                case < 20: return 0; break;
                case < 40: return 1; break;
                case < 60: return 2; break;
                case < 80: return 3; break;
                case < 95: return 4; break;
                default: return 5; break;
            }
        }
        static bool GetUserChoice(string userChoice)
        {
            while (userChoice != "да" && userChoice != "нет")
            {
                Console.WriteLine("Пожалуйста, введите ДА или НЕТ");
                userChoice = Console.ReadLine().ToLower();
                userChoice = CheckForNullorWhiteSpace(userChoice);
            }
            if (userChoice == "нет")
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

