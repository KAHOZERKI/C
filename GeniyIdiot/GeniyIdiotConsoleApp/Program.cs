namespace GeniusIdiotConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Пожалуйста,введите Ваше ФИО!");

            var userName = GetValidInput();
            var uzver = new User(userName);
            var nextString = "\"---------------------------\\n\"";

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
                    var input = GetValidInput();
                    while (!CheckDigit(input))
                    {
                        Console.WriteLine("Пожалуйста, введите число!");
                        input = GetValidInput();
                    }

                    double userAnswer = Convert.ToDouble(input);
                    if (userAnswer == questions[randomQuestionsIndex].Answer)
                    {
                        correctAnswersCount++;
                    }
                    questions.RemoveAt(randomQuestionsIndex);
                }
                int userResult = UsersResultStorage.GetDiagnosesFromPercent(questionsCount,correctAnswersCount);
                var diagnoses= UsersResultStorage.GetDiagnoses();
                Console.WriteLine($"{userName}, Вы {diagnoses[userResult]}");
                UsersResultStorage.CreateTable(userName, correctAnswersCount, diagnoses[userResult]);

                Console.WriteLine("Хотите посмотреть результаты тестирования?");
                Console.WriteLine("Пожалуйста, введите ДА или НЕТ");
                var userAnswerForWatchingTable = Console.ReadLine().ToLower();
                if (GetUserChoice(userAnswerForWatchingTable))
                {
                    string result= UsersResultStorage.WatchResultTable();
                    Console.WriteLine(result);
                }

                Console.WriteLine($"{uzver.Name},Хотите добавить свой вопрос в базу?");
                Console.WriteLine("Пожалуйста, введите ДА или НЕТ");
                var userAnswerForGetNewQuestion = Console.ReadLine().ToLower();

                if (GetUserChoice(userAnswerForGetNewQuestion))
                {
                    Console.WriteLine("Пожалуйста, введите вопрос");
                    var userQuestion = GetValidInput();
                    Console.WriteLine("Пожалуйста, введите ответ");
                    var userAnswer = GetValidInput();
                    while (!CheckDigit(userAnswer))
                    {
                        Console.WriteLine("Пожалуйста, введите число!");
                        userAnswer = GetValidInput();
                    }
                    var newQuestion = new Question(userQuestion, int.Parse(userAnswer));
                    questions.Add(newQuestion);
                    var line = $"{userQuestion}#{userAnswer}";
                    FileSystem.Append(QuestionStorage.pathForQuestion, line);
                }

                Console.WriteLine($"{uzver.Name},Хотите удалить вопрос из базы?");
                Console.WriteLine("Пожалуйста, введите ДА или НЕТ");
                var userAnswerForDeleteQuestion = Console.ReadLine().ToLower();
                if (GetUserChoice(userAnswerForDeleteQuestion))
                {
                    var currentQuestions = QuestionStorage.GetQuestionList();
                    for (int i = 0; i < currentQuestions.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {currentQuestions[i].Text}");
                    }
                    Console.WriteLine(nextString);
                    Console.WriteLine("Напишите номер вопроса,который следует удалить");
                    var numberOfQuestion = GetValidInput();
                    if (CheckDigit(numberOfQuestion))
                    {
                        int index = int.Parse(numberOfQuestion) - 1;
                        if (index >= 0 && index < currentQuestions.Count)
                        {
                            currentQuestions.RemoveAt(index);
                            QuestionStorage.ClearQuestionsStorage(QuestionStorage.pathForQuestion);
                            QuestionStorage.RecordQuestionsToStorage(currentQuestions);
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
        public static string ChooseCorrectAnswer(string userChoice)
        {
            while (userChoice != "да" && userChoice != "нет")
            {
                Console.WriteLine("Пожалуйста, введите ДА или НЕТ");
                userChoice = GetValidInput().ToLower();
            }
            return userChoice;
        }
        public static bool GetUserChoice(string userChoice)
        {
            userChoice = ChooseCorrectAnswer(userChoice);
            if (userChoice == "да")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string CheckForNullorWhiteSpace(string input)
        {
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Пожалуйста,не оставляйте эту строку пустой");
                input = Console.ReadLine();
            }
            return input;
        }
        public static bool CheckDigit(string input)
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
        public static string GetValidInput()
        {
            string input = Console.ReadLine();
            return CheckForNullorWhiteSpace(input);

        }

    }
}


