using Newtonsoft.Json;

namespace GeniusIdiot.Library
{
    public class QuestionStorage
    {
        public static string path = "questions.json";
        static public List<Question> GetQuestionList()
        {
            if (FileSystem.IsEmpty(path))
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
                
                string allQuestions = FileSystem.Read(path);
            var results = JsonConvert.DeserializeObject<List<Question>>(allQuestions);
            if (results == null)
            {
                return new List<Question>();
            }
            return results;

        }
        public static void RecordQuestionsToStorage(List<Question> questions)
        {
            var json = JsonConvert.SerializeObject(questions, Formatting.Indented);
            FileSystem.Append(path, json);
        }
        public static void ClearQuestionsStorage(string pathForQuestion)
        {
            FileSystem.ClearFile(pathForQuestion);
        }
        public static Question GetRandomQuestion(List<Question> questions)
        {
            var random = new Random();
            int randomIndex = random.Next(0, questions.Count);
            return questions[randomIndex];
        }

    }
}

