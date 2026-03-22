using GeniusIdiot.Library;

namespace GeniusIdiotConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Пожалуйста,введите Ваше ФИО!");

            var userName = GetValidInput();
            var nextString = "\"---------------------------\\n\"";   
            while (true)
            {
                Console.Clear();
                var uzver = new User(userName);
                var questions = QuestionStorage.GetQuestionList();
                var questionsCount = QuestionStorage.GetQuestionList().Count;
                for (int i = 0; i < questionsCount; i++)
                {
                    var randomQuestion = QuestionStorage.GetRandomQuestion(questions);

                    Console.WriteLine($"Вопрос №{i + 1}: {randomQuestion.Text}");
                    var input = GetValidInput();
                    while (!Check.CheckDigit(input))
                    {
                        Console.WriteLine("Пожалуйста, введите число!");
                        input = GetValidInput();
                    }
                    UsersResultStorage.GetCorrectRightAnswers(input, randomQuestion.Answer,uzver);
                    questions.Remove(randomQuestion);
                }
                var userResult = UsersResultStorage.GetDiagnosesFromPercent(questionsCount, uzver.CorrectRightAnswers);
                var diagnoses= UsersResultStorage.GetDiagnoses();
                Console.WriteLine($"{userName}, Вы {diagnoses[userResult]}");
                UsersResultStorage.CreateTable(userName, uzver.CorrectRightAnswers, diagnoses[userResult]);

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
                    var userQuestionText = GetValidInput();
                    Console.WriteLine("Пожалуйста, введите ответ");
                    var userAnswer = GetValidInput();
                    while (!Check.CheckDigit(userAnswer))
                    {
                        Console.WriteLine("Пожалуйста, введите число!");
                        userAnswer = GetValidInput();
                    }
                    var newQuestion = new Question(userQuestionText, int.Parse(userAnswer));
                    var currentQuestions = QuestionStorage.GetQuestionList();
                    currentQuestions.Add(newQuestion);
                  
                    QuestionStorage.RecordQuestionsToStorage(currentQuestions);

                    Console.WriteLine("Вопрос успешно добавлен!");
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
                    if (Check.CheckDigit(numberOfQuestion))
                    {
                        int index = int.Parse(numberOfQuestion) - 1;
                        if (index >= 0 && index < currentQuestions.Count)
                        {
                            currentQuestions.RemoveAt(index);
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
        public static string CheckForNullorWhiteSpace(string input)
        {
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Пожалуйста,не оставляйте эту строку пустой");
                input = Console.ReadLine();
            }
            return input;
        }
       
        public static string GetValidInput()
        {
            string input = Console.ReadLine();
            return CheckForNullorWhiteSpace(input);
        }
        public static string ChooseCorrectAnswer(string userChoice)
        {

            while ((userChoice != "да" && userChoice != "нет") || string.IsNullOrEmpty(userChoice))
            {
                Console.WriteLine("Пожалуйста, введите ДА или НЕТ");
                userChoice = Console.ReadLine().ToLower();

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

    }
}


