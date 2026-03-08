namespace GeniusIdiotConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Пожалуйста,введите Ваше ФИО!");

            var userName = ActionsWithInputString.GetValidInput();
            var uzver = new User(userName);
            while (true)
            {
                Console.Clear();
                var questions = QuestionStorage.GetQuestionList();
                var correctAnswersCount = 0;
                var questionsCount = questions.Count;
                var random = new Random();
                for (int i = 0; i < questionsCount; i++)
                {
                    var randomQuestionsIndex = random.Next(0, questions.Count);
                    Console.WriteLine($"Вопрос №{i + 1}: {questions[randomQuestionsIndex].Text}");
                    var input = ActionsWithInputString.GetValidInput();
                    while (!ActionsWithInputString.CheckDigit(input))
                    {
                        Console.WriteLine("Пожалуйста, введите число!");
                        input = ActionsWithInputString.GetValidInput();
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
                string path = "note.txt";
                if (FileSystem.IsEmpty(path))
                {
                    string header = string.Format("|| {0,-25} || {1,-25} || {2,-15} ||", "ФИО", "Кол-во ответов", "Диагноз");
                    FileSystem.Append(path, header);
                }
                string userDataForTable = string.Format("|| {0,-25} || {1,-25} || {2,-10} ||", userName, correctAnswersCount, diagnoses[userResult]);
                FileSystem.Append(path, userDataForTable);
                Console.WriteLine("Хотите посмотреть результаты тестирования?");
                Console.WriteLine("Пожалуйста, введите ДА или НЕТ");
                string userAnswerForWatchingTable = Console.ReadLine().ToLower();
                if (GetUserChoice(userAnswerForWatchingTable))
                {
                    string results = FileSystem.Read(path);
                    Console.WriteLine("\n" + results);
                    Console.WriteLine("---------------------------\n");
                }
                Console.WriteLine($"{uzver.Name},Хотите добавить свой вопрос в базу?");
                Console.WriteLine("Пожалуйста, введите ДА или НЕТ");
                String userAnswerForGetNewQuestion = Console.ReadLine().ToLower();
                if (GetUserChoice(userAnswerForGetNewQuestion))
                {
                    Console.WriteLine("Пожалуйста, введите вопрос");
                    string userQuestion = ActionsWithInputString.GetValidInput();
                    Console.WriteLine("Пожалуйста, введите ответ");
                    string userAnswer = ActionsWithInputString.GetValidInput();
                    while (!ActionsWithInputString.CheckDigit(userAnswer))
                    {
                        Console.WriteLine("Пожалуйста, введите число!");
                        userAnswer = ActionsWithInputString.GetValidInput();
                    }
                    var newQuestion = new Question(userQuestion, int.Parse(userAnswer));
                    questions.Add(newQuestion);
                    string line = $"{userQuestion}#{userAnswer}";
                    FileSystem.Append(QuestionStorage.pathForQuestion, line);
                }
                Console.WriteLine($"{uzver.Name},Хотите удалить вопрос из базы?");
                Console.WriteLine("Пожалуйста, введите ДА или НЕТ");
                String userAnswerForDeleteQuestion = Console.ReadLine().ToLower();
                if (GetUserChoice(userAnswerForDeleteQuestion))
                {
                    var currentQuestions = QuestionStorage.GetQuestionList();
                    for (int i = 0; i < currentQuestions.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {currentQuestions[i].Text}");
                    }
                    Console.WriteLine("---------------------------\n");
                    Console.WriteLine("Напишите номер вопроса,который следует удалить");
                    string numberOfQuestion = ActionsWithInputString.GetValidInput();
                    if (ActionsWithInputString.CheckDigit(numberOfQuestion))
                    {
                        int index = int.Parse(numberOfQuestion) - 1;
                        if (index >= 0 && index < currentQuestions.Count)
                        {
                            currentQuestions.RemoveAt(index);
                            QuestionStorage.ClearQuestionsStorage(QuestionStorage.pathForQuestion);
                            QuestionStorage.GetQuestionsToStorage(currentQuestions);
                            Console.WriteLine("Вопрос успешно удален!");
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: вопроса с таким номером нет в списке.");

                        }
                    }
                }
                Console.WriteLine($"{userName}, есть желание попробовать пройти тест еще раз?");
                Console.WriteLine("Пожалуйста, введите ДА или НЕТ");
                var userChoice = Console.ReadLine().ToLower();
                if (!GetUserChoice(userChoice))
                {
                    break;
                }
            }
        }
        public static string ChoozeCorrectAnswer(string userChoice)
        {
            while (userChoice != "да" && userChoice != "нет")
            {
                Console.WriteLine("Пожалуйста, введите ДА или НЕТ");
                userChoice = ActionsWithInputString.GetValidInput().ToLower();
            }
            return userChoice;
        }
        public static bool GetUserChoice(string userChoice)
        {
            userChoice = ChoozeCorrectAnswer(userChoice);
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


