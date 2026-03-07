namespace GeniusIdiotConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Пожалуйста,введите Ваше ФИО!");
            var userName = Console.ReadLine();
            userName = ActionsWithInputString.CheckForNullorWhiteSpace(userName);
            var uzver = new User(userName);
            var storage = new QuestionStorage();
            while (true)
            {
                var questions = QuestionStorage.GetQuestionList();
                var correctAnswersCount = 0;
                var questionsCount = questions.Count;
                var random = new Random();
                for (int i = 0; i < questionsCount; i++)
                {
                    var randomQuestionsIndex = random.Next(0, questions.Count);
                    Console.WriteLine($"Вопрос №{i + 1}: {questions[randomQuestionsIndex].Text}");
                    var input = Console.ReadLine();
                    input = ActionsWithInputString.CheckForNullorWhiteSpace(input);
                    while (!ActionsWithInputString.CheckDigit(input))
                    {
                        Console.WriteLine("Пожалуйста, введите число!");
                        input = Console.ReadLine();
                        input = ActionsWithInputString.CheckForNullorWhiteSpace(input);
                    }
                    double userAnswer = Convert.ToDouble(input);
                    if (userAnswer == questions[randomQuestionsIndex].Answer)
                    {
                        correctAnswersCount++;
                    }
                    questions.RemoveAt(randomQuestionsIndex);
                }
                string[] diagnoses = User.GetDiagnoses();
                var userResult = User.GetDiagnosesFromPercent(questionsCount, correctAnswersCount);
                Console.WriteLine($"{userName}, Вы {diagnoses[userResult]}");
                string userDataForTable = string.Format("|| {0,-25} || {1,-25} || {2,-10} ||", userName, correctAnswersCount, diagnoses[userResult]);
                StreamWriter sw = FileSystem.WriteSystemFile();
                sw.WriteLine(userDataForTable);
                sw.Close();
                Console.WriteLine($"{userName}, есть желание попробовать пройти тест еще раз?");
                Console.WriteLine("Пожалуйста, введите ДА или НЕТ");
                var userChoice = Console.ReadLine().ToLower();
                userChoice = ActionsWithInputString.CheckForNullorWhiteSpace(userChoice);
                Console.WriteLine("Хотите посмотреть результаты тестирования?");
                Console.WriteLine("Ответьте да или нет");
                string userAnswerForWatchingTable = Console.ReadLine();
                userAnswerForWatchingTable = ActionsWithInputString.CheckForNullorWhiteSpace(userAnswerForWatchingTable);
                if (GetUserChoice(userAnswerForWatchingTable))
                {
                    string results = FileSystem.ReadSystemFile();
                    Console.WriteLine("\n" + results);
                    Console.WriteLine("---------------------------\n");
                }
                if (!GetUserChoice(userChoice))
                {
                    break;
                }
            }
        }
        public static bool GetUserChoice(string userChoice)
        {
            while (userChoice != "да" && userChoice != "нет")
            {
                Console.WriteLine("Пожалуйста, введите ДА или НЕТ");
                userChoice = Console.ReadLine().ToLower();
                userChoice = ActionsWithInputString.CheckForNullorWhiteSpace(userChoice);
            }
            if (userChoice == "да")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
        

