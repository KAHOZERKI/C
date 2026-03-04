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
                string[] diagnoses = UsersResultStorage.GetDiagnoses();
                var userResult = UsersResultStorage.GetDiagnosesFromPercent(questionsCount, correctAnswersCount);
                Console.WriteLine($"{userName}, Вы {diagnoses[userResult]}");
                Console.WriteLine($"{userName}, есть желание попробовать пройти тест еще раз?");
                Console.WriteLine("Пожалуйста, введите ДА или НЕТ");
                var userChoice = Console.ReadLine().ToLower();
                userChoice = ActionsWithInputString.CheckForNullorWhiteSpace(userChoice);
                if (!GetUserChoice(userChoice))
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
                    userAnswerForWatchingTable = ActionsWithInputString.CheckForNullorWhiteSpace(userAnswerForWatchingTable);
                    if (GetUserChoice(userAnswerForWatchingTable))
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

