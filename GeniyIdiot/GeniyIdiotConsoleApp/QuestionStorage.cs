namespace GeniusIdiotConsoleApp
{
    public class QuestionStorage
    {
        public static string pathForQuestion = "questions.txt";
        static public List<Question> GetQuestionList()
        {
            if (FileSystem.IsEmpty(pathForQuestion))
            {
                var questions = new List<Question>()
                {
                new Question("Сколько будет два плюс два умноженное на два?", 6),
                new Question("Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?", 9),
                new Question("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25),
                new Question("Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?", 60),
                new Question("Пять свечей горело, две потухли. Сколько свечей осталось?", 2)
               };
                RecordQuestionsToStorage(questions);
                return questions;
            }
            else
            {
                var questions = new List<Question>();
                string allQuestions = FileSystem.Read(pathForQuestion);
                string[] lines = allQuestions.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    string[] massiveOfQuestion = line.Split('#');
                    questions.Add(new Question(massiveOfQuestion[0].Trim(), int.Parse(massiveOfQuestion[1].Trim())));
                }
                return questions;
            }
        }
        public static void RecordQuestionsToStorage(List<Question> questions)
        {
            foreach (var question in questions)
            {
                FileSystem.Append(pathForQuestion, $"{question.Text}#{question.Answer}");
            }
        }
        public static void ClearQuestionsStorage(string pathForQuestion)
        {
            FileSystem.ClearFile(pathForQuestion);
        }

    }
}

