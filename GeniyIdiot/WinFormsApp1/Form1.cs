using GeniusIdiot.Library;
using GeniyIdiot.WinForm;
namespace WinFormsApp1
{
    public partial class mainForm : Form
    {
        private User uzver;
        private List<Question> questions;
        private Question currentQuestion;
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
            questionLabel.Text = $"Вопрос № {numberQuestion + 1}";
            numberQuestion++;
        }

        private void ShowNextQuestion()
        {
           
            if (questions.Count == 0)
            {
                
                var userResult = UsersResultStorage.GetDiagnosesFromPercent(questionsCount, uzver.CorrectRightAnswers);
                var diagnoses = UsersResultStorage.GetDiagnoses();

                MessageBox.Show($"Игра окончена! {uzver.Name},Вы: {diagnoses[userResult]}");

                UsersResultStorage.CreateTable(uzver.Name, uzver.CorrectRightAnswers, diagnoses[userResult]);
                var dialogResult = MessageBox.Show("Хотите посмотреть таблицу резудьтатов?", "Результат", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    
                    resultsForm window = new resultsForm();
                    window.ShowDialog();
                }
              
                Application.Exit();
                return; 
            }
            var randomQuestion = QuestionStorage.GetRandomQuestion(questions);
            questionTextLabel.Text = randomQuestion.Text;
            currentQuestion = randomQuestion;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (currentQuestion == null)
            {
                MessageBox.Show("Вопрос не загружен. Возможно, список вопросов пуст.");
                return;
            }

            try
            {
                var input = userAnswerTextBox.Text;
                if (!Check.CheckDigit(input))
                {
                    MessageBox.Show("Введите корректное число (только цифры)!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                UsersResultStorage.GetCorrectRightAnswers(input, currentQuestion.Answer, uzver);
                questions.Remove(currentQuestion);
                userAnswerTextBox.Clear();
                ShowNextQuestion();
                if (questions.Count > 0)
                {
                    questionLabel.Text = $"Вопрос № {numberQuestion + 1}";

                    numberQuestion++;
                }
               
            }
            catch (Exception ex)
            {
                userAnswerTextBox.Clear();
                userAnswerTextBox.Focus();
            }
        }
        private void buttonRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lookResultTable_Click(object sender, EventArgs e)
        {
            MessageBox.Show(UsersResultStorage.WatchResultTable());
        } 
    }
}
