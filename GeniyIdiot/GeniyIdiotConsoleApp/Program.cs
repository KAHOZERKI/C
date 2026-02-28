namespace GeniusIdiotConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var FirstQuestion = new Question("Сколько будет два плюс два умноженное на два?", 6);
            var SecondQuestion = new Question("Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?", 9);
            var ThirdQuestion = new Question("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25);
            var FouthQuestion = new Question("Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?", 60);
            var FiveQuestion = new Question("Пять свечей горело, две потухли. Сколько свечей осталось?", 2);
            var ListQuestions = new List<Question> { FirstQuestion, SecondQuestion, ThirdQuestion, FouthQuestion, FiveQuestion };
            Console.WriteLine("Пожалуйста,введите Ваше ФИО!");
            var userName = Console.ReadLine();
            userName = ActionsWithInputString.CheckForNullorWhiteSpace(userName);
            var Uzver = new User(userName);
            while (true)
            {
                var correctAnswersCount = 0;
                var questionsCount = ListQuestions.Count();
                var random = new Random();
                for (int i = 0; i < questionsCount; i++)
                {
                    var randomQuestionsIndex = random.Next(0, ListQuestions.Count);
                    Console.WriteLine($"Вопрос №{i + 1}: {ListQuestions[randomQuestionsIndex]}");
                    var input = Console.ReadLine();
                    input = ActionsWithInputString.CheckForNullorWhiteSpace(input);
                    while (!ActionsWithInputString.CheckDigit(input))
                    {
                        Console.WriteLine("Пожалуйста, введите число!");
                        input = Console.ReadLine();
                        input = ActionsWithInputString.CheckForNullorWhiteSpace(input);
                    }
                    double userAnswer = Convert.ToDouble(input);
                    if (userAnswer == ListQuestions[randomQuestionsIndex].Answer)
                    {
                        correctAnswersCount++;
                    }
                    ListQuestions.RemoveAt(randomQuestionsIndex);
                }
                string[] diagnoses = Diagnoz.GetDiagnoses();
                var userResult = Diagnoz.GetDiagnosesFromPercent(questionsCount, correctAnswersCount);
                Console.WriteLine($"{userName}, Вы {diagnoses[userResult]}");
                Console.WriteLine($"{userName}, есть желание попробовать пройти тест еще раз?");
                Console.WriteLine("Пожалуйста, введите ДА или НЕТ");
                var userChoice = Console.ReadLine().ToLower();
                userChoice = ActionsWithInputString.CheckForNullorWhiteSpace(userChoice);
                if (!User.GetUserChoice(userChoice))
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
                    if (User.GetUserChoice(userAnswerForWatchingTable))
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
    }
}

