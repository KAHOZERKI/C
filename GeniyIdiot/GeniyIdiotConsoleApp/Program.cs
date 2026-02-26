namespace GeniusIdiotConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Пожалуйста,введите Ваше ФИО!");
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
                    string path = "note.txt";
                    string table = string.Format("|| {0,-25} || {1,-25} || {2,-10} ||", "ФИО", "кол-во правильных ответ", "Диагноз");
                    string userDataForTable = string.Format("|| {0,-25} || {1,-25} || {2,-10} ||", userName, correctAnswersCount, diagnoses[userResult]);
                    using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                    {
                        if (new FileInfo(path).Length == 0)
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
                        path = "note.txt";
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
            {
                "Сколько будет два плюс два умноженное на два?",
             "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?",
             "На двух руках 10 пальцев. Сколько пальцев на 5 руках?",
             "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?",
             "Пять свечей горело, две потухли. Сколько свечей осталось?"
            };
            return result;
        }
        static List<int> GetAnswers()
        {
            var result = new List<int> { 6, 9, 25, 60, 2 };
            return result;
        }
        static int GetDiagnosesFromPercent(int QuestionsCount, int countCorrectAnswers)
        {
            double PercentCorrectAnswers = ((double)countCorrectAnswers / QuestionsCount) * 100;
            switch (PercentCorrectAnswers)
            {
                case < 20: return 0;
                case < 40: return 1;
                case < 60: return 2;
                case < 80: return 3;
                case < 95: return 4;
                default: return 5;
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
        static bool GetUserChoice(string userchoice)
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

