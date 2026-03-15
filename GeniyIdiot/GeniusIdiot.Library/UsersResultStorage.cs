namespace GeniusIdiot.Library
{
    public class UsersResultStorage

    {
        static string path = "note.txt";

        public static int GetDiagnosesFromPercent(int QuestionsCount, int countCorrectAnswers)
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
        public static string[] GetDiagnoses()
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
        public static void CreateTable(string userName, int correctAnswersCount, string diagnosesUserResult)
        {
            var path = "note.txt";
            if (FileSystem.IsEmpty(path))
            {
                var header = string.Format("|| {0,-25} || {1,-25} || {2,-15} ||", "ФИО", "Кол-во ответов", "Диагноз");
                FileSystem.Append(path, header);
            }
            var userDataForTable = string.Format("|| {0,-25} || {1,-25} || {2,-10} ||", userName, correctAnswersCount, diagnosesUserResult);
            FileSystem.Append(path, userDataForTable);
        }
        public static string WatchResultTable()
        {
            return FileSystem.Read(path);
        }
    }
}


