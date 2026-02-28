namespace GeniusIdiotConsoleApp
{
    public class Diagnoz
    {
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
    }
}

