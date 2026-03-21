using Newtonsoft.Json;
using System.Linq;
namespace GeniusIdiot.Library
{
    public class UsersResultStorage

    {
        static string path = "results.json"; 
        
          public static void GetCorrectRightAnswers(string input,int currentQuestionAnswer,User user )
         {
             
             if(!Check.CheckDigit(input))
                return;
            var userAnswer = int.Parse(input);

            if (userAnswer == currentQuestionAnswer)
             {
                 user.CorrectRightAnswers++;
             }
         }
           
        public static int GetDiagnosesFromPercent(int QuestionsCount, int countCorrectAnswers)
        {
            var PercentCorrectAnswers = ((double)countCorrectAnswers / QuestionsCount) * 100;
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
        public static string[] GetDiagnoses()
        {
            var diagnoses = new string[]
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
        public static List<User> GetAllResults()
        {
            if (!File.Exists(path))
            {
                return new List<User>();
            }
            var json = FileSystem.Read(path);
            var results = JsonConvert.DeserializeObject<List<User>>(json);
            if (results == null)
            {
               return new List<User>();
            }
            return results;
        }
        public static void CreateTable(string userName, int correctAnswersCount, string diagnosesUserResult)
        {
            var path = "results.json";
            var allResults = GetAllResults();
            var newUser = new User(userName)
            {
                CorrectRightAnswers = correctAnswersCount,
                Diagnosis = diagnosesUserResult
            };
            allResults.Add(newUser);
            var json = JsonConvert.SerializeObject(allResults, Formatting.Indented);
            FileSystem.Append(path, json);

        }
        public static string WatchResultTable()
        {
            var results = GetAllResults();
            var header = string.Format("|| {0,-25} || {1,-25} || {2,-15} ||\n", "ФИО", "Кол-во ответов", "Диагноз");
            var rows = results.Select(u=>string.Format("|| {0,-25} || {1,-25} || {2,-15} ||\n",u.Name, u.CorrectRightAnswers, u.Diagnosis));
           return header + string.Join("", rows); 
        }
    }
}


