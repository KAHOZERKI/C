using GeniusIdiot.Library;
namespace WinFormsApp1
{
    public partial class mainForm : Form
    {
        private User uzver;
        private List<Question> questions;
        private Question currentQuestion;
        private int correctAnswersCount;
        private int questionsCount;
        private int numberQuestion;
        public mainForm(string userName)
        {
            InitializeComponent();
            uzver = new User(userName);

        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            questions = QuestionStorage.GetQuestionList();
            questionsCount = questions.Count;
            ShowNextQuestion();
            questionLabel.Text = $"Вопрос № {numberQuestion+1}";
            numberQuestion++;
        }

        private void ShowNextQuestion()
        {
            if (questions.Count == 0)
            {
                var userResult = UsersResultStorage.GetDiagnosesFromPercent(questionsCount, correctAnswersCount);
                var diagnoses = UsersResultStorage.GetDiagnoses();

                MessageBox.Show($"Игра окончена! {uzver.Name},Вы: {diagnoses[userResult]}");

                UsersResultStorage.CreateTable(uzver.Name, correctAnswersCount, diagnoses[userResult]);
                var dialogResult = MessageBox.Show("Хотите посмотреть таблицу резудьтатов?", "Результат", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    MessageBox.Show(UsersResultStorage.WatchResultTable());
                }
                Application.Exit();
                
            }

            var randomQuestion = QuestionStorage.GetRandomQuestion(questions);
            questionTextLabel.Text = randomQuestion.Text;
            currentQuestion = randomQuestion;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            try
            {
                var input = userAnswerTextBox.Text;
                var userAnswer = int.Parse(GetNewAnswer(input));
                if (userAnswer == currentQuestion.Answer)
                {
                    User.CorrectRightAnswers++;
                }

                questions.Remove(currentQuestion);
                userAnswerTextBox.Clear();
                questionLabel.Text = $"Вопрос № {numberQuestion + 1}";
                numberQuestion++;
                ShowNextQuestion();
            }
            catch (Exception ex)
            {
                userAnswerTextBox.Clear();
                userAnswerTextBox.Focus();
            }
        }
        private string GetNewAnswer(string input)
        {
            if (string.IsNullOrEmpty(input) || !CheckDigit(input))
            {
                MessageBox.Show("Введите корректное число (только цифры)!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception("Введите число");
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

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
