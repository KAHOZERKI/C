namespace GeniusIdiotConsoleApp
{
    public class QuestionStorage
    {
        public List<string> questions = new List<string>{
            "Сколько будет два плюс два умноженное на два?",
            "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?",
            "На двух руках 10 пальцев. Сколько пальцев на 5 руках?",
            "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?",
            "Пять свечей горело, две потухли. Сколько свечей осталось?"
        };
        public  List<int> answers = new List<int>
        {
            6,9,25,60,2
        };

        public  List<Question> GetQuestionList()
        {
            var listQuestions = new List<Question>();

            for (int i = 0; i < questions.Count; i++)
            {
                listQuestions.Add(new Question(questions[i], answers[i]));
            }
            return listQuestions;
        }
    }
}

