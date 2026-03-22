
using GeniusIdiot.Library;
namespace GeniyIdiot.WinForm
{
    public partial class resultsForm : Form
    {
        public resultsForm()
        {
            InitializeComponent();
            throw new Exception("ПРОВЕРКА СВЯЗИ");
            LoadResults();
        }
        
            public void LoadResults()

        {
            MessageBox.Show(Path.GetFullPath("results.json"));
            resultsBox.Rows.Clear();

            var results = UsersResultStorage.GetAllResults();

            // 3. Проходим циклом по каждому пользователю
            foreach (var user in results)
            {
                // Добавляем новую строку. 
                // ВАЖНО: порядок (Имя, Баллы, Диагноз) должен совпадать 
                // с порядком ваших колонок в Дизайнере!
                resultsBox.Rows.Add(user.Name, user.CorrectRightAnswers, user.Diagnosis);
            }
        }
        

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
